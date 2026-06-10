using IrisUNAL.Api.Entities.Repositories;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
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
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class TareasController : BaseController<Tareas>
    {
        public readonly ITareasRepository _tareasRepository;
        private TareasController(ITareasRepository tareasRepository)
        {
            _tareasRepository = tareasRepository;
        }
        readonly ITareasRepository tareasRepository = new TareasRepository();
        public TareasController()
        {
            _tareasRepository = tareasRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllTareas()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _tareasRepository.GetAllTareas();

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
        public IHttpActionResult GetTareasDetails(int id_tarea)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _tareasRepository.GetTareasDetails(id_tarea);

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
        public IHttpActionResult InsertTareas([FromBody] Tareas tareas)
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

                var created = _tareasRepository.InsertTareas(tareas);

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
        public IHttpActionResult UpdateTareas([FromBody] Tareas tareas)
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

                var created = _tareasRepository.UpdateTareas(tareas);

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
        public IHttpActionResult UpdateTareaEstadoAvance(TareasEstadoAvanceDTO tarea)
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

                var created = _tareasRepository.UpdateTareaEstadoAvance(tarea);

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
        public IHttpActionResult DeleteTareas(int id_tarea)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _tareasRepository.DeleteTareas(id_tarea);

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
        public IHttpActionResult GetDataTableTareasByFuncionarioEstado(string idfuncionario, int id_estadotarea)
        {
            DataTableAdapter<Tareas> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _tareasRepository.GetDataTableTareasByFuncionarioEstado(idfuncionario, id_estadotarea, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }

        [HttpGet]
        public IHttpActionResult GetDataTableTareasByModuloRelacionado(int idtareamodulo, int idrelacionado)
        {
            DataTableAdapter<Tareas> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _tareasRepository.GetDataTableTareasByModuloRelacionado(idtareamodulo, idrelacionado, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }

        [HttpGet]
        public IHttpActionResult GetDataTableTareasByRelacioncon(string relacioncon, int idrelacionado)
        {
            DataTableAdapter<Tareas> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _tareasRepository.GetDataTableTareasByRelacioncon(relacioncon, idrelacionado, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }

        [HttpGet]
        public IHttpActionResult GetDataTableTareasByAsignadoPorEstado(string asignadopor, int id_estadotarea)
        {
            DataTableAdapter<Tareas> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _tareasRepository.GetDataTableTareasByAsignadoPorEstado(asignadopor, id_estadotarea, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }


    }
}
