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
    public class Propuesta_OrigenPropuestaController : BaseController<Propuesta_OrigenPropuesta>
    {
        private readonly IPropuesta_OrigenPropuestaRepository _propuesta_OrigenPropuestaRepository;

        public Propuesta_OrigenPropuestaController(IPropuesta_OrigenPropuestaRepository propuesta_OrigenPropuestaRepository)
        {
            _propuesta_OrigenPropuestaRepository = propuesta_OrigenPropuestaRepository;
        }

        readonly IPropuesta_OrigenPropuestaRepository propuesta_OrigenPropuestaRepository = new Propuesta_OrigenPropuestaRepository();
        public Propuesta_OrigenPropuestaController()
        {
            _propuesta_OrigenPropuestaRepository = propuesta_OrigenPropuestaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPropuesta_OrigenPropuesta()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_OrigenPropuestaRepository.GetAllPropuesta_OrigenPropuesta();

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
        public IHttpActionResult GetPropuesta_OrigenPropuestaDetails(int id_origenpropuesta)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_OrigenPropuestaRepository.GetPropuesta_OrigenPropuestaDetails(id_origenpropuesta);

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
        public IHttpActionResult GetPropuesta_OrigenPropuestaDetails(string cd_nmorigenpropuesta)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_OrigenPropuestaRepository.GetPropuesta_OrigenPropuestaDetails(cd_nmorigenpropuesta);

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
        public IHttpActionResult InsertPropuesta_OrigenPropuesta([FromBody] Propuesta_OrigenPropuesta propuesta_OrigenPropuesta)
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

                var created = _propuesta_OrigenPropuestaRepository.InsertPropuesta_OrigenPropuesta(propuesta_OrigenPropuesta);

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
        public IHttpActionResult UpdatePropuesta_OrigenPropuesta([FromBody] Propuesta_OrigenPropuesta propuesta_OrigenPropuesta)
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

                var created = _propuesta_OrigenPropuestaRepository.UpdatePropuesta_OrigenPropuesta(propuesta_OrigenPropuesta);

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
        public IHttpActionResult DeletePropuesta_OrigenPropuesta(int id_origenpropuesta)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _propuesta_OrigenPropuestaRepository.DeletePropuesta_OrigenPropuesta(id_origenpropuesta);

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
        public IHttpActionResult GetDataTablePropuestaOrigen()
        {
            DataTableAdapter<Propuesta_OrigenPropuesta> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _propuesta_OrigenPropuestaRepository.GetDataTablePropuestaOrigen(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

    }
}
