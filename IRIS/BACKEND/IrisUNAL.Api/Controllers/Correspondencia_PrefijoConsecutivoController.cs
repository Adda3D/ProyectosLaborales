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
    public class Correspondencia_PrefijoConsecutivoController : BaseController<Correspondencia_PrefijoConsecutivo>
    {
        private readonly ICorrespondencia_PrefijoConsecutivoRepository _correspondencia_PrefijoConsecutivoRepository;
        public Correspondencia_PrefijoConsecutivoController(ICorrespondencia_PrefijoConsecutivoRepository correspondencia_PrefijoConsecutivoRepository)
        {
            _correspondencia_PrefijoConsecutivoRepository = correspondencia_PrefijoConsecutivoRepository;
        }
        readonly ICorrespondencia_PrefijoConsecutivoRepository correspondencia_PrefijoConsecutivoRepository = new Correspondencia_PrefijoConsecutivoRepository();
        public Correspondencia_PrefijoConsecutivoController()
        {
            _correspondencia_PrefijoConsecutivoRepository = correspondencia_PrefijoConsecutivoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllCorrespondencia_PrefijoConsecutivo()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = correspondencia_PrefijoConsecutivoRepository.GetAllCorrespondencia_PrefijoConsecutivo();

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
        public IHttpActionResult GetCorrespondencia_PrefijoConsecutivoByDependencia(int id_depend)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = correspondencia_PrefijoConsecutivoRepository.GetCorrespondencia_PrefijoConsecutivoByDependencia(id_depend);

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
        public IHttpActionResult GetCorrespondencia_PrefijoConsecutivoDetails(int id_prefijoconsecutivo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = correspondencia_PrefijoConsecutivoRepository.GetCorrespondencia_PrefijoConsecutivoDetails(id_prefijoconsecutivo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Prefijo inexistente";
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
        public IHttpActionResult GetCorrespondencia_PrefijoConsecutivoNombre(string cd_nmprefijo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = correspondencia_PrefijoConsecutivoRepository.GetCorrespondencia_PrefijoConsecutivoNombre(cd_nmprefijo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Prefijo inexistente";
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
        public IHttpActionResult InsertCorrespondencia_PrefijoConsecutivo([FromBody] Correspondencia_PrefijoConsecutivo correspondencia_PrefijoConsecutivo)
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

                var created = correspondencia_PrefijoConsecutivoRepository.InsertCorrespondencia_PrefijoConsecutivo(correspondencia_PrefijoConsecutivo);

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
        public IHttpActionResult UpdateCorrespondencia_PrefijoConsecutivo([FromBody] Correspondencia_PrefijoConsecutivo correspondencia_PrefijoConsecutivo)
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

                var created = correspondencia_PrefijoConsecutivoRepository.UpdateCorrespondencia_PrefijoConsecutivo(correspondencia_PrefijoConsecutivo);

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
        public IHttpActionResult DeleteCorrespondencia_PrefijoConsecutivo(int id_prefijoconsecutivo)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = correspondencia_PrefijoConsecutivoRepository.DeleteCorrespondencia_PrefijoConsecutivo(id_prefijoconsecutivo);

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
        public IHttpActionResult GetDataTableCorrespondencia_PrefijoConsecutivo()
        {
            DataTableAdapter<Correspondencia_PrefijoConsecutivo> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = correspondencia_PrefijoConsecutivoRepository.GetDataTableCorrespondencia_PrefijoConsecutivo(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
