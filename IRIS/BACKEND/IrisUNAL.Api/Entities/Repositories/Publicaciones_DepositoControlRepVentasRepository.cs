using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_DepositoControlRepVentasRepository : SuperType<Publicaciones_DepositoControlRepVentas>, IPublicaciones_DepositoControlRepVentasRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DepositoControlRepVentasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DepositoControlRepVentasRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DepositoControlRepVentas(int id_repventas)
        {
            Delete(id_repventas);
            return true;
        }

        public IEnumerable<Publicaciones_DepositoControlRepVentas> GetAllPublicaciones_DepositoControlRepVentas()
        {
            return Get();
        }

        public Publicaciones_DepositoControlRepVentas GetPublicaciones_DepositoControlRepVentasDetails(int id_repventas)
        {
            return Get(id_repventas);
        }

        public bool InsertPublicaciones_DepositoControlRepVentas(Publicaciones_DepositoControlRepVentas publicaciones_DepositoControlRepVentas)
        {
            Add(publicaciones_DepositoControlRepVentas);
            return true;
        }

        public bool UpdatePublicaciones_DepositoControlRepVentas(Publicaciones_DepositoControlRepVentas publicaciones_DepositoControlRepVentas)
        {
            Update(publicaciones_DepositoControlRepVentas);
            return true;
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

        public DataTableAdapter<Publicaciones_DepositoControlRepVentas> GetDataTablePublicaciones_DepositoControlRepVentasByPublicacion(int id_crearpublicacion, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_DepositoControlRepVentas, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_DepositoControlRepVentas, string>> orderByFunc = null;
            Expression<Func<Publicaciones_DepositoControlRepVentas, DateTime>> orderByDateFunc = null;
            Expression<Func<Publicaciones_DepositoControlRepVentas, int>> orderByIntFunc = null;

            Expression<Func<Publicaciones_DepositoControlRepVentas, object>> parameter1 = m => m.ObjDistribuidor;
            Expression<Func<Publicaciones_DepositoControlRepVentas, object>>[] parameterArray = new Expression<Func<Publicaciones_DepositoControlRepVentas, object>>[] { parameter1 };

            bool isOrderDesc = false;


            if (model.SortColumn.ToLower() == "id_repventas")
                orderByIntFunc = CreateExpressionOrderByInt<Publicaciones_DepositoControlRepVentas>("id_repventas");
            else
                if (model.SortColumn.ToLower() == "fecreporte")
                orderByDateFunc = CreateExpressionOrderByDate<Publicaciones_DepositoControlRepVentas>("fecreporte");


            //FILTRA POR LA PUBLICACION
            srchByFunc = p => p.id_crearpublicacion == id_crearpublicacion;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_crearpublicacion == id_crearpublicacion;
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();

            var data = (model.SortColumn.ToLower() == "fecreporte") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_DepositoControlRepVentas> result = new DataTableAdapter<Publicaciones_DepositoControlRepVentas>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }
    }
}