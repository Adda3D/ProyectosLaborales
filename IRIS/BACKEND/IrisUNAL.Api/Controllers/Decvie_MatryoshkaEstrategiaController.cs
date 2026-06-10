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
    public class Decvie_MatryoshkaEstrategiaController : BaseController<Decvie_MatryoshkaEstrategia>
    {
        private readonly Decvie_MatryoshkaEstrategiaRepository _decvie_MatryoshkaEstrategiaRepository;
        public Decvie_MatryoshkaEstrategiaController (Decvie_MatryoshkaEstrategiaRepository decvie_MatryoshkaEstrategiaRepository)
        {
            _decvie_MatryoshkaEstrategiaRepository = decvie_MatryoshkaEstrategiaRepository;
        }
        readonly Decvie_MatryoshkaEstrategiaRepository decvie_MatryoshkaEstrategiaRepository = new Decvie_MatryoshkaEstrategiaRepository();
        public Decvie_MatryoshkaEstrategiaController()
        {
            _decvie_MatryoshkaEstrategiaRepository = decvie_MatryoshkaEstrategiaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecvie_MatryoshkaEstrategia()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_MatryoshkaEstrategiaRepository.GetAllDecvie_MatryoshkaEstrategia();

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
        public IHttpActionResult GetDecvie_MatryoshkaEstrategiaDetails(int id_matryoshkaestrategia)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_MatryoshkaEstrategiaRepository.GetDecvie_MatryoshkaEstrategiaDetails(id_matryoshkaestrategia);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Estrategia inexistente";
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
        public IHttpActionResult InsertDecvie_MatryoshkaEstrategia([FromBody] Decvie_MatryoshkaEstrategia decvie_MatryoshkaEstrategia )
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

                var created = decvie_MatryoshkaEstrategiaRepository.InsertDecvie_MatryoshkaEstrategia(decvie_MatryoshkaEstrategia);

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
        public IHttpActionResult UpdateDecvie_MatryoshkaEstrategia([FromBody] Decvie_MatryoshkaEstrategia decvie_MatryoshkaEstrategia )
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

                var created = decvie_MatryoshkaEstrategiaRepository.UpdateDecvie_MatryoshkaEstrategia(decvie_MatryoshkaEstrategia);

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
        public IHttpActionResult DeleteDecvie_MatryoshkaEstrategia(int id_matryoshkaestrategia)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decvie_MatryoshkaEstrategiaRepository.DeleteDecvie_MatryoshkaEstrategia(id_matryoshkaestrategia);

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
        public IHttpActionResult GetDataTableDecvie_MatryoshkaEstrategia()
        {
            DataTableAdapter<Decvie_MatryoshkaEstrategia> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_MatryoshkaEstrategiaRepository.GetDataTableDecvie_MatryoshkaEstrategia(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }
        [HttpGet]
        public IHttpActionResult GetDataTableDecvie_MatryoshkaEstrategiaByMatryohska(int id_matryoska)
        {
            DataTableAdapter<Decvie_MatryoshkaEstrategia> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_MatryoshkaEstrategiaRepository.GetDataTableDecvie_MatryoshkaEstrategiaByMatryohska(id_matryoska, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
