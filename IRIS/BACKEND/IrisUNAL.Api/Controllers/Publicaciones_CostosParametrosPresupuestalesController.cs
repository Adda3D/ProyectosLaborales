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
    public class Publicaciones_CostosParametrosPresupuestalesController : BaseController<Publicaciones_CostosParametrosPresupuestales>
    {
        private readonly IPublicaciones_CostosParametrosPresupuestalesRepository _publicaciones_CostosParametrosPresupuestalesRepository;
        public Publicaciones_CostosParametrosPresupuestalesController(IPublicaciones_CostosParametrosPresupuestalesRepository publicaciones_CostosParametrosPresupuestalesRepository)
        {
            _publicaciones_CostosParametrosPresupuestalesRepository = publicaciones_CostosParametrosPresupuestalesRepository;
        }
        readonly IPublicaciones_CostosParametrosPresupuestalesRepository publicaciones_CostosParametrosPresupuestalesRepository = new Publicaciones_CostosParametrosPresupuestalesRepository();
        public Publicaciones_CostosParametrosPresupuestalesController()
        {
            _publicaciones_CostosParametrosPresupuestalesRepository = publicaciones_CostosParametrosPresupuestalesRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_CostosParametrosPresupuestales()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CostosParametrosPresupuestalesRepository.GetAllPublicaciones_CostosParametrosPresupuestales();

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
        public IHttpActionResult GetPublicaciones_CostosParametrosPresupuestalesDetails(int id_costopublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CostosParametrosPresupuestalesRepository.GetPublicaciones_CostosParametrosPresupuestalesDetails(id_costopublicacion);

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
        public IHttpActionResult GetPublicaciones_CostosParametrosPresupuestalesCodigo(string cd_id_kardex)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CostosParametrosPresupuestalesRepository.GetPublicaciones_CostosParametrosPresupuestalesCodigo(cd_id_kardex);

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
        public IHttpActionResult InsertPublicaciones_CostosParametrosPresupuestales([FromBody] Publicaciones_CostosParametrosPresupuestales publicaciones_CostosParametrosPresupuestales)
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

                var created = publicaciones_CostosParametrosPresupuestalesRepository.InsertPublicaciones_CostosParametrosPresupuestales(publicaciones_CostosParametrosPresupuestales);

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
        public IHttpActionResult UpdatePublicaciones_CostosParametrosPresupuestales([FromBody] Publicaciones_CostosParametrosPresupuestales publicaciones_CostosParametrosPresupuestales)
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

                var created = publicaciones_CostosParametrosPresupuestalesRepository.UpdatePublicaciones_CostosParametrosPresupuestales(publicaciones_CostosParametrosPresupuestales);

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
        public IHttpActionResult DeletePublicaciones_CostosParametrosPresupuestales(int id_costopublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_CostosParametrosPresupuestalesRepository.DeletePublicaciones_CostosParametrosPresupuestales(id_costopublicacion);

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
