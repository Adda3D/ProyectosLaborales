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
    public class Publicaciones_EvalConceptoController : BaseController<Publicaciones_EvalConcepto>
    {
        private readonly IPublicaciones_EvalConceptoRepository _publicaciones_EvalConceptoRepository;
        public Publicaciones_EvalConceptoController(IPublicaciones_EvalConceptoRepository publicaciones_EvalConceptoRepository)
        {
            _publicaciones_EvalConceptoRepository = publicaciones_EvalConceptoRepository;
        }
        readonly IPublicaciones_EvalConceptoRepository publicaciones_EvalConceptoRepository = new Publicaciones_EvalConceptoRepository();
        public Publicaciones_EvalConceptoController()
        {
            _publicaciones_EvalConceptoRepository = publicaciones_EvalConceptoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_EvalConcepto()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EvalConceptoRepository.GetAllPublicaciones_EvalConcepto();

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
        public IHttpActionResult GetPublicaciones_EvalConceptoDetails(int id_evalconcepto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EvalConceptoRepository.GetPublicaciones_EvalConceptoDetails(id_evalconcepto);

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
        public IHttpActionResult GetPublicaciones_EvalConceptoByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EvalConceptoRepository.GetPublicaciones_EvalConceptoByPublicacion(id_crearpublicacion);

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
        public IHttpActionResult GetPublicaciones_EvalConceptoByEvaluador(int id_evaluadores)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EvalConceptoRepository.GetPublicaciones_EvalConceptoByEvaluador(id_evaluadores);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Evaluador no tiene concepto asignado";
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
        public IHttpActionResult GetPublicaciones_EvalConceptoByPublicacionEvaluacion(int id_crearpublicacion, int id_evalgenerada)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EvalConceptoRepository.GetPublicaciones_EvalConceptoByPublicacionEvaluacion(id_crearpublicacion, id_evalgenerada);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Evaluador no tiene concepto asignado";
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
        public IHttpActionResult InsertPublicaciones_EvalConcepto([FromBody] Publicaciones_EvalConcepto publicaciones_EvalConcepto)
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

                var created = publicaciones_EvalConceptoRepository.InsertPublicaciones_EvalConcepto(publicaciones_EvalConcepto);

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
        public IHttpActionResult UpdatePublicaciones_EvalConcepto([FromBody] Publicaciones_EvalConcepto publicaciones_EvalConcepto)
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

                var created = publicaciones_EvalConceptoRepository.UpdatePublicaciones_EvalConcepto(publicaciones_EvalConcepto);

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
        public IHttpActionResult DeletePublicaciones_EvalConcepto(int id_evalconcepto)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_EvalConceptoRepository.DeletePublicaciones_EvalConcepto(id_evalconcepto);

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
