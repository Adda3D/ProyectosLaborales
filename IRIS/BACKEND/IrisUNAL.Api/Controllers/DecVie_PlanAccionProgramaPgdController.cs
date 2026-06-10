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
    public class DecVie_PlanAccionProgramaPgdController : BaseController<DecVie_PlanAccionProgramaPgd>
    {
        private readonly IDecVie_PlanAccionProgramaPgdRepository _decVie_PlanAccionProgramaPgdRepository;
        public DecVie_PlanAccionProgramaPgdController(IDecVie_PlanAccionProgramaPgdRepository decVie_PlanAccionProgramaPgdRepository)
        {
            _decVie_PlanAccionProgramaPgdRepository = decVie_PlanAccionProgramaPgdRepository;
        }
        readonly IDecVie_PlanAccionProgramaPgdRepository decVie_PlanAccionProgramaPgdRepository = new DecVie_PlanAccionProgramaPgdRepository();
        public DecVie_PlanAccionProgramaPgdController()
        {
            _decVie_PlanAccionProgramaPgdRepository = decVie_PlanAccionProgramaPgdRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_PlanAccionProgramaPgd()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionProgramaPgdRepository.GetAllDecVie_PlanAccionProgramaPgd();

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
        public IHttpActionResult GetDecVie_PlanAccionProgramaPgdDetails(int id_programapgd)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionProgramaPgdRepository.GetDecVie_PlanAccionProgramaPgdDetails(id_programapgd);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "ProgramaPgd inexistente";
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
        public IHttpActionResult GetDecVie_PlanAccionProgramaPgdNombre(string cd_nmprogramapgd)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionProgramaPgdRepository.GetDecVie_PlanAccionProgramaPgdNombre(cd_nmprogramapgd);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "ProgramaPgd inexistente";
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
        public IHttpActionResult InsertDecVie_PlanAccionProgramaPgd([FromBody] DecVie_PlanAccionProgramaPgd decVie_PlanAccionProgramaPgd)
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

                var created = decVie_PlanAccionProgramaPgdRepository.InsertDecVie_PlanAccionProgramaPgd(decVie_PlanAccionProgramaPgd);

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
        public IHttpActionResult UpdateDecVie_PlanAccionProgramaPgd([FromBody] DecVie_PlanAccionProgramaPgd decVie_PlanAccionProgramaPgd)
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

                var created = decVie_PlanAccionProgramaPgdRepository.UpdateDecVie_PlanAccionProgramaPgd(decVie_PlanAccionProgramaPgd);

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
        public IHttpActionResult DeleteDecVie_PlanAccionProgramaPgd(int id_programapgd)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_PlanAccionProgramaPgdRepository.DeleteDecVie_PlanAccionProgramaPgd(id_programapgd);

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
        public IHttpActionResult GetDataTableDecVie_PlanAccionProgramaPgd()
        {
            DataTableAdapter<DecVie_PlanAccionProgramaPgd> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_PlanAccionProgramaPgdRepository.GetDataTableDecVie_PlanAccionProgramaPgd(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
