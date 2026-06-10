using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models.DTO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities
{
    public class PublicacionInformesRepository : SuperType<PublicacionIngresoVentasDTO>
    {
        private ApplicationDbContext _context;

        public PublicacionInformesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public PublicacionInformesRepository()
        {
            _context = new ApplicationDbContext();
        }

        public PublicacionIngresoVentasDTO GetIngresosVentas(int id_crearpublicacion)
        {
            var rvtas = (from rv in _context.publicaciones_depositocontrolrepventas
                         join a in _context.publicaciones_depositocontrolacta on rv.id_crearpublicacion equals a.id_crearpublicacion into ac
                         from iv in ac.DefaultIfEmpty()
                         where rv.id_crearpublicacion == id_crearpublicacion
                         group rv by iv into dt
                         select new
                         {
                             und = dt.Sum(x => x.unidadesvendidas), // rv.unidadesvendidas,
                             vtas = dt.Sum(x => x.valorventas), // rv.valorventas,
                             comi = dt.Sum(x => x.valorcomision), // rv.valorcomision,
                             cunit = dt.Key.costounitario //iv.costounitario
                         }).FirstOrDefault();


            PublicacionIngresoVentasDTO ingresos = new PublicacionIngresoVentasDTO();
            decimal margen = 0;

            if (rvtas != null)
            {
                ingresos.unidades = rvtas.und;
                ingresos.ventas = rvtas.vtas;
                ingresos.comision = rvtas.comi;
                ingresos.costounitario = 0;
                ingresos.neto = ingresos.ventas - ingresos.comision;

                if (rvtas.cunit != null)
                {
                    ingresos.costounitario = (decimal)rvtas.cunit;
                }

                ingresos.ingresounitario = 0;
                ingresos.margenvalor = 0;
                ingresos.margenporcentaje = 0;

                if (ingresos.unidades != 0)
                    ingresos.ingresounitario = decimal.Round((decimal)ingresos.neto / ingresos.unidades, 2, MidpointRounding.AwayFromZero);

                ingresos.margenvalor = ingresos.ingresounitario - ingresos.costounitario;

                if (ingresos.ingresounitario != 0)
                {
                    margen = (ingresos.margenvalor / ingresos.ingresounitario) * 100;
                    margen = decimal.Round(margen, 2, MidpointRounding.AwayFromZero);
                    ingresos.margenporcentaje = margen;
                }

            }

            return ingresos;
        }

        public PublicacionInventarioDTO GetInventarioByPublicacion(int id_crearpublicacion)
        {
            var queryinv = "select r.id_crearpublicacion, ejemplaresinstitucional,ejemplarescomercializa,ejemplaresinmovil, " +
                "coalesce(institucional,0) mvtoinstitucional, coalesce(ajusteins,0) ajusteins, coalesce(comercial, 0) mvtocomercial, " +
                "coalesce(ajustecom, 0) ajustecomercial, coalesce(ajusteinmovil, 0) ajusteinmovil, coalesce(unidadesvendidas, 0) unidadesvendidas from " +
            //resolucion
                "(select id_crearpublicacion, ejemplaresinstitucional, ejemplarescomercializa, ejemplaresinmovil from publicaciones_depositoresolucion " +
                "where id_crearpublicacion = @publicacion) as r " +
                "left join " +
            //--entregas - devoluciones institucional
                "(select id_crearpublicacion, coalesce(sum(cantidad), 0) institucional from publicaciones_depositodistribucion " +
                "where id_crearpublicacion = @publicacion " +
                "group by id_crearpublicacion) as mi " +
                "on r.id_crearpublicacion = mi.id_crearpublicacion " +
                "left join " +
            //--ajustes institucional
                "(select id_crearpublicacion, coalesce(sum(cantidad), 0) ajusteins from publicaciones_depositocontrolinventariomovimientos " +
                "where id_crearpublicacion = @publicacion and id_bodega = 2 " +
                "group by id_crearpublicacion) as ai " +
                "on r.id_crearpublicacion = ai.id_crearpublicacion " +
                "left join " +
            //--entregas - devoluciones comercial
                "(select id_crearpublicacion, coalesce(sum(cantidad), 0) comercial from publicaciones_depositodistribucioncomercial " +
                "where id_crearpublicacion = @publicacion " +
                "group by id_crearpublicacion) as mc " +
                "on r.id_crearpublicacion = mc.id_crearpublicacion " +
                "left join " +
            //--ajustes comercial
                "(select id_crearpublicacion, coalesce(sum(cantidad), 0) ajustecom from publicaciones_depositocontrolinventariomovimientos " +
                "where id_crearpublicacion = @publicacion and id_bodega = 3 " +
                "group by id_crearpublicacion) as ac " +
                "on r.id_crearpublicacion = ac.id_crearpublicacion " +
                "left join " +
            //--ajustes inamovible
                "(select id_crearpublicacion, coalesce(sum(cantidad), 0) ajusteinmovil from publicaciones_depositocontrolinventariomovimientos " +
                "where id_crearpublicacion = @publicacion and id_bodega = 1 " +
                "group by id_crearpublicacion) as a " +
                "on r.id_crearpublicacion = a.id_crearpublicacion " +
                "left join " +
            //--reporte ventas
                "(select id_crearpublicacion, coalesce(sum(unidadesvendidas), 0) unidadesvendidas from publicaciones_depositocontrolrepventas " +
                "where id_crearpublicacion = @publicacion " +
                "group by id_crearpublicacion) as v " +
                "on r.id_crearpublicacion = v.id_crearpublicacion";

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@publicacion", id_crearpublicacion));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<PublicacionInventarioDTO>(queryinv, Param).FirstOrDefault();

            PublicacionInventarioDTO inventario = new PublicacionInventarioDTO();
            inventario.invinamovible = 0;
            inventario.invinstitucional = 0;
            inventario.invcomercial = 0;
            inventario.invterceros = 0;

            if (datos != null)
            {
                inventario = datos;

                inventario.invinamovible = inventario.ejemplaresinmovil + inventario.ajusteinmovil;
                inventario.invinstitucional = inventario.ejemplaresinstitucional - inventario.mvtoinstitucional + inventario.ajusteins;
                inventario.invcomercial = inventario.ejemplarescomercializa - inventario.mvtocomercial + inventario.ajustecomercial;
                inventario.invterceros = inventario.mvtocomercial - inventario.unidadesvendidas;
            }

            return inventario;
        }
    }
}