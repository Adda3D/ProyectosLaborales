using IrisUNAL.Api.Entities.Repositories.Investigacion;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.Investigacion;
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

namespace IrisUNAL.Api.Controllers.Investigacion
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class Investigacion_EstadoProyectoController : BaseController<Investigacion_EstadoProyecto>
    {
        private readonly Investigacion_EstadoProyectoRepository _investigacion_EstadoProyectoRepository;
        public Investigacion_EstadoProyectoController (Investigacion_EstadoProyectoRepository investigacion_EstadoProyectoRepository)
        {
            _investigacion_EstadoProyectoRepository = investigacion_EstadoProyectoRepository;
        }
        readonly Investigacion_EstadoProyectoRepository investigacion_EstadoProyectoRepository = new Investigacion_EstadoProyectoRepository();
        public Investigacion_EstadoProyectoController()
        {
            _investigacion_EstadoProyectoRepository = investigacion_EstadoProyectoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllInvestigacion_EstadoProyecto()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = investigacion_EstadoProyectoRepository.GetAllInvestigacion_EstadoProyecto();

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
        public IHttpActionResult GetInvestigacion_EstadoProyectoDetails(int id_estado)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = investigacion_EstadoProyectoRepository.GetInvestigacion_EstadoProyectoDetails(id_estado);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Estado inexistente";
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
        public IHttpActionResult GetInvestigacion_EstadoProyectoNombre(string cd_nmestado)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = investigacion_EstadoProyectoRepository.GetInvestigacion_EstadoProyectoNombre(cd_nmestado);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Estado inexistente";
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
        public IHttpActionResult InsertInvestigacion_EstadoProyecto([FromBody] Investigacion_EstadoProyecto investigacion_EstadoProyecto )
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

                var created = investigacion_EstadoProyectoRepository.InsertInvestigacion_EstadoProyecto(investigacion_EstadoProyecto);

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
        public IHttpActionResult UpdateInvestigacion_EstadoProyecto([FromBody] Investigacion_EstadoProyecto investigacion_EstadoProyecto)
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

                var created = investigacion_EstadoProyectoRepository.UpdateInvestigacion_EstadoProyecto(investigacion_EstadoProyecto);

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
        public IHttpActionResult DeleteInvestigacion_EstadoProyecto(int id_estado)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = investigacion_EstadoProyectoRepository.DeleteInvestigacion_EstadoProyecto(id_estado);

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
        public IHttpActionResult GetDataTableInvestigacion_EstadoProyecto()
        {
            DataTableAdapter<Investigacion_EstadoProyecto> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = investigacion_EstadoProyectoRepository.GetDataTableInvestigacion_EstadoProyecto(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
