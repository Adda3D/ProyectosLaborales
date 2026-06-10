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
    public class DecVie_PlanAccionLineaPoliticaController : BaseController<DecVie_PlanAccionLineaPolitica>
    {
        private readonly IDecVie_PlanAccionLineaPoliticaRepository _decVie_PlanAccionLineaPoliticaRepository;
        public DecVie_PlanAccionLineaPoliticaController(IDecVie_PlanAccionLineaPoliticaRepository decVie_PlanAccionLineaPoliticaRepository)
        {
            _decVie_PlanAccionLineaPoliticaRepository = decVie_PlanAccionLineaPoliticaRepository;
        }
        readonly IDecVie_PlanAccionLineaPoliticaRepository decVie_PlanAccionLineaPoliticaRepository = new DecVie_PlanAccionLineaPoliticaRepository();
        public DecVie_PlanAccionLineaPoliticaController()
        {
            _decVie_PlanAccionLineaPoliticaRepository = decVie_PlanAccionLineaPoliticaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_PlanAccionLineaPolitica()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionLineaPoliticaRepository.GetAllDecVie_PlanAccionLineaPolitica();

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
        public IHttpActionResult GetDecVie_PlanAccionLineaPoliticaDetails(int id_lineapolitica)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionLineaPoliticaRepository.GetDecVie_PlanAccionLineaPoliticaDetails(id_lineapolitica);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_PlanAccionLineaPolitica inexistente";
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
        public IHttpActionResult GetDecVie_PlanAccionLineaPoliticaNombre(string cd_lineapolitica)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionLineaPoliticaRepository.GetDecVie_PlanAccionLineaPoliticaNombre(cd_lineapolitica);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_PlanAccionLineaPolitica inexistente";
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
        public IHttpActionResult InsertDecVie_PlanAccionLineaPolitica([FromBody] DecVie_PlanAccionLineaPolitica decVie_PlanAccionLineaPolitica)
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

                var created = decVie_PlanAccionLineaPoliticaRepository.InsertDecVie_PlanAccionLineaPolitica(decVie_PlanAccionLineaPolitica);

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
        public IHttpActionResult UpdateDecVie_PlanAccionLineaPolitica([FromBody] DecVie_PlanAccionLineaPolitica decVie_PlanAccionLineaPolitica)
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

                var created = decVie_PlanAccionLineaPoliticaRepository.UpdateDecVie_PlanAccionLineaPolitica(decVie_PlanAccionLineaPolitica);

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
        public IHttpActionResult DeleteDecVie_PlanAccionLineaPolitica(int id_lineapolitica)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_PlanAccionLineaPoliticaRepository.DeleteDecVie_PlanAccionLineaPolitica(id_lineapolitica);

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
        public IHttpActionResult GetDataTableDecVie_PlanAccionLineaPolitica()
        {
            DataTableAdapter<DecVie_PlanAccionLineaPolitica> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_PlanAccionLineaPoliticaRepository.GetDataTableDecVie_PlanAccionLineaPolitica(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
