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
    public class Persona_TituloAltoController : BaseController<Persona_TituloAlto>
    {
        private readonly IPersona_TituloAltoRepository _persona_TituloAltoRepository;

        public Persona_TituloAltoController(IPersona_TituloAltoRepository persona_TituloAltoRepository)
        {
            _persona_TituloAltoRepository = persona_TituloAltoRepository;
        }

        readonly IPersona_TituloAltoRepository persona_TituloAltoRepository = new Persona_TituloAltoRepository();
        public Persona_TituloAltoController()
        {
            _persona_TituloAltoRepository = persona_TituloAltoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPersona_TituloAlto()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _persona_TituloAltoRepository.GetAllPersona_TituloAlto();

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
        public IHttpActionResult GetPersona_TituloAltoDetails(int id_tituloalto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _persona_TituloAltoRepository.GetPersona_TituloAltoDetails(id_tituloalto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Persona_TituloAlto inexistente";
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
        public IHttpActionResult GetPersona_TituloAltoDetails(string cd_nmtituloalto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _persona_TituloAltoRepository.GetPersona_TituloAltoDetails(cd_nmtituloalto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Persona_TituloAlto inexistente";
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
        public IHttpActionResult InsertPersona_TituloAlto([FromBody] Persona_TituloAlto persona_TituloAlto)
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

                var created = _persona_TituloAltoRepository.InsertPersona_TituloAlto(persona_TituloAlto);

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
        public IHttpActionResult UpdatePersona_TituloAlto([FromBody] Persona_TituloAlto persona_TituloAlto)
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

                var created = _persona_TituloAltoRepository.UpdatePersona_TituloAlto(persona_TituloAlto);

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
        public IHttpActionResult DeletePersona_TituloAlto(int id_tituloalto)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _persona_TituloAltoRepository.DeletePersona_TituloAlto(id_tituloalto);

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
        public IHttpActionResult GetDataTablePersona_TituloAlto()
        {
            DataTableAdapter<Persona_TituloAlto> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = persona_TituloAltoRepository.GetDataTablePersona_TituloAlto(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
