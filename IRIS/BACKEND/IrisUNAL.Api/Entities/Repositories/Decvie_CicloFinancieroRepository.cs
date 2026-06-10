using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.TableModel;
using IrisUNAL.Api.Utilities;
using Npgsql;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Decvie_CicloFinancieroRepository : SuperType<Decvie_CicloFinanciero>
    {
        private ApplicationDbContext _context;

        public Decvie_CicloFinancieroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Decvie_CicloFinancieroRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Decvie_CicloFinanciero> GetAllDecvie_CicloFinanciero()
        {
            return Get();
        }

        public Decvie_CicloFinanciero GetDecvie_CicloFinancieroDetails(int id_ciclofinanciero)
        {
            return Get(id_ciclofinanciero);
        }

        public bool InsertDecvie_CicloFinanciero(Decvie_CicloFinanciero decvie_CicloFinanciero )
        {
            Add(decvie_CicloFinanciero);
            return true;
        }

        public bool UpdateDecvie_CicloFinanciero(Decvie_CicloFinanciero decvie_CicloFinanciero)
        {
            Update(decvie_CicloFinanciero);
            return true;
        }

        public bool DeleteDecvie_CicloFinanciero(int id_ciclofinanciero)
        {
            Delete(id_ciclofinanciero);
            return true;
        }

        public DataTableAdapter<Decvie_CicloFinanciero> GetDataTableDecvie_CicloFinanciero(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;
                        
            Expression<Func<Decvie_CicloFinanciero, bool>> srchByFunc = null;
            Expression<Func<Decvie_CicloFinanciero, string>> orderByFunc = null;
            Expression<Func<Decvie_CicloFinanciero, int>> orderByIntFunc = null;

            Expression<Func<Decvie_CicloFinanciero, object>> parameter2 = d => d.Objsemestre;               
            Expression<Func<Decvie_CicloFinanciero, object>>[] parameterArray = new Expression<Func<Decvie_CicloFinanciero, object>>[] { parameter2, };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.observaciones.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;
                        

            if (model.SortColumn == "id_ciclofinanciero")
            {
                orderByIntFunc = CreateExpressionOrderByInt<Decvie_CicloFinanciero>(model.SortColumn);
            }
            else
            {
                orderByFunc = CreateExpressionOrderBy<Decvie_CicloFinanciero>(model.SortColumn);
            }

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            List<Decvie_CicloFinanciero> data = null;
            
            if (model.SortColumn == "id_ciclofinanciero")
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();
            }
            else
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            }
            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_CicloFinanciero> result = new DataTableAdapter<Decvie_CicloFinanciero>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public DataTableAdapter<Decvie_CicloFinanciero> GetDataTableDecvie_CicloFinancieroBySemestre( int id_ciclofinanciero, DataTableRequest model)
        {
            var totalRows = 0; //Count();
            var RowsFiltered = totalRows;

            Expression<Func<Decvie_CicloFinanciero, bool>> srchByFunc = null;
            Expression<Func<Decvie_CicloFinanciero, string>> orderByFunc = null;
            Expression<Func<Decvie_CicloFinanciero, object>> parameter1 = p => p.Objsemestre;
            
            Expression<Func<Decvie_CicloFinanciero, object>>[] parameterArray = new Expression<Func<Decvie_CicloFinanciero, object>>[] { parameter1, };
            bool isOrderDesc = false;

            //FILTRA POR DEPENDENCIA
            srchByFunc = d => d.id_ciclofinanciero == id_ciclofinanciero;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_ciclofinanciero == id_ciclofinanciero && d.NombreSemestre.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Decvie_CicloFinanciero>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_CicloFinanciero> result = new DataTableAdapter<Decvie_CicloFinanciero>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public string ExcelDecvie_CicloFinanciero(int id_ciclofinanciero)
        {
            var archivoreturn = "/Export/CicloFinancieroPosgrado_" + id_ciclofinanciero.ToString() + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/CicloFinancieroPosgrado_" + id_ciclofinanciero.ToString() + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/CICLO_FINANCIERO_POSGRADO.xlsx");

            SLDocument xlsdocument = new SLDocument(plantilla);
            string qry = "select fp.id_programapostgrado,nmprogramapostgrado,tipoprograma,nmsemestre," +
                "coalesce(costosemprog,0) costosemprog, coalesce(cupos,0) cupos, coalesce(inscritos,0) inscritos, coalesce(admitidos,0) admitidos, coalesce(matriculados,0) matriculados, " +
                "coalesce(aplazados,0) aplazados, coalesce(numestudiantes,0) numestudiantes, coalesce(porcentaje,0) porcentaje, coalesce(valor,0) valor, coalesce(costosemconvenio,0) costosemconvenio, " +
                "coalesce(cuposconvenio,0) cuposconvenio, coalesce(inscritosconvenio,0) inscritosconvenio, coalesce(admitidosconvenio,0) admitidosconvenio, coalesce(matriculadosconvenio,0) matriculadosconvenio, " +
                "coalesce(aplazadosconvenio,0) aplazadosconvenio, coalesce(numestudiantesconvenio,0) numestudiantesconvenio, coalesce(porcentajeconvenio,0) porcentajeconvenio, coalesce(valorconvenio,0) valorconvenio, " +
                "coalesce(graduadosbogota,0) graduadosbogota, coalesce(graduadosconvenio,0) graduadosconvenio, coalesce(recaudobogota,0) recaudobogota, coalesce(recaudoconvenio,0) recaudoconvenio, " +
                "coalesce(porcentajeugi,0) porcentajeugi, coalesce(porcentajederadmtvos,0) porcentajederadmtvos, facultaddsps, coalesce(total,0) total, " +
                "coalesce(porcentajeugiconvenio,0) porcentajeugiconvenio, coalesce(porcentajederadmtvosconvenio,0) porcentajederadmtvosconvenio, coalesce(trasladoistconvenio,0) trasladoistconvenio, facultaddspsconvenio " +
                "from decvie_ciclofinancieropostprogram fp " +
                "join decvie_ciclofinancieroprogramapostgrado pp on fp.id_programapostgrado = pp.id_programapostgrado " +
                "join decvie_ciclofinanciero cf on fp.id_ciclofinanciero = cf.id_ciclofinanciero " +
                "join semestre sm on cf.id_semestre = sm.id_semestre " +
                "where fp.id_ciclofinanciero = @id_ciclofinanciero ";

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@id_ciclofinanciero", id_ciclofinanciero));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<CicloFinancieroPosgradoDTO>(qry, Param).ToList();

            int filaxls = 7;
            string celdaxls = "";

            SLStyle styleEsp = xlsdocument.CreateStyle();
            SLStyle styleMag = xlsdocument.CreateStyle();
            SLStyle styleDoc = xlsdocument.CreateStyle();
            SLStyle styleEspT = xlsdocument.CreateStyle();
            SLStyle styleMagT = xlsdocument.CreateStyle();
            SLStyle styleDocT = xlsdocument.CreateStyle();

            styleEsp.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, Color.FromArgb(197,90,17), System.Drawing.Color.Blue);
            styleMag.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, Color.FromArgb(0, 176, 80), System.Drawing.Color.Blue);
            styleDoc.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, Color.FromArgb(0, 176, 240), System.Drawing.Color.Blue);

            styleEspT.SetFontColor(Color.FromArgb(197, 90, 17));
            styleMagT.SetFontColor(Color.FromArgb(0, 176, 80));
            styleDocT.SetFontColor(Color.FromArgb(0, 176, 240));

            foreach (var registro in datos)
            {
                filaxls += 1;
                celdaxls = "b" + filaxls.ToString();

                var tipoprog = registro.tipoprograma.Substring(0, 1);

                switch (tipoprog)
                {
                    case "E":
                        xlsdocument.SetCellStyle(filaxls, 2, styleEsp);
                        xlsdocument.SetCellStyle(filaxls, 5, styleEspT);
                        break;
                    case "M":
                        xlsdocument.SetCellStyle(filaxls, 3, styleMag);
                        xlsdocument.SetCellStyle(filaxls, 5, styleMagT);
                        break;
                    case "D":
                        xlsdocument.SetCellStyle(filaxls, 4, styleDoc);
                        xlsdocument.SetCellStyle(filaxls, 5, styleDocT);
                        break;
                }

                xlsdocument.SetCellValue(6, 2, registro.nmsemestre);
                celdaxls = "E" + filaxls.ToString();                
                xlsdocument.SetCellValue(celdaxls, registro.nmprogramapostgrado);
                celdaxls = "f" + filaxls.ToString();                
                xlsdocument.SetCellValueNumeric(celdaxls, registro.costosemprog.ToString());
                celdaxls = "g" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.cupos.ToString());
                celdaxls = "h" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.inscritos.ToString());
                celdaxls = "i" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.admitidos.ToString());
                celdaxls = "j" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.matriculados.ToString());
                celdaxls = "k" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.aplazados.ToString());
                celdaxls = "l" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.numestudiantes.ToString());
                celdaxls = "m" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.porcentaje.ToString());
                celdaxls = "n" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.valor.ToString());
                celdaxls = "o" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.costosemconvenio.ToString());
                celdaxls = "p" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.cuposconvenio.ToString());
                celdaxls = "q" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.inscritosconvenio.ToString());
                celdaxls = "r" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.admitidosconvenio.ToString());
                celdaxls = "s" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.matriculadosconvenio.ToString());
                celdaxls = "t" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.aplazadosconvenio.ToString());
                celdaxls = "u" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.numestudiantesconvenio.ToString());
                celdaxls = "v" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.porcentajeconvenio.ToString());
                celdaxls = "w" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.valorconvenio.ToString());
                celdaxls = "x" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.graduadosbogota.ToString());
                celdaxls = "y" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.graduadosconvenio.ToString());
                celdaxls = "z" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.recaudobogota.ToString());
                celdaxls = "aa" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.recaudoconvenio.ToString());
                celdaxls = "ab" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.porcentajeugi.ToString());
                celdaxls = "ac" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.porcentajederadmtvos.ToString());
                celdaxls = "ad" + filaxls.ToString();
                xlsdocument.SetCellValue(celdaxls, registro.facultaddsps);
                celdaxls = "ae" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.total.ToString());
                celdaxls = "af" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.porcentajeconvenio.ToString());
                celdaxls = "ag" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.porcentajederadmtvosconvenio.ToString());
                celdaxls = "ah" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.trasladoistconvenio.ToString());
                celdaxls = "ai" + filaxls.ToString();
                xlsdocument.SetCellValue(celdaxls, registro.facultaddspsconvenio);
            }

            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }

    }
}