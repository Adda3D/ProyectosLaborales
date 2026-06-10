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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Publicaciones_DepositoPreciosController : BaseController<Publicaciones_DepositoPrecios>
    {
        private readonly IPublicaciones_DepositoPreciosRepository _publicaciones_DepositoPreciosRepository;
        public Publicaciones_DepositoPreciosController(IPublicaciones_DepositoPreciosRepository publicaciones_DepositoPreciosRepository)
        {
            _publicaciones_DepositoPreciosRepository = publicaciones_DepositoPreciosRepository;
        }
        readonly IPublicaciones_DepositoPreciosRepository publicaciones_DepositoPreciosRepository = new Publicaciones_DepositoPreciosRepository();
        public Publicaciones_DepositoPreciosController()
        {
            _publicaciones_DepositoPreciosRepository = publicaciones_DepositoPreciosRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DepositoPrecios()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoPreciosRepository.GetAllPublicaciones_DepositoPrecios();

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
        public IHttpActionResult GetPublicaciones_DepositoPreciosDetails(int id_precios)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoPreciosRepository.GetPublicaciones_DepositoPreciosDetails(id_precios);

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
        public IHttpActionResult GetPublicaciones_DepositoPreciosByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoPreciosRepository.GetPublicaciones_DepositoPreciosByPublicacion(id_crearpublicacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Detalle de precios no asignado";
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
        public IHttpActionResult InsertPublicaciones_DepositoPrecios([FromBody] Publicaciones_DepositoPrecios publicaciones_DepositoPrecios)
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

                var created = publicaciones_DepositoPreciosRepository.InsertPublicaciones_DepositoPrecios(publicaciones_DepositoPrecios);

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
        public IHttpActionResult UpdatePublicaciones_DepositoPrecios([FromBody] Publicaciones_DepositoPrecios publicaciones_DepositoPrecios)
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

                var created = publicaciones_DepositoPreciosRepository.UpdatePublicaciones_DepositoPrecios(publicaciones_DepositoPrecios);

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
        public IHttpActionResult DeletePublicaciones_DepositoPrecios(int id_precios)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DepositoPreciosRepository.DeletePublicaciones_DepositoPrecios(id_precios);

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
