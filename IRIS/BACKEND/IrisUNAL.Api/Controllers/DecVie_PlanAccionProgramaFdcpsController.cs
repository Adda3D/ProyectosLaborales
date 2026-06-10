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
    public class DecVie_PlanAccionProgramaFdcpsController : BaseController<DecVie_PlanAccionProgramaFdcps>
    {
        private readonly IDecVie_PlanAccionProgramaFdcpsRepository _decVie_PlanAccionProgramaFdcpsRepository;
        public DecVie_PlanAccionProgramaFdcpsController(IDecVie_PlanAccionProgramaFdcpsRepository decVie_PlanAccionProgramaFdcpsRepository)
        {
            _decVie_PlanAccionProgramaFdcpsRepository = decVie_PlanAccionProgramaFdcpsRepository;
        }
        readonly IDecVie_PlanAccionProgramaFdcpsRepository decVie_PlanAccionProgramaFdcpsRepository = new DecVie_PlanAccionProgramaFdcpsRepository();
        public DecVie_PlanAccionProgramaFdcpsController()
        {
            _decVie_PlanAccionProgramaFdcpsRepository = decVie_PlanAccionProgramaFdcpsRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_PlanAccionProgramaFdcps()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionProgramaFdcpsRepository.GetAllDecVie_PlanAccionProgramaFdcps();

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
        public IHttpActionResult GetDecVie_PlanAccionProgramaFdcpsDetails(int id_programafdcps)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionProgramaFdcpsRepository.GetDecVie_PlanAccionProgramaFdcpsDetails(id_programafdcps);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "ProgramaFdcps inexistente";
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
        public IHttpActionResult GetDecVie_PlanAccionProgramaFdcpsNombre(string cd_programafacultad)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionProgramaFdcpsRepository.GetDecVie_PlanAccionProgramaFdcpsNombre(cd_programafacultad);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "ProgramaFdcps inexistente";
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
        public IHttpActionResult InsertDecVie_PlanAccionProgramaFdcps([FromBody] DecVie_PlanAccionProgramaFdcps decVie_PlanAccionProgramaFdcps)
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

                var created = decVie_PlanAccionProgramaFdcpsRepository.InsertDecVie_PlanAccionProgramaFdcps(decVie_PlanAccionProgramaFdcps);

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
        public IHttpActionResult UpdateDecVie_PlanAccionProgramaFdcps([FromBody] DecVie_PlanAccionProgramaFdcps decVie_PlanAccionProgramaFdcps)
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

                var created = decVie_PlanAccionProgramaFdcpsRepository.UpdateDecVie_PlanAccionProgramaFdcps(decVie_PlanAccionProgramaFdcps);

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
        public IHttpActionResult DeleteDecVie_PlanAccionProgramaFdcps(int id_programafdcps)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_PlanAccionProgramaFdcpsRepository.DeleteDecVie_PlanAccionProgramaFdcps(id_programafdcps);

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
        public IHttpActionResult GetDataTableDecVie_PlanAccionProgramaFdcps()
        {
            DataTableAdapter<DecVie_PlanAccionProgramaFdcps> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_PlanAccionProgramaFdcpsRepository.GetDataTableDecVie_PlanAccionProgramaFdcps(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
