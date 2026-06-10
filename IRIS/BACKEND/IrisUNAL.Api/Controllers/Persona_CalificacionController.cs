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
    public class Persona_CalificacionController : BaseController<Persona_Calificacion>
    {
        private readonly IPersona_CalificacionRepository _persona_CalificacionRepository;

        public Persona_CalificacionController(IPersona_CalificacionRepository persona_CalificacionRepository)
        {
            _persona_CalificacionRepository = persona_CalificacionRepository;
        }

        readonly IPersona_CalificacionRepository persona_CalificacionRepository = new Persona_CalificacionRepository();
        public Persona_CalificacionController()
        {
            _persona_CalificacionRepository = persona_CalificacionRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPersona_Calificacion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = persona_CalificacionRepository.GetAllPersona_Calificacion();

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
        public IHttpActionResult GetPersona_CalificacionDetails(int id_calificacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = persona_CalificacionRepository.GetPersona_CalificacionDetails(id_calificacion);

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
        public IHttpActionResult GetPersona_CalificacionCalificacion(string cd_calificacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = persona_CalificacionRepository.GetPersona_CalificacionCalificacion(cd_calificacion);

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
        public IHttpActionResult InsertPersona_Calificacion([FromBody] Persona_Calificacion persona_Calificacion)
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

                var created = persona_CalificacionRepository.InsertPersona_Calificacion(persona_Calificacion);

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
        public IHttpActionResult UpdatePersona_Calificacion([FromBody] Persona_Calificacion persona_Calificacion)
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

                var created = persona_CalificacionRepository.UpdatePersona_Calificacion(persona_Calificacion);

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
        public IHttpActionResult DeletePersona_Calificacion(int id_calificacion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = persona_CalificacionRepository.DeletePersona_Calificacion(id_calificacion);

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
