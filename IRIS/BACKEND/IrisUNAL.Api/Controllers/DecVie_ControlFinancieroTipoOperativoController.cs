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
    public class DecVie_ControlFinancieroTipoOperativoController : BaseController<DecVie_ControlFinancieroTipoOperativo>
    {
        private readonly IDecVie_ControlFinancieroTipoOperativoRepository _decVie_ControlFinancieroTipoOperativoRepository;
        public DecVie_ControlFinancieroTipoOperativoController(IDecVie_ControlFinancieroTipoOperativoRepository decVie_ControlFinancieroTipoOperativoRepository)
        {
            _decVie_ControlFinancieroTipoOperativoRepository = decVie_ControlFinancieroTipoOperativoRepository;
        }
        readonly IDecVie_ControlFinancieroTipoOperativoRepository decVie_ControlFinancieroTipoOperativoRepository = new DecVie_ControlFinancieroTipoOperativoRepository();
        public DecVie_ControlFinancieroTipoOperativoController()
        {
            _decVie_ControlFinancieroTipoOperativoRepository = decVie_ControlFinancieroTipoOperativoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_ControlFinancieroTipoOperativo()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ControlFinancieroTipoOperativoRepository.GetAllDecVie_ControlFinancieroTipoOperativo();

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
        public IHttpActionResult GetDecVie_ControlFinancieroTipoOperativoDetails(int id_tipooperativo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ControlFinancieroTipoOperativoRepository.GetDecVie_ControlFinancieroTipoOperativoDetails(id_tipooperativo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_ControlFinancieroTipoOperativo inexistente";
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
        public IHttpActionResult GetDecVie_ControlFinancieroTipoOperativoNombre(string cd_nmtipooperativo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ControlFinancieroTipoOperativoRepository.GetDecVie_ControlFinancieroTipoOperativoNombre(cd_nmtipooperativo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_ControlFinancieroTipoOperativo inexistente";
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
        public IHttpActionResult InsertDecVie_ControlFinancieroTipoOperativo([FromBody] DecVie_ControlFinancieroTipoOperativo decVie_ControlFinancieroTipoOperativo)
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

                var created = decVie_ControlFinancieroTipoOperativoRepository.InsertDecVie_ControlFinancieroTipoOperativo(decVie_ControlFinancieroTipoOperativo);

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
        public IHttpActionResult UpdateDecVie_ControlFinancieroTipoOperativo([FromBody] DecVie_ControlFinancieroTipoOperativo decVie_ControlFinancieroTipoOperativo)
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

                var created = decVie_ControlFinancieroTipoOperativoRepository.UpdateDecVie_ControlFinancieroTipoOperativo(decVie_ControlFinancieroTipoOperativo);

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
        public IHttpActionResult DeleteDecVie_ControlFinancieroTipoOperativo(int id_tipooperativo)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_ControlFinancieroTipoOperativoRepository.DeleteDecVie_ControlFinancieroTipoOperativo(id_tipooperativo);

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
        public IHttpActionResult GetDataTableDecVie_ControlFinancieroTipoOperativo()
        {
            DataTableAdapter<DecVie_ControlFinancieroTipoOperativo> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_ControlFinancieroTipoOperativoRepository.GetDataTableDecVie_ControlFinancieroTipoOperativo(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
