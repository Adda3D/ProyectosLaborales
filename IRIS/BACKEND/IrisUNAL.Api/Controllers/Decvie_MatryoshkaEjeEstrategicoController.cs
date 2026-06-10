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
    public class Decvie_MatryoshkaEjeEstrategicoController : BaseController<Decvie_MatryoshkaEjeEstrategico>
    {
        private readonly Decvie_MatryoshkaEjeEstrategicoRepository _decvie_MatryoshkaEjeEstrategicoRepository;
        public Decvie_MatryoshkaEjeEstrategicoController (Decvie_MatryoshkaEjeEstrategicoRepository decvie_MatryoshkaEjeEstrategicoRepository)
        {
            _decvie_MatryoshkaEjeEstrategicoRepository = decvie_MatryoshkaEjeEstrategicoRepository;
        }
        readonly Decvie_MatryoshkaEjeEstrategicoRepository decvie_MatryoshkaEjeEstrategicoRepository = new Decvie_MatryoshkaEjeEstrategicoRepository();
        public Decvie_MatryoshkaEjeEstrategicoController()
        {
            _decvie_MatryoshkaEjeEstrategicoRepository = decvie_MatryoshkaEjeEstrategicoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecvie_MatryoshkaEjeEstrategico()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_MatryoshkaEjeEstrategicoRepository.GetAllDecvie_MatryoshkaEjeEstrategico();

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
        public IHttpActionResult GetDecvie_MatryoshkaEjeEstrategicoDetails(int id_matryoshkaejeestrategico)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_MatryoshkaEjeEstrategicoRepository.GetDecvie_MatryoshkaEjeEstrategicoDetails(id_matryoshkaejeestrategico);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Eje Estratégico inexistente";
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
        public IHttpActionResult InsertDecvie_MatryoshkaEjeEstrategico([FromBody] Decvie_MatryoshkaEjeEstrategico decvie_MatryoshkaEjeEstrategico)
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

                var created = decvie_MatryoshkaEjeEstrategicoRepository.InsertDecvie_MatryoshkaEjeEstrategico(decvie_MatryoshkaEjeEstrategico);

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
        public IHttpActionResult UpdateDecvie_MatryoshkaEjeEstrategico([FromBody] Decvie_MatryoshkaEjeEstrategico decvie_MatryoshkaEjeEstrategico)
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

                var created = decvie_MatryoshkaEjeEstrategicoRepository.UpdateDecvie_MatryoshkaEjeEstrategico(decvie_MatryoshkaEjeEstrategico);

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
        public IHttpActionResult DeleteDecvie_MatryoshkaEjeEstrategico(int id_matryoshkaejeestrategico)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decvie_MatryoshkaEjeEstrategicoRepository.DeleteDecvie_MatryoshkaEjeEstrategico(id_matryoshkaejeestrategico);

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
        public IHttpActionResult GetDataTableDecvie_MatryoshkaEjeEstrategico()
        {
            DataTableAdapter<Decvie_MatryoshkaEjeEstrategico> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_MatryoshkaEjeEstrategicoRepository.GetDataTableDecvie_MatryoshkaEjeEstrategico(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }
        [HttpGet]
        public IHttpActionResult GetDataTableDecvie_MatryoshkaEjeEstrategicoByMatryohska(int id_matryoska)
        {
            DataTableAdapter<Decvie_MatryoshkaEjeEstrategico> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_MatryoshkaEjeEstrategicoRepository.GetDataTableDecvie_MatryoshkaEjeEstrategicoByMatryohska(id_matryoska, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }
    }
}
