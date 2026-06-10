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
    public class Proyectos_ProyectosObservacionesController : BaseController<Proyectos_ProyectosObservaciones>
    {
        private readonly IProyectos_ProyectosObservacionesRepository _proyectos_ProyectosObservacionesRepository;

        public Proyectos_ProyectosObservacionesController(IProyectos_ProyectosObservacionesRepository proyectos_ProyectosObservacionesRepository)
        {
            _proyectos_ProyectosObservacionesRepository = proyectos_ProyectosObservacionesRepository;
        }

        readonly IProyectos_ProyectosObservacionesRepository proyectos_ProyectosObservacionesRepository = new Proyectos_ProyectosObservacionesRepository();
        public Proyectos_ProyectosObservacionesController()
        {
            _proyectos_ProyectosObservacionesRepository = proyectos_ProyectosObservacionesRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllProyectos_ProyectosObservaciones()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_ProyectosObservacionesRepository.GetAllProyectos_ProyectosObservaciones();

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
        public IHttpActionResult GetProyectos_ProyectosObservacionesDetails(int id_proyectosobservaciones)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_ProyectosObservacionesRepository.GetProyectos_ProyectosObservacionesDetails(id_proyectosobservaciones);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Obligación proyecto inexistente";
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
        public IHttpActionResult GetProyectos_ProyectosObservacionesDescripcion(string cd_descripcion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_ProyectosObservacionesRepository.GetProyectos_ProyectosObservacionesDescripcion(cd_descripcion);

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
        public IHttpActionResult InsertProyectos_ProyectosObservaciones([FromBody] Proyectos_ProyectosObservaciones proyectos_ProyectosObservaciones)
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

                var created = _proyectos_ProyectosObservacionesRepository.InsertProyectos_ProyectosObservaciones(proyectos_ProyectosObservaciones);

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
        public IHttpActionResult UpdateProyectos_ProyectosObservaciones([FromBody] Proyectos_ProyectosObservaciones proyectos_ProyectosObservaciones)
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

                var created = _proyectos_ProyectosObservacionesRepository.UpdateProyectos_ProyectosObservaciones(proyectos_ProyectosObservaciones);

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
        public IHttpActionResult DeleteProyectos_ProyectosObservaciones(int id_proyectosobservaciones)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _proyectos_ProyectosObservacionesRepository.DeleteProyectos_ProyectosObservaciones(id_proyectosobservaciones);

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
        public IHttpActionResult GetDataTableProyectos_ObservacionesByProyecto(int id_asignacionproyecto)
        {
            DataTableAdapter<Proyectos_ProyectosObservaciones> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _proyectos_ProyectosObservacionesRepository.GetDataTableProyectos_Observaciones(id_asignacionproyecto, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
