using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models.Hermes;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories.Hermes
{
    public class HermesProyectoInvestigacionRepository : SuperType<HermesProyectoInvestigacion>
    {
        private ApplicationDbContext _context;

        public HermesProyectoInvestigacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public HermesProyectoInvestigacionRepository()
        {
            _context = new ApplicationDbContext();
        }

        public HermesProyectoInvestigacion GetHermesProyectoInvestigacionDetails(int idproyecto)
        {
            return Get(idproyecto);
        }

        public HermesProyectoInvestigacion GetHermesProyectoInvestigacionDetailsidhermes(int idhermes)
        {
            return Get(p => p.id_hermes == idhermes).FirstOrDefault();
        }

        public bool InsertHermesProyectoInvestigacion(HermesProyectoInvestigacion _hermesproyectoinvestigacion)
        {
            Add(_hermesproyectoinvestigacion);
            return true;
        }

        public bool UpdateHermesProyectoInvestigacion(HermesProyectoInvestigacion _hermesproyectoinvestigacion)
        {
            Update(_hermesproyectoinvestigacion);
            return true;
        }

        public DataTableAdapter<HermesProyectoInvestigacion> GetDataTableHermesProyectoInvestigacion(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<HermesProyectoInvestigacion, bool>> srchByFunc = null;
            Expression<Func<HermesProyectoInvestigacion, string>> orderByFunc = null;            
            Expression<Func<HermesProyectoInvestigacion, int>> orderByIntFunc = null;

            bool isOrderDesc = false;            

            if (model.SortColumn.ToLower() == "id_hermes")
                orderByIntFunc = CreateExpressionOrderByInt<HermesProyectoInvestigacion>("id_hermes");
            else
                orderByFunc = CreateExpressionOrderBy<HermesProyectoInvestigacion>(model.SortColumn);

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.codigoquipu.ToLower().Contains(model.SearchValue.ToLower()) || d.nombreproyecto.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            var data = (model.SortColumn.ToLower() == "id_hermes") ?
                Get(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc).ToList() :
                Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<HermesProyectoInvestigacion> result = new DataTableAdapter<HermesProyectoInvestigacion>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public string ConsultarWSHermes(string endpoint)
        {
            string jsonContent = string.Empty;
            string strResponseValue = string.Empty;
            HermesProyectoInvestigacionWS resultadoWS = null;
            jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(resultadoWS);

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(jsonContent);

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.hermes.unal.edu.co:8093/hermesWS/WS/interoperabilidad/FDCPS/P1");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endpoint);
            request.Method = "GET";

            //request.ContentLength = byteArray.Length;
            request.ContentType = @"application/json";
            /*
            using (System.IO.Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            */
            long length = 0;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                length = response.ContentLength;
                using (System.IO.Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (System.IO.StreamReader reader = new System.IO.StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();

                            //logger.Log(string.Format("Solicitud:{0}{1}{0}Respuesta:{0}{2}", Environment.NewLine, jsonContent, strResponseValue));
                        }
                    }
                }

            }

            return strResponseValue;
        }

        public HermesProyectoInvestigacion SetCamposProyectoInvestigacion(HermesProyectoInvestigacionWS dataws)
        {
            HermesProyectoInvestigacion datadb = new HermesProyectoInvestigacion();

            datadb.id_hermes = dataws.id;
            datadb.codigoquipu = dataws.codigoQUIPU;
            datadb.tipologiaproyecto = dataws.tipologiaProyecto;
            datadb.nombreproyecto = dataws.nombreProyecto;
            datadb.duracion = dataws.duracion;
            datadb.resumen = dataws.resumen;
            datadb.estadoactual = dataws.estadoActual;
            datadb.lugarejecucion = dataws.lugarEjecucion;
            datadb.objetivogeneral = dataws.objetivoGeneral;
            datadb.convocatoria = dataws.convocatoria;
            datadb.annioconvocatoria = dataws.añoConvocatoria;
            datadb.tipoconvocatoria = dataws.tipoConvocatoria;
            datadb.modalidad = dataws.modalidad;
            datadb.tdocinvprincipal = dataws.tDocInvPrincipal;
            datadb.documentoinvprinc = dataws.documentoInvPrinc;
            datadb.invprincipal = dataws.invPrincipal;
            datadb.horasdedicacion = dataws.horasDedicacion;
            datadb.sede = dataws.sede;
            datadb.facultad = dataws.facultad;
            datadb.departamento = dataws.departamento;
            datadb.fechapropuesta = dataws.fechaPropuesta;
            datadb.fechainicio = dataws.fechaInicio;
            datadb.fechafinal = dataws.fechaFinal;
            datadb.fechafinalprorrogas = dataws.fechaFinalProrrogas;
            datadb.valorpersonal = dataws.valorPersonal;
            datadb.montointernofinanciado = dataws.montoInternoFinanciado;
            datadb.montoexternofinanciado = dataws.montoExternofinanciado;
            datadb.montoentparticipantes = dataws.montoEntParticipantes;
            datadb.montoadicionesapobadas = dataws.montoAdicionesApobadas;
            datadb.totalactualproyecto = dataws.totalActualProyecto;
            datadb.impactoesperado = dataws.impactoEsperado;
            datadb.justificacion = dataws.justificacion;
            datadb.metodologia = dataws.metodologia;
            datadb.descripcion = dataws.descripcion;
            datadb.antecedentes = dataws.antecedentes;
            datadb.jornadadocente = dataws.jornadaDocente;

            return datadb;
        }

        public bool CargarHermesProyectoInvestigacion()
        {
            string strResponseValue = string.Empty;
            List<HermesProyectoInvestigacionWS> datosWS = null;

            strResponseValue = ConsultarWSHermes("http://www.hermes.unal.edu.co:8093/hermesWS/WS/interoperabilidad/FDCPS/P1");

            if (!string.IsNullOrEmpty(strResponseValue))
            {
                datosWS = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HermesProyectoInvestigacionWS>>(strResponseValue);                
            }

            foreach (var proyecto in datosWS)
            {
                int id_hermes = proyecto.id;

                var datosproyecto = SetCamposProyectoInvestigacion(proyecto);

                var proyectodb = Get(p => p.id_hermes == id_hermes).FirstOrDefault();

                if (proyectodb != null)
                {
                    Delete(proyectodb.idproyecto);
                }

                Add(datosproyecto);
            }
            
            return true;
        }


    }
}