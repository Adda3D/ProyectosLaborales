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
    public class Publicaciones_DepositoResolucionController : BaseController<Publicaciones_DepositoResolucion>
    {
        private readonly IPublicaciones_DepositoResolucionRepository _publicaciones_DepositoResolucionRepository;
        public Publicaciones_DepositoResolucionController(IPublicaciones_DepositoResolucionRepository publicaciones_DepositoResolucionRepository)
        {
            _publicaciones_DepositoResolucionRepository = publicaciones_DepositoResolucionRepository;
        }
        readonly IPublicaciones_DepositoResolucionRepository publicaciones_DepositoResolucionRepository = new Publicaciones_DepositoResolucionRepository();
        public Publicaciones_DepositoResolucionController()
        {
            _publicaciones_DepositoResolucionRepository = publicaciones_DepositoResolucionRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DepositoResolucion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoResolucionRepository.GetAllPublicaciones_DepositoResolucion();

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
        public IHttpActionResult GetPublicaciones_DepositoResolucionDetails(int id_resolucion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoResolucionRepository.GetPublicaciones_DepositoResolucionDetails(id_resolucion);

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
        public IHttpActionResult GetPublicaciones_DepositoResolucionNumero(string cd_numresolucion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoResolucionRepository.GetPublicaciones_DepositoResolucionNumero(cd_numresolucion);

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
        public IHttpActionResult GetPublicaciones_DepositoResolucionByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoResolucionRepository.GetPublicaciones_DepositoResolucionByPublicacion(id_crearpublicacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Resolución distribución no asignada a la publicación";
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
        public IHttpActionResult InsertPublicaciones_DepositoResolucion([FromBody] Publicaciones_DepositoResolucion publicaciones_DepositoResolucion)
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

                var created = publicaciones_DepositoResolucionRepository.InsertPublicaciones_DepositoResolucion(publicaciones_DepositoResolucion);

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
        public IHttpActionResult UpdatePublicaciones_DepositoResolucion([FromBody] Publicaciones_DepositoResolucion publicaciones_DepositoResolucion)
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

                var created = publicaciones_DepositoResolucionRepository.UpdatePublicaciones_DepositoResolucion(publicaciones_DepositoResolucion);

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
        public IHttpActionResult DeletePublicaciones_DepositoResolucion(int id_resolucion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DepositoResolucionRepository.DeletePublicaciones_DepositoResolucion(id_resolucion);

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
