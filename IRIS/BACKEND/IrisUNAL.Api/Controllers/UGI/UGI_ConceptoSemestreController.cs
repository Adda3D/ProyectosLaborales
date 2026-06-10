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
    public class UGI_ConceptoSemestreController : BaseController<UGI_ConceptoSemestre>
    {
        private readonly UGI_ConceptoSemestreRepository _uGI_ConceptoSemestreRepository;
        public UGI_ConceptoSemestreController (UGI_ConceptoSemestreRepository uGI_ConceptoSemestreRepository)
        {
            _uGI_ConceptoSemestreRepository = uGI_ConceptoSemestreRepository;
        }
        readonly UGI_ConceptoSemestreRepository uGI_ConceptoSemestreRepository = new UGI_ConceptoSemestreRepository();
        public UGI_ConceptoSemestreController()
        {
            _uGI_ConceptoSemestreRepository = uGI_ConceptoSemestreRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllUGI_ConceptoSemestre()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = uGI_ConceptoSemestreRepository.GetAllUGI_ConceptoSemestre();

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
        public IHttpActionResult GetUGI_ConceptoSemestreDetails(int id_ugiconceptosemestre)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = uGI_ConceptoSemestreRepository.GetUGI_ConceptoSemestreDetails(id_ugiconceptosemestre);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Concepto Semestre inexistente";
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
        public IHttpActionResult InsertUGI_ConceptoSemestre([FromBody] UGI_ConceptoSemestre uGI_ConceptoSemestre)
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

                var created = uGI_ConceptoSemestreRepository.InsertUGI_ConceptoSemestre(uGI_ConceptoSemestre);

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
        public IHttpActionResult UpdateUGI_ConceptoSemestre([FromBody] UGI_ConceptoSemestre uGI_ConceptoSemestre)
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

                var created = uGI_ConceptoSemestreRepository.UpdateUGI_ConceptoSemestre(uGI_ConceptoSemestre);

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
        public IHttpActionResult DeleteUGI_ConceptoSemestre(int id_ugiconceptosemestre)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = uGI_ConceptoSemestreRepository.DeleteUGI_ConceptoSemestre(id_ugiconceptosemestre);

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
        public IHttpActionResult GetDataTableUGI_ConceptoSemestreBySemestre(int id_ugiliteralsemestre)
        {
            DataTableAdapter<UGI_ConceptoSemestre> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = uGI_ConceptoSemestreRepository.GetDataTableUGI_ConceptoSemestreBySemestre(id_ugiliteralsemestre, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
