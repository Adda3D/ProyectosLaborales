using IrisUNAL.Api.Entities.Repositories.Extension;
using IrisUNAL.Api.Entities.Repositories.Publicacion;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.Extension;
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

namespace IrisUNAL.Api.Controllers.Extension
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProyectosCentroExtensionController : BaseController<ProyectosCentroExtension>
    {
        private readonly ProyectosCentroExtensionRepository _proyectosCentroExtensionRepository;
        public ProyectosCentroExtensionController(ProyectosCentroExtensionRepository proyectosCentroExtensionRepository)
        {
            _proyectosCentroExtensionRepository = proyectosCentroExtensionRepository;
        }
        readonly ProyectosCentroExtensionRepository proyectosCentroExtensionRepository = new ProyectosCentroExtensionRepository();
        public ProyectosCentroExtensionController()
        {
            _proyectosCentroExtensionRepository = proyectosCentroExtensionRepository;
        }

        [HttpGet]
        public IHttpActionResult GetDropdownSemestre()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectosCentroExtensionRepository.DropdownSemestre();

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
        public IHttpActionResult GetAllPropuestasModalidad(int annio, int rango1, int rango2)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectosCentroExtensionRepository.TotalPropuestasModalidad(annio, rango1, rango2);

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
        public IHttpActionResult GetAllPropuestas(int annio, int rango1, int rango2)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectosCentroExtensionRepository.TotalPropuestas(annio, rango1, rango2);

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
        public IHttpActionResult GetAllPropuestasTipoUsuario(int annio, int rango1, int rango2)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectosCentroExtensionRepository.PropuestasTipoUsuario(annio, rango1, rango2);

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
        public IHttpActionResult GetAllPropuestasOrigen(int annio, int rango1, int rango2)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectosCentroExtensionRepository.PropuestasOrigen(annio, rango1, rango2);

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
        public IHttpActionResult GetAllNombreProyectosEjecucion(int annio, int rango1, int rango2)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectosCentroExtensionRepository.NombreProyectosEjecucion(annio, rango1, rango2);

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
        public IHttpActionResult GetAllTotalProyectosEjecucion(int annio, int rango1, int rango2)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectosCentroExtensionRepository.TotalProyectosEjecucion(annio, rango1, rango2);

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
        public IHttpActionResult GetAllTotalEntidadesPropuestas(int annio, int rango1, int rango2)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectosCentroExtensionRepository.TotalEntidadesPropuestas(annio, rango1, rango2);

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
        public IHttpActionResult GetAllEstadoProyectos(int annio, int rango1, int rango2)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectosCentroExtensionRepository.TotalEstadoProyectos(annio, rango1, rango2);

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
        public IHttpActionResult ExcelProyectosPendientesIngreso()
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = _proyectosCentroExtensionRepository.ExcelProyectosPendientesIngreso();

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
        [HttpGet]

        public IHttpActionResult ExcelSeguimientoSuscripcionActasLiquidacion()
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = _proyectosCentroExtensionRepository.ExcelSeguimientoSuscripcionActasLiquidacion();

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
        [HttpGet]

        public IHttpActionResult ExcelMatrizAsignacionProyectos()
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = _proyectosCentroExtensionRepository.ExcelMatrizAsignacionProyectos();

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
        [HttpGet]

        public IHttpActionResult ExcelSeguimientoCumplimientoContrapartidas()
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = _proyectosCentroExtensionRepository.ExcelSeguimientoCumplimientoContrapartidas();

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
        [HttpGet]

        public IHttpActionResult ExcelContratacion()
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = _proyectosCentroExtensionRepository.ExcelContratacion();

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
        [HttpGet]

        public IHttpActionResult ExcelProyectosPEC()
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = _proyectosCentroExtensionRepository.ExcelProyectosPEC();

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
        [HttpGet]

        public IHttpActionResult ExcelMatrizConoPropuestas()
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = _proyectosCentroExtensionRepository.ExcelMatrizConoPropuestas();

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
        [HttpGet]

        public IHttpActionResult ExcelNumProyectos()
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = _proyectosCentroExtensionRepository.ExcelNumProyectos();

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
        [HttpGet]

        public IHttpActionResult ExcelProyectosPendientesIngresos()
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = _proyectosCentroExtensionRepository.ExcelProyectosPendientesIngresos();

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
        [HttpGet]

        public IHttpActionResult ExcelProyectosEstadoFinalizado()
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = _proyectosCentroExtensionRepository.ExcelProyectosEstadoFinalizado();

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
        [HttpGet]

        public IHttpActionResult ExcelMatrizLiquidacionFinalizacionProyectos()
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = _proyectosCentroExtensionRepository.ExcelMatrizLiquidacionFinalizacionProyectos();

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
        [HttpGet]

        public IHttpActionResult ExcelLiquidacionActas(int id_asignacionproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = _proyectosCentroExtensionRepository.ExcelLiquidacionActas(id_asignacionproyecto);

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
        [HttpGet]

        public IHttpActionResult ExcelProyeccionProximosProyectos()
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = _proyectosCentroExtensionRepository.ExcelProyeccionProximosProyectos();

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
        [HttpGet]

        public IHttpActionResult ExcelListadoPropuesta()
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = _proyectosCentroExtensionRepository.ExcelListadoPropuesta();

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
        [HttpGet]

        public IHttpActionResult ExcelTablaRegistroProyectos()
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = _proyectosCentroExtensionRepository.ExcelTablaRegistroProyectos();

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
        [HttpGet]

        public IHttpActionResult ExcelEstadoProyectos()
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = _proyectosCentroExtensionRepository.ExcelEstadoProyectos();

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
        [HttpGet]

        public IHttpActionResult ExcelBalancePropuestas()
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = _proyectosCentroExtensionRepository.ExcelBalancePropuestas();

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
