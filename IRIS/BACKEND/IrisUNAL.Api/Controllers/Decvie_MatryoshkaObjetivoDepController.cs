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
    public class Decvie_MatryoshkaObjetivoDepController : BaseController<Decvie_MatryoshkaObjetivoDep>
    {
        private readonly Decvie_MatryoshkaObjetivoDepRepository _decvie_MatryoshkaObjetivoDepRepository;
        public Decvie_MatryoshkaObjetivoDepController(Decvie_MatryoshkaObjetivoDepRepository decvie_MatryoshkaObjetivoDepRepository)
        {
            _decvie_MatryoshkaObjetivoDepRepository = decvie_MatryoshkaObjetivoDepRepository;
        }
        readonly Decvie_MatryoshkaObjetivoDepRepository decvie_MatryoshkaObjetivoDepRepository = new Decvie_MatryoshkaObjetivoDepRepository();
        public Decvie_MatryoshkaObjetivoDepController()
        {
            _decvie_MatryoshkaObjetivoDepRepository = decvie_MatryoshkaObjetivoDepRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecvie_MatryoshkaObjetivoDep()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_MatryoshkaObjetivoDepRepository.GetAllDecvie_MatryoshkaObjetivoDep();

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
        public IHttpActionResult GetDecvie_MatryoshkaObjetivoDepDetails(int id_matryoshkaobjetivodep)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_MatryoshkaObjetivoDepRepository.GetDecvie_MatryoshkaObjetivoDepDetails(id_matryoshkaobjetivodep);

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
        public IHttpActionResult InsertDecvie_MatryoshkaObjetivoDep([FromBody] Decvie_MatryoshkaObjetivoDep decvie_MatryoshkaObjetivoDep )
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

                var created = decvie_MatryoshkaObjetivoDepRepository.InsertDecvie_MatryoshkaObjetivoDep(decvie_MatryoshkaObjetivoDep);

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
        public IHttpActionResult UpdateDecvie_MatryoshkaObjetivoDep([FromBody] Decvie_MatryoshkaObjetivoDep decvie_MatryoshkaObjetivoDep )
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

                var created = decvie_MatryoshkaObjetivoDepRepository.UpdateDecvie_MatryoshkaObjetivoDep(decvie_MatryoshkaObjetivoDep);

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
        public IHttpActionResult DeleteDecvie_MatryoshkaObjetivoDep(int id_matryoshkaobjetivodep)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decvie_MatryoshkaObjetivoDepRepository.DeleteDecvie_MatryoshkaObjetivoDep(id_matryoshkaobjetivodep);

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
        public IHttpActionResult GetDataTableDecvie_MatryoshkaObjetivoDep()
        {
            DataTableAdapter<Decvie_MatryoshkaObjetivoDep> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_MatryoshkaObjetivoDepRepository.GetDataTableDecvie_MatryoshkaObjetivoDep(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }
        [HttpGet]
        public IHttpActionResult GetDataTableDecvie_MatryoshkaObjetivoDepByMatryohska(int id_matryoska)
        {
            DataTableAdapter<Decvie_MatryoshkaObjetivoDep> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_MatryoshkaObjetivoDepRepository.GetDataTableDecvie_MatryoshkaObjetivoDepByMatryohska(id_matryoska, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
