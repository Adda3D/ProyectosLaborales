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
    public class MatrizFinanciera_TipoOperativoController : BaseController<MatrizFinanciera_TipoOperativo>
    {
        private readonly MatrizFinanciera_TipoOperativoRepository _matrizFinanciera_TipoOperativoRepository;
        public MatrizFinanciera_TipoOperativoController(MatrizFinanciera_TipoOperativoRepository matrizFinanciera_TipoOperativoRepository)
        {
            _matrizFinanciera_TipoOperativoRepository = matrizFinanciera_TipoOperativoRepository;
        }
        readonly MatrizFinanciera_TipoOperativoRepository matrizFinanciera_TipoOperativoRepository = new MatrizFinanciera_TipoOperativoRepository();
        public MatrizFinanciera_TipoOperativoController()
        {
            _matrizFinanciera_TipoOperativoRepository = matrizFinanciera_TipoOperativoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllMatrizFinanciera_TipoOperativo()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = matrizFinanciera_TipoOperativoRepository.GetAllMatrizFinanciera_TipoOperativo();

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
        public IHttpActionResult GetMatrizFinanciera_TipoOperativoDetails(int id_tipooperativo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = matrizFinanciera_TipoOperativoRepository.GetMatrizFinanciera_TipoOperativoDetails(id_tipooperativo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Tipo Operativo inexistente";
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
        public IHttpActionResult GetMatrizFinanciera_TipoOperativoNombre(string cd_nmtipooperativo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = matrizFinanciera_TipoOperativoRepository.GetMatrizFinanciera_TipoOperativoNombre(cd_nmtipooperativo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Tipo Operativo inexistente";
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
        public IHttpActionResult InsertMatrizFinanciera_TipoOperativo([FromBody] MatrizFinanciera_TipoOperativo matrizFinanciera_TipoOperativo)
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

                var created = matrizFinanciera_TipoOperativoRepository.InsertMatrizFinanciera_TipoOperativo(matrizFinanciera_TipoOperativo);

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
        public IHttpActionResult UpdateMatrizFinanciera_TipoOperativo([FromBody] MatrizFinanciera_TipoOperativo matrizFinanciera_TipoOperativo)
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

                var created = matrizFinanciera_TipoOperativoRepository.UpdateMatrizFinanciera_TipoOperativo(matrizFinanciera_TipoOperativo);

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
        public IHttpActionResult DeleteMatrizFinanciera_TipoOperativo(int id_tipooperativo)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = matrizFinanciera_TipoOperativoRepository.DeleteMatrizFinanciera_TipoOperativo(id_tipooperativo);

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
        public IHttpActionResult GetDataTableMatrizFinanciera_TipoOperativo()
        {
            DataTableAdapter<MatrizFinanciera_TipoOperativo> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = matrizFinanciera_TipoOperativoRepository.GetDataTableMatrizFinanciera_TipoOperativo(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
