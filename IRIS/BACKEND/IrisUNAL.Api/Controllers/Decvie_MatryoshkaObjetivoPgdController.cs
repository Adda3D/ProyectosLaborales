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
    public class Decvie_MatryoshkaObjetivoPgdController : BaseController<Decvie_MatryoshkaObjetivoPgd>
    {
        private readonly Decvie_MatryoshkaObjetivoPgdRepository _decvie_MatryoshkaObjetivoPgdRepository;
        public Decvie_MatryoshkaObjetivoPgdController(Decvie_MatryoshkaObjetivoPgdRepository decvie_MatryoshkaObjetivoPgdRepository)
        {
            _decvie_MatryoshkaObjetivoPgdRepository = decvie_MatryoshkaObjetivoPgdRepository;
        }
        readonly Decvie_MatryoshkaObjetivoPgdRepository decvie_MatryoshkaObjetivoPgdRepository = new Decvie_MatryoshkaObjetivoPgdRepository();
        public Decvie_MatryoshkaObjetivoPgdController()
        {
            _decvie_MatryoshkaObjetivoPgdRepository = decvie_MatryoshkaObjetivoPgdRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecvie_MatryoshkaObjetivoPgd()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_MatryoshkaObjetivoPgdRepository.GetAllDecvie_MatryoshkaObjetivoPgd();

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
        public IHttpActionResult GetDecvie_MatryoshkaObjetivoPgdDetails(int id_matryoshkaobjetivopgd)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_MatryoshkaObjetivoPgdRepository.GetDecvie_MatryoshkaObjetivoPgdDetails(id_matryoshkaobjetivopgd);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Objetivo inexistente";
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
        public IHttpActionResult InsertDecvie_MatryoshkaObjetivoPgd([FromBody] Decvie_MatryoshkaObjetivoPgd decvie_MatryoshkaObjetivoPgd )
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

                var created = decvie_MatryoshkaObjetivoPgdRepository.InsertDecvie_MatryoshkaObjetivoPgd(decvie_MatryoshkaObjetivoPgd);

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
        public IHttpActionResult UpdateDecvie_MatryoshkaObjetivoPgd([FromBody] Decvie_MatryoshkaObjetivoPgd decvie_MatryoshkaObjetivoPgd)
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

                var created = decvie_MatryoshkaObjetivoPgdRepository.UpdateDecvie_MatryoshkaObjetivoPgd(decvie_MatryoshkaObjetivoPgd);

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
        public IHttpActionResult DeleteDecvie_MatryoshkaObjetivoPgd(int id_matryoshkaobjetivopgd)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decvie_MatryoshkaObjetivoPgdRepository.DeleteDecvie_MatryoshkaObjetivoPgd(id_matryoshkaobjetivopgd);

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
        public IHttpActionResult GetDataTableDecvie_MatryoshkaObjetivoPgd()
        {
            DataTableAdapter<Decvie_MatryoshkaObjetivoPgd> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_MatryoshkaObjetivoPgdRepository.GetDataTableDecvie_MatryoshkaObjetivoPgd(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }
        [HttpGet]
        public IHttpActionResult GetDataTableDecvie_MatryoshkaObjetivoPgdByMatryohska(int id_matryoska)
        {
            DataTableAdapter<Decvie_MatryoshkaObjetivoPgd> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_MatryoshkaObjetivoPgdRepository.GetDataTableDecvie_MatryoshkaObjetivoPgdByMatryohska(id_matryoska, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
