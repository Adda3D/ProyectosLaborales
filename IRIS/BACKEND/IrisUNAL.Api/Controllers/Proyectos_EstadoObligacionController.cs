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
    public class Proyectos_EstadoObligacionController : BaseController<Proyectos_EstadoObligacion>
    {
        private readonly IProyectos_EstadoObligacionRepository _proyectos_EstadoObligacionRepository;

        public Proyectos_EstadoObligacionController(IProyectos_EstadoObligacionRepository proyectos_EstadoObligacionRepository)
        {
            _proyectos_EstadoObligacionRepository = proyectos_EstadoObligacionRepository;
        }

        readonly IProyectos_EstadoObligacionRepository proyectos_EstadoObligacionRepository = new Proyectos_EstadoObligacionRepository();
        public Proyectos_EstadoObligacionController()
        {
            _proyectos_EstadoObligacionRepository = proyectos_EstadoObligacionRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllProyectos_EstadoObligacion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_EstadoObligacionRepository.GetAllProyectos_EstadoObligacion();

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
        public IHttpActionResult GetProyectos_EstadoObligacionDetails(int id_estadoobligacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_EstadoObligacionRepository.GetProyectos_EstadoObligacionDetails(id_estadoobligacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Proyectos_EstadoObligacion inexistente";
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
        public IHttpActionResult GetProyectos_EstadoObligacionEstado(string cd_estadoobligacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_EstadoObligacionRepository.GetProyectos_EstadoObligacionEstado(cd_estadoobligacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Proyectos_EstadoObligacion inexistente";
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
        public IHttpActionResult InsertProyectos_EstadoObligacion([FromBody] Proyectos_EstadoObligacion proyectos_EstadoObligacion)
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

                var created = _proyectos_EstadoObligacionRepository.InsertProyectos_EstadoObligacion(proyectos_EstadoObligacion);

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
        public IHttpActionResult UpdateProyectos_EstadoObligacion([FromBody] Proyectos_EstadoObligacion proyectos_EstadoObligacion)
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

                var created = _proyectos_EstadoObligacionRepository.UpdateProyectos_EstadoObligacion(proyectos_EstadoObligacion);

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
        public IHttpActionResult DeleteProyectos_EstadoObligacion(int id_estadoobligacion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _proyectos_EstadoObligacionRepository.DeleteProyectos_EstadoObligacion(id_estadoobligacion);

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
        public IHttpActionResult GetDataTableProyectos_EstadoObligacion()
        {
            DataTableAdapter<Proyectos_EstadoObligacion> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = proyectos_EstadoObligacionRepository.GetDataTableProyectos_EstadoObligacion(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
