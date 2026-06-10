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
    public class Investigacion_AplicarpagoController : BaseController<Investigacion_Aplicarpago>
    {
        private readonly Investigacion_AplicarpagoRepository _investigacion_aplicarpagoRepository;

        public Investigacion_AplicarpagoController(Investigacion_AplicarpagoRepository investigacion_aplicarpagoRepository)
        {
            _investigacion_aplicarpagoRepository = investigacion_aplicarpagoRepository;
        }

        readonly Investigacion_AplicarpagoRepository investigacion_aplicarpagoRepository = new Investigacion_AplicarpagoRepository();
        public Investigacion_AplicarpagoController()
        {
            _investigacion_aplicarpagoRepository = investigacion_aplicarpagoRepository;
        }

        [HttpGet]
        public IHttpActionResult GetInvestigacion_AplicarpagoDetails(int id_investigacionpago)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_aplicarpagoRepository.GetInvestigacion_AplicarpagoDetails(id_investigacionpago);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Detalle de pago inexistente";
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
        public IHttpActionResult InsertInvestigacion_Aplicarpago([FromBody] Investigacion_Aplicarpago _investigacion_aplicarpago)
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

                var created = _investigacion_aplicarpagoRepository.InsertInvestigacion_Aplicarpago(_investigacion_aplicarpago);

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
        public IHttpActionResult UpdateInvestigacion_Aplicarpago([FromBody] Investigacion_Aplicarpago _investigacion_aplicarpago)
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

                var created = _investigacion_aplicarpagoRepository.UpdateInvestigacion_Aplicarpago(_investigacion_aplicarpago);

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
        public IHttpActionResult DeleteInvestigacion_Aplicarpago(int id_investigacionpago)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _investigacion_aplicarpagoRepository.DeleteInvestigacion_Aplicarpago(id_investigacionpago);

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
        public IHttpActionResult GetDataTablePagosByInvestigacionGasto(int id_investigaciongasto)
        {
            DataTableAdapter<Investigacion_Aplicarpago> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _investigacion_aplicarpagoRepository.GetDataTablePagosByInvestigacionGasto(id_investigaciongasto, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetDataTableInvestigacion_AplicarpagoByProyecto(int id_crearproyecto)
        {
            DataTableAdapter<Investigacion_Aplicarpago> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _investigacion_aplicarpagoRepository.GetDataTableInvestigacion_AplicarpagoByProyecto(id_crearproyecto, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
