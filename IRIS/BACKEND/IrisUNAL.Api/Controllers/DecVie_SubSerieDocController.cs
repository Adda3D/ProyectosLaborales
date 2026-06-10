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
    public class DecVie_SubSerieDocController : BaseController<DecVie_SubSerieDoc>
    {        
        private readonly IDecVie_SubSerieDocRepository _decVie_SubSerieDocRepository;
        public DecVie_SubSerieDocController(IDecVie_SubSerieDocRepository decVie_SubSerieDocRepository)
        {
            _decVie_SubSerieDocRepository = decVie_SubSerieDocRepository;
        }
        readonly IDecVie_SubSerieDocRepository decVie_SubSerieDocRepository = new DecVie_SubSerieDocRepository();
        public DecVie_SubSerieDocController()
        {
            _decVie_SubSerieDocRepository = decVie_SubSerieDocRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_SubSerieDoc()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_SubSerieDocRepository.GetAllDecVie_SubSerieDoc();

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
        public IHttpActionResult GetDecVie_SubSerieDocDetails(int id_subseriedoc)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_SubSerieDocRepository.GetDecVie_SubSerieDocDetails(id_subseriedoc);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_SubSerieDoc inexistente";
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
        public IHttpActionResult GetDecVie_SubSerieDocNombre(string cd_nmsubseriedoc)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_SubSerieDocRepository.GetDecVie_SubSerieDocNombre(cd_nmsubseriedoc);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_SubSerieDoc inexistente";
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
        public IHttpActionResult InsertDecVie_SubSerieDoc([FromBody] DecVie_SubSerieDoc decVie_SubSerieDoc)
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

                var created = decVie_SubSerieDocRepository.InsertDecVie_SubSerieDoc(decVie_SubSerieDoc);

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
        public IHttpActionResult UpdateDecVie_SubSerieDoc([FromBody] DecVie_SubSerieDoc decVie_SubSerieDoc)
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

                var created = decVie_SubSerieDocRepository.UpdateDecVie_SubSerieDoc(decVie_SubSerieDoc);

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
        public IHttpActionResult DeleteDecVie_SubSerieDoc(int id_subseriedoc)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_SubSerieDocRepository.DeleteDecVie_SubSerieDoc(id_subseriedoc);

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
        public IHttpActionResult GetDataTableDecVie_SubSerieDoc()
        {
            DataTableAdapter<DecVie_SubSerieDoc> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_SubSerieDocRepository.GetDataTableDecVie_SubSerieDoc(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
