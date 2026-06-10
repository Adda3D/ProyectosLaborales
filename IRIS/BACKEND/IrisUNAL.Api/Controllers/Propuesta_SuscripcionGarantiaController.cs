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
    public class Propuesta_SuscripcionGarantiaController : BaseController<Propuesta_SuscripcionGarantia>
    {
        private readonly IPropuesta_SuscripcionGarantiaRepository _propuesta_SuscripcionGarantiaRepository;

        public Propuesta_SuscripcionGarantiaController(IPropuesta_SuscripcionGarantiaRepository propuesta_SuscripcionGarantiaRepository)
        {
            _propuesta_SuscripcionGarantiaRepository = propuesta_SuscripcionGarantiaRepository;
        }

        readonly IPropuesta_SuscripcionGarantiaRepository propuesta_SuscripcionGarantiaRepository = new Propuesta_SuscripcionGarantiaRepository();
        public Propuesta_SuscripcionGarantiaController()
        {
            _propuesta_SuscripcionGarantiaRepository = propuesta_SuscripcionGarantiaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPropuesta_SuscripcionGarantia()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_SuscripcionGarantiaRepository.GetAllPropuesta_SuscripcionGarantia();

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
        public IHttpActionResult GetPropuesta_SuscripcionGarantiaDetails(int id_suscripciongarantia)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_SuscripcionGarantiaRepository.GetPropuesta_SuscripcionGarantiaDetails(id_suscripciongarantia);

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
        public IHttpActionResult GetPropuesta_SuscripcionGarantiaPoliza(string cd_numeropoliza)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_SuscripcionGarantiaRepository.GetPropuesta_SuscripcionGarantiaPoliza(cd_numeropoliza);

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
        public IHttpActionResult InsertPropuesta_SuscripcionGarantia([FromBody] Propuesta_SuscripcionGarantia propuesta_SuscripcionGarantia)
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

                var created = _propuesta_SuscripcionGarantiaRepository.InsertPropuesta_SuscripcionGarantia(propuesta_SuscripcionGarantia);

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
        public IHttpActionResult UpdatePropuesta_SuscripcionGarantia([FromBody] Propuesta_SuscripcionGarantia propuesta_SuscripcionGarantia)
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

                var created = _propuesta_SuscripcionGarantiaRepository.UpdatePropuesta_SuscripcionGarantia(propuesta_SuscripcionGarantia);

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
        public IHttpActionResult DeletePropuesta_SuscripcionGarantia(int id_suscripciongarantia)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _propuesta_SuscripcionGarantiaRepository.DeletePropuesta_SuscripcionGarantia(id_suscripciongarantia);

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
        public IHttpActionResult GetPropuesta_SuscripcionGarantiaByPropuesta(int idpropuesta)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_SuscripcionGarantiaRepository.GetPropuesta_SuscripcionGarantiaByPropuesta(idpropuesta);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "No tiene garantía asignada";
                }

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
