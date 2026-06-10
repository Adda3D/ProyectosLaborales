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
    public class Liquidacion_FinalizacionController : BaseController<Liquidacion_Finalizacion>
    {
        private readonly ILiquidacion_FinalizacionRepository _liquidacion_FinalizacionRepository;
        public Liquidacion_FinalizacionController(ILiquidacion_FinalizacionRepository liquidacion_FinalizacionRepository)
        {
            _liquidacion_FinalizacionRepository = liquidacion_FinalizacionRepository;
        }
        readonly ILiquidacion_FinalizacionRepository liquidacion_FinalizacionRepository = new Liquidacion_FinalizacionRepository();
        public Liquidacion_FinalizacionController()
        {
            _liquidacion_FinalizacionRepository = liquidacion_FinalizacionRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllLiquidacion_Finalizacion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _liquidacion_FinalizacionRepository.GetAllLiquidacion_Finalizacion();

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
        public IHttpActionResult GetLiquidacion_FinalizacionDetails(int id_liqfinalizacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _liquidacion_FinalizacionRepository.GetLiquidacion_FinalizacionDetails(id_liqfinalizacion);

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
        public IHttpActionResult InsertLiquidacion_Finalizacion([FromBody] Liquidacion_Finalizacion liquidacion_Finalizacion)
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

                var created = _liquidacion_FinalizacionRepository.InsertLiquidacion_Finalizacion(liquidacion_Finalizacion);

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
        public IHttpActionResult UpdateLiquidacion_Finalizacion([FromBody] Liquidacion_Finalizacion liquidacion_Finalizacion)
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

                var created = _liquidacion_FinalizacionRepository.UpdateLiquidacion_Finalizacion(liquidacion_Finalizacion);

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
        public IHttpActionResult DeleteLiquidacion_Finalizacion(int id_liqfinalizacion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _liquidacion_FinalizacionRepository.DeleteLiquidacion_Finalizacion(id_liqfinalizacion);

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
        public IHttpActionResult GetLiquidacion_FinalizacionByProyecto(int id_asignacionproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _liquidacion_FinalizacionRepository.GetLiquidacion_FinalizacionByProyecto(id_asignacionproyecto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Proyecto no tiene datos de liquidación cargados";
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
