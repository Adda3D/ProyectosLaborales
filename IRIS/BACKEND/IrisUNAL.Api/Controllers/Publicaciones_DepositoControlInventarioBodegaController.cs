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
    public class Publicaciones_DepositoControlInventarioBodegaController : BaseController<Publicaciones_DepositoControlInventarioBodega>
    {
        private readonly IPublicaciones_DepositoControlInventarioBodegaRepository _publicaciones_DepositoControlInventarioBodegaRepository;
        public Publicaciones_DepositoControlInventarioBodegaController(IPublicaciones_DepositoControlInventarioBodegaRepository publicaciones_DepositoControlInventarioBodegaRepository)
        {
            _publicaciones_DepositoControlInventarioBodegaRepository = publicaciones_DepositoControlInventarioBodegaRepository;
        }
        readonly IPublicaciones_DepositoControlInventarioBodegaRepository publicaciones_DepositoControlInventarioBodegaRepository = new Publicaciones_DepositoControlInventarioBodegaRepository();
        public Publicaciones_DepositoControlInventarioBodegaController()
        {
            _publicaciones_DepositoControlInventarioBodegaRepository = publicaciones_DepositoControlInventarioBodegaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DepositoControlInventarioBodega()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoControlInventarioBodegaRepository.GetAllPublicaciones_DepositoControlInventarioBodega();

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
        public IHttpActionResult GetPublicaciones_DepositoControlInventarioBodegaDetails(int id_bodega)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoControlInventarioBodegaRepository.GetPublicaciones_DepositoControlInventarioBodegaDetails(id_bodega);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_DepositoControlInventarioBodega inexistente";
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
        public IHttpActionResult GetPublicaciones_DepositoControlInventarioBodegaNombre(string cd_nmbodega)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoControlInventarioBodegaRepository.GetPublicaciones_DepositoControlInventarioBodegaNombre(cd_nmbodega);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_DepositoControlInventarioBodega inexistente";
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
        public IHttpActionResult InsertPublicaciones_DepositoControlInventarioBodega([FromBody] Publicaciones_DepositoControlInventarioBodega publicaciones_DepositoControlInventarioBodega)
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

                var created = publicaciones_DepositoControlInventarioBodegaRepository.InsertPublicaciones_DepositoControlInventarioBodega(publicaciones_DepositoControlInventarioBodega);

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
        public IHttpActionResult UpdatePublicaciones_DepositoControlInventarioBodega([FromBody] Publicaciones_DepositoControlInventarioBodega publicaciones_DepositoControlInventarioBodega)
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

                var created = publicaciones_DepositoControlInventarioBodegaRepository.UpdatePublicaciones_DepositoControlInventarioBodega(publicaciones_DepositoControlInventarioBodega);

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
        public IHttpActionResult DeletePublicaciones_DepositoControlInventarioBodega(int id_bodega)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DepositoControlInventarioBodegaRepository.DeletePublicaciones_DepositoControlInventarioBodega(id_bodega);

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
        public IHttpActionResult GetDataTablePublicaciones_DepositoControlInventarioBodega()
        {
            DataTableAdapter<Publicaciones_DepositoControlInventarioBodega> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_DepositoControlInventarioBodegaRepository.GetDataTablePublicaciones_DepositoControlInventarioBodega(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
