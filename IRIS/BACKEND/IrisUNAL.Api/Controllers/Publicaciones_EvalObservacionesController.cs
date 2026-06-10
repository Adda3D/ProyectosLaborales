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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Publicaciones_EvalObservacionesController : BaseController<Publicaciones_EvalObservaciones>
    {
        private readonly Publicaciones_EvalObservacionesRepository _publicaciones_EvalObservacionesRepository;

        public Publicaciones_EvalObservacionesController(Publicaciones_EvalObservacionesRepository publicaciones_evalObservacionrepository)
        {
            _publicaciones_EvalObservacionesRepository = publicaciones_evalObservacionrepository;
        }

        readonly Publicaciones_EvalObservacionesRepository publicaciones_Evalobservacionesrepository = new Publicaciones_EvalObservacionesRepository();

        public Publicaciones_EvalObservacionesController()
        {
            _publicaciones_EvalObservacionesRepository = publicaciones_Evalobservacionesrepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_EvalObservaciones()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_EvalObservacionesRepository.GetAllPublicaciones_EvalObservaciones();

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
        public IHttpActionResult GetPublicaciones_EvalObservacionesDetails(int idevalobservacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_EvalObservacionesRepository.GetPublicaciones_EvalObservacionesDetails(idevalobservacion);

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
        public IHttpActionResult GetPublicaciones_EvalObservacionesByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_EvalObservacionesRepository.GetPublicaciones_EvalObservacionesByPublicacion(id_crearpublicacion);

                resultdb.Ok = true;
                resultdb.Message = "";
/*
                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicación no tiene observaciones";
                }
*/
                resultdb.Data = data;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }

        [HttpPost]
        public IHttpActionResult InsertPublicaciones_EvalObservaciones([FromBody] Publicaciones_EvalObservaciones publicaciones_evalobservaciones)
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

                var created = _publicaciones_EvalObservacionesRepository.InsertPublicaciones_EvalObservaciones(publicaciones_evalobservaciones);

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
        public IHttpActionResult UpdatePublicaciones_EvalObservaciones([FromBody] Publicaciones_EvalObservaciones publicaciones_evalobservaciones)
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

                var created = _publicaciones_EvalObservacionesRepository.UpdatePublicaciones_EvalObservaciones(publicaciones_evalobservaciones);

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
        public IHttpActionResult DeletePublicaciones_EvalObservaciones(int idevalobservacion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _publicaciones_EvalObservacionesRepository.DeletePublicaciones_EvalObservaciones(idevalobservacion);

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
