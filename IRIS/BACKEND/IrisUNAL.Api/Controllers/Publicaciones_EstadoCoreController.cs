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
    public class Publicaciones_EstadoCoreController : BaseController<Publicaciones_EstadoCore>
    {
        private readonly IPublicaciones_EstadoCoreRepository _publicaciones_EstadoCoreRepository;
        public Publicaciones_EstadoCoreController(IPublicaciones_EstadoCoreRepository publicaciones_EstadoCoreRepository)
        {
            _publicaciones_EstadoCoreRepository = publicaciones_EstadoCoreRepository;
        }
        readonly IPublicaciones_EstadoCoreRepository publicaciones_EstadoCoreRepository = new Publicaciones_EstadoCoreRepository();
        public Publicaciones_EstadoCoreController()
        {
            _publicaciones_EstadoCoreRepository = publicaciones_EstadoCoreRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_EstadoCore()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EstadoCoreRepository.GetAllPublicaciones_EstadoCore();

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
        public IHttpActionResult GetPublicaciones_EstadoCoreDetails(int id_estadocore)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EstadoCoreRepository.GetPublicaciones_EstadoCoreDetails(id_estadocore);

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
        public IHttpActionResult GetPublicaciones_EstadoCoreCodigo(string cd_id_kardex)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EstadoCoreRepository.GetPublicaciones_EstadoCoreCodigo(cd_id_kardex);

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

        [HttpPost]
        public IHttpActionResult InsertPublicaciones_EstadoCore([FromBody] Publicaciones_EstadoCore publicaciones_EstadoCore)
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

                var created = publicaciones_EstadoCoreRepository.InsertPublicaciones_EstadoCore(publicaciones_EstadoCore);

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
        public IHttpActionResult UpdatePublicaciones_EstadoCore([FromBody] Publicaciones_EstadoCore publicaciones_EstadoCore)
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

                var created = publicaciones_EstadoCoreRepository.UpdatePublicaciones_EstadoCore(publicaciones_EstadoCore);

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
        public IHttpActionResult DeletePublicaciones_EstadoCore(int id_estadocore)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_EstadoCoreRepository.DeletePublicaciones_EstadoCore(id_estadocore);

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
