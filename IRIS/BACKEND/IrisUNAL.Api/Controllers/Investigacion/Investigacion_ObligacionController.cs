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
    public class Investigacion_ObligacionController : BaseController<Investigacion_Obligacion>
    {
        private readonly Investigacion_ObligacionRepository _investigacion_obligacionRepository;

        public Investigacion_ObligacionController(Investigacion_ObligacionRepository investigacion_obligacionRepository)
        {
            _investigacion_obligacionRepository = investigacion_obligacionRepository;
        }

        readonly Investigacion_ObligacionRepository investigacion_obligacionRepository = new Investigacion_ObligacionRepository();
        public Investigacion_ObligacionController()
        {
            _investigacion_obligacionRepository = investigacion_obligacionRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllInvestigacion_ObligacionByProyecto(int id_crearproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_obligacionRepository.GetAllInvestigacion_ObligacionByProyecto(id_crearproyecto);

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
        public IHttpActionResult GetInvestigacion_ObligacionDetails(int id_proyectoobligacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_obligacionRepository.GetInvestigacion_ObligacionDetails(id_proyectoobligacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = true;
                    resultdb.Message = "Obligación Inexistente";
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
        public IHttpActionResult InsertInvestigacion_Obligacion([FromBody] Investigacion_Obligacion _investigacion_obligacion)
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

                var created = _investigacion_obligacionRepository.InsertInvestigacion_Obligacion(_investigacion_obligacion);

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
        public IHttpActionResult UpdateInvestigacion_Obligacion([FromBody] Investigacion_Obligacion _investigacion_obligacion)
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

                var created = _investigacion_obligacionRepository.UpdateInvestigacion_Obligacion(_investigacion_obligacion);

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
        public IHttpActionResult DeleteInvestigacion_Obligacion(int id_proyectoobligacion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _investigacion_obligacionRepository.DeleteInvestigacion_Obligacion(id_proyectoobligacion);

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
        public IHttpActionResult GetDataTableInvestigacion_ObligacionByProyecto(int id_crearproyecto)
        {
            DataTableAdapter<Investigacion_Obligacion> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _investigacion_obligacionRepository.GetDataTableInvestigacion_ObligacionByProyecto(id_crearproyecto, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

    }
}
