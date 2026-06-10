using IrisUNAL.Api.Entities.Repositories.UGI;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using IrisUNAL.Api.Models.UGI;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IrisUNAL.Api.Controllers.UGI
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class UGI_LiteralSemestreController : BaseController<UGI_LiteralSemestre>
    {
        private readonly UGI_LiteralSemestreRepository _uGI_LiteralSemestreRepository;
        public UGI_LiteralSemestreController (UGI_LiteralSemestreRepository uGI_LiteralSemestreRepository)
        {
            _uGI_LiteralSemestreRepository = uGI_LiteralSemestreRepository;
        }
        readonly UGI_LiteralSemestreRepository uGI_LiteralSemestreRepository = new UGI_LiteralSemestreRepository();
        public UGI_LiteralSemestreController()
        {
            _uGI_LiteralSemestreRepository = uGI_LiteralSemestreRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllUGI_LiteralSemestre()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = uGI_LiteralSemestreRepository.GetAllUGI_LiteralSemestre();

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
        public IHttpActionResult GetUGI_LiteralSemestreDetails(int id_ugiliteralsemestre)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = uGI_LiteralSemestreRepository.GetUGI_LiteralSemestreDetails(id_ugiliteralsemestre);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Literal Semestre inexistente";
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
        public IHttpActionResult InsertUGI_LiteralSemestre([FromBody] UGI_LiteralSemestre uGI_LiteralSemestre)
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

                var created = uGI_LiteralSemestreRepository.InsertUGI_LiteralSemestre(uGI_LiteralSemestre);

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
        public IHttpActionResult UpdateUGI_LiteralSemestre([FromBody] UGI_LiteralSemestre uGI_LiteralSemestre)
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

                var created = uGI_LiteralSemestreRepository.UpdateUGI_LiteralSemestre(uGI_LiteralSemestre);

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
        public IHttpActionResult DeleteUGI_LiteralSemestre(int id_ugiliteralsemestre)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = uGI_LiteralSemestreRepository.DeleteUGI_LiteralSemestre(id_ugiliteralsemestre);

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
        public IHttpActionResult GetDataTableUGI_LiteralSemestre()
        {
            DataTableAdapter<UGI_LiteralSemestre> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = uGI_LiteralSemestreRepository.GetDataTableUGI_LiteralSemestre(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
        [HttpGet]
        public IHttpActionResult GetDataTableUGI_LiteralSemestreBySemestre(int id_ugisemestre)
        {
            DataTableAdapter<UGI_LiteralSemestre> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = uGI_LiteralSemestreRepository.GetDataTableUGI_LiteralSemestreBySemestre(id_ugisemestre, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
