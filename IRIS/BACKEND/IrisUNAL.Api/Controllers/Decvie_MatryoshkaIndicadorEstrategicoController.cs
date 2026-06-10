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
    public class Decvie_MatryoshkaIndicadorEstrategicoController : BaseController<Decvie_MatryoshkaIndicadorEstrategico>
    {
        private readonly Decvie_MatryoshkaIndicadorEstrategicoRepository _decvie_MatryoshkaIndicadorEstrategicoRepository;
        public Decvie_MatryoshkaIndicadorEstrategicoController (Decvie_MatryoshkaIndicadorEstrategicoRepository decvie_MatryoshkaIndicadorEstrategicoRepository)
        {
            _decvie_MatryoshkaIndicadorEstrategicoRepository = decvie_MatryoshkaIndicadorEstrategicoRepository;
        }
        readonly Decvie_MatryoshkaIndicadorEstrategicoRepository decvie_MatryoshkaIndicadorEstrategicoRepository = new Decvie_MatryoshkaIndicadorEstrategicoRepository();
        public Decvie_MatryoshkaIndicadorEstrategicoController()
        {
            _decvie_MatryoshkaIndicadorEstrategicoRepository = decvie_MatryoshkaIndicadorEstrategicoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecvie_MatryoshkaIndicadorEstrategico()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_MatryoshkaIndicadorEstrategicoRepository.GetAllDecvie_MatryoshkaIndicadorEstrategico();

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
        public IHttpActionResult GetDecvie_MatryoshkaIndicadorEstrategicoDetails(int id_matryoshkaindicadorestrategico)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_MatryoshkaIndicadorEstrategicoRepository.GetDecvie_MatryoshkaIndicadorEstrategicoDetails(id_matryoshkaindicadorestrategico);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Indicador inexistente";
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
        public IHttpActionResult InsertDecvie_MatryoshkaIndicadorEstrategico([FromBody] Decvie_MatryoshkaIndicadorEstrategico decvie_MatryoshkaIndicadorEstrategico )
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

                var created = decvie_MatryoshkaIndicadorEstrategicoRepository.InsertDecvie_MatryoshkaIndicadorEstrategico(decvie_MatryoshkaIndicadorEstrategico);

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
        public IHttpActionResult UpdateDecvie_MatryoshkaIndicadorEstrategico([FromBody] Decvie_MatryoshkaIndicadorEstrategico decvie_MatryoshkaIndicadorEstrategico)
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

                var created = decvie_MatryoshkaIndicadorEstrategicoRepository.UpdateDecvie_MatryoshkaIndicadorEstrategico(decvie_MatryoshkaIndicadorEstrategico);

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
        public IHttpActionResult DeleteDecvie_MatryoshkaIndicadorEstrategico(int id_matryoshkaindicadorestrategico)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decvie_MatryoshkaIndicadorEstrategicoRepository.DeleteDecvie_MatryoshkaIndicadorEstrategico(id_matryoshkaindicadorestrategico);

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
        public IHttpActionResult GetDataTableDecvie_MatryoshkaIndicadorEstrategico()
        {
            DataTableAdapter<Decvie_MatryoshkaIndicadorEstrategico> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_MatryoshkaIndicadorEstrategicoRepository.GetDataTableDecvie_MatryoshkaIndicadorEstrategico(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }
        [HttpGet]
        public IHttpActionResult GetDataTableDecvie_MatryoshkaIndicadorEstrategicoByMatryohska(int id_matryoska)
        {
            DataTableAdapter<Decvie_MatryoshkaIndicadorEstrategico> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_MatryoshkaIndicadorEstrategicoRepository.GetDataTableDecvie_MatryoshkaIndicadorEstrategicoByMatryohska(id_matryoska, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
