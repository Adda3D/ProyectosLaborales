using IrisUNAL.Api.Entities.Repositories;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IrisUNAL.Api.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class Publicaciones_EstadoCorParamController : BaseController<Publicaciones_EstadoCorParam>
    {
        private readonly IPublicaciones_EstadoCorParamRepository _publicaciones_EstadoCorParamRepository;
        public Publicaciones_EstadoCorParamController(IPublicaciones_EstadoCorParamRepository publicaciones_EstadoCorParamRepository)
        {
            _publicaciones_EstadoCorParamRepository = publicaciones_EstadoCorParamRepository;
        }
        readonly IPublicaciones_EstadoCorParamRepository publicaciones_EstadoCorParamRepository = new Publicaciones_EstadoCorParamRepository();
        public Publicaciones_EstadoCorParamController()
        {
            _publicaciones_EstadoCorParamRepository = publicaciones_EstadoCorParamRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_EstadoCorParam()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EstadoCorParamRepository.GetAllPublicaciones_EstadoCorParam();

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
        public IHttpActionResult GetPublicaciones_EstadoCorParamDetails(int id_estadocorparam)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EstadoCorParamRepository.GetPublicaciones_EstadoCorParamDetails(id_estadocorparam);

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
        public IHttpActionResult GetPublicaciones_EstadoCorParamByPublicacionEtapa(int id_crearpublicacion, string correccionetapa)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EstadoCorParamRepository.GetPublicaciones_EstadoCorParamByPublicacionEtapa(id_crearpublicacion, correccionetapa);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Etapa de corrección no asignada";
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
        public IHttpActionResult InsertPublicaciones_EstadoCorParam([FromBody] Publicaciones_EstadoCorParam publicaciones_EstadoCorParam)
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

                var created = publicaciones_EstadoCorParamRepository.InsertPublicaciones_EstadoCorParam(publicaciones_EstadoCorParam);

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
        public IHttpActionResult UpdatePublicaciones_EstadoCorParam([FromBody] Publicaciones_EstadoCorParam publicaciones_EstadoCorParam)
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

                var created = publicaciones_EstadoCorParamRepository.UpdatePublicaciones_EstadoCorParam(publicaciones_EstadoCorParam);

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
        public IHttpActionResult DeletePublicaciones_EstadoCorParam(int id_estadocorparam)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_EstadoCorParamRepository.DeletePublicaciones_EstadoCorParam(id_estadocorparam);

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
    }
}
