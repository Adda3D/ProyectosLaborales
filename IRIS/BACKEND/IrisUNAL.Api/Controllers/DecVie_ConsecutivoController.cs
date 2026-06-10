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
    public class DecVie_ConsecutivoController : BaseController<DecVie_Consecutivo>
    {
        private readonly IDecVie_ConsecutivoRepository _decVie_ConsecutivoRepository;
        public DecVie_ConsecutivoController(IDecVie_ConsecutivoRepository decVie_ConsecutivoRepository)
        {
            _decVie_ConsecutivoRepository = decVie_ConsecutivoRepository;
        }
        readonly IDecVie_ConsecutivoRepository decVie_ConsecutivoRepository = new DecVie_ConsecutivoRepository();
        public DecVie_ConsecutivoController()
        {
            _decVie_ConsecutivoRepository = decVie_ConsecutivoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_Consecutivo()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ConsecutivoRepository.GetAllDecVie_Consecutivo();

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
        public IHttpActionResult GetDecVie_ConsecutivoDetails(int id_decvieconsecutivo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ConsecutivoRepository.GetDecVie_ConsecutivoDetails(id_decvieconsecutivo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Consecutivo inexistente";
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
        public IHttpActionResult GetDecVie_ConsecutivoNumero(string cd_numconsecutivo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ConsecutivoRepository.GetDecVie_ConsecutivoNumero(cd_numconsecutivo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Consecutivo inexistente";
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
        public IHttpActionResult InsertDecVie_Consecutivo([FromBody] DecVie_Consecutivo decVie_Consecutivo)
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

                var created = decVie_ConsecutivoRepository.InsertDecVie_Consecutivo(decVie_Consecutivo);

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
        public IHttpActionResult InsertDecVie_Consecutivo_Data([FromBody] DecVie_Consecutivo decVie_Consecutivo)
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

                var created = decVie_ConsecutivoRepository.InsertDecVie_Consecutivo_Data(decVie_Consecutivo);

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
        public IHttpActionResult UpdateDecVie_Consecutivo([FromBody] DecVie_Consecutivo decVie_Consecutivo)
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

                var created = decVie_ConsecutivoRepository.UpdateDecVie_Consecutivo(decVie_Consecutivo);

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
        public IHttpActionResult UpdateDecVie_Consecutivo_Data([FromBody] DecVie_Consecutivo decVie_Consecutivo)
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

                var created = decVie_ConsecutivoRepository.UpdateDecVie_Consecutivo_Data(decVie_Consecutivo);

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
        public IHttpActionResult DeleteDecVie_Consecutivo(int id_decvieconsecutivo)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_ConsecutivoRepository.DeleteDecVie_Consecutivo(id_decvieconsecutivo);

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
        public IHttpActionResult GetDataTableDecVie_Consecutivo()
        {
            DataTableAdapter<DecVie_Consecutivo> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_ConsecutivoRepository.GetDataTableDecVie_Consecutivo(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
