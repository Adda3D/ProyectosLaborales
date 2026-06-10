using DocumentFormat.OpenXml.Spreadsheet;
using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models.Decanatura;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.TableModel;
using Npgsql;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories.Publicacion
{
    public class PublicacionesExcelRepository
    {
        private ApplicationDbContext _context;

        public PublicacionesExcelRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public PublicacionesExcelRepository()
        {
            _context = new ApplicationDbContext();
        }   
        public string ExcelPublicaciones(string id_kardex, int id_bodega)
        {
            var archivoreturn = "/Export/PUBLICACIONESEXCEL_" + id_kardex.ToString() + id_bodega.ToString() + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/PUBLICACIONESEXCEL_" + id_kardex.ToString() + id_bodega.ToString() + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/PUBLICACIONES_EXCEl.xlsx");

            SLDocument xlsdocument = new SLDocument(plantilla);
            string qry = "select cp.id_kardex, (ca.tirajetotal) - (sum(unidadesvendidas)) as total_inventario, sum(unidadesvendidas) as unidades_vendidas, sum(pd.valorventas) as total_ventas" 
                        + " from publicaciones_depositocontrolrepventas pd" 
                        + " join publicaciones_crearpublicacion cp on pd.id_crearpublicacion = cp.id_crearpublicacion" 
                        + " join publicaciones_depositocontrolacta ca on cp.id_crearpublicacion = ca.id_crearpublicacion where cp.id_kardex = @id_kardex"
                        + " group by cp.id_kardex, ca.tirajetotal";

            string qry2 = "select cp.id_kardex as kardex, ca.tirajetotal-(sum(dc.cantidad)) as inv_institucional, + " +
                "ca.tirajetotal - (ca.tirajetotal - (sum(dc.cantidad))) as inv_comercial from publicaciones_depositocontrolacta ca join " + 
                "publicaciones_depositodistribucioncomercial dc on ca.id_crearpublicacion = dc.id_crearpublicacion " +
                "join publicaciones_crearpublicacion cp on dc.id_crearpublicacion = cp.id_crearpublicacion where cp.id_kardex = @id_kardex group by id_kardex, ca.tirajetotal";

            string qry3 = "select ib.nmbodega, sum (im.cantidad) as ajustes from publicaciones_depositocontrolinventariomovimientos im "+
                "join publicaciones_depositocontrolinventariobodega ib on im.id_bodega = ib.id_bodega where ib.id_bodega = @id_bodega group by ib.id_bodega ";


            string qry4 = "select cp.id_kardex, nmformatodis, sum(unidadesvendidas) as unidades_vendidas from "+
                "publicaciones_depositocontrolrepventas pd join publicaciones_crearpublicacion cp on pd.id_crearpublicacion = "+
                "cp.id_crearpublicacion join publicaciones_formatodistribucion fd on cp.id_formatodistribucion = "+
                "fd.id_formatodistribucion where cp.id_kardex = @id_kardex group by cp.id_kardex, nmformatodis ";

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            List<NpgsqlParameter> parameterList2 = new List<NpgsqlParameter>();
            List<NpgsqlParameter> parameterList3 = new List<NpgsqlParameter>();
            List<NpgsqlParameter> parameterList4 = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@id_kardex", id_kardex));
            parameterList2.Add(new NpgsqlParameter("@id_kardex", id_kardex));
            parameterList3.Add(new NpgsqlParameter("@id_bodega", id_bodega));
            parameterList4.Add(new NpgsqlParameter("@id_kardex", id_kardex));
            NpgsqlParameter[] Param = parameterList.ToArray();
            NpgsqlParameter[] Param2 = parameterList2.ToArray();
            NpgsqlParameter[] Param3 = parameterList3.ToArray();
            NpgsqlParameter[] Param4 = parameterList4.ToArray();


            var datos = _context.Database.SqlQuery<PublicacionesExcelDTO>(qry, Param).ToList();
            var datos2 = _context.Database.SqlQuery<PublicacionesExcelDTO>(qry2, Param2).ToList();
            var datos3 = _context.Database.SqlQuery<PublicacionesExcelDTO>(qry3, Param3).ToList();
            var datos4 = _context.Database.SqlQuery<PublicacionesExcelDTO>(qry4, Param4).ToList();
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

            xlsdocument.SetCellValue(3, 2, "REPORTE PUBLICACIONES");
            xlsdocument.SetCellStyle(3, 2, style);
            xlsdocument.SetCellStyle(3, 2, styleBack);
            xlsdocument.MergeWorksheetCells(3, 2, 4, 8);

            filaxls += 1;

            if (datos != null)
            {
                var registro = datos[0];
                xlsdocument.SetCellValue(5, 1, "Total Ventas");
                xlsdocument.SetCellStyle(5, 1, style);
                xlsdocument.SetCellValue(5, 2, registro.total_ventas.ToString());
                xlsdocument.SetCellStyle(5, 2, style);
                xlsdocument.MergeWorksheetCells(5, 2, 5, 8);

                xlsdocument.SetCellValue(6, 1, "Saldo Inventario Comercial");
                xlsdocument.SetCellStyle(6, 1, style);
                xlsdocument.SetCellValueNumeric(6, 2, registro.total_inventario.ToString());
                xlsdocument.SetCellStyle(6, 2, style);
                xlsdocument.MergeWorksheetCells(6, 2, 6, 8);
                xlsdocument.SetCellValue(7, 1, "Unidades Vendidas");
                xlsdocument.SetCellStyle(7, 1, style);
                xlsdocument.SetCellValueNumeric(7, 2, registro.unidades_vendidas.ToString());
                xlsdocument.SetCellStyle(7, 2, style);
                xlsdocument.MergeWorksheetCells(7, 2, 7, 8);
                //xlsdocument.SetCellValue(7, 6, "Valor por comprometer");
                //xlsdocument.SetCellValueNumeric(7, 7, registro.presupuestogeneralcomprometer.ToString());
                //xlsdocument.SetCellValue(8, 2, "Presupuesto general de la Ugi");
                //xlsdocument.SetCellValueNumeric(8, 3, registro.presupuestougi.ToString());
                //xlsdocument.SetCellValue(8, 4, "Comprometido");
                //xlsdocument.SetCellValueNumeric(8, 5, registro.presupuestougicomprometido.ToString());
                //xlsdocument.SetCellValue(8, 6, "Valor por comprometer");
                //xlsdocument.SetCellValueNumeric(8, 7, registro.presupuestougicomprometer.ToString());
                //xlsdocument.SetCellValue(10, 2, "Presupuesto para Vinculación a estudiantes");
                //xlsdocument.SetCellValueNumeric(10, 3, registro.presupuestoestudiantes.ToString());
                //xlsdocument.SetCellValue(10, 4, "Comprometido");
                //xlsdocument.SetCellValueNumeric(10, 5, registro.presupuestoestudiantescomprometido.ToString());
                //xlsdocument.SetCellValue(10, 6, "Valor por comprometer");
                //xlsdocument.SetCellValueNumeric(10, 7, registro.presupuestoestudiantescomprometer.ToString());
            }

            foreach (var registro2 in datos2)
            {
                celdaxls = "B" + filaxls2.ToString();
                xlsdocument.SetCellValue(8, 1, "Inventario Institucional");
                xlsdocument.SetCellStyle(8, 1, style);
                xlsdocument.SetCellValue(8, 2, registro2.inv_institucional);
                xlsdocument.SetCellStyle(8, 2, style);
                xlsdocument.MergeWorksheetCells(8, 2, 8, 8);
                celdaxls = "C" + filaxls2.ToString();
                xlsdocument.SetCellValue(9, 1, "Inventario Comercial");
                xlsdocument.SetCellStyle(9, 1, style);
                xlsdocument.SetCellValueNumeric(9,2, registro2.inv_comercial.ToString());
                xlsdocument.SetCellStyle(9, 2, style);
                xlsdocument.MergeWorksheetCells(9, 2, 9, 8);
                //celdaxls = "D" + filaxls2.ToString();
                //xlsdocument.SetCellValueNumeric(celdaxls, registro2.valortotal.ToString());
                //celdaxls = "E" + filaxls2.ToString();
                //xlsdocument.SetCellValueNumeric(celdaxls, registro2.especializado.ToString());
                //celdaxls = "F" + filaxls2.ToString();
                //xlsdocument.SetCellValueNumeric(celdaxls, registro2.profesional.ToString());
                //celdaxls = "G" + filaxls2.ToString();
                //xlsdocument.SetCellValueNumeric(celdaxls, registro2.tecnico.ToString());
                //celdaxls = "H" + filaxls2.ToString();
                //xlsdocument.SetCellValueNumeric(celdaxls, registro2.asistencial.ToString());
                //celdaxls = "I" + filaxls2.ToString();
                //xlsdocument.SetCellValue(celdaxls, registro2.observaciones);

                filaxls2 += 1;
                xlsdocument.InsertRow(filaxls2, 1);
            }


            filaxls2 += 2;
            /*
            xlsdocument.SetCellValue(filaxls2, 1, "GASTOS OPERATIVOS");
            xlsdocument.SetCellStyle(filaxls2, 1, style);
            xlsdocument.MergeWorksheetCells(filaxls2, 1, filaxls2, 5);

            filaxls2 += 1;
            xlsdocument.SetCellValue(filaxls2, 1, "Tipo Operativo");
            xlsdocument.SetCellValue(filaxls2, 2, "Dependencia");
            xlsdocument.SetCellValue(filaxls2, 3, "Número de personas contratadas");
            xlsdocument.SetCellValue(filaxls2, 4, "Valor total de la contratación por Dependencia");
            xlsdocument.SetCellValue(filaxls2, 5, "Observaciones");
            */

            foreach (var registro3 in datos3)
            {
                filaxls2 += 1;

                celdaxls = "A" + filaxls2.ToString();
                xlsdocument.SetCellValue(10, 1, "Ajustes realizados");
                xlsdocument.SetCellStyle(10, 1, style);
                xlsdocument.SetCellValue(10,2, registro3.ajustes);
                xlsdocument.SetCellStyle(10, 2, style);
                xlsdocument.MergeWorksheetCells(10, 2, 10, 8);
                //celdaxls = "B" + filaxls2.ToString();
                //xlsdocument.SetCellValue(celdaxls, registro3.nmdepend);
                //celdaxls = "C" + filaxls2.ToString();
                //xlsdocument.SetCellValueNumeric(celdaxls, registro3.totalpersonascontratadas.ToString());
                //celdaxls = "D" + filaxls2.ToString();
                //xlsdocument.SetCellValueNumeric(celdaxls, registro3.valortotal.ToString());
                //celdaxls = "E" + filaxls2.ToString();
                //xlsdocument.SetCellValue(celdaxls, registro3.observaciones);

            }
            //foreach(var registro4 in datos4)
            //{
            //    filaxls2 += 1;
            //    celdaxls = "A" + filaxls2.ToString();
            //    xlsdocument.SetCellValue(celdaxls, registro4.numeroventasxformatodistribucion);
            //}

            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }
    }
}