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
    public class Propuesta_AvalInternoController : BaseController<Propuesta_AvalInterno>
    {
        private readonly IPropuesta_AvalInternoRepository _propuesta_AvalInternoRepository;

        public Propuesta_AvalInternoController(IPropuesta_AvalInternoRepository propuesta_AvalInternoRepository)
        {
            _propuesta_AvalInternoRepository = propuesta_AvalInternoRepository;
        }

        readonly IPropuesta_AvalInternoRepository propuesta_AvalInternoRepository = new Propuesta_AvalInternoRepository();
        public Propuesta_AvalInternoController()
        {
            _propuesta_AvalInternoRepository = propuesta_AvalInternoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPropuesta_AvalInterno()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_AvalInternoRepository.GetAllPropuesta_AvalInterno();

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
        public IHttpActionResult GetPropuesta_AvalInternoDetails(int id_avalinterno)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_AvalInternoRepository.GetPropuesta_AvalInternoDetails(id_avalinterno);

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
        public IHttpActionResult GetPropuesta_AvalInternoDetails(string cd_avalinterno)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_AvalInternoRepository.GetPropuesta_AvalInternoDetails(cd_avalinterno);

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
        public IHttpActionResult InsertPropuesta_AvalInterno([FromBody] Propuesta_AvalInterno propuesta_AvalInterno)
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

                var created = _propuesta_AvalInternoRepository.InsertPropuesta_AvalInterno(propuesta_AvalInterno);

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
        public IHttpActionResult UpdatePropuesta_AvalInterno([FromBody] Propuesta_AvalInterno propuesta_AvalInterno)
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

                var created = _propuesta_AvalInternoRepository.UpdatePropuesta_AvalInterno(propuesta_AvalInterno);

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
        public IHttpActionResult DeletePropuesta_AvalInterno(int id_avalinterno)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _propuesta_AvalInternoRepository.DeletePropuesta_AvalInterno(id_avalinterno);

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
