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
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class Publicaciones_EvalGeneradaController : BaseController<Publicaciones_EvalGenerada>
    {
        private readonly IPublicaciones_EvalGeneradaRepository _publicaciones_EvalGeneradaRepository;
        public Publicaciones_EvalGeneradaController(IPublicaciones_EvalGeneradaRepository publicaciones_EvalGeneradaRepository)
        {
            _publicaciones_EvalGeneradaRepository = publicaciones_EvalGeneradaRepository;
        }
        readonly IPublicaciones_EvalGeneradaRepository publicaciones_EvalGeneradaRepository = new Publicaciones_EvalGeneradaRepository();
        public Publicaciones_EvalGeneradaController()
        {
            _publicaciones_EvalGeneradaRepository = publicaciones_EvalGeneradaRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_EvalGenerada()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EvalGeneradaRepository.GetAllPublicaciones_EvalGenerada();

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
        public IHttpActionResult GetPublicaciones_EvalGeneradaDetails(int id_evalgenerada)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EvalGeneradaRepository.GetPublicaciones_EvalGeneradaDetails(id_evalgenerada);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_EvalGenerada inexistente";
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
        public IHttpActionResult GetPublicaciones_EvalGeneradaNombre(string cd_conevalgenerada)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EvalGeneradaRepository.GetPublicaciones_EvalGeneradaNombre(cd_conevalgenerada);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_EvalGenerada inexistente";
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
        public IHttpActionResult InsertPublicaciones_EvalGenerada([FromBody] Publicaciones_EvalGenerada publicaciones_EvalGenerada)
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

                var created = publicaciones_EvalGeneradaRepository.InsertPublicaciones_EvalGenerada(publicaciones_EvalGenerada);

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
        public IHttpActionResult UpdatePublicaciones_EvalGenerada([FromBody] Publicaciones_EvalGenerada publicaciones_EvalGenerada)
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

                var created = publicaciones_EvalGeneradaRepository.UpdatePublicaciones_EvalGenerada(publicaciones_EvalGenerada);

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
        public IHttpActionResult DeletePublicaciones_EvalGenerada(int id_evalgenerada)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_EvalGeneradaRepository.DeletePublicaciones_EvalGenerada(id_evalgenerada);

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
        public IHttpActionResult GetDataTablePublicaciones_EvalGenerada()
        {
            DataTableAdapter<Publicaciones_EvalGenerada> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_EvalGeneradaRepository.GetDataTablePublicaciones_EvalGenerada(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
