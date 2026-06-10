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
    public class Publicaciones_DepositoDistribucionTituloController : BaseController<Publicaciones_DepositoDistribucionTitulo>
    {
        private readonly IPublicaciones_DepositoDistribucionTituloRepository _publicaciones_DepositoDistribucionTituloRepository;
        public Publicaciones_DepositoDistribucionTituloController (IPublicaciones_DepositoDistribucionTituloRepository publicaciones_DepositoDistribucionTituloRepository)
        {
            _publicaciones_DepositoDistribucionTituloRepository = publicaciones_DepositoDistribucionTituloRepository;
        }
        readonly IPublicaciones_DepositoDistribucionTituloRepository publicaciones_DepositoDistribucionTituloRepository = new Publicaciones_DepositoDistribucionTituloRepository();
        public Publicaciones_DepositoDistribucionTituloController()
        {
            _publicaciones_DepositoDistribucionTituloRepository = publicaciones_DepositoDistribucionTituloRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DepositoDistribucionTitulo()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoDistribucionTituloRepository.GetAllPublicaciones_DepositoDistribucionTitulo();

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
        public IHttpActionResult GetPublicaciones_DepositoDistribucionTituloDetails(int id_disttitulo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoDistribucionTituloRepository.GetPublicaciones_DepositoDistribucionTituloDetails(id_disttitulo);

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
        public IHttpActionResult GetPublicaciones_DepositoDistribucionTituloNombre(string cd_nmtitulo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoDistribucionTituloRepository.GetPublicaciones_DepositoDistribucionTituloNombre(cd_nmtitulo);

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
        public IHttpActionResult InsertPublicaciones_DepositoDistribucionTitulo([FromBody] Publicaciones_DepositoDistribucionTitulo publicaciones_DepositoDistribucionTitulo)
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

                var created = publicaciones_DepositoDistribucionTituloRepository.InsertPublicaciones_DepositoDistribucionTitulo(publicaciones_DepositoDistribucionTitulo);

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
        public IHttpActionResult UpdatePublicaciones_DepositoDistribucionTitulo([FromBody] Publicaciones_DepositoDistribucionTitulo publicaciones_DepositoDistribucionTitulo)
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

                var created = publicaciones_DepositoDistribucionTituloRepository.UpdatePublicaciones_DepositoDistribucionTitulo(publicaciones_DepositoDistribucionTitulo);

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
        public IHttpActionResult DeletePublicaciones_DepositoDistribucionTitulo(int id_disttitulo)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DepositoDistribucionTituloRepository.DeletePublicaciones_DepositoDistribucionTitulo(id_disttitulo);

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
