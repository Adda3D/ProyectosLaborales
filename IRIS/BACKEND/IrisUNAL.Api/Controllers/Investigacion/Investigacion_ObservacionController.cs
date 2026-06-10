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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Investigacion_ObservacionController : BaseController<Investigacion_Observacion>
    {
        private readonly Investigacion_ObservacionRepository _investigacion_observacionRepository;

        public Investigacion_ObservacionController(Investigacion_ObservacionRepository investigacion_observacionRepository)
        {
            _investigacion_observacionRepository = investigacion_observacionRepository;
        }

        readonly Investigacion_ObservacionRepository investigacion_observacionRepository = new Investigacion_ObservacionRepository();
        public Investigacion_ObservacionController()
        {
            _investigacion_observacionRepository = investigacion_observacionRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllInvestigacion_ObservacionByProyecto(int id_crearproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_observacionRepository.GetAllInvestigacion_ObservacionByProyecto(id_crearproyecto);

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
        public IHttpActionResult GetInvestigacion_ObservacionDetails(int id_proyectoobservacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_observacionRepository.GetInvestigacion_ObservacionDetails(id_proyectoobservacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = true;
                    resultdb.Message = "Observación Inexistente";
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
        public IHttpActionResult InsertInvestigacion_Observacion([FromBody] Investigacion_Observacion _investigacion_observacion)
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

                var created = _investigacion_observacionRepository.InsertInvestigacion_Observacion(_investigacion_observacion);

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
        public IHttpActionResult UpdateInvestigacion_Observacion([FromBody] Investigacion_Observacion _investigacion_observacion)
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

                var created = _investigacion_observacionRepository.UpdateInvestigacion_Observacion(_investigacion_observacion);

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
        public IHttpActionResult DeleteInvestigacion_Observacion(int id_proyectoobservacion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _investigacion_observacionRepository.DeleteInvestigacion_Observacion(id_proyectoobservacion);

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
        public IHttpActionResult GetDataTableInvestigacion_ObservacionByProyecto(int id_crearproyecto)
        {
            DataTableAdapter<Investigacion_Observacion> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _investigacion_observacionRepository.GetDataTableInvestigacion_ObservacionByProyecto(id_crearproyecto, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

    }
}
