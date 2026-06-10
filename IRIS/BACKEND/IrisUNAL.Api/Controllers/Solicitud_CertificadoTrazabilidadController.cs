using IrisUNAL.Api.Entities.Repositories;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IrisUNAL.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Solicitud_CertificadoTrazabilidadController : BaseController<Solicitud_CertificadoTrazabilidad>
    {
        private readonly ISolicitud_CertificadoTrazabilidadRepository _solicitud_CertificadoTrazabilidadRepository;

        public Solicitud_CertificadoTrazabilidadController(ISolicitud_CertificadoTrazabilidadRepository solicitud_CertificadoTrazabilidadRepository)
        {
            _solicitud_CertificadoTrazabilidadRepository = solicitud_CertificadoTrazabilidadRepository;
        }

        readonly ISolicitud_CertificadoTrazabilidadRepository solicitud_CertificadoTrazabilidadRepository = new Solicitud_CertificadoTrazabilidadRepository();

        public Solicitud_CertificadoTrazabilidadController()
        {
            _solicitud_CertificadoTrazabilidadRepository = solicitud_CertificadoTrazabilidadRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllSolicitud_CertificadoTrazabilidad()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _solicitud_CertificadoTrazabilidadRepository.GetAllSolicitud_CertificadoTrazabilidad();

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
        public IHttpActionResult GetSolicitud_CertificadoTrazabilidadDetails(int id)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _solicitud_CertificadoTrazabilidadRepository.GetSolicitud_CertificadoTrazabilidadById(id);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Registro de trazabilidad inexistente";
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
        public IHttpActionResult InsertSolicitud_CertificadoTrazabilidad([FromBody] Solicitud_CertificadoTrazabilidad trazabilidad)
        {
            var resultdb = new ResultObject();
            try
            {
                if (!ModelState.IsValid)
                {
                    resultdb.Ok = false;
                    resultdb.Message = Request.CreateResponse(ModelState).ToString();
                    resultdb.Data = null;
                }

                _solicitud_CertificadoTrazabilidadRepository.InsertSolicitud_CertificadoTrazabilidad(trazabilidad);

                resultdb.Ok = true;
                resultdb.Message = "Trazabilidad creada correctamente";
                resultdb.Data = trazabilidad;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }

        [HttpPost]
        public IHttpActionResult UpdateSolicitud_CertificadoTrazabilidad([FromBody] Solicitud_CertificadoTrazabilidad trazabilidad)
        {
            var resultdb = new ResultObject();
            try
            {
                if (!ModelState.IsValid)
                {
                    resultdb.Ok = false;
                    resultdb.Message = Request.CreateResponse(ModelState).ToString();
                    resultdb.Data = null;
                }

                _solicitud_CertificadoTrazabilidadRepository.UpdateSolicitud_CertificadoTrazabilidad(trazabilidad);

                resultdb.Ok = true;
                resultdb.Message = "Trazabilidad actualizada correctamente";
                resultdb.Data = trazabilidad;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }


        [HttpDelete]
        public IHttpActionResult DeleteSolicitud_CertificadoTrazabilidad(int id)
        {
            var resultdb = new ResultObject();
            try
            {
                _solicitud_CertificadoTrazabilidadRepository.DeleteSolicitud_CertificadoTrazabilidad(id);

                resultdb.Ok = true;
                resultdb.Message = "Trazabilidad eliminada correctamente";
                resultdb.Data = null;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }

        [HttpPost]
        public IHttpActionResult SyncTrazabilidad()
        {
            var resultdb = new ResultObject();
            try
            {
                _solicitud_CertificadoTrazabilidadRepository.SyncTrazabilidad();

                resultdb.Ok = true;
                resultdb.Message = "Sincronización de trazabilidad ejecutada correctamente.";
                resultdb.Data = null;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }

    }
}
