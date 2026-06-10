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
    public class DecVie_PlanAccionObjetivosPgdVriSedeController : BaseController<DecVie_PlanAccionObjetivosPgdVriSede>
    {
        private readonly IDecVie_PlanAccionObjetivosPgdVriSedeRepository _decVie_PlanAccionObjetivosPgdVriSedeRepository;
        public DecVie_PlanAccionObjetivosPgdVriSedeController (IDecVie_PlanAccionObjetivosPgdVriSedeRepository decVie_PlanAccionObjetivosPgdVriSedeRepository)
        {
            _decVie_PlanAccionObjetivosPgdVriSedeRepository = decVie_PlanAccionObjetivosPgdVriSedeRepository;
        }
        readonly IDecVie_PlanAccionObjetivosPgdVriSedeRepository decVie_PlanAccionObjetivosPgdVriSedeRepository = new DecVie_PlanAccionObjetivosPgdVriSedeRepository();
        public DecVie_PlanAccionObjetivosPgdVriSedeController()
        {
            _decVie_PlanAccionObjetivosPgdVriSedeRepository = decVie_PlanAccionObjetivosPgdVriSedeRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_PlanAccionObjetivosPgdVriSede()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _decVie_PlanAccionObjetivosPgdVriSedeRepository.GetAllDecVie_PlanAccionObjetivosPgdVriSede();

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
        public IHttpActionResult GetDecVie_PlanAccionObjetivosPgdVriSedeDetails(int id_objetivopgdvrisede)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _decVie_PlanAccionObjetivosPgdVriSedeRepository.GetDecVie_PlanAccionObjetivosPgdVriSedeDetails(id_objetivopgdvrisede);

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
        public IHttpActionResult GetDecVie_PlanAccionObjetivosPgdVriSedeNombre(string cd_nmobjetivopgdvrisede)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _decVie_PlanAccionObjetivosPgdVriSedeRepository.GetDecVie_PlanAccionObjetivosPgdVriSedeNombre(cd_nmobjetivopgdvrisede);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_PlanAccionTipoIndicador inexistente";
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
        public IHttpActionResult InsertDecVie_PlanAccionObjetivosPgdVriSede([FromBody] DecVie_PlanAccionObjetivosPgdVriSede decVie_PlanAccionObjetivosPgdVriSede)
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

                var created = _decVie_PlanAccionObjetivosPgdVriSedeRepository.InsertDecVie_PlanAccionObjetivosPgdVriSede(decVie_PlanAccionObjetivosPgdVriSede);

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
        public IHttpActionResult UpdateDecVie_PlanAccionObjetivosPgdVriSede([FromBody] DecVie_PlanAccionObjetivosPgdVriSede decVie_PlanAccionObjetivosPgdVriSede)
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

                var created = _decVie_PlanAccionObjetivosPgdVriSedeRepository.UpdateDecVie_PlanAccionObjetivosPgdVriSede(decVie_PlanAccionObjetivosPgdVriSede);

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
        public IHttpActionResult DeleteDecVie_PlanAccionObjetivosPgdVriSede(int id_objetivopgdvrisede)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _decVie_PlanAccionObjetivosPgdVriSedeRepository.DeleteDecVie_PlanAccionObjetivosPgdVriSede(id_objetivopgdvrisede);

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
        public IHttpActionResult GetDataTableDecVie_PlanAccionObjetivosPgdVriSede()
        {
            DataTableAdapter<DecVie_PlanAccionObjetivosPgdVriSede> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _decVie_PlanAccionObjetivosPgdVriSedeRepository.GetDataTableDecVie_PlanAccionObjetivosPgdVriSede(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
