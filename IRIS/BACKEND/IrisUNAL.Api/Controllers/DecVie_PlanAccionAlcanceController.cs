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
    public class DecVie_PlanAccionAlcanceController : BaseController<DecVie_PlanAccionAlcance>
    {
        private readonly IDecVie_PlanAccionAlcanceRepository _decVie_PlanAccionAlcanceRepository;
        public DecVie_PlanAccionAlcanceController(IDecVie_PlanAccionAlcanceRepository decVie_PlanAccionAlcanceRepository)
        {
            _decVie_PlanAccionAlcanceRepository = decVie_PlanAccionAlcanceRepository;
        }
        readonly IDecVie_PlanAccionAlcanceRepository decVie_PlanAccionAlcanceRepository = new DecVie_PlanAccionAlcanceRepository();
        public DecVie_PlanAccionAlcanceController()
        {
            _decVie_PlanAccionAlcanceRepository = decVie_PlanAccionAlcanceRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_PlanAccionAlcance()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionAlcanceRepository.GetAllDecVie_PlanAccionAlcance();

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
        public IHttpActionResult GetDecVie_PlanAccionAlcanceDetails(int id_planaccionalcance)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionAlcanceRepository.GetDecVie_PlanAccionAlcanceDetails(id_planaccionalcance);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Descripción Alcance inexistente";
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
        public IHttpActionResult GetDecVie_PlanAccionAlcanceNombre(string cd_descripcionalcance)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionAlcanceRepository.GetDecVie_PlanAccionAlcanceNombre(cd_descripcionalcance);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Descripción Alcance inexistente";
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
        public IHttpActionResult InsertDecVie_PlanAccionAlcance([FromBody] DecVie_PlanAccionAlcance decVie_PlanAccionAlcance)
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

                var created = decVie_PlanAccionAlcanceRepository.InsertDecVie_PlanAccionAlcance(decVie_PlanAccionAlcance);

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
        public IHttpActionResult UpdateDecVie_PlanAccionAlcance([FromBody] DecVie_PlanAccionAlcance decVie_PlanAccionAlcance)
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

                var created = decVie_PlanAccionAlcanceRepository.UpdateDecVie_PlanAccionAlcance(decVie_PlanAccionAlcance);

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
        public IHttpActionResult DeleteDecVie_PlanAccionAlcance(int id_planaccionalcance)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_PlanAccionAlcanceRepository.DeleteDecVie_PlanAccionAlcance(id_planaccionalcance);

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
        public IHttpActionResult GetDataTableDecVie_PlanAccionAlcance()
        {
            DataTableAdapter<DecVie_PlanAccionAlcance> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_PlanAccionAlcanceRepository.GetDataTableDecVie_PlanAccionAlcance(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
