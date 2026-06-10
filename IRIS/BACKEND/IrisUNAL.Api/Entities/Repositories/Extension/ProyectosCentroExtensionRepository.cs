using DocumentFormat.OpenXml.Spreadsheet;
using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.Decanatura;
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

namespace IrisUNAL.Api.Entities.Repositories.Extension
{
    public class ProyectosCentroExtensionRepository
    {
        private ApplicationDbContext _context;

        public ProyectosCentroExtensionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public ProyectosCentroExtensionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable DropdownSemestre()
        {
            var registros = _context.Database.SqlQuery<DropSemestre>("SELECT SM.NMSEMESTRE AS SEMESTRE FROM semestre JOIN SEMESTRE SM ON SM.ID_SEMESTRE = sm.ID_SEMESTRE GROUP BY SM.NMSEMESTRE ORDER BY SM.NMSEMESTRE ASC");

            return registros;
        }
        public IEnumerable TotalPropuestas(int annio, int rango1, int rango2)
        {
            string qry = ("SELECT EP.NMESTADOPROPUESTA ESTADOPROPUESTA, COUNT(PR.ID_PROPUESTA) TOTALESTADOPROPUESTA FROM PROPUESTA PR JOIN PROPUESTA_ESTADOPROPUESTA EP ON PR.ID_ESTADOPROPUESTA = EP.ID_ESTADOPROPUESTA WHERE date_part('year', pr.fecrad) = @annio AND date_part('month', pr.fecrad) BETWEEN @rango1 AND @rango2 GROUP BY EP.NMESTADOPROPUESTA");
            //var registros = _context.Database.SqlQuery<TotalPropuestas>("select ep.nmestadopropuesta estadopropuesta, count(pr.id_propuesta) totalestadopropuesta from propuesta pr join propuesta_estadopropuesta ep on pr.id_estadopropuesta = ep.id_estadopropuesta group by ep.nmestadopropuesta ");

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@annio", annio));
            parameterList.Add(new NpgsqlParameter("@rango1", rango1));
            parameterList.Add(new NpgsqlParameter("@rango2", rango2));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var registros = _context.Database.SqlQuery<TotalPropuestas>(qry, Param).ToList();

            return registros;

        }
        public IEnumerable TotalPropuestasModalidad(int annio, int rango1, int rango2)
        {
            string qry = ("SELECT MD.NMMODALIDAD MODALIDADPROPUESTA, COUNT(PR.ID_PROPUESTA) TOTALMODALIDADPROPUESTA FROM PROPUESTA PR JOIN PROPUESTA_MODALIDAD MD ON PR.ID_MODALIDAD = MD.ID_MODALIDAD WHERE date_part('year', pr.fecrad) = @annio AND date_part('month', pr.fecrad) BETWEEN @rango1 AND @rango2 GROUP BY MD.NMMODALIDAD;");
            //var registros = _context.Database.SqlQuery<TotalpropuestasModalidad>("select md.nmmodalidad modalidadpropuesta, count(pr.id_propuesta) totalmodalidadpropuesta from propuesta pr join propuesta_modalidad md on pr.id_modalidad = md.id_modalidad group by md.nmmodalidad ");

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@annio", annio));
            parameterList.Add(new NpgsqlParameter("@rango1", rango1));
            parameterList.Add(new NpgsqlParameter("@rango2", rango2));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var registros = _context.Database.SqlQuery<TotalpropuestasModalidad>(qry, Param).ToList();

            return registros;
        }
        public IEnumerable PropuestasTipoUsuario(int annio, int rango1, int rango2)
        {
            string qry = ("SELECT tu.nmpropuestatipousuario, COUNT(pr.id_propuesta) as totalportipousuario FROM PROPUESTA PR JOIN propuesta_tipousuario tu ON pr.id_propuestatipousuario = tu.id_propuestatipousuario WHERE date_part('year', pr.fecrad) = @annio AND date_part('month', pr.fecrad) BETWEEN @rango1 AND @rango2 GROUP BY tu.nmpropuestatipousuario;");
            //var registros = _context.Database.SqlQuery<TotalPropuestasTipoUsuario>("select tu.nmpropuestatipousuario, count(pr.id_propuesta) as totalportipousuario from propuesta pr join propuesta_tipousuario tu on pr.id_propuestatipousuario = tu.id_propuestatipousuario group by tu.nmpropuestatipousuario");

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@annio", annio));
            parameterList.Add(new NpgsqlParameter("@rango1", rango1));
            parameterList.Add(new NpgsqlParameter("@rango2", rango2));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var registros = _context.Database.SqlQuery<TotalPropuestasTipoUsuario>(qry, Param).ToList();

            return registros;
        }
        public IEnumerable PropuestasOrigen(int annio, int rango1, int rango2)
        {
            string qry = ("select op.nmorigenpropuesta origenpropuesta, count(pr.id_propuesta) totalorigenpropuesta from propuesta pr join propuesta_origenpropuesta op on pr.id_origenpropuesta = op.id_origenpropuesta WHERE date_part('year', pr.fecrad) = @annio AND date_part('month', pr.fecrad) BETWEEN @rango1 AND @rango2 group by op.nmorigenpropuesta");
            //var registros = _context.Database.SqlQuery<TotalPropuestasOrigen>("select op.nmorigenpropuesta origenpropuesta, count(pr.id_propuesta) totalorigenpropuesta from propuesta pr join propuesta_origenpropuesta op on pr.id_origenpropuesta = op.id_origenpropuesta group by op.nmorigenpropuesta ");

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@annio", annio));
            parameterList.Add(new NpgsqlParameter("@rango1", rango1));
            parameterList.Add(new NpgsqlParameter("@rango2", rango2));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var registros = _context.Database.SqlQuery<TotalPropuestasOrigen>(qry, Param).ToList();

            return registros;
        }
        public IEnumerable NombreProyectosEjecucion(int annio, int rango1, int rango2)
        {
            string qry = ("SELECT PM.NMMODALIDAD, COUNT(ID_ASIGNACIONPROYECTO) AS CANTMODALIDAD FROM PROYECTOS_ASIGNACIONPROYECTO AP JOIN PROPUESTA PR ON AP.ID_PROPUESTA = PR.ID_PROPUESTA JOIN PROPUESTA_MODALIDAD PM ON PR.ID_MODALIDAD = PM.ID_MODALIDAD WHERE date_part('year', ap.fecacuerdovoluntades) = @annio AND date_part('month', ap.fecacuerdovoluntades) BETWEEN @rango1 AND @rango2 GROUP BY PM.NMMODALIDAD");
            //var registros = _context.Database.SqlQuery<ModalidadProyectosEjecucion>("select pm.nmmodalidad, count(id_asignacionproyecto) as cantmodalidad from proyectos_asignacionproyecto ap join propuesta pr on ap.id_propuesta = pr.id_propuesta join propuesta_modalidad pm on pr.id_modalidad = pm.id_modalidad group by pm.nmmodalidad ");

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@annio", annio));
            parameterList.Add(new NpgsqlParameter("@rango1", rango1));
            parameterList.Add(new NpgsqlParameter("@rango2", rango2));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var registros = _context.Database.SqlQuery<ModalidadProyectosEjecucion>(qry, Param).ToList();

            return registros;
        }
        public IEnumerable TotalProyectosEjecucion(int annio, int rango1, int rango2)
        {
            string qry = ("select count(id_asignacionproyecto) totalproyectos from proyectos_asignacionproyecto WHERE id_estadocontrato = 6 AND date_part('year', fecacuerdovoluntades) = @annio AND date_part('month', fecacuerdovoluntades) BETWEEN @rango1 AND @rango2");
            //var registros = _context.Database.SqlQuery<TotProyectosEjecucion>("select count(id_asignacionproyecto) totalproyectos from proyectos_asignacionproyecto");

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@annio", annio));
            parameterList.Add(new NpgsqlParameter("@rango1", rango1));
            parameterList.Add(new NpgsqlParameter("@rango2", rango2));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var registros = _context.Database.SqlQuery<TotProyectosEjecucion>(qry, Param).ToList();

            return registros;
        }
        public IEnumerable TotalEntidadesPropuestas(int annio, int rango1, int rango2)
        {
            string qry = ("select pe.razonsocial, count(pr.id_propuesta) from propuesta pr join propuesta_entidad pe on pr.idpropuesta_entidad = pe.idpropuesta_entidad WHERE date_part('year', pr.fecrad) = @annio AND date_part('month', pr.fecrad) BETWEEN @rango1 AND @rango2 group by pe.razonsocial");
            //var registros = _context.Database.SqlQuery<TotEntidadesPropuestas>("select pe.razonsocial, count(pr.id_propuesta) from propuesta pr join propuesta_entidad pe on pr.idpropuesta_entidad = pe.idpropuesta_entidad group by pe.razonsocial ");

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@annio", annio));
            parameterList.Add(new NpgsqlParameter("@rango1", rango1));
            parameterList.Add(new NpgsqlParameter("@rango2", rango2));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var registros = _context.Database.SqlQuery<TotEntidadesPropuestas>(qry, Param).ToList();

            return registros;
        }
        public IEnumerable TotalEstadoProyectos(int annio, int rango1, int rango2)
        {
            string qry = ("SELECT LF.TRANSFERENCIASCOPE, COUNT(LF.ID_ASIGNACIONPROYECTO) AS Total FROM LIQUIDACION_FINALIZACION LF LEFT JOIN PROYECTOS_ASIGNACIONPROYECTO PA ON LF.ID_ASIGNACIONPROYECTO = PA.ID_ASIGNACIONPROYECTO WHERE DATE_PART('year', PA.FECACUERDOVOLUNTADES) = @annio AND DATE_PART('month', PA.FECACUERDOVOLUNTADES) BETWEEN @rango1 AND @rango2 GROUP BY LF.TRANSFERENCIASCOPE ORDER BY LF.TRANSFERENCIASCOPE");
            //var registros = _context.Database.SqlQuery<TotEstadoProyectos>("select count(id_asignacionproyecto), lf.transferenciascope from liquidacion_finalizacion lf group by lf.transferenciascope");

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@annio", annio));
            parameterList.Add(new NpgsqlParameter("@rango1", rango1));
            parameterList.Add(new NpgsqlParameter("@rango2", rango2));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var registros = _context.Database.SqlQuery<TotEstadoProyectos>(qry, Param).ToList();

            return registros;
        }




        public string ExcelLiquidacionActas(int id_asignacionproyecto)
        {
            var archivoreturn = "/Export/ExcelLiquidacionActas_" + id_asignacionproyecto.ToString() + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/ExcelLiquidacionActas_" + id_asignacionproyecto.ToString() + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/EXCELLIQUIDACION_ACTAS_.xlsx");
            SLDocument xlsdocument = new SLDocument(plantilla);

            string qry = " select ap.nombreproyecto, ap.objetocontratoactividad, ap.fecactainicio, ap.fecterminacion, ec.estadocontrato, actaliqentidad as acta, (select fechaestado + interval '3 month' from liquidacion_finalizacion) as vencimiento from proyectos_asignacionproyecto ap join liquidacion_finalizacion lf on ap.id_asignacionproyecto = lf.id_asignacionproyecto join proyectos_estadocontrato ec on lf.id_estadocontrato = ec.id_estadocontrato where ap.id_asignacionproyecto = @id_asignacionproyecto group by ap.nombreproyecto, ap.objetocontratoactividad, ap.fecactainicio, ap.fecterminacion, ec.estadocontrato, actaliqentidad";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@id_asignacionproyecto", id_asignacionproyecto));
            NpgsqlParameter[] Param = parameterList.ToArray();
            var datos = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry, Param).ToList();

            int filaxls = 4;
            int filaxls2 = 13;
            int filaxls3 = 60;
            string celdaxls = "";

            SLStyle style = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            //            style.SetWrapText(true);
            //style.Alignment.JustifyLastLine = true;
            //style.Alignment.ShrinkToFit = true;

