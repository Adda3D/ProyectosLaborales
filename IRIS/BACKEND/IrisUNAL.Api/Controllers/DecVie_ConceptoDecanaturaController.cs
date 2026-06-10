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
    public class DecVie_ConceptoDecanaturaController : BaseController<DecVie_ConceptoDecanatura>
    {
        private readonly IDecVie_ConceptoDecanaturaRepository _decVie_ConceptoDecanaturaRepository;
        public DecVie_ConceptoDecanaturaController(IDecVie_ConceptoDecanaturaRepository decVie_ConceptoDecanaturaRepository)
        {
            _decVie_ConceptoDecanaturaRepository = decVie_ConceptoDecanaturaRepository;
        }
        readonly IDecVie_ConceptoDecanaturaRepository decVie_ConceptoDecanaturaRepository = new DecVie_ConceptoDecanaturaRepository();
        public DecVie_ConceptoDecanaturaController()
        {
            _decVie_ConceptoDecanaturaRepository = decVie_ConceptoDecanaturaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_ConceptoDecanatura()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ConceptoDecanaturaRepository.GetAllDecVie_ConceptoDecanatura();

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
        public IHttpActionResult GetDecVie_ConceptoDecanaturaDetails(int id_conceptodecanatura)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ConceptoDecanaturaRepository.GetDecVie_ConceptoDecanaturaDetails(id_conceptodecanatura);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_ConceptoDecanatura inexistente";
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
        public IHttpActionResult GetDecVie_ConceptoDecanaturaNombre(string cd_nmconceptodecanatura)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ConceptoDecanaturaRepository.GetDecVie_ConceptoDecanaturaNombre(cd_nmconceptodecanatura);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_ConceptoDecanatura inexistente";
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
        public IHttpActionResult InsertDecVie_ConceptoDecanatura([FromBody] DecVie_ConceptoDecanatura decVie_ConceptoDecanatura)
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

                var created = decVie_ConceptoDecanaturaRepository.InsertDecVie_ConceptoDecanatura(decVie_ConceptoDecanatura);

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
        public IHttpActionResult UpdateDecVie_ConceptoDecanatura([FromBody] DecVie_ConceptoDecanatura decVie_ConceptoDecanatura)
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

                var created = decVie_ConceptoDecanaturaRepository.UpdateDecVie_ConceptoDecanatura(decVie_ConceptoDecanatura);

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
        public IHttpActionResult DeleteDecVie_ConceptoDecanatura(int id_conceptodecanatura)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_ConceptoDecanaturaRepository.DeleteDecVie_ConceptoDecanatura(id_conceptodecanatura);

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
        public IHttpActionResult GetDataTableDecVie_ConceptoDecanatura()
        {
            DataTableAdapter<DecVie_ConceptoDecanatura> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_ConceptoDecanaturaRepository.GetDataTableDecVie_ConceptoDecanatura(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
