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
    public class Suscripcion_LiquidacionController : BaseController<Suscripcion_Liquidacion>
    {
        private readonly ISuscripcion_LiquidacionRepository _suscripcion_LiquidacionRepository;
        public Suscripcion_LiquidacionController (ISuscripcion_LiquidacionRepository suscripcion_LiquidacionRepository)
        {
            _suscripcion_LiquidacionRepository = suscripcion_LiquidacionRepository;
        }
        readonly ISuscripcion_LiquidacionRepository suscripcion_LiquidacionRepository = new Suscripcion_LiquidacionRepository();
        public Suscripcion_LiquidacionController()
        {
            _suscripcion_LiquidacionRepository = suscripcion_LiquidacionRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllSuscripcion_Liquidacion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _suscripcion_LiquidacionRepository.GetAllSuscripcion_Liquidacion();

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
        public IHttpActionResult GetSuscripcion_LiquidacionDetails(int id_suscripcionliquidcion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _suscripcion_LiquidacionRepository.GetSuscripcion_LiquidacionDetails(id_suscripcionliquidcion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Proyecto Inexistente";
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
        public IHttpActionResult InsertSuscripcion_Liquidacion([FromBody] Suscripcion_Liquidacion suscripcion_Liquidacion)
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

                var created = _suscripcion_LiquidacionRepository.InsertSuscripcion_Liquidacion(suscripcion_Liquidacion);

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
        public IHttpActionResult UpdateSuscripcion_Liquidacion([FromBody] Suscripcion_Liquidacion suscripcion_Liquidacion)
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

                var created = _suscripcion_LiquidacionRepository.UpdateSuscripcion_Liquidacion(suscripcion_Liquidacion);

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
        public IHttpActionResult DeleteSuscripcion_Liquidacion(int id_suscripcionliquidcion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _suscripcion_LiquidacionRepository.DeleteSuscripcion_Liquidacion(id_suscripcionliquidcion);

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
        public IHttpActionResult GetSuscripcion_LiquidacionByProyecto(int id_asignacionproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _suscripcion_LiquidacionRepository.GetSuscripcion_LiquidacionByProyecto(id_asignacionproyecto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Proyecto no tiene datos Acta de Liquidación cargados";
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
