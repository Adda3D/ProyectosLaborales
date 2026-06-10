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
    public class Propuesta_SuscripcionMinutaController : BaseController<Propuesta_SuscripcionMinuta>
    {
        private readonly IPropuesta_SuscripcionMinutaRepository _propuesta_SuscripcionMinutaRepository;

        public Propuesta_SuscripcionMinutaController(IPropuesta_SuscripcionMinutaRepository propuesta_SuscripcionMinutaRepository)
        {
            _propuesta_SuscripcionMinutaRepository = propuesta_SuscripcionMinutaRepository;
        }

        readonly IPropuesta_SuscripcionMinutaRepository propuesta_SuscripcionMinutaRepository = new Propuesta_SuscripcionMinutaRepository();
        public Propuesta_SuscripcionMinutaController()
        {
            _propuesta_SuscripcionMinutaRepository = propuesta_SuscripcionMinutaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPropuesta_SuscripcionMinuta()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_SuscripcionMinutaRepository.GetAllPropuesta_SuscripcionMinuta();

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
        public IHttpActionResult GetPropuesta_SuscripcionMinutaDetails(int id_suscripcionminuta)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_SuscripcionMinutaRepository.GetPropuesta_SuscripcionMinutaDetails(id_suscripcionminuta);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Minuta inexistente";
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
        public IHttpActionResult GetPropuesta_SuscripcionMinutaNumMinuta(string numminuta)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_SuscripcionMinutaRepository.GetPropuesta_SuscripcionMinutaMinuta(numminuta);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Minuta inexistente";
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
        public IHttpActionResult GetPropuesta_SuscripcionMinutaByPropuesta(int idpropuesta)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_SuscripcionMinutaRepository.GetPropuesta_SuscripcionMinutaByPropuesta(idpropuesta);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "No tiene Minuta asignada";
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
        public IHttpActionResult InsertPropuesta_SuscripcionMinuta([FromBody] Propuesta_SuscripcionMinuta propuesta_SuscripcionMinuta)
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

                var created = _propuesta_SuscripcionMinutaRepository.InsertPropuesta_SuscripcionMinuta(propuesta_SuscripcionMinuta);

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
        public IHttpActionResult UpdatePropuesta_SuscripcionMinuta([FromBody] Propuesta_SuscripcionMinuta propuesta_SuscripcionMinuta)
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

                var created = _propuesta_SuscripcionMinutaRepository.UpdatePropuesta_SuscripcionMinuta(propuesta_SuscripcionMinuta);

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
        public IHttpActionResult DeletePropuesta_SuscripcionMinuta(int id_suscripcionminuta)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _propuesta_SuscripcionMinutaRepository.DeletePropuesta_SuscripcionMinuta(id_suscripcionminuta);

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
