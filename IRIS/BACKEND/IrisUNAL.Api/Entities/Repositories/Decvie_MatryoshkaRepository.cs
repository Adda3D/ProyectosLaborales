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
    public class Decvie_MatryoshkaRepository : SuperType<Decvie_Matryoshka>
    {
        private ApplicationDbContext _context;

        public Decvie_MatryoshkaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Decvie_MatryoshkaRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Decvie_Matryoshka> GetAllDecvie_Matryoshka()
        {
            return Get();
        }

        public Decvie_Matryoshka GetDecvie_MatryoshkaDetails(int id_matryoska)
        {
            return Get(id_matryoska);
        }

        public bool InsertDecvie_Matryoshka(Decvie_Matryoshka _decvie_matryoshka)
        {
            Add(_decvie_matryoshka);
            return true;
        }

        public bool UpdateDecvie_Matryoshka(Decvie_Matryoshka _decvie_matryoshka)
        {
            Update(_decvie_matryoshka);
            return true;
        }

        public bool DeleteDecvie_Matryoshka(int id_matryoska)
        {
            Delete(id_matryoska);
            return true;
        }

        public DataTableAdapter<Decvie_Matryoshka> GetDataTableDecvie_Matryoshka(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Decvie_Matryoshka, bool>> srchByFunc = null;
            Expression<Func<Decvie_Matryoshka, string>> orderByFunc = null;
            Expression<Func<Decvie_Matryoshka, object>> parameter1 = p => p.ObjDependencia;
            Expression<Func<Decvie_Matryoshka, object>>[] parameterArray = new Expression<Func<Decvie_Matryoshka, object>>[] { parameter1 };
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.alcance.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Decvie_Matryoshka>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_Matryoshka> result = new DataTableAdapter<Decvie_Matryoshka>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public DataTableAdapter<Decvie_Matryoshka> GetDataTableDecvie_MatryoshkaByDependencia(int id_depend, DataTableRequest model)
        {
            var totalRows = 0; //Count();
            var RowsFiltered = totalRows;

            Expression<Func<Decvie_Matryoshka, bool>> srchByFunc = null;
            Expression<Func<Decvie_Matryoshka, string>> orderByFunc = null;
            Expression<Func<Decvie_Matryoshka, object>> parameter1 = p => p.ObjDependencia;
            Expression<Func<Decvie_Matryoshka, object>>[] parameterArray = new Expression<Func<Decvie_Matryoshka, object>>[] { parameter1 };
            bool isOrderDesc = false;

            //FILTRA POR DEPENDENCIA
            srchByFunc = d => d.id_depend == id_depend;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_depend == id_depend && d.alcance.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Decvie_Matryoshka>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Decvie_Matryoshka> result = new DataTableAdapter<Decvie_Matryoshka>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        private List<Decvie_MatryoshkaDTO> DatosEje(int id_matryoska)
        {
            //CARGA LOS DATOS EJE, PROGRAMA, DESCRIPCION DEL PROGRAMA Y ALCANCES
            string qry = "select mk.id_matryoska, alcance, dp.nmdepend, es.ejeestrategico, pp.nmprogramapgd, pp.descripcionprogramapgd " +
                         "from decvie_matryoshka mk " +
                         "join dependencia dp on mk.id_depend = dp.id_depend " +
                         "join decvie_matryoshkaejeestrategico me on mk.id_matryoska = me.id_matryoska " +
                         "join decvie_planaccionejeestrategico es on me.id_ejeestrategico = es.id_ejeestrategico " +
                         "join decvie_matryoshkaprogramapgd mp on mk.id_matryoska = mp.id_matryoska " +
                         "join decvie_planaccionprogramapgd pp on mp.id_programapgd = pp.id_programapgd " +
                         "where mk.id_matryoska = @id_matryoska ";

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@id_matryoska", id_matryoska));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<Decvie_MatryoshkaDTO>(qry, Param).ToList();

            return datos;
        }

        private List<Decvie_MatryoshkaDTO> DatosPGDVRISEDE(int id_matryoska)
        {
            //CARGA DATOS DE LAS ESTRATEGIAS YU OBJETIVOS PGDVRISEDE
            string qry = "select mke.id_matryoska, st.estrategia, opgd.nmobjetivopgdvrisede " +
                            "from decvie_matryoshka mke " +
                            "join decvie_matryoshkaestrategia st on mke.id_matryoska = st.id_matryoska " +
                            "join decvie_matryoshkaobjetivopgd op on st.id_matryoshkaestrategia = op.id_matryoshkaestrategia " +
                            "left join decvie_planaccionobjetivospgdvrisede opgd on op.id_objetivopgdvrisede = opgd.id_objetivopgdvrisede " +
                            "where  mke.id_matryoska = @id_matryoska ";

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@id_matryoska", id_matryoska));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<Decvie_MatryoshkaDTO>(qry, Param).ToList();

            return datos;
        }

        private List<Decvie_MatryoshkaDTO> DatosObjetivoMetaActividad(int id_matryoska)
        {
            //CARGA OBJETIVOS DE LA DEPENDENCIA, META Y ACTIVIDAD 
            string qry = "select mkd.id_matryoska, pode.nmobjetivodependencia, pmta.nmmeta, pac.nmactividad " +
                          "from decvie_matryoshka mkd " +
                          "join decvie_matryoshkaobjetivodep odep on mkd.id_matryoska = odep.id_matryoska " +
                          "join decvie_planaccionobjetivodependencia pode on odep.id_objetivodependencia = pode.id_objetivodependencia " +
                          "join decvie_matryoshkametadep meta on odep.id_matryoshkaobjetivodep = meta.id_matryoshkaobjetivodep " +
                          "left join decvie_planaccionmeta pmta on meta.id_meta = pmta.id_meta " +
                          "left join decvie_matryoshkaactividaddep ac on meta.id_matryoshkametadep = ac.id_matryoshkametadep " +
                          "left join decvie_planaccionactividades pac on ac.id_actividades = pac.id_actividades " +
                          "where mkd.id_matryoska = @id_matryoska ";

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@id_matryoska", id_matryoska));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<Decvie_MatryoshkaDTO>(qry, Param).ToList();

            return datos;
        }

        private List<Decvie_MatryoshkaDTO> DatosIndicadoresEstrategicos(int id_matryoska)
        {
            //CARGA DATOS DE INDICADORES ESTRATEGICOS
            string qry = "select mka.id_matryoska, pic.nmindicadoresestrategicos " +
                          "from decvie_matryoshka mka " +
                          "join decvie_matryoshkaindicadorestrategico ic on mka.id_matryoska = ic.id_matryoska " +
                          "left join decvie_planaccionindicadoresestrategicos pic on ic.id_indicadoresestrategicos = pic.id_indicadoresestrategicos " +
                          "where mka.id_matryoska = @id_matryoska ";

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@id_matryoska", id_matryoska));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<Decvie_MatryoshkaDTO>(qry, Param).ToList();

            return datos;
        }

        private List<Decvie_MatryoshkaDTO> DatosNuevosIndicadores(int id_matryoska)
        {
            //CARGA DATOS NUEVOSW INDICADORES, DESCRIPCION Y EJECUCIÓN
            string qry = "select mopd.id_matryoska, pni.nmnuevosindicadores, ti.nmtipoindicador, mni.descripcion, mni.presupuesto, mni.ejecucion " +
                          "from decvie_matryoshkaobjetivodep mopd " +
                          "join decvie_matryoshkanuevoindicador mni on mopd.id_matryoshkaobjetivodep = mni.id_matryoshkaobjetivodep " +
                          "join decvie_planaccionnuevosindicadores pni on mni.id_nuevosindicadores = pni.id_nuevosindicadores " +
                          "join decvie_planacciontipoindicador ti on mni.id_tipoindicador = ti.id_tipoindicador " +
                          "where mopd.id_matryoska = @id_matryoska ";

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@id_matryoska", id_matryoska));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<Decvie_MatryoshkaDTO>(qry, Param).ToList();

            return datos;
        }

        public string ExcelDecvie_Matryoshka(int id_matryoska)
        {
            var archivoreturn = "/Export/MATRYOSHKA_" + id_matryoska.ToString() + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/MATRYOSHKA_" + id_matryoska.ToString() + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/DECVIE_MATRYOSHKA_.xlsx");

            SLDocument xlsdocument = new SLDocument(plantilla);

            var datosEje = DatosEje(id_matryoska);
            var datosPGDVRISEDE = DatosPGDVRISEDE(id_matryoska);
            var datosObjetivo = DatosObjetivoMetaActividad(id_matryoska);
            var datosIndicadoresEstrategiso = DatosIndicadoresEstrategicos(id_matryoska);
            var datosNuevosIndicadores = DatosNuevosIndicadores(id_matryoska);

            int filaxls = 2;            
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
            styleRellenoLiteral.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.FromArgb(226, 239, 217), System.Drawing.Color.Blue);
            styleAdjTexto.SetWrapText(true);
           

            foreach (var campos in datosEje)
            {                               
                xlsdocument.SetCellValue(2, 14, campos.alcance);                    
                    xlsdocument.SetCellStyle(2, 14, 2, 14, style);                   
                    
            }

            int filainicialeje = 0;
            int filainicialprograma = 0;
            string ejeactual = "";
            string programaactual = "";
            decimal valoreje = 0;

            if (datosEje != null)
            {
                ejeactual = datosEje[0].ejeestrategico;
                programaactual = datosEje[0].nmprogramapgd;
                filainicialeje = filaxls + 1;
                filainicialprograma = filaxls + 1;

                xlsdocument.SetCellValue(filainicialeje, 1, datosEje[0].ejeestrategico);
                xlsdocument.SetCellValue(filainicialeje, 2, datosEje[0].nmprogramapgd);
                valoreje = 0;

                foreach (var registro in datosEje)
                {
                    if (ejeactual != registro.ejeestrategico)
                    {
                        xlsdocument.SetCellValueNumeric(filainicialeje, 13, valoreje.ToString());
                        xlsdocument.MergeWorksheetCells(filainicialeje, 1, filaxls, 1);
                        xlsdocument.SetCellStyle(filainicialeje, 1, styleAdjTexto);
                        xlsdocument.SetCellStyle(filainicialeje, 1, styleRellenoLiteral);
                        xlsdocument.SetCellStyle(filainicialeje, 1, filaxls, 1, style);

                      //  xlsdocument.MergeWorksheetCells(filainicialeje, 2, filaxls, 2);
                        xlsdocument.SetCellStyle(filainicialeje, 2, styleAdjTexto);
                        xlsdocument.SetCellStyle(filainicialeje, 2, styleRellenoLiteral);

                        /*xlsdocument.MergeWorksheetCells(filainicialeje, 6, filaxls, 6);
                        filaxls += 1;
                          xlsdocument.InsertRow(filaxls, 1);
                          xlsdocument.MergeWorksheetCells(filaxls, 1, filaxls, 16);

                          xlsdocument.SetCellStyle(filaxls, 1, styleSeparacion);*/

                        ejeactual = registro.ejeestrategico;
                        filainicialeje = filaxls + 1;

                        xlsdocument.SetCellValue(filainicialeje, 1, registro.ejeestrategico);
                        xlsdocument.SetCellValue(filainicialeje, 2, registro.nmprogramapgd);
                        valoreje = 0;
                    }

                    if (programaactual != registro.nmprogramapgd)
                    {
                        programaactual = registro.nmprogramapgd;
                        filainicialprograma = filaxls + 1;

                        xlsdocument.SetCellValue(filainicialprograma, 2, registro.nmprogramapgd);                        
                    }
                    /*
                    var registro2 = datos2[0];
                    var registro3 = datos3[0];
                    var registro4 = datos4[0];
                    var registro5 = datos5[0];
                    */
                    filaxls += 1;
                    

                    celdaxls = "C" + filaxls.ToString();
                    //xlsdocument.SetCellValue(celdaxls, registro2.estrategia);
                    xlsdocument.SetCellStyle(filainicialeje, 3, styleAdjTexto);
                    xlsdocument.SetCellStyle(filainicialeje, 3, filaxls, 3, style);
                    xlsdocument.SetCellStyle(filainicialeje, 3, styleRellenoLiteral);
                    celdaxls = "D" + filaxls.ToString();
                    //xlsdocument.SetCellValue(celdaxls, registro2.nmobjetivopgdvrisede);
                    xlsdocument.SetCellStyle(filainicialeje, 4, styleAdjTexto);
                    xlsdocument.SetCellStyle(filainicialeje, 4, filaxls, 4, style);
                    xlsdocument.SetCellStyle(filainicialeje, 4, styleRellenoLiteral);
                    celdaxls = "E" + filaxls.ToString();
                    xlsdocument.SetCellValue(celdaxls, "Algo va Aquí");
                    xlsdocument.SetCellStyle(filainicialeje, 5, filaxls, 5, style);
                    xlsdocument.SetCellStyle(filainicialeje, 5, styleRellenoLiteral);
                    celdaxls = "F" + filaxls.ToString();
                    //xlsdocument.SetCellValue(celdaxls, registro3.nmobjetivodependencia);
                    xlsdocument.SetCellStyle(filainicialeje, 6, styleAdjTexto);
                    xlsdocument.SetCellStyle(filainicialeje, 6, filaxls, 6, style);
                    xlsdocument.SetCellStyle(filainicialeje, 6, styleRellenoLiteral);
                    celdaxls = "G" + filaxls.ToString();
                    //xlsdocument.SetCellValue(celdaxls, registro3.nmmeta);
                    xlsdocument.SetCellStyle(filainicialeje, 7, styleAdjTexto);
                    xlsdocument.SetCellStyle(filainicialeje, 7, filaxls, 7, style);
                    xlsdocument.SetCellStyle(filainicialeje, 7, styleRellenoLiteral);
                    celdaxls = "H" + filaxls.ToString();
                    //xlsdocument.SetCellValue(celdaxls, registro3.nmactividad);
                    xlsdocument.SetCellStyle(filainicialeje, 8, styleAdjTexto);
                    xlsdocument.SetCellStyle(filainicialeje, 8, filaxls, 8, style);
                    xlsdocument.SetCellStyle(filainicialeje, 8, styleRellenoLiteral);
                    celdaxls = "I" + filaxls.ToString();
                    //xlsdocument.SetCellValue(celdaxls, registro4.nmindicadoresestrategicos);
                    xlsdocument.SetCellStyle(filainicialeje, 9, styleAdjTexto);
                    xlsdocument.SetCellStyle(filainicialeje, 9, filaxls, 9, style);
                    xlsdocument.SetCellStyle(filainicialeje, 9, styleRellenoLiteral);
                    celdaxls = "J" + filaxls.ToString();
                    //xlsdocument.SetCellValue(celdaxls, registro5.nmnuevosindicadores);
                    xlsdocument.SetCellStyle(filainicialeje, 10, styleAdjTexto);
                    xlsdocument.SetCellStyle(filainicialeje, 10, filaxls, 10, style);
                    xlsdocument.SetCellStyle(filainicialeje, 10, styleRellenoLiteral);
                    celdaxls = "K" + filaxls.ToString();
                    //xlsdocument.SetCellValue(celdaxls, registro5.nmtipoindicador);
                    xlsdocument.SetCellStyle(filainicialeje, 11, filaxls, 11, style);
                    xlsdocument.SetCellStyle(filainicialeje, 11, styleRellenoLiteral);
                    celdaxls = "L" + filaxls.ToString();
                    //xlsdocument.SetCellValue(celdaxls, registro5.descripcion);
                    xlsdocument.SetCellStyle(filainicialeje,12, styleAdjTexto);
                    xlsdocument.SetCellStyle(filainicialeje, 12, filaxls, 12, style);
                    xlsdocument.SetCellStyle(filainicialeje, 12, styleRellenoLiteral);
                    //valoreje += (int)registro5.presupuesto;
                    xlsdocument.SetCellStyle(filainicialeje, 13, filaxls, 13, style);
                    xlsdocument.SetCellStyle(filainicialeje, 13, styleRellenoLiteral);
                }

                xlsdocument.SetCellValueNumeric(filainicialeje, 13, valoreje.ToString());
                xlsdocument.MergeWorksheetCells(filainicialeje, 1, filaxls, 1);
                xlsdocument.SetCellStyle(filainicialeje, 1, styleRellenoLiteral);
                xlsdocument.SetCellStyle(filainicialeje, 1, filaxls, 1, style);
              //  xlsdocument.MergeWorksheetCells(filainicialeje, 2, filaxls, 2);
                xlsdocument.SetCellStyle(filainicialeje, 2, styleAdjTexto);
                xlsdocument.SetCellStyle(filainicialeje, 2, styleRellenoLiteral);
                xlsdocument.MergeWorksheetCells(filainicialeje, 13, filaxls, 13);
            }

            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }
    }
}