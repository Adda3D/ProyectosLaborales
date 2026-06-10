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
    public class Proyectos_EstadoContratoController : BaseController<Proyectos_EstadoContrato>
    {
        private readonly IProyectos_EstadoContratoRepository _proyectos_EstadoContratoRepository;

        public Proyectos_EstadoContratoController(IProyectos_EstadoContratoRepository proyectos_EstadoContratoRepository)
        {
            _proyectos_EstadoContratoRepository = proyectos_EstadoContratoRepository;
        }

        readonly IProyectos_EstadoContratoRepository proyectos_EstadoContratoRepository = new Proyectos_EstadoContratoRepository();
        public Proyectos_EstadoContratoController()
        {
            _proyectos_EstadoContratoRepository = proyectos_EstadoContratoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllProyectos_EstadoContrato()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_EstadoContratoRepository.GetAllProyectos_EstadoContrato();

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
        public IHttpActionResult GetProyectos_EstadoContratoDetails(int id_estadocontrato)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_EstadoContratoRepository.GetProyectos_EstadoContratoDetails(id_estadocontrato);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Proyectos_EstadoContrato inexistente";
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
        public IHttpActionResult GetProyectos_EstadoContratoEstado(string cd_estadocontrato)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_EstadoContratoRepository.GetProyectos_EstadoContratoEstado(cd_estadocontrato);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Proyectos_EstadoContrato inexistente";
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
        public IHttpActionResult InsertProyectos_EstadoContrato([FromBody] Proyectos_EstadoContrato proyectos_EstadoContrato)
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

                var created = _proyectos_EstadoContratoRepository.InsertProyectos_EstadoContrato(proyectos_EstadoContrato);

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
        public IHttpActionResult UpdateProyectos_EstadoContrato([FromBody] Proyectos_EstadoContrato proyectos_EstadoContrato)
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

                var created = _proyectos_EstadoContratoRepository.UpdateProyectos_EstadoContrato(proyectos_EstadoContrato);

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
        public IHttpActionResult DeleteProyectos_EstadoContrato(int id_estadocontrato)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _proyectos_EstadoContratoRepository.DeleteProyectos_EstadoContrato(id_estadocontrato);

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
        public IHttpActionResult GetDataTableProyectos_EstadoContrato()
        {
            DataTableAdapter<Proyectos_EstadoContrato> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _proyectos_EstadoContratoRepository.GetDataTableProyectos_EstadoContrato(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
