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
    public class Publicaciones_EstadoCubiertaController : BaseController<Publicaciones_EstadoCubierta>
    {
        private readonly IPublicaciones_EstadoCubiertaRepository _publicaciones_EstadoCubiertaRepository;
        public Publicaciones_EstadoCubiertaController(IPublicaciones_EstadoCubiertaRepository publicaciones_EstadoCubiertaRepository)
        {
            _publicaciones_EstadoCubiertaRepository = publicaciones_EstadoCubiertaRepository;
        }
        readonly IPublicaciones_EstadoCubiertaRepository publicaciones_EstadoCubiertaRepository = new Publicaciones_EstadoCubiertaRepository();
        public Publicaciones_EstadoCubiertaController()
        {
            _publicaciones_EstadoCubiertaRepository = publicaciones_EstadoCubiertaRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_EstadoCubierta()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EstadoCubiertaRepository.GetAllPublicaciones_EstadoCubierta();

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
        public IHttpActionResult GetPublicaciones_EstadoCubiertaDetails(int id_estadocubierta)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EstadoCubiertaRepository.GetPublicaciones_EstadoCubiertaDetails(id_estadocubierta);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_EstadoCubierta inexistente";
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
        public IHttpActionResult GetPublicaciones_EstadoCubiertaNombre(string cd_nmestadocubierta)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EstadoCubiertaRepository.GetPublicaciones_EstadoCubiertaNombre(cd_nmestadocubierta);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_EstadoCubierta inexistente";
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
        public IHttpActionResult InsertPublicaciones_EstadoCubierta([FromBody] Publicaciones_EstadoCubierta publicaciones_EstadoCubierta)
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

                var created = publicaciones_EstadoCubiertaRepository.InsertPublicaciones_EstadoCubierta(publicaciones_EstadoCubierta);

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
        public IHttpActionResult UpdatePublicaciones_EstadoCubierta([FromBody] Publicaciones_EstadoCubierta publicaciones_EstadoCubierta)
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

                var created = publicaciones_EstadoCubiertaRepository.UpdatePublicaciones_EstadoCubierta(publicaciones_EstadoCubierta);

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
        public IHttpActionResult DeletePublicaciones_EstadoCubierta(int id_estadocubierta)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_EstadoCubiertaRepository.DeletePublicaciones_EstadoCubierta(id_estadocubierta);

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
        public IHttpActionResult GetDataTablePublicaciones_EstadoCubierta()
        {
            DataTableAdapter<Publicaciones_EstadoCubierta> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_EstadoCubiertaRepository.GetDataTablePublicaciones_EstadoCubierta(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
