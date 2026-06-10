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
    public class Publicaciones_DepositoTipoPubController : BaseController<Publicaciones_DepositoTipoPub>
    {
        private readonly IPublicaciones_DepositoTipoPubRepository _publicaciones_DepositoTipoPubRepository;
        public Publicaciones_DepositoTipoPubController (IPublicaciones_DepositoTipoPubRepository publicaciones_DepositoTipoPubRepository)
        {
            _publicaciones_DepositoTipoPubRepository = publicaciones_DepositoTipoPubRepository;
        }
        readonly IPublicaciones_DepositoTipoPubRepository publicaciones_DepositoTipoPubRepository = new Publicaciones_DepositoTipoPubRepository();
        public Publicaciones_DepositoTipoPubController()
        {
            _publicaciones_DepositoTipoPubRepository = publicaciones_DepositoTipoPubRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DepositoTipoPub()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoTipoPubRepository.GetAllPublicaciones_DepositoTipoPub();

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
        public IHttpActionResult GetPublicaciones_DepositoTipoPubDetails(int id_tipopub)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoTipoPubRepository.GetPublicaciones_DepositoTipoPubDetails(id_tipopub);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_DepositoTipoPub inexistente";
                }

                resultdb.Data = data;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }
        [HttpGet]
        public IHttpActionResult GetPublicaciones_DepositoTipoPubNombre(string cd_nmtipopub)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoTipoPubRepository.GetPublicaciones_DepositoTipoPubNombre(cd_nmtipopub);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_DepositoTipoPub inexistente";
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
        public IHttpActionResult InsertPublicaciones_DepositoTipoPub([FromBody] Publicaciones_DepositoTipoPub publicaciones_DepositoTipoPub)
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

                var created = publicaciones_DepositoTipoPubRepository.InsertPublicaciones_DepositoTipoPub(publicaciones_DepositoTipoPub);

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
        public IHttpActionResult UpdatePublicaciones_DepositoTipoPub([FromBody] Publicaciones_DepositoTipoPub publicaciones_DepositoTipoPub)
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

                var created = publicaciones_DepositoTipoPubRepository.UpdatePublicaciones_DepositoTipoPub(publicaciones_DepositoTipoPub);

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
        public IHttpActionResult DeletePublicaciones_DepositoTipoPub(int id_tipopub)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DepositoTipoPubRepository.DeletePublicaciones_DepositoTipoPub(id_tipopub);

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
        public IHttpActionResult GetDataTablePublicaciones_DepositoTipoPub()
        {
            DataTableAdapter<Publicaciones_DepositoTipoPub> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_DepositoTipoPubRepository.GetDataTablePublicaciones_DepositoTipoPub(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
