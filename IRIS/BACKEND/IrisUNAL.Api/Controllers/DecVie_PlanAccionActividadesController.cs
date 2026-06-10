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
    public class DecVie_PlanAccionActividadesController : BaseController<DecVie_PlanAccionActividades>
    {
        private readonly IDecVie_PlanAccionActividadesRepository _decVie_PlanAccionActividadesRepository;
        public DecVie_PlanAccionActividadesController(IDecVie_PlanAccionActividadesRepository decVie_PlanAccionActividadesRepository)
        {
            _decVie_PlanAccionActividadesRepository = decVie_PlanAccionActividadesRepository;
        }
        readonly IDecVie_PlanAccionActividadesRepository decVie_PlanAccionActividadesRepository = new DecVie_PlanAccionActividadesRepository();
        public DecVie_PlanAccionActividadesController()
        {
            _decVie_PlanAccionActividadesRepository = decVie_PlanAccionActividadesRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_PlanAccionActividades()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionActividadesRepository.GetAllDecVie_PlanAccionActividades();

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
        public IHttpActionResult GetDecVie_PlanAccionActividadesDetails(int id_actividades)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionActividadesRepository.GetDecVie_PlanAccionActividadesDetails(id_actividades);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_PlanAccionActividades inexistente";
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
        public IHttpActionResult GetDecVie_PlanAccionActividadesNombre(string cd_nmactividad)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionActividadesRepository.GetDecVie_PlanAccionActividadesNombre(cd_nmactividad);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_PlanAccionActividades inexistente";
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
        public IHttpActionResult InsertDecVie_PlanAccionActividades([FromBody] DecVie_PlanAccionActividades decVie_PlanAccionActividades)
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

                var created = decVie_PlanAccionActividadesRepository.InsertDecVie_PlanAccionActividades(decVie_PlanAccionActividades);

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
        public IHttpActionResult UpdateDecVie_PlanAccionActividades([FromBody] DecVie_PlanAccionActividades decVie_PlanAccionActividades)
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

                var created = decVie_PlanAccionActividadesRepository.UpdateDecVie_PlanAccionActividades(decVie_PlanAccionActividades);

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
        public IHttpActionResult DeleteDecVie_PlanAccionActividades(int id_actividades)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_PlanAccionActividadesRepository.DeleteDecVie_PlanAccionActividades(id_actividades);

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
        public IHttpActionResult GetDataTableDecVie_PlanAccionActividades()
        {
            DataTableAdapter<DecVie_PlanAccionActividades> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_PlanAccionActividadesRepository.GetDataTableDecVie_PlanAccionActividades(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
