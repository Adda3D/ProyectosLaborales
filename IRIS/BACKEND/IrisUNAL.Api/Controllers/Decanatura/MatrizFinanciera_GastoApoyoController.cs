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
    public class MatrizFinanciera_GastoApoyoController : BaseController<MatrizFinanciera_GastoApoyo>
    {
        private readonly MatrizFinanciera_GastoApoyoRepository _matrizFinanciera_GastoApoyoRepository;
        public MatrizFinanciera_GastoApoyoController(MatrizFinanciera_GastoApoyoRepository matrizFinanciera_GastoApoyoRepository)
        {
            _matrizFinanciera_GastoApoyoRepository = matrizFinanciera_GastoApoyoRepository;
        }
        readonly MatrizFinanciera_GastoApoyoRepository matrizFinanciera_GastoApoyoRepository = new MatrizFinanciera_GastoApoyoRepository();
        public MatrizFinanciera_GastoApoyoController()
        {
            _matrizFinanciera_GastoApoyoRepository = matrizFinanciera_GastoApoyoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllMatrizFinanciera_GastoApoyo()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = matrizFinanciera_GastoApoyoRepository.GetAllMatrizFinanciera_GastoApoyo();

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
        public IHttpActionResult GetMatrizFinanciera_GastoApoyoDetails(int id_gastoapoyo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = matrizFinanciera_GastoApoyoRepository.GetMatrizFinanciera_GastoApoyoDetails(id_gastoapoyo);

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
        public IHttpActionResult InsertMatrizFinanciera_GastoApoyo([FromBody] MatrizFinanciera_GastoApoyo matrizFinanciera_GastoApoyo)
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

                var created = matrizFinanciera_GastoApoyoRepository.InsertMatrizFinanciera_GastoApoyo(matrizFinanciera_GastoApoyo);

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
        public IHttpActionResult UpdateMatrizFinanciera_GastoApoyo([FromBody] MatrizFinanciera_GastoApoyo matrizFinanciera_GastoApoyo)
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

                var created = matrizFinanciera_GastoApoyoRepository.UpdateMatrizFinanciera_GastoApoyo(matrizFinanciera_GastoApoyo);

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
        public IHttpActionResult DeleteMatrizFinanciera_GastoApoyo(int id_gastoapoyo)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = matrizFinanciera_GastoApoyoRepository.DeleteMatrizFinanciera_GastoApoyo(id_gastoapoyo);

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
        public IHttpActionResult GetDataTableMatrizFinanciera_GastoApoyoByMatriz(int id_matrizfinanciera)
        {
            DataTableAdapter<MatrizFinanciera_GastoApoyo> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = matrizFinanciera_GastoApoyoRepository.GetDataTableMatrizFinanciera_GastoApoyoByMatriz(id_matrizfinanciera, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}

