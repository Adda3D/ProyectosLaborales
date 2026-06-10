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
    public class DecVie_PlanAccionObjetivoDependenciaController : BaseController<DecVie_PlanAccionObjetivoDependencia>
    {
        private readonly IDecVie_PlanAccionObjetivoDependenciaRepository _decVie_PlanAccionObjetivoDependenciaRepository;
        public DecVie_PlanAccionObjetivoDependenciaController(IDecVie_PlanAccionObjetivoDependenciaRepository decVie_PlanAccionObjetivoDependenciaRepository)
        {
            _decVie_PlanAccionObjetivoDependenciaRepository = decVie_PlanAccionObjetivoDependenciaRepository;
        }
        readonly IDecVie_PlanAccionObjetivoDependenciaRepository decVie_PlanAccionObjetivoDependenciaRepository = new DecVie_PlanAccionObjetivoDependenciaRepository();
        public DecVie_PlanAccionObjetivoDependenciaController()
        {
            _decVie_PlanAccionObjetivoDependenciaRepository = decVie_PlanAccionObjetivoDependenciaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_PlanAccionObjetivoDependencia()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _decVie_PlanAccionObjetivoDependenciaRepository.GetAllDecVie_PlanAccionObjetivoDependencia();

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
        public IHttpActionResult GetDecVie_PlanAccionObjetivoDependenciaDetails(int id_objetivodependencia)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _decVie_PlanAccionObjetivoDependenciaRepository.GetDecVie_PlanAccionObjetivoDependenciaDetails(id_objetivodependencia);

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
        public IHttpActionResult GetDecVie_PlanAccionObjetivoDependenciaNombre(string cd_nmobjetivodependencia)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _decVie_PlanAccionObjetivoDependenciaRepository.GetDecVie_PlanAccionObjetivoDependenciaNombre(cd_nmobjetivodependencia);

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
        public IHttpActionResult InsertDecVie_PlanAccionObjetivoDependencia([FromBody] DecVie_PlanAccionObjetivoDependencia decVie_PlanAccionObjetivoDependencia)
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

                var created = _decVie_PlanAccionObjetivoDependenciaRepository.InsertDecVie_PlanAccionObjetivoDependencia(decVie_PlanAccionObjetivoDependencia);

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
        public IHttpActionResult UpdateDecVie_PlanAccionObjetivoDependencia([FromBody] DecVie_PlanAccionObjetivoDependencia decVie_PlanAccionObjetivoDependencia)
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

                var created = _decVie_PlanAccionObjetivoDependenciaRepository.UpdateDecVie_PlanAccionObjetivoDependencia(decVie_PlanAccionObjetivoDependencia);

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
        public IHttpActionResult DeleteDecVie_PlanAccionObjetivoDependencia(int id_objetivodependencia)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _decVie_PlanAccionObjetivoDependenciaRepository.DeleteDecVie_PlanAccionObjetivoDependencia(id_objetivodependencia);

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
        public IHttpActionResult GetDataTableDecVie_PlanAccionObjetivoDependencia()
        {
            DataTableAdapter<DecVie_PlanAccionObjetivoDependencia> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _decVie_PlanAccionObjetivoDependenciaRepository.GetDataTableDecVie_PlanAccionObjetivoDependencia(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
