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
    public class Proyectos_AsignacionProyectoController : BaseController<Proyectos_AsignacionProyecto>
    {
        private readonly IProyectos_AsignacionProyectoRepository _proyectos_AsignacionProyectoRepository;

        public Proyectos_AsignacionProyectoController(IProyectos_AsignacionProyectoRepository proyectos_AsignacionProyectoRepository)
        {
            _proyectos_AsignacionProyectoRepository = proyectos_AsignacionProyectoRepository;
        }

        readonly IProyectos_AsignacionProyectoRepository proyectos_AsignacionProyectoRepository = new Proyectos_AsignacionProyectoRepository();
        public Proyectos_AsignacionProyectoController()
        {
            _proyectos_AsignacionProyectoRepository = proyectos_AsignacionProyectoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllProyectos_AsignacionProyecto()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_AsignacionProyectoRepository.GetAllProyectos_AsignacionProyecto();

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
        public IHttpActionResult GetProyectos_AsignacionProyectoDetails(int id_asignacionproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_AsignacionProyectoRepository.GetProyectos_AsignacionProyectoDetails(id_asignacionproyecto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Proyecto extensión inexistente";
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
        public IHttpActionResult GetProyectos_AsignacionProyectoContrato(string cd_numcontratoconvenio)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_AsignacionProyectoRepository.GetProyectos_AsignacionProyectoContrato(cd_numcontratoconvenio);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Proyecto extensión inexistente";
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
        public IHttpActionResult GetProyectos_AsignacionProyectoConsecutivo(string consecutivo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_AsignacionProyectoRepository.GetProyectos_AsignacionProyectoConsecutivo(consecutivo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Proyecto extensión inexistente";
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
        public IHttpActionResult GetProyectos_AsignacionProyectoPropuesta(int id_propuesta)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_AsignacionProyectoRepository.GetProyectos_AsignacionProyectoPropuesta(id_propuesta);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Proyecto extensión inexistente";
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
        public IHttpActionResult UpdateProyectos_AsignacionProyectoContrato(AsignacionProyectoDTO datocontrato)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_AsignacionProyectoRepository.UpdateProyectoContrato(datocontrato);

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
        public IHttpActionResult InsertProyectos_AsignacionProyecto([FromBody] Proyectos_AsignacionProyecto proyectos_AsignacionProyecto)
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

                var created = _proyectos_AsignacionProyectoRepository.InsertProyectos_AsignacionProyecto(proyectos_AsignacionProyecto);

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
        public IHttpActionResult UpdateProyectos_AsignacionProyecto([FromBody] Proyectos_AsignacionProyecto proyectos_AsignacionProyecto)
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

                var created = _proyectos_AsignacionProyectoRepository.UpdateProyectos_AsignacionProyecto(proyectos_AsignacionProyecto);

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
        public IHttpActionResult UpdateProyectos_AsignacionProyectoAportes(ProyectoTotalAportesDTO proyecto_aportes)
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

                var created = _proyectos_AsignacionProyectoRepository.UpdateProyectos_AsignacionProyectoAportes(proyecto_aportes);

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
        public IHttpActionResult DeleteProyectos_AsignacionProyecto(int id_asignacionproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _proyectos_AsignacionProyectoRepository.DeleteProyectos_AsignacionProyecto(id_asignacionproyecto);

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
        public IHttpActionResult GetDataTableProyectos_AsignacionProyecto()
        {
            DataTableAdapter<Proyectos_AsignacionProyecto> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _proyectos_AsignacionProyectoRepository.GetDataTableProyectos_AsignacionProyecto(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetProyectos_AsignacionProyectoAportes(int id_proyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_AsignacionProyectoRepository.GetProyectos_AsignacionProyectoAportes(id_proyecto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Proyecto extensión inexistente";
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
        public IHttpActionResult ExcelProyectos_AsignacionProyecto(int id_asignacionproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = _proyectos_AsignacionProyectoRepository.ExcelProyectos_AsignacionProyecto(id_asignacionproyecto);

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
