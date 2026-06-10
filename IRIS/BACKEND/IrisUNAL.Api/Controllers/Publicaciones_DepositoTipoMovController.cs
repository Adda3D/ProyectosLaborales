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
    public class Publicaciones_DepositoTipoMovController : BaseController<Publicaciones_DepositoTipoMov>
    {
        private readonly IPublicaciones_DepositoTipoMovRepository _publicaciones_DepositoTipoMovRepository;
        public Publicaciones_DepositoTipoMovController(IPublicaciones_DepositoTipoMovRepository publicaciones_DepositoTipoMovRepository)
        {
            _publicaciones_DepositoTipoMovRepository = publicaciones_DepositoTipoMovRepository;
        }
        readonly IPublicaciones_DepositoTipoMovRepository publicaciones_DepositoTipoMovRepository = new Publicaciones_DepositoTipoMovRepository();
        public Publicaciones_DepositoTipoMovController()
        {
            _publicaciones_DepositoTipoMovRepository = publicaciones_DepositoTipoMovRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DepositoTipoMov()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoTipoMovRepository.GetAllPublicaciones_DepositoTipoMov();

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
        public IHttpActionResult GetPublicaciones_DepositoTipoMovDetails(int id_tipomov)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoTipoMovRepository.GetPublicaciones_DepositoTipoMovDetails(id_tipomov);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_DepositoTipoMov inexistente";
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
        public IHttpActionResult GetPublicaciones_DepositoTipoMovNombre(string cd_nmtipomov)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoTipoMovRepository.GetPublicaciones_DepositoTipoMovNombre(cd_nmtipomov);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_DepositoTipoMov inexistente";
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
        public IHttpActionResult InsertPublicaciones_DepositoTipoMov([FromBody] Publicaciones_DepositoTipoMov publicaciones_DepositoTipoMov)
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

                var created = publicaciones_DepositoTipoMovRepository.InsertPublicaciones_DepositoTipoMov(publicaciones_DepositoTipoMov);

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
        public IHttpActionResult UpdatePublicaciones_DepositoTipoMov([FromBody] Publicaciones_DepositoTipoMov publicaciones_DepositoTipoMov)
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

                var created = publicaciones_DepositoTipoMovRepository.UpdatePublicaciones_DepositoTipoMov(publicaciones_DepositoTipoMov);

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
        public IHttpActionResult DeletePublicaciones_DepositoTipoMov(int id_tipomov)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DepositoTipoMovRepository.DeletePublicaciones_DepositoTipoMov(id_tipomov);

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
        public IHttpActionResult GetDataTablePublicaciones_DepositoTipoMov()
        {
            DataTableAdapter<Publicaciones_DepositoTipoMov> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_DepositoTipoMovRepository.GetDataTablePublicaciones_DepositoTipoMov(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
