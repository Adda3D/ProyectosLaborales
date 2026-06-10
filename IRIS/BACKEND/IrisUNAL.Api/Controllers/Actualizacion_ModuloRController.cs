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
    public class Actualizacion_ModuloRController : BaseController<Actualizacion_ModuloR>
    {
        private readonly IActualizacion_ModuloRRepository _actualizacion_ModuloRRepository;
        public Actualizacion_ModuloRController(IActualizacion_ModuloRRepository actualizacion_ModuloRRepository)
        {
            _actualizacion_ModuloRRepository = actualizacion_ModuloRRepository;
        }
        readonly IActualizacion_ModuloRRepository actualizacion_ModuloRRepository = new Actualizacion_ModuloRRepository();
        public Actualizacion_ModuloRController()
        {
            _actualizacion_ModuloRRepository = actualizacion_ModuloRRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllActualizacion_ModuloR()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _actualizacion_ModuloRRepository.GetAllActualizacion_ModuloR();

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
        public IHttpActionResult GetActualizacion_ModuloRDetails(int id_actualizacionmodulor)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _actualizacion_ModuloRRepository.GetActualizacion_ModuloRDetails(id_actualizacionmodulor);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Datos Módulo RUP inexistentes";
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
        public IHttpActionResult InsertActualizacion_ModuloR([FromBody] Actualizacion_ModuloR actualizacion_ModuloR)
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

                var created = _actualizacion_ModuloRRepository.InsertActualizacion_ModuloR(actualizacion_ModuloR);

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
        public IHttpActionResult UpdateActualizacion_ModuloR([FromBody] Actualizacion_ModuloR actualizacion_ModuloR)
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

                var created = _actualizacion_ModuloRRepository.UpdateActualizacion_ModuloR(actualizacion_ModuloR);

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
        public IHttpActionResult DeleteActualizacion_ModuloR(int id_actualizacionmodulor)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _actualizacion_ModuloRRepository.DeleteActualizacion_ModuloR(id_actualizacionmodulor);

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
        public IHttpActionResult GetActualizacion_ModuloRByProyecto(int id_asignacionproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _actualizacion_ModuloRRepository.GetActualizacion_ModuloRByProyecto(id_asignacionproyecto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Proyecto no tiene datos Módulo RUP cargados";
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
