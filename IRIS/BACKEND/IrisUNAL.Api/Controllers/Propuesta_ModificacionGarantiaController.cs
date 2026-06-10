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
    public class Propuesta_ModificacionGarantiaController : BaseController<Propuesta_ModificacionGarantia>
    {
        private readonly IPropuesta_ModificacionGarantiaRepository _propuesta_ModificacionGarantiaRepository;

        public Propuesta_ModificacionGarantiaController(IPropuesta_ModificacionGarantiaRepository propuesta_ModificacionGarantiaRepository)
        {
            _propuesta_ModificacionGarantiaRepository = propuesta_ModificacionGarantiaRepository;
        }

        readonly IPropuesta_ModificacionGarantiaRepository propuesta_ModificacionGarantiaRepository = new Propuesta_ModificacionGarantiaRepository();
        public Propuesta_ModificacionGarantiaController()
        {
            _propuesta_ModificacionGarantiaRepository = propuesta_ModificacionGarantiaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPropuesta_ModificacionGarantia()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_ModificacionGarantiaRepository.GetAllPropuesta_ModificacionGarantia();

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
        public IHttpActionResult GetPropuesta_ModificacionGarantiaDetails(int id_modificaciongarantia)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_ModificacionGarantiaRepository.GetPropuesta_ModificacionGarantiaDetails(id_modificaciongarantia);

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
        public IHttpActionResult GetPropuesta_ModificacionGarantiaPoliza(int id_suscripciongarantia)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_ModificacionGarantiaRepository.GetPropuesta_ModificacionGarantiaPoliza(id_suscripciongarantia);

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
        public IHttpActionResult InsertPropuesta_ModificacionGarantia([FromBody] Propuesta_ModificacionGarantia propuesta_ModificacionGarantia)
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

                var created = _propuesta_ModificacionGarantiaRepository.InsertPropuesta_ModificacionGarantia(propuesta_ModificacionGarantia);

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
        public IHttpActionResult UpdatePropuesta_ModificacionGarantia([FromBody] Propuesta_ModificacionGarantia propuesta_ModificacionGarantia)
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

                var created = _propuesta_ModificacionGarantiaRepository.UpdatePropuesta_ModificacionGarantia(propuesta_ModificacionGarantia);

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
        public IHttpActionResult DeletePropuesta_ModificacionGarantia(int id_modificaciongarantia)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _propuesta_ModificacionGarantiaRepository.DeletePropuesta_ModificacionGarantia(id_modificaciongarantia);

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
        public IHttpActionResult GetDataTablePropuestaModificacionGarantiaByGarantia(int id_suscripciongarantia)
        {
            DataTableAdapter<Propuesta_ModificacionGarantia> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _propuesta_ModificacionGarantiaRepository.GetDataTablePropuestaModificacionGarantiaByGarantia(id_suscripciongarantia, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetDataTablePropuestaModificacionGarantiaByPropuesta(int id_propuesta)
        {
            DataTableAdapter<Propuesta_ModificacionGarantia> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _propuesta_ModificacionGarantiaRepository.GetDataTablePropuestaModificacionGarantiaByPropuesta(id_propuesta, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

    }
}
