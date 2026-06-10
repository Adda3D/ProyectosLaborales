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
    public class HermesProyectoExtensionRepository : SuperType<HermesProyectoExtension>
    {
        private ApplicationDbContext _context;

        public HermesProyectoExtensionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public HermesProyectoExtensionRepository()
        {
            _context = new ApplicationDbContext();
        }

        public HermesProyectoExtension GetHermesProyectoExtensionDetails(int idproyecto)
        {
            return Get(idproyecto);
        }

        public bool InsertHermesProyectoExtension(HermesProyectoExtension _hermesproyectoextension)
        {
            Add(_hermesproyectoextension);
            return true;
        }

        public bool UpdateHermesProyectoExtension(HermesProyectoExtension _hermesproyectoextension)
        {
            Update(_hermesproyectoextension);
            return true;
        }

        public DataTableAdapter<HermesProyectoExtension> GetDataTableHermesProyectoExtension(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<HermesProyectoExtension, bool>> srchByFunc = null;
            Expression<Func<HermesProyectoExtension, string>> orderByFunc = null;
            Expression<Func<HermesProyectoExtension, int>> orderByIntFunc = null;

            bool isOrderDesc = false;

            if (model.SortColumn.ToLower() == "id_hermes")
                orderByIntFunc = CreateExpressionOrderByInt<HermesProyectoExtension>("id_hermes");
            else
                orderByFunc = CreateExpressionOrderBy<HermesProyectoExtension>(model.SortColumn);

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.codigo_quipu.ToLower().Contains(model.SearchValue.ToLower()) || d.nombre_proyecto.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            var data = (model.SortColumn.ToLower() == "id_hermes") ?
                Get(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc).ToList() :
                Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<HermesProyectoExtension> result = new DataTableAdapter<HermesProyectoExtension>();

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
            HermesProyectoExtensionWS resultadoWS = null;
            jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(resultadoWS);

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(jsonContent);

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://hermesextension.unal.edu.co/ords/test/snw_hermes/v1/proyectos/BOG_DER");
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

        public HermesProyectoExtension SetCamposProyectoExtension(HermesProyectoExtensionWS dataws)
        {
            HermesProyectoExtension datadb = new HermesProyectoExtension();

            datadb.id_hermes = dataws.codigo_hermes;
            datadb.proceso = dataws.proceso;
            datadb.actividad = dataws.actividad;
            datadb.estado = dataws.estado;
            datadb.observacion = dataws.observacion;
            datadb.codigo_quipu = dataws.codigo_quipu;
            datadb.modalidad = dataws.modalidad;
            datadb.submodalidad = dataws.submodalidad;
            datadb.nombre_proyecto = dataws.nombre_proyecto;
            datadb.origen_propuesta = dataws.origen_propuesta;
            datadb.id_acuerdo_interfic = dataws.id_acuerdo_interfic;
            datadb.id_convocatoria = dataws.id_convocatoria;
            datadb.nombre_convocatoria = dataws.nombre_convocatoria;
            datadb.objeto_convocatoria = dataws.objeto_convocatoria;
            datadb.documentos_adjuntos = dataws.documentos_adjuntos;
            datadb.justificacion = dataws.justificacion;
            datadb.convenio_marco = dataws.convenio_marco;
            datadb.firma = dataws.firma;
            datadb.fecha_acuerdo = dataws.fecha_acuerdo;
            datadb.fecha_inicio_proyecto = dataws.fecha_inicio_proyecto;
            datadb.fecha_fin_proyecto = dataws.fecha_fin_proyecto;
            datadb.fecha_fin_ejecucion = dataws.fecha_fin_ejecucion;
            datadb.fecha_liquidacion_quipu = dataws.fecha_liquidacion_quipu;
            datadb.informe_final = dataws.informe_final;
            datadb.enlace_informe_final = dataws.enlace_informe_final;

            return datadb;
        }

        public bool CargarHermesProyectoExtension()
        {
            string strResponseValue = string.Empty;
            LstHermesExtension datosWS = null;
            //List<HermesProyectoExtensionWS> datosWS = null;

            strResponseValue = ConsultarWSHermes("https://hermesextension.unal.edu.co/ords/test/snw_hermes/v1/proyectos/BOG_DER");

            if (!string.IsNullOrEmpty(strResponseValue))
            {
                datosWS = Newtonsoft.Json.JsonConvert.DeserializeObject<LstHermesExtension>(strResponseValue);
            }

            
            foreach (var proyecto in datosWS.items)
            {
                int id_hermes = proyecto.codigo_hermes;

                var datosproyecto = SetCamposProyectoExtension(proyecto);

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