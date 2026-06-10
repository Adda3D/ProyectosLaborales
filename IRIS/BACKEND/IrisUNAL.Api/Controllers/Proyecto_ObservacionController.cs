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
    public class Proyecto_ObservacionController : BaseController<Proyecto_Observacion>
    {
        private readonly IProyecto_ObservacionRepository _proyecto_ObservacionRepository;
        public Proyecto_ObservacionController(IProyecto_ObservacionRepository proyecto_ObservacionRepository)
        {
            _proyecto_ObservacionRepository = proyecto_ObservacionRepository;
        }
        readonly IProyecto_ObservacionRepository proyecto_ObservacionRepository = new Proyecto_ObservacionRepository();
        public Proyecto_ObservacionController()
        {
            _proyecto_ObservacionRepository = proyecto_ObservacionRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllProyecto_Observacion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyecto_ObservacionRepository.GetAllProyecto_Observacion();

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
        public IHttpActionResult GetProyecto_ObservacionDetails(int id_proyectoobservacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyecto_ObservacionRepository.GetProyecto_ObservacionDetails(id_proyectoobservacion);

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
        public IHttpActionResult InsertProyecto_Observacion([FromBody] Proyecto_Observacion proyecto_Observacion)
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

                var created = _proyecto_ObservacionRepository.InsertProyecto_Observacion(proyecto_Observacion);

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
        public IHttpActionResult UpdateProyecto_Observacion([FromBody] Proyecto_Observacion proyecto_Observacion)
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

                var created = _proyecto_ObservacionRepository.UpdateProyecto_Observacion(proyecto_Observacion);

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
        public IHttpActionResult DeleteProyecto_Observacion(int id_proyectoobservacion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _proyecto_ObservacionRepository.DeleteProyecto_Observacion(id_proyectoobservacion);

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
