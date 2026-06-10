using IrisUNAL.Api.Entities.Repositories.Decanatura;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.Decanatura;
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

namespace IrisUNAL.Api.Controllers.Decanatura
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class MatrizFinanciera_GastoOperativoController : BaseController<MatrizFinanciera_GastoOperativo>
    {
        private readonly MatrizFinanciera_GastoOperativoRepository _matrizFinanciera_GastoOperativoRepository;
        public MatrizFinanciera_GastoOperativoController(MatrizFinanciera_GastoOperativoRepository matrizFinanciera_GastoOperativoRepository)
        {
            _matrizFinanciera_GastoOperativoRepository = matrizFinanciera_GastoOperativoRepository;
        }
        readonly MatrizFinanciera_GastoOperativoRepository matrizFinanciera_GastoOperativoRepository = new MatrizFinanciera_GastoOperativoRepository();
        public MatrizFinanciera_GastoOperativoController()
        {
            _matrizFinanciera_GastoOperativoRepository = matrizFinanciera_GastoOperativoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllMatrizFinanciera_GastoOperativo()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = matrizFinanciera_GastoOperativoRepository.GetAllMatrizFinanciera_GastoOperativo();

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
        public IHttpActionResult GetMatrizFinanciera_GastoOperativoDetails(int id_gastooperativo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = matrizFinanciera_GastoOperativoRepository.GetMatrizFinanciera_GastoOperativoDetails(id_gastooperativo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Gasto inexistente";
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
        public IHttpActionResult InsertMatrizFinanciera_GastoOperativo([FromBody] MatrizFinanciera_GastoOperativo matrizFinanciera_GastoOperativo)
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

                var created = matrizFinanciera_GastoOperativoRepository.InsertMatrizFinanciera_GastoOperativo(matrizFinanciera_GastoOperativo);

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
        public IHttpActionResult UpdateMatrizFinanciera_GastoOperativo([FromBody] MatrizFinanciera_GastoOperativo matrizFinanciera_GastoOperativo)
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

                var created = matrizFinanciera_GastoOperativoRepository.UpdateMatrizFinanciera_GastoOperativo(matrizFinanciera_GastoOperativo);

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
        public IHttpActionResult DeleteMatrizFinanciera_GastoOperativo(int id_gastooperativo)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = matrizFinanciera_GastoOperativoRepository.DeleteMatrizFinanciera_GastoOperativo(id_gastooperativo);

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
        public IHttpActionResult GetDataTableMatrizFinanciera_GastoOperativoByMatriz(int id_matrizfinanciera)
        {
            DataTableAdapter<MatrizFinanciera_GastoOperativo> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = matrizFinanciera_GastoOperativoRepository.GetDataTableMatrizFinanciera_GastoOperativoByMatriz(id_matrizfinanciera, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
