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
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class Seguimiento_AplicarPagoController : BaseController<Seguimiento_AplicarPago>
    {
        private readonly ISeguimiento_AplicarPagoRepository _seguimiento_AplicarPagoRepository;
        public Seguimiento_AplicarPagoController(ISeguimiento_AplicarPagoRepository seguimiento_AplicarPagoRepository)
        {
            _seguimiento_AplicarPagoRepository = seguimiento_AplicarPagoRepository;
        }
        readonly ISeguimiento_AplicarPagoRepository seguimiento_AplicarPagoRepository = new Seguimiento_AplicarPagoRepository();
        public Seguimiento_AplicarPagoController()
        {
            _seguimiento_AplicarPagoRepository = seguimiento_AplicarPagoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllSeguimiento_AplicarPago()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_AplicarPagoRepository.GetAllSeguimiento_AplicarPago();

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
        public IHttpActionResult GetSeguimiento_AplicarPagoDetails(int id_aplicarpago)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_AplicarPagoRepository.GetSeguimiento_AplicarPagoDetails(id_aplicarpago);

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
        public IHttpActionResult InsertSeguimiento_AplicarPago([FromBody] Seguimiento_AplicarPago seguimiento_AplicarPago)
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

                var created = _seguimiento_AplicarPagoRepository.InsertSeguimiento_AplicarPago(seguimiento_AplicarPago);

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
        public IHttpActionResult UpdateSeguimiento_AplicarPago([FromBody] Seguimiento_AplicarPago seguimiento_AplicarPago)
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

                var created = _seguimiento_AplicarPagoRepository.UpdateSeguimiento_AplicarPago(seguimiento_AplicarPago);

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
        public IHttpActionResult DeleteSeguimiento_AplicarPago(int id_aplicarpago)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _seguimiento_AplicarPagoRepository.DeleteSeguimiento_AplicarPago(id_aplicarpago);

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
        public IHttpActionResult GetDataTablePagosByGastoProyecto(int id_creargasto)
        {
            DataTableAdapter<Seguimiento_AplicarPago> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _seguimiento_AplicarPagoRepository.GetDataTablePagosByGastoProyecto(id_creargasto, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetDataTablePagosByProyecto(int id_asignacionproyecto)
        {
            DataTableAdapter<Seguimiento_AplicarPago> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _seguimiento_AplicarPagoRepository.GetDataTablePagosByProyecto(id_asignacionproyecto, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

    }
}
