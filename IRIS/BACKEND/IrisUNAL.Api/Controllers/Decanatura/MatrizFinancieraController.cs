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
    public class MatrizFinancieraController : BaseController<MatrizFinanciera>
    {
        private readonly MatrizFinancieraRepository _matrizFinancieraRepository;
        public MatrizFinancieraController(MatrizFinancieraRepository matrizFinancieraRepository)
        {
            _matrizFinancieraRepository = matrizFinancieraRepository;
        }
        readonly MatrizFinancieraRepository matrizFinancieraRepository = new MatrizFinancieraRepository();
        public MatrizFinancieraController()
        {
            _matrizFinancieraRepository = matrizFinancieraRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllMatrizFinanciera()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = matrizFinancieraRepository.GetAllMatrizFinanciera();

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
        public IHttpActionResult GetMatrizFinancieraDetails(int id_matrizfinanciera)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = matrizFinancieraRepository.GetMatrizFinancieraDetails(id_matrizfinanciera);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "MatrizFinanciera inexistente";
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
        public IHttpActionResult InsertMatrizFinanciera([FromBody] MatrizFinanciera matrizFinanciera)
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

                var created = matrizFinancieraRepository.InsertMatrizFinanciera(matrizFinanciera);

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
        public IHttpActionResult UpdateMatrizFinanciera([FromBody] MatrizFinanciera matrizFinanciera)
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

                var created = matrizFinancieraRepository.UpdateMatrizFinanciera(matrizFinanciera);

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
        public IHttpActionResult DeleteMatrizFinanciera(int id_matrizfinanciera)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = matrizFinancieraRepository.DeleteMatrizFinanciera(id_matrizfinanciera);

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
        public IHttpActionResult GetDataTableMatrizFinanciera()
        {
            DataTableAdapter<MatrizFinanciera> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = matrizFinancieraRepository.GetDataTableMatrizFinanciera(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
        [HttpGet]

        public IHttpActionResult ExcelMatrizFinanciera(int id_matrizfinanciera)
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = matrizFinancieraRepository.ExcelMatrizFinanciera(id_matrizfinanciera);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (archivoresultado == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Error creando Archivo Excel";
                }

                resultdb.Data = archivoresultado;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }

        }
    }
}
