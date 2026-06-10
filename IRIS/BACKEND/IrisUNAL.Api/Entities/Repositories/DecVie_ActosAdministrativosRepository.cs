using DocumentFormat.OpenXml.Spreadsheet;
using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
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
    public class DecVie_ActosAdministrativosRepository : SuperType<DecVie_ActosAdministrativos>, IDecVie_ActosAdministrativosRepository
    {
        private ApplicationDbContext _context;

        public DecVie_ActosAdministrativosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_ActosAdministrativosRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_ActosAdministrativos(int id_actoadministrativo)
        {
            Delete(id_actoadministrativo);
            return true;
        }

        public IEnumerable<DecVie_ActosAdministrativos> GetAllDecVie_ActosAdministrativos()
        {
            return Get();
        }

        public DecVie_ActosAdministrativos GetDecVie_ActosAdministrativosConsecutivo(string cd_consecutivoactoadministrativo)
        {
            return Get(c => c.consecutivoactoadministrativo == cd_consecutivoactoadministrativo).FirstOrDefault();
        }

        public DecVie_ActosAdministrativos GetDecVie_ActosAdministrativosDetails(int id_actoadministrativo)
        {
            return Get(id_actoadministrativo);
        }

        public bool InsertDecVie_ActosAdministrativos(DecVie_ActosAdministrativos decVie_ActosAdministrativos)
        {
            Add(decVie_ActosAdministrativos);
            return true;
        }

        public bool UpdateDecVie_ActosAdministrativos(DecVie_ActosAdministrativos decVie_ActosAdministrativos)
        {
            Update(decVie_ActosAdministrativos);
            return true;
        }
        public DataTableAdapter<DecVie_ActosAdministrativos> GetDataTableDecVie_ActosAdministrativos(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_ActosAdministrativos, bool>> srchByFunc = null;
            Expression<Func<DecVie_ActosAdministrativos, string>> orderByFunc = null;
            Expression<Func<DecVie_ActosAdministrativos, int>> orderByIntFunc = null;

            Expression<Func<DecVie_ActosAdministrativos, object>> parameter2 = d => d.estadoacto;
            Expression<Func<DecVie_ActosAdministrativos, object>> parameter5 = d => d.dependenciasolicitante;
            Expression<Func<DecVie_ActosAdministrativos, object>> parameter7 = d => d.responsablesolicitud;

            Expression<Func<DecVie_ActosAdministrativos, object>>[] parameterArray = new Expression<Func<DecVie_ActosAdministrativos, object>>[] { parameter2, parameter5, parameter7, };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.consecutivoactoadministrativo.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            if (model.SortColumn == "id_actoadministrativo")
            {
                orderByIntFunc = CreateExpressionOrderByInt<DecVie_ActosAdministrativos>(model.SortColumn);
            }
            else 
            {
                orderByFunc = CreateExpressionOrderBy<DecVie_ActosAdministrativos>(model.SortColumn);
            }            

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            List<DecVie_ActosAdministrativos> data = null;

            if (model.SortColumn == "id_actoadministrativo")
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();
            }
            else
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            }
            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_ActosAdministrativos> result = new DataTableAdapter<DecVie_ActosAdministrativos>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public string ExcelDecVie_ActosAdministrativos()
        {
            var archivoreturn = "/Export/ACTOSADMINISTRATIVOS_"  + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/ACTOSADMINISTRATIVOS_" + ".xlsx");

            SLDocument xlsdocument = new SLDocument();
            string qry = "select ad.id_actoadministrativo, fechaexpedicion, nmidtipoactoadministrativo, consecutivoactoadministrativo, conconceptoasunto, nmdecvietipologia, " +
            "nmdecviemacroproceso, dp.nmdepend, beneficiario, df.nmdepend dependenciafirma, nombrecompleto, ad.numidentificacion, nmestadoactoadministrativo, dependenciadocumento " + 
            "from decvie_actosadministrativos ad " +
            "join DecVie_ActosAdministrativosTipo taa on ad.id_tipoactoadministrativo = taa.id_tipoactoadministrativo " +
            "join DecVie_Tipologia tp on ad.id_decvietipologia = tp.id_decvietipologia " +
            "join DecVie_Macroproceso mp on ad.id_decviemacroproceso = mp.id_decviemacroproceso " +
            "join dependencia dp on ad.id_depend = dp.id_depend " +
            //"left join dependencia df on cast(ad.dependenciafirma as int) = df.id_depend " +
            "left join dependencia df on ad.dependenciafirma = df.id_depend " +            
            "join persona pr on ad.id_persona = pr.id_persona " +
            "join DecVie_ActosAdministrativosEstado es on ad.id_estadoactoadministrativo = es.id_estadoactoadministrativo";

            var datos = _context.Database.SqlQuery<DecVie_ActosAdministrativosDTO>(qry).ToList();

            int filaxls = 4;
            
            string celdaxls = "";
            
            SLStyle style = xlsdocument.CreateStyle();
            SLStyle styleBack = xlsdocument.CreateStyle();
            SLStyle styleTitle = xlsdocument.CreateStyle();
           
            
            style.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            style.Alignment.Vertical = VerticalAlignmentValues.Center;
            styleBack.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(146, 208, 80), System.Drawing.Color.Blue);
            styleTitle.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(255, 255, 0), System.Drawing.Color.Blue);
            

            xlsdocument.SetCellValue(3, 2, "ACTOS ADMINISTRATIVOS");
            xlsdocument.SetCellStyle(3, 2, style);
            xlsdocument.SetCellStyle(3, 2, styleBack);
            xlsdocument.MergeWorksheetCells(3, 2, 3, 14);
            xlsdocument.SetCellValue(4, 2, "Fecha de expedición de acto  administrativo");
            xlsdocument.SetCellStyle(4, 2, style);
            xlsdocument.SetCellStyle(4, 2, styleTitle);
            xlsdocument.SetColumnWidth(2, 40);
            xlsdocument.SetCellValue(4, 3, "Tipo de acto Administrativo");
            xlsdocument.SetCellStyle(4, 3, style);
            xlsdocument.SetCellStyle(4, 3, styleTitle);
            xlsdocument.SetColumnWidth(3, 25);
            xlsdocument.SetCellValue(4, 4, "No Consecutivo del acto Administrativo");
            xlsdocument.SetCellStyle(4, 4, style);
            xlsdocument.SetCellStyle(4, 4, styleTitle);
            xlsdocument.SetColumnWidth(4, 36);
            xlsdocument.SetCellValue(4, 5, "Conconcepto / asunto");
            xlsdocument.SetCellStyle(4, 5, style);
            xlsdocument.SetCellStyle(4, 5, styleTitle);
            xlsdocument.SetColumnWidth(5, 121);
            xlsdocument.SetCellValue(4, 6, "Tipología ");
            xlsdocument.SetCellStyle(4, 6, style);
            xlsdocument.SetCellStyle(4, 6, styleTitle);
            xlsdocument.SetColumnWidth(6, 10);
            xlsdocument.SetCellValue(4, 7, "Macroproceso");
            xlsdocument.SetCellStyle(4, 7, style);
            xlsdocument.SetCellStyle(4, 7, styleTitle);
            xlsdocument.SetColumnWidth(7, 13);
            xlsdocument.SetCellValue(4, 8, "Dependencia Solicitante");
            xlsdocument.SetCellStyle(4, 8, style);
            xlsdocument.SetCellStyle(4, 8, styleTitle);
            xlsdocument.SetColumnWidth(8, 23);
            xlsdocument.SetCellValue(4, 9, "Responsable (persona) de la solicitud");
            xlsdocument.SetCellStyle(4, 9, style);
            xlsdocument.SetCellStyle(4, 9, styleTitle);
            xlsdocument.SetColumnWidth(9, 34);
            xlsdocument.SetCellValue(4, 10, "Dependencia que expide (firma)  el acto administrativo");
            xlsdocument.SetCellStyle(4, 10, style);
            xlsdocument.SetCellStyle(4, 10, styleTitle);
            xlsdocument.SetColumnWidth(10, 50);
            xlsdocument.SetCellValue(4, 11, "Nombre del benficiario directo (si aplica)");
            xlsdocument.SetCellStyle(4, 11, style);
            xlsdocument.SetCellStyle(4, 11, styleTitle);
            xlsdocument.SetColumnWidth(11, 38);
            xlsdocument.SetCellValue(4, 12, "Identificación del benificiario directo  al que impacta el acto administrativo");
            xlsdocument.SetCellStyle(4, 12, style);
            xlsdocument.SetCellStyle(4, 12, styleTitle);
            xlsdocument.SetColumnWidth(12, 34);
            xlsdocument.SetCellValue(4, 13, "Estado del proceso");
            xlsdocument.SetCellStyle(4, 13, style);
            xlsdocument.SetCellStyle(4, 13, styleTitle);
            xlsdocument.SetColumnWidth(13, 17);
            xlsdocument.SetCellValue(4, 14, "dependencia donde reposa el documento");
            xlsdocument.SetCellStyle(4, 14, style);
            xlsdocument.SetCellStyle(4, 14, styleTitle);
            xlsdocument.SetColumnWidth(14, 22);

            if (datos != null)
            {
                
                foreach (var registro in datos)
                {
                    filaxls += 1;

                    celdaxls = "B" + filaxls.ToString();
                    if (registro.fechaexpedicion != null)
                    {
                        DateTime fechaexpedicion = (DateTime)registro.fechaexpedicion;
                        xlsdocument.SetCellValue(celdaxls, fechaexpedicion.ToString("yyy-MM-dd"));
                    }
                    celdaxls = "C" + filaxls.ToString();
                    xlsdocument.SetCellValue(celdaxls, registro.nmidtipoactoadministrativo);
                    celdaxls = "D" + filaxls.ToString();
                    xlsdocument.SetCellValue(celdaxls, registro.consecutivoactoadministrativo);
                    celdaxls = "E" + filaxls.ToString();
                    xlsdocument.SetCellValue(celdaxls, registro.conconceptoasunto);
                    celdaxls = "F" + filaxls.ToString();
                    xlsdocument.SetCellValue(celdaxls, registro.nmdecvietipologia);
                    celdaxls = "G" + filaxls.ToString();
                    xlsdocument.SetCellValue(celdaxls, registro.nmdecviemacroproceso);
                    celdaxls = "H" + filaxls.ToString();
                    xlsdocument.SetCellValue(celdaxls, registro.nmdepend);
                    celdaxls = "I" + filaxls.ToString();
                    xlsdocument.SetCellValue(celdaxls, registro.nombrecompleto);
                    celdaxls = "J" + filaxls.ToString();
                    xlsdocument.SetCellValue(celdaxls, registro.dependenciafirma);
                    celdaxls = "K" + filaxls.ToString();
                    xlsdocument.SetCellValue(celdaxls, registro.beneficiario);
                    celdaxls = "L" + filaxls.ToString();
                    xlsdocument.SetCellValue(celdaxls, registro.numidentificacion);
                    celdaxls = "M" + filaxls.ToString();
                    xlsdocument.SetCellValue(celdaxls, registro.nmestadoactoadministrativo);
                    celdaxls = "N" + filaxls.ToString();
                    xlsdocument.SetCellValue(celdaxls, registro.dependenciadocumento);

                }


            }

            xlsdocument.SaveAs(archivo);
            return archivoreturn;

        }


    }
}