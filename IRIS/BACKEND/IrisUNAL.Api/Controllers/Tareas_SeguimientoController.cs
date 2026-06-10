using IrisUNAL.Api.Entities.Repositories;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IrisUNAL.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Tareas_SeguimientoController : BaseController<Tareas_Seguimiento>
    {
        private readonly Tareas_SeguimientoRepository _tareas_seguimientoRepository;
        public Tareas_SeguimientoController(Tareas_SeguimientoRepository tareas_seguimientoRepository)
        {
            _tareas_seguimientoRepository = tareas_seguimientoRepository;
        }
        readonly Tareas_SeguimientoRepository tareas_seguimientoRepository = new Tareas_SeguimientoRepository();
        public Tareas_SeguimientoController()
        {
            _tareas_seguimientoRepository = tareas_seguimientoRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllTareas_Seguimiento()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _tareas_seguimientoRepository.GetAllTareas_Seguimiento();

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
        public IHttpActionResult GetTareas_SeguimientoDetails(int idtareaseguimiento)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _tareas_seguimientoRepository.GetTareas_SeguimientoDetails(idtareaseguimiento);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Seguimiento inexistente";
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
        public IHttpActionResult InsertTareas_Seguimiento([FromBody] Tareas_Seguimiento tareas_seguimiento)
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

                var created = _tareas_seguimientoRepository.InsertTareas_Seguimiento(tareas_seguimiento);

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
        public IHttpActionResult UpdateTareas_Seguimiento([FromBody] Tareas_Seguimiento tareas_seguimiento)
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

                var created = _tareas_seguimientoRepository.UpdateTareas_Seguimiento(tareas_seguimiento);

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
        public IHttpActionResult DeleteTareas_Seguimiento(int idtareaseguimiento)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _tareas_seguimientoRepository.DeleteTareas_Seguimiento(idtareaseguimiento);

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
        public IHttpActionResult GetDataTableTareas_SeguimientoByTarea(int id_tarea)
        {
            DataTableAdapter<Tareas_Seguimiento> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _tareas_seguimientoRepository.GetDataTableTareas_SeguimientoByTarea(id_tarea, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
