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
    public class Persona_CiudadController : BaseController<Persona_Ciudad>
    {
        private readonly IPersona_CiudadRepository _persona_CiudadRepository;

        public Persona_CiudadController(IPersona_CiudadRepository persona_CiudadRepository)
        {
            _persona_CiudadRepository = persona_CiudadRepository;
        }

        readonly IPersona_CiudadRepository persona_CiudadRepository = new Persona_CiudadRepository();
        public Persona_CiudadController()
        {
            _persona_CiudadRepository = persona_CiudadRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPersona_Ciudad()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _persona_CiudadRepository.GetAllPersona_Ciudad();

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
        public IHttpActionResult GetPersona_CiudadDetails(int id_ciudad)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _persona_CiudadRepository.GetPersona_CiudadDetails(id_ciudad);

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
        public IHttpActionResult GetPersona_CiudadCodigo(string cd_nmciudad)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _persona_CiudadRepository.GetPersona_CiudadDetails(cd_nmciudad);

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
        public IHttpActionResult InsertPersona_Ciudad([FromBody] Persona_Ciudad persona_Ciudad)
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

                var created = _persona_CiudadRepository.InsertPersona_Ciudad(persona_Ciudad);

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
        public IHttpActionResult UpdatePersona_Ciudad([FromBody] Persona_Ciudad persona_Ciudad)
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

                var created = _persona_CiudadRepository.UpdatePersona_Ciudad(persona_Ciudad);

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
        public IHttpActionResult DeletePersona_Ciudad(int id_ciudad)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _persona_CiudadRepository.DeletePersona_Ciudad(id_ciudad);

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
