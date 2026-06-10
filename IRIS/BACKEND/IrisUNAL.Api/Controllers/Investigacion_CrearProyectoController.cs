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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Investigacion_CrearProyectoController : BaseController<Investigacion_CrearProyecto>
    {
        private readonly IInvestigacion_CrearProyectoRepository _investigacion_CrearProyectoRepository;

        public Investigacion_CrearProyectoController(IInvestigacion_CrearProyectoRepository investigacion_CrearProyectoRepository)
        {
            _investigacion_CrearProyectoRepository = investigacion_CrearProyectoRepository;
        }

        readonly IInvestigacion_CrearProyectoRepository investigacion_CrearProyectoRepository = new Investigacion_CrearProyectoRepository();
        public Investigacion_CrearProyectoController()
        {
            _investigacion_CrearProyectoRepository = investigacion_CrearProyectoRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllInvestigacion_CrearProyecto()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_CrearProyectoRepository.GetAllInvestigacion_CrearProyecto();

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
        public IHttpActionResult GetInvestigacion_CrearProyectoDetails(int id_crearproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_CrearProyectoRepository.GetInvestigacion_CrearProyectoDetails(id_crearproyecto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Proyecto inexistente";
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
        public IHttpActionResult GetInvestigacion_CrearProyectoCodigo(string cd_codigohermes)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_CrearProyectoRepository.GetInvestigacion_CrearProyectoCodigo(cd_codigohermes);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Proyecto inexistente";
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
        public IHttpActionResult InsertInvestigacion_CrearProyecto([FromBody] Investigacion_CrearProyecto investigacion_CrearProyecto)
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

                var created = _investigacion_CrearProyectoRepository.InsertInvestigacion_CrearProyecto(investigacion_CrearProyecto);

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
        public IHttpActionResult UpdateInvestigacion_CrearProyecto([FromBody] Investigacion_CrearProyecto investigacion_CrearProyecto)
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

                var created = _investigacion_CrearProyectoRepository.UpdateInvestigacion_CrearProyecto(investigacion_CrearProyecto);

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
        public IHttpActionResult DeleteInvestigacion_CrearProyecto(int id_crearproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _investigacion_CrearProyectoRepository.DeleteInvestigacion_CrearProyecto(id_crearproyecto);

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
        public IHttpActionResult GetDataTableInvestigacion_CrearProyecto()
        {
            DataTableAdapter<Investigacion_CrearProyecto> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _investigacion_CrearProyectoRepository.GetDataTableInvestigacion_CrearProyecto(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetInvestigacion_CrearProyectoAportes(int id_crearproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_CrearProyectoRepository.GetInvestigacion_CrearProyectoAportes(id_crearproyecto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Proyecto investigación inexistente";
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
        public IHttpActionResult UpdateInvestigacion_CrearProyectoAportes(ProyectoTotalAportesDTO proyecto_aportes)
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

                var created = _investigacion_CrearProyectoRepository.UpdateInvestigacion_CrearProyectoAportes(proyecto_aportes);

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

        [HttpGet]
        public IHttpActionResult ExcelInvestigacion_CrearProyecto(int id_crearproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = _investigacion_CrearProyectoRepository.ExcelInvestigacion_CrearProyecto(id_crearproyecto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (archivoresultado == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Error creando Archivo Excel";
                }

                resultdb.Data = archivoresultado;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }
    }
}