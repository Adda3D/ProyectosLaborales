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
    public class DecVie_PlanAccionMatryoshkaController : BaseController<DecVie_PlanAccionMatryoshka>
    {
        private readonly IDecVie_PlanAccionMatryoshkaRepository _decVie_PlanAccionMatryoshkaRepository;
        public DecVie_PlanAccionMatryoshkaController(IDecVie_PlanAccionMatryoshkaRepository decVie_PlanAccionMatryoshkaRepository)
        {
            _decVie_PlanAccionMatryoshkaRepository = decVie_PlanAccionMatryoshkaRepository;
        }
        readonly IDecVie_PlanAccionMatryoshkaRepository decVie_PlanAccionMatryoshkaRepository = new DecVie_PlanAccionMatryoshkaRepository();
        public DecVie_PlanAccionMatryoshkaController()
        {
            _decVie_PlanAccionMatryoshkaRepository = decVie_PlanAccionMatryoshkaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_PlanAccionMatryoshka()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionMatryoshkaRepository.GetAllDecVie_PlanAccionMatryoshka();

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
        public IHttpActionResult GetDecVie_PlanAccionMatryoshkaDetails(int id_matryoshka)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionMatryoshkaRepository.GetDecVie_PlanAccionMatryoshkaDetails(id_matryoshka);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_PlanAccionMatryoshka inexistente";
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
        public IHttpActionResult InsertDecVie_PlanAccionMatryoshka([FromBody] DecVie_PlanAccionMatryoshka decVie_PlanAccionMatryoshka)
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

                var created = decVie_PlanAccionMatryoshkaRepository.InsertDecVie_PlanAccionMatryoshka(decVie_PlanAccionMatryoshka);

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
        public IHttpActionResult UpdateDecVie_PlanAccionMatryoshka([FromBody] DecVie_PlanAccionMatryoshka decVie_PlanAccionMatryoshka)
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

                var created = decVie_PlanAccionMatryoshkaRepository.UpdateDecVie_PlanAccionMatryoshka(decVie_PlanAccionMatryoshka);

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
        public IHttpActionResult DeleteDecVie_PlanAccionMatryoshka(int id_matryoshka)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_PlanAccionMatryoshkaRepository.DeleteDecVie_PlanAccionMatryoshka(id_matryoshka);

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
        public IHttpActionResult GetDataTableDecVie_PlanAccionMatryoshka()
        {
            DataTableAdapter<DecVie_PlanAccionMatryoshka> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_PlanAccionMatryoshkaRepository.GetDataTableDecVie_PlanAccionMatryoshka(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
