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
    public class Decvie_MatryoshkaActividadDepController : BaseController<Decvie_MatryoshkaActividadDep>
    {
        private readonly Decvie_MatryoshkaActividadDepRepository _decvie_MatryoshkaActividadDepRepository;
        public Decvie_MatryoshkaActividadDepController(Decvie_MatryoshkaActividadDepRepository decvie_MatryoshkaActividadDepRepository)
        {
            _decvie_MatryoshkaActividadDepRepository = decvie_MatryoshkaActividadDepRepository;
        }
        readonly Decvie_MatryoshkaActividadDepRepository decvie_MatryoshkaActividadDepRepository = new Decvie_MatryoshkaActividadDepRepository();
        public Decvie_MatryoshkaActividadDepController()
        {
            _decvie_MatryoshkaActividadDepRepository = decvie_MatryoshkaActividadDepRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecvie_MatryoshkaActividadDep()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_MatryoshkaActividadDepRepository.GetAllDecvie_MatryoshkaActividadDep();

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
        public IHttpActionResult GetDecvie_MatryoshkaActividadDepDetails(int id_matryoshkaactividaddep)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_MatryoshkaActividadDepRepository.GetDecvie_MatryoshkaActividadDepDetails(id_matryoshkaactividaddep);

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
        public IHttpActionResult InsertDecvie_MatryoshkaActividadDep([FromBody] Decvie_MatryoshkaActividadDep decvie_MatryoshkaActividadDep )
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

                var created = decvie_MatryoshkaActividadDepRepository.InsertDecvie_MatryoshkaActividadDep(decvie_MatryoshkaActividadDep);

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
        public IHttpActionResult UpdateDecvie_MatryoshkaActividadDep([FromBody] Decvie_MatryoshkaActividadDep decvie_MatryoshkaActividadDep)
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

                var created = decvie_MatryoshkaActividadDepRepository.UpdateDecvie_MatryoshkaActividadDep(decvie_MatryoshkaActividadDep);

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
        public IHttpActionResult DeleteDecvie_MatryoshkaActividadDep(int id_matryoshkaactividaddep)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decvie_MatryoshkaActividadDepRepository.DeleteDecvie_MatryoshkaActividadDep(id_matryoshkaactividaddep);

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
        public IHttpActionResult GetDataTableDecvie_MatryoshkaActividadDep()
        {
            DataTableAdapter<Decvie_MatryoshkaActividadDep> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_MatryoshkaActividadDepRepository.GetDataTableDecvie_MatryoshkaActividadDep(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }
        [HttpGet]
        public IHttpActionResult GetDataTableDecvie_MatryoshkaActividadDepByMatryohska(int id_matryoska)
        {
            DataTableAdapter<Decvie_MatryoshkaActividadDep> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_MatryoshkaActividadDepRepository.GetDataTableDecvie_MatryoshkaActividadDepByMatryohska(id_matryoska, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
