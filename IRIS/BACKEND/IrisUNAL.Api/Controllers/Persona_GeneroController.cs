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
    public class Persona_GeneroController : BaseController<Persona_Genero>
    {
        private readonly IPersona_GeneroRepository _persona_GeneroRepository;

        public Persona_GeneroController(IPersona_GeneroRepository persona_GeneroRepository)
        {
            _persona_GeneroRepository = persona_GeneroRepository;
        }

        readonly IPersona_GeneroRepository persona_GeneroRepository = new Persona_GeneroRepository();
        public Persona_GeneroController()
        {
            _persona_GeneroRepository = persona_GeneroRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPersona_Genero()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _persona_GeneroRepository.GetAllPersona_Genero();

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
        public IHttpActionResult GetPersona_GeneroDetails(int id_genero)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _persona_GeneroRepository.GetPersona_GeneroDetails(id_genero);

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
        public IHttpActionResult GetPersona_GeneroCodigo(string cd_nmgenero)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _persona_GeneroRepository.GetPersona_GeneroDetails(cd_nmgenero);

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
        public IHttpActionResult InsertPersona_Genero([FromBody] Persona_Genero persona_Genero)
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

                var created = _persona_GeneroRepository.InsertPersona_Genero(persona_Genero);

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
        public IHttpActionResult UpdatePersona_Genero([FromBody] Persona_Genero persona_Genero)
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

                var created = _persona_GeneroRepository.UpdatePersona_Genero(persona_Genero);

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
        public IHttpActionResult DeletePersona_Genero(int id_genero)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _persona_GeneroRepository.DeletePersona_Genero(id_genero);

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
