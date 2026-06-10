using IrisUNAL.Api.Entities.Repositories.Investigacion;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.Investigacion;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IrisUNAL.Api.Controllers.Investigacion
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class Convocatoria_InteresadosController : BaseController<Convocatoria_Interesados>
    {
        private readonly Convocatoria_InteresadosRepository _convocatoria_InteresadosRepository;
        public Convocatoria_InteresadosController (Convocatoria_InteresadosRepository convocatoria_InteresadosRepository)
        {
            _convocatoria_InteresadosRepository = convocatoria_InteresadosRepository;
        }
        readonly Convocatoria_InteresadosRepository convocatoria_InteresadosRepository = new Convocatoria_InteresadosRepository();
        public Convocatoria_InteresadosController()
        {
            _convocatoria_InteresadosRepository = convocatoria_InteresadosRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllConvocatoria_Interesados()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = convocatoria_InteresadosRepository.GetAllConvocatoria_Interesados();

                resultdb.Ok = true;
                resultdb.Message = "";
                resultdb.Data = data;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetConvocatoria_InteresadosDetails(int id_interesados)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = convocatoria_InteresadosRepository.GetConvocatoria_InteresadosDetails(id_interesados);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Interesado inexistente";
                }

                resultdb.Data = data;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetConvocatoria_InteresadosNombre(string cd_nombreinteresado)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = convocatoria_InteresadosRepository.GetConvocatoria_InteresadosNombre(cd_nombreinteresado);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Interesado inexistente";
                }

                resultdb.Data = data;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }

        [HttpPost]
        public IHttpActionResult InsertConvocatoria_Interesados([FromBody] Convocatoria_Interesados convocatoria_Interesados)
        {
            var resultdb = new ResultObject();

            try
            {
                //VALIDA BASADO EN LOS DATAANNOTATIONS DEL MODELO
                if (!ModelState.IsValid)
                {
                    resultdb.Ok = false;
                    resultdb.Message = Request.CreateResponse(ModelState).ToString();
                    resultdb.Data = null;
                }

                var created = convocatoria_InteresadosRepository.InsertConvocatoria_Interesados(convocatoria_Interesados);

                resultdb.Ok = true;
                resultdb.Message = "";
                resultdb.Data = created;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }

        [HttpPost]
        public IHttpActionResult UpdateConvocatoria_Interesados([FromBody] Convocatoria_Interesados convocatoria_Interesados)
        {
            var resultdb = new ResultObject();

            try
            {
                //VALIDA BASADO EN LOS DATAANNOTATIONS DEL MODELO
                if (!ModelState.IsValid)
                {
                    resultdb.Ok = false;
                    resultdb.Message = Request.CreateResponse(ModelState).ToString();
                    resultdb.Data = null;
                }

                var created = convocatoria_InteresadosRepository.UpdateConvocatoria_Interesados(convocatoria_Interesados);

                resultdb.Ok = true;
                resultdb.Message = "";
                resultdb.Data = created;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteConvocatoria_Interesados(int id_interesados)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = convocatoria_InteresadosRepository.DeleteConvocatoria_Interesados(id_interesados);

                resultdb.Ok = true;
                resultdb.Message = "";
                resultdb.Data = data;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetDataTableConvocatoria_InteresadosByConvocatoria(int id_convocatoria)
        {
            DataTableAdapter<Convocatoria_Interesados> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = convocatoria_InteresadosRepository.GetDataTableConvocatoria_InteresadosByConvocatoria(id_convocatoria, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
