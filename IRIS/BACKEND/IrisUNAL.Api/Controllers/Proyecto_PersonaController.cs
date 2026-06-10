using IrisUNAL.Api.Entities.Repositories;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IrisUNAL.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Proyecto_PersonaController : BaseController<Proyecto_Persona>
    {
        private readonly IProyecto_PersonaRepository _proyectoPersonaRepository;
        public Proyecto_PersonaController(IProyecto_PersonaRepository proyecto_PersonaRepository)
        {
            _proyectoPersonaRepository = proyecto_PersonaRepository;
        }
        readonly IProyecto_PersonaRepository proyecto_PersonaRepository = new Proyecto_PersonaRepository();
        public Proyecto_PersonaController()
        {
            _proyectoPersonaRepository = proyecto_PersonaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllProyecto_Persona()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectoPersonaRepository.GetAllProyecto_Persona();

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
        public IHttpActionResult GetProyecto_PersonaDetails(int id_proyectopersona)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectoPersonaRepository.GetProyecto_PersonaDetails(id_proyectopersona);

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
        public IHttpActionResult GetProyecto_PersonaByProyectoTipoPersona(int id_proyecto, int id_tipo, int id_persona)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectoPersonaRepository.GetProyecto_PersonaByProyectoTipoPersona(id_proyecto, id_tipo, id_persona);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Persona no asociada al Proyecto ";
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
        public IHttpActionResult InsertProyecto_Persona([FromBody] Proyecto_Persona proyecto_Persona)
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

                var created = _proyectoPersonaRepository.InsertProyecto_Persona(proyecto_Persona);

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
        public IHttpActionResult UpdateProyecto_Persona([FromBody] Proyecto_Persona proyecto_Persona)
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

                var created = _proyectoPersonaRepository.UpdateProyecto_Persona(proyecto_Persona);

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
        public IHttpActionResult DeleteProyecto_Persona(int id_proyectopersona)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _proyectoPersonaRepository.DeleteProyecto_Persona(id_proyectopersona);

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
        public IHttpActionResult GetDataTableProyectos_PersonaByProyecto(int id_asignacionproyecto, int id_tipoproyecto)
        {
            DataTableAdapter<Proyecto_Persona> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _proyectoPersonaRepository.GetDataTableProyectos_PersonaByProyecto(id_asignacionproyecto, id_tipoproyecto, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

    }
}
