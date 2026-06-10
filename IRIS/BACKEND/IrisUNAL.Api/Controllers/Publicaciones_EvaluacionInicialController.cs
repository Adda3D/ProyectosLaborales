using IrisUNAL.Api.Entities.Repositories;
using IrisUNAL.Api.Models;
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

namespace IrisUNAL.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Publicaciones_EvaluacionInicialController : BaseController<Publicaciones_EvaluacionInicial>
    {
        private IPublicaciones_EvaluacionInicialRepository _publicaciones_EvaluacionInicialRepository;
        public Publicaciones_EvaluacionInicialController(IPublicaciones_EvaluacionInicialRepository publicaciones_EvaluacionInicialRepository)
        {
            _publicaciones_EvaluacionInicialRepository = publicaciones_EvaluacionInicialRepository;
        }
        readonly IPublicaciones_EvaluacionInicialRepository publicaciones_EvaluacionInicialRepository = new Publicaciones_EvaluacionInicialRepository();
        public Publicaciones_EvaluacionInicialController()
        {
            _publicaciones_EvaluacionInicialRepository = publicaciones_EvaluacionInicialRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_EvaluacionInicial()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EvaluacionInicialRepository.GetAllPublicaciones_EvaluacionInicial();

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
        public IHttpActionResult GetPublicaciones_EvaluacionInicialDetails(int id_evaluacioninicial)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EvaluacionInicialRepository.GetPublicaciones_EvaluacionInicialDetails(id_evaluacioninicial);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_EvaluacionInicial inexistente";
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
        public IHttpActionResult GetPublicaciones_EvaluacionInicialNombre(string cd_nmevalinicial)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EvaluacionInicialRepository.GetPublicaciones_EvaluacionInicialNombre(cd_nmevalinicial);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_EvaluacionInicial inexistente";
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
        public IHttpActionResult InsertPublicaciones_EvaluacionInicial([FromBody] Publicaciones_EvaluacionInicial publicaciones_EvaluacionInicial)
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

                var created = publicaciones_EvaluacionInicialRepository.InsertPublicaciones_EvaluacionInicial(publicaciones_EvaluacionInicial);

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
        public IHttpActionResult UpdatePublicaciones_EvaluacionInicial([FromBody] Publicaciones_EvaluacionInicial publicaciones_EvaluacionInicial)
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

                var created = publicaciones_EvaluacionInicialRepository.UpdatePublicaciones_EvaluacionInicial(publicaciones_EvaluacionInicial);

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
        public IHttpActionResult DeletePublicaciones_EvaluacionInicial(int id_evaluacioninicial)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_EvaluacionInicialRepository.DeletePublicaciones_EvaluacionInicial(id_evaluacioninicial);

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
        public IHttpActionResult GetDataTablePublicaciones_EvaluacionInicial()
        {
            DataTableAdapter<Publicaciones_EvaluacionInicial> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_EvaluacionInicialRepository.GetDataTablePublicaciones_EvaluacionInicial(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
