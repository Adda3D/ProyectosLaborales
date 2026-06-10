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
    public class DecVie_PlanAccionEjeEstrategicoController : BaseController<DecVie_PlanAccionEjeEstrategico>
    {
        private readonly IDecVie_PlanAccionEjeEstrategicoRepository _decVie_PlanAccionEjeEstrategicoRepository;
        public DecVie_PlanAccionEjeEstrategicoController(IDecVie_PlanAccionEjeEstrategicoRepository decVie_PlanAccionEjeEstrategicoRepository)
        {
            _decVie_PlanAccionEjeEstrategicoRepository = decVie_PlanAccionEjeEstrategicoRepository;
        }
        readonly IDecVie_PlanAccionEjeEstrategicoRepository decVie_PlanAccionEjeEstrategicoRepository = new DecVie_PlanAccionEjeEstrategicoRepository();
        public DecVie_PlanAccionEjeEstrategicoController()
        {
            _decVie_PlanAccionEjeEstrategicoRepository = decVie_PlanAccionEjeEstrategicoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_PlanAccionEjeEstrategico()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionEjeEstrategicoRepository.GetAllDecVie_PlanAccionEjeEstrategico();

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
        public IHttpActionResult GetDecVie_PlanAccionEjeEstrategicoDetails(int id_ejeestrategico)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionEjeEstrategicoRepository.GetDecVie_PlanAccionEjeEstrategicoDetails(id_ejeestrategico);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Eje Estrategico inexistente";
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
        public IHttpActionResult GetDecVie_PlanAccionEjeEstrategicoNombre(string cd_ejeestrategico)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionEjeEstrategicoRepository.GetDecVie_PlanAccionEjeEstrategicoNombre(cd_ejeestrategico);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Eje Estrategico inexistente";
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
        public IHttpActionResult InsertDecVie_PlanAccionEjeEstrategico([FromBody] DecVie_PlanAccionEjeEstrategico decVie_PlanAccionEjeEstrategico)
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

                var created = decVie_PlanAccionEjeEstrategicoRepository.InsertDecVie_PlanAccionEjeEstrategico(decVie_PlanAccionEjeEstrategico);

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
        public IHttpActionResult UpdateDecVie_PlanAccionEjeEstrategico([FromBody] DecVie_PlanAccionEjeEstrategico decVie_PlanAccionEjeEstrategico)
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

                var created = decVie_PlanAccionEjeEstrategicoRepository.UpdateDecVie_PlanAccionEjeEstrategico(decVie_PlanAccionEjeEstrategico);

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
        public IHttpActionResult DeleteDecVie_PlanAccionEjeEstrategico(int id_ejeestrategico)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_PlanAccionEjeEstrategicoRepository.DeleteDecVie_PlanAccionEjeEstrategico(id_ejeestrategico);

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
        public IHttpActionResult GetDataTableDecVie_PlanAccionEjeEstrategico()
        {
            DataTableAdapter<DecVie_PlanAccionEjeEstrategico> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_PlanAccionEjeEstrategicoRepository.GetDataTableDecVie_PlanAccionEjeEstrategico(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
