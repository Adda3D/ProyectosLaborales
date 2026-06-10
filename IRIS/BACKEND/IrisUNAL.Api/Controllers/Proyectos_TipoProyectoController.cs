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
    public class Proyectos_TipoProyectoController : BaseController<Proyectos_TipoProyecto>
    {
        private readonly IProyectos_TipoProyectoRepository _proyectos_TipoProyectoRepository;

        public Proyectos_TipoProyectoController(IProyectos_TipoProyectoRepository proyectos_TipoProyectoRepository)
        {
            _proyectos_TipoProyectoRepository = proyectos_TipoProyectoRepository;
        }

        readonly IProyectos_TipoProyectoRepository proyectos_TipoProyectoRepository = new Proyectos_TipoProyectoRepository();
        public Proyectos_TipoProyectoController()
        {
            _proyectos_TipoProyectoRepository = proyectos_TipoProyectoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllProyectos_TipoProyecto()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_TipoProyectoRepository.GetAllProyectos_TipoProyecto();

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
        public IHttpActionResult GetProyectos_TipoProyectoDetails(int id_tipoproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_TipoProyectoRepository.GetProyectos_TipoProyectoDetails(id_tipoproyecto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Proyectos_TipoProyecto inexistente";
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
        public IHttpActionResult GetProyectos_TipoProyectoTipo(string cd_tipoproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_TipoProyectoRepository.GetProyectos_TipoProyectoTipo(cd_tipoproyecto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Proyectos_TipoProyecto inexistente";
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
        public IHttpActionResult InsertProyectos_TipoProyecto([FromBody] Proyectos_TipoProyecto proyectos_TipoProyecto)
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

                var created = _proyectos_TipoProyectoRepository.InsertProyectos_TipoProyecto(proyectos_TipoProyecto);

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
        public IHttpActionResult UpdateProyectos_TipoProyecto([FromBody] Proyectos_TipoProyecto proyectos_TipoProyecto)
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

                var created = _proyectos_TipoProyectoRepository.UpdateProyectos_TipoProyecto(proyectos_TipoProyecto);

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
        public IHttpActionResult DeleteProyectos_TipoProyecto(int id_tipoproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _proyectos_TipoProyectoRepository.DeleteProyectos_TipoProyecto(id_tipoproyecto);

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
        public IHttpActionResult GetDataTableProyectos_TipoProyecto()
        {
            DataTableAdapter<Proyectos_TipoProyecto> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = proyectos_TipoProyectoRepository.GetDataTableProyectos_TipoProyecto(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
