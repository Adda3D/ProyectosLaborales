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
    public class DecVie_PlanAccionMetaController : BaseController<DecVie_PlanAccionMeta>
    {
        private readonly IDecVie_PlanAccionMetaRepository _decVie_PlanAccionMetaRepository;
        public DecVie_PlanAccionMetaController(IDecVie_PlanAccionMetaRepository decVie_PlanAccionMetaRepository)
        {
            _decVie_PlanAccionMetaRepository = decVie_PlanAccionMetaRepository;
        }
        readonly IDecVie_PlanAccionMetaRepository decVie_PlanAccionMetaRepository = new DecVie_PlanAccionMetaRepository();
        public DecVie_PlanAccionMetaController()
        {
            _decVie_PlanAccionMetaRepository = decVie_PlanAccionMetaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_PlanAccionMeta()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionMetaRepository.GetAllDecVie_PlanAccionMeta();

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
        public IHttpActionResult GetDecVie_PlanAccionMetaDetails(int id_meta)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionMetaRepository.GetDecVie_PlanAccionMetaDetails(id_meta);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_PlanAccionMeta inexistente";
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
        public IHttpActionResult GetDecVie_PlanAccionMetaNombre(string cd_nmmeta)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionMetaRepository.GetDecVie_PlanAccionMetaNombre(cd_nmmeta);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_PlanAccionMeta inexistente";
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
        public IHttpActionResult InsertDecVie_PlanAccionMeta([FromBody] DecVie_PlanAccionMeta decVie_PlanAccionMeta)
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

                var created = decVie_PlanAccionMetaRepository.InsertDecVie_PlanAccionMeta(decVie_PlanAccionMeta);

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
        public IHttpActionResult UpdateDecVie_PlanAccionMeta([FromBody] DecVie_PlanAccionMeta decVie_PlanAccionMeta)
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

                var created = decVie_PlanAccionMetaRepository.UpdateDecVie_PlanAccionMeta(decVie_PlanAccionMeta);

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
        public IHttpActionResult DeleteDecVie_PlanAccionMeta(int id_meta)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_PlanAccionMetaRepository.DeleteDecVie_PlanAccionMeta(id_meta);

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
        public IHttpActionResult GetDataTableDecVie_PlanAccionMeta()
        {
            DataTableAdapter<DecVie_PlanAccionMeta> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_PlanAccionMetaRepository.GetDataTableDecVie_PlanAccionMeta(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
