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
    public class Tipo_PersonaController : BaseController<Tipo_Persona>
    {
        private readonly ITipo_PersonaRepository _tipo_PersonaRepository;

        public Tipo_PersonaController(ITipo_PersonaRepository tipo_PersonaRepository)
        {
            _tipo_PersonaRepository = tipo_PersonaRepository;
        }

        readonly ITipo_PersonaRepository tipo_PersonaRepository = new Tipo_PersonaRepository();
        public Tipo_PersonaController()
        {
            _tipo_PersonaRepository = tipo_PersonaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllTipo_Persona()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _tipo_PersonaRepository.GetAllTipo_Persona();

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
        public IHttpActionResult GetTipo_PersonaDetails(int id_tipopersona)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _tipo_PersonaRepository.GetTipo_PersonaDetails(id_tipopersona);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Tipo_Persona inexistente";
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
        public IHttpActionResult GetTipo_PersonaNombre(string cd_nmtipoper)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _tipo_PersonaRepository.GetTipo_PersonaNombre(cd_nmtipoper);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Tipo_Persona inexistente";
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
        public IHttpActionResult InsertTipo_Persona([FromBody] Tipo_Persona tipo_Persona)
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

                var created = _tipo_PersonaRepository.InsertTipo_Persona(tipo_Persona);

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
        public IHttpActionResult UpdateTipo_Persona([FromBody] Tipo_Persona tipo_Persona)
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

                var created = _tipo_PersonaRepository.UpdateTipo_Persona(tipo_Persona);

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
        public IHttpActionResult DeleteTipo_Persona(int id_tipopersona)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _tipo_PersonaRepository.DeleteTipo_Persona(id_tipopersona);

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
        public IHttpActionResult GetDataTableTipo_Persona()
        {
            DataTableAdapter<Tipo_Persona> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _tipo_PersonaRepository.GetDataTableTipo_Persona(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
