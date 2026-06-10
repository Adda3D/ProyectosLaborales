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
    public class HermesProyectoExtensionController : BaseController<HermesProyectoExtension>
    {
        private readonly HermesProyectoExtensionRepository _hermesproyectoextensionRepository;

        public HermesProyectoExtensionController(HermesProyectoExtensionRepository hermesproyectoextensionRepository)
        {
            _hermesproyectoextensionRepository = hermesproyectoextensionRepository;
        }

        readonly HermesProyectoExtensionRepository hermesproyectoextensionRepository = new HermesProyectoExtensionRepository();
        public HermesProyectoExtensionController()
        {
            _hermesproyectoextensionRepository = hermesproyectoextensionRepository;
        }

        [HttpGet]
        public IHttpActionResult GetHermesProyectoExtensionDetails(int idproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _hermesproyectoextensionRepository.GetHermesProyectoExtensionDetails(idproyecto);

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
        public IHttpActionResult InsertHermesProyectoExtension([FromBody] HermesProyectoExtension _hermesproyectoextension)
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

                var created = _hermesproyectoextensionRepository.InsertHermesProyectoExtension(_hermesproyectoextension);

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
        public IHttpActionResult UpdateHermesProyectoExtension([FromBody] HermesProyectoExtension _hermesproyectoextension)
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

                var created = _hermesproyectoextensionRepository.UpdateHermesProyectoExtension(_hermesproyectoextension);

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
        public IHttpActionResult GetDataTableHermesProyectoExtension()
        {
            DataTableAdapter<HermesProyectoExtension> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _hermesproyectoextensionRepository.GetDataTableHermesProyectoExtension(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

        [HttpGet]
        public IHttpActionResult CargarHermesProyectoExtension()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _hermesproyectoextensionRepository.CargarHermesProyectoExtension();

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
