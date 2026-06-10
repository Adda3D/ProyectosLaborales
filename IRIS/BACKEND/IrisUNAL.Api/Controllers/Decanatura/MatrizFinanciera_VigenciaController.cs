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
    public class MatrizFinanciera_VigenciaController : BaseController<MatrizFinanciera_Vigencia>
    {
        private readonly MatrizFinanciera_VigenciaRepository _matrizFinanciera_VigenciaRepository;
        public MatrizFinanciera_VigenciaController(MatrizFinanciera_VigenciaRepository matrizFinanciera_VigenciaRepository)
        {
            _matrizFinanciera_VigenciaRepository = matrizFinanciera_VigenciaRepository;
        }
        readonly MatrizFinanciera_VigenciaRepository matrizFinanciera_VigenciaRepository = new MatrizFinanciera_VigenciaRepository();
        public MatrizFinanciera_VigenciaController()
        {
            _matrizFinanciera_VigenciaRepository = matrizFinanciera_VigenciaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllMatrizFinanciera_Vigencia()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = matrizFinanciera_VigenciaRepository.GetAllMatrizFinanciera_Vigencia();

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
        public IHttpActionResult GetMatrizFinanciera_VigenciaDetails(int id_vigencia)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = matrizFinanciera_VigenciaRepository.GetMatrizFinanciera_VigenciaDetails(id_vigencia);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Vigencia inexistente";
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
        public IHttpActionResult GetMatrizFinanciera_VigenciaNombre(string cd_nmvigencia)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = matrizFinanciera_VigenciaRepository.GetMatrizFinanciera_VigenciaNombre(cd_nmvigencia);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Vigencia inexistente";
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
        public IHttpActionResult InsertMatrizFinanciera_Vigencia([FromBody] MatrizFinanciera_Vigencia matrizFinanciera_Vigencia)
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

                var created = matrizFinanciera_VigenciaRepository.InsertMatrizFinanciera_Vigencia(matrizFinanciera_Vigencia);

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
        public IHttpActionResult UpdateMatrizFinanciera_Vigencia([FromBody] MatrizFinanciera_Vigencia matrizFinanciera_Vigencia)
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

                var created = matrizFinanciera_VigenciaRepository.UpdateMatrizFinanciera_Vigencia(matrizFinanciera_Vigencia);

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
        public IHttpActionResult DeleteMatrizFinanciera_Vigencia(int id_vigencia)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = matrizFinanciera_VigenciaRepository.DeleteMatrizFinanciera_Vigencia(id_vigencia);

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
        public IHttpActionResult GetDataTableMatrizFinanciera_Vigencia()
        {
            DataTableAdapter<MatrizFinanciera_Vigencia> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = matrizFinanciera_VigenciaRepository.GetDataTableMatrizFinanciera_Vigencia(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
