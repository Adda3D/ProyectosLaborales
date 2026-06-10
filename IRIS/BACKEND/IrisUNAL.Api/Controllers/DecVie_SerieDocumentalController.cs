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
    public class DecVie_SerieDocumentalController : BaseController<DecVie_SerieDocumental>
    {
        private readonly IDecVie_SerieDocumentalRepository _decVie_SerieDocumentalRepository;
        public DecVie_SerieDocumentalController(IDecVie_SerieDocumentalRepository decVie_SerieDocumentalRepository)
        {
            _decVie_SerieDocumentalRepository = decVie_SerieDocumentalRepository;
        }
        readonly IDecVie_SerieDocumentalRepository decVie_SerieDocumentalRepository = new DecVie_SerieDocumentalRepository();
        public DecVie_SerieDocumentalController()
        {
            _decVie_SerieDocumentalRepository = decVie_SerieDocumentalRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_SerieDocumental()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_SerieDocumentalRepository.GetAllDecVie_SerieDocumental();

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
        public IHttpActionResult GetDecVie_SerieDocumentalDetails(int id_seriedocumental)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_SerieDocumentalRepository.GetDecVie_SerieDocumentalDetails(id_seriedocumental);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_SerieDocumental inexistente";
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
        public IHttpActionResult GetDecVie_SerieDocumentalNombre(string cd_nminstancia)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_SerieDocumentalRepository.GetDecVie_SerieDocumentalNombre(cd_nminstancia);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_SerieDocumental inexistente";
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
        public IHttpActionResult InsertDecVie_SerieDocumental([FromBody] DecVie_SerieDocumental decVie_SerieDocumental)
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

                var created = decVie_SerieDocumentalRepository.InsertDecVie_SerieDocumental(decVie_SerieDocumental);

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
        public IHttpActionResult UpdateDecVie_SerieDocumental([FromBody] DecVie_SerieDocumental decVie_SerieDocumental)
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

                var created = decVie_SerieDocumentalRepository.UpdateDecVie_SerieDocumental(decVie_SerieDocumental);

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
        public IHttpActionResult DeleteDecVie_SerieDocumental(int id_seriedocumental)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_SerieDocumentalRepository.DeleteDecVie_SerieDocumental(id_seriedocumental);

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
        public IHttpActionResult GetDataTableDecVie_SerieDocumental()
        {
            DataTableAdapter<DecVie_SerieDocumental> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_SerieDocumentalRepository.GetDataTableDecVie_SerieDocumental(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
