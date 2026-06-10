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
    public class Persona_TipoServicioController : BaseController<Persona_TipoServicio>
    {
        private readonly IPersona_TipoServicioRepository _persona_TipoServicioRepository;

        public Persona_TipoServicioController(IPersona_TipoServicioRepository persona_TipoServicioRepository)
        {
            _persona_TipoServicioRepository = persona_TipoServicioRepository;
        }

        readonly IPersona_TipoServicioRepository persona_TipoServicioRepository = new Persona_TipoServicioRepository();
        public Persona_TipoServicioController()
        {
            _persona_TipoServicioRepository = persona_TipoServicioRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPersona_TipoServicio()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _persona_TipoServicioRepository.GetAllPersona_TipoServicio();

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
        public IHttpActionResult GetPersona_TipoServicioDetails(int id_tiposervicio)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _persona_TipoServicioRepository.GetPersona_TipoServicioDetails(id_tiposervicio);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Persona_TipoServicio inexistente";
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
        public IHttpActionResult GetPersona_TipoServicioNombre(string cd_nmtiposerv)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _persona_TipoServicioRepository.GetPersona_TipoServicioNombre(cd_nmtiposerv);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Persona_TipoServicio inexistente";
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
        public IHttpActionResult InsertPersona_TipoServicio([FromBody] Persona_TipoServicio persona_TipoServicio)
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

                var created = _persona_TipoServicioRepository.InsertPersona_TipoServicio(persona_TipoServicio);

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
        public IHttpActionResult UpdatePersona_TipoServicio([FromBody] Persona_TipoServicio persona_TipoServicio)
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

                var created = _persona_TipoServicioRepository.UpdatePersona_TipoServicio(persona_TipoServicio);

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
        public IHttpActionResult DeletePersona_TipoServicio(int id_tiposervicio)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _persona_TipoServicioRepository.DeletePersona_TipoServicio(id_tiposervicio);

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
        public IHttpActionResult GetDataTablePersona_TipoServicio()
        {
            DataTableAdapter<Persona_TipoServicio> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = persona_TipoServicioRepository.GetDataTablePersona_TipoServicio(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
