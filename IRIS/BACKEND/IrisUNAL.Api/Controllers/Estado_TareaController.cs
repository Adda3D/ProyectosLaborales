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
    public class Estado_TareaController : BaseController<Estado_Tarea>
    {
        private readonly IEstado_TareaRepository _estado_TareaRepository;

        public Estado_TareaController(IEstado_TareaRepository estado_TareaRepository)
        {
            _estado_TareaRepository = estado_TareaRepository;
        }
        readonly IEstado_TareaRepository estado_TareaRepository = new Estado_TareaRepository();
        public Estado_TareaController()
        {
            _estado_TareaRepository = estado_TareaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllEstado_Tarea()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _estado_TareaRepository.GetAllEstado_Tarea();

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
        public IHttpActionResult GetEstado_TareaDetails(int id_estadotarea)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _estado_TareaRepository.GetEstado_TareaDetails(id_estadotarea);

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
        public IHttpActionResult GetEstado_TareaCodigo(string cd_nmestadotarea)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _estado_TareaRepository.GetEstado_TareaDetails(cd_nmestadotarea);

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
        public IHttpActionResult InsertEstado_Tarea([FromBody] Estado_Tarea estado_Tarea)
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

                var created = _estado_TareaRepository.InsertEstado_Tarea(estado_Tarea);

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
        public IHttpActionResult UpdateEstado_Tarea([FromBody] Estado_Tarea estado_Tarea)
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

                var created = _estado_TareaRepository.UpdateEstado_Tarea(estado_Tarea);

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
        public IHttpActionResult DeleteEstado_Tarea(int id_estadotarea)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _estado_TareaRepository.DeleteEstado_Tarea(id_estadotarea);

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
