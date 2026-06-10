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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Publicaciones_DepositoDisposicionLegalController : BaseController<Publicaciones_DepositoDisposicionLegal>
    {
        private readonly Publicaciones_DepositoDisposicionLegalRepository _publicaciones_depositodisposicionlegalRepository;
        public Publicaciones_DepositoDisposicionLegalController(Publicaciones_DepositoDisposicionLegalRepository publicaciones_depositodisposicionlegalrepository)
        {
            _publicaciones_depositodisposicionlegalRepository = publicaciones_depositodisposicionlegalrepository;
        }
        readonly Publicaciones_DepositoDisposicionLegalRepository publicaciones_depositodisposicionlegalrepository = new Publicaciones_DepositoDisposicionLegalRepository();
        public Publicaciones_DepositoDisposicionLegalController()
        {
            _publicaciones_depositodisposicionlegalRepository = publicaciones_depositodisposicionlegalrepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DepositoDisposicionLegal()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_depositodisposicionlegalRepository.GetAllPublicaciones_DepositoDisposicionLegal();

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
        public IHttpActionResult GetPublicaciones_DepositoDisposicionLegalDetails(int iddisposicionlegal)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_depositodisposicionlegalRepository.GetPublicaciones_DepositoDisposicionLegalDetails(iddisposicionlegal);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Deposito Disposición Legal inexistente";
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
        public IHttpActionResult InsertPublicaciones_DepositoDisposicionLegal([FromBody] Publicaciones_DepositoDisposicionLegal publicaciones_depositodisposicionlegal)
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

                var created = _publicaciones_depositodisposicionlegalRepository.InsertPublicaciones_DepositoDisposicionLegal(publicaciones_depositodisposicionlegal);

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
        public IHttpActionResult UpdatePublicaciones_DepositoDisposicionLegal([FromBody] Publicaciones_DepositoDisposicionLegal publicaciones_depositodisposicionlegal)
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

                var created = _publicaciones_depositodisposicionlegalRepository.UpdatePublicaciones_DepositoDisposicionLegal(publicaciones_depositodisposicionlegal);

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
        public IHttpActionResult DeletePublicaciones_DepositoDisposicionLegal(int iddisposicionlegal)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _publicaciones_depositodisposicionlegalRepository.DeletePublicaciones_DepositoDisposicionLegal(iddisposicionlegal);

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
        public IHttpActionResult GetDataTablePublicaciones_DepositoDisposicionLegal()
        {
            DataTableAdapter<Publicaciones_DepositoDisposicionLegal> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _publicaciones_depositodisposicionlegalRepository.GetDataTablePublicaciones_DepositoDisposicionLegal(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

    }
}
