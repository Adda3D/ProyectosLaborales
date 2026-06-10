using IrisUNAL.Api.Entities.Repositories.Hermes;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.Hermes;
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

namespace IrisUNAL.Api.Controllers.Hermes
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HermesProyectoInvestigacionController : BaseController<HermesProyectoInvestigacion>
    {
        private readonly HermesProyectoInvestigacionRepository _hermesproyectoinvestigacionRepository;

        public HermesProyectoInvestigacionController(HermesProyectoInvestigacionRepository hermesproyectoinvestigacionRepository)
        {
            _hermesproyectoinvestigacionRepository = hermesproyectoinvestigacionRepository;
        }

        readonly HermesProyectoInvestigacionRepository hermesproyectoinvestigacionRepository = new HermesProyectoInvestigacionRepository();
        public HermesProyectoInvestigacionController()
        {
            _hermesproyectoinvestigacionRepository = hermesproyectoinvestigacionRepository;
        }

        [HttpGet]
        public IHttpActionResult GetHermesProyectoInvestigacionDetails(int idproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _hermesproyectoinvestigacionRepository.GetHermesProyectoInvestigacionDetails(idproyecto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Detalle proyecto inexistente";
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
        public IHttpActionResult GetHermesProyectoInvestigacionDetailsidhermes(int idhermes)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _hermesproyectoinvestigacionRepository.GetHermesProyectoInvestigacionDetailsidhermes(idhermes);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Detalle proyecto inexistente";
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
        public IHttpActionResult InsertHermesProyectoInvestigacion([FromBody] HermesProyectoInvestigacion _hermesproyectoinvestigacion)
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

                var created = _hermesproyectoinvestigacionRepository.InsertHermesProyectoInvestigacion(_hermesproyectoinvestigacion);

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
        public IHttpActionResult UpdateHermesProyectoInvestigacion([FromBody] HermesProyectoInvestigacion _hermesproyectoinvestigacion)
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

                var created = _hermesproyectoinvestigacionRepository.UpdateHermesProyectoInvestigacion(_hermesproyectoinvestigacion);

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
        public IHttpActionResult GetDataTableHermesProyectoInvestigacion()
        {
            DataTableAdapter<HermesProyectoInvestigacion> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _hermesproyectoinvestigacionRepository.GetDataTableHermesProyectoInvestigacion(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

        [HttpGet]
        public IHttpActionResult CargarHermesProyectoInvestigacion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _hermesproyectoinvestigacionRepository.CargarHermesProyectoInvestigacion();

                resultdb.Ok = true;
                resultdb.Message = "";

                if (!data)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Proyectos HERMES sin cargar";
                }

                resultdb.Data = data;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }

    }
}
