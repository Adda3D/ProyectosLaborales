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
    public class Persona_TipoEntidadController : BaseController<Persona_TipoEntidad>
    {
        private readonly IPersona_TipoEntidadRepository _persona_TipoEntidadRepository;

        public Persona_TipoEntidadController(IPersona_TipoEntidadRepository persona_TipoEntidadRepository)
        {
            _persona_TipoEntidadRepository = persona_TipoEntidadRepository;
        }

        readonly IPersona_TipoEntidadRepository persona_TipoEntidadRepository = new Persona_TipoEntidadRepository();
        public Persona_TipoEntidadController()
        {
            _persona_TipoEntidadRepository = persona_TipoEntidadRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPersona_TipoEntidad()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _persona_TipoEntidadRepository.GetAllPersona_TipoEntidad();

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
        public IHttpActionResult GetPersona_TipoEntidadDetails(int id_tipoentidad)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _persona_TipoEntidadRepository.GetPersona_TipoEntidadDetails(id_tipoentidad);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Persona_TipoEntidad inexistente";
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
        public IHttpActionResult GetPersona_TipoEntidadNombre(string cd_nmtipoent)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _persona_TipoEntidadRepository.GetPersona_TipoEntidadNombre(cd_nmtipoent);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Persona_TipoEntidad inexistente";
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
        public IHttpActionResult InsertPersona_TipoEntidad([FromBody] Persona_TipoEntidad persona_TipoEntidad)
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

                var created = _persona_TipoEntidadRepository.InsertPersona_TipoEntidad(persona_TipoEntidad);

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
        public IHttpActionResult UpdatePersona_TipoEntidad([FromBody] Persona_TipoEntidad persona_TipoEntidad)
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

                var created = _persona_TipoEntidadRepository.UpdatePersona_TipoEntidad(persona_TipoEntidad);

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
        public IHttpActionResult DeletePersona_TipoEntidad(int id_tipoentidad)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _persona_TipoEntidadRepository.DeletePersona_TipoEntidad(id_tipoentidad);

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
        public IHttpActionResult GetDataTablePersona_TipoEntidad()
        {
            DataTableAdapter<Persona_TipoEntidad> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = persona_TipoEntidadRepository.GetDataTablePersona_TipoEntidad(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
