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
    public class Publicaciones_DivulgacionPlanController : BaseController<Publicaciones_DivulgacionPlan>
    {
        private readonly IPublicaciones_DivulgacionPlanRepository _publicaciones_DivulgacionPlanRepository;
        public Publicaciones_DivulgacionPlanController(IPublicaciones_DivulgacionPlanRepository publicaciones_DivulgacionPlanRepository)
        {
            _publicaciones_DivulgacionPlanRepository = publicaciones_DivulgacionPlanRepository;
        }
        readonly IPublicaciones_DivulgacionPlanRepository publicaciones_DivulgacionPlanRepository = new Publicaciones_DivulgacionPlanRepository();
        public Publicaciones_DivulgacionPlanController()
        {
            _publicaciones_DivulgacionPlanRepository = publicaciones_DivulgacionPlanRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DivulgacionPlan()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionPlanRepository.GetAllPublicaciones_DivulgacionPlan();

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
        public IHttpActionResult GetPublicaciones_DivulgacionPlanDetails(int id_plan)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionPlanRepository.GetPublicaciones_DivulgacionPlanDetails(id_plan);

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
        public IHttpActionResult InsertPublicaciones_DivulgacionPlan([FromBody] Publicaciones_DivulgacionPlan publicaciones_DivulgacionPlan)
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

                var created = publicaciones_DivulgacionPlanRepository.InsertPublicaciones_DivulgacionPlan(publicaciones_DivulgacionPlan);

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
        public IHttpActionResult UpdatePublicaciones_DivulgacionPlan([FromBody] Publicaciones_DivulgacionPlan publicaciones_DivulgacionPlan)
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

                var created = publicaciones_DivulgacionPlanRepository.UpdatePublicaciones_DivulgacionPlan(publicaciones_DivulgacionPlan);

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
        public IHttpActionResult DeletePublicaciones_DivulgacionPlan(int id_plan)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DivulgacionPlanRepository.DeletePublicaciones_DivulgacionPlan(id_plan);

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
        public IHttpActionResult GetPublicaciones_DivulgacionPlanByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionPlanRepository.GetPublicaciones_DivulgacionPlanByPublicacion(id_crearpublicacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Datos plan divulgación no asignados para la publicación";
                }

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
