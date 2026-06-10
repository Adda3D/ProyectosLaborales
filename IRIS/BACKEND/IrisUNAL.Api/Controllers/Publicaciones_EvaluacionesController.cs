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
    public class Publicaciones_EvaluacionesController : BaseController<Publicaciones_Evaluaciones>
    {
        private readonly IPublicaciones_EvaluacionesRepository _publicaciones_EvaluacionesRepository;
        public Publicaciones_EvaluacionesController(IPublicaciones_EvaluacionesRepository publicaciones_EvaluacionesRepository)
        {
            _publicaciones_EvaluacionesRepository = publicaciones_EvaluacionesRepository;
        }
        readonly IPublicaciones_EvaluacionesRepository publicaciones_EvaluacionesRepository = new Publicaciones_EvaluacionesRepository();
        public Publicaciones_EvaluacionesController()
        {
            _publicaciones_EvaluacionesRepository = publicaciones_EvaluacionesRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_Evaluaciones()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EvaluacionesRepository.GetAllPublicaciones_Evaluaciones();

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
        public IHttpActionResult GetPublicaciones_EvaluacionesDetails(int id_evaluaciones)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EvaluacionesRepository.GetPublicaciones_EvaluacionesDetails(id_evaluaciones);

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
        public IHttpActionResult GetPublicaciones_EvaluacionesByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EvaluacionesRepository.GetPublicaciones_EvaluacionesByPublicacion(id_crearpublicacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicación sin aprobación asignada";
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
        public IHttpActionResult InsertPublicaciones_Evaluaciones([FromBody] Publicaciones_Evaluaciones publicaciones_Evaluaciones)
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

                var created = publicaciones_EvaluacionesRepository.InsertPublicaciones_Evaluaciones(publicaciones_Evaluaciones);

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
        public IHttpActionResult UpdatePublicaciones_Evaluaciones([FromBody] Publicaciones_Evaluaciones publicaciones_Evaluaciones)
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

                var created = publicaciones_EvaluacionesRepository.UpdatePublicaciones_Evaluaciones(publicaciones_Evaluaciones);

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
        public IHttpActionResult DeletePublicaciones_Evaluaciones(int id_evaluaciones)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_EvaluacionesRepository.DeletePublicaciones_Evaluaciones(id_evaluaciones);

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
