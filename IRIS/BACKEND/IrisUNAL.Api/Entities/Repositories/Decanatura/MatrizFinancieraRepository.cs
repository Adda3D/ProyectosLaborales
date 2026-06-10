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

namespace IrisUNAL.Api.Entities.Repositories.Decanatura
{
    public class MatrizFinancieraRepository : SuperType<MatrizFinanciera>
    {
        private ApplicationDbContext _context;

        public MatrizFinancieraRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public MatrizFinancieraRepository()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<MatrizFinanciera> GetAllMatrizFinanciera()
        {
            return Get();
        }
        public MatrizFinanciera GetMatrizFinancieraDetails(int id_matrizfinanciera)
        {
            return Get(id_matrizfinanciera);
        }
        public bool InsertMatrizFinanciera(MatrizFinanciera matrizFinanciera)
        {
            Add(matrizFinanciera);
            return true;
        }
        public bool UpdateMatrizFinanciera(MatrizFinanciera matrizFinanciera)
        {
            Update(matrizFinanciera);
            return true;
        }
        public bool DeleteMatrizFinanciera(int id_matrizfinanciera)
        {
            Delete(id_matrizfinanciera);
            return true;
        }
        public DataTableAdapter<MatrizFinanciera> GetDataTableMatrizFinanciera(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;
            
            Expression<Func<MatrizFinanciera, bool>> srchByFunc = null;
            Expression<Func<MatrizFinanciera, string>> orderByFunc = null;
            Expression<Func<MatrizFinanciera, int>> orderByIntFunc = null;

            Expression<Func<MatrizFinanciera, object>> parameter1 = d => d.Objvigencia;
            Expression<Func<MatrizFinanciera, object>> parameter2 = d => d.Objdependencia;

            Expression<Func<MatrizFinanciera, object>>[] parameterArray = new Expression<Func<MatrizFinanciera, object>>[] { parameter1, parameter2, };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.Objvigencia.nmvigencia.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            if (model.SortColumn == "id_matrizfinanciera")
            {
                orderByIntFunc = CreateExpressionOrderByInt<MatrizFinanciera>(model.SortColumn);
            }
            else
            {
                orderByFunc = CreateExpressionOrderBy<MatrizFinanciera>(model.SortColumn);
            }

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            List<MatrizFinanciera> data = null;
            
            if (model.SortColumn == "id_matrizfinanciera")
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();
            }
            else
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            }
            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<MatrizFinanciera> result = new DataTableAdapter<MatrizFinanciera>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
  
        }
        public string ExcelMatrizFinanciera(int id_matrizfinanciera)
        {
            var archivoreturn = "/Export/MATRIZFINANCIERAGENERAL_" + id_matrizfinanciera.ToString() + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/MATRIZFINANCIERAGENERAL_" + id_matrizfinanciera.ToString() + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/MATRIZ_FINANCIERA_GENERAL.xlsx");

            SLDocument xlsdocument = new SLDocument(plantilla);
            string qry = "select mf.id_matrizfinanciera, nmvigencia, coalesce(presupuestogeneral, 0) presupuestogeneral, coalesce(presupuestogeneralcomprometido, 0) presupuestogeneralcomprometido, " +
                            "coalesce(presupuestogeneralcomprometer, 0)presupuestogeneralcomprometer, coalesce(presupuestougi, 0) presupuestougi, coalesce(presupuestougicomprometido, 0) presupuestougicomprometido, " +
                            "coalesce(presupuestougicomprometer, 0) presupuestougicomprometer, coalesce(presupuestoestudiantes, 0) presupuestoestudiantes, " +
                            "coalesce(presupuestoestudiantescomprometido, 0) presupuestoestudiantescomprometido, coalesce(presupuestoestudiantescomprometer, 0) presupuestoestudiantescomprometer " +
                            "from matrizfinanciera mf " +
                            "join matrizfinanciera_vigencia fv on mf.id_vigencia = fv.id_vigencia " +
                           // "join dependencia dp on mf.id_depend = dp.id_depend " +
                            "where mf.id_matrizfinanciera = @id_matrizfinanciera ";

              string qry2 = "select ga.id_gastoapoyo, nmdepend, ga.id_matrizfinanciera, coalesce(especializado, 0) especializado, coalesce(profesional, 0) profesional, coalesce(tecnico, 0) tecnico, " +
                              "coalesce(asistencial, 0) asistencial, coalesce(totalpersonascontratadas, 0) totalpersonascontratadas, coalesce(valortotal, 0) valortotal, observaciones " +
                              "from matrizfinanciera_gastoapoyo ga " +
                              "join dependencia df on ga.id_depend = df.id_depend " +
                              "join matrizfinanciera va on ga.id_matrizfinanciera = va.id_matrizfinanciera " +
                              "where va.id_matrizfinanciera = @id_matrizfinanciera ";

              string qry3 = "select fo.id_gastooperativo, nmtipooperativo, nmdepend, fo.id_matrizfinanciera, coalesce(totalpersonascontratadas, 0) totalpersonascontratadas, coalesce(valortotal, 0) valortotal, observaciones " +
                              "from matrizfinanciera_gastooperativo fo " +
                              "join matrizfinanciera_tipooperativo op on fo.id_tipooperativo = op.id_tipooperativo " +
                              "join dependencia dg on fo.id_depend = dg.id_depend " +
                              "join matrizfinanciera mo on fo.id_matrizfinanciera = mo.id_matrizfinanciera " +
                              "where mo.id_matrizfinanciera = @id_matrizfinanciera ";

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            List<NpgsqlParameter> parameterList2 = new List<NpgsqlParameter>();
            List<NpgsqlParameter> parameterList3 = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@id_matrizfinanciera", id_matrizfinanciera));
            parameterList2.Add(new NpgsqlParameter("@id_matrizfinanciera", id_matrizfinanciera));
            parameterList3.Add(new NpgsqlParameter("@id_matrizfinanciera", id_matrizfinanciera));
            NpgsqlParameter[] Param = parameterList.ToArray();
            NpgsqlParameter[] Param2 = parameterList2.ToArray();
            NpgsqlParameter[] Param3 = parameterList3.ToArray();


            var datos = _context.Database.SqlQuery<MatrizFinancieraDTO>(qry, Param).ToList();
            var datos2 = _context.Database.SqlQuery<MatrizFinancieraDTO>(qry2, Param2).ToList();
            var datos3 = _context.Database.SqlQuery<MatrizFinancieraDTO>(qry3, Param3).ToList();

            int filaxls = 4;
            int filaxls2 = 13;
            int filaxls3 = 60;
            string celdaxls = "";
            /*
            SLStyle style = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            styleBack.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(146, 208, 80), System.Drawing.Color.Blue);

            xlsdocument.SetCellValue(3, 2, "MATRIZ FINANCIERA");
            xlsdocument.SetCellStyle(3, 2, style);
            xlsdocument.SetCellStyle(3, 2, styleBack);
            xlsdocument.MergeWorksheetCells(3, 2, 4, 8);
            */
            filaxls += 1;

            if (datos != null)
            {
                var registro = datos[0];

                xlsdocument.SetCellValue(5, 2, registro.nmvigencia);
                //xlsdocument.SetCellStyle(5, 2, style);
                //xlsdocument.MergeWorksheetCells(5, 2, 5, 7);

                //xlsdocument.SetCellValue(7, 2, "Presupesto general de regulado proyección anual Apoyo a la gestion OPS)");
                xlsdocument.SetCellValueNumeric(7, 3, registro.presupuestogeneral.ToString());
                //xlsdocument.SetCellValue(7, 4, "Comprometido");
                xlsdocument.SetCellValueNumeric(7, 5, registro.presupuestogeneralcomprometido.ToString());
                //xlsdocument.SetCellValue(7, 6, "Valor por comprometer");
                xlsdocument.SetCellValueNumeric(7, 7, registro.presupuestogeneralcomprometer.ToString());
                //xlsdocument.SetCellValue(8, 2, "Presupuesto general de la Ugi");
                xlsdocument.SetCellValueNumeric(8, 3, registro.presupuestougi.ToString());
                //xlsdocument.SetCellValue(8, 4, "Comprometido");
                xlsdocument.SetCellValueNumeric(8, 5, registro.presupuestougicomprometido.ToString());
                //xlsdocument.SetCellValue(8, 6, "Valor por comprometer");
                xlsdocument.SetCellValueNumeric(8, 7, registro.presupuestougicomprometer.ToString());
                //xlsdocument.SetCellValue(10, 2, "Presupuesto para Vinculación a estudiantes");
                xlsdocument.SetCellValueNumeric(10, 3, registro.presupuestoestudiantes.ToString());
                //xlsdocument.SetCellValue(10, 4, "Comprometido");
                xlsdocument.SetCellValueNumeric(10, 5, registro.presupuestoestudiantescomprometido.ToString());
                //xlsdocument.SetCellValue(10, 6, "Valor por comprometer");
                xlsdocument.SetCellValueNumeric(10, 7, registro.presupuestoestudiantescomprometer.ToString());
            }

            foreach (var registro2 in datos2)
            {                
                celdaxls = "B" + filaxls2.ToString();
                xlsdocument.SetCellValue(celdaxls, registro2.nmdepend);
                celdaxls = "C" + filaxls2.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro2.totalpersonascontratadas.ToString());
                celdaxls = "D" + filaxls2.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro2.valortotal.ToString());
                celdaxls = "E" + filaxls2.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro2.especializado.ToString());                
                celdaxls = "F" + filaxls2.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro2.profesional.ToString());
                celdaxls = "G" + filaxls2.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro2.tecnico.ToString());
                celdaxls = "H" + filaxls2.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro2.asistencial.ToString());                
                celdaxls = "I" + filaxls2.ToString();
                xlsdocument.SetCellValue(celdaxls, registro2.observaciones);

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
                xlsdocument.SetCellValue(celdaxls, registro3.nmtipooperativo);
                celdaxls = "B" + filaxls2.ToString();
                xlsdocument.SetCellValue(celdaxls, registro3.nmdepend);
                celdaxls = "C" + filaxls2.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro3.totalpersonascontratadas.ToString());
                celdaxls = "D" + filaxls2.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro3.valortotal.ToString());
                celdaxls = "E" + filaxls2.ToString();
                xlsdocument.SetCellValue(celdaxls, registro3.observaciones);

            }
          
            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }
    }
}