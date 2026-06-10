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
    public class UGI_SemestreController : BaseController<UGI_Semestre>
    {
        private readonly UGI_SemestreRepository _uGI_SemestreRepository;
        public UGI_SemestreController (UGI_SemestreRepository uGI_SemestreRepository)
        {
            _uGI_SemestreRepository = uGI_SemestreRepository;
        }
        readonly UGI_SemestreRepository uGI_SemestreRepository = new UGI_SemestreRepository();
        public UGI_SemestreController()
        {
            _uGI_SemestreRepository = uGI_SemestreRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllUGI_Semestre()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = uGI_SemestreRepository.GetAllUGI_Semestre();

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
        public IHttpActionResult GetUGI_SemestreDetails(int id_ugisemestre)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = uGI_SemestreRepository.GetUGI_SemestreDetails(id_ugisemestre);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "UGI Semestre inexistente";
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
        public IHttpActionResult InsertUGI_Semestre([FromBody] UGI_Semestre uGI_Semestre)
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

                var created = uGI_SemestreRepository.InsertUGI_Semestre(uGI_Semestre);

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
        public IHttpActionResult UpdateUGI_Semestre([FromBody] UGI_Semestre uGI_Semestre)
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

                var created = uGI_SemestreRepository.UpdateUGI_Semestre(uGI_Semestre);

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
        public IHttpActionResult DeleteUGI_Semestre(int id_ugisemestre)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = uGI_SemestreRepository.DeleteUGI_Semestre(id_ugisemestre);

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
        public IHttpActionResult GetDataTableUGI_Semestre()
        {
            DataTableAdapter<UGI_Semestre> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = uGI_SemestreRepository.GetDataTableUGI_Semestre(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

        [HttpGet]

        public IHttpActionResult ExcelUGI_Semestre(int id_ugisemestre)
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = uGI_SemestreRepository.ExcelUGI_Semestre(id_ugisemestre);

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
