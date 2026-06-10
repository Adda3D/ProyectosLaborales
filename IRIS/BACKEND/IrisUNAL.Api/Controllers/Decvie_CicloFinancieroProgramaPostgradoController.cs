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
    public class Decvie_CicloFinancieroProgramaPostgradoController : BaseController<Decvie_CicloFinancieroProgramaPostgrado>
    {
        private readonly Decvie_CicloFinancieroProgramaPostgradoRepository _decvie_CicloFinancieroProgramaPostgradoRepository;
        public Decvie_CicloFinancieroProgramaPostgradoController (Decvie_CicloFinancieroProgramaPostgradoRepository decvie_CicloFinancieroProgramaPostgradoRepository)
        {
            _decvie_CicloFinancieroProgramaPostgradoRepository = decvie_CicloFinancieroProgramaPostgradoRepository;
        }
        readonly Decvie_CicloFinancieroProgramaPostgradoRepository decvie_CicloFinancieroProgramaPostgradoRepository = new Decvie_CicloFinancieroProgramaPostgradoRepository();
        public Decvie_CicloFinancieroProgramaPostgradoController()
        {
            _decvie_CicloFinancieroProgramaPostgradoRepository = decvie_CicloFinancieroProgramaPostgradoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecvie_CicloFinancieroProgramaPostgrado()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_CicloFinancieroProgramaPostgradoRepository.GetAllDecvie_CicloFinancieroProgramaPostgrado();

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
        public IHttpActionResult GetDecvie_CicloFinancieroProgramaPostgradoDetails(int id_programapostgrado)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_CicloFinancieroProgramaPostgradoRepository.GetDecvie_CicloFinancieroProgramaPostgradoDetails(id_programapostgrado);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Matryoshka inexistente";
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
        public IHttpActionResult InsertDecvie_CicloFinancieroProgramaPostgrado([FromBody] Decvie_CicloFinancieroProgramaPostgrado decvie_CicloFinancieroProgramaPostgrado )
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

                var created = decvie_CicloFinancieroProgramaPostgradoRepository.InsertDecvie_CicloFinancieroProgramaPostgrado(decvie_CicloFinancieroProgramaPostgrado);

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
        public IHttpActionResult UpdateDecvie_CicloFinancieroProgramaPostgrado([FromBody] Decvie_CicloFinancieroProgramaPostgrado decvie_CicloFinancieroProgramaPostgrado )
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

                var created = decvie_CicloFinancieroProgramaPostgradoRepository.UpdateDecvie_CicloFinancieroProgramaPostgrado(decvie_CicloFinancieroProgramaPostgrado);

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
        public IHttpActionResult DeleteDecvie_CicloFinancieroProgramaPostgrado(int id_programapostgrado)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decvie_CicloFinancieroProgramaPostgradoRepository.DeleteDecvie_CicloFinancieroProgramaPostgrado(id_programapostgrado);

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
        public IHttpActionResult GetDataTableDecvie_CicloFinancieroProgramaPostgrado()
        {
            DataTableAdapter<Decvie_CicloFinancieroProgramaPostgrado> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_CicloFinancieroProgramaPostgradoRepository.GetDataTableDecvie_CicloFinancieroProgramaPostgrado(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }
    }
}