            styleBack.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(146, 208, 80), System.Drawing.Color.Blue);
            //al no haber datos, no muestra nada en la hoja
            foreach (var registro in datos)
            {
                xlsdocument.MergeWorksheetCells(2, 2, 2, 8);
                xlsdocument.SetCellValue(2, 2, "Liquidacion Actas");
                xlsdocument.SetCellStyle(2, 2, style);
                xlsdocument.SetCellStyle(2, 2, styleBack);
                //celdaxls = "B" + filaxls2.ToString();
                xlsdocument.SetCellValue(3, 2, "Nombre Proyecto");
                xlsdocument.SetCellStyle(3, 2, style);
                xlsdocument.SetCellValue(3, 3, registro.nombreproyecto);
                xlsdocument.SetCellStyle(3, 3, style);
                //xlsdocument.MergeWorksheetCells(8, 2, 8, 8);
                celdaxls = "C" + filaxls2.ToString();
                xlsdocument.SetCellValue(4, 2, "Objeto contrato actividad");
                xlsdocument.SetCellStyle(4, 2, style);
                xlsdocument.SetCellValue(4, 3, registro.objetocontratoactividad);
                xlsdocument.SetCellStyle(4, 3, style);
                xlsdocument.SetCellValue(5, 2, "Fecha Inicio");
                xlsdocument.SetCellStyle(5, 2, style);
                if (registro.fecactainicio != null)
                    xlsdocument.SetCellValue(5, 3, ((DateTime)registro.fecactainicio).ToString());
                xlsdocument.SetCellStyle(5, 3, style);
                xlsdocument.SetCellValue(6, 2, "Fecha Terminacion");
                xlsdocument.SetCellStyle(6, 2, style);
                xlsdocument.SetCellValue(6, 3, registro.fecterminacion.ToString());
                xlsdocument.SetCellStyle(6, 3, style);
                xlsdocument.SetCellValue(7, 2, "Estado contrato");
                xlsdocument.SetCellStyle(7, 2, style);
                xlsdocument.SetCellValue(7, 3, registro.estadocontrato);
                xlsdocument.SetCellStyle(7, 3, style);
                xlsdocument.SetCellValue(8, 2, "Acta");
                xlsdocument.SetCellStyle(8, 2, style);
                xlsdocument.SetCellValue(8, 3, registro.acta);
                xlsdocument.SetCellStyle(8, 3, style);
                xlsdocument.SetCellValue(9, 2, "Vencimiento");
                xlsdocument.SetCellStyle(9, 2, style);
                xlsdocument.SetCellValue(9, 3, registro.vencimiento);
                xlsdocument.SetCellStyle(9, 3, style);

            }
            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }


        public string ExcelProyectosEstadoFinalizado()
        {
            var archivoreturn = "/Export/ExcelProyectosEstadoFinalizado_" + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/ExcelProyectosEstadoFinalizado_" + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/EXCELESTADO_FINALIZADO_.xlsx");
            SLDocument xlsdocument = new SLDocument(plantilla);

            string qry = " select lf.id_asignacionproyecto, nombreproyecto from liquidacion_finalizacion lf join proyectos_asignacionproyecto ap on lf.id_asignacionproyecto = ap.id_asignacionproyecto where ingresos = null group by lf.id_asignacionproyecto, nombreproyecto";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            NpgsqlParameter[] Param = parameterList.ToArray();
            var datos = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry, Param).ToList();

            int filaxls = 4;
            int filaxls2 = 13;
            int filaxls3 = 60;
            string celdaxls = "";

            SLStyle style = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            //            style.SetWrapText(true);
            //style.Alignment.JustifyLastLine = true;
            //style.Alignment.ShrinkToFit = true;

            styleBack.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(146, 208, 80), System.Drawing.Color.Blue);
            //al no haber datos, no muestra nada en la hoja
            foreach (var registro in datos)
            {
                xlsdocument.MergeWorksheetCells(2, 2, 2, 8);
                xlsdocument.SetCellValue(2, 2, "Proyectos Estado Finalizado");
                xlsdocument.SetCellStyle(2, 2, style);
                xlsdocument.SetCellStyle(2, 2, styleBack);
                //celdaxls = "B" + filaxls2.ToString();
                xlsdocument.SetCellValue(3, 2, "Proyectos");
                xlsdocument.SetCellStyle(3, 2, style);
                xlsdocument.SetCellValue(3, 3, registro.proyectos);
                xlsdocument.SetCellStyle(3, 3, style);
                //xlsdocument.MergeWorksheetCells(8, 2, 8, 8);
                celdaxls = "C" + filaxls2.ToString();
                xlsdocument.SetCellValue(4, 2, "Transferencia");
                xlsdocument.SetCellStyle(4, 2, style);
                xlsdocument.SetCellValue(4, 3, registro.transferencia);
                xlsdocument.SetCellStyle(4, 3, style);
            }
            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }

        public string ExcelProyectosPendientesIngresos()
        {
            var archivoreturn = "/Export/EXCELPENDIENTESINGRESO_" + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/EXCELPENDIENTESINGRESO_" + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/EXCELPENDIENTES_INGRESO_.xlsx");
            SLDocument xlsdocument = new SLDocument(plantilla);

            string qry = " select lf.id_asignacionproyecto, nombreproyecto from liquidacion_finalizacion lf join proyectos_asignacionproyecto ap on lf.id_asignacionproyecto = ap.id_asignacionproyecto where ingresos = null group by lf.id_asignacionproyecto, nombreproyecto";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            NpgsqlParameter[] Param = parameterList.ToArray();
            var datos = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry, Param).ToList();

            int filaxls = 4;
            int filaxls2 = 13;
            int filaxls3 = 60;
            string celdaxls = "";

            SLStyle style = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            //            style.SetWrapText(true);
            //style.Alignment.JustifyLastLine = true;
            //style.Alignment.ShrinkToFit = true;

            styleBack.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(146, 208, 80), System.Drawing.Color.Blue);
            //al no haber datos, no muestra nada en la hoja
            foreach (var registro in datos)
            {
                xlsdocument.MergeWorksheetCells(2, 2, 2, 8);
                xlsdocument.SetCellValue(2, 2, "Proyectos Pendientes Ingresos");
                xlsdocument.SetCellStyle(2, 2, style);
                xlsdocument.SetCellStyle(2, 2, styleBack);
                //celdaxls = "B" + filaxls2.ToString();
                xlsdocument.SetCellValue(3, 2, "ID Asignacion Proyecto");
                xlsdocument.SetCellStyle(3, 2, style);
                xlsdocument.SetCellValue(3, 3, registro.id_asignacionproyecto);
                xlsdocument.SetCellStyle(3, 3, style);
                //xlsdocument.MergeWorksheetCells(8, 2, 8, 8);
                celdaxls = "C" + filaxls2.ToString();
                xlsdocument.SetCellValue(4, 2, "Nombre Proyecto");
                xlsdocument.SetCellStyle(4, 2, style);
                xlsdocument.SetCellValue(4, 3, registro.nombreproyecto);
                xlsdocument.SetCellStyle(4, 3, style);
            }
            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }
        public string ExcelModificacionProyecto(int id_asignacionproyecto)
        {
            var archivoreturn = "/Export/ExcelModificacionProyecto_" + id_asignacionproyecto.ToString() + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/ExcelModificacionProyecto_" + id_asignacionproyecto.ToString() + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/EXCEL_MODIFICACIONESPROYECTO_.xlsx");
            SLDocument xlsdocument = new SLDocument(plantilla);

            string qry = "select id_asignacionproyecto, nombreproyecto, razonsocial, numeromodificaciones from proyectos_asignacionproyecto ap join propuesta_entidad pe on ap.idpropuesta_entidad = pe.idpropuesta_entidad where id_asignacionproyecto = @id_asignacionproyecto group by id_asignacionproyecto, nombreproyecto, razonsocial, numeromodificaciones";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@id_asignacionproyecto", id_asignacionproyecto));
            NpgsqlParameter[] Param = parameterList.ToArray();
            var datos = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry, Param).ToList();

            int filaxls = 4;
            int filaxls2 = 13;
            int filaxls3 = 60;
            string celdaxls = "";

            SLStyle style = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            //            style.SetWrapText(true);
            //style.Alignment.JustifyLastLine = true;
            //style.Alignment.ShrinkToFit = true;

            styleBack.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(146, 208, 80), System.Drawing.Color.Blue);


            foreach (var registro in datos)
            {
                xlsdocument.MergeWorksheetCells(2, 2, 2, 8);
                xlsdocument.SetCellValue(2, 2, "MODIFICACIONES POR PROYECTO");
                xlsdocument.SetCellStyle(2, 2, style);
                xlsdocument.SetCellStyle(2, 2, styleBack);
                //celdaxls = "B" + filaxls2.ToString();
                xlsdocument.SetCellValue(3, 2, "ID Asignacion Proyecto");
                xlsdocument.SetCellStyle(3, 2, style);
                xlsdocument.SetCellValue(3, 3, registro.id_asignacionproyecto);
                xlsdocument.SetCellStyle(3, 3, style);
                //xlsdocument.MergeWorksheetCells(8, 2, 8, 8);
                celdaxls = "C" + filaxls2.ToString();
                xlsdocument.SetCellValue(4, 2, "Nombre Proyecto");
                xlsdocument.SetCellStyle(4, 2, style);
                xlsdocument.SetCellValue(4, 3, registro.nombreproyecto);
                xlsdocument.SetCellStyle(4, 3, style);
                xlsdocument.SetCellValue(5, 2, "Razon Social");
                xlsdocument.SetCellStyle(5, 2, style);
                xlsdocument.SetCellValue(5, 3, registro.razonsocial);
                xlsdocument.SetCellStyle(5, 3, style);
                xlsdocument.SetCellValue(6, 2, "Numero Modificaciones");
                xlsdocument.SetCellStyle(6, 2, style);
                xlsdocument.SetCellValue(6, 3, registro.numeromodificaciones);
                xlsdocument.SetCellStyle(6, 3, style);
            }
            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }






        public string ExcelSeguimientoSuscripcionActasLiquidacion( )
        {
            var archivoreturn = "/Export/ExcelSeguimientoSuscripcionActasLiquidacion" +  ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/ExcelSeguimientoSuscripcionActasLiquidacion" +  ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/ExcelSeguimientoSuscripcionActas_Liquidacion.xlsx");
            SLDocument xlsdocument = new SLDocument(plantilla);

            string qry = "select ap.nombreproyecto, ap.objetocontratoactividad, ap.fecactainicio, ap.fecterminacion, ec.estadocontrato, actaliqentidad as acta, fechaestado + interval '4 month' as fechavencimiento from proyectos_asignacionproyecto ap join liquidacion_finalizacion lf on ap.id_asignacionproyecto = lf.id_asignacionproyecto join proyectos_estadocontrato ec on lf.id_estadocontrato = ec.id_estadocontrato group by ap.nombreproyecto, ap.objetocontratoactividad, ap.fecactainicio, ap.fecterminacion, ec.estadocontrato, actaliqentidad, fechaestado";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            NpgsqlParameter[] Param = parameterList.ToArray();
            var datos = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry, Param).ToList();

            int filaxls = 4;
            int filaxls2 = 13;
            int filaxls3 = 60;
            string celdaxls = "";

            SLStyle style = xlsdocument.CreateStyle();
            SLStyle borders = xlsdocument.CreateStyle();
            borders.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.LeftBorder.Color = System.Drawing.Color.Black;
            borders.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.RightBorder.Color = System.Drawing.Color.Black;
            borders.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.TopBorder.Color = System.Drawing.Color.Black;
            borders.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.BottomBorder.Color = System.Drawing.Color.Black;

            SLStyle headers = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            SLStyle styleYellow = xlsdocument.CreateStyle();
            SLStyle textCenter = xlsdocument.CreateStyle();

            textCenter.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            textCenter.Alignment.Vertical = VerticalAlignmentValues.Center;
            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            style.Font.Bold = true;
            styleBack.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            styleBack.Alignment.Vertical = VerticalAlignmentValues.Center;
            styleBack.Font.Bold = true;
            //            style.SetWrapText(true);
            //style.Alignment.JustifyLastLine = true;
            //style.Alignment.ShrinkToFit = true;
            styleYellow.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(255, 255, 0), System.Drawing.Color.Blue);
            styleBack.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(207, 226, 243), System.Drawing.Color.Blue);
            headers.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(182, 215, 168), System.Drawing.Color.Blue);
            style.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(182, 215, 168), System.Drawing.Color.Blue);


            var row = 3;
            var count = 1;
            foreach (var registro3 in datos)
            {

                xlsdocument.SetRowHeight(1, 35.0);
                xlsdocument.SetRowHeight(row, 100.0);
                xlsdocument.SetRowHeight(2, 50.0);

                //xlsdocument.SetWorksheetDefaultRowHeight(100.0);
                xlsdocument.MergeWorksheetCells(1, 1, 1, 3);
                xlsdocument.MergeWorksheetCells(1, 4, 1, 8);
                xlsdocument.SetCellStyle(1, 4, styleBack);
                xlsdocument.SetCellValue(1, 1, "SEGUIMIENTO DE SUSCRIPCION DE ACTAS DE LIQUIDACION");
                xlsdocument.SetCellStyle(1, 1, styleBack);
                xlsdocument.SetCellStyle(1, 15, borders);
                xlsdocument.SetCellValue(2, 1, "NO.");
                xlsdocument.SetCellStyle(2, 1, style);
                xlsdocument.SetCellStyle(2, 1, borders);
                xlsdocument.SetColumnWidth("A", 13.0);
                xlsdocument.SetCellValue(2, 2, "Nombre del Proyecto");
                //xlsdocument.MergeWorksheetCells(3, 3, 4, 3);
                xlsdocument.SetCellStyle(2, 2, style);
                xlsdocument.SetCellStyle(2, 2, styleYellow);
                xlsdocument.SetCellStyle(2, 2, borders);
                xlsdocument.SetCellValue(2, 3, "Objeto ");
                //xlsdocument.MergeWorksheetCells(3, 4, 4, 4);
                xlsdocument.SetCellStyle(2, 3, style);
                xlsdocument.SetCellStyle(2, 3, borders);
                xlsdocument.SetCellValue(2, 4, "Fecha Inicio");
                //xlsdocument.MergeWorksheetCells(3, 5, 4, 5);
                xlsdocument.SetCellStyle(2, 4, style);
                xlsdocument.SetCellStyle(2, 4, borders);
                xlsdocument.SetCellValue(2, 5, "Fecha Terminacion");
                //xlsdocument.MergeWorksheetCells(3, 6, 4, 6);
                xlsdocument.SetCellStyle(2, 5, style);
                xlsdocument.SetCellStyle(2, 5, borders);
                xlsdocument.SetCellValue(2, 6, "Estado Contrato");
                //xlsdocument.MergeWorksheetCells(3, 7, 4, 7);
                xlsdocument.SetCellStyle(2, 6, style);
                xlsdocument.SetCellStyle(2, 6, borders);
                xlsdocument.SetCellValue(2, 7, "Acta");
                //xlsdocument.MergeWorksheetCells(3, 7, 4, 7);
                xlsdocument.SetCellStyle(2, 7, style);
                xlsdocument.SetCellStyle(2, 7, borders);
                xlsdocument.SetCellValue(2, 8, "Vencimiento");
                //xlsdocument.MergeWorksheetCells(3, 7, 4, 7);
                xlsdocument.SetCellStyle(2, 8, style);
                xlsdocument.SetCellStyle(2, 8, borders);





                //if (registro8.id_propuesta != null)
                //    xlsdocument.SetCellValue(row, column, (int)registro8.id_propuesta);
                //xlsdocument.SetCellStyle(3, 3, style);
                ////xlsdocument.MergeWorksheetCells(26, 2, 26, 8);
                ///
                xlsdocument.SetCellValue(row, 1, count);
                xlsdocument.SetCellStyle(row, 1, borders);
                xlsdocument.SetCellStyle(row, 1, textCenter);

                if (registro3.nombreproyecto != null)
                {
                    xlsdocument.SetCellValue(row, 2, registro3.nombreproyecto);
                    xlsdocument.SetCellStyle(row, 2, borders);

                }
                //xlsdocument.SetCellStyle(4, 3, style);
                ////xlsdocument.MergeWorksheetCells(27, 2, 27, 8);
                if (registro3.objetocontratoactividad != null)
                {
                    xlsdocument.SetCellValue(row, 3, registro3.objetocontratoactividad);
                    xlsdocument.SetCellStyle(row, 3, borders);

                }

                //xlsdocument.SetCellStyle(5, 3, style);

                if (registro3.fecactainicio != null)
                    xlsdocument.SetCellValue(row, 4, ((DateTime)registro3.fecactainicio).ToString());
                xlsdocument.SetCellStyle(row, 4, borders);

                //xlsdocument.SetCellStyle(6, 3, style);
                ////xlsdocument.MergeWorksheetCells(29, 2, 29, 8);

                if (registro3.fecterminacion != null)
                    xlsdocument.SetCellValue(row, 5, ((DateTime)registro3.fecterminacion).ToString());
                xlsdocument.SetCellStyle(row, 5, borders);

                //xlsdocument.SetCellStyle(7, 3, style);
                ////xlsdocument.MergeWorksheetCells(30, 2, 30, 8);

                if (registro3.estadocontrato != null)

                    xlsdocument.SetCellValue(row, 6, registro3.estadocontrato);
                xlsdocument.SetCellStyle(row, 6, borders);

                if (registro3.acta != null)

                    xlsdocument.SetCellValue(row, 7, registro3.acta);
                xlsdocument.SetCellStyle(row, 7, borders);

                if (registro3.vencimiento != null)

                    xlsdocument.SetCellValue(row, 8, ((DateTime)registro3.fechavencimiento).ToString());
                xlsdocument.SetCellStyle(row, 8, borders);

                xlsdocument.AutoFitColumn(1, 16);
                xlsdocument.SetColumnWidth("B", 45.0);


                count++;
                row++;
            }
            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }

        public string ExcelProyectosPendientesIngreso( )
        {
            var archivoreturn = "/Export/ExcelProyectosPendientesIngreso" +  ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/ExcelProyectosPendientesIngreso" +  ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/ExcelProyectosPendientes_Ingreso.xlsx");
            SLDocument xlsdocument = new SLDocument(plantilla);

            string qry = " select lf.id_asignacionproyecto, nombreproyecto from liquidacion_finalizacion lf join proyectos_asignacionproyecto ap on lf.id_asignacionproyecto = ap.id_asignacionproyecto where ingresos = null group by lf.id_asignacionproyecto, nombreproyecto ";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            NpgsqlParameter[] Param = parameterList.ToArray();
            var datos = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry, Param).ToList();

            int filaxls = 4;
            int filaxls2 = 13;
            int filaxls3 = 60;
            string celdaxls = "";

            SLStyle style = xlsdocument.CreateStyle();
            SLStyle borders = xlsdocument.CreateStyle();
            borders.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.LeftBorder.Color = System.Drawing.Color.Black;
            borders.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.RightBorder.Color = System.Drawing.Color.Black;
            borders.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.TopBorder.Color = System.Drawing.Color.Black;
            borders.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.BottomBorder.Color = System.Drawing.Color.Black;

            SLStyle headers = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            SLStyle styleYellow = xlsdocument.CreateStyle();
            SLStyle textCenter = xlsdocument.CreateStyle();

            textCenter.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            textCenter.Alignment.Vertical = VerticalAlignmentValues.Center;
            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            style.Font.Bold = true;
            styleBack.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            styleBack.Alignment.Vertical = VerticalAlignmentValues.Center;
            styleBack.Font.Bold = true;
            //            style.SetWrapText(true);
            //style.Alignment.JustifyLastLine = true;
            //style.Alignment.ShrinkToFit = true;
            styleYellow.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(255, 255, 0), System.Drawing.Color.Blue);
            styleBack.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(207, 226, 243), System.Drawing.Color.Blue);
            headers.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(182, 215, 168), System.Drawing.Color.Blue);
            style.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(182, 215, 168), System.Drawing.Color.Blue);


            var row = 3;
            var count = 1;
            xlsdocument.SetRowHeight(1, 35.0);
            xlsdocument.SetRowHeight(2, 50.0);

            //xlsdocument.SetWorksheetDefaultRowHeight(100.0);
            xlsdocument.MergeWorksheetCells(1, 1, 1, 2);
            xlsdocument.SetCellStyle(1, 4, styleBack);
            xlsdocument.SetCellValue(1, 1, "PROYECTOS PENDIENTES POR INGRESO");
            xlsdocument.SetCellStyle(1, 1, styleBack);
            xlsdocument.SetCellStyle(1, 15, borders);
            xlsdocument.SetCellValue(2, 1, "NO.");
            xlsdocument.SetCellStyle(2, 1, style);
            xlsdocument.SetCellStyle(2, 1, borders);
            xlsdocument.SetColumnWidth("A", 13.0);
            xlsdocument.SetCellValue(2, 2, "Nombre del Proyecto");
            //xlsdocument.MergeWorksheetCells(3, 3, 4, 3);
            xlsdocument.SetCellStyle(2, 2, style);
            xlsdocument.SetCellStyle(2, 2, styleYellow);
            xlsdocument.SetCellStyle(2, 2, borders);
            xlsdocument.AutoFitColumn(1, 16);
            xlsdocument.SetColumnWidth("B", 45.0);

            foreach (var registro3 in datos)
            {

            xlsdocument.SetRowHeight(row, 100.0);

                //xlsdocument.SetCellValue(2, 3, "Entidad");
                ////xlsdocument.MergeWorksheetCells(3, 4, 4, 4);
                //xlsdocument.SetCellStyle(2, 3, style);
                //xlsdocument.SetCellStyle(2, 3, borders);
                //xlsdocument.SetCellValue(2, 4, "Valor Contrapartida");
                ////xlsdocument.MergeWorksheetCells(3, 5, 4, 5);
                //xlsdocument.SetCellStyle(2, 4, style);
                //xlsdocument.SetCellStyle(2, 4, borders);
                //xlsdocument.SetCellValue(2, 5, "Productos Contrapartida");
                ////xlsdocument.MergeWorksheetCells(3, 6, 4, 6);
                //xlsdocument.SetCellStyle(2, 5, style);
                //xlsdocument.SetCellStyle(2, 5, borders);
                //xlsdocument.SetCellValue(2, 6, "Fecha Finalización Proyecto");
                ////xlsdocument.MergeWorksheetCells(3, 7, 4, 7);
                //xlsdocument.SetCellStyle(2, 6, style);
                //xlsdocument.SetCellStyle(2, 6, borders);






                //if (registro8.id_propuesta != null)
                //    xlsdocument.SetCellValue(row, column, (int)registro8.id_propuesta);
                //xlsdocument.SetCellStyle(3, 3, style);
                ////xlsdocument.MergeWorksheetCells(26, 2, 26, 8);
                ///
                xlsdocument.SetCellValue(row, 1, count);
                xlsdocument.SetCellStyle(row, 1, borders);
                xlsdocument.SetCellStyle(row, 1, textCenter);

                if (registro3.nombreproyecto != null)
                {
                    xlsdocument.SetCellValue(row, 2, registro3.nombreproyecto);
                    xlsdocument.SetCellStyle(row, 2, borders);

                }
                //xlsdocument.SetCellStyle(4, 3, style);
                ////xlsdocument.MergeWorksheetCells(27, 2, 27, 8);
                //if (registro3.nombreproyecto != null)
                //{
                //    xlsdocument.SetCellValue(row, 3, registro3.entidad);
                //    xlsdocument.SetCellStyle(row, 3, borders);

                //}

                ////xlsdocument.SetCellStyle(5, 3, style);

                //if (registro3.contrapartida != null)
                //    xlsdocument.SetCellValue(row, 4, registro3.contrapartida);
                //xlsdocument.SetCellStyle(row, 4, borders);

                ////xlsdocument.SetCellStyle(6, 3, style);
                //////xlsdocument.MergeWorksheetCells(29, 2, 29, 8);

                //xlsdocument.SetCellValue(row, 5, registro3.productos);
                //xlsdocument.SetCellStyle(row, 5, borders);

                ////xlsdocument.SetCellStyle(7, 3, style);
                //////xlsdocument.MergeWorksheetCells(30, 2, 30, 8);

                //if (registro3.fecterminacion != null)

                //    xlsdocument.SetCellValue(row, 6, ((DateTime)registro3.fecterminacion).ToString());
                //xlsdocument.SetCellStyle(row, 6, borders);
                xlsdocument.AutoFitColumn(1, 16);


                count++;
                row++;
            }
            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }

        public string ExcelEstadoProyectos()
        {
            var archivoreturn = "/Export/ExcelEstadoProyectos" + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/ExcelEstadoProyectos" +  ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/ExcelEstado_Proyectos.xlsx");
            SLDocument xlsdocument = new SLDocument(plantilla);

            string qry2 = "select count(id_asignacionproyecto), lf.transferenciascope from liquidacion_finalizacion lf group by lf.transferenciascope";

            List<NpgsqlParameter> parameterList2 = new List<NpgsqlParameter>();
            NpgsqlParameter[] Param2 = parameterList2.ToArray();
            var datos = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry2, Param2).ToList();


            int filaxls = 4;
            int filaxls2 = 13;
            int filaxls3 = 60;
            string celdaxls = "";
            SLStyle style = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            SLStyle font = xlsdocument.CreateStyle();
            SLStyle titlefont = xlsdocument.CreateStyle();
            SLStyle propuestastit = xlsdocument.CreateStyle();
            SLStyle footer = xlsdocument.CreateStyle();
            SLStyle txtfooter = xlsdocument.CreateStyle();
            SLStyle prp = xlsdocument.CreateStyle();
            SLStyle propuestas = xlsdocument.CreateStyle();
            SLStyle propuestasSb = xlsdocument.CreateStyle();
            SLStyle line = xlsdocument.CreateStyle();

            propuestastit.Font.FontColor = System.Drawing.Color.Red;
            propuestas.Font.FontSize = 25.0;

            propuestastit.Font.FontSize = 72.0;
            propuestas.Font.FontColor = System.Drawing.Color.Red;
            propuestasSb.Font.FontSize = 26.0;

            propuestasSb.Font.FontColor = System.Drawing.Color.Red;
            txtfooter.Font.FontSize = 8.0;
            prp.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            txtfooter.Font.FontColor = System.Drawing.Color.White;
            txtfooter.Alignment.Vertical = VerticalAlignmentValues.Center;





            //propuestastit.Font.FontSize = 15.0;
            //propuestastit.Font.FontColor = System.Drawing.Color.Gray;
            //propuestastit.Alignment.Vertical = VerticalAlignmentValues.Center;

            titlefont.Font.FontFamily = 1;
            titlefont.Font.FontSize = 18.0;
            titlefont.Font.FontColor = System.Drawing.Color.FromArgb(45, 66, 148);
            font.Font.FontSize = 15.0;
            font.Font.FontFamily = 1;
            font.Font.FontColor = System.Drawing.Color.FromArgb(108, 120, 168);
            font.Alignment.Vertical = VerticalAlignmentValues.Center;
            line.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            line.Border.TopBorder.Color = System.Drawing.Color.Black; style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            //            style.SetWrapText(true);
            //style.Alignment.JustifyLastLine = true;
            //style.Alignment.ShrinkToFit = true;

            styleBack.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(230, 230, 230), System.Drawing.Color.Blue);
            footer.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(45, 66, 148), System.Drawing.Color.Blue);

            for (var i = 2; i <= 7; i++)
            {
                var b = "B" + i;
                var c = "C" + i;
                var d = "D" + i;
                var e = "E" + i;
                var f = "F" + i;
                var g = "G" + i;
                var h = "H" + i;
                xlsdocument.SetCellStyle(b, styleBack);
                xlsdocument.SetCellStyle(c, styleBack);
                xlsdocument.SetCellStyle(d, styleBack);
                xlsdocument.SetCellStyle(e, styleBack);
                xlsdocument.SetCellStyle(f, styleBack);
                xlsdocument.SetCellStyle(g, styleBack);
                xlsdocument.SetCellStyle(h, styleBack);
            }


            filaxls += 1;
            var sum = 0;
            var row = 7;
            var rowData = 7; 
            if (datos != null)
            {


                foreach (var registro in datos)
                {
                    xlsdocument.AutoFitColumn(1, 8);

                    var b = "B" + row;
                    var c = "C" + row;
                    var d = "D" + row;
                    var e = "E" + row;
                    var f = "F" + row;
                    var g = "G" + row;
                    var h = "H" + row;
                    xlsdocument.SetCellStyle(b, styleBack);
                    xlsdocument.SetCellStyle(c, styleBack);
                    xlsdocument.SetCellStyle(d, styleBack);
                    xlsdocument.SetCellStyle(e, styleBack);
                    xlsdocument.SetCellStyle(f, styleBack);
                    xlsdocument.SetCellStyle(g, styleBack);
                    xlsdocument.SetCellStyle(h, styleBack);

                    sum += registro.count;

                    //xlsdocument.SetRowHeight(2, 25.0);
                    //xlsdocument.SetRowHeight(3, 25.0);
                    xlsdocument.AutoFitRow(1, row);
                    xlsdocument.SetCellValue(2, 2, "          ESTADO PROYECTOS");
                    xlsdocument.SetCellStyle(2, 2, titlefont);

                    xlsdocument.SetCellValue(3, 2, "          SEGUIMIENTO DE PROYECTOS HERMES - RUP");
                    xlsdocument.SetCellStyle(3, 2, font);

                    xlsdocument.SetCellValue(5, 2, sum);
                    xlsdocument.SetCellStyle(5, 2, propuestastit);

                    xlsdocument.SetCellValue(5, 3, "Proyectos - transferencias");
                    xlsdocument.SetCellStyle(5, 3, propuestas);

                    xlsdocument.SetCellStyle(6, 3, line);
                    xlsdocument.SetCellStyle(6, 4, line);
                    xlsdocument.SetCellStyle(6, 2, line);

                    xlsdocument.SetCellValue(row, 2, registro.count);
                    xlsdocument.SetCellValue(row, 3, "Proyectos");
                    xlsdocument.SetCellStyle(row, 3, prp);

                    xlsdocument.SetCellValue(row, 4, registro.transferenciascope);


                    rowData++;
                    row++;
                }

                xlsdocument.MergeWorksheetCells(row, 2, row, 8);
                xlsdocument.MergeWorksheetCells(row + 1, 2, row + 1, 8);
                var foot = "B" + (row + 1);
                var margin = "B" + row;

                xlsdocument.SetCellStyle(margin, styleBack);
                xlsdocument.SetColumnWidth(8, 35.0);
                xlsdocument.SetRowHeight(row + 1, 45.0);
                xlsdocument.SetRowHeight(row, 15.0);

                xlsdocument.SetCellStyle(foot, footer);
                xlsdocument.SetCellValue(foot, "      Facultad de Derecho, Ciencias Politicas y Sociales Sede Bogotá" +
                "                                                                                                                        " +
                "Proyecto CULTURAl, CIENTIFICO, y COLECTIVO de Nación ");


                xlsdocument.SetCellStyle(foot, txtfooter);

            }





            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }
        public string ExcelSeguimientoCumplimientoContrapartidas()
        {
            var archivoreturn = "/Export/ExcelSeguimientoCumplimientoContrapartidas" + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/ExcelSeguimientoCumplimientoContrapartidas" + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/ExcelSeguimientoCumplimiento_Contrapartidas.xlsx");
            SLDocument xlsdocument = new SLDocument(plantilla);

            string qry3 = "select razonsocial as entidad, nombreproyecto, contrapartida, descripcion as productos, fecterminacion from proyectos_asignacionproyecto ap join propuesta_entidad pe on ap.idpropuesta_entidad = pe.idpropuesta_entidad join proyectos_nuevoproducto np on ap.id_asignacionproyecto = np.id_asignacionproyecto group by razonsocial, nombreproyecto, contrapartida, descripcion, fecterminacion";

            List<NpgsqlParameter> parameterList3 = new List<NpgsqlParameter>();
            NpgsqlParameter[] Param3 = parameterList3.ToArray();
            var datos3 = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry3, Param3).ToList();

            int filaxls = 4;
            int filaxls2 = 13;
            int filaxls3 = 60;
            string celdaxls = "";

            SLStyle style = xlsdocument.CreateStyle();
            SLStyle borders = xlsdocument.CreateStyle();
            borders.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.LeftBorder.Color = System.Drawing.Color.Black;
            borders.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.RightBorder.Color = System.Drawing.Color.Black;
            borders.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.TopBorder.Color = System.Drawing.Color.Black;
            borders.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.BottomBorder.Color = System.Drawing.Color.Black;

            SLStyle headers = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            SLStyle styleYellow = xlsdocument.CreateStyle();
            SLStyle textCenter = xlsdocument.CreateStyle();

            textCenter.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            textCenter.Alignment.Vertical = VerticalAlignmentValues.Center;
            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            style.Font.Bold = true;
            styleBack.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            styleBack.Alignment.Vertical = VerticalAlignmentValues.Center;
            styleBack.Font.Bold = true;
            //            style.SetWrapText(true);
            //style.Alignment.JustifyLastLine = true;
            //style.Alignment.ShrinkToFit = true;
            styleYellow.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(255, 255, 0), System.Drawing.Color.Blue);
            styleBack.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(207, 226, 243), System.Drawing.Color.Blue);
            headers.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(182, 215, 168), System.Drawing.Color.Blue);
            style.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(182, 215, 168), System.Drawing.Color.Blue);


            var row = 3;
            var count = 1;
            foreach (var registro3 in datos3)
            {

                xlsdocument.SetRowHeight(1, 35.0);
                xlsdocument.SetRowHeight(row, 100.0);
                xlsdocument.SetRowHeight(2, 50.0);

                //xlsdocument.SetWorksheetDefaultRowHeight(100.0);
                xlsdocument.MergeWorksheetCells(1, 1, 1, 3);
                xlsdocument.MergeWorksheetCells(1, 4, 1, 6);
                xlsdocument.SetCellStyle(1, 4, styleBack);
                xlsdocument.SetCellValue(1, 1, "SEGUIMIENTO Y CUMPLIMIENTO CONTRAPARTIDAS");
                xlsdocument.SetCellStyle(1, 1, styleBack);
                xlsdocument.SetCellStyle(1, 15, borders);
                xlsdocument.SetCellValue(2, 1, "NO.");
                xlsdocument.SetCellStyle(2, 1, style);
                xlsdocument.SetCellStyle(2, 1, borders);
                xlsdocument.SetColumnWidth("A", 13.0);
                xlsdocument.SetCellValue(2, 2, "Nombre del Proyecto");
                //xlsdocument.MergeWorksheetCells(3, 3, 4, 3);
                xlsdocument.SetCellStyle(2, 2, style);
                xlsdocument.SetCellStyle(2, 2, styleYellow);
                xlsdocument.SetCellStyle(2, 2, borders);
                xlsdocument.SetCellValue(2, 3, "Entidad");
                //xlsdocument.MergeWorksheetCells(3, 4, 4, 4);
                xlsdocument.SetCellStyle(2, 3, style);
                xlsdocument.SetCellStyle(2, 3, borders);
                xlsdocument.SetCellValue(2, 4, "Valor Contrapartida");
                //xlsdocument.MergeWorksheetCells(3, 5, 4, 5);
                xlsdocument.SetCellStyle(2, 4, style);
                xlsdocument.SetCellStyle(2, 4, borders);
                xlsdocument.SetCellValue(2, 5, "Productos Contrapartida");
                //xlsdocument.MergeWorksheetCells(3, 6, 4, 6);
                xlsdocument.SetCellStyle(2, 5, style);
                xlsdocument.SetCellStyle(2, 5, borders);
                xlsdocument.SetCellValue(2, 6, "Fecha Finalización Proyecto");
                //xlsdocument.MergeWorksheetCells(3, 7, 4, 7);
                xlsdocument.SetCellStyle(2, 6, style);
                xlsdocument.SetCellStyle(2, 6, borders);
                
      




                //if (registro8.id_propuesta != null)
                //    xlsdocument.SetCellValue(row, column, (int)registro8.id_propuesta);
                //xlsdocument.SetCellStyle(3, 3, style);
                ////xlsdocument.MergeWorksheetCells(26, 2, 26, 8);
                ///
                xlsdocument.SetCellValue(row, 1, count);
                xlsdocument.SetCellStyle(row, 1, borders);
                xlsdocument.SetCellStyle(row, 1, textCenter);

                if (registro3.nombreproyecto != null)
                {
                    xlsdocument.SetCellValue(row, 2, registro3.nombreproyecto);
                    xlsdocument.SetCellStyle(row, 2, borders);

                }
                //xlsdocument.SetCellStyle(4, 3, style);
                ////xlsdocument.MergeWorksheetCells(27, 2, 27, 8);
                if (registro3.entidad != null)
                {
                    xlsdocument.SetCellValue(row, 3, registro3.entidad);
                    xlsdocument.SetCellStyle(row, 3, borders);

                }

                //xlsdocument.SetCellStyle(5, 3, style);

                if (registro3.contrapartida != null)
                    xlsdocument.SetCellValue(row, 4, registro3.contrapartida);
                xlsdocument.SetCellStyle(row, 4, borders);

                //xlsdocument.SetCellStyle(6, 3, style);
                ////xlsdocument.MergeWorksheetCells(29, 2, 29, 8);

                xlsdocument.SetCellValue(row, 5, registro3.productos);
                xlsdocument.SetCellStyle(row, 5, borders);

                //xlsdocument.SetCellStyle(7, 3, style);
                ////xlsdocument.MergeWorksheetCells(30, 2, 30, 8);

                if (registro3.fecterminacion != null)

                    xlsdocument.SetCellValue(row, 6, ((DateTime)registro3.fecterminacion).ToString());
                xlsdocument.SetCellStyle(row, 6, borders);
                xlsdocument.AutoFitColumn(1, 16);
                xlsdocument.SetColumnWidth("B", 45.0);


                count++;
                row++;
            }
            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }
        public string ExcelTablaRegistroProyectos()
        {
            var archivoreturn = "/Export/ExcelTablaRegistroProyectos" + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/ExcelTablaRegistroProyectos" + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/ExcelTablaRegistro_Proyectos.xlsx");

            SLDocument xlsdocument = new SLDocument(plantilla);

            string qry3 = "select id_asignacionproyecto, razonsocial, nombreproyecto, valinicialaporteentidad, fecterminacion, concat(fu.nombres, ' ', fu.apellidos) as director from proyectos_asignacionproyecto ap join propuesta_entidad pe on ap.idpropuesta_entidad = pe.idpropuesta_entidad join funcionario fu on ap.iddirector = fu.idfuncionario group by id_asignacionproyecto, razonsocial, nombreproyecto, valinicialaporteentidad, fecterminacion, fu.nombres, fu.apellidos";
            string qry = "select pm.nmmodalidad, count(id_asignacionproyecto) from proyectos_asignacionproyecto ap join propuesta pr  on ap.id_propuesta = pr.id_propuesta join propuesta_modalidad pm on pr.id_modalidad = pm.id_modalidad group by id_asignacionproyecto, pm.nmmodalidad ";

            string qry2 = "select count(id_asignacionproyecto) totalproyectos from proyectos_asignacionproyecto";


            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();

            NpgsqlParameter[] Param = parameterList.ToArray();



            var datos = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry, Param).ToList();
            var datos2 = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry2, Param).ToList();

            var datos3 = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry3, Param).ToList();
            //var datos4 = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry4, Param).ToList();

            //var datos7 = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry7, Param6).ToList();


            int filaxls = 4;
            int filaxls2 = 13;
            int filaxls3 = 60;
            string celdaxls = "";

            SLStyle style = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            SLStyle font = xlsdocument.CreateStyle();
            SLStyle titlefont = xlsdocument.CreateStyle();
            SLStyle line = xlsdocument.CreateStyle();
            SLStyle propuestas = xlsdocument.CreateStyle();
            SLStyle propuestastit = xlsdocument.CreateStyle();
            SLStyle prp = xlsdocument.CreateStyle();
            SLStyle prpBlue = xlsdocument.CreateStyle();
            SLStyle footer = xlsdocument.CreateStyle();
            SLStyle propuestasSb = xlsdocument.CreateStyle();
            SLStyle txtfooter = xlsdocument.CreateStyle();
            SLStyle textProjects = xlsdocument.CreateStyle();
            SLStyle colorBackground = xlsdocument.CreateStyle();
            SLStyle titred = xlsdocument.CreateStyle();




            titred.Font.FontSize = 40.0;
            titred.Font.FontColor = System.Drawing.Color.Red;
            titred.Alignment.Horizontal = HorizontalAlignmentValues.Right;
            colorBackground.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(75, 172, 198), System.Drawing.Color.Blue);

            textProjects.Font.FontSize = 16.0;
            textProjects.Font.FontColor = System.Drawing.Color.Black;
            txtfooter.Font.FontSize = 8.0;


            txtfooter.Font.FontColor = System.Drawing.Color.White;
            txtfooter.Alignment.Vertical = VerticalAlignmentValues.Center;

            prpBlue.Alignment.Vertical = VerticalAlignmentValues.Top;

            prpBlue.Font.FontSize = 16.0;
            prpBlue.Font.FontColor = System.Drawing.Color.FromArgb(45, 66, 148);


            prp.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(208, 227, 234), System.Drawing.Color.Blue);
            prp.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            prp.Border.LeftBorder.Color = System.Drawing.Color.White;
            prp.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            prp.Border.RightBorder.Color = System.Drawing.Color.White;
            prp.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            prp.Border.TopBorder.Color = System.Drawing.Color.White;
            prp.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            prp.Border.BottomBorder.Color = System.Drawing.Color.White;
            prp.Font.FontSize = 15.0;
            prp.Font.FontColor = System.Drawing.Color.FromArgb(58, 56, 56);
            prp.Alignment.Vertical = VerticalAlignmentValues.Center;
            prp.Alignment.Horizontal = HorizontalAlignmentValues.Center;


            propuestastit.Font.Bold = true;
            propuestastit.Font.FontSize = 15.0;
            propuestastit.Font.FontColor = System.Drawing.Color.White;
            propuestastit.Alignment.Vertical = VerticalAlignmentValues.Center;
            propuestastit.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            propuestastit.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(75, 172, 198), System.Drawing.Color.Blue);
            propuestastit.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            propuestastit.Border.LeftBorder.Color = System.Drawing.Color.White;
            propuestastit.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            propuestastit.Border.RightBorder.Color = System.Drawing.Color.White;
            propuestastit.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            propuestastit.Border.TopBorder.Color = System.Drawing.Color.White;
            propuestastit.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            propuestastit.Border.BottomBorder.Color = System.Drawing.Color.White;
            propuestas.Font.FontColor = System.Drawing.Color.Red;
            propuestasSb.Font.FontSize = 26.0;

            propuestasSb.Font.FontColor = System.Drawing.Color.Red;


            line.Border.BottomBorder.Color = System.Drawing.Color.Black;
            line.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            titlefont.Font.FontFamily = 1;
            titlefont.Font.FontSize = 18.0;
            titlefont.Font.FontColor = System.Drawing.Color.FromArgb(45, 66, 148);
            font.Font.FontSize = 15.0;
            font.Font.FontFamily = 1;
            font.Font.FontColor = System.Drawing.Color.FromArgb(108, 120, 168);
            font.Alignment.Horizontal = HorizontalAlignmentValues.Left;
            font.Alignment.Vertical = VerticalAlignmentValues.Top;

            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            //            style.SetWrapText(true);
            //style.Alignment.JustifyLastLine = true;
            //style.Alignment.ShrinkToFit = true;

            styleBack.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(230, 230, 230), System.Drawing.Color.Blue);
            footer.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(45, 66, 148), System.Drawing.Color.Blue);


            for (var i = 2; i <= 8; i++)
            {
                var b = "B" + i;
                var c = "C" + i;
                var d = "D" + i;
                var e = "E" + i;
                var f = "F" + i;
                var g = "G" + i;
                var h = "H" + i;


                xlsdocument.SetCellStyle(b, styleBack);
                xlsdocument.SetCellStyle(c, styleBack);
                xlsdocument.SetCellStyle(d, styleBack);
                xlsdocument.SetCellStyle(e, styleBack);
                xlsdocument.SetCellStyle(f, styleBack);
                xlsdocument.SetCellStyle(g, styleBack);
                xlsdocument.SetCellStyle(h, styleBack);


            }

            var row = 6;
            if (datos != null)
            {


                foreach (var registro in datos)
                {
                    xlsdocument.AutoFitColumn(1, 30);

                    xlsdocument.SetColumnWidth(3, 20.0);

                    var b = "B" + row;
                    var c = "C" + row;
                    var d = "D" + row;
                    var e = "E" + row;
                    var f = "F" + row;
                    var g = "G" + row;
                    var h = "H" + row;
                    xlsdocument.SetCellStyle(b, styleBack);
                    xlsdocument.SetCellStyle(c, styleBack);
                    xlsdocument.SetCellStyle(d, styleBack);
                    xlsdocument.SetCellStyle(e, styleBack);
                    xlsdocument.SetCellStyle(f, styleBack);
                    xlsdocument.SetCellStyle(g, styleBack);
                    xlsdocument.SetCellStyle(h, styleBack);

                    xlsdocument.SetCellStyle("C3", line);
                    xlsdocument.SetCellStyle("D3", line);
                    xlsdocument.SetCellStyle("E3", line);
                    xlsdocument.SetCellStyle("F3", line);

                    xlsdocument.SetCellStyle(3, 3, propuestas);

                    xlsdocument.SetCellValue(3, 4, "Proyectos");
                    xlsdocument.SetCellStyle(3, 4, propuestasSb);


                    xlsdocument.SetCellValue(3, 2, "          SEGUIMIENTO PROYECTOS EN EJECUCIÓN 2021");
                    xlsdocument.SetCellStyle(3, 2, titlefont);

                    xlsdocument.SetCellValue(5, 2, "          Informacion de Matriz Asignación de proyectos");
                    xlsdocument.SetCellValue(6, 2, "          y matrices de ejecución de cada proyecto");

                    xlsdocument.SetCellStyle(5, 2, font);
                    xlsdocument.SetCellStyle(6, 2, font);

                    xlsdocument.SetCellValue(row, 5, registro.nmmodalidad);
                    xlsdocument.SetCellStyle(row, 5, prpBlue);
                    xlsdocument.SetCellValue(row, 4, "Proyectos");
                    xlsdocument.SetCellStyle(row, 4, textProjects);

                    xlsdocument.SetCellValue(row, 3, registro.count);
                    xlsdocument.SetCellStyle(row, 3, textProjects);


                    row++;


                }
                foreach (var registro2 in datos2)
                {
                    xlsdocument.AutoFitColumn(1, 30);

                    xlsdocument.SetColumnWidth(3, 20.0);

                    var b = "B" + row;
                    var c = "C" + row;
                    var d = "D" + row;
                    var e = "E" + row;
                    var f = "F" + row;
                    var g = "G" + row;
                    var h = "H" + row;


                    xlsdocument.SetCellStyle(b, styleBack);
                    xlsdocument.SetCellStyle(c, styleBack);
                    xlsdocument.SetCellStyle(d, styleBack);
                    xlsdocument.SetCellStyle(e, styleBack);
                    xlsdocument.SetCellStyle(f, styleBack);
                    xlsdocument.SetCellStyle(g, styleBack);
                    xlsdocument.SetCellStyle(h, styleBack);


                    xlsdocument.SetCellStyle("C3", line);
                    xlsdocument.SetCellStyle("D3", line);
                    xlsdocument.SetCellStyle("E3", line);
                    xlsdocument.SetCellStyle("F3", line);


                    xlsdocument.SetCellValue(3, 3, registro2.totalproyectos);
                    xlsdocument.SetCellStyle(3, 3, titred);



                    //sum += registro2.totalmodalidadpropuesta;

             



                    row++;

                    xlsdocument.SetCellValue("B" + row, "Entidad");
                    xlsdocument.SetCellStyle("B" + row, propuestastit);

                    xlsdocument.SetCellValue("C" + row, "Nombre del Proyecto");
                    xlsdocument.SetCellStyle("C" + row, propuestastit);

                    xlsdocument.SetCellValue("D" + row, "Aporte de la Entidad");
                    xlsdocument.SetCellStyle("D" + row, propuestastit);

                    xlsdocument.SetCellValue("E" + row, "Plazo");
                    xlsdocument.SetCellStyle("E" + row, propuestastit);

                    xlsdocument.SetCellValue("F" + row, "Director");
                    xlsdocument.SetCellStyle("F" + row, propuestastit);




                }
                var rowData = row+1; 
                foreach(var registro3 in datos3)
                {
                    var b = "B" + rowData;
                    var c = "C" + rowData;
                    var d = "D" + rowData;
                    var e = "E" + rowData;
                    var f = "F" + rowData;
                    var g = "G" + rowData;
                    var h = "H" + rowData;
                    xlsdocument.SetCellStyle(b, styleBack);
                    xlsdocument.SetCellStyle(c, styleBack);
                    xlsdocument.SetCellStyle(d, styleBack);
                    xlsdocument.SetCellStyle(e, styleBack);
                    xlsdocument.SetCellStyle(f, styleBack);
                    xlsdocument.SetCellStyle(g, styleBack);
                    xlsdocument.SetCellStyle(h, styleBack);
                    xlsdocument.SetCellStyle("G" + (rowData-1), styleBack);
                    xlsdocument.SetCellStyle("H" + (rowData - 1), styleBack);



                    xlsdocument.AutoFitColumn(1, 30);
                    xlsdocument.SetCellValue("B" + rowData, registro3.razonsocial);
                    xlsdocument.SetCellStyle("B" + rowData, propuestastit);

                    xlsdocument.SetCellValue("C" + rowData, registro3.nombreproyecto);
                    xlsdocument.SetCellStyle("C" + rowData, prp);

                    xlsdocument.SetCellValue("D" + rowData, registro3.valinicialaporteentidad);
                    xlsdocument.SetCellStyle("D" + rowData, prp);

                    xlsdocument.SetCellValue("E" + rowData, (DateTime)registro3.fecterminacion).ToString();
                    xlsdocument.SetCellStyle("E" + rowData, prp);

                    xlsdocument.SetCellValue("F" + rowData, registro3.director);
                    xlsdocument.SetCellStyle("F" + rowData, prp);





                    rowData++;
                }

                xlsdocument.MergeWorksheetCells(rowData, 2, rowData, 8);
                xlsdocument.MergeWorksheetCells(rowData + 1, 2, rowData + 1, 8);
                var foot = "B" + (rowData + 1);
                var margin = "B" + rowData;

                xlsdocument.SetCellStyle(margin, styleBack);

                xlsdocument.SetRowHeight(rowData + 1, 45.0);
                xlsdocument.SetRowHeight(rowData, 15.0);

                xlsdocument.SetCellStyle(foot, footer);
                xlsdocument.SetCellValue(foot, "      Facultad de Derecho, Ciencias Politicas y Sociales Sede Bogotá" +
                "                                                                                                                        " +
                "Proyecto CULTURAl, CIENTIFICO, y COLECTIVO de Nación ");


                xlsdocument.SetCellStyle(foot, txtfooter);
            }
            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }
        public string ExcelNumProyectos()
        {
            var archivoreturn = "/Export/ExcelNumProyectos" + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/ExcelNumProyectos" + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/Excel_NumProyectos.xlsx");

            SLDocument xlsdocument = new SLDocument(plantilla);

            string qry = "select pm.nmmodalidad, count(id_asignacionproyecto) from proyectos_asignacionproyecto ap join propuesta pr on ap.id_propuesta = pr.id_propuesta join propuesta_modalidad pm on pr.id_modalidad = pm.id_modalidad group by pm.nmmodalidad ";

            string qry2 = "select count(id_asignacionproyecto) totalproyectos from proyectos_asignacionproyecto";


            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();

            NpgsqlParameter[] Param = parameterList.ToArray();



            var datos = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry, Param).ToList();
            var datos2 = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry2, Param).ToList();
            //var datos3 = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry3, Param).ToList();
            //var datos4 = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry4, Param).ToList();

            //var datos7 = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry7, Param6).ToList();


            int filaxls = 4;
            int filaxls2 = 13;
            int filaxls3 = 60;
            string celdaxls = "";

            SLStyle style = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            SLStyle font = xlsdocument.CreateStyle();
            SLStyle titlefont = xlsdocument.CreateStyle();
            SLStyle line = xlsdocument.CreateStyle();
            SLStyle propuestas = xlsdocument.CreateStyle();
            SLStyle propuestastit = xlsdocument.CreateStyle();
            SLStyle prp = xlsdocument.CreateStyle();
            SLStyle prpBlue = xlsdocument.CreateStyle();
            SLStyle footer = xlsdocument.CreateStyle();
            SLStyle propuestasSb = xlsdocument.CreateStyle();
            SLStyle txtfooter = xlsdocument.CreateStyle();
            SLStyle textProjects = xlsdocument.CreateStyle();



            textProjects.Font.FontSize = 16.0;
            textProjects.Font.FontColor = System.Drawing.Color.Black;
            txtfooter.Font.FontSize = 8.0;


            txtfooter.Font.FontColor = System.Drawing.Color.White;
            txtfooter.Alignment.Vertical = VerticalAlignmentValues.Center;

            prpBlue.Alignment.Vertical = VerticalAlignmentValues.Top;

            prpBlue.Font.FontSize = 16.0;
            prpBlue.Font.FontColor = System.Drawing.Color.FromArgb(45, 66, 148);

            prp.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            prp.Alignment.Vertical = VerticalAlignmentValues.Top;
            prp.Font.FontSize = 16.0;

            propuestastit.Font.FontSize = 72.0;
            propuestas.Font.FontColor = System.Drawing.Color.Red;
            propuestasSb.Font.FontSize = 26.0;

            propuestasSb.Font.FontColor = System.Drawing.Color.Red;


            line.Border.BottomBorder.Color = System.Drawing.Color.Black;
            line.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            titlefont.Font.FontFamily = 1;
            titlefont.Font.FontSize = 18.0;
            titlefont.Font.FontColor = System.Drawing.Color.FromArgb(45, 66, 148);
            font.Font.FontSize = 15.0;
            font.Font.FontFamily = 1;
            font.Font.FontColor = System.Drawing.Color.FromArgb(108, 120, 168);
            font.Alignment.Horizontal = HorizontalAlignmentValues.Left;
            font.Alignment.Vertical = VerticalAlignmentValues.Top;

            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            //            style.SetWrapText(true);
            //style.Alignment.JustifyLastLine = true;
            //style.Alignment.ShrinkToFit = true;

            styleBack.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(230, 230, 230), System.Drawing.Color.Blue);
            //footer.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(45, 66, 148), System.Drawing.Color.Blue);


            for (var i = 2; i <= 8; i++)
            {
                var b = "B" + i;
                var c = "C" + i;
                var d = "D" + i;
                var e = "E" + i;
                var f = "F" + i;
                var g = "G" + i;
                var h = "H" + i;


                xlsdocument.SetCellStyle(b, styleBack);
                xlsdocument.SetCellStyle(c, styleBack);
                xlsdocument.SetCellStyle(d, styleBack);
                xlsdocument.SetCellStyle(e, styleBack);
                xlsdocument.SetCellStyle(f, styleBack);
                xlsdocument.SetCellStyle(g, styleBack);
                xlsdocument.SetCellStyle(h, styleBack);


            }

            var row = 6;
            if (datos != null)
            {


                foreach (var registro in datos)
                {
                    xlsdocument.AutoFitColumn(1, 30);

                    xlsdocument.SetColumnWidth(3, 20.0);

                    var b = "B" + row;
                    var c = "C" + row;
                    var d = "D" + row;
                    var e = "E" + row;
                    var f = "F" + row;
                    var g = "G" + row;
                    var h = "H" + row;

                    xlsdocument.SetCellStyle(b, styleBack);
                    xlsdocument.SetCellStyle(c, styleBack);
                    xlsdocument.SetCellStyle(d, styleBack);
                    xlsdocument.SetCellStyle(e, styleBack);
                    xlsdocument.SetCellStyle(f, styleBack);
                    xlsdocument.SetCellStyle(g, styleBack);
                    xlsdocument.SetCellStyle(h, styleBack);

                    xlsdocument.SetCellStyle("C3", line);
                    xlsdocument.SetCellStyle("D3", line);
                    xlsdocument.SetCellStyle("E3", line);
                    xlsdocument.SetCellStyle("F3", line);



                    xlsdocument.SetCellValue(3, 2, "          SEGUIMIENTO PROYECTOS EN EJECUCIÓN 2021");
                    xlsdocument.SetCellStyle(3, 2, titlefont);

                    xlsdocument.SetCellValue(5, 2, "          Informacion de Matriz Asignación de proyectos");
                    xlsdocument.SetCellValue(6, 2, "          y matrices de ejecución de cada proyecto");

                    xlsdocument.SetCellStyle(5, 2, font);
                    xlsdocument.SetCellStyle(6, 2, font);

                    xlsdocument.SetCellValue(row, 5, registro.nmmodalidad);
                    xlsdocument.SetCellStyle(row, 5, prpBlue);
                    xlsdocument.SetCellValue(row, 4, "Proyectos");
                    xlsdocument.SetCellStyle(row, 4, textProjects);

                    xlsdocument.SetCellValue(row, 3, registro.count);
                    xlsdocument.SetCellStyle(row, 3, textProjects);

                    row++;


                }
                foreach (var registro2 in datos2)
                {
                    xlsdocument.AutoFitColumn(1, 30);

                    xlsdocument.SetColumnWidth(3, 20.0);

                    var b = "B" + row;
                    var c = "C" + row;
                    var d = "D" + row;
                    var e = "E" + row;
                    var f = "F" + row;
                    var g = "G" + row;
                    var h = "H" + row;

                    xlsdocument.SetCellStyle("C3", line);
                    xlsdocument.SetCellStyle("D3", line);
                    xlsdocument.SetCellStyle("E3", line);
                    xlsdocument.SetCellStyle("F3", line);


                    xlsdocument.SetCellStyle(b, styleBack);
                    xlsdocument.SetCellStyle(c, styleBack);
                    xlsdocument.SetCellStyle(d, styleBack);
                    xlsdocument.SetCellStyle(e, styleBack);
                    xlsdocument.SetCellStyle(f, styleBack);
                    xlsdocument.SetCellStyle(g, styleBack);
                    xlsdocument.SetCellStyle(h, styleBack);

                    xlsdocument.SetCellValue(3, 3, registro2.totalproyectos);
                    xlsdocument.SetCellStyle(3, 3, prp);

      

                    //sum += registro2.totalmodalidadpropuesta;

                    xlsdocument.SetCellStyle(3, 3, propuestas);
                    xlsdocument.SetCellStyle(3, 3, propuestastit);

                    xlsdocument.SetCellValue(3, 4, "Proyectos");
                    xlsdocument.SetCellStyle(3, 4, propuestasSb);

                    row++;

                }



            }
            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }
        public string ExcelContratacion()
        {
            var archivoreturn = "/Export/ExcelContratacion" + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/ExcelContratacion" + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/Excel_Contratacion.xlsx");

            SLDocument xlsdocument = new SLDocument(plantilla);

            string qry = "select cp.id_kardex, (ca.tirajetotal) - (sum(unidadesvendidas)) as total_inventario, sum(unidadesvendidas) as unidades_vendidas, sum(pd.valorventas) as total_ventas from publicaciones_depositocontrolrepventas pd join publicaciones_crearpublicacion cp on pd.id_crearpublicacion = cp.id_crearpublicacion join publicaciones_depositocontrolacta ca on cp.id_crearpublicacion = ca.id_crearpublicacion group by cp.id_kardex, ca.tirajetotal";

            string qry2 = "select cp.id_kardex as kardex, ca.tirajetotal-(sum(dc.cantidad)) as inv_institucional, ca.tirajetotal - (ca.tirajetotal - (sum(dc.cantidad))) as inv_comercial from publicaciones_depositocontrolacta ca join publicaciones_depositodistribucioncomercial dc on ca.id_crearpublicacion = dc.id_crearpublicacion join publicaciones_crearpublicacion cp on dc.id_crearpublicacion = cp.id_crearpublicacion group by id_kardex, ca.tirajetotal";
            string qry3 = "select ib.nmbodega, sum (im.cantidad) as ajustes from publicaciones_depositocontrolinventariomovimientos im join publicaciones_depositocontrolinventariobodega ib on im.id_bodega = ib.id_bodega group by ib.id_bodega ";
            string qry4 = "select cp.id_kardex, nmformatodis, sum(unidadesvendidas) as unidades_vendidas from publicaciones_depositocontrolrepventas pd join publicaciones_crearpublicacion cp on pd.id_crearpublicacion = cp.id_crearpublicacion join publicaciones_formatodistribucion fd on cp.id_formatodistribucion = fd.id_formatodistribucion group by cp.id_kardex, nmformatodis ";


            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();

            NpgsqlParameter[] Param = parameterList.ToArray();



            var datos = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry, Param).ToList();
            var datos2 = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry2, Param).ToList();
            var datos3 = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry3, Param).ToList();
            var datos4 = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry4, Param).ToList();

            //var datos7 = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry7, Param6).ToList();


            int filaxls = 4;
            int filaxls2 = 13;
            int filaxls3 = 60;
            string celdaxls = "";

            SLStyle style = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            SLStyle borders = xlsdocument.CreateStyle();
            SLStyle backg = xlsdocument.CreateStyle();
            SLStyle bordersTop = xlsdocument.CreateStyle();
            SLStyle bordersbtm = xlsdocument.CreateStyle();

            bordersTop.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            bordersTop.Border.TopBorder.Color = System.Drawing.Color.Black;

            bordersbtm.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            bordersbtm.Border.BottomBorder.Color = System.Drawing.Color.Black;

            borders.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.LeftBorder.Color = System.Drawing.Color.Black;
            borders.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.RightBorder.Color = System.Drawing.Color.Black;
            borders.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.TopBorder.Color = System.Drawing.Color.Black;
            borders.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.BottomBorder.Color = System.Drawing.Color.Black;


            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            //            style.SetWrapText(true);
            //style.Alignment.JustifyLastLine = true;
            //style.Alignment.ShrinkToFit = true;

            styleBack.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(230, 230, 230), System.Drawing.Color.Blue);
            backg.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(255, 255, 255), System.Drawing.Color.Blue);


            xlsdocument.SetRowHeight(4, 50.0);
            xlsdocument.SetRowHeight(5, 30.0);

            xlsdocument.AutoFitColumn(1, 30);

            var row = 4;
            var rowinv = 4;

            if (datos != null)
            {


                foreach (var registro4 in datos4)
                {



                    xlsdocument.SetCellValue("H3", "Unidades");
                    xlsdocument.SetCellValue("I3", "$");
                    xlsdocument.SetCellStyle("H3", borders);
                    xlsdocument.SetCellStyle("I3", borders);


                    xlsdocument.SetCellValue(4, 6, "Casa Gaitán");
                    xlsdocument.SetCellValue(4, 5, "Bodega");
                    xlsdocument.SetCellStyle(4, 6, borders);
                    xlsdocument.SetCellStyle(4, 5, borders);

                    xlsdocument.AutoFitColumn(1, 30);

                    row++;

                }
                xlsdocument.SetCellValue(row - 1, 6, "Editorial UN");
                xlsdocument.SetCellValue(row - 1, 5, "Consignación");
                xlsdocument.SetCellStyle(row - 1, 5, borders);
                xlsdocument.SetCellStyle(row - 1, 6, borders);
                xlsdocument.SetCellStyle(7, 8, borders);
                xlsdocument.SetCellStyle(7, 9, borders);
                xlsdocument.SetCellStyle(4, 7, bordersTop);
                xlsdocument.SetCellStyle(5, 7, bordersbtm);
                xlsdocument.SetCellStyle(7, 4, borders);
                xlsdocument.SetCellStyle(6, 4, borders);
                xlsdocument.SetCellStyle(5, 4, borders);







            }


            foreach (var registro3 in datos3)
            {
                xlsdocument.AutoFitColumn(1, 30);
                xlsdocument.SetCellValue("D4", "INVENTARIO");
                xlsdocument.SetCellStyle("D4", borders);

                xlsdocument.SetCellValue(rowinv, 7, registro3.nmbodega);

                xlsdocument.MergeWorksheetCells("D4", "D" + rowinv);

                rowinv++;

            }
            foreach (var registro2 in datos2)
            {

                xlsdocument.SetCellValue(4, 8, registro2.inv_institucional);
                xlsdocument.SetCellStyle(4, 8, borders);
                xlsdocument.SetCellStyle(4, 9, borders);


                xlsdocument.SetCellValue(rowinv - 1, 8, registro2.inv_comercial);
                xlsdocument.SetCellStyle(rowinv - 1, 8, borders);
                xlsdocument.SetCellStyle(rowinv - 1, 9, borders);



                xlsdocument.AutoFitColumn(1, 30);

                //xlsdocument.SetCellValue(, 8, registro2.inv_comercial);


            }
            var rownminv = rowinv;

            foreach (var registro5 in datos4)
            {

                xlsdocument.SetCellValue(rownminv, 5, registro5.nmformatodis);
                xlsdocument.SetCellStyle(rowinv+1, 5, bordersbtm);
                xlsdocument.SetCellStyle(rowinv+1, 6, bordersbtm);
                xlsdocument.SetCellStyle(rowinv+1, 7, bordersbtm);

                xlsdocument.MergeWorksheetCells("F" + rownminv, "G" + rownminv);
                xlsdocument.SetCellStyle(rownminv, 5, backg);
                xlsdocument.SetCellStyle("F" + rownminv, backg);
                xlsdocument.MergeWorksheetCells("D" + rowinv, "D" + rownminv);
                xlsdocument.SetCellValue("D" + rowinv, "VENTAS");
                xlsdocument.MergeWorksheetCells("H" + rowinv, "H" + rownminv);
                xlsdocument.MergeWorksheetCells("I" + rowinv, "I" + rownminv);
                xlsdocument.SetCellStyle("I" + rowinv, borders);
                xlsdocument.SetCellStyle("H" + rowinv, borders);

                xlsdocument.AutoFitColumn(1, 30);


                rownminv++;
            }
            foreach (var registro in datos)
            {
                xlsdocument.AutoFitColumn(1, 30);

                xlsdocument.SetCellValue("H" + rowinv, registro.unidades_vendidas);
                xlsdocument.SetCellValue("I" + rowinv, registro.total_ventas);
                xlsdocument.SetColumnWidth("D", 15.0);
                xlsdocument.SetColumnWidth("I", 20.0);





            }

            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }
        public string ExcelProyectosPEC()
        {
            var archivoreturn = "/Export/ExcelProyectosPEC" + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/ExcelProyectosPEC" + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/ExcelProyectos_PEC.xlsx");
            SLDocument xlsdocument = new SLDocument(plantilla);

            string qry6 = "SELECT ID_PROPUESTA, NMPROPUESTA, VALORINICIALPROPUESTA, EP.NMESTADOPROPUESTA FROM PROPUESTA PR JOIN PROPUESTA_TIPOUSUARIO TP ON PR.id_propuestatipousuario = TP.id_propuestatipousuario JOIN PROPUESTA_MODALIDAD PM ON PR.ID_MODALIDAD = PM.ID_MODALIDAD JOIN PROPUESTA_ESTADOPROPUESTA EP ON PR.ID_ESTADOPROPUESTA = EP.ID_ESTADOPROPUESTA where TP.id_propuestatipousuario = 10 and PM.NMMODALIDAD = 'PEC' GROUP BY ID_PROPUESTA, NMPROPUESTA, VALORINICIALPROPUESTA, EP.NMESTADOPROPUESTA";

            List<NpgsqlParameter> parameterList6 = new List<NpgsqlParameter>();
            NpgsqlParameter[] Param6 = parameterList6.ToArray();
            var datos = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry6, Param6).ToList();

            int filaxls = 4;
            int filaxls2 = 13;
            int filaxls3 = 60;
            string celdaxls = "";

            SLStyle style = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            SLStyle font = xlsdocument.CreateStyle();
            SLStyle titlefont = xlsdocument.CreateStyle();
            SLStyle line = xlsdocument.CreateStyle();
            SLStyle propuestastit = xlsdocument.CreateStyle();
            SLStyle prp = xlsdocument.CreateStyle();
            SLStyle footer = xlsdocument.CreateStyle();
            SLStyle txtfooter = xlsdocument.CreateStyle();




            txtfooter.Font.FontSize = 8.0;


            txtfooter.Font.FontColor = System.Drawing.Color.White;
            txtfooter.Alignment.Vertical = VerticalAlignmentValues.Center;




            prp.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(252, 194, 147), System.Drawing.Color.Blue);
            prp.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            prp.Border.LeftBorder.Color = System.Drawing.Color.White;
            prp.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            prp.Border.RightBorder.Color = System.Drawing.Color.White;
            prp.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            prp.Border.TopBorder.Color = System.Drawing.Color.White;
            prp.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            prp.Border.BottomBorder.Color = System.Drawing.Color.White;
            prp.Font.FontSize = 15.0;
            prp.Font.FontColor = System.Drawing.Color.Black;
            prp.Alignment.Vertical = VerticalAlignmentValues.Center;
            prp.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            propuestastit.Font.FontSize = 15.0;
            propuestastit.Font.FontColor = System.Drawing.Color.Black;
            propuestastit.Alignment.Vertical = VerticalAlignmentValues.Center;
            propuestastit.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            propuestastit.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(247, 150, 70), System.Drawing.Color.Blue);
            propuestastit.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            propuestastit.Border.LeftBorder.Color = System.Drawing.Color.White;
            propuestastit.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            propuestastit.Border.RightBorder.Color = System.Drawing.Color.White;
            propuestastit.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            propuestastit.Border.TopBorder.Color = System.Drawing.Color.White;
            propuestastit.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            propuestastit.Border.BottomBorder.Color = System.Drawing.Color.White;

            titlefont.Font.FontFamily = 1;
            titlefont.Font.FontSize = 18.0;
            titlefont.Font.FontColor = System.Drawing.Color.FromArgb(45, 66, 148);
            font.Font.FontSize = 15.0;
            font.Font.FontFamily = 1;
            font.Font.FontColor = System.Drawing.Color.FromArgb(108, 120, 168);
            font.Alignment.Vertical = VerticalAlignmentValues.Center;

            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            //            style.SetWrapText(true);
            //style.Alignment.JustifyLastLine = true;
            //style.Alignment.ShrinkToFit = true;

            styleBack.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(230, 230, 230), System.Drawing.Color.Blue);
            footer.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(45, 66, 148), System.Drawing.Color.Blue);


            for (var i = 2; i <= 5; i++)
            {
                var b = "B" + i;
                var c = "C" + i;
                var d = "D" + i;
                var e = "E" + i;
                var f = "F" + i;
                var g = "G" + i;
                var h = "H" + i;
                var I = "I" + i;

                xlsdocument.SetCellStyle(b, styleBack);
                xlsdocument.SetCellStyle(c, styleBack);
                xlsdocument.SetCellStyle(d, styleBack);
                xlsdocument.SetCellStyle(e, styleBack);
                xlsdocument.SetCellStyle(f, styleBack);
                xlsdocument.SetCellStyle(g, styleBack);
                xlsdocument.SetCellStyle(h, styleBack);
            }




            var row = 6;
            if (datos != null)
            {
                {


                    foreach (var registro in datos)
                    {

                        xlsdocument.SetCellStyle("B2", "H2", styleBack);

                        var b = "B" + row;
                        var c = "C" + row;
                        var d = "D" + row;
                        var e = "E" + row;
                        var f = "F" + row;
                        var g = "G" + row;
                        var h = "H" + row;
                        var I = "I" + row;

                        xlsdocument.SetCellStyle(b, styleBack);
                        xlsdocument.SetCellStyle(c, styleBack);
                        xlsdocument.SetCellStyle(d, styleBack);
                        xlsdocument.SetCellStyle(e, styleBack);
                        xlsdocument.SetCellStyle(f, styleBack);
                        xlsdocument.SetCellStyle(g, styleBack);
                        xlsdocument.SetCellStyle(h, styleBack);

                        xlsdocument.MergeWorksheetCells(2, 2, 2, 8);
                        xlsdocument.MergeWorksheetCells(3, 2, 3, 8);
                        xlsdocument.SetRowHeight(5, 35.0);

                        xlsdocument.SetRowHeight(2, 25.0);
                        xlsdocument.SetRowHeight(3, 25.0);
                        xlsdocument.SetCellValue(2, 2, "PROYECTOS PEC ABIERTOS AL PUBLICO");
                        xlsdocument.SetCellStyle(2, 2, titlefont);

                        xlsdocument.SetCellValue(3, 2, "Información de Matriz Cono de Propuestas");
                        xlsdocument.SetCellStyle(3, 2, font);
                        xlsdocument.SetCellValue(5, 3, "Nombre");
                        xlsdocument.SetCellStyle(5, 3, propuestastit);

                        xlsdocument.SetCellValue(5, 4, "Valor Inicial Propuesta");
                        xlsdocument.SetCellStyle(5, 4, propuestastit);

                        xlsdocument.SetCellValue(5, 5, "Estado Propuesta");
                        xlsdocument.SetCellStyle(5, 5, propuestastit);

                        //xlsdocument.SetCellValue(5, 6, "Estado");
                        //xlsdocument.SetCellStyle(5, 6, propuestastit);


                        xlsdocument.SetRowHeight(row, 35.0);

                        xlsdocument.SetCellValue(row, 3, registro.nmpropuesta);
                        xlsdocument.SetCellStyle(row, 3, propuestastit);

                        xlsdocument.SetCellValue(row, 4, registro.valorinicialpropuesta);
                        xlsdocument.SetCellStyle(row, 4, prp);

                        xlsdocument.SetCellValue(row, 5, registro.nmestadopropuesta);
                        xlsdocument.SetCellStyle(row, 5, prp);

                        //xlsdocument.SetCellValue(row, 6, registro.nmpropuesta);
                        //xlsdocument.SetCellStyle(row, 6, prp);
                        xlsdocument.AutoFitColumn(1, 30);




                        row++;

                    }
                    xlsdocument.MergeWorksheetCells(row, 2, row, 8);
                    xlsdocument.MergeWorksheetCells(row + 1, 2, row + 1, 8);
                    var foot = "B" + (row + 1);
                    var margin = "B" + row;

                    xlsdocument.SetCellStyle(margin, styleBack);

                    xlsdocument.SetRowHeight(row + 1, 45.0);
                    xlsdocument.SetRowHeight(row, 15.0);

                    xlsdocument.SetCellStyle(foot, footer);
                    xlsdocument.SetCellValue(foot, "      Facultad de Derecho, Ciencias Politicas y Sociales Sede Bogotá" +
                    "                                                                                                                        " +
                    "Proyecto CULTURAl, CIENTIFICO, y COLECTIVO de Nación ");


                    xlsdocument.SetCellStyle(foot, txtfooter);
                }
            }




            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }
        public string ExcelMatrizLiquidacionFinalizacionProyectos()
        {
            var archivoreturn = "/Export/ExcelLIQUIDACIÓNYFINALIZACIÓNPROYECTOS_" + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/ExcelLIQUIDACIÓNYFINALIZACIÓNPROYECTOS_" + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/EXCELLIQUIDACIONYFINALIZACIONO_PROYECTOS_.xlsx");
            SLDocument xlsdocument = new SLDocument(plantilla);
            string qry = "SELECT lf.ingresos, lf.pagos, lf.transferencias, lf.liquidacioninternahermes, lf.resumenestado, ap.nombreproyecto, lf.fechafincontratoasistente, lf.ordenesnumhermes, lf.matrizsegejecucion, lf.transferenciascope, lf.balfifinalfirmado, lf.subproyectofinhermes, lf.proacahermesuncompdrive, lf.correoinstitucionalproy, lf.actaliqentidad, lf.entregaarchivoce, lf.resolucionliqinterna, lf.consecutivosrequerimientos, lf.fecultimarev, concat(fu.nombres, ' ', fu.apellidos), ec.estadocontrato, lf.pagoscumplidos, lf.fechaestado, lf.informefinal, lf.informefinalenlace, lf.observaciones, lf.productoacademicoenlace, lf.actaliqentidadenlace FROM liquidacion_finalizacion lf join proyectos_asignacionproyecto ap on lf.id_asignacionproyecto = ap.id_asignacionproyecto join funcionario fu on lf.idfuncionario = fu.idfuncionario join proyectos_estadocontrato ec on lf.id_estadocontrato = ec.id_estadocontrato group by lf.ingresos, lf.pagos, lf.transferencias, lf.liquidacioninternahermes, lf.resumenestado, ap.nombreproyecto, lf.fechafincontratoasistente, lf.ordenesnumhermes, lf.matrizsegejecucion, lf.transferenciascope, lf.balfifinalfirmado, lf.subproyectofinhermes, lf.proacahermesuncompdrive, lf.correoinstitucionalproy, lf.actaliqentidad, lf.entregaarchivoce, lf.resolucionliqinterna, lf.consecutivosrequerimientos, lf.fecultimarev, concat(fu.nombres, ' ', fu.apellidos), ec.estadocontrato, lf.pagoscumplidos, lf.fechaestado, lf.informefinal, lf.informefinalenlace, lf.observaciones, lf.productoacademicoenlace, lf.actaliqentidadenlace";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            NpgsqlParameter[] Param = parameterList.ToArray();
            var datos = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry, Param).ToList();

            int filaxls = 4;
            int filaxls2 = 13;
            int filaxls3 = 60;
            string celdaxls = "";



            SLStyle style = xlsdocument.CreateStyle();
            SLStyle borders = xlsdocument.CreateStyle();
            borders.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.LeftBorder.Color = System.Drawing.Color.Black;
            borders.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.RightBorder.Color = System.Drawing.Color.Black;
            borders.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.TopBorder.Color = System.Drawing.Color.Black;
            borders.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.BottomBorder.Color = System.Drawing.Color.Black;

            SLStyle headers = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            SLStyle styleYellow = xlsdocument.CreateStyle();
            SLStyle textCenter = xlsdocument.CreateStyle();

            textCenter.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            textCenter.Alignment.Vertical = VerticalAlignmentValues.Center;
            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            style.Font.Bold = true;
            styleBack.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            styleBack.Alignment.Vertical = VerticalAlignmentValues.Center;
            styleBack.Font.Bold = true;
            //            style.SetWrapText(true);
            //style.Alignment.JustifyLastLine = true;
            //style.Alignment.ShrinkToFit = true;
            styleYellow.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(255, 255, 0), System.Drawing.Color.Blue);
            styleBack.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(207, 226, 243), System.Drawing.Color.Blue);
            headers.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(182, 215, 168), System.Drawing.Color.Blue);
            style.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(182, 215, 168), System.Drawing.Color.Blue);


            var row = 3;
            var count = 1;
            foreach (var registro in datos)
            {

                xlsdocument.SetRowHeight(1, 35.0);
                xlsdocument.SetRowHeight(row, 100.0);
                xlsdocument.SetRowHeight(2, 50.0);

                //xlsdocument.SetWorksheetDefaultRowHeight(100.0);
                xlsdocument.MergeWorksheetCells(1, 1, 1, 3);
                xlsdocument.MergeWorksheetCells(1, 4, 1, 29);
                xlsdocument.SetCellStyle(1, 4, styleBack);
                xlsdocument.SetCellValue(1, 1, "CAMPOS MATRIZ LIQUIDACION FINALIZACION PROYECTOS");
                xlsdocument.SetCellStyle(1, 1, styleBack);
                xlsdocument.SetCellStyle(1, 29, borders);

                xlsdocument.SetCellValue(2, 1, "No. ");
                xlsdocument.SetCellStyle(2, 1, style);
                xlsdocument.SetCellStyle(2, 1, borders);
                xlsdocument.SetColumnWidth("A", 13.0);


                xlsdocument.SetCellValue(2, 2, "Ingresos");
                xlsdocument.SetCellStyle(2, 2, style);
                xlsdocument.SetCellStyle(2, 2, borders);



                xlsdocument.SetCellValue(2, 3, "Pagos");
                xlsdocument.SetCellStyle(2, 3, style);
                xlsdocument.SetCellStyle(2, 3, borders);



                xlsdocument.SetCellValue(2, 4, "Transferencia");
                xlsdocument.SetCellStyle(2, 4, style);
                xlsdocument.SetCellStyle(2, 4, borders);



                xlsdocument.SetCellValue(2, 5, "Liquidacion interna hermes");
                xlsdocument.SetCellStyle(2, 5, style);
                xlsdocument.SetCellStyle(2, 5, borders);



                xlsdocument.SetCellValue(2, 6, "Resumen Estado");
                xlsdocument.SetCellStyle(2, 6, style);
                xlsdocument.SetCellStyle(2, 6, borders);



                xlsdocument.SetCellValue(2, 7, "Nombre Proyecto");
                xlsdocument.SetCellStyle(2, 7, style);
                xlsdocument.SetCellStyle(2, 7, borders);



                xlsdocument.SetCellValue(2, 8, "Fecha fin Contrato Asistente");
                xlsdocument.SetCellStyle(2, 8, style);
                xlsdocument.SetCellStyle(2, 8, borders);



                xlsdocument.SetCellValue(2, 9, "Numero Ordenes hermes");
                xlsdocument.SetCellStyle(2, 9, style);
                xlsdocument.SetCellStyle(2, 9, borders);


                xlsdocument.SetCellValue(2, 10, "Matriz Ejecucion");
                xlsdocument.SetCellStyle(2, 10, style);
                xlsdocument.SetCellStyle(2, 10, borders);


                xlsdocument.SetCellValue(2, 11, "Transferencias Cope");
                xlsdocument.SetCellStyle(2, 11, style);
                xlsdocument.SetCellStyle(2, 11, borders);


                xlsdocument.SetCellValue(2, 12, "balfifinalfirmado");
                xlsdocument.SetCellStyle(2, 12, style);
                xlsdocument.SetCellStyle(2, 12, borders);


                xlsdocument.SetCellValue(2, 13, "subproyectofinhermes");
                xlsdocument.SetCellStyle(2, 13, style);
                xlsdocument.SetCellStyle(2, 13, borders);


                xlsdocument.SetCellValue(2, 14, "proacahermesuncompdrive");
                xlsdocument.SetCellStyle(2, 14, style);
                xlsdocument.SetCellStyle(2, 14, borders);


                xlsdocument.SetCellValue(2, 15, "correoinstitucionalproy");
                xlsdocument.SetCellStyle(2, 15, style);
                xlsdocument.SetCellStyle(2, 15, borders);


                xlsdocument.SetCellValue(2, 16, "actaliqentidad");
                xlsdocument.SetCellStyle(2, 16, style);
                xlsdocument.SetCellStyle(2, 16, borders);


                xlsdocument.SetCellValue(2, 17, "entregaarchivoce");
                xlsdocument.SetCellStyle(2, 17, style);
                xlsdocument.SetCellStyle(2, 17, borders);


                xlsdocument.SetCellValue(2, 18, "resolucionliqinterna");
                xlsdocument.SetCellStyle(2, 18, style);
                xlsdocument.SetCellStyle(2, 18, borders);


                xlsdocument.SetCellValue(2, 19, "consecutivos requerimientos");
                xlsdocument.SetCellStyle(2, 19, style);
                xlsdocument.SetCellStyle(2, 19, borders);


                xlsdocument.SetCellValue(2, 20, "Fecha Ultima Revision");
                xlsdocument.SetCellStyle(2, 20, style);
                xlsdocument.SetCellStyle(2, 20, borders);


                xlsdocument.SetCellValue(2, 21, "Nombre");
                xlsdocument.SetCellStyle(2, 21, style);
                xlsdocument.SetCellStyle(2, 21, borders);


                xlsdocument.SetCellValue(2, 22, "estado Contrato");
                xlsdocument.SetCellStyle(2, 22, style);
                xlsdocument.SetCellStyle(2, 22, borders);


                xlsdocument.SetCellValue(2, 23, "Pagos Cumplidos");
                xlsdocument.SetCellStyle(2, 23, style);
                xlsdocument.SetCellStyle(2, 23, borders);


                xlsdocument.SetCellValue(2, 24, "Fecha estado");
                xlsdocument.SetCellStyle(2, 24, style);
                xlsdocument.SetCellStyle(2, 24, borders);


                xlsdocument.SetCellValue(2, 25, "Informe Final");
                xlsdocument.SetCellStyle(2, 25, style);
                xlsdocument.SetCellStyle(2, 25, borders);


                xlsdocument.SetCellValue(2, 26, "Informe Final Enlace");
                xlsdocument.SetCellStyle(2, 26, style);
                xlsdocument.SetCellStyle(2, 26, borders);


                xlsdocument.SetCellValue(2, 27, "Observaciones");
                xlsdocument.SetCellStyle(2, 27, style);
                xlsdocument.SetCellStyle(2, 27, borders);


                xlsdocument.SetCellValue(2, 28, "producto Academico enlace");
                xlsdocument.SetCellStyle(2, 28, style);
                xlsdocument.SetCellStyle(2, 28, borders);


                xlsdocument.SetCellValue(2, 29, "Actaliqentidadenlace");
                xlsdocument.SetCellStyle(2, 29, style);
                xlsdocument.SetCellStyle(2, 29, borders);




                xlsdocument.SetCellValue(row, 1, count);
                xlsdocument.SetCellStyle(row, 1, borders);
                xlsdocument.SetCellStyle(row, 1, textCenter);

                xlsdocument.SetCellValue(row, 2, registro.ingresos);
                xlsdocument.SetCellStyle(row, 2, borders);


                xlsdocument.SetCellValue(row, 3, registro.pagos);
                xlsdocument.SetCellStyle(row, 3, borders);


                xlsdocument.SetCellValue(row, 4, registro.transferencias);
                xlsdocument.SetCellStyle(row, 4, borders);


                xlsdocument.SetCellValue(row, 5, registro.liquidacioninternahermes);
                xlsdocument.SetCellStyle(row, 5, borders);


                xlsdocument.SetCellValue(row, 6, registro.resumenestado);
                xlsdocument.SetCellStyle(row, 6, borders);


                xlsdocument.SetCellValue(row, 7, registro.nombreproyecto);
                xlsdocument.SetCellStyle(row, 7, borders);


                if (registro.fechafincontratoasistente != null)
                    xlsdocument.SetCellValue(row, 8, ((DateTime)registro.fechafincontratoasistente).ToString());
                xlsdocument.SetCellStyle(row, 8, borders);


                xlsdocument.SetCellValue(row, 9, registro.ordenesnumhermes);
                xlsdocument.SetCellStyle(row, 9, borders);


                xlsdocument.SetCellValue(row, 10, registro.matrizsegejecucion);
                xlsdocument.SetCellStyle(row, 10, borders);


                xlsdocument.SetCellValue(row, 11, registro.transferenciascope);
                xlsdocument.SetCellStyle(row, 11, borders);


                xlsdocument.SetCellValue(row, 12, registro.balfifinalfirmado);
                xlsdocument.SetCellStyle(row, 12, borders);


                xlsdocument.SetCellValue(row, 13, registro.subproyectofinhermes);
                xlsdocument.SetCellStyle(row, 13, borders);


                xlsdocument.SetCellValue(row, 14, registro.proacahermesuncompdrive);
                xlsdocument.SetCellStyle(row, 14, borders);


                xlsdocument.SetCellValue(row, 15, registro.correoinstitucionalproy);
                xlsdocument.SetCellStyle(row, 15, borders);


                xlsdocument.SetCellValue(row, 16, registro.actaliqentidadenlace);
                xlsdocument.SetCellStyle(row, 16, borders);


                xlsdocument.SetCellValue(row, 17, registro.entregaarchivoce);
                xlsdocument.SetCellStyle(row, 17, borders);


                xlsdocument.SetCellValue(row, 18, registro.resolucionliqinterna);
                xlsdocument.SetCellStyle(row, 18, borders);


                xlsdocument.SetCellValue(row, 19, registro.consecutivosrequerimientos);
                xlsdocument.SetCellStyle(row, 19, borders);


                xlsdocument.SetCellValue(row, 20, registro.nombresapell);
                xlsdocument.SetCellStyle(row, 20, borders);


                xlsdocument.SetCellValue(row, 21, registro.estadocontrato);
                xlsdocument.SetCellStyle(row, 21, borders);


                xlsdocument.SetCellValue(row, 22, registro.pagoscumplidos);
                xlsdocument.SetCellStyle(row, 22, borders);


                if (registro.fechaestado != null)
                    xlsdocument.SetCellValue(row, 23, ((DateTime)registro.fechaestado).ToString());
                xlsdocument.SetCellStyle(row, 23, borders);


                xlsdocument.SetCellValue(row, 24, registro.informefinal);
                xlsdocument.SetCellStyle(row, 24, borders);


                xlsdocument.SetCellValue(row, 25, registro.informefinalenlace);
                xlsdocument.SetCellStyle(row, 25, borders);


                xlsdocument.SetCellValue(row, 26, registro.observaciones);
                xlsdocument.SetCellStyle(row, 26, borders);


                xlsdocument.SetCellValue(row, 27, registro.productoacademicoenlace);
                xlsdocument.SetCellStyle(row, 27, borders);


                xlsdocument.SetCellValue(row, 28, registro.actaliqentidadenlace);
                xlsdocument.SetCellStyle(row, 28, borders);
                xlsdocument.AutoFitColumn(1, 29);
                xlsdocument.SetColumnWidth("C1", 45.0);

                row++;
                count++;
            }
            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }
        public string ExcelMatrizAsignacionProyectos()
        {
            var archivoreturn = "/Export/EXCELMATRIZASIGNACIONPROYECTOS_" + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/EXCELMATRIZASIGNACIONPROYECTOS_" + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/EXCELMATRIZ_ASIGNACIONPROYECTOS_.xlsx");
            SLDocument xlsdocument = new SLDocument(plantilla);

            string qry = "select ap.yearsuscripcion, np.naturalezaproyecto, ap.nombreproyecto, ap.poblacionobjetivo, ap.numcontratoconvenio, ap.yearsejecucion, ap.plazoejecucion, ap.fecacuerdovoluntades, ap.fecactainicio, ap.fecterminacion, ap.fichaquipu, ap.codigohermes, ap.numeromodificaciones, ap.objetocontratoactividad, py.alcanceproyecto, ap.valinicialaporteentidad, ap.adiciondisminucion, ap.contrapartida, ap.valortotal, aa.nmaacad, ap.nestudiantesderecho, ap.nestudiantespolitica, ap.nestudiantespostgrados, ap.numerosar, ap.numeroodsops, ec.estadocontrato, ap.consecutivo, pe.razonsocial,concat(di.nombres, ' ', di.apellidos), concat(sr.nombres, ' ', sr.apellidos), concat(tt.nombres, ' ', tt.apellidos), ap.idregistrorup, ap.idarchivoentrega, ap.contratoconvenioenlace, ap.entregaarchivoenlace, pp.nmpropuesta,  ap.aportefacultad, ap.aportevir, ap.aportedieb, ap.aprobadoconvenio, tp.nmtipopropuesta from proyectos_asignacionproyecto ap join proyectos_naturalezaproyecto np on ap.id_naturalezaproyecto = np.id_naturalezaproyecto join proyectos_alcanceproyecto py on ap.id_alcanceproyecto = py.id_alcanceproyecto join area_academica aa on ap.id_areaacad = aa.id_areaacad join proyectos_estadocontrato ec on ap.id_estadocontrato = ec.id_estadocontrato join propuesta_entidad pe on ap.idpropuesta_entidad = pe.idpropuesta_entidad join funcionario di on ap.iddirector = di.idfuncionario join funcionario sr on ap.idsupervisor = sr.idfuncionario join funcionario tt on ap.idasistente = tt.idfuncionario join propuesta pp on ap.id_propuesta = pp.id_propuesta join propuesta_tipopropuesta tp on ap.id_tipopropuesta = tp.id_tipopropuesta group by ap.yearsuscripcion, np.naturalezaproyecto, ap.nombreproyecto, ap.poblacionobjetivo, ap.numcontratoconvenio, ap.yearsejecucion, ap.plazoejecucion, ap.fecacuerdovoluntades, ap.fecactainicio, ap.fecterminacion, ap.fichaquipu, ap.codigohermes, ap.numeromodificaciones, ap.objetocontratoactividad, py.alcanceproyecto, ap.valinicialaporteentidad, ap.adiciondisminucion, ap.contrapartida, ap.valortotal, aa.nmaacad, ap.nestudiantesderecho, ap.nestudiantespolitica, ap.nestudiantespostgrados, ap.numerosar, ap.numeroodsops, ec.estadocontrato, ap.consecutivo, pe.razonsocial,concat(di.nombres, ' ', di.apellidos), concat(sr.nombres, ' ', sr.apellidos), concat(tt.nombres, ' ', tt.apellidos), ap.idregistrorup, ap.idarchivoentrega, ap.contratoconvenioenlace, ap.entregaarchivoenlace, pp.nmpropuesta,  ap.aportefacultad, ap.aportevir, ap.aportedieb, ap.aprobadoconvenio, tp.nmtipopropuesta";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            NpgsqlParameter[] Param = parameterList.ToArray();
            var datos = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry, Param).ToList();

            int filaxls = 4;
            int filaxls2 = 13;
            int filaxls3 = 60;
            string celdaxls = "";

            SLStyle style = xlsdocument.CreateStyle();
            SLStyle borders = xlsdocument.CreateStyle();
            borders.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.LeftBorder.Color = System.Drawing.Color.Black;
            borders.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.RightBorder.Color = System.Drawing.Color.Black;
            borders.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.TopBorder.Color = System.Drawing.Color.Black;
            borders.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.BottomBorder.Color = System.Drawing.Color.Black;

            SLStyle headers = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            SLStyle styleYellow = xlsdocument.CreateStyle();
            SLStyle textCenter = xlsdocument.CreateStyle();

            textCenter.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            textCenter.Alignment.Vertical = VerticalAlignmentValues.Center;
            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            style.Font.Bold = true;
            styleBack.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            styleBack.Alignment.Vertical = VerticalAlignmentValues.Center;
            styleBack.Font.Bold = true;
            //            style.SetWrapText(true);
            //style.Alignment.JustifyLastLine = true;
            //style.Alignment.ShrinkToFit = true;
            styleYellow.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(255, 255, 0), System.Drawing.Color.Blue);
            styleBack.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(207, 226, 243), System.Drawing.Color.Blue);
            headers.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(182, 215, 168), System.Drawing.Color.Blue);
            style.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(182, 215, 168), System.Drawing.Color.Blue);
            var row = 3;
            var count = 1;

            foreach (var registro in datos)
            {
                xlsdocument.SetRowHeight(1, 35.0);
                xlsdocument.SetRowHeight(row, 100.0);
                xlsdocument.SetRowHeight(2, 50.0);
                xlsdocument.MergeWorksheetCells(1, 4, 1, 42);
                //xlsdocument.SetWorksheetDefaultRowHeight(100.0);
                xlsdocument.MergeWorksheetCells(1, 1, 1, 3);
                //xlsdocument.SetWorksheetDefaultRowHeight(50.5);
                xlsdocument.AutoFitColumn(1, 42);
                xlsdocument.MergeWorksheetCells(1, 1, 1, 42);
                xlsdocument.SetCellValue(1, 1, "CAMPOS MATRIZ ASIGNACION PROYECTO");
                xlsdocument.SetCellStyle(1, 1, style);
                xlsdocument.SetCellStyle(1, 1, styleBack);
                xlsdocument.SetCellStyle(1, 4, styleBack);
                xlsdocument.SetCellStyle(1, 1, borders);
                xlsdocument.SetCellValue(2, 1, "No. ");
                xlsdocument.SetCellStyle(2, 1, style);
                xlsdocument.SetCellStyle(2, 1, borders);

                xlsdocument.SetCellValue(2, 2, "Naturaleza Proyecto");
                xlsdocument.SetCellStyle(2, 2, style);
                xlsdocument.SetCellStyle(2, 2, borders);

                xlsdocument.SetCellValue(2, 3, "Nombre Proyecto");
                xlsdocument.SetCellStyle(2, 3, style);
                xlsdocument.SetCellStyle(2, 3, borders);
                xlsdocument.SetCellStyle(2, 3, styleYellow);


                xlsdocument.SetCellValue(2, 4, "Poblacion Objetivo");
                xlsdocument.SetCellStyle(2, 4, style);
                xlsdocument.SetCellStyle(2, 4, borders);

                xlsdocument.SetCellValue(2, 5, "Numero de contrato convenio");
                xlsdocument.SetCellStyle(2, 5, style);
                xlsdocument.SetCellStyle(2, 5, borders);

                xlsdocument.SetCellValue(2, 6, "Año Ejecucion");
                xlsdocument.SetCellStyle(2, 6, style);
                xlsdocument.SetCellStyle(2, 6, borders);

                xlsdocument.SetCellValue(2, 7, "Plazo Ejecucion");
                xlsdocument.SetCellStyle(2, 7, style);
                xlsdocument.SetCellStyle(2, 7, borders);

                xlsdocument.SetCellValue(2, 8, "Fecha Acuerdo Voluntades");
                xlsdocument.SetCellStyle(2, 8, style);
                xlsdocument.SetCellStyle(2, 8, borders);

                xlsdocument.SetCellValue(2, 9, "Fecha Acta Inicio");
                xlsdocument.SetCellStyle(2, 9, style);
                xlsdocument.SetCellStyle(2, 9, borders);

                xlsdocument.SetCellValue(2, 10, "Fecha Terminacion");
                xlsdocument.SetCellStyle(2, 10, style);
                xlsdocument.SetCellStyle(2, 10, borders);

                xlsdocument.SetCellValue(2, 11, "Ficha quipu");
                xlsdocument.SetCellStyle(2, 11, style);
                xlsdocument.SetCellStyle(2, 11, borders);

                xlsdocument.SetCellValue(2, 12, "Codigo Hermes");
                xlsdocument.SetCellStyle(2, 12, style);
                xlsdocument.SetCellStyle(2, 12, borders);

                xlsdocument.SetCellValue(2, 13, "Numero Modificaciones");
                xlsdocument.SetCellStyle(2, 13, style);
                xlsdocument.SetCellStyle(2, 13, borders);

                xlsdocument.SetCellValue(2, 14, "Objeto Contrato Actividad");
                xlsdocument.SetCellStyle(2, 14, style);
                xlsdocument.SetCellStyle(2, 14, borders);

                xlsdocument.SetCellValue(2, 15, "Alcance Proyecto");
                xlsdocument.SetCellStyle(2, 15, style);
                xlsdocument.SetCellStyle(2, 15, borders);

                xlsdocument.SetCellValue(2, 16, "Valor Inicial Aporte Entidad");
                xlsdocument.SetCellStyle(2, 16, style);
                xlsdocument.SetCellStyle(2, 16, borders);

                xlsdocument.SetCellValue(2, 17, "Adicion Disminucion ");
                xlsdocument.SetCellStyle(2, 17, style);
                xlsdocument.SetCellStyle(2, 17, borders);

                xlsdocument.SetCellValue(2, 18, "Contrapartida");
                xlsdocument.SetCellStyle(2, 18, style);
                xlsdocument.SetCellStyle(2, 18, borders);

                xlsdocument.SetCellValue(2, 19, "Valor Total");
                xlsdocument.SetCellStyle(2, 19, style);
                xlsdocument.SetCellStyle(2, 19, borders);

                xlsdocument.SetCellValue(2, 20, "Nombre Area Académica");
                xlsdocument.SetCellStyle(2, 20, style);
                xlsdocument.SetCellStyle(2, 20, borders);

                xlsdocument.SetCellValue(2, 21, "Numero Estudiantes Derecho");
                xlsdocument.SetCellStyle(2, 21, style);
                xlsdocument.SetCellStyle(2, 21, borders);

                xlsdocument.SetCellValue(2, 22, "Numero Estudiantes Politica");
                xlsdocument.SetCellStyle(2, 22, style);
                xlsdocument.SetCellStyle(2, 22, borders);

                xlsdocument.SetCellValue(2, 23, "Numero Estudiantes Postgrado");
                xlsdocument.SetCellStyle(2, 23, style);
                xlsdocument.SetCellStyle(2, 23, borders);

                xlsdocument.SetCellValue(2, 24, "Numerosar");
                xlsdocument.SetCellStyle(2, 24, style);
                xlsdocument.SetCellStyle(2, 24, borders);

                xlsdocument.SetCellValue(2, 25, "Numeroodsops");
                xlsdocument.SetCellStyle(2, 25, style);
                xlsdocument.SetCellStyle(2, 25, borders);

                xlsdocument.SetCellValue(2, 26, "Estado Contrato");
                xlsdocument.SetCellStyle(2, 26, style);
                xlsdocument.SetCellStyle(2, 26, borders);

                xlsdocument.SetCellValue(2, 27, "Consecutivo");
                xlsdocument.SetCellStyle(2, 27, style);
                xlsdocument.SetCellStyle(2, 27, borders);

                xlsdocument.SetCellValue(2, 28, "Razon Social");
                xlsdocument.SetCellStyle(2, 28, style);
                xlsdocument.SetCellStyle(2, 28, borders);

                xlsdocument.SetCellValue(2, 29, "Director");
                xlsdocument.SetCellStyle(2, 29, style);
                xlsdocument.SetCellStyle(2, 29, borders);

                xlsdocument.SetCellValue(2, 30, "Supervisor");
                xlsdocument.SetCellStyle(2, 30, style);
                xlsdocument.SetCellStyle(2, 30, borders);

                xlsdocument.SetCellValue(2, 31, "Asistente");
                xlsdocument.SetCellStyle(2, 31, style);
                xlsdocument.SetCellStyle(2, 31, borders);

                xlsdocument.SetCellValue(2, 32, "ID registro URP");
                xlsdocument.SetCellStyle(2, 32, style);
                xlsdocument.SetCellStyle(2, 32, borders);
                xlsdocument.SetCellValue(2, 33, "ID Archivo Entrega");
                xlsdocument.SetCellStyle(2, 33, style);
                xlsdocument.SetCellStyle(2, 33, borders);
                xlsdocument.SetCellValue(2, 34, "Contrato Convenio enlace");
                xlsdocument.SetCellStyle(2, 34, style);
                xlsdocument.SetCellStyle(2, 34, borders);
                xlsdocument.SetCellValue(2, 35, "Entrega Archivo Enlace");
                xlsdocument.SetCellStyle(2, 35, style);
                xlsdocument.SetCellStyle(2, 35, borders);
                xlsdocument.SetCellValue(2, 36, "Nombre Propuesta");
                xlsdocument.SetCellStyle(2, 36, style);
                xlsdocument.SetCellStyle(2, 36, borders);
                xlsdocument.SetCellValue(2, 37, "Aporte Facultad");
                xlsdocument.SetCellStyle(2, 37, style);
                xlsdocument.SetCellStyle(2, 37, borders);
                xlsdocument.SetCellValue(2, 38, "Aporte VIR");
                xlsdocument.SetCellStyle(2, 38, style);
                xlsdocument.SetCellStyle(2, 38, borders);
                xlsdocument.SetCellValue(2, 39, "Aporte DIEB");
                xlsdocument.SetCellStyle(2, 39, style);
                xlsdocument.SetCellStyle(2, 39, borders);
                xlsdocument.SetCellValue(2, 40, "Aprobado Convenio");
                xlsdocument.SetCellStyle(2, 40, style);
                xlsdocument.SetCellStyle(2, 40, borders);
                xlsdocument.SetCellValue(2, 41, "Tipo Propuesta");
                xlsdocument.SetCellStyle(2, 41, style);
                xlsdocument.SetCellStyle(2, 41, borders);
                xlsdocument.SetCellValue(2, 42, "Año de subscripcion");
                xlsdocument.SetCellStyle(2, 42, style);
                xlsdocument.SetCellStyle(2, 42, borders);



                //xlsdocument.MergeWorksheetCells(26, 2, 26, 8);

                xlsdocument.SetCellValue(row, 1, count);
                xlsdocument.SetCellStyle(row, 1, borders);
                xlsdocument.SetCellStyle(row, 1, textCenter);
                xlsdocument.SetColumnWidth("A", 13.0);

                //xlsdocument.MergeWorksheetCells(27, 2, 27, 8);*/

                xlsdocument.SetCellValue(row, 2, registro.naturalezaproyecto);
                xlsdocument.SetCellStyle(row, 2, borders);

                xlsdocument.SetCellValue(row, 3, registro.nombreproyecto);
                xlsdocument.SetCellStyle(row, 3, borders);
                //xlsdocument.MergeWorksheetCells(29, 2, 29, 8);

                xlsdocument.SetCellValue(row, 4, registro.poblacionobjetivo);
                xlsdocument.SetCellStyle(row, 4, borders);
                //xlsdocument.MergeWorksheetCells(30, 2, 30, 8);

                xlsdocument.SetCellValue(row, 5, registro.numcontratoconvenio);
                xlsdocument.SetCellStyle(row, 5, borders);
                //xlsdocument.MergeWorksheetCells(31, 2, 31, 8);



                xlsdocument.SetCellValue(row, 6, registro.yearsejecucion);
                xlsdocument.SetCellStyle(row, 6, borders);
                //xlsdocument.MergeWorksheetCells(32, 2, 32, 8);

                xlsdocument.SetCellValue(row, 7, registro.plazoejecucion);
                xlsdocument.SetCellStyle(row, 7, borders);
                //xlsdocument.MergeWorksheetCells(33, 2, 33, 8);

                if (registro.fecacuerdovoluntades != null)
                    xlsdocument.SetCellValue(row, 8, ((DateTime)registro.fecacuerdovoluntades).ToString());
                xlsdocument.SetCellStyle(row, 8, borders);
                //xlsdocument.MergeWorksheetCells(34, 2, 34, 8);

                if (registro.fecactainicio != null)

                    xlsdocument.SetCellValue(row, 9, ((DateTime)registro.fecactainicio).ToString());
                xlsdocument.SetCellStyle(row, 9, borders);
                //xlsdocument.MergeWorksheetCells(35, 2, 35, 8);

                if (registro.fecterminacion != null)
                    xlsdocument.SetCellValue(row, 10, ((DateTime)registro.fecterminacion).ToString());
                xlsdocument.SetCellStyle(row, 10, borders);
                //xlsdocument.MergeWorksheetCells(36, 2, 36, 8);

                xlsdocument.SetCellValue(row, 11, registro.fichaquipu);
                xlsdocument.SetCellStyle(row, 11, borders);
                //xlsdocument.MergeWorksheetCells(37, 2, 37, 8);

                xlsdocument.SetCellValue(row, 12, registro.codigohermes);
                xlsdocument.SetCellStyle(row, 12, borders);
                //xlsdocument.MergeWorksheetCells(38, 2, 38, 8);

                xlsdocument.SetCellValue(row, 13, registro.numeromodificaciones);
                xlsdocument.SetCellStyle(row, 13, borders);
                //xlsdocument.MergeWorksheetCells(39, 2, 39, 8);

                xlsdocument.SetCellValue(row, 14, registro.objetocontratoactividad);
                xlsdocument.SetCellStyle(row, 14, borders);
                //xlsdocument.MergeWorksheetCells(40, 2, 40, 8);

                xlsdocument.SetCellValue(row, 15, registro.alcanceproyecto);
                xlsdocument.SetCellStyle(row, 15, borders);
                //xlsdocument.MergeWorksheetCells(41, 2, 41, 8);

                xlsdocument.SetCellValue(row, 16, registro.valinicialaporteentidad);
                xlsdocument.SetCellStyle(row, 16, borders);
                //xlsdocument.MergeWorksheetCells(42, 2, 42, 8);

                xlsdocument.SetCellValue(row, 17, registro.adiciondisminucion);
                xlsdocument.SetCellStyle(row, 17, borders);
                //xlsdocument.MergeWorksheetCells(43, 2, 43, 8);

                xlsdocument.SetCellValue(row, 18, registro.contrapartida);
                xlsdocument.SetCellStyle(row, 18, borders);
                //xlsdocument.MergeWorksheetCells(44, 2, 44, 8);

                if (registro.valortotal != null)
                    xlsdocument.SetCellValue(row, 19, (int)registro.valortotal);
                xlsdocument.SetCellStyle(row, 19, borders);
                //xlsdocument.MergeWorksheetCells(45, 2, 45, 8);

                xlsdocument.SetCellValue(row, 20, registro.nmaacad);
                xlsdocument.SetCellStyle(row, 20, borders);
                //xlsdocument.MergeWorksheetCells(46, 2, 46, 8);

                xlsdocument.SetCellValue(row, 21, registro.nestudiantesderecho);
                xlsdocument.SetCellStyle(row, 21, borders);
                //xlsdocument.MergeWorksheetCells(47, 2, 47, 8);

                xlsdocument.SetCellValue(row, 22, registro.nestudiantespolitica);
                xlsdocument.SetCellStyle(row, 22, borders);
                ///xlsdocument.MergeWorksheetCells(48, 2, 48, 8);

                xlsdocument.SetCellValue(row, 23, registro.nestudiantespostgrados);
                xlsdocument.SetCellStyle(row, 23, borders);
                //xlsdocument.MergeWorksheetCells(49, 2, 49, 8);

                xlsdocument.SetCellValue(row, 24, registro.numerosar);
                xlsdocument.SetCellStyle(row, 24, borders);
                //xlsdocument.MergeWorksheetCells(50, 2, 50, 8);

                xlsdocument.SetCellValue(row, 25, registro.numeroodsops);
                xlsdocument.SetCellStyle(row, 25, borders);

                xlsdocument.SetCellValue(row, 26, registro.estadocontrato);
                xlsdocument.SetCellStyle(row, 26, borders);


                xlsdocument.SetCellValue(row, 27, registro.consecutivo);
                xlsdocument.SetCellStyle(row, 27, borders);


                xlsdocument.SetCellValue(row, 28, registro.razonsocial);
                xlsdocument.SetCellStyle(row, 28, borders);

                xlsdocument.SetCellValue(row, 29, registro.director);
                xlsdocument.SetCellStyle(row, 29, borders);

                xlsdocument.SetCellValue(row, 30, registro.supervisor);
                xlsdocument.SetCellStyle(row, 30, borders);

                xlsdocument.SetCellValue(row, 31, registro.asistente);
                xlsdocument.SetCellStyle(row, 31, borders);

                if (registro.idregistrorup != null)
                    xlsdocument.SetCellValue(row, 32, (int)registro.idregistrorup);
                xlsdocument.SetCellStyle(row, 32, borders);

                if (registro.idarchivoentrega != null)
                    xlsdocument.SetCellValue(row, 33, (int)registro.idarchivoentrega);
                xlsdocument.SetCellStyle(row, 33, borders);


                xlsdocument.SetCellValue(row, 34, registro.contratoconvenioenlace);
                xlsdocument.SetCellStyle(row, 34, borders);

                xlsdocument.SetCellValue(row, 35, registro.entregaarchivoenlace);
                xlsdocument.SetCellStyle(row, 35, borders);


                xlsdocument.SetCellValue(row, 36, registro.nmpropuesta);
                xlsdocument.SetCellStyle(row, 36, borders);

                if (registro.aportefacultad != null)
                    xlsdocument.SetCellValue(row, 37, (int)registro.aportefacultad);
                xlsdocument.SetCellStyle(row, 37, borders);

                if (registro.aportevir != null)
                    xlsdocument.SetCellValue(row, 38, (int)registro.aportevir);
                xlsdocument.SetCellStyle(row, 38, borders);

                if (registro.aportedieb != null)
                    xlsdocument.SetCellValue(row, 39, (int)registro.aportedieb);
                xlsdocument.SetCellStyle(row, 39, borders);

                if (registro.aprobadoconvenio != null)
                    xlsdocument.SetCellValue(row, 40, (int)registro.aprobadoconvenio);
                xlsdocument.SetCellStyle(row, 40, borders);

                xlsdocument.SetCellValue(row, 41, registro.nmtipopropuesta);
                xlsdocument.SetCellStyle(row, 41, borders);
                if (registro.yearsuscripcion != null)
                    xlsdocument.SetCellValue(row, 42, ((DateTime)registro.yearsuscripcion).ToString());
                xlsdocument.SetCellStyle(row, 42, borders);
                count++;
                row++;
            }
            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }
        public string ExcelMatrizConoPropuestas()
        {
            var archivoreturn = "/Export/EXCELMATRIZCONOPROPUESTAS_" + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/EXCELMATRIZCONOPROPUESTAS_" + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/EXCELMATRIZCONO_PROPUESTAS_.xlsx");
            SLDocument xlsdocument = new SLDocument(plantilla);

            string qry8 = "select pp.consecutivooferta, pp.nmpropuesta, pp.fecrad, pp.valorinicialpropuesta, pm.nmmodalidad, op.nmorigenpropuesta, tp.nmtipopropuesta, ep.nmestadopropuesta, concat(fn.nombres, ' ', fn.apellidos) as nombresapell, tu.nmpropuestatipousuario, razonsocial, pp.oficioaprobacion, pp.actaaprobacion, pp.oficioaprobenlace, pp.actaaprobenlace FROM propuesta pp join propuesta_modalidad pm on pp.id_modalidad = pm.id_modalidad join propuesta_origenpropuesta op on pp.id_origenpropuesta = op.id_origenpropuesta join propuesta_tipopropuesta tp on pp.id_tipopropuesta = tp.id_tipopropuesta join propuesta_estadopropuesta ep on pp.id_estadopropuesta = ep.id_estadopropuesta join funcionario fn on pp.idfuncionario = fn.idfuncionario join propuesta_tipousuario tu on pp.id_propuestatipousuario = tu.id_propuestatipousuario join propuesta_entidad pe on pp.idpropuesta_entidad = pe.idpropuesta_entidad group by pp.consecutivooferta, pp.nmpropuesta, pp.fecrad, pp.valorinicialpropuesta, pm.nmmodalidad, op.nmorigenpropuesta, tp.nmtipopropuesta, ep.nmestadopropuesta, concat(fn.nombres, ' ', fn.apellidos), tu.nmpropuestatipousuario, razonsocial, pp.oficioaprobacion, pp.actaaprobacion, pp.oficioaprobenlace, pp.actaaprobenlace";

            List<NpgsqlParameter> parameterList8 = new List<NpgsqlParameter>();
            NpgsqlParameter[] Param8 = parameterList8.ToArray();
            var datos8 = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry8, Param8).ToList();

            int filaxls = 4;
            int filaxls2 = 13;
            int filaxls3 = 60;
            string celdaxls = "";

            SLStyle style = xlsdocument.CreateStyle();
            SLStyle borders = xlsdocument.CreateStyle();
            borders.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.LeftBorder.Color = System.Drawing.Color.Black;
            borders.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.RightBorder.Color = System.Drawing.Color.Black;
            borders.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.TopBorder.Color = System.Drawing.Color.Black;
            borders.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            borders.Border.BottomBorder.Color = System.Drawing.Color.Black;

            SLStyle headers = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            SLStyle styleYellow = xlsdocument.CreateStyle();
            SLStyle textCenter = xlsdocument.CreateStyle();

            textCenter.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            textCenter.Alignment.Vertical = VerticalAlignmentValues.Center;
            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            style.Font.Bold = true;
            styleBack.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            styleBack.Alignment.Vertical = VerticalAlignmentValues.Center;
            styleBack.Font.Bold = true;
            //            style.SetWrapText(true);
            //style.Alignment.JustifyLastLine = true;
            //style.Alignment.ShrinkToFit = true;
            styleYellow.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(255, 255, 0), System.Drawing.Color.Blue);
            styleBack.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(207, 226, 243), System.Drawing.Color.Blue);
            headers.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(182, 215, 168), System.Drawing.Color.Blue);
            style.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(182, 215, 168), System.Drawing.Color.Blue);


            var row = 3;
            var count = 1;
            foreach (var registro8 in datos8)
            {

                xlsdocument.SetRowHeight(1, 35.0);
                xlsdocument.SetRowHeight(row, 100.0);
                xlsdocument.SetRowHeight(2, 50.0);

                //xlsdocument.SetWorksheetDefaultRowHeight(100.0);
                xlsdocument.MergeWorksheetCells(1, 1, 1, 3);
                xlsdocument.AutoFitColumn(1, 16);
                xlsdocument.MergeWorksheetCells(1, 4, 1, 16);
                xlsdocument.SetCellStyle(1, 4, styleBack);
                xlsdocument.SetCellValue(1, 1, "CAMPOS MATRIZ CONO DE PROPUESTAS");
                xlsdocument.SetCellStyle(1, 1, styleBack);
                xlsdocument.SetCellStyle(1, 15, borders);
                xlsdocument.SetCellValue(2, 1, "NO.");
                xlsdocument.SetCellStyle(2, 1, style);
                xlsdocument.SetCellStyle(2, 1, borders);
                xlsdocument.SetColumnWidth("A", 13.0);
                xlsdocument.SetCellValue(2, 2, "Consecutivo Oferta");
                //xlsdocument.MergeWorksheetCells(3, 3, 4, 3);
                xlsdocument.SetCellStyle(2, 2, style);
                xlsdocument.SetCellStyle(2, 2, styleYellow);
                xlsdocument.SetCellStyle(2, 2, borders);
                xlsdocument.SetCellValue(2, 3, "Nombre de la propuesta");
                //xlsdocument.MergeWorksheetCells(3, 4, 4, 4);
                xlsdocument.SetCellStyle(2, 3, style);
                xlsdocument.SetCellStyle(2, 3, borders);
                xlsdocument.SetCellValue(2, 4, "Fecha creación");
                //xlsdocument.MergeWorksheetCells(3, 5, 4, 5);
                xlsdocument.SetCellStyle(2, 4, style);
                xlsdocument.SetCellStyle(2, 4, borders);
                xlsdocument.SetCellValue(2, 5, "Valor inicial de la propuesta");
                //xlsdocument.MergeWorksheetCells(3, 6, 4, 6);
                xlsdocument.SetCellStyle(2, 5, style);
                xlsdocument.SetCellStyle(2, 5, borders);
                xlsdocument.SetCellValue(2, 6, "Modalidad");
                //xlsdocument.MergeWorksheetCells(3, 7, 4, 7);
                xlsdocument.SetCellStyle(2, 6, style);
                xlsdocument.SetCellStyle(2, 6, borders);
                xlsdocument.SetCellValue(2, 7, "Origen de la Propuesta");
                //xlsdocument.MergeWorksheetCells(3, 8, 4, 8);
                xlsdocument.SetCellStyle(2, 7, style);
                xlsdocument.SetCellStyle(2, 7, borders);
                xlsdocument.SetCellValue(2, 8, "Tipo de Propuesta");
                //xlsdocument.MergeWorksheetCells(3, 9, 4, 9);
                xlsdocument.SetCellStyle(2, 8, style);
                xlsdocument.SetCellStyle(2, 8, borders);
                xlsdocument.SetCellValue(2, 9, "Estado de la Propuesta");
                //xlsdocument.MergeWorksheetCells(3, 10, 4, 10);
                xlsdocument.SetCellStyle(2, 9, style);
                xlsdocument.SetCellStyle(2, 9, borders);
                xlsdocument.SetCellValue(2, 10, "Nombresapll preguntar");
                //xlsdocument.MergeWorksheetCells(3, 11, 4, 11);
                xlsdocument.SetCellStyle(2, 10, style);
                xlsdocument.SetCellStyle(2, 10, borders);
                xlsdocument.SetCellValue(2, 11, "Tipo de Usuario");
                //xlsdocument.MergeWorksheetCells(3, 12, 4, 12);
                xlsdocument.SetCellStyle(2, 11, style);
                xlsdocument.SetCellStyle(2, 11, borders);
                xlsdocument.SetCellValue(2, 12, "Razon Social");
                //xlsdocument.MergeWorksheetCells(3, 13, 4, 13);
                xlsdocument.SetCellStyle(2, 12, style);
                xlsdocument.SetCellStyle(2, 12, borders);
                //xlsdocument.MergeWorksheetCells(3, 14, 4, 14);
                xlsdocument.SetCellValue(2, 13, "Oficio Aprobacion");
                //xlsdocument.MergeWorksheetCells(3, 15, 4, 15);
                xlsdocument.SetCellStyle(2, 13, style);
                xlsdocument.SetCellStyle(2, 13, borders);
                xlsdocument.SetCellValue(2, 14, "Acta Aprobacion");
                //xlsdocument.MergeWorksheetCells(3, 16, 4, 16);
                xlsdocument.SetCellStyle(2, 14, style);
                xlsdocument.SetCellStyle(2, 14, borders);
                xlsdocument.SetCellValue(2, 15, "oficio aprobenlace");
                //xlsdocument.MergeWorksheetCells(3, 17, 4, 17);
                xlsdocument.SetCellStyle(2, 15, style);
                xlsdocument.SetCellStyle(2, 15, borders);
                xlsdocument.SetCellValue(2, 16, "Acta aprobenlace");
                //xlsdocument.MergeWorksheetCells(3, 17, 4, 17);
                xlsdocument.SetCellStyle(2, 16, style);
                xlsdocument.SetCellStyle(2, 16, borders);
                //xlsdocument.SetCellValue(3, 17, "Activo");
                ////xlsdocument.MergeWorksheetCells(3, 18, 4, 18);
                //xlsdocument.SetCellStyle(18, 2, style);
                //xlsdocument.SetCellValue(3, 18, "ID Funcionario");
                ////xlsdocument.MergeWorksheetCells(3, 19, 4, 19);
                //xlsdocument.SetCellStyle(19, 2, style);
                //xlsdocument.SetCellValue(3, 19, "ID Propuesta Tipo Usuario");
                ////xlsdocument.MergeWorksheetCells(3, 20, 4, 20);
                //xlsdocument.SetCellStyle(20, 2, style);
                //xlsdocument.SetCellValue(3, 20, "Contrato Convenio");
                ////xlsdocument.MergeWorksheetCells(3, 21, 4, 21);
                //xlsdocument.SetCellStyle(21, 2, style);
                //xlsdocument.SetCellValue(3, 21, "ID Propuesta Entidad");
                ////xlsdocument.MergeWorksheetCells(3, 22, 4, 22);
                //xlsdocument.SetCellStyle(22, 2, style);
                //xlsdocument.SetCellValue(3, 22, "ID Acta Consejo Facultad");
                ////xlsdocument.MergeWorksheetCells(3, 23, 4, 23);
                //xlsdocument.SetCellStyle(23, 2, style);
                //xlsdocument.SetCellValue(3, 23, "Oficio Aprobacion");
                ////xlsdocument.MergeWorksheetCells(3, 24, 4, 24);
                //xlsdocument.SetCellStyle(24, 2, style);
                //xlsdocument.SetCellValue(3, 24, "Acta Aprobacion");
                ////xlsdocument.MergeWorksheetCells(3, 25, 4, 25);
                //xlsdocument.SetCellStyle(25, 2, style);
                //xlsdocument.SetCellValue(3, 25, "Oficio Aprobenlace");
                ////xlsdocument.MergeWorksheetCells(3, 26, 4, 26);
                //xlsdocument.SetCellStyle(26, 2, style);
                //xlsdocument.SetCellValue(3, 26, "Acta APROBENLACE");
                ////xlsdocument.MergeWorksheetCells(3, 27, 4, 27);
                //xlsdocument.SetCellStyle(27, 2, style);




                //if (registro8.id_propuesta != null)
                //    xlsdocument.SetCellValue(row, column, (int)registro8.id_propuesta);
                //xlsdocument.SetCellStyle(3, 3, style);
                ////xlsdocument.MergeWorksheetCells(26, 2, 26, 8);
                ///
                xlsdocument.SetCellValue(row, 1, count);
                xlsdocument.SetCellStyle(row, 1, borders);
                xlsdocument.SetCellStyle(row, 1, textCenter);

                if (registro8.consecutivooferta != null)
                {
                    xlsdocument.SetCellValue(row, 2, registro8.consecutivooferta);
                    xlsdocument.SetCellStyle(row, 2, borders);

                }
                //xlsdocument.SetCellStyle(4, 3, style);
                ////xlsdocument.MergeWorksheetCells(27, 2, 27, 8);
                if (registro8.nmpropuesta != null)
                {
                    xlsdocument.SetCellValue(row, 3, registro8.nmpropuesta);
                    xlsdocument.SetCellStyle(row, 3, borders);

                }

                //xlsdocument.SetCellStyle(5, 3, style);

                if (registro8.fecrad != null)
                    xlsdocument.SetCellValue(row, 4, ((DateTime)registro8.fecrad).ToString());
                xlsdocument.SetCellStyle(row, 4, borders);

                //xlsdocument.SetCellStyle(6, 3, style);
                ////xlsdocument.MergeWorksheetCells(29, 2, 29, 8);

                xlsdocument.SetCellValue(row, 5, registro8.valorinicialpropuesta);
                xlsdocument.SetCellStyle(row, 5, borders);

                //xlsdocument.SetCellStyle(7, 3, style);
                ////xlsdocument.MergeWorksheetCells(30, 2, 30, 8);

                xlsdocument.SetCellValue(row, 6, registro8.nmmodalidad);
                xlsdocument.SetCellStyle(row, 6, borders);

                //xlsdocument.SetCellStyle(8, 3, style);
                ////xlsdocument.MergeWorksheetCells(31, 2, 31, 8);

                xlsdocument.SetCellValue(row, 7, registro8.nmorigenpropuesta);
                xlsdocument.SetCellStyle(row, 7, borders);

                //xlsdocument.SetCellStyle(9, 3, style);
                ////xlsdocument.MergeWorksheetCells(32, 2, 32, 8);

                xlsdocument.SetCellValue(row, 8, registro8.nmtipopropuesta);
                xlsdocument.SetCellStyle(row, 8, borders);

                //xlsdocument.SetCellStyle(10, 3, style);
                ////xlsdocument.MergeWorksheetCells(33, 2, 33, 8);


                if (registro8.nmestadopropuesta != null)
                    xlsdocument.SetCellValue(row, 9, registro8.nmestadopropuesta);
                xlsdocument.SetCellStyle(row, 9, borders);


                //xlsdocument.SetCellStyle(11, 3, style);
                ////xlsdocument.MergeWorksheetCells(34, 2, 34, 8);

                xlsdocument.SetCellValue(row, 10, registro8.nombresapell);
                xlsdocument.SetCellStyle(row, 10, borders);

                //xlsdocument.SetCellStyle(12, 3, style);
                ////xlsdocument.MergeWorksheetCells(35, 2, 35, 8);

                if (registro8.nmpropuestatipousuario != null)
                    xlsdocument.SetCellValue(row, 11, registro8.nmpropuestatipousuario);
                xlsdocument.SetCellStyle(row, 11, borders);

                //xlsdocument.SetCellStyle(13, 3, style);
                ////xlsdocument.MergeWorksheetCells(36, 2, 36, 8);

                //xlsdocument.SetCellStyle(14, 3, style);
                ////xlsdocument.MergeWorksheetCells(37, 2, 37, 8);

                xlsdocument.SetCellValue(row, 12, registro8.razonsocial);
                xlsdocument.SetCellStyle(row, 12, borders);

                //xlsdocument.SetCellStyle(15, 3, style);
                ////xlsdocument.MergeWorksheetCells(38, 2, 38, 8);

                //xlsdocument.SetCellStyle(16, 3, style);
                ////xlsdocument.MergeWorksheetCells(39, 2, 39, 8);

                xlsdocument.SetCellValue(row, 13, registro8.oficioaprobacion);
                xlsdocument.SetCellStyle(row, 13, borders);

                //xlsdocument.SetCellStyle(17, 3, style);
                ////xlsdocument.MergeWorksheetCells(40, 2, 40, 8);

                xlsdocument.SetCellValue(row, 14, registro8.actaaprobacion);
                xlsdocument.SetCellStyle(row, 14, borders);

                //xlsdocument.SetCellStyle(18, 3, style);
                ////xlsdocument.MergeWorksheetCells(41, 2, 41, 8);

                xlsdocument.SetCellValue(row, 15, registro8.oficioaprobenlace);
                xlsdocument.SetCellStyle(row, 15, borders);

                //xlsdocument.SetCellStyle(19, 3, style);
                ////xlsdocument.MergeWorksheetCells(42, 2, 42, 8);

                xlsdocument.SetCellValue(row, 16, registro8.actaaprobenlace);
                xlsdocument.SetCellStyle(row, 16, borders);

                //xlsdocument.SetCellStyle(20, 3, style);
                ////xlsdocument.MergeWorksheetCells(43, 2, 43, 8);

                count++;
                row++;
            }
            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }
        public string ExcelProyeccionProximosProyectos()
        {
            var archivoreturn = "/Export/ExcelProyeccionProximosProyectos" + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/ExcelProyeccionProximosProyectos" + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/ExcelProyeccion_ProximosProyectos.xlsx");
            SLDocument xlsdocument = new SLDocument(plantilla);

            string qry10 = "select id_propuesta, nmpropuesta, valorinicialpropuesta, pe.razonsocial from propuesta pr join propuesta_entidad pe on pr.idpropuesta_entidad = pe.idpropuesta_entidad join propuesta_estadopropuesta ep on pr.id_estadopropuesta = ep.id_estadopropuesta where ep.nmestadopropuesta = 'Aprobado' group by id_propuesta, nmpropuesta, valorinicialpropuesta, pe.razonsocial";


            List<NpgsqlParameter> parameterList10 = new List<NpgsqlParameter>();
            NpgsqlParameter[] Param10 = parameterList10.ToArray();
            var datos = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry10, Param10).ToList();

            int filaxls = 4;
            int filaxls2 = 13;
            int filaxls3 = 60;
            string celdaxls = "";

            SLStyle style = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            SLStyle font = xlsdocument.CreateStyle();
            SLStyle titlefont = xlsdocument.CreateStyle();
            SLStyle line = xlsdocument.CreateStyle();
            SLStyle propuestastit = xlsdocument.CreateStyle();
            SLStyle prp = xlsdocument.CreateStyle();
            SLStyle footer = xlsdocument.CreateStyle();
            SLStyle txtfooter = xlsdocument.CreateStyle();




            txtfooter.Font.FontSize = 8.0;


            txtfooter.Font.FontColor = System.Drawing.Color.White;
            txtfooter.Alignment.Vertical = VerticalAlignmentValues.Center;




            prp.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(208, 227, 234), System.Drawing.Color.Blue);
            prp.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            prp.Border.LeftBorder.Color = System.Drawing.Color.White;
            prp.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            prp.Border.RightBorder.Color = System.Drawing.Color.White;
            prp.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            prp.Border.TopBorder.Color = System.Drawing.Color.White;
            prp.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            prp.Border.BottomBorder.Color = System.Drawing.Color.White;
            prp.Font.FontSize = 15.0;
            prp.Font.FontColor = System.Drawing.Color.FromArgb(58, 56, 56);
            prp.Alignment.Vertical = VerticalAlignmentValues.Center;
            prp.Alignment.Horizontal = HorizontalAlignmentValues.Center;


            propuestastit.Font.Bold = true;
            propuestastit.Font.FontSize = 15.0;
            propuestastit.Font.FontColor = System.Drawing.Color.White;
            propuestastit.Alignment.Vertical = VerticalAlignmentValues.Center;
            propuestastit.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            propuestastit.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(75, 172, 198), System.Drawing.Color.Blue);
            propuestastit.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            propuestastit.Border.LeftBorder.Color = System.Drawing.Color.White;
            propuestastit.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            propuestastit.Border.RightBorder.Color = System.Drawing.Color.White;
            propuestastit.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            propuestastit.Border.TopBorder.Color = System.Drawing.Color.White;
            propuestastit.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            propuestastit.Border.BottomBorder.Color = System.Drawing.Color.White;

            titlefont.Font.FontFamily = 1;
            titlefont.Font.FontSize = 18.0;
            titlefont.Font.FontColor = System.Drawing.Color.FromArgb(45, 66, 148);
            font.Font.FontSize = 15.0;
            font.Font.FontFamily = 1;
            font.Font.FontColor = System.Drawing.Color.FromArgb(108, 120, 168);
            font.Alignment.Vertical = VerticalAlignmentValues.Center;

            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            //            style.SetWrapText(true);
            //style.Alignment.JustifyLastLine = true;
            //style.Alignment.ShrinkToFit = true;

            styleBack.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(230, 230, 230), System.Drawing.Color.Blue);
            footer.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(45, 66, 148), System.Drawing.Color.Blue);


            for (var i = 2; i <= 5; i++)
            {
                var b = "B" + i;
                var c = "C" + i;
                var d = "D" + i;
                var e = "E" + i;
                var f = "F" + i;
                var g = "G" + i;
                var h = "H" + i;

                xlsdocument.SetCellStyle(b, styleBack);
                xlsdocument.SetCellStyle(c, styleBack);
                xlsdocument.SetCellStyle(d, styleBack);
                xlsdocument.SetCellStyle(e, styleBack);
                xlsdocument.SetCellStyle(f, styleBack);
                xlsdocument.SetCellStyle(g, styleBack);
                xlsdocument.SetCellStyle(h, styleBack);
            }



            xlsdocument.SetRowHeight(6, 10.0);

            filaxls += 1;
            var sum = 0;
            var row = 6;
            if (datos != null)
            {


                foreach (var registro in datos)
                {

                    xlsdocument.AutoFitColumn(2, 20);
                    xlsdocument.SetCellStyle("B2", "H2", styleBack);

                    var b = "B" + row;
                    var c = "C" + row;
                    var d = "D" + row;
                    var e = "E" + row;
                    var f = "F" + row;
                    var g = "G" + row;
                    var h = "H" + row;
                    var I = "I" + row;

                    xlsdocument.SetCellStyle(b, styleBack);
                    xlsdocument.SetCellStyle(c, styleBack);
                    xlsdocument.SetCellStyle(d, styleBack);
                    xlsdocument.SetCellStyle(e, styleBack);
                    xlsdocument.SetCellStyle(f, styleBack);
                    xlsdocument.SetCellStyle(g, styleBack);
                    xlsdocument.SetCellStyle(h, styleBack);

                    xlsdocument.MergeWorksheetCells(2, 2, 2, 8);
                    xlsdocument.MergeWorksheetCells(3, 2, 3, 8);
                    xlsdocument.SetRowHeight(5, 35.0);

                    xlsdocument.SetRowHeight(2, 25.0);
                    xlsdocument.SetRowHeight(3, 25.0);
                    xlsdocument.SetCellValue(2, 2, "                      PROYECCION PROXIMOS PROYECTOS");
                    xlsdocument.SetCellStyle(2, 2, titlefont);

                    xlsdocument.SetCellValue(3, 2, "                      Información de Matriz Cono de Propuestas");
                    xlsdocument.SetCellStyle(3, 2, font);
                    xlsdocument.SetCellValue(5, 4, "Entidad");
                    xlsdocument.SetCellStyle(5, 4, propuestastit);

                    xlsdocument.SetCellValue(5, 5, "Nombre Propuesta");
                    xlsdocument.SetCellStyle(5, 5, propuestastit);

                    xlsdocument.SetCellValue(5, 6, "Valor inicial Propuesta");
                    xlsdocument.SetCellStyle(5, 6, propuestastit);

                    //xlsdocument.SetCellValue(5, 6, "Estado");
                    //xlsdocument.SetCellStyle(5, 6, propuestastit);

                    //xlsdocument.SetCellValue(5, 7, "Director");
                    //xlsdocument.SetCellStyle(5, 7, propuestastit);

                    xlsdocument.SetRowHeight(row, 35.0);

                    xlsdocument.SetCellValue(row, 4, registro.razonsocial);
                    xlsdocument.SetCellStyle(row, 4, propuestastit);

                    xlsdocument.SetCellValue(row, 5, registro.nmpropuesta);
                    xlsdocument.SetCellStyle(row, 5, prp);

                    xlsdocument.SetCellValue(row, 6, registro.valorinicialpropuesta);
                    xlsdocument.SetCellStyle(row, 6, prp);

                    //xlsdocument.SetCellValue(row, 6, "Falta Estado EN el query");
                    //xlsdocument.SetCellStyle(row, 6, prp);

                    //xlsdocument.SetCellValue(row, 7, "Falta Director EN el query");
                    //xlsdocument.SetCellStyle(row, 7, prp);



                    row++;

                }


                xlsdocument.SetColumnWidth(8, 25.0);
                xlsdocument.MergeWorksheetCells(row, 2, row, 8);
                xlsdocument.MergeWorksheetCells(row + 1, 2, row + 1, 8);
                var foot = "B" + (row + 1);
                var margin = "B" + row;

                xlsdocument.SetCellStyle(margin, styleBack);

                xlsdocument.SetRowHeight(row + 1, 45.0);
                xlsdocument.SetRowHeight(row, 15.0);

                xlsdocument.SetCellStyle(foot, footer);
                xlsdocument.SetCellValue(foot, "      Facultad de Derecho, Ciencias Politicas y Sociales Sede Bogotá" +
                "                                                                                                                        " +
                "Proyecto CULTURAl, CIENTIFICO, y COLECTIVO de Nación ");


                xlsdocument.SetCellStyle(foot, txtfooter);

            }





            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }
        public string ExcelListadoPropuesta()
        {
            var archivoreturn = "/Export/ExcelListadoPropuesta" + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/ExcelListadoPropuesta" + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/ExcelListado_Propuesta.xlsx");
            SLDocument xlsdocument = new SLDocument(plantilla);

            string qry11 = "select pe.razonsocial, count(pr.id_propuesta) as numpropraz from propuesta pr join propuesta_entidad pe on pr.idpropuesta_entidad = pe.idpropuesta_entidad group by pe.razonsocial ";


            List<NpgsqlParameter> parameterList11 = new List<NpgsqlParameter>();
            NpgsqlParameter[] Param11 = parameterList11.ToArray();
            var datos = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry11, Param11).ToList();

            int filaxls = 4;


            SLStyle style = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            SLStyle font = xlsdocument.CreateStyle();
            SLStyle titlefont = xlsdocument.CreateStyle();
            SLStyle propuestastit = xlsdocument.CreateStyle();
            SLStyle footer = xlsdocument.CreateStyle();
            SLStyle txtfooter = xlsdocument.CreateStyle();




            txtfooter.Font.FontSize = 8.0;


            txtfooter.Font.FontColor = System.Drawing.Color.White;
            txtfooter.Alignment.Vertical = VerticalAlignmentValues.Center;





            propuestastit.Font.FontSize = 15.0;
            propuestastit.Font.FontColor = System.Drawing.Color.Gray;
            propuestastit.Alignment.Vertical = VerticalAlignmentValues.Center;

            titlefont.Font.FontFamily = 1;
            titlefont.Font.FontSize = 18.0;
            titlefont.Font.FontColor = System.Drawing.Color.FromArgb(45, 66, 148);
            font.Font.FontSize = 15.0;
            font.Font.FontFamily = 1;
            font.Font.FontColor = System.Drawing.Color.FromArgb(108, 120, 168);
            font.Alignment.Vertical = VerticalAlignmentValues.Center;

            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            //            style.SetWrapText(true);
            //style.Alignment.JustifyLastLine = true;
            //style.Alignment.ShrinkToFit = true;

            styleBack.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(230, 230, 230), System.Drawing.Color.Blue);
            footer.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(45, 66, 148), System.Drawing.Color.Blue);

            for (var i = 2; i <= 7; i++)
            {
                var b = "B" + i;
                var c = "C" + i;
                var d = "D" + i;
                var e = "E" + i;
                var f = "F" + i;
                var g = "G" + i;
                var h = "H" + i;
                xlsdocument.SetCellStyle(b, styleBack);
                xlsdocument.SetCellStyle(c, styleBack);
                xlsdocument.SetCellStyle(d, styleBack);
                xlsdocument.SetCellStyle(e, styleBack);
                xlsdocument.SetCellStyle(f, styleBack);
                xlsdocument.SetCellStyle(g, styleBack);
                xlsdocument.SetCellStyle(h, styleBack);
            }

            xlsdocument.SetRowHeight(6, 10.0);

            filaxls += 1;
            var sum = 0;
            var row = 5;
            if (datos != null)
            {


                foreach (var registro in datos)
                {
                    sum += registro.numpropraz;
                    xlsdocument.AutoFitColumn(1, 8);

                    var b = "B" + row;
                    var c = "C" + row;
                    var d = "D" + row;
                    var e = "E" + row;
                    var f = "F" + row;
                    var g = "G" + row;
                    var h = "H" + row;
                    xlsdocument.SetCellStyle(b, styleBack);
                    xlsdocument.SetCellStyle(c, styleBack);
                    xlsdocument.SetCellStyle(d, styleBack);
                    xlsdocument.SetCellStyle(e, styleBack);
                    xlsdocument.SetCellStyle(f, styleBack);
                    xlsdocument.SetCellStyle(g, styleBack);
                    xlsdocument.SetCellStyle(h, styleBack);



                    xlsdocument.SetRowHeight(2, 25.0);
                    xlsdocument.SetRowHeight(3, 25.0);
                    xlsdocument.SetRowHeight(row, 45.0);
                    xlsdocument.SetCellValue(2, 2, "          LISTADO DE ENTIDADES A LAS QUE SE LES HA ENVIADO PROPUESTA - ");
                    xlsdocument.SetCellStyle(2, 2, titlefont);

                    xlsdocument.SetCellValue(2, 3, sum);
                    xlsdocument.SetCellStyle(2, 3, titlefont);
                    xlsdocument.SetCellValue(2, 4, "propuestas");
                    xlsdocument.SetCellStyle(2, 4, titlefont);
                    xlsdocument.SetCellValue(3, 2, "          Información de Matriz Cono de Propuestas");
                    xlsdocument.SetCellStyle(3, 2, font);

                    xlsdocument.SetCellValue(row, 2, "          ◉ " + registro.razonsocial);
                    xlsdocument.SetCellStyle(row, 2, propuestastit);





                    row++;
                }

                xlsdocument.MergeWorksheetCells(row, 2, row, 8);
                xlsdocument.MergeWorksheetCells(row + 1, 2, row + 1, 8);
                var foot = "B" + (row + 1);
                var margin = "B" + row;

                xlsdocument.SetCellStyle(margin, styleBack);

                xlsdocument.SetRowHeight(row + 1, 45.0);
                xlsdocument.SetRowHeight(row, 15.0);

                xlsdocument.SetCellStyle(foot, footer);
                xlsdocument.SetCellValue(foot, "      Facultad de Derecho, Ciencias Politicas y Sociales Sede Bogotá" +
                "                                                                                                                        " +
                "Proyecto CULTURAl, CIENTIFICO, y COLECTIVO de Nación ");


                xlsdocument.SetCellStyle(foot, txtfooter);

            }





            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }
        public string ExcelBalancePropuestas()
        {
            var archivoreturn = "/Export/ExcelBalancePropuestas" + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/ExcelBalancePropuestas" + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/ExcelBalance_Propuestas.xlsx");

            SLDocument xlsdocument = new SLDocument(plantilla);
            string qry = "select ep.nmestadopropuesta estadopropuesta, count(pr.id_propuesta) totalestadopropuesta " +
                "from propuesta pr join propuesta_estadopropuesta ep on pr.id_estadopropuesta = ep.id_estadopropuesta" +
                " group by ep.nmestadopropuesta ";

            string qry2 = "select md.nmmodalidad modalidadpropuesta, count(pr.id_propuesta) totalmodalidadpropuesta from propuesta pr join propuesta_modalidad md on pr.id_modalidad = md.id_modalidad group by md.nmmodalidad";
            string qry3 = "select tu.nmpropuestatipousuario, count(pr.id_propuesta) as totalportipousuario from propuesta pr join propuesta_tipousuario tu on pr.id_propuestatipousuario = tu.id_propuestatipousuario group by tu.nmpropuestatipousuario";
            string qry4 = "select op.nmorigenpropuesta origenpropuesta, count(pr.id_propuesta) totalorigenpropuesta from propuesta pr join propuesta_origenpropuesta op on pr.id_origenpropuesta = op.id_origenpropuesta group by op.nmorigenpropuesta";


            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            //List<NpgsqlParameter> parameterList7 = new List<NpgsqlParameter>();


            //parameterList7.Add(new NpgsqlParameter("@id_propuesta", id_propuesta));



            NpgsqlParameter[] Param = parameterList.ToArray();
            //NpgsqlParameter[] Param7 = parameterList7.ToArray();



            var datos = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry, Param).ToList();
            var datos2 = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry2, Param).ToList();
            var datos3 = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry3, Param).ToList();
            var datos4 = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry4, Param).ToList();

            //var datos7 = _context.Database.SqlQuery<ProyectosCentroExtensionDTO>(qry7, Param6).ToList();


            int filaxls = 4;
            int filaxls2 = 13;
            int filaxls3 = 60;
            string celdaxls = "";

            SLStyle style = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            SLStyle font = xlsdocument.CreateStyle();
            SLStyle titlefont = xlsdocument.CreateStyle();
            SLStyle line = xlsdocument.CreateStyle();
            SLStyle propuestas = xlsdocument.CreateStyle();
            SLStyle propuestastit = xlsdocument.CreateStyle();
            SLStyle prp = xlsdocument.CreateStyle();
            SLStyle prpBlue = xlsdocument.CreateStyle();
            SLStyle footer = xlsdocument.CreateStyle();
            SLStyle propuestasSb = xlsdocument.CreateStyle();
            SLStyle txtfooter = xlsdocument.CreateStyle();




            txtfooter.Font.FontSize = 8.0;


            txtfooter.Font.FontColor = System.Drawing.Color.White;
            txtfooter.Alignment.Vertical = VerticalAlignmentValues.Center;

            prpBlue.Alignment.Vertical = VerticalAlignmentValues.Top;
            prpBlue.Font.FontSize = 16.0;
            prpBlue.Font.FontColor = System.Drawing.Color.FromArgb(45, 66, 148);

            prp.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            prp.Alignment.Vertical = VerticalAlignmentValues.Top;
            prp.Font.FontSize = 16.0;

            propuestastit.Font.FontSize = 72.0;
            propuestas.Font.FontColor = System.Drawing.Color.Red;
            propuestasSb.Font.FontSize = 26.0;

            propuestasSb.Font.FontColor = System.Drawing.Color.Red;


            line.Border.BottomBorder.Color = System.Drawing.Color.Black;
            line.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            titlefont.Font.FontFamily = 1;
            titlefont.Font.FontSize = 18.0;
            titlefont.Font.FontColor = System.Drawing.Color.FromArgb(45, 66, 148);
            font.Font.FontSize = 15.0;
            font.Font.FontFamily = 1;
            font.Font.FontColor = System.Drawing.Color.FromArgb(108, 120, 168);
            font.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            font.Alignment.Vertical = VerticalAlignmentValues.Top;

            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            //            style.SetWrapText(true);
            //style.Alignment.JustifyLastLine = true;
            //style.Alignment.ShrinkToFit = true;

            styleBack.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(230, 230, 230), System.Drawing.Color.Blue);
            footer.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(45, 66, 148), System.Drawing.Color.Blue);

            for (var i = 2; i <= 7; i++)
            {
                var b = "B" + i;
                var c = "C" + i;
                var d = "D" + i;
                var e = "E" + i;
                var f = "F" + i;
                var g = "G" + i;
                var h = "H" + i;

                xlsdocument.SetCellStyle(b, styleBack);
                xlsdocument.SetCellStyle(c, styleBack);
                xlsdocument.SetCellStyle(d, styleBack);
                xlsdocument.SetCellStyle(e, styleBack);
                xlsdocument.SetCellStyle(f, styleBack);
                xlsdocument.SetCellStyle(g, styleBack);
                xlsdocument.SetCellStyle(h, styleBack);
            }

            xlsdocument.SetRowHeight(6, 10.0);

            filaxls += 1;
            var sum = 0;
            var row = 7;
            if (datos != null)
            {


                foreach (var registro in datos)
                {

                    xlsdocument.AutoFitColumn("B2", "F2");

                    var b = "B" + row;
                    var c = "C" + row;
                    var d = "D" + row;
                    var e = "E" + row;
                    var f = "F" + row;
                    var g = "G" + row;
                    var h = "H" + row;

                    xlsdocument.SetCellStyle(b, styleBack);
                    xlsdocument.SetCellStyle(c, styleBack);
                    xlsdocument.SetCellStyle(d, styleBack);
                    xlsdocument.SetCellStyle(e, styleBack);
                    xlsdocument.SetCellStyle(f, styleBack);
                    xlsdocument.SetCellStyle(g, styleBack);
                    xlsdocument.SetCellStyle(h, styleBack);

                    xlsdocument.SetCellStyle("C6", line);
                    xlsdocument.SetCellStyle("D6", line);
                    xlsdocument.SetCellStyle("E6", line);
                    xlsdocument.SetCellStyle("F6", line);


                    xlsdocument.SetColumnWidth("C", 20.0);

                    xlsdocument.SetRowHeight(2, 45.0);
                    xlsdocument.SetRowHeight(3, 45.0);
                    xlsdocument.SetRowHeight(row, 45.0);
                    xlsdocument.SetCellValue(2, 2, "          BALANCE DE PROPUESTAS");
                    xlsdocument.SetCellStyle(2, 2, titlefont);

                    xlsdocument.SetCellValue(3, 2, "          Informacion de Matriz Cono de Propuestas");
                    xlsdocument.SetCellStyle(3, 2, font);
                    //xlsdocument.SetCellValue(5, 2, registro.estadopropuesta);

                    xlsdocument.SetCellValue(row, 3, registro.totalestadopropuesta);
                    xlsdocument.SetCellStyle(row, 3, prp);
                    xlsdocument.SetCellValue(row, 4, "Propuestas");
                    xlsdocument.SetCellStyle(row, 4, prp);
                    xlsdocument.SetCellValue(row, 5, registro.estadopropuesta);
                    xlsdocument.SetCellStyle(row, 5, prpBlue);



                    row++;
                }
                foreach (var registro2 in datos2)
                {


                    xlsdocument.AutoFitColumn("B2", "F2");
                    var b = "B" + row;
                    var c = "C" + row;
                    var d = "D" + row;
                    var e = "E" + row;
                    var f = "F" + row;
                    var g = "G" + row;
                    var h = "H" + row;

                    xlsdocument.SetCellStyle(b, styleBack);
                    xlsdocument.SetCellStyle(c, styleBack);
                    xlsdocument.SetCellStyle(d, styleBack);
                    xlsdocument.SetCellStyle(e, styleBack);
                    xlsdocument.SetCellStyle(f, styleBack);
                    xlsdocument.SetCellStyle(g, styleBack);
                    xlsdocument.SetCellStyle(h, styleBack);
                    xlsdocument.SetCellStyle("C6", line);
                    xlsdocument.SetCellStyle("D6", line);
                    xlsdocument.SetCellStyle("E6", line);
                    xlsdocument.SetCellStyle("F6", line);
                    xlsdocument.SetColumnWidth("C", 20.0);

                    xlsdocument.SetRowHeight(row, 45.0);

                    xlsdocument.SetCellValue(row, 3, registro2.totalmodalidadpropuesta);
                    xlsdocument.SetCellStyle(row, 3, prp);

                    xlsdocument.SetCellValue(row, 4, "Propuestas");
                    xlsdocument.SetCellStyle(row, 4, prp);

                    xlsdocument.SetCellValue(row, 5, registro2.modalidadpropuesta);
                    xlsdocument.SetCellStyle(row, 5, prpBlue);

                    row++;

                }
                foreach (var registro3 in datos3)
                {


                    xlsdocument.AutoFitColumn("B2", "F2");
                    var b = "B" + row;
                    var c = "C" + row;
                    var d = "D" + row;
                    var e = "E" + row;
                    var f = "F" + row;
                    var g = "G" + row;
                    var h = "H" + row;

                    xlsdocument.SetCellStyle(b, styleBack);
                    xlsdocument.SetCellStyle(c, styleBack);
                    xlsdocument.SetCellStyle(d, styleBack);
                    xlsdocument.SetCellStyle(e, styleBack);
                    xlsdocument.SetCellStyle(f, styleBack);
                    xlsdocument.SetCellStyle(g, styleBack);
                    xlsdocument.SetCellStyle(h, styleBack);
                    xlsdocument.SetCellStyle("C6", line);
                    xlsdocument.SetCellStyle("D6", line);
                    xlsdocument.SetCellStyle("E6", line);
                    xlsdocument.SetCellStyle("F6", line);
                    xlsdocument.SetColumnWidth("C", 20.0);

                    xlsdocument.SetRowHeight(row, 45.0);

                    xlsdocument.SetCellValue(row, 3, registro3.totalportipousuario);
                    xlsdocument.SetCellStyle(row, 3, prp);

                    xlsdocument.SetCellValue(row, 4, "Propuestas");
                    xlsdocument.SetCellStyle(row, 4, prp);

                    xlsdocument.SetCellValue(row, 5, registro3.nmpropuestatipousuario);
                    xlsdocument.SetCellStyle(row, 5, prpBlue);


                    row++;
                }
                foreach (var registro4 in datos4)
                {


                    xlsdocument.AutoFitColumn("B2", "F2");
                    var b = "B" + row;
                    var c = "C" + row;
                    var d = "D" + row;
                    var e = "E" + row;
                    var f = "F" + row;
                    var g = "G" + row;
                    var h = "H" + row;
                    xlsdocument.SetCellStyle(b, styleBack);
                    xlsdocument.SetCellStyle(c, styleBack);
                    xlsdocument.SetCellStyle(d, styleBack);
                    xlsdocument.SetCellStyle(e, styleBack);
                    xlsdocument.SetCellStyle(f, styleBack);
                    xlsdocument.SetCellStyle(g, styleBack);
                    xlsdocument.SetCellStyle(h, styleBack);
                    xlsdocument.SetCellStyle("C6", line);
                    xlsdocument.SetCellStyle("D6", line);
                    xlsdocument.SetCellStyle("E6", line);
                    xlsdocument.SetCellStyle("F6", line);
                    xlsdocument.SetColumnWidth("C", 20.0);

                    xlsdocument.SetRowHeight(row, 45.0);

                    xlsdocument.SetCellValue(row, 3, registro4.totalorigenpropuesta);
                    xlsdocument.SetCellStyle(row, 3, prp);

                    xlsdocument.SetCellValue(row, 4, "Propuestas");
                    xlsdocument.SetCellStyle(row, 4, prp);

                    xlsdocument.SetCellValue(row, 5, registro4.origenpropuesta);
                    xlsdocument.SetCellStyle(row, 5, prpBlue);

                    sum += registro4.totalorigenpropuesta;

                    xlsdocument.SetCellValue(5, 3, sum);
                    xlsdocument.SetCellStyle(5, 3, propuestas);
                    xlsdocument.SetCellStyle(5, 3, propuestastit);

                    xlsdocument.SetCellValue(5, 4, "propuestas");
                    xlsdocument.SetCellStyle(5, 4, propuestasSb);

                    //en la 7 va linea

                    row++;

                }
                xlsdocument.MergeWorksheetCells(row, 2, row, 8);
                xlsdocument.MergeWorksheetCells(row + 1, 2, row + 1, 8);
                var foot = "B" + (row + 1);
                var margin = "B" + row;

                xlsdocument.SetCellStyle(margin, styleBack);

                xlsdocument.SetRowHeight(row + 1, 45.0);
                xlsdocument.SetRowHeight(row, 15.0);

                xlsdocument.SetCellStyle(foot, footer);
                xlsdocument.SetCellValue(foot, "      Facultad de Derecho, Ciencias Politicas y Sociales Sede Bogotá" +
                "                                                                                                                        " +
                "Proyecto CULTURAl, CIENTIFICO, y COLECTIVO de Nación ");


                xlsdocument.SetCellStyle(foot, txtfooter);


            }





            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }
    }
}