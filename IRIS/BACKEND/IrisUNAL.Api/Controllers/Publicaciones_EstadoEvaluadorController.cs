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
    public class Publicaciones_EstadoEvaluadorController : BaseController<Publicaciones_EstadoEvaluador>
    {
        private readonly IPublicaciones_EstadoEvaluadorRepository _publicaciones_EstadoEvaluadorRepository;
        public Publicaciones_EstadoEvaluadorController(IPublicaciones_EstadoEvaluadorRepository publicaciones_EstadoEvaluadorRepository)
        {
            _publicaciones_EstadoEvaluadorRepository = publicaciones_EstadoEvaluadorRepository;
        }
        readonly IPublicaciones_EstadoEvaluadorRepository publicaciones_EstadoEvaluadorRepository = new Publicaciones_EstadoEvaluadorRepository();
        public Publicaciones_EstadoEvaluadorController()
        {
            _publicaciones_EstadoEvaluadorRepository = publicaciones_EstadoEvaluadorRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_EstadoEvaluador()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EstadoEvaluadorRepository.GetAllPublicaciones_EstadoEvaluador();

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
        public IHttpActionResult GetPublicaciones_EstadoEvaluadorDetails(int id_estadoevaluador)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EstadoEvaluadorRepository.GetPublicaciones_EstadoEvaluadorDetails(id_estadoevaluador);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_EstadoEvaluador inexistente";
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
        public IHttpActionResult GetPublicaciones_EstadoEvaluadorNombre(string cd_nmestadoevaluador)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EstadoEvaluadorRepository.GetPublicaciones_EstadoEvaluadorNombre(cd_nmestadoevaluador);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_EstadoEvaluador inexistente";
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
        public IHttpActionResult InsertPublicaciones_EstadoEvaluador([FromBody] Publicaciones_EstadoEvaluador publicaciones_EstadoEvaluador)
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

                var created = publicaciones_EstadoEvaluadorRepository.InsertPublicaciones_EstadoEvaluador(publicaciones_EstadoEvaluador);

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
        public IHttpActionResult UpdatePublicaciones_EstadoEvaluador([FromBody] Publicaciones_EstadoEvaluador publicaciones_EstadoEvaluador)
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

                var created = publicaciones_EstadoEvaluadorRepository.UpdatePublicaciones_EstadoEvaluador(publicaciones_EstadoEvaluador);

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
        public IHttpActionResult DeletePublicaciones_EstadoEvaluador(int id_estadoevaluador)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_EstadoEvaluadorRepository.DeletePublicaciones_EstadoEvaluador(id_estadoevaluador);

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
        public IHttpActionResult GetDataTablePublicaciones_EstadoEvaluador()
        {
            DataTableAdapter<Publicaciones_EstadoEvaluador> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_EstadoEvaluadorRepository.GetDataTablePublicaciones_EstadoEvaluador(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
