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
    public class DecVie_PlanAccionObjetivoEstrategicoController : BaseController<DecVie_PlanAccionObjetivoEstrategico>
    {
        private readonly IDecVie_PlanAccionObjetivoEstrategicoRepository _decVie_PlanAccionObjetivoEstrategicoRepository;
        public DecVie_PlanAccionObjetivoEstrategicoController(IDecVie_PlanAccionObjetivoEstrategicoRepository decVie_PlanAccionObjetivoEstrategicoRepository)
        {
            _decVie_PlanAccionObjetivoEstrategicoRepository = decVie_PlanAccionObjetivoEstrategicoRepository;
        }
        readonly IDecVie_PlanAccionObjetivoEstrategicoRepository decVie_PlanAccionObjetivoEstrategicoRepository = new DecVie_PlanAccionObjetivoEstrategicoRepository();
        public DecVie_PlanAccionObjetivoEstrategicoController()
        {
            _decVie_PlanAccionObjetivoEstrategicoRepository = decVie_PlanAccionObjetivoEstrategicoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_PlanAccionObjetivoEstrategico()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionObjetivoEstrategicoRepository.GetAllDecVie_PlanAccionObjetivoEstrategico();

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
        public IHttpActionResult GetDecVie_PlanAccionObjetivoEstrategicoDetails(int id_objetivoestrategico)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionObjetivoEstrategicoRepository.GetDecVie_PlanAccionObjetivoEstrategicoDetails(id_objetivoestrategico);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_PlanAccionObjetivoEstrategico inexistente";
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
        public IHttpActionResult GetDecVie_PlanAccionObjetivoEstrategicoNombre(string cd_objetivoestrategico)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionObjetivoEstrategicoRepository.GetDecVie_PlanAccionObjetivoEstrategicoNombre(cd_objetivoestrategico);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_PlanAccionObjetivoEstrategico inexistente";
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
        public IHttpActionResult InsertDecVie_PlanAccionObjetivoEstrategico([FromBody] DecVie_PlanAccionObjetivoEstrategico decVie_PlanAccionObjetivoEstrategico)
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

                var created = decVie_PlanAccionObjetivoEstrategicoRepository.InsertDecVie_PlanAccionObjetivoEstrategico(decVie_PlanAccionObjetivoEstrategico);

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
        public IHttpActionResult UpdateDecVie_PlanAccionObjetivoEstrategico([FromBody] DecVie_PlanAccionObjetivoEstrategico decVie_PlanAccionObjetivoEstrategico)
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

                var created = decVie_PlanAccionObjetivoEstrategicoRepository.UpdateDecVie_PlanAccionObjetivoEstrategico(decVie_PlanAccionObjetivoEstrategico);

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
        public IHttpActionResult DeleteDecVie_PlanAccionObjetivoEstrategico(int id_objetivoestrategico)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_PlanAccionObjetivoEstrategicoRepository.DeleteDecVie_PlanAccionObjetivoEstrategico(id_objetivoestrategico);

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
        public IHttpActionResult GetDataTableDecVie_PlanAccionObjetivoEstrategico()
        {
            DataTableAdapter<DecVie_PlanAccionObjetivoEstrategico> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_PlanAccionObjetivoEstrategicoRepository.GetDataTableDecVie_PlanAccionObjetivoEstrategico(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}

