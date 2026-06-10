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
    public class Literal_UGIController : BaseController<Literal_UGI>
    {
        private readonly ILiteral_UGIRepository _literal_UGIRepository;

        public Literal_UGIController(ILiteral_UGIRepository literal_UGIRepository)
        {
            _literal_UGIRepository = literal_UGIRepository;
        }
        readonly ILiteral_UGIRepository literal_UGIRepository = new Literal_UGIRepository();
        public Literal_UGIController()
        {
            _literal_UGIRepository = literal_UGIRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllLiteral_UGI()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _literal_UGIRepository.GetAllLiteral_UGI();

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
        public IHttpActionResult GetLiteral_UGIDetails(int id_literal)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _literal_UGIRepository.GetLiteral_UGIDetails(id_literal);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Literal UGI inexistente";
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
        public IHttpActionResult GetLiteral_UGINombre(string cd_nmliteral)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _literal_UGIRepository.GetLiteral_UGINombre(cd_nmliteral);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Literal UGI inexistente";
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
        public IHttpActionResult InsertLiteral_UGI([FromBody] Literal_UGI literal_UGI)
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

                var created = _literal_UGIRepository.InsertLiteral_UGI(literal_UGI);

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
        public IHttpActionResult UpdateLiteral_UGI([FromBody] Literal_UGI literal_UGI)
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

                var created = _literal_UGIRepository.UpdateLiteral_UGI(literal_UGI);

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
        public IHttpActionResult DeleteLiteral_UGI(int id_literal)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = literal_UGIRepository.DeleteLiteral_UGI(id_literal);

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
        public IHttpActionResult GetDataTableLiteral_UGI()
        {
            DataTableAdapter<Literal_UGI> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = literal_UGIRepository.GetDataTableLiteral_UGI(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
