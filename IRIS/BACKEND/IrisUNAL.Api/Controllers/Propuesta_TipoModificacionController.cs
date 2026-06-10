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
    public class Propuesta_TipoModificacionController : BaseController<Propuesta_TipoModificacion>
    {
        private readonly IPropuesta_TipoModificacionRepository _propuesta_TipoModificacionRepository;

        public Propuesta_TipoModificacionController(IPropuesta_TipoModificacionRepository propuesta_TipoModificacionRepository)
        {
            _propuesta_TipoModificacionRepository = propuesta_TipoModificacionRepository;
        }

        readonly IPropuesta_TipoModificacionRepository propuesta_TipoModificacionRepository = new Propuesta_TipoModificacionRepository();
        public Propuesta_TipoModificacionController()
        {
            _propuesta_TipoModificacionRepository = propuesta_TipoModificacionRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPropuesta_TipoModificacion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_TipoModificacionRepository.GetAllPropuesta_TipoModificacion();

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
        public IHttpActionResult GetPropuesta_TipoModificacionDetails(int id_tipomodificacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_TipoModificacionRepository.GetPropuesta_TipoModificacionDetails(id_tipomodificacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Tipo modificación inexistente";
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
        public IHttpActionResult GetPropuesta_TipoModificacionDetails(string nmtipomodificacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_TipoModificacionRepository.GetPropuesta_TipoModificacionDetails(nmtipomodificacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Tipo modificación inexistente";
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
        public IHttpActionResult InsertPropuesta_TipoModificacion([FromBody] Propuesta_TipoModificacion propuesta_TipoModificacion)
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

                var created = _propuesta_TipoModificacionRepository.InsertPropuesta_TipoModificacion(propuesta_TipoModificacion);

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
        public IHttpActionResult UpdatePropuesta_TipoModificacion([FromBody] Propuesta_TipoModificacion propuesta_TipoModificacion)
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

                var created = _propuesta_TipoModificacionRepository.UpdatePropuesta_TipoModificacion(propuesta_TipoModificacion);

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
        public IHttpActionResult DeletePropuesta_TipoModificacion(int id_tipomodificacion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _propuesta_TipoModificacionRepository.DeletePropuesta_TipoModificacion(id_tipomodificacion);

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
        public IHttpActionResult GetDataTablePropuestaTipoModificacion()
        {
            DataTableAdapter<Propuesta_TipoModificacion> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _propuesta_TipoModificacionRepository.GetDataTablePropuestaSuscripcionMinuta(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

    }
}
