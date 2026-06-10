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
    public class Proyectos_AlcanceProyectoController : BaseController<Proyectos_AlcanceProyecto>
    {
        private readonly IProyectos_AlcanceProyectoRepository _proyectos_AlcanceProyectoRepository;

        public Proyectos_AlcanceProyectoController(IProyectos_AlcanceProyectoRepository proyectos_AlcanceProyectoRepository)
        {
            _proyectos_AlcanceProyectoRepository = proyectos_AlcanceProyectoRepository;
        }

        readonly IProyectos_AlcanceProyectoRepository proyectos_AlcanceProyectoRepository = new Proyectos_AlcanceProyectoRepository();
        public Proyectos_AlcanceProyectoController()
        {
            _proyectos_AlcanceProyectoRepository = proyectos_AlcanceProyectoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllProyectos_AlcanceProyecto()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_AlcanceProyectoRepository.GetAllProyectos_AlcanceProyecto();

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
        public IHttpActionResult GetProyectos_AlcanceProyectoDetails(int id_alcanceproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_AlcanceProyectoRepository.GetProyectos_AlcanceProyectoDetails(id_alcanceproyecto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Proyectos_AlcanceProyecto inexistente";
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
        public IHttpActionResult GetProyectos_AlcanceProyectoAlcance(string cd_alcanceproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_AlcanceProyectoRepository.GetProyectos_AlcanceProyectoAlcance(cd_alcanceproyecto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Proyectos_AlcanceProyecto inexistente";
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
        public IHttpActionResult InsertProyectos_AlcanceProyecto([FromBody] Proyectos_AlcanceProyecto proyectos_AlcanceProyecto)
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

                var created = _proyectos_AlcanceProyectoRepository.InsertProyectos_AlcanceProyecto(proyectos_AlcanceProyecto);

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
        public IHttpActionResult UpdateProyectos_AlcanceProyecto([FromBody] Proyectos_AlcanceProyecto proyectos_AlcanceProyecto)
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

                var created = _proyectos_AlcanceProyectoRepository.UpdateProyectos_AlcanceProyecto(proyectos_AlcanceProyecto);

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
        public IHttpActionResult DeleteProyectos_AlcanceProyecto(int id_alcanceproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _proyectos_AlcanceProyectoRepository.DeleteProyectos_AlcanceProyecto(id_alcanceproyecto);

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
        public IHttpActionResult GetDataTableProyectos_AlcanceProyecto()
        {
            DataTableAdapter<Proyectos_AlcanceProyecto> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _proyectos_AlcanceProyectoRepository.GetDataTableProyectos_AlcanceProyecto(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
