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
    public class Decvie_MatryoshkaProgramaPgdController : BaseController<Decvie_MatryoshkaProgramaPgd>
    {
        private readonly Decvie_MatryoshkaProgramaPgdRepository _decvie_MatryoshkaProgramaPgdReporitory;
        public Decvie_MatryoshkaProgramaPgdController (Decvie_MatryoshkaProgramaPgdRepository decvie_MatryoshkaProgramaPgdReporitory)
        {
            _decvie_MatryoshkaProgramaPgdReporitory = decvie_MatryoshkaProgramaPgdReporitory;
        }
        readonly Decvie_MatryoshkaProgramaPgdRepository decvie_MatryoshkaProgramaPgdReporitory = new Decvie_MatryoshkaProgramaPgdRepository();
        public Decvie_MatryoshkaProgramaPgdController()
        {
            _decvie_MatryoshkaProgramaPgdReporitory = decvie_MatryoshkaProgramaPgdReporitory;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecvie_MatryoshkaProgramaPgd()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_MatryoshkaProgramaPgdReporitory.GetAllDecvie_MatryoshkaProgramaPgd ();

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
        public IHttpActionResult GetDecvie_MatryoshkaProgramaPgdDetails(int id_matryoshkaprogramapgd)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_MatryoshkaProgramaPgdReporitory.GetDecvie_MatryoshkaProgramaPgdDetails(id_matryoshkaprogramapgd);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Programa PGD inexistente";
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
        public IHttpActionResult InsertDecvie_MatryoshkaProgramaPgd([FromBody] Decvie_MatryoshkaProgramaPgd decvie_MatryoshkaProgramaPgd)
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

                var created = decvie_MatryoshkaProgramaPgdReporitory.InsertDecvie_MatryoshkaProgramaPgd(decvie_MatryoshkaProgramaPgd);

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
        public IHttpActionResult UpdateDecvie_MatryoshkaProgramaPgd([FromBody] Decvie_MatryoshkaProgramaPgd decvie_MatryoshkaProgramaPgd)
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

                var created = decvie_MatryoshkaProgramaPgdReporitory.UpdateDecvie_MatryoshkaProgramaPgd(decvie_MatryoshkaProgramaPgd);

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
        public IHttpActionResult DeleteDecvie_MatryoshkaProgramaPgd(int id_matryoshkaprogramapgd)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decvie_MatryoshkaProgramaPgdReporitory.DeleteDecvie_MatryoshkaProgramaPgd(id_matryoshkaprogramapgd);

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
        public IHttpActionResult GetDataTableDecvie_MatryoshkaProgramaPgd()
        {
            DataTableAdapter<Decvie_MatryoshkaProgramaPgd> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_MatryoshkaProgramaPgdReporitory.GetDataTableDecvie_MatryoshkaProgramaPgd(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }
        [HttpGet]
        public IHttpActionResult GetDataTableDecvie_MatryoshkaProgramaPgdByMatryohska(int id_matryoska)
        {
            DataTableAdapter<Decvie_MatryoshkaProgramaPgd> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_MatryoshkaProgramaPgdReporitory.GetDataTableDecvie_MatryoshkaProgramaPgdByMatryohska(id_matryoska, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }
    }
}
