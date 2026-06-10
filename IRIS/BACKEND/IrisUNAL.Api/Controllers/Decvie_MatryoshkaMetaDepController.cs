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
    public class Decvie_MatryoshkaMetaDepController : BaseController<Decvie_MatryoshkaMetaDep>
    {
        private readonly Decvie_MatryoshkaMetaDepRepository _decvie_MatryoshkaMetaDepRepository;
        public Decvie_MatryoshkaMetaDepController (Decvie_MatryoshkaMetaDepRepository decvie_MatryoshkaMetaDepRepository)
        {
            _decvie_MatryoshkaMetaDepRepository = decvie_MatryoshkaMetaDepRepository;
        }
        readonly Decvie_MatryoshkaMetaDepRepository decvie_MatryoshkaMetaDepRepository = new Decvie_MatryoshkaMetaDepRepository();
        public Decvie_MatryoshkaMetaDepController()
        {
            _decvie_MatryoshkaMetaDepRepository = decvie_MatryoshkaMetaDepRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecvie_MatryoshkaMetaDep()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_MatryoshkaMetaDepRepository.GetAllDecvie_MatryoshkaMetaDep();

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
        public IHttpActionResult GetDecvie_MatryoshkaMetaDepDetails(int id_matryoshkametadep)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_MatryoshkaMetaDepRepository.GetDecvie_MatryoshkaMetaDepDetails(id_matryoshkametadep);

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
        public IHttpActionResult InsertDecvie_MatryoshkaMetaDep([FromBody] Decvie_MatryoshkaMetaDep decvie_MatryoshkaMetaDep )
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

                var created = decvie_MatryoshkaMetaDepRepository.InsertDecvie_MatryoshkaMetaDep(decvie_MatryoshkaMetaDep);

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
        public IHttpActionResult UpdateDecvie_MatryoshkaMetaDep([FromBody] Decvie_MatryoshkaMetaDep decvie_MatryoshkaMetaDep)
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

                var created = decvie_MatryoshkaMetaDepRepository.UpdateDecvie_MatryoshkaMetaDep(decvie_MatryoshkaMetaDep);

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
        public IHttpActionResult DeleteDecvie_MatryoshkaMetaDep(int id_matryoshkametadep)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decvie_MatryoshkaMetaDepRepository.DeleteDecvie_MatryoshkaMetaDep(id_matryoshkametadep);

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
        public IHttpActionResult GetDataTableDecvie_MatryoshkaMetaDep()
        {
            DataTableAdapter<Decvie_MatryoshkaMetaDep> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_MatryoshkaMetaDepRepository.GetDataTableDecvie_MatryoshkaMetaDep(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }
        [HttpGet]
        public IHttpActionResult GetDataTableDecvie_MatryoshkaMetaDepByMatryohska(int id_matryoska)
        {
            DataTableAdapter<Decvie_MatryoshkaMetaDep> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_MatryoshkaMetaDepRepository.GetDataTableDecvie_MatryoshkaMetaDepByMatryohska(id_matryoska, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
