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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Concepto_UGIController : BaseController<Concepto_UGI>
    {
        private readonly IConcepto_UGIRepository _concepto_UGIRepository;

        public Concepto_UGIController(IConcepto_UGIRepository concepto_UGIRepository)
        {
            _concepto_UGIRepository = concepto_UGIRepository;
        }
        readonly IConcepto_UGIRepository concepto_UGIRepository = new Concepto_UGIRepository();
        public Concepto_UGIController()
        {
            _concepto_UGIRepository = concepto_UGIRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllConcepto_UGI()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _concepto_UGIRepository.GetAllConcepto_UGI();

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
        public IHttpActionResult GetConcepto_UGIDetails(int id_conceptougi)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _concepto_UGIRepository.GetConcepto_UGIDetails(id_conceptougi);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Código inexistente";
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
        public IHttpActionResult GetConcepto_UGINombre(string cd_concepto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _concepto_UGIRepository.GetConcepto_UGINombre(cd_concepto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Código inexistente";
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
        public IHttpActionResult InsertConcepto_UGI([FromBody] Concepto_UGI concepto_UGI)
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

                var created = _concepto_UGIRepository.InsertConcepto_UGI(concepto_UGI);

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
        public IHttpActionResult UpdateConcepto_UGI([FromBody] Concepto_UGI concepto_UGI)
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

                var created = _concepto_UGIRepository.UpdateConcepto_UGI(concepto_UGI);

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
        public IHttpActionResult DeleteConcepto_UGI(int id_conceptougi)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _concepto_UGIRepository.DeleteConcepto_UGI(id_conceptougi);

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
        public IHttpActionResult GetDataTableConcepto_UGI()
        {
            DataTableAdapter<Concepto_UGI> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _concepto_UGIRepository.GetDataTableConcepto_UGI(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
