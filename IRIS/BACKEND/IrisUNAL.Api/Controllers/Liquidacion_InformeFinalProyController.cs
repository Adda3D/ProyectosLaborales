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
    public class Liquidacion_InformeFinalProyController : BaseController<Liquidacion_InformeFinalProy>
    {
        private readonly ILiquidacion_InformeFinalProyRepository _liquidacion_InformeFinalProyRepository;

        public Liquidacion_InformeFinalProyController(ILiquidacion_InformeFinalProyRepository liquidacion_InformeFinalProyRepository)
        {
            _liquidacion_InformeFinalProyRepository = liquidacion_InformeFinalProyRepository;
        }

        readonly ILiquidacion_InformeFinalProyRepository liquidacion_InformeFinalProyRepository = new Liquidacion_InformeFinalProyRepository();
        public Liquidacion_InformeFinalProyController()
        {
            _liquidacion_InformeFinalProyRepository = liquidacion_InformeFinalProyRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllLiquidacion_InformeFinalProy()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _liquidacion_InformeFinalProyRepository.GetAllLiquidacion_InformeFinalProy();

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
        public IHttpActionResult GetLiquidacion_InformeFinalProyDetails(int id_informefinalproy)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _liquidacion_InformeFinalProyRepository.GetLiquidacion_InformeFinalProyDetails(id_informefinalproy);

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
        public IHttpActionResult GetLiquidacion_InformeFinalProyNombre(string cd_nominformefinalproy)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _liquidacion_InformeFinalProyRepository.GetLiquidacion_InformeFinalProyNombre(cd_nominformefinalproy);

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
        public IHttpActionResult InsertLiquidacion_InformeFinalProy([FromBody] Liquidacion_InformeFinalProy liquidacion_InformeFinalProy)
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

                var created = _liquidacion_InformeFinalProyRepository.InsertLiquidacion_InformeFinalProy(liquidacion_InformeFinalProy);

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
        public IHttpActionResult UpdateLiquidacion_InformeFinalProy([FromBody] Liquidacion_InformeFinalProy liquidacion_InformeFinalProy)
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

                var created = _liquidacion_InformeFinalProyRepository.UpdateLiquidacion_InformeFinalProy(liquidacion_InformeFinalProy);

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
        public IHttpActionResult DeleteLiquidacion_InformeFinalProy(int id_informefinalproy)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _liquidacion_InformeFinalProyRepository.DeleteLiquidacion_InformeFinalProy(id_informefinalproy);

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
