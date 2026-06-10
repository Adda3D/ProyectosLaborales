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
    public class Proyectos_ObligacionesController : BaseController<Proyectos_Obligaciones>
    {
        private readonly IProyectos_ObligacionesRepository _proyectos_ObligacionesRepository;

        public Proyectos_ObligacionesController(IProyectos_ObligacionesRepository proyectos_ObligacionesRepository)
        {
            _proyectos_ObligacionesRepository = proyectos_ObligacionesRepository;
        }

        readonly IProyectos_ObligacionesRepository proyectos_ObligacionesRepository = new Proyectos_ObligacionesRepository();
        public Proyectos_ObligacionesController()
        {
            _proyectos_ObligacionesRepository = proyectos_ObligacionesRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllProyectos_Obligaciones()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_ObligacionesRepository.GetAllProyectos_Obligaciones();

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
        public IHttpActionResult GetAllProyectos_ObligacionesByProyecto(int id_asignacionproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_ObligacionesRepository.GetAllProyectos_ObligacionesByProyecto(id_asignacionproyecto);

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
        public IHttpActionResult GetProyectos_ObligacionesDetails(int id_proyectoobligaciones)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_ObligacionesRepository.GetProyectos_ObligacionesDetails(id_proyectoobligaciones);

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
        public IHttpActionResult GetProyectos_ObligacionesNombre(string cd_obligacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_ObligacionesRepository.GetProyectos_ObligacionesNombre(cd_obligacion);

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
        public IHttpActionResult InsertProyectos_Obligaciones([FromBody] Proyectos_Obligaciones proyectos_Obligaciones)
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

                var created = _proyectos_ObligacionesRepository.InsertProyectos_Obligaciones(proyectos_Obligaciones);

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
        public IHttpActionResult UpdateProyectos_Obligaciones([FromBody] Proyectos_Obligaciones proyectos_Obligaciones)
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

                var created = _proyectos_ObligacionesRepository.UpdateProyectos_Obligaciones(proyectos_Obligaciones);

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
        public IHttpActionResult DeleteProyectos_Obligaciones(int id_proyectoobligaciones)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _proyectos_ObligacionesRepository.DeleteProyectos_Obligaciones(id_proyectoobligaciones);

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
        public IHttpActionResult GetDataTableProyectos_ObligacionesByProyecto(int id_asignacionproyecto)
        {
            DataTableAdapter<Proyectos_Obligaciones> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _proyectos_ObligacionesRepository.GetDataTableProyectos_Obligaciones(id_asignacionproyecto, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
