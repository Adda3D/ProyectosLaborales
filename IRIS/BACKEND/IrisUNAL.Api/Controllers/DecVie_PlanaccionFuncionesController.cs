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
    public class DecVie_PlanaccionFuncionesController : BaseController<DecVie_PlanaccionFunciones>
    {
        private readonly IDecVie_PlanaccionFuncionesRepository _decVie_PlanaccionFuncionesRepository;
        public DecVie_PlanaccionFuncionesController(IDecVie_PlanaccionFuncionesRepository decVie_PlanaccionFuncionesRepository)
        {
            _decVie_PlanaccionFuncionesRepository = decVie_PlanaccionFuncionesRepository;
        }
        readonly IDecVie_PlanaccionFuncionesRepository decVie_PlanaccionFuncionesRepository = new DecVie_PlanaccionFuncionesRepository();
        public DecVie_PlanaccionFuncionesController()
        {
            _decVie_PlanaccionFuncionesRepository = decVie_PlanaccionFuncionesRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_PlanaccionFunciones()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanaccionFuncionesRepository.GetAllDecVie_PlanaccionFunciones();

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
        public IHttpActionResult GetDecVie_PlanaccionFuncionesDetails(int id_funciones)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanaccionFuncionesRepository.GetDecVie_PlanaccionFuncionesDetails(id_funciones);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_PlanaccionFunciones inexistente";
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
        public IHttpActionResult GetDecVie_PlanaccionFuncionesNombre(string cd_nmfuncion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanaccionFuncionesRepository.GetDecVie_PlanaccionFuncionesNombre(cd_nmfuncion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_PlanaccionFunciones inexistente";
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
        public IHttpActionResult InsertDecVie_PlanaccionFunciones([FromBody] DecVie_PlanaccionFunciones decVie_PlanaccionFunciones)
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

                var created = decVie_PlanaccionFuncionesRepository.InsertDecVie_PlanaccionFunciones(decVie_PlanaccionFunciones);

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
        public IHttpActionResult UpdateDecVie_PlanaccionFunciones([FromBody] DecVie_PlanaccionFunciones decVie_PlanaccionFunciones)
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

                var created = decVie_PlanaccionFuncionesRepository.UpdateDecVie_PlanaccionFunciones(decVie_PlanaccionFunciones);

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
        public IHttpActionResult DeleteDecVie_PlanaccionFunciones(int id_funciones)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_PlanaccionFuncionesRepository.DeleteDecVie_PlanaccionFunciones(id_funciones);

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
        public IHttpActionResult GetDataTableDecVie_PlanaccionFunciones()
        {
            DataTableAdapter<DecVie_PlanaccionFunciones> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_PlanaccionFuncionesRepository.GetDataTableDecVie_PlanaccionFunciones(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
