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
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class DecVie_ControlFinancieroController : BaseController<DecVie_ControlFinanciero>
    {
        private readonly IDecVie_ControlFinancieroRepository _decVie_ControlFinancieroRepository;
        public DecVie_ControlFinancieroController(IDecVie_ControlFinancieroRepository decVie_ControlFinancieroRepository)
        {
            _decVie_ControlFinancieroRepository = decVie_ControlFinancieroRepository;
        }
        readonly IDecVie_ControlFinancieroRepository decVie_ControlFinancieroRepository = new DecVie_ControlFinancieroRepository();
        public DecVie_ControlFinancieroController()
        {
            _decVie_ControlFinancieroRepository = decVie_ControlFinancieroRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_ControlFinanciero()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ControlFinancieroRepository.GetAllDecVie_ControlFinanciero();

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
        public IHttpActionResult GetDecVie_ControlFinancieroDetails(int id_controlfinanciero)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ControlFinancieroRepository.GetDecVie_ControlFinancieroDetails(id_controlfinanciero);

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
        public IHttpActionResult GetDecVie_ControlFinancieroNombre(string cd_nmpresupuesto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ControlFinancieroRepository.GetDecVie_ControlFinancieroNombre(cd_nmpresupuesto);

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
        public IHttpActionResult InsertDecVie_ControlFinanciero([FromBody] DecVie_ControlFinanciero decVie_ControlFinanciero)
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

                var created = decVie_ControlFinancieroRepository.InsertDecVie_ControlFinanciero(decVie_ControlFinanciero);

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
        public IHttpActionResult UpdateDecVie_ControlFinanciero([FromBody] DecVie_ControlFinanciero decVie_ControlFinanciero)
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

                var created = decVie_ControlFinancieroRepository.UpdateDecVie_ControlFinanciero(decVie_ControlFinanciero);

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
        public IHttpActionResult DeleteDecVie_ControlFinanciero(int id_controlfinanciero)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_ControlFinancieroRepository.DeleteDecVie_ControlFinanciero(id_controlfinanciero);

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
