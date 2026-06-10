using DocumentFormat.OpenXml.Spreadsheet;
using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.TableModel;
using Npgsql;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories.Investigacion
{
    public class InvestigacionExcelControlFinancieroRepository
    {
        private ApplicationDbContext _context;

        public InvestigacionExcelControlFinancieroRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public InvestigacionExcelControlFinancieroRepository()
        {
            _context = new ApplicationDbContext();
        }

        public string ExcelInvestigacionControlFinanciero(int id_crearproyecto)
        {
            var archivoreturn = "/Export/InvestigacionControlFinanciero_" + id_crearproyecto.ToString() + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/InvestigacionControlFinanciero_" + id_crearproyecto.ToString() + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/InvestigacionControl_Financiero_.xlsx");
            SLDocument xlsdocument = new SLDocument(plantilla);

            //string qry = "";

            //List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            //parameterList.Add(new NpgsqlParameter("@id_crearproyecto", id_crearproyecto));
            //NpgsqlParameter[] Param = parameterList.ToArray();
            //var datos = _context.Database.SqlQuery<InvestigacionExcelControlFinancieroDTO>(qry, Param).ToList();



            SLStyle style = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            SLStyle titlesCentred = xlsdocument.CreateStyle();
            SLStyle titlesLeft = xlsdocument.CreateStyle();
            SLStyle rowBorder = xlsdocument.CreateStyle();
            SLStyle titleWOutBKg = xlsdocument.CreateStyle(); //Titulos sin color de fondo 



            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            //style.SetWrapText(true);
            //style.Alignment.JustifyLastLine = true;
            //style.Alignment.ShrinkToFit = true;
            rowBorder.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.Black, System.Drawing.Color.Black);

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
            xlsdocument.MergeWorksheetCells("T9", "X10");
            xlsdocument.MergeWorksheetCells("T11", "X11");
            xlsdocument.SetCellValue("T11", "TOTAL CONVENIO APROBADO");
            xlsdocument.SetCellStyle("T11", titleWOutBKg);
            xlsdocument.MergeWorksheetCells("T12", "X13");

            xlsdocument.AutoFitColumn(1, 25);
            xlsdocument.AutoFitRow(1, 25);
            xlsdocument.SetWorksheetDefaultColumnWidth(13.0);
            xlsdocument.SetColumnWidth(1, 13.5);
            xlsdocument.SetColumnWidth(2, 29.5);
            xlsdocument.SetColumnWidth(3, 17.0);
            xlsdocument.SetCellStyle("A6", "X6", rowBorder);
            xlsdocument.SetCellStyle("Y1", "Y6", rowBorder);
            xlsdocument.SetColumnWidth("Y", 2.5);
            xlsdocument.SetRowHeight(6, 11.0);


            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }
    }
}