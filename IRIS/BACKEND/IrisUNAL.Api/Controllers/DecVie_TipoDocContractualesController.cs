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
    public class DecVie_TipoDocContractualesController : BaseController<DecVie_TipoDocContractuales>
    {
        private readonly IDecVie_TipoDocContractualesRepository _decVie_TipoDocContractualesRepository;
        public DecVie_TipoDocContractualesController (IDecVie_TipoDocContractualesRepository decVie_TipoDocContractualesRepository)
        {
            _decVie_TipoDocContractualesRepository = decVie_TipoDocContractualesRepository;
        }
        readonly IDecVie_TipoDocContractualesRepository decVie_TipoDocContractualesRepository = new DecVie_TipoDocContractualesRepository();
        public DecVie_TipoDocContractualesController()
        {
            _decVie_TipoDocContractualesRepository = decVie_TipoDocContractualesRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_TipoDocContractuales()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_TipoDocContractualesRepository.GetAllDecVie_TipoDocContractuales();

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
        public IHttpActionResult GetDecVie_TipoDocContractualesDetails(int id_doccontractuales)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_TipoDocContractualesRepository.GetDecVie_TipoDocContractualesDetails(id_doccontractuales);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_TipoDocContractuales inexistente";
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
        public IHttpActionResult GetDecVie_TipoDocContractualesNombre(string cd_nmdoccontractuales)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_TipoDocContractualesRepository.GetDecVie_TipoDocContractualesNombre(cd_nmdoccontractuales);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_TipoDocContractuales inexistente";
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
        public IHttpActionResult InsertDecVie_TipoDocContractuales([FromBody] DecVie_TipoDocContractuales decVie_TipoDocContractuales)
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

                var created = decVie_TipoDocContractualesRepository.InsertDecVie_TipoDocContractuales(decVie_TipoDocContractuales);

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
        public IHttpActionResult UpdateDecVie_TipoDocContractuales([FromBody] DecVie_TipoDocContractuales decVie_TipoDocContractuales)
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

                var created = decVie_TipoDocContractualesRepository.UpdateDecVie_TipoDocContractuales(decVie_TipoDocContractuales);

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
        public IHttpActionResult DeleteDecVie_TipoDocContractuales(int id_doccontractuales)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_TipoDocContractualesRepository.DeleteDecVie_TipoDocContractuales(id_doccontractuales);

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
        public IHttpActionResult GetDataTableDecVie_TipoDocContractuales()
        {
            DataTableAdapter<DecVie_TipoDocContractuales> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_TipoDocContractualesRepository.GetDataTableDecVie_TipoDocContractuales(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
