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
    public class Publicaciones_CesionDerechosController : BaseController<Publicaciones_CesionDerechos>
    {
        private readonly IPublicaciones_CesionDerechosRepository _publicaciones_CesionDerechosRepository;
        public Publicaciones_CesionDerechosController(IPublicaciones_CesionDerechosRepository publicaciones_CesionDerechosRepository)
        {
            _publicaciones_CesionDerechosRepository = publicaciones_CesionDerechosRepository;
        }
        readonly IPublicaciones_CesionDerechosRepository publicaciones_CesionDerechosRepository = new Publicaciones_CesionDerechosRepository();
        public Publicaciones_CesionDerechosController()
        {
            _publicaciones_CesionDerechosRepository = publicaciones_CesionDerechosRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_CesionDerechos()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CesionDerechosRepository.GetAllPublicaciones_CesionDerechos();

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
        public IHttpActionResult GetPublicaciones_CesionDerechosDetails(int id_cesionderechos)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CesionDerechosRepository.GetPublicaciones_CesionDerechosDetails(id_cesionderechos);

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
        public IHttpActionResult GetPublicaciones_CesionDerechosByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CesionDerechosRepository.GetPublicaciones_CesionDerechosByPublicacion(id_crearpublicacion);

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
        public IHttpActionResult InsertPublicaciones_CesionDerechos([FromBody] Publicaciones_CesionDerechos publicaciones_CesionDerechos)
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

                var created = publicaciones_CesionDerechosRepository.InsertPublicaciones_CesionDerechos(publicaciones_CesionDerechos);

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
        public IHttpActionResult UpdatePublicaciones_CesionDerechos([FromBody] Publicaciones_CesionDerechos publicaciones_CesionDerechos)
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

                var created = publicaciones_CesionDerechosRepository.UpdatePublicaciones_CesionDerechos(publicaciones_CesionDerechos);

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
        public IHttpActionResult DeletePublicaciones_CesionDerechos(int id_cesionderechos)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_CesionDerechosRepository.DeletePublicaciones_CesionDerechos(id_cesionderechos);

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
