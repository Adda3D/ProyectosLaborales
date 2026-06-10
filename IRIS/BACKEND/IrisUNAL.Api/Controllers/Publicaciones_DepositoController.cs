using IrisUNAL.Api.Entities.Repositories;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IrisUNAL.Api.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class Publicaciones_DepositoController : BaseController<Publicaciones_Deposito>
    {
        private readonly IPublicaciones_DepositoRepository _publicaciones_DepositoRepository;
        public Publicaciones_DepositoController(IPublicaciones_DepositoRepository publicaciones_DepositoRepository)
        {
            _publicaciones_DepositoRepository = publicaciones_DepositoRepository;
        }
        readonly IPublicaciones_DepositoRepository publicaciones_DepositoRepository = new Publicaciones_DepositoRepository();
        public Publicaciones_DepositoController()
        {
            _publicaciones_DepositoRepository = publicaciones_DepositoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_Deposito()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoRepository.GetAllPublicaciones_Deposito();

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
        public IHttpActionResult GetPublicaciones_DepositoDetails(int id_deposito)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoRepository.GetPublicaciones_DepositoDetails(id_deposito);

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
        public IHttpActionResult GetPublicaciones_DepositoCodigo(string cd_id_kardex)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoRepository.GetPublicaciones_DepositoCodigo(cd_id_kardex);

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

        [HttpPost]
        public IHttpActionResult InsertPublicaciones_Deposito([FromBody] Publicaciones_Deposito publicaciones_Deposito)
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

                var created = publicaciones_DepositoRepository.InsertPublicaciones_Deposito(publicaciones_Deposito);

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
        public IHttpActionResult UpdatePublicaciones_Deposito([FromBody] Publicaciones_Deposito publicaciones_Deposito)
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

                var created = publicaciones_DepositoRepository.UpdatePublicaciones_Deposito(publicaciones_Deposito);

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
        public IHttpActionResult DeletePublicaciones_Deposito(int id_deposito)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DepositoRepository.DeletePublicaciones_Deposito(id_deposito);

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
    }
}
