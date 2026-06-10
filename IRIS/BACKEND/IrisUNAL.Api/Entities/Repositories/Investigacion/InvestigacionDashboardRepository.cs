using DocumentFormat.OpenXml.Spreadsheet;
using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.TableModel;
using Npgsql;
using SpreadsheetLight;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories.Investigacion
{
    public class InvestigacionDashboardRepository
    {
        private ApplicationDbContext _context;

        public InvestigacionDashboardRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public InvestigacionDashboardRepository()
        {
            _context = new ApplicationDbContext();
        }

        //Funciones sin ningun filtro unicamente para poder cargar los dropdown con la informacion de la DB
        public IEnumerable DropdownMontoEjecutadoLiteral()
        {
            var registros = _context.Database.SqlQuery<MontoEjecutadoLiteral>("select lu.nmliteral as Literal, sm.nmsemestre as Semestre, sum(ap.valorneto) as Monto_Ejecutado from investigacion_aplicarpago ap join investigacion_crearproyecto cp on cp.id_crearproyecto = ap.id_crearproyecto join literal_ugi lu on cp.id_literal = lu.id_literal join semestre sm on ap.id_semestre = sm.id_semestre group by lu.nmliteral, sm.nmsemestre");

            return registros;
        }
        public IEnumerable DropdownMontoBalanceMontoComprometido_Comprometer()
        {
            var registros = _context.Database.SqlQuery<BalanceMontoComprometido>("select lu.nmliteral as Literal, sum(ga.valortotal) as Comprometido, cp.saldoporcomprometer from investigacion_gasto ga join investigacion_crearproyecto cp on ga.id_crearproyecto = cp.id_crearproyecto join literal_ugi lu on cp.id_literal = lu.id_literal group by lu.nmliteral, cp.saldoporcomprometer");

            return registros;
        }
        public IEnumerable DropdownPresupuestoTotalSemestreVigente()
        {
            var registros = _context.Database.SqlQuery<presupuestoTotalSemestreVigente>("select lu.nmliteral as Literal, sm.nmsemestre as Semestre, sum(cs.valorproyectado) as Presupuesto_Total from ugi_semestre us join semestre sm on sm.id_semestre = us.id_semestre join ugi_conceptosemestre cs on cs.id_ugisemestre = us.id_ugisemestre Join ugi_literalsemestre ls on cs.id_ugiliteralsemestre = ls.id_ugiliteralsemestre join literal_ugi lu on ls.id_literal = lu.id_literal group by lu.nmliteral, sm.nmsemestre order by sm.nmsemestre asc");

            return registros;
        }
        public IEnumerable DropdownEjecutadoTotalPorcentaje()
        {
            var registros = _context.Database.SqlQuery<ejecutadoTotalPorcentaje>("	select lu.nmliteral as Literal, sm.nmsemestre as Semestre, sum(ap.valorneto) as Monto_Ejecutado, (select(sum(ga.valortotal) / (select sum(cs.valorproyectado) from ugi_conceptosemestre cs)) as Porcentaje_Presupuesto from investigacion_gasto ga) from investigacion_aplicarpago ap join investigacion_crearproyecto cp on cp.id_crearproyecto = ap.id_crearproyecto join literal_ugi lu on cp.id_literal = lu.id_literal join semestre sm on ap.id_semestre = sm.id_semestre group by lu.nmliteral, sm.nmsemestre");

            return registros;
        }
        public IEnumerable DropdownDiferenciaTotalComprometidoEjecutado()
        {
            var registros = _context.Database.SqlQuery<diferenciaTotalComprometidoEjecutado>("select lu.nmliteral as Literal, sum(ga.valortotal) as Comprometido, (select sum(ap.valorneto) as Monto_Ejecutado from investigacion_aplicarpago ap),(select sum(ga.valortotal) - (select sum(ap.valorneto) as Monto_Ejecutado from investigacion_aplicarpago ap)) as Monto_Ejecutar from investigacion_gasto ga join investigacion_crearproyecto cp on ga.id_crearproyecto = cp.id_crearproyecto join literal_ugi lu on cp.id_literal = lu.id_literal group by lu.nmliteral");

            return registros;
        }





        // Funciones con Filtro Semestre y literal Para ser mostradas como Graficos

        public IEnumerable MontoEjecutadoLiteral(string literal, string semestre)
        {



            string qry = "select lu.nmliteral as Literal, sm.nmsemestre as Semestre, sum(ap.valorneto) as Monto_Ejecutado from investigacion_aplicarpago ap join investigacion_crearproyecto cp on cp.id_crearproyecto = ap.id_crearproyecto join literal_ugi lu on cp.id_literal = lu.id_literal join semestre sm on ap.id_semestre = sm.id_semestre where nmliteral = @literal AND nmsemestre = @semestre group by lu.nmliteral, sm.nmsemestre";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@literal", literal));
            parameterList.Add(new NpgsqlParameter("@semestre", semestre));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<MontoEjecutadoLiteral>(qry, Param).ToList();



            return datos;
        }

     
        public IEnumerable EstadoProyecto()
        {

            string qry = "select ep.nmestado,count(*)from investigacion_estadoproyecto ep join investigacion_crearproyecto cp on ep.id_estado = cp.id_estado group by ep.id_estado";
            //List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            //parameterList.Add(new NpgsqlParameter("@count", count));
            //parameterList.Add(new NpgsqlParameter("@nmestado", nmestado));
            //NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<ProyectosporEstado>(qry);



            return datos;
        }
        public IEnumerable MontoEjecutadoLiteralFilter(string literal, string semestre)
        {



            string qry = "select nmliteral, nmsemestre, sum(cos.valorproyectado) as proyectado from ugi_conceptosemestre cos join ugi_semestre ugis on cos.id_ugisemestre = ugis.id_ugisemestre join semestre se on ugis.id_semestre = se.id_semestre join ugi_literalsemestre li on cos.id_ugiliteralsemestre = li.id_ugiliteralsemestre join literal_ugi liugi on li.id_literal = liugi.id_literal where nmliteral = @literal AND nmsemestre = @semestre group by nmliteral, nmsemestre ";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@literal", literal));
            parameterList.Add(new NpgsqlParameter("@semestre", semestre));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<MontoEjecutadoLiteralFilter>(qry, Param).ToList();



            return datos;
        }
        public IEnumerable MontoComprometidoComprometer(string literal)
        {
            var qry = "select lu.nmliteral as Literal, sum(ga.valortotal) as Comprometido, (select sum(ap.valorneto) as Monto_Ejecutado from investigacion_aplicarpago ap),(select sum(ga.valortotal) - (select sum(ap.valorneto) as Monto_Ejecutado from investigacion_aplicarpago ap)) as Monto_Ejecutar from investigacion_gasto ga join investigacion_crearproyecto cp on ga.id_crearproyecto = cp.id_crearproyecto join literal_ugi lu on cp.id_literal = lu.id_literal where lu.nmliteral = @literal group by lu.nmliteral";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@literal", literal));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<Comprometido_comprometer>(qry, Param).ToList();

            return datos;
        }


        public IEnumerable BalanceMontoComprometido_Comprometer(string literal, string semestre)
        {
            string qry = "select lu.nmliteral as Literal, sum(ga.valortotal) as Comprometido, sm.nmsemestre from investigacion_gasto ga join investigacion_crearproyecto cp on ga.id_crearproyecto = cp.id_crearproyecto join literal_ugi lu on cp.id_literal = lu.id_literal join investigacion_aplicarpago ap on cp.id_crearproyecto = ap.id_crearproyecto join semestre sm on ap.id_semestre = sm.id_semestre where lu.nmliteral = @literal and sm.nmsemestre = @semestre  group by lu.nmliteral, sm.nmsemestre";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@literal", literal));
            parameterList.Add(new NpgsqlParameter("@semestre", semestre));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<BalanceMontoComprometido>(qry, Param).ToList();


            return datos;
        }
        public IEnumerable PresupuestoTotalSemestreVigente(string semestre, string literal)
        {
            string qry = "select lu.nmliteral as literal, sm.nmsemestre as semestre, sum(cs.valorproyectado) as presupuesto_total from ugi_semestre us join semestre sm on sm.id_semestre = us.id_semestre join ugi_conceptosemestre cs on cs.id_ugisemestre = us.id_ugisemestre join ugi_literalsemestre ls on cs.id_ugiliteralsemestre = ls.id_ugiliteralsemestre join literal_ugi lu on ls.id_literal = lu.id_literal where nmliteral = @literal and nmsemestre = @semestre group by lu.nmliteral, sm.nmsemestre order by sm.nmsemestre asc";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@literal", literal));
            parameterList.Add(new NpgsqlParameter("@semestre", semestre));

            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<presupuestoTotalSemestreVigente>(qry, Param).ToList();

            return datos;
        }
        public IEnumerable ComprometidoTotalPorcentaje()
        {

            var registros = _context.Database.SqlQuery<comprometidoTotalPorcentaje>("select sum(ga.valortotal) as Total_Comprometido, (select sum(cs.valorproyectado) from ugi_conceptosemestre cs) as Total_Presupuesto, (sum(ga.valortotal) / (select sum(cs.valorproyectado) from ugi_conceptosemestre cs)) as Porcentaje_Presupuesto from investigacion_gasto ga ");

            return registros;
        }
        public IEnumerable EjecutadoTotalPorcentaje(string semestre, string literal)
        {
            string qry = "	select lu.nmliteral as Literal, sm.nmsemestre as Semestre, sum(ap.valorneto) as Monto_Ejecutado, (select(sum(ga.valortotal) / (select sum(cs.valorproyectado) from ugi_conceptosemestre cs)) as Porcentaje_Presupuesto from investigacion_gasto ga) from investigacion_aplicarpago ap join investigacion_crearproyecto cp on cp.id_crearproyecto = ap.id_crearproyecto join literal_ugi lu on cp.id_literal = lu.id_literal join semestre sm on ap.id_semestre = sm.id_semestre where nmliteral = @literal AND nmsemestre = @semestre group by lu.nmliteral, sm.nmsemestre";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@literal", literal));
            parameterList.Add(new NpgsqlParameter("@semestre", semestre));

            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<ejecutadoTotalPorcentaje>(qry, Param).ToList();

            return datos;
        }
        public IEnumerable DiferenciaTotalComprometidoEjecutado(string literal)
        {
            string qry = "select lu.nmliteral as Literal, sum(ga.valortotal) as Comprometido, (select sum(ap.valorneto) as Monto_Ejecutado from investigacion_aplicarpago ap),(select sum(ga.valortotal) - (select sum(ap.valorneto) as Monto_Ejecutado from investigacion_aplicarpago ap)) as Monto_Ejecutar from investigacion_gasto ga join investigacion_crearproyecto cp on ga.id_crearproyecto = cp.id_crearproyecto join literal_ugi lu on cp.id_literal = lu.id_literal where nmliteral = @literal group by lu.nmliteral";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@literal", literal));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<diferenciaTotalComprometidoEjecutado>(qry, Param).ToList();


            return datos;
        }
        public IEnumerable BotonInteractivo()
        {
            var registros = _context.Database.SqlQuery<botonInteractivo>("select lu.nmliteral as Literal, sm.nmsemestre as Semestre, sum(cs.valorproyectado) as Presupuesto_Total from ugi_semestre us join semestre sm on sm.id_semestre = us.id_semestre join ugi_conceptosemestre cs on cs.id_ugisemestre = us.id_ugisemestre Join ugi_literalsemestre ls on cs.id_ugiliteralsemestre = ls.id_ugiliteralsemestre join literal_ugi lu on ls.id_literal = lu.id_literal group by lu.nmliteral, sm.nmsemestre order by sm.nmsemestre asc");

            return registros;
        }
        public IEnumerable ProyectosPorEstadoByLiteral(string literal, int anio, int rango1, int rango2)
        {
            string qry = "SELECT EP.NMESTADO, COUNT(*) FROM INVESTIGACION_ESTADOPROYECTO EP" + 
                            " JOIN INVESTIGACION_CREARPROYECTO CP ON EP.ID_ESTADO = CP.ID_ESTADO" + 
                            " JOIN literal_ugi lu on cp.id_literal = lu.id_literal" + 
                            " WHERE lu.nmliteral = @literal and DATE_PART('year'," + 
                            " CP.FECHAINICIO) = @anio AND DATE_PART('month'," + 
						    " CP.FECHAINICIO) BETWEEN @rango1 AND @rango2" + 
                            " GROUP BY EP.ID_ESTADO, EP.NMESTADO;";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@anio", anio));
            parameterList.Add(new NpgsqlParameter("@literal", literal));
            parameterList.Add(new NpgsqlParameter("@rango1", rango1));
            parameterList.Add(new NpgsqlParameter("@rango2", rango2));

            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<ProyectosporEstado>(qry, Param).ToList();

            return datos;
        }


        //----------------------------------------
        //Funciones definidas para filtrar unicamente por semestre 

        public IEnumerable ValorProyectadoSemestre(string semestre)
        {



            string qry = "SELECT  nmsemestre, SUM(COS.VALORPROYECTADO) AS proyectado" + 
                            " FROM UGI_CONCEPTOSEMESTRE COS" + 
                            " JOIN UGI_SEMESTRE UGIS ON COS.ID_UGISEMESTRE = UGIS.ID_UGISEMESTRE" + 
                            " JOIN SEMESTRE SE ON UGIS.ID_SEMESTRE = SE.ID_SEMESTRE" +
                            " WHERE nmsemestre = @semestre" +
                            " GROUP BY nmsemestre";

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@semestre", semestre));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<ValorProyectadoSemestre>(qry, Param).ToList();



            return datos;
        }

        public IEnumerable MontoEjecutadoSemestre(string semestre)
        {



            string qry = "SELECT SM.NMSEMESTRE AS semestre, SUM(AP.VALORNETO) AS monto_ejecutado" + 
                            " FROM INVESTIGACION_APLICARPAGO AP" + 
                            " JOIN SEMESTRE SM ON AP.ID_SEMESTRE = SM.ID_SEMESTRE" + 
                            " WHERE NMSEMESTRE = @semestre" +
                            " GROUP BY SM.NMSEMESTRE";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@semestre", semestre));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<MontoEjecutadoSemestre>(qry, Param).ToList();



            return datos;
        }

        public IEnumerable MontoComprometido_ComprometerSemestre(string semestre)
        {
            string qry = "SELECT SUM(GA.VALORTOTAL) AS comprometido, SM.NMSEMESTRE" + 
                            " FROM INVESTIGACION_GASTO GA" + 
                            " JOIN INVESTIGACION_CREARPROYECTO CP ON GA.ID_CREARPROYECTO = CP.ID_CREARPROYECTO" + 
                            " JOIN INVESTIGACION_APLICARPAGO AP ON CP.ID_CREARPROYECTO = AP.ID_CREARPROYECTO" + 
                            " JOIN SEMESTRE SM ON AP.ID_SEMESTRE = SM.ID_SEMESTRE WHERE SM.NMSEMESTRE = @semestre" + 
                            " GROUP BY SM.NMSEMESTRE";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@semestre", semestre));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<MontoComprometidoComprometerSemestre>(qry, Param).ToList();


            return datos;
        }

        public IEnumerable ProyectosPorEstado(int anio, int rango1, int rango2)
        {
            string qry = "SELECT ep.nmestado, COUNT(*) FROM investigacion_estadoproyecto ep JOIN investigacion_crearproyecto cp ON ep.id_estado = cp.id_estado WHERE date_part('year', cp.fechainicio) = @anio AND date_part('month', cp.fechainicio) BETWEEN @rango1 AND @rango2 GROUP BY ep.id_estado, ep.nmestado; ";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@anio", anio));
            parameterList.Add(new NpgsqlParameter("@rango1", rango1));
            parameterList.Add(new NpgsqlParameter("@rango2", rango2));

            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<ProyectosporEstado>(qry, Param).ToList();

            return datos;
        }


        public IEnumerable ConvovatoriasPorFuenteBySemestre(int anio, int rango1, int rango2)
        {
            string qry = "select cf.nmfuentecnv, count(cp.id_crearproyecto) from investigacion_crearproyecto cp join convocatoria co " +
                            "on cp.id_convocatoria = co.id_convocatoria join convocatoria_fuentecnv cf " + 
                            "on co.id_fuentecnv = cf.id_fuentecnv join literal_ugi lu on cp.id_literal = lu.id_literal " + 
                            "where lu.nmliteral = 'A' AND DATE_PART('year',cp.fechainicio) = @anio " + 
                            "AND DATE_PART('month',cp.fechainicio) BETWEEN @rango1 AND @rango2 group by cf.nmfuentecnv";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@anio", anio));
            parameterList.Add(new NpgsqlParameter("@rango1", rango1));
            parameterList.Add(new NpgsqlParameter("@rango2", rango2));

            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<ProyectosporEstadoConvovatoriasPorFuenteDTO>(qry, Param).ToList();

            return datos;
        }
        public IEnumerable PresuspuestoTotalComprometidoPorcentajeBySemestre(string semestre, int anio, int rango1, int rango2)
        {
            string qry = "SELECT SUM(GA.VALORTOTAL) AS total_comprometido, (SELECT SUM(CS.VALORPROYECTADO) FROM UGI_CONCEPTOSEMESTRE CS JOIN UGI_SEMESTRE US ON CS.ID_UGISEMESTRE = US.ID_UGISEMESTRE JOIN SEMESTRE SE ON US.ID_SEMESTRE = SE.ID_SEMESTRE WHERE se.nmsemestre = @semestre ) AS total_presupuesto, (SUM(GA.VALORTOTAL) / (SELECT SUM(CS.VALORPROYECTADO) FROM UGI_CONCEPTOSEMESTRE CS JOIN UGI_SEMESTRE US ON CS.ID_UGISEMESTRE = US.ID_UGISEMESTRE JOIN SEMESTRE SE ON US.ID_SEMESTRE = SE.ID_SEMESTRE WHERE se.nmsemestre = @semestre )) AS porcentaje_presupuesto FROM INVESTIGACION_GASTO GA WHERE DATE_PART('year', GA.FECHALEGALIZACIONORDEN) = @anio AND DATE_PART('month', GA.FECHALEGALIZACIONORDEN) BETWEEN @rango1 AND @rango2; ";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@anio", anio));
            parameterList.Add(new NpgsqlParameter("@semestre", semestre));
            parameterList.Add(new NpgsqlParameter("@rango1", rango1));
            parameterList.Add(new NpgsqlParameter("@rango2", rango2));

            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<PresuspuestoTotalComprometidoBySemestreDTO>(qry, Param).ToList();

            return datos;
        }
        public IEnumerable PresuspuestoTotalComprometidoPorcentajeBySemestreAndLiteral(string semestre, string literal ,int anio, int rango1, int rango2)
        {
            string qry = "SELECT SUM(ga.VALORTOTAL) AS total_comprometido, (SELECT SUM(CS.VALORPROYECTADO) FROM UGI_CONCEPTOSEMESTRE CS join ugi_semestre us on cs.id_ugisemestre = us.id_ugisemestre join semestre se on us.id_semestre = se.id_semestre join ugi_literalsemestre sl on cs.id_ugiliteralsemestre = sl.id_ugiliteralsemestre join literal_ugi lu on sl.id_literal = lu.id_literal WHERE se.nmsemestre= @semestre AND lu.nmliteral = @literal ) AS total_presupuesto, (SUM(GA.VALORTOTAL) / (SELECT SUM(CS.VALORPROYECTADO) FROM UGI_CONCEPTOSEMESTRE CS join ugi_semestre us on cs.id_ugisemestre = us.id_ugisemestre join semestre se on us.id_semestre = se.id_semestre join ugi_literalsemestre sl on cs.id_ugiliteralsemestre = sl.id_ugiliteralsemestre join literal_ugi lu on sl.id_literal = lu.id_literal WHERE se.nmsemestre= @semestre AND lu.nmliteral = @literal)) AS porcentaje_presupuesto FROM investigacion_gasto ga join investigacion_crearproyecto cp on ga.id_crearproyecto = cp.id_crearproyecto join literal_ugi lu on cp.id_literal = lu.id_literal where lu.nmliteral= @literal and DATE_PART('year',ga.fechalegalizacionorden) = @anio AND DATE_PART('month',ga.fechalegalizacionorden) BETWEEN @rango1 AND @rango2";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@anio", anio));
            parameterList.Add(new NpgsqlParameter("@literal", literal));
            parameterList.Add(new NpgsqlParameter("@semestre", semestre));
            parameterList.Add(new NpgsqlParameter("@rango1", rango1));
            parameterList.Add(new NpgsqlParameter("@rango2", rango2));

            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<PresuspuestoTotalComprometidoBySemestreAndLiteralDTO>(qry, Param).ToList();

            return datos;
        }
        public IEnumerable PresuspuestoTotalComprometidoEjecutadoBySemestre(int anio, int rango1, int rango2)
        {
            string qry = "SELECT LU.NMLITERAL AS literal,SUM(GA.VALORTOTAL) AS comprometido,(SELECT SUM(AP.VALORNETO) AS monto_ejecutado FROM INVESTIGACION_APLICARPAGO AP),(SELECT SUM(GA.VALORTOTAL) -(SELECT SUM(AP.VALORNETO) AS monto_ejecutado FROM INVESTIGACION_APLICARPAGO AP)) AS monto_ejecutar FROM INVESTIGACION_GASTO GA JOIN INVESTIGACION_CREARPROYECTO CP ON GA.ID_CREARPROYECTO = CP.ID_CREARPROYECTO JOIN LITERAL_UGI LU ON CP.ID_LITERAL = LU.ID_LITERAL where DATE_PART('year', ga.fechalegalizacionorden) = @anio AND DATE_PART('month', ga.fechalegalizacionorden) BETWEEN @rango1 AND @rango2 GROUP BY LU.NMLITERAL";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@anio", anio));
            parameterList.Add(new NpgsqlParameter("@rango1", rango1));
            parameterList.Add(new NpgsqlParameter("@rango2", rango2));

            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<PresuspuestoTotalComprometidoEjecutadoByLiteralDTO>(qry, Param).ToList();

            return datos;
        }
        public IEnumerable PresuspuestoTotalComprometidoEjecutadoByLiteralAndSemestre(string literal, int anio, int rango1, int rango2)
        {
            string qry = "SELECT LU.NMLITERAL AS literal,SUM(GA.VALORTOTAL) AS comprometido,(SELECT SUM(AP.VALORNETO) AS monto_ejecutado FROM INVESTIGACION_APLICARPAGO AP),(SELECT SUM(GA.VALORTOTAL) -(SELECT SUM(AP.VALORNETO) AS monto_ejecutado FROM INVESTIGACION_APLICARPAGO AP)) AS monto_ejecutar FROM INVESTIGACION_GASTO GA JOIN INVESTIGACION_CREARPROYECTO CP ON GA.ID_CREARPROYECTO = CP.ID_CREARPROYECTO JOIN LITERAL_UGI LU ON CP.ID_LITERAL = LU.ID_LITERAL where lu.nmliteral = @literal and DATE_PART('year',ga.fechalegalizacionorden) = @anio AND DATE_PART('month',ga.fechalegalizacionorden) BETWEEN @rango1 AND @rango2 GROUP BY LU.NMLITERAL";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@anio", anio));
            parameterList.Add(new NpgsqlParameter("@literal", literal));
            parameterList.Add(new NpgsqlParameter("@rango1", rango1));
            parameterList.Add(new NpgsqlParameter("@rango2", rango2));


            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<PresuspuestoTotalComprometidoEjecutadoByLiteralDTO>(qry, Param).ToList();

            return datos;
        }

    }
}