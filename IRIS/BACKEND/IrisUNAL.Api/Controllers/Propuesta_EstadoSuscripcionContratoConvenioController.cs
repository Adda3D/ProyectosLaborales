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
    public class Propuesta_EstadoSuscripcionContratoConvenioController : BaseController<Propuesta_EstadoSuscripcionContratoConvenio>
    {
        private readonly IPropuesta_EstadoSuscripcionContratoConvenioRepository _propuesta_EstadoSuscripcionContratoConvenioRepository;

        public Propuesta_EstadoSuscripcionContratoConvenioController(IPropuesta_EstadoSuscripcionContratoConvenioRepository propuesta_EstadoSuscripcionContratoConvenioRepository)
        {
            _propuesta_EstadoSuscripcionContratoConvenioRepository = propuesta_EstadoSuscripcionContratoConvenioRepository;
        }

        readonly IPropuesta_EstadoSuscripcionContratoConvenioRepository propuesta_EstadoSuscripcionContratoConvenioRepository = new Propuesta_EstadoSuscripcionContratoConvenioRepository();
        public Propuesta_EstadoSuscripcionContratoConvenioController()
        {
            _propuesta_EstadoSuscripcionContratoConvenioRepository = propuesta_EstadoSuscripcionContratoConvenioRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPropuesta_EstadoSuscripcionContratoConvenio()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_EstadoSuscripcionContratoConvenioRepository.GetAllPropuesta_EstadoSuscripcionContratoConvenio();

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
        public IHttpActionResult GetPropuesta_EstadoSuscripcionContratoConvenioDetails(int id_estadosuscripcioncontratoconvenio)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_EstadoSuscripcionContratoConvenioRepository.GetPropuesta_EstadoSuscripcionContratoConvenioDetails(id_estadosuscripcioncontratoconvenio);

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
        public IHttpActionResult GetPropuesta_EstadoSuscripcionContratoConvenioDetails(string cd_nmestadosuscripcioncontratoconvenio)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_EstadoSuscripcionContratoConvenioRepository.GetPropuesta_EstadoSuscripcionContratoConvenioDetails(cd_nmestadosuscripcioncontratoconvenio);

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
        public IHttpActionResult InsertPropuesta_EstadoSuscripcionContratoConvenio([FromBody] Propuesta_EstadoSuscripcionContratoConvenio propuesta_EstadoSuscripcionContratoConvenio)
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

                var created = _propuesta_EstadoSuscripcionContratoConvenioRepository.InsertPropuesta_EstadoSuscripcionContratoConvenio(propuesta_EstadoSuscripcionContratoConvenio);

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
        public IHttpActionResult UpdatePropuesta_EstadoSuscripcionContratoConvenio([FromBody] Propuesta_EstadoSuscripcionContratoConvenio propuesta_EstadoSuscripcionContratoConvenio)
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

                var created = _propuesta_EstadoSuscripcionContratoConvenioRepository.UpdatePropuesta_EstadoSuscripcionContratoConvenio(propuesta_EstadoSuscripcionContratoConvenio);

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
        public IHttpActionResult DeletePropuesta_EstadoSuscripcionContratoConvenio(int id_estadosuscripcioncontratoconvenio)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _propuesta_EstadoSuscripcionContratoConvenioRepository.DeletePropuesta_EstadoSuscripcionContratoConvenio(id_estadosuscripcioncontratoconvenio);

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
