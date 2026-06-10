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
    public class Propuesta_EstadoPropuestaController : BaseController<Propuesta_EstadoPropuesta>
    {
        private readonly IPropuesta_EstadoPropuestaRepository _propuesta_EstadoPropuestaRepository;

        public Propuesta_EstadoPropuestaController(IPropuesta_EstadoPropuestaRepository propuesta_EstadoPropuestaRepository)
        {
            _propuesta_EstadoPropuestaRepository = propuesta_EstadoPropuestaRepository;
        }

        readonly IPropuesta_EstadoPropuestaRepository propuesta_EstadoPropuestaRepository = new Propuesta_EstadoPropuestaRepository();
        public Propuesta_EstadoPropuestaController()
        {
            _propuesta_EstadoPropuestaRepository = propuesta_EstadoPropuestaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPropuesta_EstadoPropuesta()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_EstadoPropuestaRepository.GetAllPropuesta_EstadoPropuesta();

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
        public IHttpActionResult GetPropuesta_EstadoPropuestaDetails(int id_estadopropuesta)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_EstadoPropuestaRepository.GetPropuesta_EstadoPropuestaDetails(id_estadopropuesta);

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
        public IHttpActionResult GetPropuesta_EstadoPropuestaDetails(string cd_nmestadopropuesta)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_EstadoPropuestaRepository.GetPropuesta_EstadoPropuestaDetails(cd_nmestadopropuesta);

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
        public IHttpActionResult InsertPropuesta_EstadoPropuesta([FromBody] Propuesta_EstadoPropuesta propuesta_EstadoPropuesta)
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

                var created = _propuesta_EstadoPropuestaRepository.InsertPropuesta_EstadoPropuesta(propuesta_EstadoPropuesta);

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
        public IHttpActionResult UpdatePropuesta_EstadoPropuesta([FromBody] Propuesta_EstadoPropuesta propuesta_EstadoPropuesta)
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

                var created = _propuesta_EstadoPropuestaRepository.UpdatePropuesta_EstadoPropuesta(propuesta_EstadoPropuesta);

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
        public IHttpActionResult DeletePropuesta_EstadoPropuesta(int id_estadopropuesta)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _propuesta_EstadoPropuestaRepository.DeletePropuesta_EstadoPropuesta(id_estadopropuesta);

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
        public IHttpActionResult GetDataTablePropuestaEstado()
        {
            DataTableAdapter<Propuesta_EstadoPropuesta> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _propuesta_EstadoPropuestaRepository.GetDataTablePropuestaEstado(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

    }
}
