using DocumentFormat.OpenXml.Spreadsheet;
using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.TableModel;
using IrisUNAL.Api.Models.UGI;
using Npgsql;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories.UGI
{
    public class UGI_SemestreRepository : SuperType<UGI_Semestre>
    {
        private ApplicationDbContext _context;

        public UGI_SemestreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public UGI_SemestreRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<UGI_Semestre> GetAllUGI_Semestre()
        {
            return Get();
        }

        public UGI_Semestre GetUGI_SemestreDetails(int id_ugisemestre)
        {
            return Get(id_ugisemestre);
        }
        public bool InsertUGI_Semestre(UGI_Semestre uGI_Semestre)
        {
            Add(uGI_Semestre);
            return true;
        }
        public bool UpdateUGI_Semestre(UGI_Semestre uGI_Semestre)
        {
            Update(uGI_Semestre);
            return true;
        }
        public bool DeleteUGI_Semestre(int id_ugisemestre)
        {
            Delete(id_ugisemestre);
            return true;
        }
        public DataTableAdapter<UGI_Semestre> GetDataTableUGI_Semestre(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<UGI_Semestre, DateTime>> orderByDateFunc = null;
            Expression<Func<UGI_Semestre, bool>> srchByFunc = null;
            Expression<Func<UGI_Semestre, string>> orderByFunc = null;
            Expression<Func<UGI_Semestre, int>> orderByIntFunc = null;

            Expression<Func<UGI_Semestre, object>> parameter1 = d => d.Objsemestre;


            Expression<Func<UGI_Semestre, object>>[] parameterArray = new Expression<Func<UGI_Semestre, object>>[] { parameter1, };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.numresolucion.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            if (model.SortColumn.ToLower() == "fecresolucion")
                orderByDateFunc = CreateExpressionOrderByDate<UGI_Semestre>("fecresolucion");
            else

            if (model.SortColumn == "id_ugisemestre")
            {
                orderByIntFunc = CreateExpressionOrderByInt<UGI_Semestre>(model.SortColumn);
            }
            else
            {
                orderByFunc = CreateExpressionOrderBy<UGI_Semestre>(model.SortColumn);
            }

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            List<UGI_Semestre> data = null;
            if (model.SortColumn.ToLower() == "fecresolucion")
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList();
            else
            if (model.SortColumn == "id_ugisemestre")
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();
            }
            else
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            }

            //**** TOTAL PROYECTADO
            var valoraportado = (from cs in _context.ugi_conceptosemestre
                                     //where cs.id_ugisemestre == id_ugisemestre
                                 group cs by cs.id_ugisemestre into dt
                                 select new
                                 {
                                     valortotalizado = dt.Sum(x => x.valorproyectado),
                                     idugisemestre = dt.Key
                                 }).ToList();

            foreach (var literal in data)
            {
                var objtotal = valoraportado.Find(x => x.idugisemestre == literal.id_ugisemestre);

                if (objtotal != null)
                {
                    literal.valortotalsemestre = objtotal.valortotalizado;
                }
            }

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<UGI_Semestre> result = new DataTableAdapter<UGI_Semestre>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }
        public string ExcelUGI_Semestre(int id_ugisemestre)
        {
            var archivoreturn = "/Export/UGISEGUIMIENTO_" + id_ugisemestre.ToString() + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/UGISEGUIMIENTO_" + id_ugisemestre.ToString() + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/UGI_SEGUIMIENTO.xlsx");

            SLDocument xlsdocument = new SLDocument(plantilla);
            string qry = "select cs.id_ugiconceptosemestre, us.numresolucion, us.fecresolucion, sm.nmsemestre, lu.nmliteral, lu.grupoproducto, " +
                            "cu.concepto, cs.valorproyectado, cs.observaciones " +
                            "from ugi_conceptosemestre cs " +
                            "join ugi_literalsemestre ls on cs.id_ugiliteralsemestre = ls.id_ugiliteralsemestre " +
                            "left join ugi_semestre us on ls.id_ugisemestre = us.id_ugisemestre " +
                            "left join semestre sm on us.id_semestre = sm.id_semestre " +
                            "left join concepto_ugi cu on cs.id_conceptougi = cu.id_conceptougi " +
                            "left join literal_ugi lu on ls.id_literal = lu.id_literal " +
                            "where cs.id_ugisemestre = @id_ugisemestre order by lu.nmliteral";

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();

            parameterList.Add(new NpgsqlParameter("@id_ugisemestre", id_ugisemestre));

            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<UGI_SemestreDTO>(qry, Param).ToList();

            int filaxls = 12;

            int filavalor = 3;

            string celdaxls = "";

            SLStyle style = xlsdocument.CreateStyle();
            SLStyle styleizquierdo = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            SLStyle styleTitle = xlsdocument.CreateStyle();
            SLStyle styleSeparacion = xlsdocument.CreateStyle();
            SLStyle styleRellenoLiteral = xlsdocument.CreateStyle();
            SLStyle styleAdjTexto = xlsdocument.CreateStyle();

            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            styleizquierdo.Alignment.Horizontal = HorizontalAlignmentValues.Left;
            styleizquierdo.Alignment.Vertical = VerticalAlignmentValues.Center;
            styleBack.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(146, 208, 80), System.Drawing.Color.Blue);
            styleTitle.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(255, 255, 0), System.Drawing.Color.Blue);
            styleSeparacion.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(0, 0, 0), System.Drawing.Color.Blue);
            styleRellenoLiteral.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(191, 191, 191), System.Drawing.Color.Blue);
            styleAdjTexto.SetWrapText(true);

            foreach (var campos in datos)
            {

                xlsdocument.SetCellValue(1, 3, "Número de Resolución:");
                xlsdocument.SetCellValue(1, 5, campos.numresolucion);
                xlsdocument.SetCellValue(1, 6, "Fecha Resolución:");
                xlsdocument.SetCellValue(1, 8, campos.fecresolucion.ToString("yyy-mm-dd"));
                xlsdocument.SetCellStyle(1, 8, styleTitle);
                xlsdocument.SetCellValue(2, 3, "EJECUCIÓN UGI " + campos.nmsemestre);
                xlsdocument.SetCellValue(3, 3, "VALOR TOTAL PARA EL SEMESTRE");
                xlsdocument.SetCellValue(4, 3, "VALOR EJECUTADO EN FICHAS QUIPU");
                xlsdocument.SetCellValue(5, 3, "DISPONIBILIDAD ");
                xlsdocument.SetCellValue(8, 3, "EJECUTADO DE LAS FICHAS QUIPU ");
                xlsdocument.SetCellValue(9, 3, "DISTRIBUIR ");
                xlsdocument.SetCellValue(10, 1, "LITERAL");
                xlsdocument.SetCellStyle(10, 1, styleTitle);
                xlsdocument.SetCellValue(10, 3, "CONCEPTO");
                xlsdocument.SetCellStyle(10, 3, styleTitle);
                xlsdocument.SetCellValue(10, 4, "VALOR PROYECTADO");
                xlsdocument.SetCellStyle(10, 4, styleTitle);
                xlsdocument.SetCellValue(10, 5, "OBSERVACIÓN");
                xlsdocument.SetCellStyle(10, 5, styleTitle);
                xlsdocument.SetCellValue(10, 6, "VALOR TOTAL DEL LITERAL");
                xlsdocument.SetCellStyle(10, 6, styleTitle);
                xlsdocument.SetCellValue(11, 7, "CÓDIGO DE CONVOCATORIA ");
                xlsdocument.SetCellStyle(11, 7, styleTitle);
                xlsdocument.SetCellValue(11, 9, "No PROYECTOS ");
                xlsdocument.SetCellStyle(11, 9, styleTitle);
                xlsdocument.SetCellValue(10, 7, "EJECUCIÓN LITERAL ");
                xlsdocument.SetCellStyle(10, 7, styleTitle);
                xlsdocument.SetCellValue(11, 10, "AREA DE PROYECTO ");
                xlsdocument.SetCellStyle(11, 10, styleTitle);
                xlsdocument.SetCellValue(12, 10, "CIENCIA POLÍTICA ");
                xlsdocument.SetCellStyle(12, 10, styleTitle);
                xlsdocument.SetCellValue(12, 11, "DERECHO");
                xlsdocument.SetCellStyle(12, 11, styleTitle);
                xlsdocument.SetCellValue(11, 12, "VALOR");
                xlsdocument.SetCellStyle(11, 12, styleTitle);
                xlsdocument.SetCellValue(11, 13, "CONCEPTO");
                xlsdocument.SetCellStyle(11, 13, styleTitle);
                xlsdocument.SetCellValue(11, 14, "EJECUTADO EN FICHAS");
                xlsdocument.SetCellStyle(11, 14, styleTitle);
                xlsdocument.SetCellValue(10, 15, "TOTAL EJECUTADO DEL LITERAL");
                xlsdocument.SetCellStyle(10, 15, styleTitle);
                xlsdocument.SetCellValue(10, 16, "DISPONIBILIDAD DEL LITERAL // REDISTRIBUCIÓN");
                xlsdocument.SetCellStyle(10, 16, styleTitle);

            }

            int filainicialiteral = 0;
            string literalactual = "";
            decimal valorliteral = 0;
            decimal valortotal = 0;



            if (datos != null)
            {
                literalactual = datos[0].nmliteral;
                filainicialiteral = filaxls + 1;

                xlsdocument.SetCellValue(filainicialiteral, 1, datos[0].nmliteral);
                xlsdocument.SetCellValue(filainicialiteral, 2, datos[0].grupoproducto);
                valorliteral = 0;

                foreach (var registro in datos)
                {
                    if (literalactual != registro.nmliteral)
                    {
                        xlsdocument.SetCellValueNumeric(filainicialiteral, 6, valorliteral.ToString());
                        xlsdocument.MergeWorksheetCells(filainicialiteral, 1, filaxls, 1);
                        xlsdocument.SetCellStyle(filainicialiteral, 1, styleRellenoLiteral);
                        xlsdocument.SetCellStyle(filainicialiteral, 1, filaxls, 1, style);

                        xlsdocument.MergeWorksheetCells(filainicialiteral, 2, filaxls, 2);
                        xlsdocument.SetCellStyle(filainicialiteral, 2, styleAdjTexto);
                        xlsdocument.SetCellStyle(filainicialiteral, 2, styleRellenoLiteral);

                        xlsdocument.MergeWorksheetCells(filainicialiteral, 6, filaxls, 6);
                        filaxls += 1;
                        xlsdocument.InsertRow(filaxls, 1);
                        xlsdocument.MergeWorksheetCells(filaxls, 1, filaxls, 16);

                        xlsdocument.SetCellStyle(filaxls, 1, styleSeparacion);

                        literalactual = registro.nmliteral;
                        filainicialiteral = filaxls + 1;

                        xlsdocument.SetCellValue(filainicialiteral, 1, registro.nmliteral);
                        xlsdocument.SetCellValue(filainicialiteral, 2, registro.grupoproducto);

                        //desde aquí se hace la suma para cuando hay más literales (solo la linea)
                        valortotal += valorliteral;

                        valorliteral = 0;


                    }

                    filaxls += 1;
                    celdaxls = "C" + filaxls.ToString();
                    xlsdocument.SetCellValue(celdaxls, registro.concepto);
                    xlsdocument.SetCellStyle(filainicialiteral, 3, filaxls, 3, styleizquierdo);
                    celdaxls = "D" + filaxls.ToString();
                    xlsdocument.SetCellValueNumeric(celdaxls, registro.valorproyectado.ToString());
                    xlsdocument.SetCellStyle(filainicialiteral, 4, filaxls, 4, style);
                    celdaxls = "E" + filaxls.ToString();
                    xlsdocument.SetCellValue(celdaxls, registro.observaciones);
                    xlsdocument.SetCellStyle(filainicialiteral, 5, filaxls, 5, styleizquierdo);
                    valorliteral += (int)registro.valorproyectado;
                    xlsdocument.SetCellStyle(filainicialiteral, 6, filaxls, 6, style);


                }
                //aquí se agrega la misma suma pero también se muestra en el excel
                valortotal += valorliteral;
                celdaxls = "F" + filavalor.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, valortotal.ToString());




                xlsdocument.SetCellValueNumeric(filainicialiteral, 6, valorliteral.ToString());
                xlsdocument.MergeWorksheetCells(filainicialiteral, 1, filaxls, 1);
                xlsdocument.SetCellStyle(filainicialiteral, 1, styleRellenoLiteral);
                xlsdocument.SetCellStyle(filainicialiteral, 1, filaxls, 1, style);
                xlsdocument.MergeWorksheetCells(filainicialiteral, 2, filaxls, 2);
                xlsdocument.SetCellStyle(filainicialiteral, 2, styleAdjTexto);
                xlsdocument.SetCellStyle(filainicialiteral, 2, styleRellenoLiteral);
                xlsdocument.MergeWorksheetCells(filainicialiteral, 6, filaxls, 6);
            }

            xlsdocument.SaveAs(archivo);
            return archivoreturn;

        }
    }
}