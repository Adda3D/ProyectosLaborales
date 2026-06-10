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
    public class DecVie_PlanAccionTipoIndicadorController : BaseController<DecVie_PlanAccionTipoIndicador>
    {
        private readonly IDecVie_PlanAccionTipoIndicadorRepository _decVie_PlanAccionTipoIndicadorRepository;
        public DecVie_PlanAccionTipoIndicadorController(IDecVie_PlanAccionTipoIndicadorRepository decVie_PlanAccionTipoIndicadorRepository)
        {
            _decVie_PlanAccionTipoIndicadorRepository = decVie_PlanAccionTipoIndicadorRepository;
        }
        readonly IDecVie_PlanAccionTipoIndicadorRepository decVie_PlanAccionTipoIndicadorRepository = new DecVie_PlanAccionTipoIndicadorRepository();
        public DecVie_PlanAccionTipoIndicadorController()
        {
            _decVie_PlanAccionTipoIndicadorRepository = decVie_PlanAccionTipoIndicadorRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_PlanAccionTipoIndicador()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionTipoIndicadorRepository.GetAllDecVie_PlanAccionTipoIndicador();

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
        public IHttpActionResult GetDecVie_PlanAccionTipoIndicadorDetails(int id_tipoindicador)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionTipoIndicadorRepository.GetDecVie_PlanAccionTipoIndicadorDetails(id_tipoindicador);

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

        [HttpGet]
        public IHttpActionResult GetDecVie_PlanAccionTipoIndicadorNombre(string cd_nmtipoindicador)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionTipoIndicadorRepository.GetDecVie_PlanAccionTipoIndicadorNombre(cd_nmtipoindicador);

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
        public IHttpActionResult InsertDecVie_PlanAccionTipoIndicador([FromBody] DecVie_PlanAccionTipoIndicador decVie_PlanAccionTipoIndicador)
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

                var created = decVie_PlanAccionTipoIndicadorRepository.InsertDecVie_PlanAccionTipoIndicador(decVie_PlanAccionTipoIndicador);

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
        public IHttpActionResult UpdateDecVie_PlanAccionTipoIndicador([FromBody] DecVie_PlanAccionTipoIndicador decVie_PlanAccionTipoIndicador)
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

                var created = decVie_PlanAccionTipoIndicadorRepository.UpdateDecVie_PlanAccionTipoIndicador(decVie_PlanAccionTipoIndicador);

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
        public IHttpActionResult DeleteDecVie_PlanAccionTipoIndicador(int id_tipoindicador)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_PlanAccionTipoIndicadorRepository.DeleteDecVie_PlanAccionTipoIndicador(id_tipoindicador);

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
        public IHttpActionResult GetDataTableDecVie_PlanAccionTipoIndicador()
        {
            DataTableAdapter<DecVie_PlanAccionTipoIndicador> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _decVie_PlanAccionTipoIndicadorRepository.GetDataTableDecVie_PlanAccionTipoIndicador(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
