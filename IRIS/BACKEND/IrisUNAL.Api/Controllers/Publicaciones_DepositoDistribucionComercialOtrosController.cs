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
    public class Publicaciones_DepositoDistribucionComercialOtrosController : BaseController<Publicaciones_DepositoDistribucionComercialOtros>
    {
        private readonly IPublicaciones_DepositoDistribucionComercialOtrosRepository _publicaciones_DepositoDistribucionComercialOtrosRepository;
        public Publicaciones_DepositoDistribucionComercialOtrosController(IPublicaciones_DepositoDistribucionComercialOtrosRepository publicaciones_DepositoDistribucionComercialOtrosRepository)
        {
            _publicaciones_DepositoDistribucionComercialOtrosRepository = publicaciones_DepositoDistribucionComercialOtrosRepository;
        }
        readonly IPublicaciones_DepositoDistribucionComercialOtrosRepository publicaciones_DepositoDistribucionComercialOtrosRepository = new Publicaciones_DepositoDistribucionComercialOtrosRepository();
        public Publicaciones_DepositoDistribucionComercialOtrosController()
        {
            _publicaciones_DepositoDistribucionComercialOtrosRepository = publicaciones_DepositoDistribucionComercialOtrosRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DepositoDistribucionComercialOtros()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoDistribucionComercialOtrosRepository.GetAllPublicaciones_DepositoDistribucionComercialOtros();

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
        public IHttpActionResult GetPublicaciones_DepositoDistribucionComercialOtrosDetails(int id_otrosdistribuidores)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoDistribucionComercialOtrosRepository.GetPublicaciones_DepositoDistribucionComercialOtrosDetails(id_otrosdistribuidores);

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
        public IHttpActionResult GetPublicaciones_DepositoDistribucionComercialOtrosNombre(string cd_nmotrosdistribuidores)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoDistribucionComercialOtrosRepository.GetPublicaciones_DepositoDistribucionComercialOtrosNombre(cd_nmotrosdistribuidores);

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
        public IHttpActionResult InsertPublicaciones_DepositoDistribucionComercialOtros([FromBody] Publicaciones_DepositoDistribucionComercialOtros publicaciones_DepositoDistribucionComercialOtros)
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

                var created = publicaciones_DepositoDistribucionComercialOtrosRepository.InsertPublicaciones_DepositoDistribucionComercialOtros(publicaciones_DepositoDistribucionComercialOtros);

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
        public IHttpActionResult UpdatePublicaciones_DepositoDistribucionComercialOtros([FromBody] Publicaciones_DepositoDistribucionComercialOtros publicaciones_DepositoDistribucionComercialOtros)
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

                var created = publicaciones_DepositoDistribucionComercialOtrosRepository.UpdatePublicaciones_DepositoDistribucionComercialOtros(publicaciones_DepositoDistribucionComercialOtros);

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
        public IHttpActionResult DeletePublicaciones_DepositoDistribucionComercialOtros(int id_otrosdistribuidores)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DepositoDistribucionComercialOtrosRepository.DeletePublicaciones_DepositoDistribucionComercialOtros(id_otrosdistribuidores);

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
