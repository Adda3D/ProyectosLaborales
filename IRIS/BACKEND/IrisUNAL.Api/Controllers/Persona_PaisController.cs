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
    public class Persona_PaisController : BaseController<Persona_Pais>
    {
        private readonly IPersona_PaisRepository _persona_PaisRepository;

        public Persona_PaisController(IPersona_PaisRepository persona_PaisRepository)
        {
            _persona_PaisRepository = persona_PaisRepository;
        }

        readonly IPersona_PaisRepository persona_PaisRepository = new Persona_PaisRepository();
        public Persona_PaisController()
        {
            _persona_PaisRepository = persona_PaisRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPersona_Pais()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _persona_PaisRepository.GetAllPersona_Pais();

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
        public IHttpActionResult GetPersona_PaisDetails(int id_pais)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _persona_PaisRepository.GetPersona_PaisDetails(id_pais);

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
        public IHttpActionResult GetPersona_PaisCodigo(string cd_nmpais)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _persona_PaisRepository.GetPersona_PaisDetails(cd_nmpais);

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
        public IHttpActionResult InsertPersona_Pais([FromBody] Persona_Pais persona_Pais)
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

                var created = _persona_PaisRepository.InsertPersona_Pais(persona_Pais);

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
        public IHttpActionResult UpdatePersona_Pais([FromBody] Persona_Pais persona_Pais)
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

                var created = _persona_PaisRepository.UpdatePersona_Pais(persona_Pais);

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
        public IHttpActionResult DeletePersona_Pais(int id_pais)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _persona_PaisRepository.DeletePersona_Pais(id_pais);

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
