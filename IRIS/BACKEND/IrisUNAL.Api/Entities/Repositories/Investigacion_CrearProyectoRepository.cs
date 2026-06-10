using DocumentFormat.OpenXml.Spreadsheet;
using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.Investigacion;
using IrisUNAL.Api.Models.TableModel;
using Npgsql;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Investigacion_CrearProyectoRepository : SuperType<Investigacion_CrearProyecto>, IInvestigacion_CrearProyectoRepository
    {
        private ApplicationDbContext _context;

        public Investigacion_CrearProyectoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Investigacion_CrearProyectoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteInvestigacion_CrearProyecto(int id_crearproyecto)
        {
            Delete(id_crearproyecto);
            return true;
        }

        public IEnumerable<Investigacion_CrearProyecto> GetAllInvestigacion_CrearProyecto()
        {
            return Get();
        }

        public IEnumerable<Investigacion_CrearProyecto> GetInvestigacion_CrearProyectoCodigo(string cd_codigohermes)
        {
            return Get(c => c.codigohermes == cd_codigohermes);
        }

        public Investigacion_CrearProyecto GetInvestigacion_CrearProyectoDetails(int id_crearproyecto)
        {
            return Get(id_crearproyecto);
        }

        public bool InsertInvestigacion_CrearProyecto(Investigacion_CrearProyecto investigacion_CrearProyecto)
        {
            Add(investigacion_CrearProyecto);
            return true;
        }

        public bool UpdateInvestigacion_CrearProyecto(Investigacion_CrearProyecto investigacion_CrearProyecto)
        {
            Update(investigacion_CrearProyecto);
            return true;
        }
        //CAMBIOS ADDA, ESTE CODIGO ESTA MODIFICADO PARA BUSCAR EN TODAS LAS COLUMNAS: 
        public DataTableAdapter<Investigacion_CrearProyecto> GetDataTableInvestigacion_CrearProyecto(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Investigacion_CrearProyecto, bool>> srchByFunc = null;
            Expression<Func<Investigacion_CrearProyecto, string>> orderByFunc = null;
            Expression<Func<Investigacion_CrearProyecto, DateTime>> orderByDateFunc = null;
            Expression<Func<Investigacion_CrearProyecto, int>> orderByIntFunc = null;

            Expression<Func<Investigacion_CrearProyecto, object>> parameter1 = p => p.ObjPersona;
            Expression<Func<Investigacion_CrearProyecto, object>> parameter2 = p => p.ObjFuncionario;
            Expression<Func<Investigacion_CrearProyecto, object>> parameter3 = p => p.ObjGrupo;
            Expression<Func<Investigacion_CrearProyecto, object>> parameter4 = p => p.ObjNaturaleza;
            Expression<Func<Investigacion_CrearProyecto, object>>[] parameterArray = new Expression<Func<Investigacion_CrearProyecto, object>>[] { parameter1, parameter2, parameter3, parameter4 };

            bool isOrderDesc = false;

            var query = _context.investigacion_crearproyecto.Include("ObjPersona");

            if (model.SearchValue != null && model.SearchValue != "")
            {
                var searchValue = model.SearchValue.ToLower();
                srchByFunc = d => d.nombreproyecto.ToLower().Contains(searchValue) ||
                                  d.codigohermes.ToLower().Contains(searchValue) ||
                                  d.quipu.ToLower().Contains(searchValue) ||
                                  d.ObjPersona.nombrecompleto.ToLower().Contains(searchValue);
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var sortcolumn = (model.SortColumn.ToLower() == "nmproyectodt") ? "nombreproyecto" : model.SortColumn.ToLower();

            if (sortcolumn == "fechainicio" || model.SortColumn.ToLower() == "fechaentrega")
                orderByDateFunc = CreateExpressionOrderByDate<Investigacion_CrearProyecto>(sortcolumn);
            else if (sortcolumn == "id_crearproyecto")
                orderByIntFunc = CreateExpressionOrderByInt<Investigacion_CrearProyecto>("id_crearproyecto");
            else
                orderByFunc = CreateExpressionOrderBy<Investigacion_CrearProyecto>(sortcolumn);

            List<Investigacion_CrearProyecto> data = null;

            if (sortcolumn == "fechainicio" || model.SortColumn.ToLower() == "fechaentrega")
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList();
            else
                if (sortcolumn == "id_crearproyecto")
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();
            else
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Investigacion_CrearProyecto> result = new DataTableAdapter<Investigacion_CrearProyecto>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }







        //CAMBIOS ADDA
        //ESTE ES EL ORIGINAL
        //public DataTableAdapter<Investigacion_CrearProyecto> GetDataTableInvestigacion_CrearProyecto(DataTableRequest model)
        //{
        //    var totalRows = Count();
        //    var RowsFiltered = totalRows;

        //    Expression<Func<Investigacion_CrearProyecto, bool>> srchByFunc = null;
        //    Expression<Func<Investigacion_CrearProyecto, string>> orderByFunc = null;
        //    Expression<Func<Investigacion_CrearProyecto, DateTime>> orderByDateFunc = null;
        //    Expression<Func<Investigacion_CrearProyecto, int>> orderByIntFunc = null;

        //    Expression<Func<Investigacion_CrearProyecto, object>> parameter1 = p => p.ObjPersona;
        //    Expression<Func<Investigacion_CrearProyecto, object>> parameter2 = p => p.ObjFuncionario;
        //    Expression<Func<Investigacion_CrearProyecto, object>> parameter3 = p => p.ObjGrupo;
        //    Expression<Func<Investigacion_CrearProyecto, object>> parameter4 = p => p.ObjNaturaleza;
        //    //Expression<Func<Investigacion_CrearProyecto, object>> parameter3 = p => p.ObjEstado;
        //    Expression<Func<Investigacion_CrearProyecto, object>>[] parameterArray = new Expression<Func<Investigacion_CrearProyecto, object>>[] { parameter1, parameter2, parameter3, parameter4 };

        //    bool isOrderDesc = false;

        //    if (model.SearchValue != null && model.SearchValue != "")
        //    {
        //        srchByFunc = d => d.nombreproyecto.ToLower().Contains(model.SearchValue.ToLower()) || d.codigohermes.ToLower().Contains(model.SearchValue.ToLower()) || d.quipu.ToLower().Contains(model.SearchValue.ToLower());
        //        RowsFiltered = CountFiltered(srchByFunc);
        //    }

        //    isOrderDesc = model.SortColumnDir == "asc" ? false : true;

        //    var sortcolumn = (model.SortColumn.ToLower() == "nmproyectodt") ? "nombreproyecto" : model.SortColumn.ToLower();

        //    if (sortcolumn == "fechainicio" || model.SortColumn.ToLower() == "fechaentrega")
        //        orderByDateFunc = CreateExpressionOrderByDate<Investigacion_CrearProyecto>(sortcolumn);
        //    else
        //        if (sortcolumn == "id_crearproyecto")
        //        orderByIntFunc = CreateExpressionOrderByInt<Investigacion_CrearProyecto>("id_crearproyecto");
        //    else
        //        orderByFunc = CreateExpressionOrderBy<Investigacion_CrearProyecto>(sortcolumn);

        //    List<Investigacion_CrearProyecto> data = null;

        //    if (sortcolumn == "fechainicio" || model.SortColumn.ToLower() == "fechaentrega")
        //        data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList();
        //    else
        //        if (sortcolumn == "id_crearproyecto")
        //        data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();
        //    else
        //        data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

        //    //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
        //    DataTableAdapter<Investigacion_CrearProyecto> result = new DataTableAdapter<Investigacion_CrearProyecto>();

        //    //Llenamos con información nuestro DataTableAdapter
        //    result.Data = data;
        //    result.Draw = model.draw;
        //    result.RecordsTotal = totalRows;
        //    result.RecordsFiltered = RowsFiltered;
        //    //Regresamos el objeto result
        //    return result;
        //}

        public ProyectoTotalAportesDTO GetInvestigacion_CrearProyectoAportes(int id_crearproyecto)
        {
            ProyectoTotalAportesDTO datoaportes = new ProyectoTotalAportesDTO();
            datoaportes.id_proyecto = id_crearproyecto;

            var datosproyecto = Get(id_crearproyecto);

            if (datosproyecto != null)
            {
                datoaportes.aportefacultad = datosproyecto.valoraportefacultad;
                datoaportes.aportevir = datosproyecto.valoraportevir;
                datoaportes.aportedieb = datosproyecto.valoraportedieb;
                datoaportes.aprobadoconvenio = datosproyecto.valoraporteexterno;

                //**** TOTAL APORTADO
                var valoraportado = (from sd in _context.investigacion_desembolso
                                     where sd.id_crearproyecto == id_crearproyecto
                                     group sd by sd.id_crearproyecto into dt
                                     select new
                                     {
                                         pagos = dt.Sum(x => x.valordesembolso)
                                     }).FirstOrDefault();

                datoaportes.aportadoconvenio = (valoraportado == null) ? 0 : valoraportado.pagos;
            }

            return datoaportes;
        }

        public bool UpdateInvestigacion_CrearProyectoAportes(ProyectoTotalAportesDTO proyecto_aportes)
        {
            var datosproyecto = Get(proyecto_aportes.id_proyecto);

            if (datosproyecto != null)
            {
                datosproyecto.valoraportefacultad = (long)proyecto_aportes.aportefacultad;
                datosproyecto.valoraportevir = (long)proyecto_aportes.aportevir;
                datosproyecto.valoraportedieb = (long)proyecto_aportes.aportedieb;
                datosproyecto.valoraporteexterno = (long)proyecto_aportes.aprobadoconvenio;

                Update(datosproyecto);
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ExcelInvestigacion_CrearProyecto(int id_crearproyecto)
        {
            var archivoreturn = "/Export/InvestigacionControlFinanciero_" + id_crearproyecto.ToString() + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/InvestigacionControlFinanciero_" + id_crearproyecto.ToString() + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/InvestigacionControl_Financiero_.xlsx");
            SLDocument xlsdocument = new SLDocument(plantilla);

            ProyectoTotalAportesDTO datoaportes = new ProyectoTotalAportesDTO();
            datoaportes.id_proyecto = id_crearproyecto;

            var datosproyecto = Get(id_crearproyecto);

            Investigacion_CrearProyecto crearproyecto = new Investigacion_CrearProyecto();
            crearproyecto.id_crearproyecto = id_crearproyecto;

            var dataCrearProyectos = Get(id_crearproyecto);

            Investigacion_Desembolso desembolso = new Investigacion_Desembolso();
            desembolso.id_crearproyecto = id_crearproyecto;

            var dataDesembolso = Get(id_crearproyecto);

            //Se declaran variables correspondientes a cada partida para que vayan aumentando con respecto a la cantidad de gastos

            var rowSer = 0;
            var rowSer2 = 0;
            var rowImp = 0;
            var rowTras = 0;
            var rowbienes = 0;
            var rowservicios = 0;
            var rowimpuestos = 0;
            var rowtransferencias = 0;

            SLStyle style = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            SLStyle titlesCentred = xlsdocument.CreateStyle();
            SLStyle titlesLeft = xlsdocument.CreateStyle();
            SLStyle rowBorder = xlsdocument.CreateStyle();
            SLStyle titleWOutBKg = xlsdocument.CreateStyle(); //Titulos sin color de fondo 
            SLStyle textContent = xlsdocument.CreateStyle();
            SLStyle gastosPersonal = xlsdocument.CreateStyle();
            SLStyle gastosPersonalCentred = xlsdocument.CreateStyle();
            SLStyle bordersStyle = xlsdocument.CreateStyle();


            bordersStyle.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            bordersStyle.Border.LeftBorder.Color = System.Drawing.Color.Black;
            bordersStyle.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            bordersStyle.Border.RightBorder.Color = System.Drawing.Color.Black;
            bordersStyle.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            bordersStyle.Border.TopBorder.Color = System.Drawing.Color.Black;
            bordersStyle.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            bordersStyle.Border.BottomBorder.Color = System.Drawing.Color.Black;

            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            //style.SetWrapText(true);
            //style.Alignment.JustifyLastLine = true;
            //style.Alignment.ShrinkToFit = true;
            rowBorder.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.Black, System.Drawing.Color.Black);

            textContent.Font.FontName = "Times New Roman";
            textContent.Font.FontSize = 13.0;
            textContent.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            textContent.Alignment.Vertical = VerticalAlignmentValues.Center;

            titleWOutBKg.Font.FontName = "Times New Roman";
            titleWOutBKg.Font.FontSize = 18.0;
            titleWOutBKg.Font.Bold = true;
            titleWOutBKg.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            titleWOutBKg.Alignment.Vertical = VerticalAlignmentValues.Center;

            titlesCentred.Font.FontName = "Times New Roman";
            titlesCentred.Font.FontSize = 18.0;
            titlesCentred.Font.Bold = true;
            titlesCentred.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            titlesCentred.Alignment.Vertical = VerticalAlignmentValues.Center;
            titlesCentred.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(25, 240, 203), System.Drawing.Color.Blue);


            titlesLeft.Font.FontName = "Times New Roman";
            titlesLeft.Font.FontSize = 18.0;
            titlesLeft.Font.Bold = true;
            titlesLeft.Alignment.Horizontal = HorizontalAlignmentValues.Left;
            titlesLeft.Alignment.Vertical = VerticalAlignmentValues.Center;
            titlesLeft.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(25, 240, 203), System.Drawing.Color.Blue);

            gastosPersonal.Font.FontName = "Times New Roman";
            gastosPersonal.Font.FontSize = 14.0;
            gastosPersonal.Font.Bold = true;
            gastosPersonal.Alignment.Horizontal = HorizontalAlignmentValues.Left;
            gastosPersonal.Alignment.Vertical = VerticalAlignmentValues.Center;
            gastosPersonal.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.FromArgb(72, 199, 246), System.Drawing.Color.Blue);

            gastosPersonalCentred.Font.FontName = "Times New Roman";
            gastosPersonalCentred.Font.FontSize = 14.0;
            gastosPersonalCentred.Font.Bold = true;
            gastosPersonalCentred.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            gastosPersonalCentred.Alignment.Vertical = VerticalAlignmentValues.Center;
            gastosPersonalCentred.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.FromArgb(72, 199, 246), System.Drawing.Color.Blue);


            styleBack.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(146, 208, 80), System.Drawing.Color.Blue);


            xlsdocument.MergeWorksheetCells(1, 1, 1, 24);
            xlsdocument.MergeWorksheetCells(2, 6, 2, 24);
            xlsdocument.MergeWorksheetCells(3, 6, 3, 12);
            xlsdocument.MergeWorksheetCells(4, 6, 4, 12);
            xlsdocument.MergeWorksheetCells(5, 6, 5, 12);
            xlsdocument.MergeWorksheetCells(3, 13, 3, 15);
            xlsdocument.MergeWorksheetCells(4, 13, 4, 15);
            xlsdocument.MergeWorksheetCells(5, 13, 5, 15);

            xlsdocument.MergeWorksheetCells(3, 16, 3, 20);
            xlsdocument.MergeWorksheetCells(4, 16, 4, 20);
            xlsdocument.MergeWorksheetCells(5, 16, 5, 20);
            xlsdocument.MergeWorksheetCells(3, 21, 3, 22);
            xlsdocument.MergeWorksheetCells(4, 21, 4, 22);
            xlsdocument.MergeWorksheetCells(5, 21, 5, 22);

            xlsdocument.SetCellValue(1, 1, "SEGUIMIENTO FINANCIERO  Y ADMINISTRATIVOS DE PROYECTOS");
            xlsdocument.SetCellStyle(1, 1, titlesCentred);
            xlsdocument.MergeWorksheetCells(2, 1, 2, 5);
            xlsdocument.SetCellValue(2, 1, "NOMBRE DEL PROYECTO ");
            xlsdocument.SetCellStyle(2, 1, titlesLeft);
            xlsdocument.MergeWorksheetCells(3, 1, 3, 5);
            xlsdocument.SetCellValue(3, 1, "CODIGO QUIPU ");
            xlsdocument.SetCellStyle(3, 1, titlesLeft);
            xlsdocument.MergeWorksheetCells(4, 1, 4, 5);
            xlsdocument.SetCellValue(4, 1, "DIRECTOR DEL PROYECTO ");
            xlsdocument.SetCellStyle(4, 1, titlesLeft);
            xlsdocument.MergeWorksheetCells(5, 1, 5, 5);
            xlsdocument.SetCellValue(5, 1, "INTERVENTOR DEL PROYECTO ");
            xlsdocument.SetCellStyle(5, 1, titlesLeft);
            xlsdocument.SetCellValue(3, 13, "CODIGO HERMES");
            xlsdocument.SetCellStyle(3, 13, titlesCentred);
            xlsdocument.SetCellValue(4, 13, "IDENTIFICACION");
            xlsdocument.SetCellStyle(4, 13, titlesCentred);
            xlsdocument.SetCellValue(5, 13, "IDENTIFICACION");
            xlsdocument.SetCellStyle(5, 13, titlesCentred);
            xlsdocument.SetCellValue(3, 21, "EMPRESA");
            xlsdocument.SetCellStyle(3, 21, titlesCentred);
            xlsdocument.SetCellValue(4, 21, "CORREO");
            xlsdocument.SetCellStyle(4, 21, titlesCentred);
            xlsdocument.SetCellValue(5, 21, "CORREO");
            xlsdocument.SetCellStyle(5, 21, titlesCentred);
            xlsdocument.MergeWorksheetCells(7, 1, 7, 2);
            xlsdocument.SetCellValue(7, 1, "APORTE DE FACULTAD");
            xlsdocument.SetCellStyle(7, 1, titlesCentred);
            xlsdocument.MergeWorksheetCells(7, 3, 7, 5);
            xlsdocument.SetCellValue(7, 3, "APORTE VIR");
            xlsdocument.SetCellStyle(7, 3, titleWOutBKg);
            xlsdocument.MergeWorksheetCells(7, 6, 7, 10);
            xlsdocument.SetCellValue(7, 6, "APORTE DIEB");
            xlsdocument.SetCellStyle(7, 6, titlesCentred);
            xlsdocument.MergeWorksheetCells("K7", "X7");
            xlsdocument.SetCellValue("K7", "FINANCIACION EXTERNA");
            xlsdocument.SetCellStyle("K7", titleWOutBKg);
            xlsdocument.MergeWorksheetCells("K8", "M8");
            xlsdocument.SetCellValue("K8", "PAGOS");
            xlsdocument.SetCellStyle("K8", titleWOutBKg);
            xlsdocument.SetCellValue("N8", "100%");
            xlsdocument.SetCellStyle("N8", titleWOutBKg);
            xlsdocument.MergeWorksheetCells("O8", "P8");
            xlsdocument.SetCellValue("O8", "VALOR");
            xlsdocument.SetCellStyle("O8", titleWOutBKg);
            xlsdocument.MergeWorksheetCells("Q8", "S8");
            xlsdocument.SetCellValue("Q8", "FECHA DE GIRO");
            xlsdocument.SetCellStyle("Q8", titleWOutBKg);
            xlsdocument.MergeWorksheetCells("T8", "X8");
            xlsdocument.SetCellValue("T8", "TOTAL APORTADO A LA FECHA");
            xlsdocument.SetCellStyle("T8", titleWOutBKg);
            xlsdocument.MergeWorksheetCells("T9", "X9");
            xlsdocument.MergeWorksheetCells("T10", "X10");
            xlsdocument.SetCellValue("T10", "TOTAL CONVENIO APROBADO");
            xlsdocument.SetCellStyle("T10", titleWOutBKg);
            xlsdocument.MergeWorksheetCells("T11", "X11");



            xlsdocument.AutoFitColumn(1, 25);
            xlsdocument.AutoFitRow(1, 25);
            xlsdocument.SetWorksheetDefaultColumnWidth(13.0);
            xlsdocument.SetColumnWidth(1, 13.5);
            xlsdocument.SetColumnWidth(2, 29.5);
            xlsdocument.SetColumnWidth(3, 17.0);
            xlsdocument.SetCellStyle("A6", "X6", rowBorder);
            //xlsdocument.SetCellStyle("Y1", "Y6", rowBorder);
            xlsdocument.SetColumnWidth("Y", 2.5);
            xlsdocument.SetRowHeight(6, 11.0);

            if (datosproyecto != null)
            {

                //Se obtienen los datos de las personas asociadas al proyecto
                string qryPersona = "select pe.nombrecompleto, pe.numidentificacion, pe.correo1, fu.correo ,concat (fu.nombres, ' ', fu.apellidos) as funcionario  from investigacion_crearproyecto cp join persona pe on cp.id_persona = pe.id_persona join funcionario fu on cp.idfuncionario = fu.idfuncionario where cp.id_crearproyecto = @id_crearproyecto group by pe.nombrecompleto, pe.numidentificacion, pe.correo1, fu.correo , funcionario";
                List<NpgsqlParameter> parameterListPersona = new List<NpgsqlParameter>();
                parameterListPersona.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                NpgsqlParameter[] ParamPersona = parameterListPersona.ToArray();




                var datosPersona = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryPersona, ParamPersona).ToList();

                foreach (var persona in datosPersona)
                {
                    xlsdocument.SetCellValue("F4", persona.nombrecompleto);
                    xlsdocument.SetCellStyle("F4", textContent);
                    xlsdocument.SetCellValue("P4", persona.numidentificacion);
                    xlsdocument.SetCellStyle("P4", textContent);
                    xlsdocument.SetCellValue("W4", persona.correo1);
                    xlsdocument.SetCellStyle("W4", textContent);

                    xlsdocument.SetCellValue("F18", persona.funcionario);
                    xlsdocument.SetCellStyle("F18", textContent);
                    xlsdocument.SetCellValue("W18", persona.correo);
                    xlsdocument.SetCellStyle("W18", textContent);

                }

                datoaportes.aportefacultad = datosproyecto.valoraportefacultad;
                datoaportes.aportevir = datosproyecto.valoraportevir;
                datoaportes.aportedieb = datosproyecto.valoraportedieb;
                datoaportes.aprobadoconvenio = datosproyecto.aprobadoconvenio;

                //**** TOTAL APORTADO
                //var valoraportado = (from sd in _context.investigacion_desembolso
                //                     where sd.id_crearproyecto == id_crearproyecto
                //                     group sd by sd.id_crearproyecto into dt
                //                     select new
                //                     {
                //                         pagos = dt.Sum(x => x.valordesembolso)
                //                     }).FirstOrDefault();

                //datoaportes.aportadoconvenio = (valoraportado == null) ? 0 : valoraportado.pagos;

                if (datoaportes.aportefacultad != null)
                    xlsdocument.SetCellValue(8, 1, (long)datoaportes.aportefacultad);
                xlsdocument.SetCellStyle(8, 1, textContent);

                if (datoaportes.aportevir != null)
                    xlsdocument.SetCellValue(8, 3, (long)datoaportes.aportevir);
                xlsdocument.SetCellStyle(8, 3, textContent);

                if (datoaportes.aportedieb != null)
                    xlsdocument.SetCellValue(8, 6, (long)datoaportes.aportedieb);
                xlsdocument.SetCellStyle(8, 6, textContent);

                //if (valoraportado != null)
                //    xlsdocument.SetCellValue("T9", valoraportado.pagos);
                //xlsdocument.SetCellStyle("T9", textContent);

                if (datoaportes.aprobadoconvenio != null)
                    xlsdocument.SetCellValue("T12", (long)datoaportes.aprobadoconvenio);
                xlsdocument.SetCellStyle("T12", textContent);



            }
            if (dataCrearProyectos != null)
            {

                string qryEstado = "select ep.nmestado from investigacion_crearproyecto cp join investigacion_estadoproyecto ep on cp.id_estado = ep.id_estado where cp.id_crearproyecto = @id_crearproyecto group by ep.nmestado ";
                List<NpgsqlParameter> parameterListEstado = new List<NpgsqlParameter>();
                parameterListEstado.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                NpgsqlParameter[] ParamEstado = parameterListEstado.ToArray();




                var datosEstado = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryEstado, ParamEstado).ToList();

                foreach (var estado in datosEstado)
                {
                    xlsdocument.SetCellValue("U16", estado.nmestado);
                    xlsdocument.SetCellStyle("U16", textContent);
                }

                crearproyecto.nombreproyecto = dataCrearProyectos.nombreproyecto;
                crearproyecto.quipu = dataCrearProyectos.quipu;
                crearproyecto.codigohermes = dataCrearProyectos.codigohermes;
                crearproyecto.empresa = dataCrearProyectos.empresa;
                crearproyecto.vigencia = dataCrearProyectos.vigencia;
                //select ep.nmestado from investigacion_crearproyecto cp join investigacion_estadoproyecto ep on cp.id_estado = ep.id_estado where cp.id_crearproyecto = 3 group by ep.nmestado 


                //crearproyecto.ObjFuncionario.correo = dataCrearProyectos.ObjFuncionario.correo; //preguntar si este es el mismo director

                xlsdocument.SetCellValue("F2", crearproyecto.nombreproyecto);
                xlsdocument.SetCellStyle("F2", textContent);
                xlsdocument.SetCellValue("F3", crearproyecto.quipu);
                xlsdocument.SetCellStyle("F3", textContent);
                xlsdocument.SetCellValue("P3", crearproyecto.codigohermes);
                xlsdocument.SetCellStyle("P3", textContent);
                xlsdocument.SetCellValue("W3", crearproyecto.empresa);
                xlsdocument.SetCellStyle("W3", textContent);
                xlsdocument.SetCellValue("F15", dataCrearProyectos.vigencia);
                xlsdocument.SetCellStyle("F15", textContent);

            }

            string qry = "select valordesembolso, fechadesembolso from investigacion_desembolso where id_crearproyecto = @id_crearproyecto";
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
            NpgsqlParameter[] Param = parameterList.ToArray();




            var datos = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qry, Param).ToList();


            string qryPercent = "select sum(valordesembolso) as suma from investigacion_desembolso where id_crearproyecto = @id_crearproyecto";
            List<NpgsqlParameter> parameterListPercent = new List<NpgsqlParameter>();
            parameterListPercent.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
            NpgsqlParameter[] ParamPercent = parameterListPercent.ToArray();




            var datosPercent = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryPercent, ParamPercent).ToList();



            var row = 9;
            var des = 1;
            var id_rubro = 0;
            var id_investigaciongasto = 0;
            var rowTot = 0;
            var totRow = true;
            var rowBie = true;
            var rowServ = true;
            var rowImpues = true;
            var rowTransf = true;
            var perc = true;
            double percent = 0;
            double totaldes = 0;
            int decimales = 2;





            foreach (var registroDes in datosPercent)
            {
                if (registroDes.suma != null)
                    totaldes = (int)registroDes.suma;

            }

            foreach (var registro in datos)
            {

                xlsdocument.MergeWorksheetCells("K" + row, "M" + row);
                xlsdocument.MergeWorksheetCells("O" + row, "P" + row);
                xlsdocument.MergeWorksheetCells("Q" + row, "S" + row);

                xlsdocument.SetCellValue("K" + row, "DESEMBOLSO " + des);
                xlsdocument.SetCellStyle("K" + row, textContent);
                xlsdocument.SetCellValue("O" + row, registro.valordesembolso);
                xlsdocument.SetCellStyle("O" + row, textContent);
                xlsdocument.SetCellValue("Q" + row, registro.fechadesembolso.ToString());
                xlsdocument.SetCellStyle("Q" + row, textContent);

                percent = registro.valordesembolso * 100 / totaldes;



                xlsdocument.SetCellValue("N" + row, percent.ToString($"F{decimales}") + "%");
                xlsdocument.SetCellStyle("N" + row, textContent);


                row++;
                des++;
            }
            xlsdocument.MergeWorksheetCells("K" + row, "S" + (row + 1));

            crearproyecto.fechainicio = dataCrearProyectos.fechainicio;
            crearproyecto.fechaentrega = dataCrearProyectos.fechaentrega;




            Investigacion_Gasto rubro = new Investigacion_Gasto();
            rubro.id_crearproyecto = id_crearproyecto;

            var dataRubro = Get(id_crearproyecto);

            Seguimiento_Rubro segRubro = new Seguimiento_Rubro();


            //Partida 1

            string qry2 = "select DISTINCT ru.nombrerubro, ru.id_rubro from investigacion_gasto ga join seguimiento_rubro ru on ga.id_rubro = ru.id_rubro where ga.id_crearproyecto=@id_crearproyecto and ga.id_partida = 1";
            List<NpgsqlParameter> parameterList2 = new List<NpgsqlParameter>();
            parameterList2.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
            NpgsqlParameter[] Param2 = parameterList2.ToArray();




            var datos2 = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qry2, Param2).ToList();


            xlsdocument.MergeWorksheetCells("T12", "X" + (row - 1));
            xlsdocument.MergeWorksheetCells("A8", "B" + (row - 1));
            xlsdocument.MergeWorksheetCells("C8", "E" + (row - 1));
            xlsdocument.MergeWorksheetCells("F8", "J" + (row - 1));
            xlsdocument.MergeWorksheetCells("F" + row, "X" + row);
            xlsdocument.MergeWorksheetCells(row, 1, row, 5);
            xlsdocument.SetCellValue(row, 1, "VALOR TOTAL DEL PROYECTO APROBADO ");
            xlsdocument.SetCellStyle(row, 1, titlesLeft);
            xlsdocument.MergeWorksheetCells("F" + row, "J" + row);
            xlsdocument.SetCellValue("F" + row, "$" + crearproyecto.valortotalproyecto);
            xlsdocument.SetCellStyle("F" + (row), textContent);

            xlsdocument.MergeWorksheetCells(row + 1, 1, row + 1, 5);
            xlsdocument.SetCellValue(row + 1, 1, "VALOR EJECUTADO DEL PROYECTO");
            xlsdocument.SetCellStyle(row + 1, 1, titlesLeft);
            xlsdocument.MergeWorksheetCells("F" + (row + 1), "J" + (row + 1));
            xlsdocument.SetCellValue("F" + (row + 1), "$" + crearproyecto.valorejecutado);
            xlsdocument.SetCellStyle("F" + (row + 1), textContent);

            xlsdocument.MergeWorksheetCells(row + 2, 1, row + 2, 5);
            xlsdocument.SetCellValue(row + 2, 1, "VIGENCIA DEL PROYECTO PARA EJECUTAR");
            xlsdocument.SetCellStyle(row + 2, 1, titlesLeft);
            xlsdocument.MergeWorksheetCells(row + 2, 1, row + 2, 5);
            xlsdocument.MergeWorksheetCells("F" + (row + 2), "X" + (row + 2));
            //xlsdocument.SetCellValue("F" + row+2, data.valortotalproyecto);

            xlsdocument.MergeWorksheetCells(row + 3, 1, row + 3, 3);
            xlsdocument.SetCellValue(row + 3, 1, "FECHA DE INICIO DEL PROYECTO");
            xlsdocument.SetCellStyle(row + 3, 1, titlesCentred);
            xlsdocument.MergeWorksheetCells(row + 3, 4, row + 3, 6);
            xlsdocument.SetCellValue("D" + (row + 3), crearproyecto.fechainicio.ToString());//
            xlsdocument.SetCellStyle("D" + (row + 3), textContent);

            xlsdocument.MergeWorksheetCells("G" + (row + 3), "L" + (row + 3));
            xlsdocument.SetCellValue(row + 3, 7, "FECHA DE TERMINACION DEL PROYECTO");
            xlsdocument.SetCellStyle(row + 3, 7, titlesCentred);
            xlsdocument.MergeWorksheetCells("M" + (row + 3), "O" + (row + 3));
            xlsdocument.SetCellValue("M" + (row + 3), crearproyecto.fechaentrega.ToString());//
            xlsdocument.SetCellStyle("M" + (row + 3), textContent);

            xlsdocument.MergeWorksheetCells("P" + (row + 3), "T" + (row + 3));
            xlsdocument.SetCellValue(row + 3, 16, "ESTADO ACTUAL DEL PROYECTO");
            xlsdocument.SetCellStyle(row + 3, 16, titlesCentred);
            xlsdocument.MergeWorksheetCells("U" + (row + 3), "X" + (row + 3));
            // xlsdocument.SetCellValue("U" + (row + 3), );//
            xlsdocument.SetCellStyle("A" + (row + 4), "X" + (row + 4), rowBorder);
            xlsdocument.SetRowHeight(row + 4, 11.0);
            xlsdocument.MergeWorksheetCells((row + 5), 1, row + 5, 5);
            xlsdocument.SetCellValue(row + 5, 1, "ASISTENCIA DE COORDINACION DEL PROYECTO");
            xlsdocument.SetCellStyle(row + 5, 1, titlesLeft);
            xlsdocument.MergeWorksheetCells((row + 5), 6, row + 5, 12);
            xlsdocument.MergeWorksheetCells((row + 5), 13, row + 5, 15);
            xlsdocument.SetCellValue(row + 5, 15, "IDENTIFICACION");
            xlsdocument.SetCellStyle(row + 5, 15, titlesLeft);
            xlsdocument.MergeWorksheetCells((row + 5), 16, row + 5, 20);
            xlsdocument.MergeWorksheetCells((row + 5), 21, row + 5, 22);
            xlsdocument.SetCellValue(row + 5, 21, "CORREO");
            xlsdocument.SetCellStyle(row + 5, 21, titlesLeft);
            xlsdocument.SetCellStyle("A" + (row + 6), "X" + (row + 6), rowBorder);
            xlsdocument.SetRowHeight(row + 6, 11.0);
            xlsdocument.MergeWorksheetCells((row + 7), 1, row + 7, 24);
            xlsdocument.SetCellValue(row + 7, 1, "1. GASTOS DE PERSONAL");
            xlsdocument.SetCellStyle(row + 7, 1, gastosPersonal);
            xlsdocument.SetCellStyle("A" + (row + 8), "X" + (row + 8), rowBorder);
            xlsdocument.SetRowHeight(row + 8, 11.0);

            var nms = datos2.Select(x => x.nombreconcepto).ToArray();


            var rowRubro = (row + 9);
            var rowConcepto = 25;
            var rub = true;
            var rowRubNew = 0;
            var rowOpBienes = 0;
            var rowOpServicios = 0;
            var rowOpImpuestos = 0;
            var rowOptransferencias = 0;

            var optOrpa = true;
            var auxOrpa = 0;
            var delete = true;
            var deleteBienes = true;
            var deleteServicios = true;
            var deleteImpuestos = true;
            var deleteTransferencias = true;
            var cuatropormilPagos = 0;

            foreach (var registro in datos2)
            {



                if (rub == true)
                {
                    xlsdocument.SetCellValue(rowRubro, 1, "RUBRO");
                    xlsdocument.SetCellStyle(rowRubro, 1, gastosPersonal);
                    xlsdocument.SetCellValue(rowRubro, 2, registro.nombrerubro);
                    xlsdocument.MergeWorksheetCells("A" + rowRubro, "A" + (rowRubro + 2));
                    xlsdocument.MergeWorksheetCells("B" + rowRubro, "N" + (rowRubro + 2));
                    xlsdocument.MergeWorksheetCells("O" + rowRubro, "R" + rowRubro);
                    xlsdocument.SetCellValue(rowRubro, 15, "VALOR");
                    xlsdocument.SetCellStyle(rowRubro, 15, gastosPersonal);
                    xlsdocument.MergeWorksheetCells("O" + rowRubro, "R" + rowRubro);
                    xlsdocument.SetCellValue(rowRubro + 1, 15, "EJECUTADO");
                    xlsdocument.SetCellStyle(rowRubro + 1, 15, gastosPersonal);
                    xlsdocument.MergeWorksheetCells("O" + (rowRubro + 2), "R" + (rowRubro + 2));
                    xlsdocument.SetCellValue(rowRubro + 2, 15, "DISPONIBILIDAD DEL RUBRO");
                    xlsdocument.SetCellStyle(rowRubro + 2, 15, gastosPersonal);
                    xlsdocument.MergeWorksheetCells("S" + rowRubro, "X" + rowRubro);
                    xlsdocument.MergeWorksheetCells("S" + (rowRubro + 1), "X" + (rowRubro + 1));
                    xlsdocument.MergeWorksheetCells("S" + (rowRubro + 1), "X" + (rowRubro + 1));

                    xlsdocument.MergeWorksheetCells("A" + (rowRubro + 3), "A" + (rowRubro + 4));
                    xlsdocument.SetCellValue(rowRubro + 3, 1, "CONCEPTO");
                    xlsdocument.SetColumnWidth("A" + (rowRubro + 3), 15.0);
                    xlsdocument.SetCellStyle(rowRubro + 3, 1, gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("B" + (rowRubro + 3), "B" + (rowRubro + 4));
                    xlsdocument.SetCellValue(rowRubro + 3, 2, "NOMBRE");
                    xlsdocument.SetCellStyle(rowRubro + 3, 2, gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("C" + (rowRubro + 3), "C" + (rowRubro + 4));
                    xlsdocument.SetCellValue(rowRubro + 3, 3, "IDENTIFICACION");
                    //xlsdocument.AutoFitColumn("C"+(row+12));
                    xlsdocument.SetColumnWidth("C" + (rowRubro + 3), 25.0);
                    xlsdocument.SetCellStyle(rowRubro + 3, 3, gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("D" + (rowRubro + 3), "D" + (rowRubro + 4));
                    xlsdocument.SetCellValue(rowRubro + 3, 4, "AREA");
                    xlsdocument.SetCellStyle(rowRubro + 3, 4, gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("E" + (rowRubro + 3), "H" + (rowRubro + 3));
                    xlsdocument.SetCellValue("E" + (rowRubro + 3), "RELACION DEL VINCULO");
                    xlsdocument.SetCellStyle("E" + (rowRubro + 3), gastosPersonalCentred);
                    xlsdocument.SetCellValue("E" + (rowRubro + 4), "PREGRADO");
                    xlsdocument.SetCellStyle("E" + (rowRubro + 4), gastosPersonalCentred);
                    xlsdocument.SetColumnWidth("E" + (rowRubro + 4), 20.0);
                    xlsdocument.SetCellValue("F" + (rowRubro + 4), "POSGRADO");
                    xlsdocument.SetCellStyle("F" + (rowRubro + 4), gastosPersonalCentred);
                    xlsdocument.SetColumnWidth("F" + (rowRubro + 4), 20.0);
                    xlsdocument.SetCellValue("G" + (rowRubro + 4), "EGRESADO");
                    xlsdocument.SetCellStyle("G" + (rowRubro + 4), gastosPersonalCentred);
                    xlsdocument.SetColumnWidth("G" + (rowRubro + 4), 20.0);
                    xlsdocument.SetCellValue("H" + (rowRubro + 4), "OTRO");
                    xlsdocument.SetCellStyle("H" + (rowRubro + 4), gastosPersonalCentred);
                    xlsdocument.SetColumnWidth("H" + (rowRubro + 4), 20.0);
                    xlsdocument.MergeWorksheetCells("I" + (rowRubro + 3), "I" + (rowRubro + 4));
                    xlsdocument.SetCellValue("I" + (rowRubro + 3), "FECHA");
                    xlsdocument.SetCellStyle("I" + (rowRubro + 3), gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("J" + (rowRubro + 3), "J" + (rowRubro + 4));
                    xlsdocument.SetCellValue("J" + (rowRubro + 3), "TIPO");
                    xlsdocument.SetCellStyle("J" + (rowRubro + 3), gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("K" + (rowRubro + 3), "K" + (rowRubro + 4));
                    xlsdocument.SetCellValue("K" + (rowRubro + 3), "No.");
                    xlsdocument.SetCellStyle("K" + (rowRubro + 3), gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("L" + (rowRubro + 3), "L" + (rowRubro + 4));
                    xlsdocument.SetCellValue("L" + (rowRubro + 3), "FECHA INICIO");
                    xlsdocument.SetCellStyle("L" + (rowRubro + 3), gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("M" + (rowRubro + 3), "M" + (rowRubro + 4));
                    xlsdocument.SetCellValue("M" + (rowRubro + 3), "FECHA FINAL");
                    xlsdocument.SetCellStyle("M" + (rowRubro + 3), gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("N" + (rowRubro + 3), "N" + (rowRubro + 4));
                    xlsdocument.SetCellValue("N" + (rowRubro + 3), "ESTADO");
                    xlsdocument.SetCellStyle("N" + (rowRubro + 3), gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("O" + (rowRubro + 3), "O" + (rowRubro + 4));
                    xlsdocument.SetCellValue("O" + (rowRubro + 3), "Valor Total");
                    xlsdocument.SetCellStyle("O" + (rowRubro + 3), gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("P" + (rowRubro + 3), "P" + (rowRubro + 4));
                    xlsdocument.SetCellValue("P" + (rowRubro + 3), "Valor con 4 xmil");
                    xlsdocument.SetCellStyle("P" + (rowRubro + 3), gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("Q" + (rowRubro + 3), "V" + (rowRubro + 3));
                    xlsdocument.SetCellValue("Q" + (rowRubro + 3), "PAGOS");
                    xlsdocument.SetCellStyle("Q" + (rowRubro + 3), gastosPersonalCentred);
                    xlsdocument.SetCellValue("Q" + (rowRubro + 4), "ORPA");
                    xlsdocument.SetCellStyle("Q" + (rowRubro + 4), gastosPersonalCentred);
                    xlsdocument.SetCellValue("R" + (rowRubro + 4), "FECHA");
                    xlsdocument.SetCellStyle("R" + (rowRubro + 4), gastosPersonalCentred);
                    xlsdocument.SetCellValue("S" + (rowRubro + 4), "CP.EGR");
                    xlsdocument.SetCellStyle("S" + (rowRubro + 4), gastosPersonalCentred);
                    xlsdocument.SetCellValue("T" + (rowRubro + 4), "PERIODO");
                    xlsdocument.SetCellStyle("T" + (rowRubro + 4), gastosPersonalCentred);
                    xlsdocument.SetCellValue("U" + (rowRubro + 4), "VALOR NETO");
                    xlsdocument.SetCellStyle("U" + (rowRubro + 4), gastosPersonalCentred);
                    xlsdocument.SetCellValue("V" + (rowRubro + 4), "VALOR 4*1000");
                    xlsdocument.SetCellStyle("V" + (rowRubro + 4), gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("W" + (rowRubro + 3), "W" + (rowRubro + 4));
                    xlsdocument.SetCellValue("W" + (rowRubro + 3), "SALDO PENDIENTE");
                    xlsdocument.SetCellStyle("W" + (rowRubro + 3), gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("X" + (rowRubro + 3), "X" + (rowRubro + 4));
                    xlsdocument.SetCellValue("X" + (rowRubro + 3), "OBSERVACION");
                    xlsdocument.SetCellStyle("X" + (rowRubro + 3), gastosPersonalCentred);
                    xlsdocument.SetColumnWidth("L" + (rowRubro + 3), 25.0);
                    xlsdocument.SetColumnWidth("M" + (rowRubro + 3), 25.0);
                    xlsdocument.SetColumnWidth("N" + (rowRubro + 3), 25.0);
                    xlsdocument.SetColumnWidth("O" + (rowRubro + 3), 25.0);
                    xlsdocument.SetColumnWidth("P" + (rowRubro + 3), 25.0);
                    xlsdocument.SetColumnWidth("Q" + (rowRubro + 3), 25.0);
                    xlsdocument.SetColumnWidth("R" + (rowRubro + 3), 25.0);
                    xlsdocument.SetColumnWidth("S" + (rowRubro + 3), 25.0);
                    xlsdocument.SetColumnWidth("T" + (rowRubro + 3), 25.0);
                    xlsdocument.SetColumnWidth("U" + (rowRubro + 3), 25.0);
                    xlsdocument.SetColumnWidth("V" + (rowRubro + 3), 25.0);
                    xlsdocument.SetColumnWidth("W" + (rowRubro + 3), 25.0);
                    xlsdocument.SetColumnWidth("X" + (rowRubro + 3), 25.0);

                    id_rubro = registro.id_rubro;






                    string qryValorTotal = "select sum (valortotal) from investigacion_gasto where id_crearproyecto = @id_crearproyecto and id_partida = 1 and id_rubro = @id_rubro";
                    List<NpgsqlParameter> parameterListTotal = new List<NpgsqlParameter>();
                    parameterListTotal.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                    parameterListTotal.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                    NpgsqlParameter[] ParamTotal = parameterListTotal.ToArray();




                    var datosTotal = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryValorTotal, ParamTotal).ToList();



                    foreach (var registroN in datosTotal)
                    {
                        var cuatroxmil = (registroN.sum * 4 / 1000) + registroN.sum;
                        if (cuatroxmil != null)
                            xlsdocument.SetCellValue("S" + (rowRubro), (int)cuatroxmil);

                    }




                    string qryorpa = "select co.nombreconcepto, pe.nombrecompleto , pe.numidentificacion, rv.id_relacionvinculo, ga.fechainicio, ga.fechafinal, ga.numorden, ga.fechalegalizacionorden, ga.tipo, ga.valortotal, ga.estado, ga.id_investigaciongasto from investigacion_gasto ga join seguimiento_concepto co on ga.id_segconcepto = co.id_segconcepto join persona pe on ga.id_persona = pe.id_persona join seguimiento_relacionvinculo rv on ga.id_relacionvinculo = rv.id_relacionvinculo where ga.id_crearproyecto = @id_crearproyecto and ga.id_partida = 1 and ga.id_rubro = @id_rubro";
                    List<NpgsqlParameter> parameterListOrpa = new List<NpgsqlParameter>();
                    parameterListOrpa.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                    parameterListOrpa.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                    NpgsqlParameter[] ParamOrpa = parameterListOrpa.ToArray();

                    var datosOrpa = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryorpa, ParamOrpa).ToList();



                    if (totRow == true)
                    {
                        rowTot = rowRubro + 5;

                    }

                    totRow = false;
                    var auxrowOrpa = 0;
                    var auxOrpa2 = true;
                    var opt = true;
                    //27 tot
                    var cuatroxMil = 0;
                    var totalCuatroxMil = 0;
                    var Spendiente = 0;
                    var auxSpendiente = 0;


                    foreach (var dataorpa in datosOrpa)
                    {

                        auxOrpa2 = true;
                        if (cuatroxMil != null)
                            cuatroxMil = ((int)dataorpa.valortotal * 4 / 1000) + (int)dataorpa.valortotal;

                        id_investigaciongasto = dataorpa.id_investigaciongasto;

                        xlsdocument.SetCellValue(rowTot, 1, dataorpa.nombreconcepto);
                        xlsdocument.SetCellValue("B" + rowTot, dataorpa.nombrecompleto);
                        xlsdocument.SetCellValue("C" + rowTot, dataorpa.numidentificacion);

                        xlsdocument.SetCellValue("I" + rowTot, dataorpa.fechalegalizacionorden.ToString());
                        xlsdocument.SetCellValue("J" + rowTot, dataorpa.tipo);
                        xlsdocument.SetCellValue("K" + rowTot, dataorpa.numorden);
                        xlsdocument.SetCellValue("L" + rowTot, dataorpa.fechainicio.ToString());
                        xlsdocument.SetCellValue("M" + rowTot, dataorpa.fechafinal.ToString());
                        xlsdocument.SetCellValue("N" + rowTot, dataorpa.estado);
                        xlsdocument.SetCellValue("X" + rowTot, dataorpa.observaciones);
                        if (dataorpa.valortotal != null)
                            xlsdocument.SetCellValue("O" + rowTot, (int)dataorpa.valortotal);
                        xlsdocument.SetCellValue("P" + rowTot, cuatroxMil);
                        totalCuatroxMil += cuatroxMil;


                        opt = false;


                        if (dataorpa.id_relacionvinculo == 1 || dataorpa.id_relacionvinculo == 2)
                        {
                            xlsdocument.SetCellValue("H" + rowTot, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 3)
                        {
                            xlsdocument.SetCellValue("E" + rowTot, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 4)
                        {
                            xlsdocument.SetCellValue("F" + rowTot, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 5)
                        {
                            xlsdocument.SetCellValue("G" + rowTot, "X");

                        }



                        string qryPagos = "select ap.orpa, ap.fechapago, ap.cp_egr, sm.nmsemestre, ap.valorneto from investigacion_aplicarpago ap join investigacion_gasto ga on ap.id_investigaciongasto = ga.id_investigaciongasto join seguimiento_rubro rub on ga.id_rubro = rub.id_rubro join seguimiento_partida ru on ga.id_partida = ru.id_partida join seguimiento_concepto co on ga.id_segconcepto = co.id_segconcepto join semestre sm on ap.id_semestre = sm.id_semestre join seguimiento_relacionvinculo rv on ga.id_relacionvinculo = rv.id_relacionvinculo join persona pe on ga.id_persona = pe.id_persona where ap.id_crearproyecto = @id_crearproyecto and ru.id_partida = 1 and rub.id_rubro = @id_rubro and ga.id_investigaciongasto = @id_investigaciongasto group by  ap.orpa, ap.fechapago, ap.cp_egr, sm.nmsemestre, ap.valorneto";
                        List<NpgsqlParameter> parameterListPagos = new List<NpgsqlParameter>();
                        parameterListPagos.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                        parameterListPagos.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                        parameterListPagos.Add(new NpgsqlParameter("@id_investigaciongasto", id_investigaciongasto));
                        NpgsqlParameter[] ParamPagos = parameterListPagos.ToArray();

                        var datosPagos = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryPagos, ParamPagos).ToList();
                        var nmOrpas = datosPagos.Select(x => x.orpa).ToArray();

                        string qryEjecutado = "select sum(ap.valorneto) as ejecutado from investigacion_aplicarpago ap join investigacion_gasto ga on ap.id_investigaciongasto = ga.id_investigaciongasto join seguimiento_rubro rub on ga.id_rubro = rub.id_rubro join seguimiento_partida ru on ga.id_partida = ru.id_partida where ap.id_crearproyecto = @id_crearproyecto and ru.id_partida = 1 and rub.id_rubro = @id_rubro";
                        List<NpgsqlParameter> parameterListEjecutado = new List<NpgsqlParameter>();
                        parameterListEjecutado.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                        parameterListEjecutado.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                        NpgsqlParameter[] ParamEjecutado = parameterListEjecutado.ToArray();




                        var datosEjecutado = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryEjecutado, ParamEjecutado).ToList();



                        foreach (var registroE in datosEjecutado)
                        {
                            var cuatroxmil = (registroE.ejecutado * 4 / 1000) + registroE.ejecutado;
                            var disponibilidad = totalCuatroxMil - cuatroxmil;
                            if (cuatroxmil != null)

                                xlsdocument.SetCellValue("S" + (rowRubro + 1), (int)cuatroxmil);
                            if (disponibilidad != null)

                                xlsdocument.SetCellValue("S" + (rowRubro + 2), (int)disponibilidad);

                        }
                        auxSpendiente = 0;
                        foreach (var pagos in datosPagos)
                        {
                            if (auxOrpa2 == true)
                            {
                                auxrowOrpa = rowTot;
                            }
                            auxOrpa2 = false;
                            if (cuatropormilPagos != null)
                                cuatropormilPagos = ((int)pagos.valorneto * 4 / 1000) + (int)pagos.valorneto;
                            xlsdocument.SetCellValue("Q" + rowTot, pagos.orpa);
                            xlsdocument.SetCellValue("R" + rowTot, pagos.fechapago.ToString());
                            xlsdocument.SetCellValue("S" + rowTot, pagos.cp_egr);
                            xlsdocument.SetCellValue("T" + rowTot, pagos.nmsemestre);
                            if (pagos.valorneto != null)
                                xlsdocument.SetCellValue("U" + rowTot, (int)pagos.valorneto);
                            xlsdocument.SetCellValue("V" + rowTot, cuatropormilPagos);

                            auxSpendiente += cuatropormilPagos;

                            if (nmOrpas.Length == 1)
                            {
                                Spendiente = (int)(cuatroxMil - cuatropormilPagos);

                            }


                            rowTot++;
                        }

                        if (nmOrpas.Length == 1)
                        {
                            xlsdocument.SetCellValue("W" + (rowTot - 1), Spendiente);
                        }
                        if (nmOrpas.Length > 1)
                        {
                            Spendiente = (int)(cuatroxMil - auxSpendiente);
                            xlsdocument.SetCellValue("W" + auxrowOrpa, Spendiente);
                        }

                        if (nmOrpas.Length == 0)
                        {
                            Spendiente = cuatroxMil;
                            xlsdocument.SetCellValue("W" + rowTot, Spendiente);
                            rowTot++;
                            xlsdocument.MergeWorksheetCells("A" + auxrowOrpa, "A" + (rowTot - 2));
                            xlsdocument.MergeWorksheetCells("B" + auxrowOrpa, "B" + (rowTot - 2));
                            xlsdocument.MergeWorksheetCells("C" + auxrowOrpa, "C" + (rowTot - 2));
                            xlsdocument.MergeWorksheetCells("D" + auxrowOrpa, "D" + (rowTot - 2));
                            xlsdocument.MergeWorksheetCells("E" + auxrowOrpa, "E" + (rowTot - 2));
                            xlsdocument.MergeWorksheetCells("F" + auxrowOrpa, "F" + (rowTot - 2));
                            xlsdocument.MergeWorksheetCells("G" + auxrowOrpa, "G" + (rowTot - 2));
                            xlsdocument.MergeWorksheetCells("H" + auxrowOrpa, "H" + (rowTot - 2));
                            xlsdocument.MergeWorksheetCells("I" + auxrowOrpa, "I" + (rowTot - 2));
                            xlsdocument.MergeWorksheetCells("J" + auxrowOrpa, "J" + (rowTot - 2));
                            xlsdocument.MergeWorksheetCells("K" + auxrowOrpa, "K" + (rowTot - 2));
                            xlsdocument.MergeWorksheetCells("L" + auxrowOrpa, "L" + (rowTot - 2));
                            xlsdocument.MergeWorksheetCells("M" + auxrowOrpa, "M" + (rowTot - 2));
                            xlsdocument.MergeWorksheetCells("N" + auxrowOrpa, "N" + (rowTot - 2));
                            xlsdocument.MergeWorksheetCells("O" + auxrowOrpa, "O" + (rowTot - 2));
                            xlsdocument.MergeWorksheetCells("P" + auxrowOrpa, "P" + (rowTot - 2));
                            xlsdocument.MergeWorksheetCells("W" + auxrowOrpa, "W" + (rowTot - 2));
                            xlsdocument.MergeWorksheetCells("X" + auxrowOrpa, "X" + (rowTot - 2));
                        }
                        else
                        {
                            rowTot++;
                            xlsdocument.HideRow(rowTot - 1);
                            xlsdocument.MergeWorksheetCells("A" + auxrowOrpa, "A" + (rowTot - 1));
                            xlsdocument.MergeWorksheetCells("B" + auxrowOrpa, "B" + (rowTot - 1));
                            xlsdocument.MergeWorksheetCells("C" + auxrowOrpa, "C" + (rowTot - 1));
                            xlsdocument.MergeWorksheetCells("D" + auxrowOrpa, "D" + (rowTot - 1));
                            xlsdocument.MergeWorksheetCells("E" + auxrowOrpa, "E" + (rowTot - 1));
                            xlsdocument.MergeWorksheetCells("F" + auxrowOrpa, "F" + (rowTot - 1));
                            xlsdocument.MergeWorksheetCells("G" + auxrowOrpa, "G" + (rowTot - 1));
                            xlsdocument.MergeWorksheetCells("H" + auxrowOrpa, "H" + (rowTot - 1));
                            xlsdocument.MergeWorksheetCells("I" + auxrowOrpa, "I" + (rowTot - 1));
                            xlsdocument.MergeWorksheetCells("J" + auxrowOrpa, "J" + (rowTot - 1));
                            xlsdocument.MergeWorksheetCells("K" + auxrowOrpa, "K" + (rowTot - 1));
                            xlsdocument.MergeWorksheetCells("L" + auxrowOrpa, "L" + (rowTot - 1));
                            xlsdocument.MergeWorksheetCells("M" + auxrowOrpa, "M" + (rowTot - 1));
                            xlsdocument.MergeWorksheetCells("N" + auxrowOrpa, "N" + (rowTot - 1));
                            xlsdocument.MergeWorksheetCells("O" + auxrowOrpa, "O" + (rowTot - 1));
                            xlsdocument.MergeWorksheetCells("P" + auxrowOrpa, "P" + (rowTot - 1));
                            xlsdocument.MergeWorksheetCells("W" + auxrowOrpa, "W" + (rowTot - 1));
                            xlsdocument.MergeWorksheetCells("X" + auxrowOrpa, "X" + (rowTot - 1));
                        }

                    }
                    xlsdocument.SetCellStyle("A" + rowTot, "X" + rowTot, rowBorder);
                    rowRubNew = rowTot + 1;

                }
                rub = false;

                if (nms.Length > 1)
                {

                    if (delete == true)
                    {
                        xlsdocument.DeleteRow(22, (rowRubNew - 22));
                        //rowRubNew = rowRubNew - 21;
                        xlsdocument.HideRow(rowRubro, rowRubNew - 1);
                    }
                    delete = false;
                    xlsdocument.SetCellValue(rowRubNew, 1, "RUBRO");
                    xlsdocument.SetCellStyle(rowRubNew, 1, gastosPersonal);
                    xlsdocument.SetCellValue(rowRubNew, 2, registro.nombrerubro);
                    xlsdocument.MergeWorksheetCells("A" + rowRubNew, "A" + (rowRubNew + 2));
                    xlsdocument.MergeWorksheetCells("B" + rowRubNew, "N" + (rowRubNew + 2));
                    xlsdocument.MergeWorksheetCells("O" + rowRubNew, "R" + rowRubNew);
                    xlsdocument.SetCellValue(rowRubNew, 15, "VALOR");
                    xlsdocument.SetCellStyle(rowRubNew, 15, gastosPersonal);
                    xlsdocument.MergeWorksheetCells("O" + (rowRubNew + 1), "R" + (rowRubNew + 1));
                    xlsdocument.SetCellValue(rowRubNew + 1, 15, "EJECUTADO");
                    xlsdocument.SetCellStyle(rowRubNew + 1, 15, gastosPersonal);
                    xlsdocument.MergeWorksheetCells("O" + (rowRubNew + 2), "R" + (rowRubNew + 2));
                    xlsdocument.SetCellValue(rowRubNew + 2, 15, "DISPONIBILIDAD DEL RUBRO");
                    xlsdocument.SetCellStyle(rowRubNew + 2, 15, gastosPersonal);
                    xlsdocument.MergeWorksheetCells("S" + rowRubNew, "X" + rowRubNew);
                    xlsdocument.MergeWorksheetCells("S" + (rowRubNew + 1), "X" + (rowRubNew + 1));
                    xlsdocument.MergeWorksheetCells("S" + (rowRubNew + 2), "X" + (rowRubNew + 2));
                    xlsdocument.MergeWorksheetCells("A" + (rowRubNew + 3), "A" + (rowRubNew + 4));
                    xlsdocument.SetCellValue(rowRubNew + 3, 1, "CONCEPTO");
                    xlsdocument.SetColumnWidth("A" + (rowRubNew + 3), 15.0);
                    xlsdocument.SetCellStyle(rowRubNew + 3, 1, gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("B" + (rowRubNew + 3), "B" + (rowRubNew + 4));
                    xlsdocument.SetCellValue(rowRubNew + 3, 2, "NOMBRE");
                    xlsdocument.SetCellStyle(rowRubNew + 3, 2, gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("C" + (rowRubNew + 3), "C" + (rowRubNew + 4));
                    xlsdocument.SetCellValue(rowRubNew + 3, 3, "IDENTIFICACION");
                    xlsdocument.SetColumnWidth("C" + (rowRubNew + 3), 25.0);
                    xlsdocument.SetCellStyle(rowRubNew + 3, 3, gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("D" + (rowRubNew + 3), "D" + (rowRubNew + 4));
                    xlsdocument.SetCellValue(rowRubNew + 3, 4, "AREA");
                    xlsdocument.SetCellStyle(rowRubNew + 3, 4, gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("E" + (rowRubNew + 3), "H" + (rowRubNew + 3));
                    xlsdocument.SetCellValue("E" + (rowRubNew + 3), "RELACION DEL VINCULO");
                    xlsdocument.SetCellStyle("E" + (rowRubNew + 3), gastosPersonalCentred);
                    xlsdocument.SetCellValue("E" + (rowRubNew + 4), "PREGRADO");
                    xlsdocument.SetCellStyle("E" + (rowRubNew + 4), gastosPersonalCentred);
                    xlsdocument.SetColumnWidth("E" + (rowRubNew + 4), 20.0);
                    xlsdocument.SetCellValue("F" + (rowRubNew + 4), "POSGRADO");
                    xlsdocument.SetCellStyle("F" + (rowRubNew + 4), gastosPersonalCentred);
                    xlsdocument.SetColumnWidth("F" + (rowRubNew + 4), 20.0);
                    xlsdocument.SetCellValue("G" + (rowRubNew + 4), "EGRESADO");
                    xlsdocument.SetCellStyle("G" + (rowRubNew + 4), gastosPersonalCentred);
                    xlsdocument.SetColumnWidth("G" + (rowRubNew + 4), 20.0);
                    xlsdocument.SetCellValue("H" + (rowRubNew + 4), "OTRO");
                    xlsdocument.SetCellStyle("H" + (rowRubNew + 4), gastosPersonalCentred);
                    xlsdocument.SetColumnWidth("H" + (rowRubNew + 4), 20.0);
                    xlsdocument.MergeWorksheetCells("I" + (rowRubNew + 3), "I" + (rowRubNew + 4));
                    xlsdocument.SetCellValue("I" + (rowRubNew + 3), "FECHA");
                    xlsdocument.SetCellStyle("I" + (rowRubNew + 3), gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("J" + (rowRubNew + 3), "J" + (rowRubNew + 4));
                    xlsdocument.SetCellValue("J" + (rowRubNew + 3), "TIPO");
                    xlsdocument.SetCellStyle("J" + (rowRubNew + 3), gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("K" + (rowRubNew + 3), "K" + (rowRubNew + 4));
                    xlsdocument.SetCellValue("K" + (rowRubNew + 3), "No.");
                    xlsdocument.SetCellStyle("K" + (rowRubNew + 3), gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("L" + (rowRubNew + 3), "L" + (rowRubNew + 4));
                    xlsdocument.SetCellValue("L" + (rowRubNew + 3), "FECHA INICIO");
                    xlsdocument.SetCellStyle("L" + (rowRubNew + 3), gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("M" + (rowRubNew + 3), "M" + (rowRubNew + 4));
                    xlsdocument.SetCellValue("M" + (rowRubNew + 3), "FECHA FINAL");
                    xlsdocument.SetCellStyle("M" + (rowRubNew + 3), gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("N" + (rowRubNew + 3), "N" + (rowRubNew + 4));
                    xlsdocument.SetCellValue("N" + (rowRubNew + 3), "ESTADO");
                    xlsdocument.SetCellStyle("N" + (rowRubNew + 3), gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("O" + (rowRubNew + 3), "O" + (rowRubNew + 4));
                    xlsdocument.SetCellValue("O" + (rowRubNew + 3), "Valor Total");
                    xlsdocument.SetCellStyle("O" + (rowRubNew + 3), gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("P" + (rowRubNew + 3), "P" + (rowRubNew + 4));
                    xlsdocument.SetCellValue("P" + (rowRubNew + 3), "Valor con 4 xmil");
                    xlsdocument.SetCellStyle("P" + (rowRubNew + 3), gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("Q" + (rowRubNew + 3), "V" + (rowRubNew + 3));
                    xlsdocument.SetCellValue("Q" + (rowRubNew + 3), "PAGOS");
                    xlsdocument.SetCellStyle("Q" + (rowRubNew + 3), gastosPersonalCentred);
                    xlsdocument.SetCellValue("Q" + (rowRubNew + 4), "ORPA");
                    xlsdocument.SetCellStyle("Q" + (rowRubNew + 4), gastosPersonalCentred);
                    xlsdocument.SetCellValue("R" + (rowRubNew + 4), "FECHA");
                    xlsdocument.SetCellStyle("R" + (rowRubNew + 4), gastosPersonalCentred);
                    xlsdocument.SetCellValue("S" + (rowRubNew + 4), "CP.EGR");
                    xlsdocument.SetCellStyle("S" + (rowRubNew + 4), gastosPersonalCentred);
                    xlsdocument.SetCellValue("T" + (rowRubNew + 4), "PERIODO");
                    xlsdocument.SetCellStyle("T" + (rowRubNew + 4), gastosPersonalCentred);
                    xlsdocument.SetCellValue("U" + (rowRubNew + 4), "VALOR NETO");
                    xlsdocument.SetCellStyle("U" + (rowRubNew + 4), gastosPersonalCentred);
                    xlsdocument.SetCellValue("V" + (rowRubNew + 4), "VALOR 4*1000");
                    xlsdocument.SetCellStyle("V" + (rowRubNew + 4), gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("W" + (rowRubNew + 3), "W" + (rowRubNew + 4));
                    xlsdocument.SetCellValue("W" + (rowRubNew + 3), "SALDO PENDIENTE");
                    xlsdocument.SetCellStyle("W" + (rowRubNew + 3), gastosPersonalCentred);
                    xlsdocument.MergeWorksheetCells("X" + (rowRubNew + 3), "X" + (rowRubNew + 4));
                    xlsdocument.SetCellValue("X" + (rowRubNew + 3), "OBSERVACION");
                    xlsdocument.SetCellStyle("X" + (rowRubNew + 3), gastosPersonalCentred);
                    xlsdocument.SetColumnWidth("L" + (rowRubNew + 3), 25.0);
                    xlsdocument.SetColumnWidth("M" + (rowRubNew + 3), 25.0);
                    xlsdocument.SetColumnWidth("N" + (rowRubNew + 3), 25.0);
                    xlsdocument.SetColumnWidth("O" + (rowRubNew + 3), 25.0);
                    xlsdocument.SetColumnWidth("P" + (rowRubNew + 3), 25.0);
                    xlsdocument.SetColumnWidth("Q" + (rowRubNew + 3), 25.0);
                    xlsdocument.SetColumnWidth("R" + (rowRubNew + 3), 25.0);
                    xlsdocument.SetColumnWidth("S" + (rowRubNew + 3), 25.0);
                    xlsdocument.SetColumnWidth("T" + (rowRubNew + 3), 25.0);
                    xlsdocument.SetColumnWidth("U" + (rowRubNew + 3), 25.0);
                    xlsdocument.SetColumnWidth("V" + (rowRubNew + 3), 25.0);
                    xlsdocument.SetColumnWidth("W" + (rowRubNew + 3), 25.0);
                    xlsdocument.SetColumnWidth("X" + (rowRubNew + 3), 25.0);

                    id_rubro = registro.id_rubro;


                    //Incluimos el valor total por concepto 


                    string qryValorTotal = "select sum (valortotal) from investigacion_gasto where id_crearproyecto = @id_crearproyecto and id_partida = 1 and id_rubro = @id_rubro";
                    List<NpgsqlParameter> parameterListTotal = new List<NpgsqlParameter>();
                    parameterListTotal.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                    parameterListTotal.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                    NpgsqlParameter[] ParamTotal = parameterListTotal.ToArray();




                    var datosTotal = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryValorTotal, ParamTotal).ToList();



                    foreach (var registroN in datosTotal)
                    {
                        var cuatroxmil = (registroN.sum * 4 / 1000) + registroN.sum;
                        if (cuatroxmil != null)
                            xlsdocument.SetCellValue("S" + (rowRubNew), (int)cuatroxmil);

                    }


                    string qryorpa = "select co.nombreconcepto, pe.nombrecompleto , pe.numidentificacion, rv.id_relacionvinculo, ga.fechainicio, ga.fechafinal, ga.numorden, ga.fechalegalizacionorden, ga.tipo, ga.valortotal, ga.estado, ga.id_investigaciongasto from investigacion_gasto ga join seguimiento_concepto co on ga.id_segconcepto = co.id_segconcepto join persona pe on ga.id_persona = pe.id_persona join seguimiento_relacionvinculo rv on ga.id_relacionvinculo = rv.id_relacionvinculo where ga.id_crearproyecto = @id_crearproyecto and ga.id_partida = 1 and ga.id_rubro = @id_rubro";
                    List<NpgsqlParameter> parameterListOrpa = new List<NpgsqlParameter>();
                    parameterListOrpa.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                    parameterListOrpa.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                    NpgsqlParameter[] ParamOrpa = parameterListOrpa.ToArray();

                    var datosOrpa = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryorpa, ParamOrpa).ToList();




                    var auxrowOrpa = 0;
                    var auxOrpa2 = true;
                    var optSec = true;
                    //27 tot
                    var aux = rowRubNew + 5;

                    var rowOrpa = aux;
                    var cuatroxMil = 0;
                    optOrpa = false;
                    var totalCuatroxMil = 0;
                    var Spendiente = 0;
                    var auxSpendiente = 0;
                    //
                    foreach (var dataorpa in datosOrpa)
                    {
                        if (cuatroxMil != null)
                            cuatroxMil = ((int)dataorpa.valortotal * 4 / 1000) + (int)dataorpa.valortotal;
                        auxOrpa2 = true;
                        id_investigaciongasto = dataorpa.id_investigaciongasto;

                        xlsdocument.SetCellValue(rowOrpa, 1, dataorpa.nombreconcepto);
                        xlsdocument.SetCellValue("B" + rowOrpa, dataorpa.nombrecompleto);
                        xlsdocument.SetCellValue("C" + rowOrpa, dataorpa.numidentificacion);
                        xlsdocument.SetCellValue("I" + rowOrpa, dataorpa.fechalegalizacionorden.ToString());
                        xlsdocument.SetCellValue("J" + rowOrpa, dataorpa.tipo);
                        xlsdocument.SetCellValue("K" + rowOrpa, dataorpa.numorden);
                        xlsdocument.SetCellValue("L" + rowOrpa, dataorpa.fechainicio.ToString());
                        xlsdocument.SetCellValue("M" + rowOrpa, dataorpa.fechafinal.ToString());
                        xlsdocument.SetCellValue("N" + rowOrpa, dataorpa.estado);
                        xlsdocument.SetCellValue("X" + rowOrpa, dataorpa.observaciones);
                        if (dataorpa.valortotal != null)
                            xlsdocument.SetCellValue("O" + rowOrpa, (int)dataorpa.valortotal);
                        xlsdocument.SetCellValue("P" + rowOrpa, cuatroxMil);
                        //vTot += cuatroxMil/2;
                        totalCuatroxMil += cuatroxMil;



                        if (dataorpa.id_relacionvinculo == 1 || dataorpa.id_relacionvinculo == 2)
                        {
                            xlsdocument.SetCellValue("H" + rowOrpa, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 3)
                        {
                            xlsdocument.SetCellValue("E" + rowOrpa, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 4)
                        {
                            xlsdocument.SetCellValue("F" + rowOrpa, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 5)
                        {
                            xlsdocument.SetCellValue("G" + rowOrpa, "X");

                        }


                        string qryPagos = "select ap.orpa, ap.fechapago, ap.cp_egr, sm.nmsemestre, ap.valorneto from investigacion_aplicarpago ap join investigacion_gasto ga on ap.id_investigaciongasto = ga.id_investigaciongasto join seguimiento_rubro rub on ga.id_rubro = rub.id_rubro join seguimiento_partida ru on ga.id_partida = ru.id_partida join seguimiento_concepto co on ga.id_segconcepto = co.id_segconcepto join semestre sm on ap.id_semestre = sm.id_semestre join seguimiento_relacionvinculo rv on ga.id_relacionvinculo = rv.id_relacionvinculo join persona pe on ga.id_persona = pe.id_persona where ap.id_crearproyecto = @id_crearproyecto and ru.id_partida = 1 and rub.id_rubro = @id_rubro and ga.id_investigaciongasto = @id_investigaciongasto group by  ap.orpa" +
                            ", ap.fechapago, ap.cp_egr, sm.nmsemestre, ap.valorneto";
                        List<NpgsqlParameter> parameterListPagos = new List<NpgsqlParameter>();
                        parameterListPagos.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                        parameterListPagos.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                        parameterListPagos.Add(new NpgsqlParameter("@id_investigaciongasto", id_investigaciongasto));
                        NpgsqlParameter[] ParamPagos = parameterListPagos.ToArray();

                        var datosPagos = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryPagos, ParamPagos).ToList();


                        var nmOrpas = datosPagos.Select(x => x.orpa).ToArray();

                        string qryEjecutado = "select sum(ap.valorneto) as ejecutado from investigacion_aplicarpago ap join investigacion_gasto ga on ap.id_investigaciongasto = ga.id_investigaciongasto join seguimiento_rubro rub on ga.id_rubro = rub.id_rubro join seguimiento_partida ru on ga.id_partida = ru.id_partida where ap.id_crearproyecto = @id_crearproyecto and ru.id_partida = 1 and rub.id_rubro = @id_rubro";
                        List<NpgsqlParameter> parameterListEjecutado = new List<NpgsqlParameter>();
                        parameterListEjecutado.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                        parameterListEjecutado.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                        NpgsqlParameter[] ParamEjecutado = parameterListEjecutado.ToArray();




                        var datosEjecutado = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryEjecutado, ParamEjecutado).ToList();


                        foreach (var registroE in datosEjecutado)
                        {
                            var cuatroxmil = (registroE.ejecutado * 4 / 1000) + registroE.ejecutado;
                            var disponibilidad = totalCuatroxMil - cuatroxmil;

                            if (cuatroxmil != null)
                                xlsdocument.SetCellValue("S" + (rowRubNew + 1), (int)cuatroxmil);
                            if (disponibilidad != null)

                                xlsdocument.SetCellValue("S" + (rowRubNew + 2), (int)disponibilidad);



                        }
                        auxSpendiente = 0;
                        foreach (var pagos in datosPagos)
                        {
                            if (auxOrpa2 == true)
                            {
                                auxrowOrpa = rowOrpa;
                            }
                            auxOrpa2 = false;
                            if (cuatropormilPagos != null)
                                cuatropormilPagos = ((int)pagos.valorneto * 4 / 1000) + (int)pagos.valorneto;
                            xlsdocument.SetCellValue("Q" + rowOrpa, pagos.orpa);
                            xlsdocument.SetCellValue("R" + rowOrpa, pagos.fechapago.ToString());
                            xlsdocument.SetCellValue("S" + rowOrpa, pagos.cp_egr);
                            xlsdocument.SetCellValue("T" + rowOrpa, pagos.nmsemestre);
                            if (pagos.valorneto != null)
                                xlsdocument.SetCellValue("U" + rowOrpa, (int)pagos.valorneto);
                            xlsdocument.SetCellValue("V" + rowOrpa, cuatropormilPagos);
                            auxSpendiente += cuatropormilPagos;

                            if (nmOrpas.Length == 1)
                            {
                                Spendiente = (int)(cuatroxMil - cuatropormilPagos);

                            }



                            rowOrpa++;


                        }

                        if (nmOrpas.Length == 1)
                        {
                            xlsdocument.SetCellValue("W" + (rowOrpa - 1), Spendiente);
                        }
                        if (nmOrpas.Length > 1)
                        {
                            Spendiente = (int)(cuatroxMil - auxSpendiente);
                            xlsdocument.SetCellValue("W" + auxrowOrpa, Spendiente);
                        }

                        if (nmOrpas.Length == 0)
                        {
                            Spendiente = cuatroxMil;
                            xlsdocument.SetCellValue("W" + rowOrpa, Spendiente);
                            rowOrpa++;
                            xlsdocument.MergeWorksheetCells("A" + auxrowOrpa, "A" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("B" + auxrowOrpa, "B" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("C" + auxrowOrpa, "C" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("D" + auxrowOrpa, "D" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("E" + auxrowOrpa, "E" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("F" + auxrowOrpa, "F" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("G" + auxrowOrpa, "G" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("H" + auxrowOrpa, "H" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("I" + auxrowOrpa, "I" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("J" + auxrowOrpa, "J" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("K" + auxrowOrpa, "K" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("L" + auxrowOrpa, "L" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("M" + auxrowOrpa, "M" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("N" + auxrowOrpa, "N" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("O" + auxrowOrpa, "O" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("P" + auxrowOrpa, "P" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("W" + auxrowOrpa, "W" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("X" + auxrowOrpa, "X" + (rowOrpa - 2));
                        }
                        else
                        {
                            xlsdocument.MergeWorksheetCells("A" + auxrowOrpa, "A" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("B" + auxrowOrpa, "B" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("C" + auxrowOrpa, "C" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("D" + auxrowOrpa, "D" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("E" + auxrowOrpa, "E" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("F" + auxrowOrpa, "F" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("G" + auxrowOrpa, "G" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("H" + auxrowOrpa, "H" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("I" + auxrowOrpa, "I" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("J" + auxrowOrpa, "J" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("K" + auxrowOrpa, "K" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("L" + auxrowOrpa, "L" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("M" + auxrowOrpa, "M" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("N" + auxrowOrpa, "N" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("O" + auxrowOrpa, "O" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("P" + auxrowOrpa, "P" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("W" + auxrowOrpa, "W" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("X" + auxrowOrpa, "X" + (rowOrpa - 1));
                        }
                    }
                    auxOrpa = rowOrpa;
                    xlsdocument.SetCellStyle("A" + rowOrpa, "X" + rowOrpa, rowBorder);
                    rowRubNew = rowRubNew + (auxOrpa - rowRubNew) + 1;
                    rowSer = rowRubNew;
                }

            }
            if (nms.Length == 1)
            {
                rowSer = rowRubNew;

            }
            else if (nms.Length == 0)
            {
                rowSer = 18;
            }
            SLStyle adquisicionBienes = xlsdocument.CreateStyle();
            SLStyle adquisicionBienesCentred = xlsdocument.CreateStyle();

            adquisicionBienes.Font.FontName = "Times New Roman";
            adquisicionBienes.Font.FontSize = 14.0;
            adquisicionBienes.Font.Bold = true;
            adquisicionBienes.Alignment.Horizontal = HorizontalAlignmentValues.Left;
            adquisicionBienes.Alignment.Vertical = VerticalAlignmentValues.Center;
            adquisicionBienes.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.FromArgb(0, 255, 0), System.Drawing.Color.Blue);

            adquisicionBienesCentred.Font.FontName = "Times New Roman";
            adquisicionBienesCentred.Font.FontSize = 14.0;
            adquisicionBienesCentred.Font.Bold = true;
            adquisicionBienesCentred.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            adquisicionBienesCentred.Alignment.Vertical = VerticalAlignmentValues.Center;
            adquisicionBienesCentred.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.FromArgb(0, 255, 0), System.Drawing.Color.Blue);


            xlsdocument.MergeWorksheetCells(rowSer, 1, rowSer, 24);
            xlsdocument.SetCellValue(rowSer, 1, "2. ADQUISICION DE BIENES");
            xlsdocument.SetCellStyle(rowSer, 1, adquisicionBienes);
            xlsdocument.SetCellStyle("A" + (rowSer + 1), "X" + (rowSer + 1), rowBorder);
            xlsdocument.SetRowHeight(rowSer + 1, 11.0);


            string qryBienes = "select DISTINCT ru.nombrerubro, ru.id_rubro from investigacion_gasto ga join seguimiento_rubro ru on ga.id_rubro = ru.id_rubro where ga.id_crearproyecto=@id_crearproyecto and ga.id_partida = 2";
            List<NpgsqlParameter> parameterListBienes = new List<NpgsqlParameter>();
            parameterListBienes.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
            NpgsqlParameter[] ParamBienes = parameterListBienes.ToArray();

            var datosbienes = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryBienes, ParamBienes).ToList();

            var nmsBienes = datosbienes.Select(x => x.nombreconcepto).ToArray();


            var rub2 = true;
            foreach (var registro in datosbienes)
            {

                if (rub2 == true)
                {

                    xlsdocument.SetCellValue(rowSer + 2, 1, "RUBRO");
                    xlsdocument.SetCellStyle(rowSer + 2, 1, adquisicionBienesCentred);
                    xlsdocument.SetCellValue(rowSer + 2, 2, registro.nombrerubro);
                    xlsdocument.MergeWorksheetCells("A" + (rowSer + 2), "A" + (rowSer + 4));
                    xlsdocument.MergeWorksheetCells("B" + (rowSer + 2), "N" + (rowSer + 4));
                    xlsdocument.MergeWorksheetCells("O" + (rowSer + 2), "R" + (rowSer + 2));
                    xlsdocument.SetCellValue(rowSer + 2, 15, "VALOR");
                    xlsdocument.SetCellStyle(rowSer + 2, 15, adquisicionBienes);
                    xlsdocument.MergeWorksheetCells("O" + (rowSer + 4), "R" + (rowSer + 4));
                    xlsdocument.SetCellValue(rowSer + 3, 15, "EJECUTADO");


                    xlsdocument.SetCellStyle(rowSer + 3, 15, adquisicionBienes);
                    xlsdocument.MergeWorksheetCells("O" + (rowSer + 3), "R" + (rowSer + 3));
                    xlsdocument.SetCellValue(rowSer + 4, 15, "DISPONIBILIDAD DEL RUBRO");
                    xlsdocument.SetCellStyle(rowSer + 4, 15, adquisicionBienes);
                    xlsdocument.MergeWorksheetCells("S" + (rowSer + 2), "X" + (rowSer + 2));
                    xlsdocument.MergeWorksheetCells("S" + (rowSer + 3), "X" + (rowSer + 3));
                    xlsdocument.MergeWorksheetCells("S" + (rowSer + 4), "X" + (rowSer + 4));


                    xlsdocument.MergeWorksheetCells("A" + (rowSer + 5), "A" + (rowSer + 6));
                    xlsdocument.SetCellValue(rowSer + 5, 1, "CONCEPTO");
                    xlsdocument.SetColumnWidth("A" + (rowSer + 5), 15.0);
                    xlsdocument.SetCellStyle(rowSer + 5, 1, adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("B" + (rowSer + 5), "B" + (rowSer + 6));
                    xlsdocument.SetCellValue(rowSer + 5, 2, "NOMBRE");
                    xlsdocument.SetCellStyle(rowSer + 5, 2, adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("C" + (rowSer + 5), "C" + (rowSer + 6));
                    xlsdocument.SetCellValue(rowSer + 5, 3, "IDENTIFICACION");
                    //xlsdocument.AutoFitColumn("C"+(row+12));
                    xlsdocument.SetColumnWidth("C" + (rowSer + 5), 25.0);
                    xlsdocument.SetCellStyle(rowSer + 5, 3, adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("D" + (rowSer + 5), "D" + (rowSer + 6));
                    xlsdocument.SetCellValue(rowSer + 5, 4, "AREA");
                    xlsdocument.SetCellStyle(rowSer + 5, 4, adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("E" + (rowSer + 5), "H" + (rowSer + 5));
                    xlsdocument.SetCellValue("E" + (rowSer + 5), "RELACION DEL VINCULO");
                    xlsdocument.SetCellStyle("E" + (rowSer + 5), adquisicionBienesCentred);
                    xlsdocument.SetCellValue("E" + (rowSer + 6), "PREGRADO");
                    xlsdocument.SetCellStyle("E" + (rowSer + 6), adquisicionBienesCentred);
                    xlsdocument.SetColumnWidth("E" + (rowSer + 6), 20.0);
                    xlsdocument.SetCellValue("F" + (rowSer + 6), "POSGRADO");
                    xlsdocument.SetCellStyle("F" + (rowSer + 6), adquisicionBienesCentred);
                    xlsdocument.SetColumnWidth("F" + (rowSer + 6), 20.0);
                    xlsdocument.SetCellValue("G" + (rowSer + 6), "EGRESADO");
                    xlsdocument.SetCellStyle("G" + (rowSer + 6), adquisicionBienesCentred);
                    xlsdocument.SetColumnWidth("G" + (rowSer + 6), 20.0);
                    xlsdocument.SetCellValue("H" + (rowSer + 6), "OTRO");
                    xlsdocument.SetCellStyle("H" + (rowSer + 6), adquisicionBienesCentred);
                    xlsdocument.SetColumnWidth("H" + (rowSer + 6), 20.0);
                    xlsdocument.MergeWorksheetCells("I" + (rowSer + 5), "I" + (rowSer + 6));
                    xlsdocument.SetCellValue("I" + (rowSer + 5), "FECHA");
                    xlsdocument.SetCellStyle("I" + (rowSer + 5), adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("J" + (rowSer + 5), "J" + (rowSer + 6));
                    xlsdocument.SetCellValue("J" + (rowSer + 5), "TIPO");
                    xlsdocument.SetCellStyle("J" + (rowSer + 5), adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("K" + (rowSer + 5), "K" + (rowSer + 6));
                    xlsdocument.SetCellValue("K" + (rowSer + 5), "No.");
                    xlsdocument.SetCellStyle("K" + (rowSer + 5), adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("L" + (rowSer + 5), "L" + (rowSer + 6));
                    xlsdocument.SetCellValue("L" + (rowSer + 5), "FECHA INICIO");
                    xlsdocument.SetCellStyle("L" + (rowSer + 5), adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("M" + (rowSer + 5), "M" + (rowSer + 6));
                    xlsdocument.SetCellValue("M" + (rowSer + 5), "FECHA FINAL");
                    xlsdocument.SetCellStyle("M" + (rowSer + 5), adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("N" + (rowSer + 5), "N" + (rowSer + 6));
                    xlsdocument.SetCellValue("N" + (rowSer + 5), "ESTADO");
                    xlsdocument.SetCellStyle("N" + (rowSer + 5), adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("O" + (rowSer + 5), "O" + (rowSer + 6));
                    xlsdocument.SetCellValue("O" + (rowSer + 5), "Valor Total");
                    xlsdocument.SetCellStyle("O" + (rowSer + 5), adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("P" + (rowSer + 5), "P" + (rowSer + 6));
                    xlsdocument.SetCellValue("P" + (rowSer + 5), "Valor con 4 xmil");
                    xlsdocument.SetCellStyle("P" + (rowSer + 5), adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("Q" + (rowSer + 5), "V" + (rowSer + 5));
                    xlsdocument.SetCellValue("Q" + (rowSer + 5), "PAGOS");
                    xlsdocument.SetCellStyle("Q" + (rowSer + 5), adquisicionBienesCentred);
                    xlsdocument.SetCellValue("Q" + (rowSer + 6), "ORPA");
                    xlsdocument.SetCellStyle("Q" + (rowSer + 6), adquisicionBienesCentred);
                    xlsdocument.SetCellValue("R" + (rowSer + 6), "FECHA");
                    xlsdocument.SetCellStyle("R" + (rowSer + 6), adquisicionBienesCentred);
                    xlsdocument.SetCellValue("S" + (rowSer + 6), "CP.EGR");
                    xlsdocument.SetCellStyle("S" + (rowSer + 6), adquisicionBienesCentred);
                    xlsdocument.SetCellValue("T" + (rowSer + 6), "PERIODO");
                    xlsdocument.SetCellStyle("T" + (rowSer + 6), adquisicionBienesCentred);
                    xlsdocument.SetCellValue("U" + (rowSer + 6), "VALOR NETO");
                    xlsdocument.SetCellStyle("U" + (rowSer + 6), adquisicionBienesCentred);
                    xlsdocument.SetCellValue("V" + (rowSer + 6), "VALOR 4*1000");
                    xlsdocument.SetCellStyle("V" + (rowSer + 6), adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("W" + (rowSer + 5), "W" + (rowSer + 6));
                    xlsdocument.SetCellValue("W" + (rowSer + 5), "SALDO PENDIENTE");
                    xlsdocument.SetCellStyle("W" + (rowSer + 5), adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("X" + (rowSer + 5), "X" + (rowSer + 6));
                    xlsdocument.SetCellValue("X" + (rowSer + 5), "OBSERVACION");
                    xlsdocument.SetCellStyle("X" + (rowSer + 5), adquisicionBienesCentred);
                    xlsdocument.SetColumnWidth("L" + (rowSer + 5), 25.0);
                    xlsdocument.SetColumnWidth("M" + (rowSer + 5), 25.0);
                    xlsdocument.SetColumnWidth("N" + (rowSer + 5), 25.0);
                    xlsdocument.SetColumnWidth("O" + (rowSer + 5), 25.0);
                    xlsdocument.SetColumnWidth("P" + (rowSer + 5), 25.0);
                    xlsdocument.SetColumnWidth("Q" + (rowSer + 5), 25.0);
                    xlsdocument.SetColumnWidth("R" + (rowSer + 5), 25.0);
                    xlsdocument.SetColumnWidth("S" + (rowSer + 5), 25.0);
                    xlsdocument.SetColumnWidth("T" + (rowSer + 5), 25.0);
                    xlsdocument.SetColumnWidth("U" + (rowSer + 5), 25.0);
                    xlsdocument.SetColumnWidth("V" + (rowSer + 5), 25.0);
                    xlsdocument.SetColumnWidth("W" + (rowSer + 5), 25.0);
                    xlsdocument.SetColumnWidth("X" + (rowSer + 5), 25.0);


                    id_rubro = registro.id_rubro;


                    //Incluimos el valor total por concepto 
                    string qryValorTotal = "select sum (valortotal) from investigacion_gasto where id_crearproyecto = @id_crearproyecto and id_partida = 2 and id_rubro = @id_rubro";
                    List<NpgsqlParameter> parameterListTotal = new List<NpgsqlParameter>();
                    parameterListTotal.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                    parameterListTotal.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                    NpgsqlParameter[] ParamTotal = parameterListTotal.ToArray();




                    var datosTotal = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryValorTotal, ParamTotal).ToList();



                    foreach (var registroN in datosTotal)
                    {
                        var cuatroxmil = (registroN.sum * 4 / 1000) + registroN.sum;
                        if (cuatroxmil != null)
                            xlsdocument.SetCellValue("S" + (rowSer + 2), (int)cuatroxmil);

                    }

                    string qryorpa = "select co.nombreconcepto, pe.nombrecompleto , pe.numidentificacion, rv.id_relacionvinculo, ga.fechainicio, ga.fechafinal, ga.numorden, ga.fechalegalizacionorden, ga.tipo, ga.valortotal, ga.estado, ga.id_investigaciongasto from investigacion_gasto ga join seguimiento_concepto co on ga.id_segconcepto = co.id_segconcepto join persona pe on ga.id_persona = pe.id_persona join seguimiento_relacionvinculo rv on ga.id_relacionvinculo = rv.id_relacionvinculo where ga.id_crearproyecto = @id_crearproyecto and ga.id_partida = 2 and ga.id_rubro = @id_rubro";
                    List<NpgsqlParameter> parameterListOrpa = new List<NpgsqlParameter>();
                    parameterListOrpa.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                    parameterListOrpa.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                    NpgsqlParameter[] ParamOrpa = parameterListOrpa.ToArray();

                    var datosOrpa = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryorpa, ParamOrpa).ToList();




                    var auxrowOrpa = 0;
                    var auxOrpa2 = true;


                    var opt = true;
                    //27 tot
                    var cuatroxMil = 0;
                    var totalCuatroxMil = 0;
                    var Spendiente = 0;
                    var auxSpendiente = 0;

                    if (rowBie == true)
                    {
                        rowbienes = rowSer + 7;
                    }
                    rowBie = false;

                    foreach (var dataorpa in datosOrpa)
                    {

                        auxOrpa2 = true;
                        id_investigaciongasto = dataorpa.id_investigaciongasto;
                        if (cuatroxMil != null)
                            cuatroxMil = ((int)dataorpa.valortotal * 4 / 1000) + (int)dataorpa.valortotal;
                        totalCuatroxMil += cuatroxMil;

                        xlsdocument.SetCellValue(rowbienes, 1, dataorpa.nombreconcepto);
                        xlsdocument.SetCellValue("B" + rowbienes, dataorpa.nombrecompleto);
                        xlsdocument.SetCellValue("C" + rowbienes, dataorpa.numidentificacion);
                        xlsdocument.SetCellValue("I" + rowbienes, dataorpa.fechalegalizacionorden.ToString());
                        xlsdocument.SetCellValue("J" + rowbienes, dataorpa.tipo);
                        xlsdocument.SetCellValue("K" + rowbienes, dataorpa.numorden);
                        xlsdocument.SetCellValue("L" + rowbienes, dataorpa.fechainicio.ToString());
                        xlsdocument.SetCellValue("M" + rowbienes, dataorpa.fechafinal.ToString());
                        xlsdocument.SetCellValue("N" + rowbienes, dataorpa.estado);
                        xlsdocument.SetCellValue("X" + rowbienes, dataorpa.observaciones);
                        if (dataorpa.valortotal != null)
                            xlsdocument.SetCellValue("O" + rowbienes, (int)dataorpa.valortotal);
                        xlsdocument.SetCellValue("P" + rowbienes, cuatroxMil);

                        opt = false;


                        if (dataorpa.id_relacionvinculo == 1 || dataorpa.id_relacionvinculo == 2)
                        {
                            xlsdocument.SetCellValue("H" + rowbienes, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 3)
                        {
                            xlsdocument.SetCellValue("E" + rowbienes, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 4)
                        {
                            xlsdocument.SetCellValue("F" + rowbienes, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 5)
                        {
                            xlsdocument.SetCellValue("G" + rowbienes, "X");

                        }


                        string qryPagos = "select ap.orpa, ap.fechapago, ap.cp_egr, sm.nmsemestre, ap.valorneto from investigacion_aplicarpago ap join investigacion_gasto ga on ap.id_investigaciongasto = ga.id_investigaciongasto join seguimiento_rubro rub on ga.id_rubro = rub.id_rubro join seguimiento_partida ru on ga.id_partida = ru.id_partida join seguimiento_concepto co on ga.id_segconcepto = co.id_segconcepto join semestre sm on ap.id_semestre = sm.id_semestre join seguimiento_relacionvinculo rv on ga.id_relacionvinculo = rv.id_relacionvinculo join persona pe on ga.id_persona = pe.id_persona where ap.id_crearproyecto = @id_crearproyecto and ru.id_partida = 2 and rub.id_rubro = @id_rubro and ga.id_investigaciongasto = @id_investigaciongasto group by  ap.orpa, ap.fechapago, ap.cp_egr, sm.nmsemestre, ap.valorneto";
                        List<NpgsqlParameter> parameterListPagos = new List<NpgsqlParameter>();
                        parameterListPagos.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                        parameterListPagos.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                        parameterListPagos.Add(new NpgsqlParameter("@id_investigaciongasto", id_investigaciongasto));
                        NpgsqlParameter[] ParamPagos = parameterListPagos.ToArray();

                        var datosPagos = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryPagos, ParamPagos).ToList();
                        var nmOrpas = datosPagos.Select(x => x.orpa).ToArray();


                        string qryEjecutado = "select sum(ap.valorneto) as ejecutado from investigacion_aplicarpago ap join investigacion_gasto ga on ap.id_investigaciongasto = ga.id_investigaciongasto join seguimiento_rubro rub on ga.id_rubro = rub.id_rubro join seguimiento_partida ru on ga.id_partida = ru.id_partida where ap.id_crearproyecto = @id_crearproyecto and ru.id_partida = 2 and rub.id_rubro = @id_rubro";
                        List<NpgsqlParameter> parameterListEjecutado = new List<NpgsqlParameter>();
                        parameterListEjecutado.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                        parameterListEjecutado.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                        NpgsqlParameter[] ParamEjecutado = parameterListEjecutado.ToArray();




                        var datosEjecutado = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryEjecutado, ParamEjecutado).ToList();


                        foreach (var registroE in datosEjecutado)
                        {
                            var cuatroxmil = (registroE.ejecutado * 4 / 1000) + registroE.ejecutado;
                            var disponibilidad = totalCuatroxMil - cuatroxmil;

                            if (cuatroxmil != null)
                                xlsdocument.SetCellValue("S" + (rowSer + 3), (int)cuatroxmil);
                            if (disponibilidad != null)

                                xlsdocument.SetCellValue("S" + (rowSer + 4), (int)disponibilidad);



                        }
                        auxSpendiente = 0;
                        foreach (var pagos in datosPagos)
                        {
                            if (auxOrpa2 == true)
                            {
                                auxrowOrpa = rowbienes;
                            }
                            auxOrpa2 = false;
                            if (cuatropormilPagos != null)
                                cuatropormilPagos = ((int)pagos.valorneto * 4 / 1000) + (int)pagos.valorneto;
                            xlsdocument.SetCellValue("Q" + rowbienes, pagos.orpa);
                            xlsdocument.SetCellValue("R" + rowbienes, pagos.fechapago.ToString());
                            xlsdocument.SetCellValue("S" + rowbienes, pagos.cp_egr);
                            xlsdocument.SetCellValue("T" + rowbienes, pagos.nmsemestre);
                            if (pagos.valorneto != null)
                                xlsdocument.SetCellValue("U" + rowbienes, (int)pagos.valorneto);
                            xlsdocument.SetCellValue("V" + rowbienes, cuatropormilPagos);

                            auxSpendiente += cuatropormilPagos;

                            if (nmOrpas.Length == 1)
                            {
                                Spendiente = (int)(cuatroxMil - cuatropormilPagos);

                            }


                            rowbienes++;
                        }

                        if (nmOrpas.Length == 1)
                        {
                            xlsdocument.SetCellValue("W" + (rowbienes - 1), Spendiente);
                        }
                        if (nmOrpas.Length > 1)
                        {
                            Spendiente = (int)(cuatroxMil - auxSpendiente);
                            xlsdocument.SetCellValue("W" + auxrowOrpa, Spendiente);
                        }

                        if (nmOrpas.Length == 0)
                        {
                            Spendiente = cuatroxMil;
                            xlsdocument.SetCellValue("W" + rowbienes, Spendiente);
                            rowbienes++;
                            xlsdocument.MergeWorksheetCells("A" + auxrowOrpa, "A" + (rowbienes - 2));
                            xlsdocument.MergeWorksheetCells("B" + auxrowOrpa, "B" + (rowbienes - 2));
                            xlsdocument.MergeWorksheetCells("C" + auxrowOrpa, "C" + (rowbienes - 2));
                            xlsdocument.MergeWorksheetCells("D" + auxrowOrpa, "D" + (rowbienes - 2));
                            xlsdocument.MergeWorksheetCells("E" + auxrowOrpa, "E" + (rowbienes - 2));
                            xlsdocument.MergeWorksheetCells("F" + auxrowOrpa, "F" + (rowbienes - 2));
                            xlsdocument.MergeWorksheetCells("G" + auxrowOrpa, "G" + (rowbienes - 2));
                            xlsdocument.MergeWorksheetCells("H" + auxrowOrpa, "H" + (rowbienes - 2));
                            xlsdocument.MergeWorksheetCells("I" + auxrowOrpa, "I" + (rowbienes - 2));
                            xlsdocument.MergeWorksheetCells("J" + auxrowOrpa, "J" + (rowbienes - 2));
                            xlsdocument.MergeWorksheetCells("K" + auxrowOrpa, "K" + (rowbienes - 2));
                            xlsdocument.MergeWorksheetCells("L" + auxrowOrpa, "L" + (rowbienes - 2));
                            xlsdocument.MergeWorksheetCells("M" + auxrowOrpa, "M" + (rowbienes - 2));
                            xlsdocument.MergeWorksheetCells("N" + auxrowOrpa, "N" + (rowbienes - 2));
                            xlsdocument.MergeWorksheetCells("O" + auxrowOrpa, "O" + (rowbienes - 2));
                            xlsdocument.MergeWorksheetCells("P" + auxrowOrpa, "P" + (rowbienes - 2));
                            xlsdocument.MergeWorksheetCells("W" + auxrowOrpa, "W" + (rowbienes - 2));
                            xlsdocument.MergeWorksheetCells("X" + auxrowOrpa, "X" + (rowbienes - 2));
                        }
                        else
                        {
                            rowbienes++;
                            xlsdocument.HideRow(rowbienes - 1);
                            xlsdocument.MergeWorksheetCells("A" + auxrowOrpa, "A" + (rowbienes - 1));
                            xlsdocument.MergeWorksheetCells("B" + auxrowOrpa, "B" + (rowbienes - 1));
                            xlsdocument.MergeWorksheetCells("C" + auxrowOrpa, "C" + (rowbienes - 1));
                            xlsdocument.MergeWorksheetCells("D" + auxrowOrpa, "D" + (rowbienes - 1));
                            xlsdocument.MergeWorksheetCells("E" + auxrowOrpa, "E" + (rowbienes - 1));
                            xlsdocument.MergeWorksheetCells("F" + auxrowOrpa, "F" + (rowbienes - 1));
                            xlsdocument.MergeWorksheetCells("G" + auxrowOrpa, "G" + (rowbienes - 1));
                            xlsdocument.MergeWorksheetCells("H" + auxrowOrpa, "H" + (rowbienes - 1));
                            xlsdocument.MergeWorksheetCells("I" + auxrowOrpa, "I" + (rowbienes - 1));
                            xlsdocument.MergeWorksheetCells("J" + auxrowOrpa, "J" + (rowbienes - 1));
                            xlsdocument.MergeWorksheetCells("K" + auxrowOrpa, "K" + (rowbienes - 1));
                            xlsdocument.MergeWorksheetCells("L" + auxrowOrpa, "L" + (rowbienes - 1));
                            xlsdocument.MergeWorksheetCells("M" + auxrowOrpa, "M" + (rowbienes - 1));
                            xlsdocument.MergeWorksheetCells("N" + auxrowOrpa, "N" + (rowbienes - 1));
                            xlsdocument.MergeWorksheetCells("O" + auxrowOrpa, "O" + (rowbienes - 1));
                            xlsdocument.MergeWorksheetCells("P" + auxrowOrpa, "P" + (rowbienes - 1));
                            xlsdocument.MergeWorksheetCells("W" + auxrowOrpa, "W" + (rowbienes - 1));
                            xlsdocument.MergeWorksheetCells("X" + auxrowOrpa, "X" + (rowbienes - 1));
                        }

                    }
                    xlsdocument.SetCellStyle("A" + rowbienes, "X" + rowbienes, rowBorder);
                    //rowRubNew = rowTot + 1;
                    rowOpBienes = rowbienes + 1;

                }

                rub2 = false;

                if (nmsBienes.Length > 1)
                {

                    if (deleteBienes == true)
                    {

                        xlsdocument.DeleteRow(rowSer + 2, rowOpBienes - (rowSer + 2));
                        //                           rowRubNew = rowRubNew - 21;
                        xlsdocument.HideRow(rowSer + 2, rowOpBienes - 1);
                    }
                    deleteBienes = false;

                    xlsdocument.SetCellValue(rowOpBienes, 1, "RUBRO");
                    xlsdocument.SetCellStyle(rowOpBienes, 1, adquisicionBienes);
                    xlsdocument.SetCellValue(rowOpBienes, 2, registro.nombrerubro);
                    xlsdocument.MergeWorksheetCells("A" + rowOpBienes, "A" + (rowOpBienes + 2));
                    xlsdocument.MergeWorksheetCells("B" + rowOpBienes, "N" + (rowOpBienes + 2));
                    xlsdocument.MergeWorksheetCells("O" + rowOpBienes, "R" + rowOpBienes);
                    xlsdocument.SetCellValue(rowOpBienes, 15, "VALOR");
                    xlsdocument.SetCellStyle(rowOpBienes, 15, adquisicionBienes);
                    xlsdocument.MergeWorksheetCells("O" + (rowOpBienes + 1), "R" + (rowOpBienes + 1));
                    xlsdocument.SetCellValue(rowOpBienes + 1, 15, "EJECUTADO");
                    xlsdocument.SetCellStyle(rowOpBienes + 1, 15, adquisicionBienes);
                    xlsdocument.MergeWorksheetCells("O" + (rowOpBienes + 2), "R" + (rowOpBienes + 2));
                    xlsdocument.SetCellValue(rowOpBienes + 2, 15, "DISPONIBILIDAD DEL RUBRO");
                    xlsdocument.SetCellStyle(rowOpBienes + 2, 15, adquisicionBienes);
                    xlsdocument.MergeWorksheetCells("S" + rowOpBienes, "X" + rowOpBienes);
                    xlsdocument.MergeWorksheetCells("S" + (rowOpBienes + 1), "X" + (rowOpBienes + 1));
                    xlsdocument.MergeWorksheetCells("S" + (rowOpBienes + 2), "X" + (rowOpBienes + 2));
                    xlsdocument.MergeWorksheetCells("A" + (rowOpBienes + 3), "A" + (rowOpBienes + 4));
                    xlsdocument.SetCellValue(rowOpBienes + 3, 1, "CONCEPTO");
                    xlsdocument.SetColumnWidth("A" + (rowOpBienes + 3), 15.0);
                    xlsdocument.SetCellStyle(rowOpBienes + 3, 1, adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("B" + (rowOpBienes + 3), "B" + (rowOpBienes + 4));
                    xlsdocument.SetCellValue(rowOpBienes + 3, 2, "NOMBRE");
                    xlsdocument.SetCellStyle(rowOpBienes + 3, 2, adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("C" + (rowOpBienes + 3), "C" + (rowOpBienes + 4));
                    xlsdocument.SetCellValue(rowOpBienes + 3, 3, "IDENTIFICACION");
                    xlsdocument.SetColumnWidth("C" + (rowOpBienes + 3), 25.0);
                    xlsdocument.SetCellStyle(rowOpBienes + 3, 3, adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("D" + (rowOpBienes + 3), "D" + (rowOpBienes + 4));
                    xlsdocument.SetCellValue(rowOpBienes + 3, 4, "AREA");
                    xlsdocument.SetCellStyle(rowOpBienes + 3, 4, adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("E" + (rowOpBienes + 3), "H" + (rowOpBienes + 3));
                    xlsdocument.SetCellValue("E" + (rowOpBienes + 3), "RELACION DEL VINCULO");
                    xlsdocument.SetCellStyle("E" + (rowOpBienes + 3), adquisicionBienesCentred);
                    xlsdocument.SetCellValue("E" + (rowOpBienes + 4), "PREGRADO");
                    xlsdocument.SetCellStyle("E" + (rowOpBienes + 4), adquisicionBienesCentred);
                    xlsdocument.SetColumnWidth("E" + (rowOpBienes + 4), 20.0);
                    xlsdocument.SetCellValue("F" + (rowOpBienes + 4), "POSGRADO");
                    xlsdocument.SetCellStyle("F" + (rowOpBienes + 4), adquisicionBienesCentred);
                    xlsdocument.SetColumnWidth("F" + (rowOpBienes + 4), 20.0);
                    xlsdocument.SetCellValue("G" + (rowOpBienes + 4), "EGRESADO");
                    xlsdocument.SetCellStyle("G" + (rowOpBienes + 4), adquisicionBienesCentred);
                    xlsdocument.SetColumnWidth("G" + (rowOpBienes + 4), 20.0);
                    xlsdocument.SetCellValue("H" + (rowOpBienes + 4), "OTRO");
                    xlsdocument.SetCellStyle("H" + (rowOpBienes + 4), adquisicionBienesCentred);
                    xlsdocument.SetColumnWidth("H" + (rowOpBienes + 4), 20.0);
                    xlsdocument.MergeWorksheetCells("I" + (rowOpBienes + 3), "I" + (rowOpBienes + 4));
                    xlsdocument.SetCellValue("I" + (rowOpBienes + 3), "FECHA");
                    xlsdocument.SetCellStyle("I" + (rowOpBienes + 3), adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("J" + (rowOpBienes + 3), "J" + (rowOpBienes + 4));
                    xlsdocument.SetCellValue("J" + (rowOpBienes + 3), "TIPO");
                    xlsdocument.SetCellStyle("J" + (rowOpBienes + 3), adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("K" + (rowOpBienes + 3), "K" + (rowOpBienes + 4));
                    xlsdocument.SetCellValue("K" + (rowOpBienes + 3), "No.");
                    xlsdocument.SetCellStyle("K" + (rowOpBienes + 3), adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("L" + (rowOpBienes + 3), "L" + (rowOpBienes + 4));
                    xlsdocument.SetCellValue("L" + (rowOpBienes + 3), "FECHA INICIO");
                    xlsdocument.SetCellStyle("L" + (rowOpBienes + 3), adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("M" + (rowOpBienes + 3), "M" + (rowOpBienes + 4));
                    xlsdocument.SetCellValue("M" + (rowOpBienes + 3), "FECHA FINAL");
                    xlsdocument.SetCellStyle("M" + (rowOpBienes + 3), adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("N" + (rowOpBienes + 3), "N" + (rowOpBienes + 4));
                    xlsdocument.SetCellValue("N" + (rowOpBienes + 3), "ESTADO");
                    xlsdocument.SetCellStyle("N" + (rowOpBienes + 3), adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("O" + (rowOpBienes + 3), "O" + (rowOpBienes + 4));
                    xlsdocument.SetCellValue("O" + (rowOpBienes + 3), "Valor Total");
                    xlsdocument.SetCellStyle("O" + (rowOpBienes + 3), adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("P" + (rowOpBienes + 3), "P" + (rowOpBienes + 4));
                    xlsdocument.SetCellValue("P" + (rowOpBienes + 3), "Valor con 4 xmil");
                    xlsdocument.SetCellStyle("P" + (rowOpBienes + 3), adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("Q" + (rowOpBienes + 3), "V" + (rowOpBienes + 3));
                    xlsdocument.SetCellValue("Q" + (rowOpBienes + 3), "PAGOS");
                    xlsdocument.SetCellStyle("Q" + (rowOpBienes + 3), adquisicionBienesCentred);
                    xlsdocument.SetCellValue("Q" + (rowOpBienes + 4), "ORPA");
                    xlsdocument.SetCellStyle("Q" + (rowOpBienes + 4), adquisicionBienesCentred);
                    xlsdocument.SetCellValue("R" + (rowOpBienes + 4), "FECHA");
                    xlsdocument.SetCellStyle("R" + (rowOpBienes + 4), adquisicionBienesCentred);
                    xlsdocument.SetCellValue("S" + (rowOpBienes + 4), "CP.EGR");
                    xlsdocument.SetCellStyle("S" + (rowOpBienes + 4), adquisicionBienesCentred);
                    xlsdocument.SetCellValue("T" + (rowOpBienes + 4), "PERIODO");
                    xlsdocument.SetCellStyle("T" + (rowOpBienes + 4), adquisicionBienesCentred);
                    xlsdocument.SetCellValue("U" + (rowOpBienes + 4), "VALOR NETO");
                    xlsdocument.SetCellStyle("U" + (rowOpBienes + 4), adquisicionBienesCentred);
                    xlsdocument.SetCellValue("V" + (rowOpBienes + 4), "VALOR 4*1000");
                    xlsdocument.SetCellStyle("V" + (rowOpBienes + 4), adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("W" + (rowOpBienes + 3), "W" + (rowOpBienes + 4));
                    xlsdocument.SetCellValue("W" + (rowOpBienes + 3), "SALDO PENDIENTE");
                    xlsdocument.SetCellStyle("W" + (rowOpBienes + 3), adquisicionBienesCentred);
                    xlsdocument.MergeWorksheetCells("X" + (rowOpBienes + 3), "X" + (rowOpBienes + 4));
                    xlsdocument.SetCellValue("X" + (rowOpBienes + 3), "OBSERVACION");
                    xlsdocument.SetCellStyle("X" + (rowOpBienes + 3), adquisicionBienesCentred);
                    xlsdocument.SetColumnWidth("L" + (rowOpBienes + 3), 25.0);
                    xlsdocument.SetColumnWidth("M" + (rowOpBienes + 3), 25.0);
                    xlsdocument.SetColumnWidth("N" + (rowOpBienes + 3), 25.0);
                    xlsdocument.SetColumnWidth("O" + (rowOpBienes + 3), 25.0);
                    xlsdocument.SetColumnWidth("P" + (rowOpBienes + 3), 25.0);
                    xlsdocument.SetColumnWidth("Q" + (rowOpBienes + 3), 25.0);
                    xlsdocument.SetColumnWidth("R" + (rowOpBienes + 3), 25.0);
                    xlsdocument.SetColumnWidth("S" + (rowOpBienes + 3), 25.0);
                    xlsdocument.SetColumnWidth("T" + (rowOpBienes + 3), 25.0);
                    xlsdocument.SetColumnWidth("U" + (rowOpBienes + 3), 25.0);
                    xlsdocument.SetColumnWidth("V" + (rowOpBienes + 3), 25.0);
                    xlsdocument.SetColumnWidth("W" + (rowOpBienes + 3), 25.0);
                    xlsdocument.SetColumnWidth("X" + (rowOpBienes + 3), 25.0);

                    id_rubro = registro.id_rubro;


                    //Incluimos el valor total por concepto 

                    string qryValorTotal = "select sum (valortotal) from investigacion_gasto where id_crearproyecto = @id_crearproyecto and id_partida = 2 and id_rubro = @id_rubro";
                    List<NpgsqlParameter> parameterListTotal = new List<NpgsqlParameter>();
                    parameterListTotal.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                    parameterListTotal.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                    NpgsqlParameter[] ParamTotal = parameterListTotal.ToArray();




                    var datosTotal = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryValorTotal, ParamTotal).ToList();



                    foreach (var registroN in datosTotal)
                    {
                        var cuatroxmil = (registroN.sum * 4 / 1000) + registroN.sum;
                        if (cuatroxmil != null)
                            xlsdocument.SetCellValue("S" + (rowOpBienes), (int)cuatroxmil);

                    }


                    string qryorpa = "select co.nombreconcepto, pe.nombrecompleto , pe.numidentificacion, rv.id_relacionvinculo, ga.fechainicio, ga.fechafinal, ga.numorden, ga.fechalegalizacionorden, ga.tipo, ga.valortotal, ga.estado, ga.id_investigaciongasto from investigacion_gasto ga join seguimiento_concepto co on ga.id_segconcepto = co.id_segconcepto join persona pe on ga.id_persona = pe.id_persona join seguimiento_relacionvinculo rv on ga.id_relacionvinculo = rv.id_relacionvinculo where ga.id_crearproyecto = @id_crearproyecto and ga.id_partida = 2 and ga.id_rubro = @id_rubro";
                    List<NpgsqlParameter> parameterListOrpa = new List<NpgsqlParameter>();
                    parameterListOrpa.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                    parameterListOrpa.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                    NpgsqlParameter[] ParamOrpa = parameterListOrpa.ToArray();

                    var datosOrpa = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryorpa, ParamOrpa).ToList();



                    var optSec = true;
                    //27 tot
                    var aux = rowOpBienes + 5;
                    var cuatroxMil = 0;

                    var rowOrpa = aux;
                    var auxrowOrpa = 0;
                    optOrpa = false;
                    var auxOrpa2 = true;
                    var totalCuatroxMil = 0;

                    var Spendiente = 0;
                    var auxSpendiente = 0;

                    foreach (var dataorpa in datosOrpa)
                    {

                        auxOrpa2 = true;
                        id_investigaciongasto = dataorpa.id_investigaciongasto;
                        if (cuatroxMil != null)
                            cuatroxMil = ((int)dataorpa.valortotal * 4 / 1000) + (int)dataorpa.valortotal;
                        totalCuatroxMil += cuatroxMil;
                        xlsdocument.SetCellValue(rowOrpa, 1, dataorpa.nombreconcepto);
                        xlsdocument.SetCellValue("B" + rowOrpa, dataorpa.nombrecompleto);
                        xlsdocument.SetCellValue("C" + rowOrpa, dataorpa.numidentificacion);
                        xlsdocument.SetCellValue("I" + rowOrpa, dataorpa.fechalegalizacionorden.ToString());
                        xlsdocument.SetCellValue("J" + rowOrpa, dataorpa.tipo);
                        xlsdocument.SetCellValue("K" + rowOrpa, dataorpa.numorden);
                        xlsdocument.SetCellValue("L" + rowOrpa, dataorpa.fechainicio.ToString());
                        xlsdocument.SetCellValue("M" + rowOrpa, dataorpa.fechafinal.ToString());
                        xlsdocument.SetCellValue("N" + rowOrpa, dataorpa.estado);
                        xlsdocument.SetCellValue("X" + rowOrpa, dataorpa.observaciones);
                        if (dataorpa.valortotal != null)
                            xlsdocument.SetCellValue("O" + rowOrpa, (int)dataorpa.valortotal);
                        xlsdocument.SetCellValue("P" + rowOrpa, cuatroxMil);

                        optSec = false;


                        if (dataorpa.id_relacionvinculo == 1 || dataorpa.id_relacionvinculo == 2)
                        {
                            xlsdocument.SetCellValue("H" + rowOrpa, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 3)
                        {
                            xlsdocument.SetCellValue("E" + rowOrpa, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 4)
                        {
                            xlsdocument.SetCellValue("F" + rowOrpa, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 5)
                        {
                            xlsdocument.SetCellValue("G" + rowOrpa, "X");

                        }


                        string qryPagos = "select ap.orpa, ap.fechapago, ap.cp_egr, sm.nmsemestre, ap.valorneto from investigacion_aplicarpago ap join investigacion_gasto ga on ap.id_investigaciongasto = ga.id_investigaciongasto join seguimiento_rubro rub on ga.id_rubro = rub.id_rubro join seguimiento_partida ru on ga.id_partida = ru.id_partida join seguimiento_concepto co on ga.id_segconcepto = co.id_segconcepto join semestre sm on ap.id_semestre = sm.id_semestre join seguimiento_relacionvinculo rv on ga.id_relacionvinculo = rv.id_relacionvinculo join persona pe on ga.id_persona = pe.id_persona where ap.id_crearproyecto = @id_crearproyecto and ru.id_partida = 2 and rub.id_rubro = @id_rubro and ga.id_investigaciongasto = @id_investigaciongasto group by  ap.orpa, ap.fechapago, ap.cp_egr, sm.nmsemestre, ap.valorneto";
                        List<NpgsqlParameter> parameterListPagos = new List<NpgsqlParameter>();
                        parameterListPagos.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                        parameterListPagos.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                        parameterListPagos.Add(new NpgsqlParameter("@id_investigaciongasto", id_investigaciongasto));
                        NpgsqlParameter[] ParamPagos = parameterListPagos.ToArray();

                        var datosPagos = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryPagos, ParamPagos).ToList();
                        var nmOrpas = datosPagos.Select(x => x.orpa).ToArray();

                        string qryEjecutado = "select sum(ap.valorneto) as ejecutado from investigacion_aplicarpago ap join investigacion_gasto ga on ap.id_investigaciongasto = ga.id_investigaciongasto join seguimiento_rubro rub on ga.id_rubro = rub.id_rubro join seguimiento_partida ru on ga.id_partida = ru.id_partida where ap.id_crearproyecto = @id_crearproyecto and ru.id_partida = 2 and rub.id_rubro = @id_rubro";
                        List<NpgsqlParameter> parameterListEjecutado = new List<NpgsqlParameter>();
                        parameterListEjecutado.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                        parameterListEjecutado.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                        NpgsqlParameter[] ParamEjecutado = parameterListEjecutado.ToArray();




                        var datosEjecutado = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryEjecutado, ParamEjecutado).ToList();


                        foreach (var registroE in datosEjecutado)
                        {
                            var cuatroxmil = (registroE.ejecutado * 4 / 1000) + registroE.ejecutado;
                            var disponibilidad = totalCuatroxMil - cuatroxmil;

                            if (cuatroxmil != null)
                                xlsdocument.SetCellValue("S" + (rowOpBienes + 1), (int)cuatroxmil);
                            if (disponibilidad != null)

                                xlsdocument.SetCellValue("S" + (rowOpBienes + 2), (int)disponibilidad);



                        }

                        auxSpendiente = 0;
                        foreach (var pagos in datosPagos)
                        {
                            if (auxOrpa2 == true)
                            {
                                auxrowOrpa = rowOrpa;
                            }
                            auxOrpa2 = false;
                            if (cuatropormilPagos != null)
                                cuatropormilPagos = ((int)pagos.valorneto * 4 / 1000) + (int)pagos.valorneto;
                            xlsdocument.SetCellValue("Q" + rowOrpa, pagos.orpa);
                            xlsdocument.SetCellValue("R" + rowOrpa, pagos.fechapago.ToString());
                            xlsdocument.SetCellValue("S" + rowOrpa, pagos.cp_egr);
                            xlsdocument.SetCellValue("T" + rowOrpa, pagos.nmsemestre);
                            if (pagos.valorneto != null)
                                xlsdocument.SetCellValue("U" + rowOrpa, (int)pagos.valorneto);
                            xlsdocument.SetCellValue("V" + rowOrpa, cuatropormilPagos);

                            auxSpendiente += cuatropormilPagos;

                            if (nmOrpas.Length == 1)
                            {
                                Spendiente = (int)(cuatroxMil - cuatropormilPagos);

                            }

                            rowOrpa++;
                        }

                        if (nmOrpas.Length == 1)
                        {
                            xlsdocument.SetCellValue("W" + (rowOrpa - 1), Spendiente);
                        }
                        if (nmOrpas.Length > 1)
                        {
                            Spendiente = (int)(cuatroxMil - auxSpendiente);
                            xlsdocument.SetCellValue("W" + auxrowOrpa, Spendiente);
                        }

                        if (nmOrpas.Length == 0)
                        {
                            Spendiente = cuatroxMil;
                            xlsdocument.SetCellValue("W" + rowOrpa, Spendiente);
                            rowOrpa++;
                            xlsdocument.MergeWorksheetCells("A" + auxrowOrpa, "A" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("B" + auxrowOrpa, "B" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("C" + auxrowOrpa, "C" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("D" + auxrowOrpa, "D" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("E" + auxrowOrpa, "E" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("F" + auxrowOrpa, "F" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("G" + auxrowOrpa, "G" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("H" + auxrowOrpa, "H" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("I" + auxrowOrpa, "I" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("J" + auxrowOrpa, "J" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("K" + auxrowOrpa, "K" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("L" + auxrowOrpa, "L" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("M" + auxrowOrpa, "M" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("N" + auxrowOrpa, "N" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("O" + auxrowOrpa, "O" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("P" + auxrowOrpa, "P" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("W" + auxrowOrpa, "W" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("X" + auxrowOrpa, "X" + (rowOrpa - 2));
                        }
                        else
                        {
                            xlsdocument.MergeWorksheetCells("A" + auxrowOrpa, "A" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("B" + auxrowOrpa, "B" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("C" + auxrowOrpa, "C" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("D" + auxrowOrpa, "D" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("E" + auxrowOrpa, "E" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("F" + auxrowOrpa, "F" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("G" + auxrowOrpa, "G" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("H" + auxrowOrpa, "H" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("I" + auxrowOrpa, "I" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("J" + auxrowOrpa, "J" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("K" + auxrowOrpa, "K" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("L" + auxrowOrpa, "L" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("M" + auxrowOrpa, "M" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("N" + auxrowOrpa, "N" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("O" + auxrowOrpa, "O" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("P" + auxrowOrpa, "P" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("W" + auxrowOrpa, "W" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("X" + auxrowOrpa, "X" + (rowOrpa - 1));
                        }


                    }
                    auxOrpa = rowOrpa;
                    xlsdocument.SetCellStyle("A" + rowOrpa, "X" + rowOrpa, rowBorder);
                    rowOpBienes = rowOpBienes + (auxOrpa - rowOpBienes) + 1;
                    rowSer2 = rowOpBienes;
                }
            }
            if (nmsBienes.Length == 1)
            {
                rowSer2 = rowOpBienes;

            }
            else if (nmsBienes.Length == 0)
            {
                rowSer2 = rowSer + 2;
            }





            SLStyle adquisicionServicios = xlsdocument.CreateStyle();
            SLStyle adquisicionServiciosCentred = xlsdocument.CreateStyle();

            adquisicionServicios.Font.FontName = "Times New Roman";
            adquisicionServicios.Font.FontSize = 14.0;
            adquisicionServicios.Font.Bold = true;
            adquisicionServicios.Alignment.Horizontal = HorizontalAlignmentValues.Left;
            adquisicionServicios.Alignment.Vertical = VerticalAlignmentValues.Center;
            adquisicionServicios.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.FromArgb(175, 159, 246), System.Drawing.Color.Blue);

            adquisicionServiciosCentred.Font.FontName = "Times New Roman";
            adquisicionServiciosCentred.Font.FontSize = 14.0;
            adquisicionServiciosCentred.Font.Bold = true;
            adquisicionServiciosCentred.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            adquisicionServiciosCentred.Alignment.Vertical = VerticalAlignmentValues.Center;
            adquisicionServiciosCentred.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.FromArgb(175, 159, 246), System.Drawing.Color.Blue);


            xlsdocument.MergeWorksheetCells(rowSer2, 1, rowSer2, 24);
            xlsdocument.SetCellValue(rowSer2, 1, "3. ADQUISICION DE SERVICIOS");
            xlsdocument.SetCellStyle(rowSer2, 1, adquisicionServicios);
            xlsdocument.SetCellStyle("A" + (rowSer2 + 1), "X" + (rowSer2 + 1), rowBorder);
            xlsdocument.SetRowHeight(rowSer2 + 1, 11.0);


            string qryServicios = "select DISTINCT ru.nombrerubro, ru.id_rubro from investigacion_gasto ga join seguimiento_rubro ru on ga.id_rubro = ru.id_rubro where ga.id_crearproyecto=@id_crearproyecto and ga.id_partida = 3";
            List<NpgsqlParameter> parameterListServicios = new List<NpgsqlParameter>();
            parameterListServicios.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
            NpgsqlParameter[] ParamServicios = parameterListServicios.ToArray();

            var datosservicios = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryServicios, ParamServicios).ToList();

            var nmsServicios = datosservicios.Select(x => x.nombreconcepto).ToArray();


            var rub3 = true;

            foreach (var registro in datosservicios)
            {

                if (rub3 == true)
                {

                    xlsdocument.SetCellValue(rowSer2 + 2, 1, "RUBRO");
                    xlsdocument.SetCellStyle(rowSer2 + 2, 1, adquisicionServiciosCentred);
                    xlsdocument.SetCellValue(rowSer2 + 2, 2, registro.nombrerubro);
                    xlsdocument.MergeWorksheetCells("A" + (rowSer2 + 2), "A" + (rowSer2 + 4));
                    xlsdocument.MergeWorksheetCells("B" + (rowSer2 + 2), "N" + (rowSer2 + 4));
                    xlsdocument.MergeWorksheetCells("O" + (rowSer2 + 2), "R" + (rowSer2 + 2));
                    xlsdocument.SetCellValue(rowSer2 + 2, 15, "VALOR");
                    xlsdocument.SetCellStyle(rowSer2 + 2, 15, adquisicionServicios);
                    xlsdocument.MergeWorksheetCells("O" + (rowSer2 + 4), "R" + (rowSer2 + 4));
                    xlsdocument.SetCellValue(rowSer2 + 3, 15, "EJECUTADO");


                    xlsdocument.SetCellStyle(rowSer2 + 3, 15, adquisicionServicios);
                    xlsdocument.MergeWorksheetCells("O" + (rowSer2 + 3), "R" + (rowSer2 + 3));
                    xlsdocument.SetCellValue(rowSer2 + 4, 15, "DISPONIBILIDAD DEL RUBRO");
                    xlsdocument.SetCellStyle(rowSer2 + 4, 15, adquisicionServicios);
                    xlsdocument.MergeWorksheetCells("S" + (rowSer2 + 2), "X" + (rowSer2 + 2));
                    xlsdocument.MergeWorksheetCells("S" + (rowSer2 + 3), "X" + (rowSer2 + 3));
                    xlsdocument.MergeWorksheetCells("S" + (rowSer2 + 4), "X" + (rowSer2 + 4));


                    xlsdocument.MergeWorksheetCells("A" + (rowSer2 + 5), "A" + (rowSer2 + 6));
                    xlsdocument.SetCellValue(rowSer2 + 5, 1, "CONCEPTO");
                    xlsdocument.SetColumnWidth("A" + (rowSer2 + 5), 15.0);
                    xlsdocument.SetCellStyle(rowSer2 + 5, 1, adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("B" + (rowSer2 + 5), "B" + (rowSer2 + 6));
                    xlsdocument.SetCellValue(rowSer2 + 5, 2, "NOMBRE");
                    xlsdocument.SetCellStyle(rowSer2 + 5, 2, adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("C" + (rowSer2 + 5), "C" + (rowSer2 + 6));
                    xlsdocument.SetCellValue(rowSer2 + 5, 3, "IDENTIFICACION");
                    //xlsdocument.AutoFitColumn("C"+(row+12));
                    xlsdocument.SetColumnWidth("C" + (rowSer2 + 5), 25.0);
                    xlsdocument.SetCellStyle(rowSer2 + 5, 3, adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("D" + (rowSer2 + 5), "D" + (rowSer2 + 6));
                    xlsdocument.SetCellValue(rowSer2 + 5, 4, "AREA");
                    xlsdocument.SetCellStyle(rowSer2 + 5, 4, adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("E" + (rowSer2 + 5), "H" + (rowSer2 + 5));
                    xlsdocument.SetCellValue("E" + (rowSer2 + 5), "RELACION DEL VINCULO");
                    xlsdocument.SetCellStyle("E" + (rowSer2 + 5), adquisicionServiciosCentred);
                    xlsdocument.SetCellValue("E" + (rowSer2 + 6), "PREGRADO");
                    xlsdocument.SetCellStyle("E" + (rowSer2 + 6), adquisicionServiciosCentred);
                    xlsdocument.SetColumnWidth("E" + (rowSer2 + 6), 20.0);
                    xlsdocument.SetCellValue("F" + (rowSer2 + 6), "POSGRADO");
                    xlsdocument.SetCellStyle("F" + (rowSer2 + 6), adquisicionServiciosCentred);
                    xlsdocument.SetColumnWidth("F" + (rowSer2 + 6), 20.0);
                    xlsdocument.SetCellValue("G" + (rowSer2 + 6), "EGRESADO");
                    xlsdocument.SetCellStyle("G" + (rowSer2 + 6), adquisicionServiciosCentred);
                    xlsdocument.SetColumnWidth("G" + (rowSer2 + 6), 20.0);
                    xlsdocument.SetCellValue("H" + (rowSer2 + 6), "OTRO");
                    xlsdocument.SetCellStyle("H" + (rowSer2 + 6), adquisicionServiciosCentred);
                    xlsdocument.SetColumnWidth("H" + (rowSer2 + 6), 20.0);
                    xlsdocument.MergeWorksheetCells("I" + (rowSer2 + 5), "I" + (rowSer2 + 6));
                    xlsdocument.SetCellValue("I" + (rowSer2 + 5), "FECHA");
                    xlsdocument.SetCellStyle("I" + (rowSer2 + 5), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("J" + (rowSer2 + 5), "J" + (rowSer2 + 6));
                    xlsdocument.SetCellValue("J" + (rowSer2 + 5), "TIPO");
                    xlsdocument.SetCellStyle("J" + (rowSer2 + 5), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("K" + (rowSer2 + 5), "K" + (rowSer2 + 6));
                    xlsdocument.SetCellValue("K" + (rowSer2 + 5), "No.");
                    xlsdocument.SetCellStyle("K" + (rowSer2 + 5), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("L" + (rowSer2 + 5), "L" + (rowSer2 + 6));
                    xlsdocument.SetCellValue("L" + (rowSer2 + 5), "FECHA INICIO");
                    xlsdocument.SetCellStyle("L" + (rowSer2 + 5), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("M" + (rowSer2 + 5), "M" + (rowSer2 + 6));
                    xlsdocument.SetCellValue("M" + (rowSer2 + 5), "FECHA FINAL");
                    xlsdocument.SetCellStyle("M" + (rowSer2 + 5), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("N" + (rowSer2 + 5), "N" + (rowSer2 + 6));
                    xlsdocument.SetCellValue("N" + (rowSer2 + 5), "ESTADO");
                    xlsdocument.SetCellStyle("N" + (rowSer2 + 5), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("O" + (rowSer2 + 5), "O" + (rowSer2 + 6));
                    xlsdocument.SetCellValue("O" + (rowSer2 + 5), "Valor Total");
                    xlsdocument.SetCellStyle("O" + (rowSer2 + 5), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("P" + (rowSer2 + 5), "P" + (rowSer2 + 6));
                    xlsdocument.SetCellValue("P" + (rowSer2 + 5), "Valor con 4 xmil");
                    xlsdocument.SetCellStyle("P" + (rowSer2 + 5), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("Q" + (rowSer2 + 5), "V" + (rowSer2 + 5));
                    xlsdocument.SetCellValue("Q" + (rowSer2 + 5), "PAGOS");
                    xlsdocument.SetCellStyle("Q" + (rowSer2 + 5), adquisicionServiciosCentred);
                    xlsdocument.SetCellValue("Q" + (rowSer2 + 6), "ORPA");
                    xlsdocument.SetCellStyle("Q" + (rowSer2 + 6), adquisicionServiciosCentred);
                    xlsdocument.SetCellValue("R" + (rowSer2 + 6), "FECHA");
                    xlsdocument.SetCellStyle("R" + (rowSer2 + 6), adquisicionServiciosCentred);
                    xlsdocument.SetCellValue("S" + (rowSer2 + 6), "CP.EGR");
                    xlsdocument.SetCellStyle("S" + (rowSer2 + 6), adquisicionServiciosCentred);
                    xlsdocument.SetCellValue("T" + (rowSer2 + 6), "PERIODO");
                    xlsdocument.SetCellStyle("T" + (rowSer2 + 6), adquisicionServiciosCentred);
                    xlsdocument.SetCellValue("U" + (rowSer2 + 6), "VALOR NETO");
                    xlsdocument.SetCellStyle("U" + (rowSer2 + 6), adquisicionServiciosCentred);
                    xlsdocument.SetCellValue("V" + (rowSer2 + 6), "VALOR 4*1000");
                    xlsdocument.SetCellStyle("V" + (rowSer2 + 6), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("W" + (rowSer2 + 5), "W" + (rowSer2 + 6));
                    xlsdocument.SetCellValue("W" + (rowSer2 + 5), "SALDO PENDIENTE");
                    xlsdocument.SetCellStyle("W" + (rowSer2 + 5), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("X" + (rowSer2 + 5), "X" + (rowSer2 + 6));
                    xlsdocument.SetCellValue("X" + (rowSer2 + 5), "OBSERVACION");
                    xlsdocument.SetCellStyle("X" + (rowSer2 + 5), adquisicionServiciosCentred);
                    xlsdocument.SetColumnWidth("L" + (rowSer2 + 5), 25.0);
                    xlsdocument.SetColumnWidth("M" + (rowSer2 + 5), 25.0);
                    xlsdocument.SetColumnWidth("N" + (rowSer2 + 5), 25.0);
                    xlsdocument.SetColumnWidth("O" + (rowSer2 + 5), 25.0);
                    xlsdocument.SetColumnWidth("P" + (rowSer2 + 5), 25.0);
                    xlsdocument.SetColumnWidth("Q" + (rowSer2 + 5), 25.0);
                    xlsdocument.SetColumnWidth("R" + (rowSer2 + 5), 25.0);
                    xlsdocument.SetColumnWidth("S" + (rowSer2 + 5), 25.0);
                    xlsdocument.SetColumnWidth("T" + (rowSer2 + 5), 25.0);
                    xlsdocument.SetColumnWidth("U" + (rowSer2 + 5), 25.0);
                    xlsdocument.SetColumnWidth("V" + (rowSer2 + 5), 25.0);
                    xlsdocument.SetColumnWidth("W" + (rowSer2 + 5), 25.0);
                    xlsdocument.SetColumnWidth("X" + (rowSer2 + 5), 25.0);


                    id_rubro = registro.id_rubro;


                    //Incluimos el valor total por concepto 


                    //Incluimos el valor total por concepto 
                    string qryValorTotal = "select sum (valortotal) from investigacion_gasto where id_crearproyecto = @id_crearproyecto and id_partida = 3 and id_rubro = @id_rubro";
                    List<NpgsqlParameter> parameterListTotal = new List<NpgsqlParameter>();
                    parameterListTotal.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                    parameterListTotal.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                    NpgsqlParameter[] ParamTotal = parameterListTotal.ToArray();




                    var datosTotal = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryValorTotal, ParamTotal).ToList();



                    foreach (var registroN in datosTotal)
                    {
                        var cuatroxmil = (registroN.sum * 4 / 1000) + registroN.sum;
                        if (cuatroxmil != null)
                            xlsdocument.SetCellValue("S" + (rowSer + 2), (int)cuatroxmil);

                    }

                    string qryorpa = "select co.nombreconcepto, pe.nombrecompleto , pe.numidentificacion, rv.id_relacionvinculo, ga.fechainicio, ga.fechafinal, ga.numorden, ga.fechalegalizacionorden, ga.tipo, ga.valortotal, ga.estado, ga.id_investigaciongasto from investigacion_gasto ga join seguimiento_concepto co on ga.id_segconcepto = co.id_segconcepto join persona pe on ga.id_persona = pe.id_persona join seguimiento_relacionvinculo rv on ga.id_relacionvinculo = rv.id_relacionvinculo where ga.id_crearproyecto = @id_crearproyecto and ga.id_partida = 3 and ga.id_rubro = @id_rubro";
                    List<NpgsqlParameter> parameterListOrpa = new List<NpgsqlParameter>();
                    parameterListOrpa.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                    parameterListOrpa.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                    NpgsqlParameter[] ParamOrpa = parameterListOrpa.ToArray();

                    var datosOrpa = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryorpa, ParamOrpa).ToList();




                    var auxrowOrpa = 0;
                    var auxOrpa2 = true;
                    var totalCuatroxMil = 0;


                    var opt = true;
                    //27 tot
                    var cuatroxMil = 0;

                    var Spendiente = 0;
                    var auxSpendiente = 0;

                    if (rowServ == true)
                    {
                        rowservicios = rowSer2 + 7;
                    }
                    rowServ = false;

                    foreach (var dataorpa in datosOrpa)
                    {
                        auxOrpa2 = true;
                        if (cuatroxMil != null)
                            cuatroxMil = ((int)dataorpa.valortotal * 4 / 1000) + (int)dataorpa.valortotal;

                        id_investigaciongasto = dataorpa.id_investigaciongasto;
                        totalCuatroxMil += cuatroxMil;
                        xlsdocument.SetCellValue(rowservicios, 1, dataorpa.nombreconcepto);
                        xlsdocument.SetCellValue("B" + rowservicios, dataorpa.nombrecompleto);
                        xlsdocument.SetCellValue("C" + rowservicios, dataorpa.numidentificacion);
                        xlsdocument.SetCellValue("I" + rowservicios, dataorpa.fechalegalizacionorden.ToString());
                        xlsdocument.SetCellValue("J" + rowservicios, dataorpa.tipo);
                        xlsdocument.SetCellValue("K" + rowservicios, dataorpa.numorden);
                        xlsdocument.SetCellValue("L" + rowservicios, dataorpa.fechainicio.ToString());
                        xlsdocument.SetCellValue("M" + rowservicios, dataorpa.fechafinal.ToString());
                        xlsdocument.SetCellValue("N" + rowservicios, dataorpa.estado);
                        xlsdocument.SetCellValue("X" + rowservicios, dataorpa.observaciones);
                        if (dataorpa.valortotal != null)
                            xlsdocument.SetCellValue("O" + rowservicios, (int)dataorpa.valortotal);
                        xlsdocument.SetCellValue("P" + rowservicios, cuatroxMil);


                        if (dataorpa.id_relacionvinculo == 1 || dataorpa.id_relacionvinculo == 2)
                        {
                            xlsdocument.SetCellValue("H" + rowservicios, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 3)
                        {
                            xlsdocument.SetCellValue("E" + rowservicios, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 4)
                        {
                            xlsdocument.SetCellValue("F" + rowservicios, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 5)
                        {
                            xlsdocument.SetCellValue("G" + rowservicios, "X");

                        }



                        string qryPagos = "select ap.orpa, ap.fechapago, ap.cp_egr, sm.nmsemestre, ap.valorneto from investigacion_aplicarpago ap join investigacion_gasto ga on ap.id_investigaciongasto = ga.id_investigaciongasto join seguimiento_rubro rub on ga.id_rubro = rub.id_rubro join seguimiento_partida ru on ga.id_partida = ru.id_partida join seguimiento_concepto co on ga.id_segconcepto = co.id_segconcepto join semestre sm on ap.id_semestre = sm.id_semestre join seguimiento_relacionvinculo rv on ga.id_relacionvinculo = rv.id_relacionvinculo join persona pe on ga.id_persona = pe.id_persona where ap.id_crearproyecto = @id_crearproyecto and ru.id_partida = 3 and rub.id_rubro = @id_rubro and ga.id_investigaciongasto = @id_investigaciongasto group by  ap.orpa, ap.fechapago, ap.cp_egr, sm.nmsemestre, ap.valorneto";
                        List<NpgsqlParameter> parameterListPagos = new List<NpgsqlParameter>();
                        parameterListPagos.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                        parameterListPagos.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                        parameterListPagos.Add(new NpgsqlParameter("@id_investigaciongasto", id_investigaciongasto));
                        NpgsqlParameter[] ParamPagos = parameterListPagos.ToArray();

                        var datosPagos = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryPagos, ParamPagos).ToList();

                        var nmOrpas = datosPagos.Select(x => x.orpa).ToArray();


                        string qryEjecutado = "select sum(ap.valorneto) as ejecutado from investigacion_aplicarpago ap join investigacion_gasto ga on ap.id_investigaciongasto = ga.id_investigaciongasto join seguimiento_rubro rub on ga.id_rubro = rub.id_rubro join seguimiento_partida ru on ga.id_partida = ru.id_partida where ap.id_crearproyecto = @id_crearproyecto and ru.id_partida = 3 and rub.id_rubro = @id_rubro";
                        List<NpgsqlParameter> parameterListEjecutado = new List<NpgsqlParameter>();
                        parameterListEjecutado.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                        parameterListEjecutado.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                        NpgsqlParameter[] ParamEjecutado = parameterListEjecutado.ToArray();




                        var datosEjecutado = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryEjecutado, ParamEjecutado).ToList();


                        foreach (var registroE in datosEjecutado)
                        {
                            var cuatroxmil = (registroE.ejecutado * 4 / 1000) + registroE.ejecutado;
                            var disponibilidad = totalCuatroxMil - cuatroxmil;

                            if (cuatroxmil != null)
                                xlsdocument.SetCellValue("S" + (rowSer2 + 3), (int)cuatroxmil);
                            if (disponibilidad != null)

                                xlsdocument.SetCellValue("S" + (rowSer2 + 4), (int)disponibilidad);



                        }

                        auxSpendiente = 0;
                        foreach (var pagos in datosPagos)
                        {
                            if (auxOrpa2 == true)
                            {
                                auxrowOrpa = rowservicios;
                            }
                            auxOrpa2 = false;
                            if (cuatropormilPagos != null)
                                cuatropormilPagos = ((int)pagos.valorneto * 4 / 1000) + (int)pagos.valorneto;

                            xlsdocument.SetCellValue("Q" + rowservicios, pagos.orpa);
                            xlsdocument.SetCellValue("R" + rowservicios, pagos.fechapago.ToString());
                            xlsdocument.SetCellValue("S" + rowservicios, pagos.cp_egr);
                            xlsdocument.SetCellValue("T" + rowservicios, pagos.nmsemestre);
                            if (pagos.valorneto != null)
                                xlsdocument.SetCellValue("U" + rowservicios, (int)pagos.valorneto);
                            xlsdocument.SetCellValue("V" + rowservicios, cuatropormilPagos);

                            auxSpendiente += cuatropormilPagos;

                            if (nmOrpas.Length == 1)
                            {
                                Spendiente = (int)(cuatroxMil - cuatropormilPagos);

                            }

                            rowservicios++;
                        }

                        if (nmOrpas.Length == 1)
                        {
                            xlsdocument.SetCellValue("W" + (rowservicios - 1), Spendiente);
                        }
                        if (nmOrpas.Length > 1)
                        {
                            Spendiente = (int)(cuatroxMil - auxSpendiente);
                            xlsdocument.SetCellValue("W" + auxrowOrpa, Spendiente);
                        }

                        if (nmOrpas.Length == 0)
                        {
                            Spendiente = cuatroxMil;
                            xlsdocument.SetCellValue("W" + rowservicios, Spendiente);
                            rowservicios++;
                            xlsdocument.MergeWorksheetCells("A" + auxrowOrpa, "A" + (rowservicios - 2));
                            xlsdocument.MergeWorksheetCells("B" + auxrowOrpa, "B" + (rowservicios - 2));
                            xlsdocument.MergeWorksheetCells("C" + auxrowOrpa, "C" + (rowservicios - 2));
                            xlsdocument.MergeWorksheetCells("D" + auxrowOrpa, "D" + (rowservicios - 2));
                            xlsdocument.MergeWorksheetCells("E" + auxrowOrpa, "E" + (rowservicios - 2));
                            xlsdocument.MergeWorksheetCells("F" + auxrowOrpa, "F" + (rowservicios - 2));
                            xlsdocument.MergeWorksheetCells("G" + auxrowOrpa, "G" + (rowservicios - 2));
                            xlsdocument.MergeWorksheetCells("H" + auxrowOrpa, "H" + (rowservicios - 2));
                            xlsdocument.MergeWorksheetCells("I" + auxrowOrpa, "I" + (rowservicios - 2));
                            xlsdocument.MergeWorksheetCells("J" + auxrowOrpa, "J" + (rowservicios - 2));
                            xlsdocument.MergeWorksheetCells("K" + auxrowOrpa, "K" + (rowservicios - 2));
                            xlsdocument.MergeWorksheetCells("L" + auxrowOrpa, "L" + (rowservicios - 2));
                            xlsdocument.MergeWorksheetCells("M" + auxrowOrpa, "M" + (rowservicios - 2));
                            xlsdocument.MergeWorksheetCells("N" + auxrowOrpa, "N" + (rowservicios - 2));
                            xlsdocument.MergeWorksheetCells("O" + auxrowOrpa, "O" + (rowservicios - 2));
                            xlsdocument.MergeWorksheetCells("P" + auxrowOrpa, "P" + (rowservicios - 2));
                            xlsdocument.MergeWorksheetCells("W" + auxrowOrpa, "W" + (rowservicios - 2));
                            xlsdocument.MergeWorksheetCells("X" + auxrowOrpa, "X" + (rowservicios - 2));
                        }
                        else
                        {
                            rowservicios++;
                            xlsdocument.HideRow(rowservicios - 1);
                            xlsdocument.MergeWorksheetCells("A" + auxrowOrpa, "A" + (rowservicios - 1));
                            xlsdocument.MergeWorksheetCells("B" + auxrowOrpa, "B" + (rowservicios - 1));
                            xlsdocument.MergeWorksheetCells("C" + auxrowOrpa, "C" + (rowservicios - 1));
                            xlsdocument.MergeWorksheetCells("D" + auxrowOrpa, "D" + (rowservicios - 1));
                            xlsdocument.MergeWorksheetCells("E" + auxrowOrpa, "E" + (rowservicios - 1));
                            xlsdocument.MergeWorksheetCells("F" + auxrowOrpa, "F" + (rowservicios - 1));
                            xlsdocument.MergeWorksheetCells("G" + auxrowOrpa, "G" + (rowservicios - 1));
                            xlsdocument.MergeWorksheetCells("H" + auxrowOrpa, "H" + (rowservicios - 1));
                            xlsdocument.MergeWorksheetCells("I" + auxrowOrpa, "I" + (rowservicios - 1));
                            xlsdocument.MergeWorksheetCells("J" + auxrowOrpa, "J" + (rowservicios - 1));
                            xlsdocument.MergeWorksheetCells("K" + auxrowOrpa, "K" + (rowservicios - 1));
                            xlsdocument.MergeWorksheetCells("L" + auxrowOrpa, "L" + (rowservicios - 1));
                            xlsdocument.MergeWorksheetCells("M" + auxrowOrpa, "M" + (rowservicios - 1));
                            xlsdocument.MergeWorksheetCells("N" + auxrowOrpa, "N" + (rowservicios - 1));
                            xlsdocument.MergeWorksheetCells("O" + auxrowOrpa, "O" + (rowservicios - 1));
                            xlsdocument.MergeWorksheetCells("P" + auxrowOrpa, "P" + (rowservicios - 1));
                            xlsdocument.MergeWorksheetCells("W" + auxrowOrpa, "W" + (rowservicios - 1));
                            xlsdocument.MergeWorksheetCells("X" + auxrowOrpa, "X" + (rowservicios - 1));
                        }


                    }
                    xlsdocument.SetCellStyle("A" + rowservicios, "X" + rowservicios, rowBorder);
                    //rowRubNew = rowTot + 1;
                    rowOpServicios = rowservicios + 1;

                }

                rub3 = false;

                if (nmsServicios.Length > 1)
                {

                    if (deleteServicios == true)
                    {

                        xlsdocument.DeleteRow(rowSer2 + 2, rowOpServicios - (rowSer2 + 2));
                        //                           rowRubNew = rowRubNew - 21;
                        xlsdocument.HideRow(rowSer2 + 2, rowOpServicios - 1);
                    }
                    deleteServicios = false;

                    xlsdocument.SetCellValue(rowOpServicios, 1, "RUBRO");
                    xlsdocument.SetCellStyle(rowOpServicios, 1, adquisicionServicios);
                    xlsdocument.SetCellValue(rowOpServicios, 2, registro.nombrerubro);
                    xlsdocument.MergeWorksheetCells("A" + rowOpServicios, "A" + (rowOpServicios + 2));
                    xlsdocument.MergeWorksheetCells("B" + rowOpServicios, "N" + (rowOpServicios + 2));
                    xlsdocument.MergeWorksheetCells("O" + rowOpServicios, "R" + rowOpServicios);
                    xlsdocument.SetCellValue(rowOpServicios, 15, "VALOR");
                    xlsdocument.SetCellStyle(rowOpServicios, 15, adquisicionServicios);
                    xlsdocument.MergeWorksheetCells("O" + (rowOpServicios + 1), "R" + (rowOpServicios + 1));
                    xlsdocument.SetCellValue(rowOpServicios + 1, 15, "EJECUTADO");
                    xlsdocument.SetCellStyle(rowOpServicios + 1, 15, adquisicionServicios);
                    xlsdocument.MergeWorksheetCells("O" + (rowOpServicios + 2), "R" + (rowOpServicios + 2));
                    xlsdocument.SetCellValue(rowOpServicios + 2, 15, "DISPONIBILIDAD DEL RUBRO");
                    xlsdocument.SetCellStyle(rowOpServicios + 2, 15, adquisicionServicios);
                    xlsdocument.MergeWorksheetCells("S" + rowOpServicios, "X" + rowOpBienes);
                    xlsdocument.MergeWorksheetCells("S" + (rowOpServicios + 1), "X" + (rowOpServicios + 1));
                    xlsdocument.MergeWorksheetCells("S" + (rowOpServicios + 2), "X" + (rowOpServicios + 2));
                    xlsdocument.MergeWorksheetCells("A" + (rowOpServicios + 3), "A" + (rowOpServicios + 4));
                    xlsdocument.SetCellValue(rowOpServicios + 3, 1, "CONCEPTO");
                    xlsdocument.SetColumnWidth("A" + (rowOpServicios + 3), 15.0);
                    xlsdocument.SetCellStyle(rowOpServicios + 3, 1, adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("B" + (rowOpServicios + 3), "B" + (rowOpServicios + 4));
                    xlsdocument.SetCellValue(rowOpServicios + 3, 2, "NOMBRE");
                    xlsdocument.SetCellStyle(rowOpServicios + 3, 2, adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("C" + (rowOpServicios + 3), "C" + (rowOpServicios + 4));
                    xlsdocument.SetCellValue(rowOpServicios + 3, 3, "IDENTIFICACION");
                    xlsdocument.SetColumnWidth("C" + (rowOpServicios + 3), 25.0);
                    xlsdocument.SetCellStyle(rowOpServicios + 3, 3, adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("D" + (rowOpServicios + 3), "D" + (rowOpServicios + 4));
                    xlsdocument.SetCellValue(rowOpServicios + 3, 4, "AREA");
                    xlsdocument.SetCellStyle(rowOpServicios + 3, 4, adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("E" + (rowOpServicios + 3), "H" + (rowOpServicios + 3));
                    xlsdocument.SetCellValue("E" + (rowOpServicios + 3), "RELACION DEL VINCULO");
                    xlsdocument.SetCellStyle("E" + (rowOpServicios + 3), adquisicionServiciosCentred);
                    xlsdocument.SetCellValue("E" + (rowOpServicios + 4), "PREGRADO");
                    xlsdocument.SetCellStyle("E" + (rowOpServicios + 4), adquisicionServiciosCentred);
                    xlsdocument.SetColumnWidth("E" + (rowOpServicios + 4), 20.0);
                    xlsdocument.SetCellValue("F" + (rowOpServicios + 4), "POSGRADO");
                    xlsdocument.SetCellStyle("F" + (rowOpServicios + 4), adquisicionServiciosCentred);
                    xlsdocument.SetColumnWidth("F" + (rowOpServicios + 4), 20.0);
                    xlsdocument.SetCellValue("G" + (rowOpServicios + 4), "EGRESADO");
                    xlsdocument.SetCellStyle("G" + (rowOpServicios + 4), adquisicionServiciosCentred);
                    xlsdocument.SetColumnWidth("G" + (rowOpServicios + 4), 20.0);
                    xlsdocument.SetCellValue("H" + (rowOpServicios + 4), "OTRO");
                    xlsdocument.SetCellStyle("H" + (rowOpServicios + 4), adquisicionServiciosCentred);
                    xlsdocument.SetColumnWidth("H" + (rowOpServicios + 4), 20.0);
                    xlsdocument.MergeWorksheetCells("I" + (rowOpServicios + 3), "I" + (rowOpServicios + 4));
                    xlsdocument.SetCellValue("I" + (rowOpServicios + 3), "FECHA");
                    xlsdocument.SetCellStyle("I" + (rowOpServicios + 3), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("J" + (rowOpServicios + 3), "J" + (rowOpServicios + 4));
                    xlsdocument.SetCellValue("J" + (rowOpServicios + 3), "TIPO");
                    xlsdocument.SetCellStyle("J" + (rowOpServicios + 3), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("K" + (rowOpServicios + 3), "K" + (rowOpServicios + 4));
                    xlsdocument.SetCellValue("K" + (rowOpServicios + 3), "No.");
                    xlsdocument.SetCellStyle("K" + (rowOpServicios + 3), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("L" + (rowOpServicios + 3), "L" + (rowOpServicios + 4));
                    xlsdocument.SetCellValue("L" + (rowOpServicios + 3), "FECHA INICIO");
                    xlsdocument.SetCellStyle("L" + (rowOpServicios + 3), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("M" + (rowOpServicios + 3), "M" + (rowOpServicios + 4));
                    xlsdocument.SetCellValue("M" + (rowOpServicios + 3), "FECHA FINAL");
                    xlsdocument.SetCellStyle("M" + (rowOpServicios + 3), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("N" + (rowOpServicios + 3), "N" + (rowOpServicios + 4));
                    xlsdocument.SetCellValue("N" + (rowOpServicios + 3), "ESTADO");
                    xlsdocument.SetCellStyle("N" + (rowOpServicios + 3), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("O" + (rowOpServicios + 3), "O" + (rowOpServicios + 4));
                    xlsdocument.SetCellValue("O" + (rowOpServicios + 3), "Valor Total");
                    xlsdocument.SetCellStyle("O" + (rowOpServicios + 3), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("P" + (rowOpServicios + 3), "P" + (rowOpServicios + 4));
                    xlsdocument.SetCellValue("P" + (rowOpServicios + 3), "Valor con 4 xmil");
                    xlsdocument.SetCellStyle("P" + (rowOpServicios + 3), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("Q" + (rowOpServicios + 3), "V" + (rowOpServicios + 3));
                    xlsdocument.SetCellValue("Q" + (rowOpServicios + 3), "PAGOS");
                    xlsdocument.SetCellStyle("Q" + (rowOpServicios + 3), adquisicionServiciosCentred);
                    xlsdocument.SetCellValue("Q" + (rowOpServicios + 4), "ORPA");
                    xlsdocument.SetCellStyle("Q" + (rowOpServicios + 4), adquisicionServiciosCentred);
                    xlsdocument.SetCellValue("R" + (rowOpServicios + 4), "FECHA");
                    xlsdocument.SetCellStyle("R" + (rowOpServicios + 4), adquisicionServiciosCentred);
                    xlsdocument.SetCellValue("S" + (rowOpServicios + 4), "CP.EGR");
                    xlsdocument.SetCellStyle("S" + (rowOpServicios + 4), adquisicionServiciosCentred);
                    xlsdocument.SetCellValue("T" + (rowOpServicios + 4), "PERIODO");
                    xlsdocument.SetCellStyle("T" + (rowOpServicios + 4), adquisicionServiciosCentred);
                    xlsdocument.SetCellValue("U" + (rowOpServicios + 4), "VALOR NETO");
                    xlsdocument.SetCellStyle("U" + (rowOpServicios + 4), adquisicionServiciosCentred);
                    xlsdocument.SetCellValue("V" + (rowOpServicios + 4), "VALOR 4*1000");
                    xlsdocument.SetCellStyle("V" + (rowOpServicios + 4), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("W" + (rowOpServicios + 3), "W" + (rowOpServicios + 4));
                    xlsdocument.SetCellValue("W" + (rowOpServicios + 3), "SALDO PENDIENTE");
                    xlsdocument.SetCellStyle("W" + (rowOpServicios + 3), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("X" + (rowOpServicios + 3), "X" + (rowOpServicios + 4));
                    xlsdocument.SetCellValue("X" + (rowOpServicios + 3), "OBSERVACION");
                    xlsdocument.SetCellStyle("X" + (rowOpServicios + 3), adquisicionServiciosCentred);
                    xlsdocument.SetColumnWidth("L" + (rowOpServicios + 3), 25.0);
                    xlsdocument.SetColumnWidth("M" + (rowOpServicios + 3), 25.0);
                    xlsdocument.SetColumnWidth("N" + (rowOpServicios + 3), 25.0);
                    xlsdocument.SetColumnWidth("O" + (rowOpServicios + 3), 25.0);
                    xlsdocument.SetColumnWidth("P" + (rowOpServicios + 3), 25.0);
                    xlsdocument.SetColumnWidth("Q" + (rowOpServicios + 3), 25.0);
                    xlsdocument.SetColumnWidth("R" + (rowOpServicios + 3), 25.0);
                    xlsdocument.SetColumnWidth("S" + (rowOpServicios + 3), 25.0);
                    xlsdocument.SetColumnWidth("T" + (rowOpServicios + 3), 25.0);
                    xlsdocument.SetColumnWidth("U" + (rowOpServicios + 3), 25.0);
                    xlsdocument.SetColumnWidth("V" + (rowOpServicios + 3), 25.0);
                    xlsdocument.SetColumnWidth("W" + (rowOpServicios + 3), 25.0);
                    xlsdocument.SetColumnWidth("X" + (rowOpServicios + 3), 25.0);

                    id_rubro = registro.id_rubro;


                    //Incluimos el valor total por concepto 


                    //Incluimos el valor total por concepto 
                    string qryValorTotal = "select sum (valortotal) from investigacion_gasto where id_crearproyecto = @id_crearproyecto and id_partida = 3 and id_rubro = @id_rubro";
                    List<NpgsqlParameter> parameterListTotal = new List<NpgsqlParameter>();
                    parameterListTotal.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                    parameterListTotal.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                    NpgsqlParameter[] ParamTotal = parameterListTotal.ToArray();




                    var datosTotal = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryValorTotal, ParamTotal).ToList();



                    foreach (var registroN in datosTotal)
                    {
                        var cuatroxmil = (registroN.sum * 4 / 1000) + registroN.sum;
                        if (cuatroxmil != null)
                            xlsdocument.SetCellValue("S" + (rowOpServicios), (int)cuatroxmil);

                    }

                    string qryorpa = "select co.nombreconcepto, pe.nombrecompleto , pe.numidentificacion, rv.id_relacionvinculo, ga.fechainicio, ga.fechafinal, ga.numorden, ga.fechalegalizacionorden, ga.tipo, ga.valortotal, ga.estado, ga.id_investigaciongasto from investigacion_gasto ga join seguimiento_concepto co on ga.id_segconcepto = co.id_segconcepto join persona pe on ga.id_persona = pe.id_persona join seguimiento_relacionvinculo rv on ga.id_relacionvinculo = rv.id_relacionvinculo where ga.id_crearproyecto = @id_crearproyecto and ga.id_partida = 3 and ga.id_rubro = @id_rubro";
                    List<NpgsqlParameter> parameterListOrpa = new List<NpgsqlParameter>();
                    parameterListOrpa.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                    parameterListOrpa.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                    NpgsqlParameter[] ParamOrpa = parameterListOrpa.ToArray();

                    var datosOrpa = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryorpa, ParamOrpa).ToList();




                    var auxrowOrpa = 0;
                    var auxOrpa2 = true;

                    var optSec = true;
                    //27 tot
                    var cuatroxMil = 0;
                    var totalCuatroxMil = 0;

                    var auxSer = rowOpServicios + 5;

                    var rowOrpa = auxSer;

                    var Spendiente = 0;
                    var auxSpendiente = 0;

                    optOrpa = false;
                    foreach (var dataorpa in datosOrpa)
                    {
                        auxOrpa2 = true;

                        id_investigaciongasto = dataorpa.id_investigaciongasto;
                        if (cuatroxMil != null)
                            cuatroxMil = ((int)dataorpa.valortotal * 4 / 1000) + (int)dataorpa.valortotal;
                        totalCuatroxMil += cuatroxMil;
                        xlsdocument.SetCellValue(rowOrpa, 1, dataorpa.nombreconcepto);
                        xlsdocument.SetCellValue("B" + rowOrpa, dataorpa.nombrecompleto);
                        xlsdocument.SetCellValue("C" + rowOrpa, dataorpa.numidentificacion);
                        xlsdocument.SetCellValue("I" + rowOrpa, dataorpa.fechalegalizacionorden.ToString());
                        xlsdocument.SetCellValue("J" + rowOrpa, dataorpa.tipo);
                        xlsdocument.SetCellValue("K" + rowOrpa, dataorpa.numorden);
                        xlsdocument.SetCellValue("L" + rowOrpa, dataorpa.fechainicio.ToString());
                        xlsdocument.SetCellValue("M" + rowOrpa, dataorpa.fechafinal.ToString());
                        xlsdocument.SetCellValue("N" + rowOrpa, dataorpa.estado);
                        xlsdocument.SetCellValue("X" + rowOrpa, dataorpa.observaciones);
                        if (dataorpa.valortotal != null)
                            xlsdocument.SetCellValue("O" + rowOrpa, (int)dataorpa.valortotal);
                        xlsdocument.SetCellValue("P" + rowOrpa, cuatroxMil);

                        optSec = false;


                        if (dataorpa.id_relacionvinculo == 1 || dataorpa.id_relacionvinculo == 2)
                        {
                            xlsdocument.SetCellValue("H" + rowOrpa, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 3)
                        {
                            xlsdocument.SetCellValue("E" + rowOrpa, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 4)
                        {
                            xlsdocument.SetCellValue("F" + rowOrpa, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 5)
                        {
                            xlsdocument.SetCellValue("G" + rowOrpa, "X");

                        }


                        string qryPagos = "select ap.orpa, ap.fechapago, ap.cp_egr, sm.nmsemestre, ap.valorneto from investigacion_aplicarpago ap join investigacion_gasto ga on ap.id_investigaciongasto = ga.id_investigaciongasto join seguimiento_rubro rub on ga.id_rubro = rub.id_rubro join seguimiento_partida ru on ga.id_partida = ru.id_partida join seguimiento_concepto co on ga.id_segconcepto = co.id_segconcepto join semestre sm on ap.id_semestre = sm.id_semestre join seguimiento_relacionvinculo rv on ga.id_relacionvinculo = rv.id_relacionvinculo join persona pe on ga.id_persona = pe.id_persona where ap.id_crearproyecto = @id_crearproyecto and ru.id_partida = 3 and rub.id_rubro = @id_rubro and ga.id_investigaciongasto = @id_investigaciongasto group by  ap.orpa, ap.fechapago, ap.cp_egr, sm.nmsemestre, ap.valorneto";
                        List<NpgsqlParameter> parameterListPagos = new List<NpgsqlParameter>();
                        parameterListPagos.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                        parameterListPagos.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                        parameterListPagos.Add(new NpgsqlParameter("@id_investigaciongasto", id_investigaciongasto));
                        NpgsqlParameter[] ParamPagos = parameterListPagos.ToArray();

                        var datosPagos = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryPagos, ParamPagos).ToList();

                        var nmOrpas = datosPagos.Select(x => x.orpa).ToArray();

                        string qryEjecutado = "select sum(ap.valorneto) as ejecutado from investigacion_aplicarpago ap join investigacion_gasto ga on ap.id_investigaciongasto = ga.id_investigaciongasto join seguimiento_rubro rub on ga.id_rubro = rub.id_rubro join seguimiento_partida ru on ga.id_partida = ru.id_partida where ap.id_crearproyecto = @id_crearproyecto and ru.id_partida = 3 and rub.id_rubro = @id_rubro";
                        List<NpgsqlParameter> parameterListEjecutado = new List<NpgsqlParameter>();
                        parameterListEjecutado.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                        parameterListEjecutado.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                        NpgsqlParameter[] ParamEjecutado = parameterListEjecutado.ToArray();




                        var datosEjecutado = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryEjecutado, ParamEjecutado).ToList();


                        foreach (var registroE in datosEjecutado)
                        {
                            var cuatroxmil = (registroE.ejecutado * 4 / 1000) + registroE.ejecutado;
                            var disponibilidad = totalCuatroxMil - cuatroxmil;

                            if (cuatroxmil != null)
                                xlsdocument.SetCellValue("S" + (rowOpServicios + 1), (int)cuatroxmil);
                            if (disponibilidad != null)

                                xlsdocument.SetCellValue("S" + (rowOpServicios + 2), (int)disponibilidad);



                        }


                        auxSpendiente = 0;
                        foreach (var pagos in datosPagos)
                        {
                            if (auxOrpa2 == true)
                            {
                                auxrowOrpa = rowOrpa;
                            }
                            auxOrpa2 = false;
                            if (cuatropormilPagos != null)
                                cuatropormilPagos = ((int)pagos.valorneto * 4 / 1000) + (int)pagos.valorneto;

                            xlsdocument.SetCellValue("Q" + rowOrpa, pagos.orpa);
                            xlsdocument.SetCellValue("R" + rowOrpa, pagos.fechapago.ToString());
                            xlsdocument.SetCellValue("S" + rowOrpa, pagos.cp_egr);
                            xlsdocument.SetCellValue("T" + rowOrpa, pagos.nmsemestre);
                            if (pagos.valorneto != null)
                                xlsdocument.SetCellValue("U" + rowOrpa, (int)pagos.valorneto);
                            xlsdocument.SetCellValue("V" + rowOrpa, cuatropormilPagos);

                            auxSpendiente += cuatropormilPagos;

                            if (nmOrpas.Length == 1)
                            {
                                Spendiente = (int)(cuatroxMil - cuatropormilPagos);

                            }

                            rowOrpa++;
                        }

                        if (nmOrpas.Length == 1)
                        {
                            xlsdocument.SetCellValue("W" + (rowOrpa - 1), Spendiente);
                        }
                        if (nmOrpas.Length > 1)
                        {
                            Spendiente = (int)(cuatroxMil - auxSpendiente);
                            xlsdocument.SetCellValue("W" + auxrowOrpa, Spendiente);
                        }

                        if (nmOrpas.Length == 0)
                        {
                            Spendiente = cuatroxMil;
                            xlsdocument.SetCellValue("W" + rowOrpa, Spendiente);
                            rowOrpa++;
                            xlsdocument.MergeWorksheetCells("A" + auxrowOrpa, "A" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("B" + auxrowOrpa, "B" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("C" + auxrowOrpa, "C" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("D" + auxrowOrpa, "D" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("E" + auxrowOrpa, "E" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("F" + auxrowOrpa, "F" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("G" + auxrowOrpa, "G" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("H" + auxrowOrpa, "H" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("I" + auxrowOrpa, "I" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("J" + auxrowOrpa, "J" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("K" + auxrowOrpa, "K" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("L" + auxrowOrpa, "L" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("M" + auxrowOrpa, "M" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("N" + auxrowOrpa, "N" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("O" + auxrowOrpa, "O" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("P" + auxrowOrpa, "P" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("W" + auxrowOrpa, "W" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("X" + auxrowOrpa, "X" + (rowOrpa - 2));
                        }
                        else
                        {
                            xlsdocument.MergeWorksheetCells("A" + auxrowOrpa, "A" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("B" + auxrowOrpa, "B" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("C" + auxrowOrpa, "C" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("D" + auxrowOrpa, "D" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("E" + auxrowOrpa, "E" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("F" + auxrowOrpa, "F" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("G" + auxrowOrpa, "G" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("H" + auxrowOrpa, "H" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("I" + auxrowOrpa, "I" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("J" + auxrowOrpa, "J" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("K" + auxrowOrpa, "K" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("L" + auxrowOrpa, "L" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("M" + auxrowOrpa, "M" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("N" + auxrowOrpa, "N" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("O" + auxrowOrpa, "O" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("P" + auxrowOrpa, "P" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("W" + auxrowOrpa, "W" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("X" + auxrowOrpa, "X" + (rowOrpa - 1));
                        }

                    }
                    auxOrpa = rowOrpa;
                    xlsdocument.SetCellStyle("A" + rowOrpa, "X" + rowOrpa, rowBorder);
                    rowOpServicios = rowOpServicios + (auxOrpa - rowOpServicios) + 1;
                    rowImp = rowOpServicios;

                }

            }
            if (nmsServicios.Length == 1)
            {
                rowImp = rowOpServicios;

            }
            else if (nmsServicios.Length == 0)
            {
                rowImp = rowSer2 + 2;
            }

            /*
             auxOrpa = rowOrpa;
                    xlsdocument.SetCellStyle("A" + rowOrpa, "X" + rowOrpa, rowBorder);
                    rowRubNew = rowRubNew + (auxOrpa - rowRubNew) + 1;
                    rowSer = rowRubNew;
            */
            SLStyle impuestos = xlsdocument.CreateStyle();
            SLStyle impuestosCentred = xlsdocument.CreateStyle();

            impuestos.Font.FontName = "Times New Roman";
            impuestos.Font.FontSize = 14.0;
            impuestos.Font.Bold = true;
            impuestos.Alignment.Horizontal = HorizontalAlignmentValues.Left;
            impuestos.Alignment.Vertical = VerticalAlignmentValues.Center;
            impuestos.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.FromArgb(255, 255, 0), System.Drawing.Color.Blue);

            impuestosCentred.Font.FontName = "Times New Roman";
            impuestosCentred.Font.FontSize = 14.0;
            impuestosCentred.Font.Bold = true;
            impuestosCentred.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            impuestosCentred.Alignment.Vertical = VerticalAlignmentValues.Center;
            impuestosCentred.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.FromArgb(255, 255, 0), System.Drawing.Color.Blue);


            xlsdocument.MergeWorksheetCells(rowImp, 1, rowImp, 24);
            xlsdocument.SetCellValue(rowImp, 1, "4. IMPUESTOS, CONTRIBUCIONES Y MULTAS");
            xlsdocument.SetCellStyle(rowImp, 1, impuestos);
            xlsdocument.SetCellStyle("A" + (rowImp + 1), "X" + (rowImp + 1), rowBorder);
            xlsdocument.SetRowHeight(rowImp + 1, 11.0);


            string qryImpuestos = "select DISTINCT ru.nombrerubro, ru.id_rubro from investigacion_gasto ga join seguimiento_rubro ru on ga.id_rubro = ru.id_rubro where ga.id_crearproyecto=@id_crearproyecto and ga.id_partida = 4";
            List<NpgsqlParameter> parameterListImpuestos = new List<NpgsqlParameter>();
            parameterListImpuestos.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
            NpgsqlParameter[] ParamImpuestos = parameterListImpuestos.ToArray();

            var datosimpuestos = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryImpuestos, ParamImpuestos).ToList();

            var nmsImpuestos = datosimpuestos.Select(x => x.nombreconcepto).ToArray();


            var rub4 = true;

            foreach (var registro in datosimpuestos)
            {

                if (rub4 == true)
                {

                    xlsdocument.SetCellValue(rowImp + 2, 1, "RUBRO");
                    xlsdocument.SetCellStyle(rowImp + 2, 1, impuestos);
                    xlsdocument.SetCellValue(rowImp + 2, 2, registro.nombrerubro);
                    xlsdocument.MergeWorksheetCells("A" + (rowImp + 2), "A" + (rowImp + 4));
                    xlsdocument.MergeWorksheetCells("B" + (rowImp + 2), "N" + (rowImp + 4));
                    xlsdocument.MergeWorksheetCells("O" + (rowImp + 2), "R" + (rowImp + 2));
                    xlsdocument.SetCellValue(rowImp + 2, 15, "VALOR");
                    xlsdocument.SetCellStyle(rowImp + 2, 15, impuestos);
                    xlsdocument.MergeWorksheetCells("O" + (rowImp + 4), "R" + (rowImp + 4));
                    xlsdocument.SetCellValue(rowImp + 3, 15, "EJECUTADO");


                    xlsdocument.SetCellStyle(rowImp + 3, 15, impuestos);
                    xlsdocument.MergeWorksheetCells("O" + (rowImp + 3), "R" + (rowImp + 3));
                    xlsdocument.SetCellValue(rowImp + 4, 15, "DISPONIBILIDAD DEL RUBRO");
                    xlsdocument.SetCellStyle(rowImp + 4, 15, impuestos);
                    xlsdocument.MergeWorksheetCells("S" + (rowImp + 2), "X" + (rowImp + 2));
                    xlsdocument.MergeWorksheetCells("S" + (rowImp + 3), "X" + (rowImp + 3));
                    xlsdocument.MergeWorksheetCells("S" + (rowImp + 4), "X" + (rowImp + 4));


                    xlsdocument.MergeWorksheetCells("A" + (rowImp + 5), "A" + (rowImp + 6));
                    xlsdocument.SetCellValue(rowImp + 5, 1, "CONCEPTO");
                    xlsdocument.SetColumnWidth("A" + (rowImp + 5), 15.0);
                    xlsdocument.SetCellStyle(rowImp + 5, 1, impuestosCentred);
                    xlsdocument.MergeWorksheetCells("B" + (rowImp + 5), "B" + (rowImp + 6));
                    xlsdocument.SetCellValue(rowImp + 5, 2, "NOMBRE");
                    xlsdocument.SetCellStyle(rowImp + 5, 2, impuestosCentred);
                    xlsdocument.MergeWorksheetCells("C" + (rowImp + 5), "C" + (rowImp + 6));
                    xlsdocument.SetCellValue(rowImp + 5, 3, "IDENTIFICACION");
                    //xlsdocument.AutoFitColumn("C"+(row+12));
                    xlsdocument.SetColumnWidth("C" + (rowImp + 5), 25.0);
                    xlsdocument.SetCellStyle(rowImp + 5, 3, impuestosCentred);
                    xlsdocument.MergeWorksheetCells("D" + (rowImp + 5), "D" + (rowImp + 6));
                    xlsdocument.SetCellValue(rowImp + 5, 4, "AREA");
                    xlsdocument.SetCellStyle(rowImp + 5, 4, impuestosCentred);
                    xlsdocument.MergeWorksheetCells("E" + (rowImp + 5), "H" + (rowImp + 5));
                    xlsdocument.SetCellValue("E" + (rowImp + 5), "RELACION DEL VINCULO");
                    xlsdocument.SetCellStyle("E" + (rowImp + 5), impuestosCentred);
                    xlsdocument.SetCellValue("E" + (rowImp + 6), "PREGRADO");
                    xlsdocument.SetCellStyle("E" + (rowImp + 6), impuestosCentred);
                    xlsdocument.SetColumnWidth("E" + (rowImp + 6), 20.0);
                    xlsdocument.SetCellValue("F" + (rowImp + 6), "POSGRADO");
                    xlsdocument.SetCellStyle("F" + (rowImp + 6), impuestosCentred);
                    xlsdocument.SetColumnWidth("F" + (rowImp + 6), 20.0);
                    xlsdocument.SetCellValue("G" + (rowImp + 6), "EGRESADO");
                    xlsdocument.SetCellStyle("G" + (rowImp + 6), impuestosCentred);
                    xlsdocument.SetColumnWidth("G" + (rowImp + 6), 20.0);
                    xlsdocument.SetCellValue("H" + (rowImp + 6), "OTRO");
                    xlsdocument.SetCellStyle("H" + (rowImp + 6), impuestosCentred);
                    xlsdocument.SetColumnWidth("H" + (rowImp + 6), 20.0);
                    xlsdocument.MergeWorksheetCells("I" + (rowImp + 5), "I" + (rowImp + 6));
                    xlsdocument.SetCellValue("I" + (rowImp + 5), "FECHA");
                    xlsdocument.SetCellStyle("I" + (rowImp + 5), impuestosCentred);
                    xlsdocument.MergeWorksheetCells("J" + (rowImp + 5), "J" + (rowImp + 6));
                    xlsdocument.SetCellValue("J" + (rowImp + 5), "TIPO");
                    xlsdocument.SetCellStyle("J" + (rowImp + 5), impuestosCentred);
                    xlsdocument.MergeWorksheetCells("K" + (rowImp + 5), "K" + (rowImp + 6));
                    xlsdocument.SetCellValue("K" + (rowImp + 5), "No.");
                    xlsdocument.SetCellStyle("K" + (rowImp + 5), impuestosCentred);
                    xlsdocument.MergeWorksheetCells("L" + (rowImp + 5), "L" + (rowImp + 6));
                    xlsdocument.SetCellValue("L" + (rowImp + 5), "FECHA INICIO");
                    xlsdocument.SetCellStyle("L" + (rowImp + 5), impuestosCentred);
                    xlsdocument.MergeWorksheetCells("M" + (rowImp + 5), "M" + (rowImp + 6));
                    xlsdocument.SetCellValue("M" + (rowImp + 5), "FECHA FINAL");
                    xlsdocument.SetCellStyle("M" + (rowImp + 5), impuestosCentred);
                    xlsdocument.MergeWorksheetCells("N" + (rowImp + 5), "N" + (rowImp + 6));
                    xlsdocument.SetCellValue("N" + (rowImp + 5), "ESTADO");
                    xlsdocument.SetCellStyle("N" + (rowImp + 5), impuestosCentred);
                    xlsdocument.MergeWorksheetCells("O" + (rowImp + 5), "O" + (rowImp + 6));
                    xlsdocument.SetCellValue("O" + (rowImp + 5), "Valor Total");
                    xlsdocument.SetCellStyle("O" + (rowImp + 5), impuestosCentred);
                    xlsdocument.MergeWorksheetCells("P" + (rowImp + 5), "P" + (rowImp + 6));
                    xlsdocument.SetCellValue("P" + (rowImp + 5), "Valor con 4 xmil");
                    xlsdocument.SetCellStyle("P" + (rowImp + 5), impuestosCentred);
                    xlsdocument.MergeWorksheetCells("Q" + (rowImp + 5), "V" + (rowImp + 5));
                    xlsdocument.SetCellValue("Q" + (rowImp + 5), "PAGOS");
                    xlsdocument.SetCellStyle("Q" + (rowImp + 5), impuestosCentred);
                    xlsdocument.SetCellValue("Q" + (rowImp + 6), "ORPA");
                    xlsdocument.SetCellStyle("Q" + (rowImp + 6), impuestosCentred);
                    xlsdocument.SetCellValue("R" + (rowImp + 6), "FECHA");
                    xlsdocument.SetCellStyle("R" + (rowImp + 6), impuestosCentred);
                    xlsdocument.SetCellValue("S" + (rowImp + 6), "CP.EGR");
                    xlsdocument.SetCellStyle("S" + (rowImp + 6), impuestosCentred);
                    xlsdocument.SetCellValue("T" + (rowImp + 6), "PERIODO");
                    xlsdocument.SetCellStyle("T" + (rowImp + 6), impuestosCentred);
                    xlsdocument.SetCellValue("U" + (rowImp + 6), "VALOR NETO");
                    xlsdocument.SetCellStyle("U" + (rowImp + 6), impuestosCentred);
                    xlsdocument.SetCellValue("V" + (rowImp + 6), "VALOR 4*1000");
                    xlsdocument.SetCellStyle("V" + (rowImp + 6), impuestosCentred);
                    xlsdocument.MergeWorksheetCells("W" + (rowImp + 5), "W" + (rowImp + 6));
                    xlsdocument.SetCellValue("W" + (rowImp + 5), "SALDO PENDIENTE");
                    xlsdocument.SetCellStyle("W" + (rowImp + 5), impuestosCentred);
                    xlsdocument.MergeWorksheetCells("X" + (rowImp + 5), "X" + (rowImp + 6));
                    xlsdocument.SetCellValue("X" + (rowImp + 5), "OBSERVACION");
                    xlsdocument.SetCellStyle("X" + (rowImp + 5), impuestosCentred);
                    xlsdocument.SetColumnWidth("L" + (rowImp + 5), 25.0);
                    xlsdocument.SetColumnWidth("M" + (rowImp + 5), 25.0);
                    xlsdocument.SetColumnWidth("N" + (rowImp + 5), 25.0);
                    xlsdocument.SetColumnWidth("O" + (rowImp + 5), 25.0);
                    xlsdocument.SetColumnWidth("P" + (rowImp + 5), 25.0);
                    xlsdocument.SetColumnWidth("Q" + (rowImp + 5), 25.0);
                    xlsdocument.SetColumnWidth("R" + (rowImp + 5), 25.0);
                    xlsdocument.SetColumnWidth("S" + (rowImp + 5), 25.0);
                    xlsdocument.SetColumnWidth("T" + (rowImp + 5), 25.0);
                    xlsdocument.SetColumnWidth("U" + (rowImp + 5), 25.0);
                    xlsdocument.SetColumnWidth("V" + (rowImp + 5), 25.0);
                    xlsdocument.SetColumnWidth("W" + (rowImp + 5), 25.0);
                    xlsdocument.SetColumnWidth("X" + (rowImp + 5), 25.0);


                    id_rubro = registro.id_rubro;


                    //Incluimos el valor total por concepto 
                    string qryValorTotal = "select sum (valortotal) from investigacion_gasto where id_crearproyecto = @id_crearproyecto and id_partida = 4 and id_rubro = @id_rubro";
                    List<NpgsqlParameter> parameterListTotal = new List<NpgsqlParameter>();
                    parameterListTotal.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                    parameterListTotal.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                    NpgsqlParameter[] ParamTotal = parameterListTotal.ToArray();



                    var datosTotal = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryValorTotal, ParamTotal).ToList();



                    foreach (var registroN in datosTotal)
                    {
                        var cuatroxmil = (registroN.sum * 4 / 1000) + registroN.sum;
                        if (cuatroxmil != null)
                            xlsdocument.SetCellValue("S" + (rowImp + 2), (int)cuatroxmil);

                    }


                    string qryorpa = "select co.nombreconcepto, pe.nombrecompleto , pe.numidentificacion, rv.id_relacionvinculo, ga.fechainicio, ga.fechafinal, ga.numorden, ga.fechalegalizacionorden, ga.tipo, ga.valortotal, ga.estado, ga.id_investigaciongasto from investigacion_gasto ga join seguimiento_concepto co on ga.id_segconcepto = co.id_segconcepto join persona pe on ga.id_persona = pe.id_persona join seguimiento_relacionvinculo rv on ga.id_relacionvinculo = rv.id_relacionvinculo where ga.id_crearproyecto = @id_crearproyecto and ga.id_partida = 4 and ga.id_rubro = @id_rubro";
                    List<NpgsqlParameter> parameterListOrpa = new List<NpgsqlParameter>();
                    parameterListOrpa.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                    parameterListOrpa.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                    NpgsqlParameter[] ParamOrpa = parameterListOrpa.ToArray();

                    var datosOrpa = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryorpa, ParamOrpa).ToList();




                    var auxrowOrpa = 0;
                    var auxOrpa2 = true;


                    var opt = true;
                    //27 tot
                    var cuatroxMil = 0;
                    var totalCuatroxMil = 0;

                    var Spendiente = 0;
                    var auxSpendiente = 0;

                    if (rowImpues == true)
                    {
                        rowimpuestos = rowImp + 7;
                    }
                    rowImpues = false;

                    foreach (var dataorpa in datosOrpa)
                    {


                        auxOrpa2 = true;

                        id_investigaciongasto = dataorpa.id_investigaciongasto;
                        if (cuatroxMil != null)
                            cuatroxMil = ((int)dataorpa.valortotal * 4 / 1000) + (int)dataorpa.valortotal;
                        totalCuatroxMil += cuatroxMil;

                        xlsdocument.SetCellValue(rowimpuestos, 1, dataorpa.nombreconcepto);
                        xlsdocument.SetCellValue("B" + rowimpuestos, dataorpa.nombrecompleto);
                        xlsdocument.SetCellValue("C" + rowimpuestos, dataorpa.numidentificacion);
                        xlsdocument.SetCellValue("I" + rowimpuestos, dataorpa.fechalegalizacionorden.ToString());
                        xlsdocument.SetCellValue("J" + rowimpuestos, dataorpa.tipo);
                        xlsdocument.SetCellValue("K" + rowimpuestos, dataorpa.numorden);
                        xlsdocument.SetCellValue("L" + rowimpuestos, dataorpa.fechainicio.ToString());
                        xlsdocument.SetCellValue("M" + rowimpuestos, dataorpa.fechafinal.ToString());
                        xlsdocument.SetCellValue("N" + rowimpuestos, dataorpa.estado);
                        xlsdocument.SetCellValue("X" + rowimpuestos, dataorpa.observaciones);
                        if (dataorpa.valortotal != null)
                            xlsdocument.SetCellValue("O" + rowimpuestos, (int)dataorpa.valortotal);
                        xlsdocument.SetCellValue("P" + rowimpuestos, cuatroxMil);




                        if (dataorpa.id_relacionvinculo == 1 || dataorpa.id_relacionvinculo == 2)
                        {
                            xlsdocument.SetCellValue("H" + rowimpuestos, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 3)
                        {
                            xlsdocument.SetCellValue("E" + rowimpuestos, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 4)
                        {
                            xlsdocument.SetCellValue("F" + rowimpuestos, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 5)
                        {
                            xlsdocument.SetCellValue("G" + rowimpuestos, "X");

                        }


                        string qryPagos = "select ap.orpa, ap.fechapago, ap.cp_egr, sm.nmsemestre, ap.valorneto from investigacion_aplicarpago ap join investigacion_gasto ga on ap.id_investigaciongasto = ga.id_investigaciongasto join seguimiento_rubro rub on ga.id_rubro = rub.id_rubro join seguimiento_partida ru on ga.id_partida = ru.id_partida join seguimiento_concepto co on ga.id_segconcepto = co.id_segconcepto join semestre sm on ap.id_semestre = sm.id_semestre join seguimiento_relacionvinculo rv on ga.id_relacionvinculo = rv.id_relacionvinculo join persona pe on ga.id_persona = pe.id_persona where ap.id_crearproyecto = @id_crearproyecto and ru.id_partida = 4 and rub.id_rubro = @id_rubro and ga.id_investigaciongasto = @id_investigaciongasto group by  ap.orpa, ap.fechapago, ap.cp_egr, sm.nmsemestre, ap.valorneto";
                        List<NpgsqlParameter> parameterListPagos = new List<NpgsqlParameter>();
                        parameterListPagos.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                        parameterListPagos.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                        parameterListPagos.Add(new NpgsqlParameter("@id_investigaciongasto", id_investigaciongasto));
                        NpgsqlParameter[] ParamPagos = parameterListPagos.ToArray();

                        var datosPagos = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryPagos, ParamPagos).ToList();
                        var nmOrpas = datosPagos.Select(x => x.orpa).ToArray();

                        string qryEjecutado = "select sum(ap.valorneto) as ejecutado from investigacion_aplicarpago ap join investigacion_gasto ga on ap.id_investigaciongasto = ga.id_investigaciongasto join seguimiento_rubro rub on ga.id_rubro = rub.id_rubro join seguimiento_partida ru on ga.id_partida = ru.id_partida where ap.id_crearproyecto = @id_crearproyecto and ru.id_partida = 4 and rub.id_rubro = @id_rubro";
                        List<NpgsqlParameter> parameterListEjecutado = new List<NpgsqlParameter>();
                        parameterListEjecutado.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                        parameterListEjecutado.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                        NpgsqlParameter[] ParamEjecutado = parameterListEjecutado.ToArray();




                        var datosEjecutado = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryEjecutado, ParamEjecutado).ToList();


                        foreach (var registroE in datosEjecutado)
                        {
                            var cuatroxmil = (registroE.ejecutado * 4 / 1000) + registroE.ejecutado;
                            var disponibilidad = totalCuatroxMil - cuatroxmil;

                            if (cuatroxmil != null)
                                xlsdocument.SetCellValue("S" + (rowImp + 3), (int)cuatroxmil);
                            if (disponibilidad != null)
                                xlsdocument.SetCellValue("S" + (rowImp + 4), (int)disponibilidad);


                        }

                        auxSpendiente = 0;
                        foreach (var pagos in datosPagos)
                        {
                            if (auxOrpa2 == true)
                            {
                                auxrowOrpa = rowimpuestos;
                            }
                            auxOrpa2 = false;
                            if (pagos.valorneto != null)
                                cuatropormilPagos = ((int)pagos.valorneto * 4 / 1000) + (int)pagos.valorneto;

                            xlsdocument.SetCellValue("Q" + rowimpuestos, pagos.orpa);
                            xlsdocument.SetCellValue("R" + rowimpuestos, pagos.fechapago.ToString());
                            xlsdocument.SetCellValue("S" + rowimpuestos, pagos.cp_egr);
                            xlsdocument.SetCellValue("T" + rowimpuestos, pagos.nmsemestre);
                            if (pagos.valorneto != null)
                                xlsdocument.SetCellValue("U" + rowimpuestos, (int)pagos.valorneto);
                            xlsdocument.SetCellValue("V" + rowimpuestos, cuatropormilPagos);

                            auxSpendiente += cuatropormilPagos;

                            if (nmOrpas.Length == 1)
                            {
                                Spendiente = (int)(cuatroxMil - cuatropormilPagos);

                            }

                            rowimpuestos++;
                        }

                        if (nmOrpas.Length == 1)
                        {
                            xlsdocument.SetCellValue("W" + (rowimpuestos - 1), Spendiente);
                        }
                        if (nmOrpas.Length > 1)
                        {
                            Spendiente = (int)(cuatroxMil - auxSpendiente);
                            xlsdocument.SetCellValue("W" + auxrowOrpa, Spendiente);
                        }

                        if (nmOrpas.Length == 0)
                        {
                            Spendiente = cuatroxMil;
                            xlsdocument.SetCellValue("W" + rowimpuestos, Spendiente);
                            rowimpuestos++;
                            xlsdocument.MergeWorksheetCells("A" + auxrowOrpa, "A" + (rowimpuestos - 2));
                            xlsdocument.MergeWorksheetCells("B" + auxrowOrpa, "B" + (rowimpuestos - 2));
                            xlsdocument.MergeWorksheetCells("C" + auxrowOrpa, "C" + (rowimpuestos - 2));
                            xlsdocument.MergeWorksheetCells("D" + auxrowOrpa, "D" + (rowimpuestos - 2));
                            xlsdocument.MergeWorksheetCells("E" + auxrowOrpa, "E" + (rowimpuestos - 2));
                            xlsdocument.MergeWorksheetCells("F" + auxrowOrpa, "F" + (rowimpuestos - 2));
                            xlsdocument.MergeWorksheetCells("G" + auxrowOrpa, "G" + (rowimpuestos - 2));
                            xlsdocument.MergeWorksheetCells("H" + auxrowOrpa, "H" + (rowimpuestos - 2));
                            xlsdocument.MergeWorksheetCells("I" + auxrowOrpa, "I" + (rowimpuestos - 2));
                            xlsdocument.MergeWorksheetCells("J" + auxrowOrpa, "J" + (rowimpuestos - 2));
                            xlsdocument.MergeWorksheetCells("K" + auxrowOrpa, "K" + (rowimpuestos - 2));
                            xlsdocument.MergeWorksheetCells("L" + auxrowOrpa, "L" + (rowimpuestos - 2));
                            xlsdocument.MergeWorksheetCells("M" + auxrowOrpa, "M" + (rowimpuestos - 2));
                            xlsdocument.MergeWorksheetCells("N" + auxrowOrpa, "N" + (rowimpuestos - 2));
                            xlsdocument.MergeWorksheetCells("O" + auxrowOrpa, "O" + (rowimpuestos - 2));
                            xlsdocument.MergeWorksheetCells("P" + auxrowOrpa, "P" + (rowimpuestos - 2));
                            xlsdocument.MergeWorksheetCells("W" + auxrowOrpa, "W" + (rowimpuestos - 2));
                            xlsdocument.MergeWorksheetCells("X" + auxrowOrpa, "X" + (rowimpuestos - 2));
                        }
                        else
                        {
                            rowimpuestos++;
                            xlsdocument.HideRow(rowimpuestos - 1);
                            xlsdocument.MergeWorksheetCells("A" + auxrowOrpa, "A" + (rowimpuestos - 1));
                            xlsdocument.MergeWorksheetCells("B" + auxrowOrpa, "B" + (rowimpuestos - 1));
                            xlsdocument.MergeWorksheetCells("C" + auxrowOrpa, "C" + (rowimpuestos - 1));
                            xlsdocument.MergeWorksheetCells("D" + auxrowOrpa, "D" + (rowimpuestos - 1));
                            xlsdocument.MergeWorksheetCells("E" + auxrowOrpa, "E" + (rowimpuestos - 1));
                            xlsdocument.MergeWorksheetCells("F" + auxrowOrpa, "F" + (rowimpuestos - 1));
                            xlsdocument.MergeWorksheetCells("G" + auxrowOrpa, "G" + (rowimpuestos - 1));
                            xlsdocument.MergeWorksheetCells("H" + auxrowOrpa, "H" + (rowimpuestos - 1));
                            xlsdocument.MergeWorksheetCells("I" + auxrowOrpa, "I" + (rowimpuestos - 1));
                            xlsdocument.MergeWorksheetCells("J" + auxrowOrpa, "J" + (rowimpuestos - 1));
                            xlsdocument.MergeWorksheetCells("K" + auxrowOrpa, "K" + (rowimpuestos - 1));
                            xlsdocument.MergeWorksheetCells("L" + auxrowOrpa, "L" + (rowimpuestos - 1));
                            xlsdocument.MergeWorksheetCells("M" + auxrowOrpa, "M" + (rowimpuestos - 1));
                            xlsdocument.MergeWorksheetCells("N" + auxrowOrpa, "N" + (rowimpuestos - 1));
                            xlsdocument.MergeWorksheetCells("O" + auxrowOrpa, "O" + (rowimpuestos - 1));
                            xlsdocument.MergeWorksheetCells("P" + auxrowOrpa, "P" + (rowimpuestos - 1));
                            xlsdocument.MergeWorksheetCells("W" + auxrowOrpa, "W" + (rowimpuestos - 1));
                            xlsdocument.MergeWorksheetCells("X" + auxrowOrpa, "X" + (rowimpuestos - 1));
                        }

                    }
                    xlsdocument.SetCellStyle("A" + rowimpuestos, "X" + rowimpuestos, rowBorder);
                    //rowRubNew = rowTot + 1;
                    rowOpImpuestos = rowimpuestos + 1;

                }

                rub4 = false;

                if (nmsImpuestos.Length > 1)
                {

                    if (deleteImpuestos == true)
                    {

                        xlsdocument.DeleteRow(rowImp + 2, rowOpImpuestos - (rowImp + 2));
                        //                           rowRubNew = rowRubNew - 21;
                        xlsdocument.HideRow(rowImp + 2, rowOpImpuestos - 1);
                    }
                    deleteImpuestos = false;

                    xlsdocument.SetCellValue(rowOpImpuestos, 1, "RUBRO");
                    xlsdocument.SetCellStyle(rowOpImpuestos, 1, adquisicionServicios);
                    xlsdocument.SetCellValue(rowOpImpuestos, 2, registro.nombrerubro);
                    xlsdocument.MergeWorksheetCells("A" + rowOpImpuestos, "A" + (rowOpImpuestos + 2));
                    xlsdocument.MergeWorksheetCells("B" + rowOpImpuestos, "N" + (rowOpImpuestos + 2));
                    xlsdocument.MergeWorksheetCells("O" + rowOpImpuestos, "R" + rowOpImpuestos);
                    xlsdocument.SetCellValue(rowOpImpuestos, 15, "VALOR");
                    xlsdocument.SetCellStyle(rowOpImpuestos, 15, adquisicionServicios);
                    xlsdocument.MergeWorksheetCells("O" + (rowOpImpuestos + 1), "R" + (rowOpImpuestos + 1));
                    xlsdocument.SetCellValue(rowOpImpuestos + 1, 15, "EJECUTADO");
                    xlsdocument.SetCellStyle(rowOpImpuestos + 1, 15, adquisicionServicios);
                    xlsdocument.MergeWorksheetCells("O" + (rowOpImpuestos + 2), "R" + (rowOpImpuestos + 2));
                    xlsdocument.SetCellValue(rowOpImpuestos + 2, 15, "DISPONIBILIDAD DEL RUBRO");
                    xlsdocument.SetCellStyle(rowOpImpuestos + 2, 15, adquisicionServicios);
                    xlsdocument.MergeWorksheetCells("S" + rowOpImpuestos, "X" + rowOpImpuestos);
                    xlsdocument.MergeWorksheetCells("S" + (rowOpImpuestos + 1), "X" + (rowOpImpuestos + 1));
                    xlsdocument.MergeWorksheetCells("S" + (rowOpImpuestos + 2), "X" + (rowOpImpuestos + 2));
                    xlsdocument.MergeWorksheetCells("A" + (rowOpImpuestos + 3), "A" + (rowOpImpuestos + 4));
                    xlsdocument.SetCellValue(rowOpImpuestos + 3, 1, "CONCEPTO");
                    xlsdocument.SetColumnWidth("A" + (rowOpImpuestos + 3), 15.0);
                    xlsdocument.SetCellStyle(rowOpImpuestos + 3, 1, adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("B" + (rowOpImpuestos + 3), "B" + (rowOpImpuestos + 4));
                    xlsdocument.SetCellValue(rowOpImpuestos + 3, 2, "NOMBRE");
                    xlsdocument.SetCellStyle(rowOpImpuestos + 3, 2, adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("C" + (rowOpImpuestos + 3), "C" + (rowOpImpuestos + 4));
                    xlsdocument.SetCellValue(rowOpImpuestos + 3, 3, "IDENTIFICACION");
                    xlsdocument.SetColumnWidth("C" + (rowOpImpuestos + 3), 25.0);
                    xlsdocument.SetCellStyle(rowOpImpuestos + 3, 3, adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("D" + (rowOpImpuestos + 3), "D" + (rowOpImpuestos + 4));
                    xlsdocument.SetCellValue(rowOpImpuestos + 3, 4, "AREA");
                    xlsdocument.SetCellStyle(rowOpImpuestos + 3, 4, adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("E" + (rowOpImpuestos + 3), "H" + (rowOpImpuestos + 3));
                    xlsdocument.SetCellValue("E" + (rowOpImpuestos + 3), "RELACION DEL VINCULO");
                    xlsdocument.SetCellStyle("E" + (rowOpImpuestos + 3), adquisicionServiciosCentred);
                    xlsdocument.SetCellValue("E" + (rowOpImpuestos + 4), "PREGRADO");
                    xlsdocument.SetCellStyle("E" + (rowOpImpuestos + 4), adquisicionServiciosCentred);
                    xlsdocument.SetColumnWidth("E" + (rowOpImpuestos + 4), 20.0);
                    xlsdocument.SetCellValue("F" + (rowOpImpuestos + 4), "POSGRADO");
                    xlsdocument.SetCellStyle("F" + (rowOpImpuestos + 4), adquisicionServiciosCentred);
                    xlsdocument.SetColumnWidth("F" + (rowOpImpuestos + 4), 20.0);
                    xlsdocument.SetCellValue("G" + (rowOpImpuestos + 4), "EGRESADO");
                    xlsdocument.SetCellStyle("G" + (rowOpImpuestos + 4), adquisicionServiciosCentred);
                    xlsdocument.SetColumnWidth("G" + (rowOpImpuestos + 4), 20.0);
                    xlsdocument.SetCellValue("H" + (rowOpImpuestos + 4), "OTRO");
                    xlsdocument.SetCellStyle("H" + (rowOpImpuestos + 4), adquisicionServiciosCentred);
                    xlsdocument.SetColumnWidth("H" + (rowOpImpuestos + 4), 20.0);
                    xlsdocument.MergeWorksheetCells("I" + (rowOpImpuestos + 3), "I" + (rowOpImpuestos + 4));
                    xlsdocument.SetCellValue("I" + (rowOpImpuestos + 3), "FECHA");
                    xlsdocument.SetCellStyle("I" + (rowOpImpuestos + 3), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("J" + (rowOpImpuestos + 3), "J" + (rowOpImpuestos + 4));
                    xlsdocument.SetCellValue("J" + (rowOpImpuestos + 3), "TIPO");
                    xlsdocument.SetCellStyle("J" + (rowOpImpuestos + 3), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("K" + (rowOpImpuestos + 3), "K" + (rowOpImpuestos + 4));
                    xlsdocument.SetCellValue("K" + (rowOpImpuestos + 3), "No.");
                    xlsdocument.SetCellStyle("K" + (rowOpImpuestos + 3), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("L" + (rowOpImpuestos + 3), "L" + (rowOpImpuestos + 4));
                    xlsdocument.SetCellValue("L" + (rowOpImpuestos + 3), "FECHA INICIO");
                    xlsdocument.SetCellStyle("L" + (rowOpImpuestos + 3), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("M" + (rowOpImpuestos + 3), "M" + (rowOpImpuestos + 4));
                    xlsdocument.SetCellValue("M" + (rowOpImpuestos + 3), "FECHA FINAL");
                    xlsdocument.SetCellStyle("M" + (rowOpImpuestos + 3), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("N" + (rowOpImpuestos + 3), "N" + (rowOpImpuestos + 4));
                    xlsdocument.SetCellValue("N" + (rowOpImpuestos + 3), "ESTADO");
                    xlsdocument.SetCellStyle("N" + (rowOpImpuestos + 3), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("O" + (rowOpImpuestos + 3), "O" + (rowOpImpuestos + 4));
                    xlsdocument.SetCellValue("O" + (rowOpImpuestos + 3), "Valor Total");
                    xlsdocument.SetCellStyle("O" + (rowOpImpuestos + 3), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("P" + (rowOpImpuestos + 3), "P" + (rowOpImpuestos + 4));
                    xlsdocument.SetCellValue("P" + (rowOpImpuestos + 3), "Valor con 4 xmil");
                    xlsdocument.SetCellStyle("P" + (rowOpImpuestos + 3), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("Q" + (rowOpImpuestos + 3), "V" + (rowOpImpuestos + 3));
                    xlsdocument.SetCellValue("Q" + (rowOpImpuestos + 3), "PAGOS");
                    xlsdocument.SetCellStyle("Q" + (rowOpImpuestos + 3), adquisicionServiciosCentred);
                    xlsdocument.SetCellValue("Q" + (rowOpImpuestos + 4), "ORPA");
                    xlsdocument.SetCellStyle("Q" + (rowOpImpuestos + 4), adquisicionServiciosCentred);
                    xlsdocument.SetCellValue("R" + (rowOpImpuestos + 4), "FECHA");
                    xlsdocument.SetCellStyle("R" + (rowOpImpuestos + 4), adquisicionServiciosCentred);
                    xlsdocument.SetCellValue("S" + (rowOpImpuestos + 4), "CP.EGR");
                    xlsdocument.SetCellStyle("S" + (rowOpImpuestos + 4), adquisicionServiciosCentred);
                    xlsdocument.SetCellValue("T" + (rowOpImpuestos + 4), "PERIODO");
                    xlsdocument.SetCellStyle("T" + (rowOpImpuestos + 4), adquisicionServiciosCentred);
                    xlsdocument.SetCellValue("U" + (rowOpImpuestos + 4), "VALOR NETO");
                    xlsdocument.SetCellStyle("U" + (rowOpImpuestos + 4), adquisicionServiciosCentred);
                    xlsdocument.SetCellValue("V" + (rowOpImpuestos + 4), "VALOR 4*1000");
                    xlsdocument.SetCellStyle("V" + (rowOpImpuestos + 4), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("W" + (rowOpImpuestos + 3), "W" + (rowOpImpuestos + 4));
                    xlsdocument.SetCellValue("W" + (rowOpImpuestos + 3), "SALDO PENDIENTE");
                    xlsdocument.SetCellStyle("W" + (rowOpImpuestos + 3), adquisicionServiciosCentred);
                    xlsdocument.MergeWorksheetCells("X" + (rowOpImpuestos + 3), "X" + (rowOpImpuestos + 4));
                    xlsdocument.SetCellValue("X" + (rowOpImpuestos + 3), "OBSERVACION");
                    xlsdocument.SetCellStyle("X" + (rowOpImpuestos + 3), adquisicionServiciosCentred);
                    xlsdocument.SetColumnWidth("L" + (rowOpImpuestos + 3), 25.0);
                    xlsdocument.SetColumnWidth("M" + (rowOpImpuestos + 3), 25.0);
                    xlsdocument.SetColumnWidth("N" + (rowOpImpuestos + 3), 25.0);
                    xlsdocument.SetColumnWidth("O" + (rowOpImpuestos + 3), 25.0);
                    xlsdocument.SetColumnWidth("P" + (rowOpImpuestos + 3), 25.0);
                    xlsdocument.SetColumnWidth("Q" + (rowOpImpuestos + 3), 25.0);
                    xlsdocument.SetColumnWidth("R" + (rowOpImpuestos + 3), 25.0);
                    xlsdocument.SetColumnWidth("S" + (rowOpImpuestos + 3), 25.0);
                    xlsdocument.SetColumnWidth("T" + (rowOpImpuestos + 3), 25.0);
                    xlsdocument.SetColumnWidth("U" + (rowOpImpuestos + 3), 25.0);
                    xlsdocument.SetColumnWidth("V" + (rowOpImpuestos + 3), 25.0);
                    xlsdocument.SetColumnWidth("W" + (rowOpImpuestos + 3), 25.0);
                    xlsdocument.SetColumnWidth("X" + (rowOpImpuestos + 3), 25.0);

                    id_rubro = registro.id_rubro;


                    //Incluimos el valor total por concepto 
                    string qryValorTotal = "select sum (valortotal) from investigacion_gasto where id_crearproyecto = @id_crearproyecto and id_partida = 4 and id_rubro = @id_rubro";
                    List<NpgsqlParameter> parameterListTotal = new List<NpgsqlParameter>();
                    parameterListTotal.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                    parameterListTotal.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                    NpgsqlParameter[] ParamTotal = parameterListTotal.ToArray();



                    var datosTotal = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryValorTotal, ParamTotal).ToList();



                    foreach (var registroN in datosTotal)
                    {
                        var cuatroxmil = (registroN.sum * 4 / 1000) + registroN.sum;
                        if (cuatroxmil != null)
                            xlsdocument.SetCellValue("S" + (rowOpImpuestos), (int)cuatroxmil);

                    }

                    string qryorpa = "select co.nombreconcepto, pe.nombrecompleto , pe.numidentificacion, rv.id_relacionvinculo, ga.fechainicio, ga.fechafinal, ga.numorden, ga.fechalegalizacionorden, ga.tipo, ga.valortotal, ga.estado, ga.id_investigaciongasto from investigacion_gasto ga join seguimiento_concepto co on ga.id_segconcepto = co.id_segconcepto join persona pe on ga.id_persona = pe.id_persona join seguimiento_relacionvinculo rv on ga.id_relacionvinculo = rv.id_relacionvinculo where ga.id_crearproyecto = @id_crearproyecto and ga.id_partida = 4 and ga.id_rubro = @id_rubro";
                    List<NpgsqlParameter> parameterListOrpa = new List<NpgsqlParameter>();
                    parameterListOrpa.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                    parameterListOrpa.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                    NpgsqlParameter[] ParamOrpa = parameterListOrpa.ToArray();

                    var datosOrpa = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryorpa, ParamOrpa).ToList();




                    var auxrowOrpa = 0;
                    var auxOrpa2 = true;
                    var optSec = true;
                    //27 tot
                    var cuatroxMil = 0;
                    var totalCuatroxMil = 0;

                    var auxSer = rowOpImpuestos + 5;

                    var rowOrpa = auxSer;

                    var Spendiente = 0;
                    var auxSpendiente = 0;

                    optOrpa = false;
                    foreach (var dataorpa in datosOrpa)
                    {

                        auxOrpa2 = true;
                        if (cuatroxMil != null)
                            cuatroxMil = ((int)dataorpa.valortotal * 4 / 1000) + (int)dataorpa.valortotal;
                        totalCuatroxMil += cuatroxMil;

                        id_investigaciongasto = dataorpa.id_investigaciongasto;
                        xlsdocument.SetCellValue(rowOrpa, 1, dataorpa.nombreconcepto);
                        xlsdocument.SetCellValue("B" + rowOrpa, dataorpa.nombrecompleto);
                        xlsdocument.SetCellValue("C" + rowOrpa, dataorpa.numidentificacion);
                        xlsdocument.SetCellValue("I" + rowOrpa, dataorpa.fechalegalizacionorden.ToString());
                        xlsdocument.SetCellValue("J" + rowOrpa, dataorpa.tipo);
                        xlsdocument.SetCellValue("K" + rowOrpa, dataorpa.numorden);
                        xlsdocument.SetCellValue("L" + rowOrpa, dataorpa.fechainicio.ToString());
                        xlsdocument.SetCellValue("M" + rowOrpa, dataorpa.fechafinal.ToString());
                        xlsdocument.SetCellValue("N" + rowOrpa, dataorpa.estado);
                        xlsdocument.SetCellValue("X" + rowOrpa, dataorpa.observaciones);
                        if (dataorpa.valortotal != null)
                            xlsdocument.SetCellValue("O" + rowOrpa, (int)dataorpa.valortotal);
                        xlsdocument.SetCellValue("P" + rowOrpa, cuatroxMil);




                        if (dataorpa.id_relacionvinculo == 1 || dataorpa.id_relacionvinculo == 2)
                        {
                            xlsdocument.SetCellValue("H" + rowOrpa, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 3)
                        {
                            xlsdocument.SetCellValue("E" + rowOrpa, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 4)
                        {
                            xlsdocument.SetCellValue("F" + rowOrpa, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 5)
                        {
                            xlsdocument.SetCellValue("G" + rowOrpa, "X");

                        }

                        string qryPagos = "select ap.orpa, ap.fechapago, ap.cp_egr, sm.nmsemestre, ap.valorneto from investigacion_aplicarpago ap join investigacion_gasto ga on ap.id_investigaciongasto = ga.id_investigaciongasto join seguimiento_rubro rub on ga.id_rubro = rub.id_rubro join seguimiento_partida ru on ga.id_partida = ru.id_partida join seguimiento_concepto co on ga.id_segconcepto = co.id_segconcepto join semestre sm on ap.id_semestre = sm.id_semestre join seguimiento_relacionvinculo rv on ga.id_relacionvinculo = rv.id_relacionvinculo join persona pe on ga.id_persona = pe.id_persona where ap.id_crearproyecto = @id_crearproyecto and ru.id_partida = 4 and rub.id_rubro = @id_rubro and ga.id_investigaciongasto = @id_investigaciongasto group by  ap.orpa, ap.fechapago, ap.cp_egr, sm.nmsemestre, ap.valorneto";
                        List<NpgsqlParameter> parameterListPagos = new List<NpgsqlParameter>();
                        parameterListPagos.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                        parameterListPagos.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                        parameterListPagos.Add(new NpgsqlParameter("@id_investigaciongasto", id_investigaciongasto));
                        NpgsqlParameter[] ParamPagos = parameterListPagos.ToArray();

                        var datosPagos = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryPagos, ParamPagos).ToList();

                        var nmOrpas = datosPagos.Select(x => x.orpa).ToArray();


                        string qryEjecutado = "select sum(ap.valorneto) as ejecutado from investigacion_aplicarpago ap join investigacion_gasto ga on ap.id_investigaciongasto = ga.id_investigaciongasto join seguimiento_rubro rub on ga.id_rubro = rub.id_rubro join seguimiento_partida ru on ga.id_partida = ru.id_partida where ap.id_crearproyecto = @id_crearproyecto and ru.id_partida = 4 and rub.id_rubro = @id_rubro";
                        List<NpgsqlParameter> parameterListEjecutado = new List<NpgsqlParameter>();
                        parameterListEjecutado.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                        parameterListEjecutado.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                        NpgsqlParameter[] ParamEjecutado = parameterListEjecutado.ToArray();




                        var datosEjecutado = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryEjecutado, ParamEjecutado).ToList();


                        foreach (var registroE in datosEjecutado)
                        {
                            var cuatroxmil = (registroE.ejecutado * 4 / 1000) + registroE.ejecutado;
                            var disponibilidad = totalCuatroxMil - cuatroxmil;

                            if (cuatroxmil != null)
                                xlsdocument.SetCellValue("S" + (rowOpImpuestos + 1), (int)cuatroxmil);
                            if (disponibilidad != null)

                                xlsdocument.SetCellValue("S" + (rowOpImpuestos + 2), (int)disponibilidad);


                        }


                        auxSpendiente = 0;
                        foreach (var pagos in datosPagos)
                        {
                            if (auxOrpa2 == true)
                            {
                                auxrowOrpa = rowOrpa;
                            }
                            auxOrpa2 = false;
                            if (pagos.valorneto != null)
                                cuatropormilPagos = ((int)pagos.valorneto * 4 / 1000) + (int)pagos.valorneto;

                            xlsdocument.SetCellValue("Q" + rowOrpa, pagos.orpa);
                            xlsdocument.SetCellValue("R" + rowOrpa, pagos.fechapago.ToString());
                            xlsdocument.SetCellValue("S" + rowOrpa, pagos.cp_egr);
                            xlsdocument.SetCellValue("T" + rowOrpa, pagos.nmsemestre);
                            if (pagos.valorneto != null)
                                xlsdocument.SetCellValue("U" + rowOrpa, (int)pagos.valorneto);
                            xlsdocument.SetCellValue("V" + rowOrpa, cuatropormilPagos);

                            auxSpendiente += cuatropormilPagos;

                            if (nmOrpas.Length == 1)
                            {
                                Spendiente = (int)(cuatroxMil - cuatropormilPagos);

                            }

                            rowOrpa++;
                        }

                        if (nmOrpas.Length == 1)
                        {
                            xlsdocument.SetCellValue("W" + (rowOrpa - 1), Spendiente);
                        }
                        if (nmOrpas.Length > 1)
                        {
                            Spendiente = (int)(cuatroxMil - auxSpendiente);
                            xlsdocument.SetCellValue("W" + auxrowOrpa, Spendiente);
                        }

                        if (nmOrpas.Length == 0)
                        {
                            Spendiente = cuatroxMil;
                            xlsdocument.SetCellValue("W" + rowOrpa, Spendiente);
                            rowOrpa++;
                            xlsdocument.MergeWorksheetCells("A" + auxrowOrpa, "A" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("B" + auxrowOrpa, "B" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("C" + auxrowOrpa, "C" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("D" + auxrowOrpa, "D" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("E" + auxrowOrpa, "E" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("F" + auxrowOrpa, "F" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("G" + auxrowOrpa, "G" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("H" + auxrowOrpa, "H" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("I" + auxrowOrpa, "I" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("J" + auxrowOrpa, "J" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("K" + auxrowOrpa, "K" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("L" + auxrowOrpa, "L" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("M" + auxrowOrpa, "M" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("N" + auxrowOrpa, "N" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("O" + auxrowOrpa, "O" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("P" + auxrowOrpa, "P" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("W" + auxrowOrpa, "W" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("X" + auxrowOrpa, "X" + (rowOrpa - 2));
                        }
                        else
                        {

                            xlsdocument.MergeWorksheetCells("A" + auxrowOrpa, "A" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("B" + auxrowOrpa, "B" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("C" + auxrowOrpa, "C" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("D" + auxrowOrpa, "D" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("E" + auxrowOrpa, "E" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("F" + auxrowOrpa, "F" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("G" + auxrowOrpa, "G" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("H" + auxrowOrpa, "H" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("I" + auxrowOrpa, "I" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("J" + auxrowOrpa, "J" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("K" + auxrowOrpa, "K" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("L" + auxrowOrpa, "L" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("M" + auxrowOrpa, "M" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("N" + auxrowOrpa, "N" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("O" + auxrowOrpa, "O" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("P" + auxrowOrpa, "P" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("W" + auxrowOrpa, "W" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("X" + auxrowOrpa, "X" + (rowOrpa - 1));
                        }

                    }

                    auxOrpa = rowOrpa;
                    xlsdocument.SetCellStyle("A" + rowOrpa, "X" + rowOrpa, rowBorder);
                    rowOpImpuestos = rowOpImpuestos + (auxOrpa - rowOpImpuestos) + 1;
                    rowTras = rowOpImpuestos;
                }

            }

            if (nmsImpuestos.Length == 1)
            {
                rowTras = rowOpImpuestos;

            }
            else if (nmsImpuestos.Length == 0)
            {
                rowTras = rowImp + 2;
            }


            SLStyle transferencias = xlsdocument.CreateStyle();
            SLStyle transferenciasCentred = xlsdocument.CreateStyle();

            transferencias.Font.FontName = "Times New Roman";
            transferencias.Font.FontSize = 14.0;
            transferencias.Font.Bold = true;
            transferencias.Alignment.Horizontal = HorizontalAlignmentValues.Left;
            transferencias.Alignment.Vertical = VerticalAlignmentValues.Center;
            transferencias.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.FromArgb(192, 192, 192), System.Drawing.Color.Blue);

            transferenciasCentred.Font.FontName = "Times New Roman";
            transferenciasCentred.Font.FontSize = 14.0;
            transferenciasCentred.Font.Bold = true;
            transferenciasCentred.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            transferenciasCentred.Alignment.Vertical = VerticalAlignmentValues.Center;
            transferenciasCentred.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.FromArgb(192, 192, 192), System.Drawing.Color.Blue);


            xlsdocument.MergeWorksheetCells(rowTras, 1, rowTras, 24);
            xlsdocument.SetCellValue(rowTras, 1, "5. TRANSFERENCIAS ENTRE FONDOS SIN CONTRAPRESTACION");
            xlsdocument.SetCellStyle(rowTras, 1, transferencias);
            xlsdocument.SetCellStyle("A" + (rowTras + 1), "X" + (rowTras + 1), rowBorder);
            xlsdocument.SetRowHeight(rowTras + 1, 11.0);


            string qryTransferencias = "select DISTINCT ru.nombrerubro, ru.id_rubro from investigacion_gasto ga join seguimiento_rubro ru on ga.id_rubro = ru.id_rubro where ga.id_crearproyecto=@id_crearproyecto and ga.id_partida = 5";

            List<NpgsqlParameter> parameterListTransferencias = new List<NpgsqlParameter>();
            parameterListTransferencias.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));

            NpgsqlParameter[] Paramtransferencias = parameterListTransferencias.ToArray();

            var datostransferencias = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryTransferencias, Paramtransferencias).ToList();

            var nmstransferencias = datostransferencias.Select(x => x.nombreconcepto).ToArray();

            var rub5 = true;
            var borders = true;

            foreach (var registro in datostransferencias)
            {

                if (rub5 == true)
                {

                    xlsdocument.SetCellValue(rowTras + 2, 1, "RUBRO");
                    xlsdocument.SetCellStyle(rowTras + 2, 1, transferencias);
                    xlsdocument.SetCellValue(rowTras + 2, 2, registro.nombrerubro);
                    xlsdocument.MergeWorksheetCells("A" + (rowTras + 2), "A" + (rowTras + 4));
                    xlsdocument.MergeWorksheetCells("B" + (rowTras + 2), "N" + (rowTras + 4));
                    xlsdocument.MergeWorksheetCells("O" + (rowTras + 2), "R" + (rowTras + 2));
                    xlsdocument.SetCellValue(rowTras + 2, 15, "VALOR");
                    xlsdocument.SetCellStyle(rowTras + 2, 15, transferencias);
                    xlsdocument.MergeWorksheetCells("O" + (rowTras + 4), "R" + (rowTras + 4));
                    xlsdocument.SetCellValue(rowImp + 3, 15, "EJECUTADO");


                    xlsdocument.SetCellStyle(rowTras + 3, 15, transferencias);
                    xlsdocument.MergeWorksheetCells("O" + (rowTras + 3), "R" + (rowTras + 3));
                    xlsdocument.SetCellValue(rowTras + 4, 15, "DISPONIBILIDAD DEL RUBRO");
                    xlsdocument.SetCellStyle(rowTras + 4, 15, transferencias);
                    xlsdocument.MergeWorksheetCells("S" + (rowTras + 2), "X" + (rowTras + 2));
                    xlsdocument.MergeWorksheetCells("S" + (rowTras + 3), "X" + (rowTras + 3));
                    xlsdocument.MergeWorksheetCells("S" + (rowTras + 4), "X" + (rowTras + 4));


                    xlsdocument.MergeWorksheetCells("A" + (rowTras + 5), "A" + (rowTras + 6));
                    xlsdocument.SetCellValue(rowTras + 5, 1, "CONCEPTO");
                    xlsdocument.SetColumnWidth("A" + (rowTras + 5), 15.0);
                    xlsdocument.SetCellStyle(rowTras + 5, 1, transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("B" + (rowTras + 5), "B" + (rowTras + 6));
                    xlsdocument.SetCellValue(rowTras + 5, 2, "NOMBRE");
                    xlsdocument.SetCellStyle(rowTras + 5, 2, transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("C" + (rowTras + 5), "C" + (rowTras + 6));
                    xlsdocument.SetCellValue(rowTras + 5, 3, "IDENTIFICACION");
                    //xlsdocument.AutoFitColumn("C"+(row+12));
                    xlsdocument.SetColumnWidth("C" + (rowTras + 5), 25.0);
                    xlsdocument.SetCellStyle(rowTras + 5, 3, transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("D" + (rowTras + 5), "D" + (rowTras + 6));
                    xlsdocument.SetCellValue(rowTras + 5, 4, "AREA");
                    xlsdocument.SetCellStyle(rowTras + 5, 4, transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("E" + (rowTras + 5), "H" + (rowTras + 5));
                    xlsdocument.SetCellValue("E" + (rowTras + 5), "RELACION DEL VINCULO");
                    xlsdocument.SetCellStyle("E" + (rowTras + 5), transferenciasCentred);
                    xlsdocument.SetCellValue("E" + (rowTras + 6), "PREGRADO");
                    xlsdocument.SetCellStyle("E" + (rowTras + 6), transferenciasCentred);
                    xlsdocument.SetColumnWidth("E" + (rowTras + 6), 20.0);
                    xlsdocument.SetCellValue("F" + (rowTras + 6), "POSGRADO");
                    xlsdocument.SetCellStyle("F" + (rowTras + 6), transferenciasCentred);
                    xlsdocument.SetColumnWidth("F" + (rowTras + 6), 20.0);
                    xlsdocument.SetCellValue("G" + (rowTras + 6), "EGRESADO");
                    xlsdocument.SetCellStyle("G" + (rowTras + 6), transferenciasCentred);
                    xlsdocument.SetColumnWidth("G" + (rowTras + 6), 20.0);
                    xlsdocument.SetCellValue("H" + (rowTras + 6), "OTRO");
                    xlsdocument.SetCellStyle("H" + (rowTras + 6), transferenciasCentred);
                    xlsdocument.SetColumnWidth("H" + (rowTras + 6), 20.0);
                    xlsdocument.MergeWorksheetCells("I" + (rowTras + 5), "I" + (rowTras + 6));
                    xlsdocument.SetCellValue("I" + (rowTras + 5), "FECHA");
                    xlsdocument.SetCellStyle("I" + (rowTras + 5), transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("J" + (rowTras + 5), "J" + (rowTras + 6));
                    xlsdocument.SetCellValue("J" + (rowTras + 5), "TIPO");
                    xlsdocument.SetCellStyle("J" + (rowTras + 5), transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("K" + (rowTras + 5), "K" + (rowTras + 6));
                    xlsdocument.SetCellValue("K" + (rowTras + 5), "No.");
                    xlsdocument.SetCellStyle("K" + (rowTras + 5), transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("L" + (rowTras + 5), "L" + (rowTras + 6));
                    xlsdocument.SetCellValue("L" + (rowTras + 5), "FECHA INICIO");
                    xlsdocument.SetCellStyle("L" + (rowTras + 5), transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("M" + (rowTras + 5), "M" + (rowTras + 6));
                    xlsdocument.SetCellValue("M" + (rowTras + 5), "FECHA FINAL");
                    xlsdocument.SetCellStyle("M" + (rowTras + 5), transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("N" + (rowTras + 5), "N" + (rowTras + 6));
                    xlsdocument.SetCellValue("N" + (rowTras + 5), "ESTADO");
                    xlsdocument.SetCellStyle("N" + (rowTras + 5), transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("O" + (rowTras + 5), "O" + (rowTras + 6));
                    xlsdocument.SetCellValue("O" + (rowTras + 5), "Valor Total");
                    xlsdocument.SetCellStyle("O" + (rowTras + 5), transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("P" + (rowTras + 5), "P" + (rowTras + 6));
                    xlsdocument.SetCellValue("P" + (rowTras + 5), "Valor con 4 xmil");
                    xlsdocument.SetCellStyle("P" + (rowTras + 5), transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("Q" + (rowTras + 5), "V" + (rowTras + 5));
                    xlsdocument.SetCellValue("Q" + (rowTras + 5), "PAGOS");
                    xlsdocument.SetCellStyle("Q" + (rowTras + 5), transferenciasCentred);
                    xlsdocument.SetCellValue("Q" + (rowTras + 6), "ORPA");
                    xlsdocument.SetCellStyle("Q" + (rowTras + 6), transferenciasCentred);
                    xlsdocument.SetCellValue("R" + (rowTras + 6), "FECHA");
                    xlsdocument.SetCellStyle("R" + (rowTras + 6), transferenciasCentred);
                    xlsdocument.SetCellValue("S" + (rowTras + 6), "CP.EGR");
                    xlsdocument.SetCellStyle("S" + (rowTras + 6), transferenciasCentred);
                    xlsdocument.SetCellValue("T" + (rowTras + 6), "PERIODO");
                    xlsdocument.SetCellStyle("T" + (rowTras + 6), transferenciasCentred);
                    xlsdocument.SetCellValue("U" + (rowTras + 6), "VALOR NETO");
                    xlsdocument.SetCellStyle("U" + (rowTras + 6), transferenciasCentred);
                    xlsdocument.SetCellValue("V" + (rowTras + 6), "VALOR 4*1000");
                    xlsdocument.SetCellStyle("V" + (rowTras + 6), transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("W" + (rowTras + 5), "W" + (rowTras + 6));
                    xlsdocument.SetCellValue("W" + (rowTras + 5), "SALDO PENDIENTE");
                    xlsdocument.SetCellStyle("W" + (rowTras + 5), transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("X" + (rowTras + 5), "X" + (rowTras + 6));
                    xlsdocument.SetCellValue("X" + (rowTras + 5), "OBSERVACION");
                    xlsdocument.SetCellStyle("X" + (rowTras + 5), transferenciasCentred);
                    xlsdocument.SetColumnWidth("L" + (rowTras + 5), 25.0);
                    xlsdocument.SetColumnWidth("M" + (rowTras + 5), 25.0);
                    xlsdocument.SetColumnWidth("N" + (rowTras + 5), 25.0);
                    xlsdocument.SetColumnWidth("O" + (rowTras + 5), 25.0);
                    xlsdocument.SetColumnWidth("P" + (rowTras + 5), 25.0);
                    xlsdocument.SetColumnWidth("Q" + (rowTras + 5), 25.0);
                    xlsdocument.SetColumnWidth("R" + (rowTras + 5), 25.0);
                    xlsdocument.SetColumnWidth("S" + (rowTras + 5), 25.0);
                    xlsdocument.SetColumnWidth("T" + (rowTras + 5), 25.0);
                    xlsdocument.SetColumnWidth("U" + (rowTras + 5), 25.0);
                    xlsdocument.SetColumnWidth("V" + (rowTras + 5), 25.0);
                    xlsdocument.SetColumnWidth("W" + (rowTras + 5), 25.0);
                    xlsdocument.SetColumnWidth("X" + (rowTras + 5), 25.0);


                    id_rubro = registro.id_rubro;



                    //Incluimos el valor total por concepto 
                    string qryValorTotal = "select sum (valortotal) from investigacion_gasto where id_crearproyecto = @id_crearproyecto and id_partida = 5 and id_rubro = @id_rubro";
                    List<NpgsqlParameter> parameterListTotal = new List<NpgsqlParameter>();
                    parameterListTotal.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                    parameterListTotal.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                    NpgsqlParameter[] ParamTotal = parameterListTotal.ToArray();




                    var datosTotal = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryValorTotal, ParamTotal).ToList();



                    foreach (var registroN in datosTotal)
                    {
                        var cuatroxmil = (registroN.sum * 4 / 1000) + registroN.sum;
                        if (cuatroxmil != null)
                            xlsdocument.SetCellValue("S" + (rowTras + 2), (int)cuatroxmil);

                    }






                    string qryorpa = "select co.nombreconcepto, pe.nombrecompleto , pe.numidentificacion, rv.id_relacionvinculo, ga.fechainicio, ga.fechafinal, ga.numorden, ga.fechalegalizacionorden, ga.tipo, ga.valortotal, ga.estado, ga.id_investigaciongasto from investigacion_gasto ga join seguimiento_concepto co on ga.id_segconcepto = co.id_segconcepto join persona pe on ga.id_persona = pe.id_persona join seguimiento_relacionvinculo rv on ga.id_relacionvinculo = rv.id_relacionvinculo where ga.id_crearproyecto = @id_crearproyecto and ga.id_partida = 5 and ga.id_rubro = @id_rubro";
                    List<NpgsqlParameter> parameterListOrpa = new List<NpgsqlParameter>();
                    parameterListOrpa.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                    parameterListOrpa.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                    NpgsqlParameter[] ParamOrpa = parameterListOrpa.ToArray();

                    var datosOrpa = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryorpa, ParamOrpa).ToList();




                    var auxrowOrpa = 0;
                    var auxOrpa2 = true;



                    var opt = true;
                    //27 tot
                    var cuatroxMil = 0;
                    var totalCuatroxMil = 0;

                    var Spendiente = 0;
                    var auxSpendiente = 0;

                    if (rowTransf == true)
                    {
                        rowtransferencias = rowTras + 7;
                    }
                    rowTransf = false;

                    foreach (var dataorpa in datosOrpa)
                    {

                        auxOrpa2 = true;
                        if (cuatroxMil != null)
                            cuatroxMil = ((int)dataorpa.valortotal * 4 / 1000) + (int)dataorpa.valortotal;
                        totalCuatroxMil += cuatroxMil;

                        id_investigaciongasto = dataorpa.id_investigaciongasto;

                        xlsdocument.SetCellValue(rowtransferencias, 1, dataorpa.nombreconcepto);
                        xlsdocument.SetCellValue("B" + rowtransferencias, dataorpa.nombrecompleto);
                        xlsdocument.SetCellValue("C" + rowtransferencias, dataorpa.numidentificacion);
                        xlsdocument.SetCellValue("I" + rowtransferencias, dataorpa.fechalegalizacionorden.ToString());
                        xlsdocument.SetCellValue("J" + rowtransferencias, dataorpa.tipo);
                        xlsdocument.SetCellValue("K" + rowtransferencias, dataorpa.numorden);
                        xlsdocument.SetCellValue("L" + rowtransferencias, dataorpa.fechainicio.ToString());
                        xlsdocument.SetCellValue("M" + rowtransferencias, dataorpa.fechafinal.ToString());
                        xlsdocument.SetCellValue("N" + rowtransferencias, dataorpa.estado);
                        xlsdocument.SetCellValue("X" + rowtransferencias, dataorpa.observaciones);
                        if (dataorpa.valortotal != null)
                            xlsdocument.SetCellValue("O" + rowtransferencias, (int)dataorpa.valortotal);
                        xlsdocument.SetCellValue("P" + rowtransferencias, cuatroxMil);


                        opt = false;

                        if (dataorpa.id_relacionvinculo == 1 || dataorpa.id_relacionvinculo == 2)
                        {
                            xlsdocument.SetCellValue("H" + rowtransferencias, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 3)
                        {
                            xlsdocument.SetCellValue("E" + rowtransferencias, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 4)
                        {
                            xlsdocument.SetCellValue("F" + rowtransferencias, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 5)
                        {
                            xlsdocument.SetCellValue("G" + rowtransferencias, "X");

                        }


                        string qryPagos = "select ap.orpa, ap.fechapago, ap.cp_egr, sm.nmsemestre, ap.valorneto from investigacion_aplicarpago ap join investigacion_gasto ga on ap.id_investigaciongasto = ga.id_investigaciongasto join seguimiento_rubro rub on ga.id_rubro = rub.id_rubro join seguimiento_partida ru on ga.id_partida = ru.id_partida join seguimiento_concepto co on ga.id_segconcepto = co.id_segconcepto join semestre sm on ap.id_semestre = sm.id_semestre join seguimiento_relacionvinculo rv on ga.id_relacionvinculo = rv.id_relacionvinculo join persona pe on ga.id_persona = pe.id_persona where ap.id_crearproyecto = @id_crearproyecto and ru.id_partida = 5 and rub.id_rubro = @id_rubro and ga.id_investigaciongasto = @id_investigaciongasto group by  ap.orpa, ap.fechapago, ap.cp_egr, sm.nmsemestre, ap.valorneto";
                        List<NpgsqlParameter> parameterListPagos = new List<NpgsqlParameter>();
                        parameterListPagos.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                        parameterListPagos.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                        parameterListPagos.Add(new NpgsqlParameter("@id_investigaciongasto", id_investigaciongasto));
                        NpgsqlParameter[] ParamPagos = parameterListPagos.ToArray();

                        var datosPagos = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryPagos, ParamPagos).ToList();

                        var nmOrpas = datosPagos.Select(x => x.orpa).ToArray();

                        string qryEjecutado = "select sum(ap.valorneto) as ejecutado from investigacion_aplicarpago ap join investigacion_gasto ga on ap.id_investigaciongasto = ga.id_investigaciongasto join seguimiento_rubro rub on ga.id_rubro = rub.id_rubro join seguimiento_partida ru on ga.id_partida = ru.id_partida where ap.id_crearproyecto = @id_crearproyecto and ru.id_partida = 5 and rub.id_rubro = @id_rubro";
                        List<NpgsqlParameter> parameterListEjecutado = new List<NpgsqlParameter>();
                        parameterListEjecutado.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                        parameterListEjecutado.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                        NpgsqlParameter[] ParamEjecutado = parameterListEjecutado.ToArray();




                        var datosEjecutado = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryEjecutado, ParamEjecutado).ToList();


                        foreach (var registroE in datosEjecutado)
                        {
                            var cuatroxmil = (registroE.ejecutado * 4 / 1000) + registroE.ejecutado;
                            var disponibilidad = totalCuatroxMil - cuatroxmil;

                            if (cuatroxmil != null)
                                xlsdocument.SetCellValue("S" + (rowTras + 3), (int)cuatroxmil);
                            if (disponibilidad != null)
                                xlsdocument.SetCellValue("S" + (rowTras + 4), (int)disponibilidad);


                        }


                        auxSpendiente = 0;
                        foreach (var pagos in datosPagos)
                        {
                            if (auxOrpa2 == true)
                            {
                                auxrowOrpa = rowtransferencias;
                            }
                            auxOrpa2 = false;
                            if (pagos.valorneto != null)
                                cuatropormilPagos = ((int)pagos.valorneto * 4 / 1000) + (int)pagos.valorneto;

                            xlsdocument.SetCellValue("Q" + rowtransferencias, pagos.orpa);
                            xlsdocument.SetCellValue("R" + rowtransferencias, pagos.fechapago.ToString());
                            xlsdocument.SetCellValue("S" + rowtransferencias, pagos.cp_egr);
                            xlsdocument.SetCellValue("T" + rowtransferencias, pagos.nmsemestre);
                            if (pagos.valorneto != null)
                                xlsdocument.SetCellValue("U" + rowtransferencias, (int)pagos.valorneto);
                            xlsdocument.SetCellValue("V" + rowtransferencias, cuatropormilPagos);

                            auxSpendiente += cuatropormilPagos;

                            if (nmOrpas.Length == 1)
                            {
                                Spendiente = (int)(cuatroxMil - cuatropormilPagos);

                            }

                            rowtransferencias++;
                        }

                        if (nmOrpas.Length == 1)
                        {
                            xlsdocument.SetCellValue("W" + (rowtransferencias - 1), Spendiente);
                        }
                        if (nmOrpas.Length > 1)
                        {
                            Spendiente = (int)(cuatroxMil - auxSpendiente);
                            xlsdocument.SetCellValue("W" + auxrowOrpa, Spendiente);
                        }

                        if (nmOrpas.Length == 0)
                        {
                            Spendiente = cuatroxMil;
                            xlsdocument.SetCellValue("W" + rowtransferencias, Spendiente);
                            rowtransferencias++;
                            xlsdocument.MergeWorksheetCells("A" + auxrowOrpa, "A" + (rowtransferencias - 2));
                            xlsdocument.MergeWorksheetCells("B" + auxrowOrpa, "B" + (rowtransferencias - 2));
                            xlsdocument.MergeWorksheetCells("C" + auxrowOrpa, "C" + (rowtransferencias - 2));
                            xlsdocument.MergeWorksheetCells("D" + auxrowOrpa, "D" + (rowtransferencias - 2));
                            xlsdocument.MergeWorksheetCells("E" + auxrowOrpa, "E" + (rowtransferencias - 2));
                            xlsdocument.MergeWorksheetCells("F" + auxrowOrpa, "F" + (rowtransferencias - 2));
                            xlsdocument.MergeWorksheetCells("G" + auxrowOrpa, "G" + (rowtransferencias - 2));
                            xlsdocument.MergeWorksheetCells("H" + auxrowOrpa, "H" + (rowtransferencias - 2));
                            xlsdocument.MergeWorksheetCells("I" + auxrowOrpa, "I" + (rowtransferencias - 2));
                            xlsdocument.MergeWorksheetCells("J" + auxrowOrpa, "J" + (rowtransferencias - 2));
                            xlsdocument.MergeWorksheetCells("K" + auxrowOrpa, "K" + (rowtransferencias - 2));
                            xlsdocument.MergeWorksheetCells("L" + auxrowOrpa, "L" + (rowtransferencias - 2));
                            xlsdocument.MergeWorksheetCells("M" + auxrowOrpa, "M" + (rowtransferencias - 2));
                            xlsdocument.MergeWorksheetCells("N" + auxrowOrpa, "N" + (rowtransferencias - 2));
                            xlsdocument.MergeWorksheetCells("O" + auxrowOrpa, "O" + (rowtransferencias - 2));
                            xlsdocument.MergeWorksheetCells("P" + auxrowOrpa, "P" + (rowtransferencias - 2));
                            xlsdocument.MergeWorksheetCells("W" + auxrowOrpa, "W" + (rowtransferencias - 2));
                            xlsdocument.MergeWorksheetCells("X" + auxrowOrpa, "X" + (rowtransferencias - 2));
                        }
                        else
                        {
                            rowtransferencias++;
                            xlsdocument.HideRow(rowtransferencias - 1);
                            xlsdocument.MergeWorksheetCells("A" + auxrowOrpa, "A" + (rowtransferencias - 1));
                            xlsdocument.MergeWorksheetCells("B" + auxrowOrpa, "B" + (rowtransferencias - 1));
                            xlsdocument.MergeWorksheetCells("C" + auxrowOrpa, "C" + (rowtransferencias - 1));
                            xlsdocument.MergeWorksheetCells("D" + auxrowOrpa, "D" + (rowtransferencias - 1));
                            xlsdocument.MergeWorksheetCells("E" + auxrowOrpa, "E" + (rowtransferencias - 1));
                            xlsdocument.MergeWorksheetCells("F" + auxrowOrpa, "F" + (rowtransferencias - 1));
                            xlsdocument.MergeWorksheetCells("G" + auxrowOrpa, "G" + (rowtransferencias - 1));
                            xlsdocument.MergeWorksheetCells("H" + auxrowOrpa, "H" + (rowtransferencias - 1));
                            xlsdocument.MergeWorksheetCells("I" + auxrowOrpa, "I" + (rowtransferencias - 1));
                            xlsdocument.MergeWorksheetCells("J" + auxrowOrpa, "J" + (rowtransferencias - 1));
                            xlsdocument.MergeWorksheetCells("K" + auxrowOrpa, "K" + (rowtransferencias - 1));
                            xlsdocument.MergeWorksheetCells("L" + auxrowOrpa, "L" + (rowtransferencias - 1));
                            xlsdocument.MergeWorksheetCells("M" + auxrowOrpa, "M" + (rowtransferencias - 1));
                            xlsdocument.MergeWorksheetCells("N" + auxrowOrpa, "N" + (rowtransferencias - 1));
                            xlsdocument.MergeWorksheetCells("O" + auxrowOrpa, "O" + (rowtransferencias - 1));
                            xlsdocument.MergeWorksheetCells("P" + auxrowOrpa, "P" + (rowtransferencias - 1));
                            xlsdocument.MergeWorksheetCells("W" + auxrowOrpa, "W" + (rowtransferencias - 1));
                            xlsdocument.MergeWorksheetCells("X" + auxrowOrpa, "X" + (rowtransferencias - 1));
                        }



                        xlsdocument.SetCellStyle("Y1", "Y" + rowtransferencias, rowBorder);

                    }
                    xlsdocument.SetCellStyle("A" + rowtransferencias, "X" + rowtransferencias, rowBorder);
                    //rowRubNew = rowTot + 1;
                    rowOptransferencias = rowtransferencias + 1;
                    if (borders == true)
                    {
                        for (var i = 1; i <= rowtransferencias; i++)
                        {
                            xlsdocument.SetCellStyle("A" + i, "X" + rowtransferencias, bordersStyle);
                        }
                    }

                    if (nmstransferencias.Length < 1)
                    {

                        borders = false;
                    }

                }

                rub5 = false;

                if (nmstransferencias.Length > 1)
                {

                    if (deleteTransferencias == true)
                    {

                        xlsdocument.DeleteRow(rowTras + 2, rowOptransferencias - (rowTras + 2));
                        //                           rowRubNew = rowRubNew - 21;
                        xlsdocument.HideRow(rowTras + 2, rowOptransferencias - 1);
                    }
                    deleteTransferencias = false;

                    xlsdocument.SetCellValue(rowOptransferencias, 1, "RUBRO");
                    xlsdocument.SetCellStyle(rowOptransferencias, 1, transferencias);
                    xlsdocument.SetCellValue(rowOptransferencias, 2, registro.nombrerubro);
                    xlsdocument.MergeWorksheetCells("A" + rowOptransferencias, "A" + (rowOptransferencias + 2));
                    xlsdocument.MergeWorksheetCells("B" + rowOptransferencias, "N" + (rowOptransferencias + 2));
                    xlsdocument.MergeWorksheetCells("O" + rowOptransferencias, "R" + rowOptransferencias);
                    xlsdocument.SetCellValue(rowOptransferencias, 15, "VALOR");
                    xlsdocument.SetCellStyle(rowOptransferencias, 15, transferencias);
                    xlsdocument.MergeWorksheetCells("O" + (rowOptransferencias + 1), "R" + (rowOptransferencias + 1));
                    xlsdocument.SetCellValue(rowOptransferencias + 1, 15, "EJECUTADO");
                    xlsdocument.SetCellStyle(rowOptransferencias + 1, 15, transferencias);
                    xlsdocument.MergeWorksheetCells("O" + (rowOptransferencias + 2), "R" + (rowOptransferencias + 2));
                    xlsdocument.SetCellValue(rowOptransferencias + 2, 15, "DISPONIBILIDAD DEL RUBRO");
                    xlsdocument.SetCellStyle(rowOptransferencias + 2, 15, transferencias);
                    xlsdocument.MergeWorksheetCells("S" + rowOptransferencias, "X" + rowOptransferencias);
                    xlsdocument.MergeWorksheetCells("S" + (rowOptransferencias + 1), "X" + (rowOptransferencias + 1));
                    xlsdocument.MergeWorksheetCells("S" + (rowOptransferencias + 2), "X" + (rowOptransferencias + 2));
                    xlsdocument.MergeWorksheetCells("A" + (rowOptransferencias + 3), "A" + (rowOptransferencias + 4));
                    xlsdocument.SetCellValue(rowOptransferencias + 3, 1, "CONCEPTO");
                    xlsdocument.SetColumnWidth("A" + (rowOptransferencias + 3), 15.0);
                    xlsdocument.SetCellStyle(rowOptransferencias + 3, 1, transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("B" + (rowOptransferencias + 3), "B" + (rowOptransferencias + 4));
                    xlsdocument.SetCellValue(rowOptransferencias + 3, 2, "NOMBRE");
                    xlsdocument.SetCellStyle(rowOptransferencias + 3, 2, transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("C" + (rowOptransferencias + 3), "C" + (rowOptransferencias + 4));
                    xlsdocument.SetCellValue(rowOptransferencias + 3, 3, "IDENTIFICACION");
                    xlsdocument.SetColumnWidth("C" + (rowOptransferencias + 3), 25.0);
                    xlsdocument.SetCellStyle(rowOptransferencias + 3, 3, transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("D" + (rowOptransferencias + 3), "D" + (rowOptransferencias + 4));
                    xlsdocument.SetCellValue(rowOptransferencias + 3, 4, "AREA");
                    xlsdocument.SetCellStyle(rowOptransferencias + 3, 4, transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("E" + (rowOptransferencias + 3), "H" + (rowOptransferencias + 3));
                    xlsdocument.SetCellValue("E" + (rowOptransferencias + 3), "RELACION DEL VINCULO");
                    xlsdocument.SetCellStyle("E" + (rowOptransferencias + 3), transferenciasCentred);
                    xlsdocument.SetCellValue("E" + (rowOptransferencias + 4), "PREGRADO");
                    xlsdocument.SetCellStyle("E" + (rowOptransferencias + 4), transferenciasCentred);
                    xlsdocument.SetColumnWidth("E" + (rowOptransferencias + 4), 20.0);
                    xlsdocument.SetCellValue("F" + (rowOptransferencias + 4), "POSGRADO");
                    xlsdocument.SetCellStyle("F" + (rowOptransferencias + 4), transferenciasCentred);
                    xlsdocument.SetColumnWidth("F" + (rowOptransferencias + 4), 20.0);
                    xlsdocument.SetCellValue("G" + (rowOptransferencias + 4), "EGRESADO");
                    xlsdocument.SetCellStyle("G" + (rowOptransferencias + 4), transferenciasCentred);
                    xlsdocument.SetColumnWidth("G" + (rowOptransferencias + 4), 20.0);
                    xlsdocument.SetCellValue("H" + (rowOptransferencias + 4), "OTRO");
                    xlsdocument.SetCellStyle("H" + (rowOptransferencias + 4), transferenciasCentred);
                    xlsdocument.SetColumnWidth("H" + (rowOptransferencias + 4), 20.0);
                    xlsdocument.MergeWorksheetCells("I" + (rowOptransferencias + 3), "I" + (rowOptransferencias + 4));
                    xlsdocument.SetCellValue("I" + (rowOptransferencias + 3), "FECHA");
                    xlsdocument.SetCellStyle("I" + (rowOptransferencias + 3), transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("J" + (rowOptransferencias + 3), "J" + (rowOptransferencias + 4));
                    xlsdocument.SetCellValue("J" + (rowOptransferencias + 3), "TIPO");
                    xlsdocument.SetCellStyle("J" + (rowOptransferencias + 3), transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("K" + (rowOptransferencias + 3), "K" + (rowOptransferencias + 4));
                    xlsdocument.SetCellValue("K" + (rowOptransferencias + 3), "No.");
                    xlsdocument.SetCellStyle("K" + (rowOptransferencias + 3), transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("L" + (rowOptransferencias + 3), "L" + (rowOptransferencias + 4));
                    xlsdocument.SetCellValue("L" + (rowOptransferencias + 3), "FECHA INICIO");
                    xlsdocument.SetCellStyle("L" + (rowOptransferencias + 3), transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("M" + (rowOptransferencias + 3), "M" + (rowOptransferencias + 4));
                    xlsdocument.SetCellValue("M" + (rowOptransferencias + 3), "FECHA FINAL");
                    xlsdocument.SetCellStyle("M" + (rowOptransferencias + 3), transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("N" + (rowOptransferencias + 3), "N" + (rowOptransferencias + 4));
                    xlsdocument.SetCellValue("N" + (rowOptransferencias + 3), "ESTADO");
                    xlsdocument.SetCellStyle("N" + (rowOptransferencias + 3), transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("O" + (rowOptransferencias + 3), "O" + (rowOptransferencias + 4));
                    xlsdocument.SetCellValue("O" + (rowOptransferencias + 3), "Valor Total");
                    xlsdocument.SetCellStyle("O" + (rowOptransferencias + 3), transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("P" + (rowOptransferencias + 3), "P" + (rowOptransferencias + 4));
                    xlsdocument.SetCellValue("P" + (rowOptransferencias + 3), "Valor con 4 xmil");
                    xlsdocument.SetCellStyle("P" + (rowOptransferencias + 3), transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("Q" + (rowOptransferencias + 3), "V" + (rowOptransferencias + 3));
                    xlsdocument.SetCellValue("Q" + (rowOptransferencias + 3), "PAGOS");
                    xlsdocument.SetCellStyle("Q" + (rowOptransferencias + 3), transferenciasCentred);
                    xlsdocument.SetCellValue("Q" + (rowOptransferencias + 4), "ORPA");
                    xlsdocument.SetCellStyle("Q" + (rowOptransferencias + 4), transferenciasCentred);
                    xlsdocument.SetCellValue("R" + (rowOptransferencias + 4), "FECHA");
                    xlsdocument.SetCellStyle("R" + (rowOptransferencias + 4), transferenciasCentred);
                    xlsdocument.SetCellValue("S" + (rowOptransferencias + 4), "CP.EGR");
                    xlsdocument.SetCellStyle("S" + (rowOptransferencias + 4), transferenciasCentred);
                    xlsdocument.SetCellValue("T" + (rowOptransferencias + 4), "PERIODO");
                    xlsdocument.SetCellStyle("T" + (rowOptransferencias + 4), transferenciasCentred);
                    xlsdocument.SetCellValue("U" + (rowOptransferencias + 4), "VALOR NETO");
                    xlsdocument.SetCellStyle("U" + (rowOptransferencias + 4), transferenciasCentred);
                    xlsdocument.SetCellValue("V" + (rowOptransferencias + 4), "VALOR 4*1000");
                    xlsdocument.SetCellStyle("V" + (rowOptransferencias + 4), transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("W" + (rowOptransferencias + 3), "W" + (rowOptransferencias + 4));
                    xlsdocument.SetCellValue("W" + (rowOptransferencias + 3), "SALDO PENDIENTE");
                    xlsdocument.SetCellStyle("W" + (rowOptransferencias + 3), transferenciasCentred);
                    xlsdocument.MergeWorksheetCells("X" + (rowOptransferencias + 3), "X" + (rowOptransferencias + 4));
                    xlsdocument.SetCellValue("X" + (rowOptransferencias + 3), "OBSERVACION");
                    xlsdocument.SetCellStyle("X" + (rowOptransferencias + 3), transferenciasCentred);
                    xlsdocument.SetColumnWidth("L" + (rowOptransferencias + 3), 25.0);
                    xlsdocument.SetColumnWidth("M" + (rowOptransferencias + 3), 25.0);
                    xlsdocument.SetColumnWidth("N" + (rowOptransferencias + 3), 25.0);
                    xlsdocument.SetColumnWidth("O" + (rowOptransferencias + 3), 25.0);
                    xlsdocument.SetColumnWidth("P" + (rowOptransferencias + 3), 25.0);
                    xlsdocument.SetColumnWidth("Q" + (rowOptransferencias + 3), 25.0);
                    xlsdocument.SetColumnWidth("R" + (rowOptransferencias + 3), 25.0);
                    xlsdocument.SetColumnWidth("S" + (rowOptransferencias + 3), 25.0);
                    xlsdocument.SetColumnWidth("T" + (rowOptransferencias + 3), 25.0);
                    xlsdocument.SetColumnWidth("U" + (rowOptransferencias + 3), 25.0);
                    xlsdocument.SetColumnWidth("V" + (rowOptransferencias + 3), 25.0);
                    xlsdocument.SetColumnWidth("W" + (rowOptransferencias + 3), 25.0);
                    xlsdocument.SetColumnWidth("X" + (rowOptransferencias + 3), 25.0);

                    id_rubro = registro.id_rubro;

                    //Incluimos el valor total por concepto 
                    string qryValorTotal = "select sum (valortotal) from investigacion_gasto where id_crearproyecto = @id_crearproyecto and id_partida = 5 and id_rubro = @id_rubro";
                    List<NpgsqlParameter> parameterListTotal = new List<NpgsqlParameter>();
                    parameterListTotal.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                    parameterListTotal.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                    NpgsqlParameter[] ParamTotal = parameterListTotal.ToArray();



                    var datosTotal = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryValorTotal, ParamTotal).ToList();



                    foreach (var registroN in datosTotal)
                    {
                        var cuatroxmil = (registroN.sum * 4 / 1000) + registroN.sum;
                        if (cuatroxmil != null)
                            xlsdocument.SetCellValue("S" + (rowOptransferencias), (int)cuatroxmil);

                    }



                    string qryorpa = "select co.nombreconcepto, pe.nombrecompleto , pe.numidentificacion, rv.id_relacionvinculo, ga.fechainicio, ga.fechafinal, ga.numorden, ga.fechalegalizacionorden, ga.tipo, ga.valortotal, ga.estado, ga.id_investigaciongasto from investigacion_gasto ga join seguimiento_concepto co on ga.id_segconcepto = co.id_segconcepto join persona pe on ga.id_persona = pe.id_persona join seguimiento_relacionvinculo rv on ga.id_relacionvinculo = rv.id_relacionvinculo where ga.id_crearproyecto = @id_crearproyecto and ga.id_partida = 5 and ga.id_rubro = @id_rubro";
                    List<NpgsqlParameter> parameterListOrpa = new List<NpgsqlParameter>();
                    parameterListOrpa.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                    parameterListOrpa.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                    NpgsqlParameter[] ParamOrpa = parameterListOrpa.ToArray();

                    var datosOrpa = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryorpa, ParamOrpa).ToList();




                    var auxrowOrpa = 0;
                    var auxOrpa2 = true;
                    var optSec = true;
                    //27 tot
                    var cuatroxMil = 0;
                    var totalCuatroxMil = 0;

                    var auxSer = rowOptransferencias + 5;

                    var rowOrpa = auxSer;

                    var Spendiente = 0;
                    var auxSpendiente = 0;

                    optOrpa = false;
                    foreach (var dataorpa in datosOrpa)
                    {
                        auxOrpa2 = true;

                        id_investigaciongasto = dataorpa.id_investigaciongasto;
                        if (cuatroxMil != null)
                            cuatroxMil = ((int)dataorpa.valortotal * 4 / 1000) + (int)dataorpa.valortotal;
                        totalCuatroxMil += cuatroxMil;

                        xlsdocument.SetCellValue(rowOrpa, 1, dataorpa.nombreconcepto);
                        xlsdocument.SetCellValue("B" + rowOrpa, dataorpa.nombrecompleto);
                        xlsdocument.SetCellValue("C" + rowOrpa, dataorpa.numidentificacion);
                        xlsdocument.SetCellValue("I" + rowOrpa, dataorpa.fechalegalizacionorden.ToString());
                        xlsdocument.SetCellValue("J" + rowOrpa, dataorpa.tipo);
                        xlsdocument.SetCellValue("K" + rowOrpa, dataorpa.numorden);
                        xlsdocument.SetCellValue("L" + rowOrpa, dataorpa.fechainicio.ToString());
                        xlsdocument.SetCellValue("M" + rowOrpa, dataorpa.fechafinal.ToString());
                        xlsdocument.SetCellValue("N" + rowOrpa, dataorpa.estado);
                        xlsdocument.SetCellValue("X" + rowOrpa, dataorpa.observaciones);
                        if (dataorpa.valortotal != null)
                            xlsdocument.SetCellValue("O" + rowOrpa, (int)dataorpa.valortotal);
                        xlsdocument.SetCellValue("P" + rowOrpa, cuatroxMil);


                        optSec = false;

                        if (dataorpa.id_relacionvinculo == 1 || dataorpa.id_relacionvinculo == 2)
                        {
                            xlsdocument.SetCellValue("H" + rowOrpa, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 3)
                        {
                            xlsdocument.SetCellValue("E" + rowOrpa, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 4)
                        {
                            xlsdocument.SetCellValue("F" + rowOrpa, "X");

                        }
                        else if (dataorpa.id_relacionvinculo == 5)
                        {
                            xlsdocument.SetCellValue("G" + rowOrpa, "X");

                        }



                        string qryPagos = "select ap.orpa, ap.fechapago, ap.cp_egr, sm.nmsemestre, ap.valorneto from investigacion_aplicarpago ap join investigacion_gasto ga on ap.id_investigaciongasto = ga.id_investigaciongasto join seguimiento_rubro rub on ga.id_rubro = rub.id_rubro join seguimiento_partida ru on ga.id_partida = ru.id_partida join seguimiento_concepto co on ga.id_segconcepto = co.id_segconcepto join semestre sm on ap.id_semestre = sm.id_semestre join seguimiento_relacionvinculo rv on ga.id_relacionvinculo = rv.id_relacionvinculo join persona pe on ga.id_persona = pe.id_persona where ap.id_crearproyecto = @id_crearproyecto and ru.id_partida = 5 and rub.id_rubro = @id_rubro and ga.id_investigaciongasto = @id_investigaciongasto group by  ap.orpa, ap.fechapago, ap.cp_egr, sm.nmsemestre, ap.valorneto";
                        List<NpgsqlParameter> parameterListPagos = new List<NpgsqlParameter>();
                        parameterListPagos.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                        parameterListPagos.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                        parameterListPagos.Add(new NpgsqlParameter("@id_investigaciongasto", id_investigaciongasto));
                        NpgsqlParameter[] ParamPagos = parameterListPagos.ToArray();

                        var datosPagos = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryPagos, ParamPagos).ToList();

                        var nmOrpas = datosPagos.Select(x => x.orpa).ToArray();

                        string qryEjecutado = "select sum(ap.valorneto) as ejecutado from investigacion_aplicarpago ap join investigacion_gasto ga on ap.id_investigaciongasto = ga.id_investigaciongasto join seguimiento_rubro rub on ga.id_rubro = rub.id_rubro join seguimiento_partida ru on ga.id_partida = ru.id_partida where ap.id_crearproyecto = @id_crearproyecto and ru.id_partida = 5 and rub.id_rubro = @id_rubro";
                        List<NpgsqlParameter> parameterListEjecutado = new List<NpgsqlParameter>();
                        parameterListEjecutado.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
                        parameterListEjecutado.Add(new NpgsqlParameter("@id_rubro", id_rubro));
                        NpgsqlParameter[] ParamEjecutado = parameterListEjecutado.ToArray();




                        var datosEjecutado = _context.Database.SqlQuery<excelControlFinancieroInvestigacion>(qryEjecutado, ParamEjecutado).ToList();


                        foreach (var registroE in datosEjecutado)
                        {
                            var cuatroxmil = (registroE.ejecutado * 4 / 1000) + registroE.ejecutado;
                            var disponibilidad = totalCuatroxMil - cuatroxmil;

                            if (cuatroxmil != null)
                                xlsdocument.SetCellValue("S" + (rowOptransferencias + 1), (int)cuatroxmil);
                            if (disponibilidad != null)
                                xlsdocument.SetCellValue("S" + (rowOptransferencias + 2), (int)disponibilidad);


                        }


                        auxSpendiente = 0;
                        foreach (var pagos in datosPagos)
                        {
                            if (auxOrpa2 == true)
                            {
                                auxrowOrpa = rowOrpa;
                            }
                            auxOrpa2 = false;
                            if (cuatropormilPagos != null)
                                cuatropormilPagos = ((int)pagos.valorneto * 4 / 1000) + (int)pagos.valorneto;

                            xlsdocument.SetCellValue("Q" + rowOrpa, pagos.orpa);
                            xlsdocument.SetCellValue("R" + rowOrpa, pagos.fechapago.ToString());
                            xlsdocument.SetCellValue("S" + rowOrpa, pagos.cp_egr);
                            xlsdocument.SetCellValue("T" + rowOrpa, pagos.nmsemestre);
                            if (pagos.valorneto != null)
                                xlsdocument.SetCellValue("U" + rowOrpa, (int)pagos.valorneto);
                            xlsdocument.SetCellValue("V" + rowOrpa, cuatropormilPagos);

                            auxSpendiente += cuatropormilPagos;

                            if (nmOrpas.Length == 1)
                            {
                                Spendiente = (int)(cuatroxMil - cuatropormilPagos);

                            }


                            rowOrpa++;
                        }

                        if (nmOrpas.Length == 1)
                        {
                            xlsdocument.SetCellValue("W" + (rowOrpa - 1), Spendiente);
                        }
                        if (nmOrpas.Length > 1)
                        {
                            Spendiente = (int)(cuatroxMil - auxSpendiente);
                            xlsdocument.SetCellValue("W" + auxrowOrpa, Spendiente);
                        }

                        if (nmOrpas.Length == 0)
                        {
                            Spendiente = cuatroxMil;
                            xlsdocument.SetCellValue("W" + rowOrpa, Spendiente);
                            rowOrpa++;
                            xlsdocument.MergeWorksheetCells("A" + auxrowOrpa, "A" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("B" + auxrowOrpa, "B" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("C" + auxrowOrpa, "C" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("D" + auxrowOrpa, "D" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("E" + auxrowOrpa, "E" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("F" + auxrowOrpa, "F" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("G" + auxrowOrpa, "G" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("H" + auxrowOrpa, "H" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("I" + auxrowOrpa, "I" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("J" + auxrowOrpa, "J" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("K" + auxrowOrpa, "K" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("L" + auxrowOrpa, "L" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("M" + auxrowOrpa, "M" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("N" + auxrowOrpa, "N" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("O" + auxrowOrpa, "O" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("P" + auxrowOrpa, "P" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("W" + auxrowOrpa, "W" + (rowOrpa - 2));
                            xlsdocument.MergeWorksheetCells("X" + auxrowOrpa, "X" + (rowOrpa - 2));
                        }
                        else
                        {
                            xlsdocument.MergeWorksheetCells("A" + auxrowOrpa, "A" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("B" + auxrowOrpa, "B" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("C" + auxrowOrpa, "C" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("D" + auxrowOrpa, "D" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("E" + auxrowOrpa, "E" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("F" + auxrowOrpa, "F" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("G" + auxrowOrpa, "G" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("H" + auxrowOrpa, "H" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("I" + auxrowOrpa, "I" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("J" + auxrowOrpa, "J" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("K" + auxrowOrpa, "K" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("L" + auxrowOrpa, "L" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("M" + auxrowOrpa, "M" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("N" + auxrowOrpa, "N" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("O" + auxrowOrpa, "O" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("P" + auxrowOrpa, "P" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("W" + auxrowOrpa, "W" + (rowOrpa - 1));
                            xlsdocument.MergeWorksheetCells("X" + auxrowOrpa, "X" + (rowOrpa - 1));
                        }




                    }

                    auxOrpa = rowOrpa;
                    xlsdocument.SetCellStyle("A" + rowOrpa, "X" + rowOrpa, rowBorder);
                    rowOptransferencias = rowOptransferencias + (auxOrpa - rowOptransferencias) + 1;
                    //rowTras = rowOpImpuestos;




                }


                /*if (nmsImpuestos.Length <= 1)
                {
                    rowTras = rowOpImpuestos;

                }
                */


            }

            if (borders == true)
            {
                if (nmstransferencias.Length != 0)
                {

                    xlsdocument.SetCellStyle("Y1", "Y" + auxOrpa, rowBorder);

                    for (var i = 1; i <= auxOrpa; i++)
                    {
                        xlsdocument.SetCellStyle("A" + i, "X" + auxOrpa, bordersStyle);
                    }
                }
                else
                {
                    xlsdocument.SetCellStyle("Y1", "Y" + rowTras, rowBorder);

                    for (var i = 1; i <= rowTras; i++)
                    {
                        xlsdocument.SetCellStyle("A" + i, "X" + rowTras, bordersStyle);
                    }
                }
            }

            borders = false;






            xlsdocument.SaveAs(archivo);
            return archivoreturn;




        }
    }
}