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
    public class Publicaciones_TipoCorreccionController : BaseController<Publicaciones_TipoCorreccion>
    {
        private readonly IPublicaciones_TipoCorreccionRepository _publicaciones_TipoCorreccionRepository;
        public Publicaciones_TipoCorreccionController(IPublicaciones_TipoCorreccionRepository publicaciones_TipoCorreccionRepository)
        {
            _publicaciones_TipoCorreccionRepository = publicaciones_TipoCorreccionRepository;
        }
        readonly IPublicaciones_TipoCorreccionRepository publicaciones_TipoCorreccionRepository = new Publicaciones_TipoCorreccionRepository();
        public Publicaciones_TipoCorreccionController()
        {
            _publicaciones_TipoCorreccionRepository = publicaciones_TipoCorreccionRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_TipoCorreccion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_TipoCorreccionRepository.GetAllPublicaciones_TipoCorreccion();

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
        public IHttpActionResult GetPublicaciones_TipoCorreccionDetails(int id_tipocorreccion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_TipoCorreccionRepository.GetPublicaciones_TipoCorreccionDetails(id_tipocorreccion);

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
        public IHttpActionResult GetPublicaciones_TipoCorreccionByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_TipoCorreccionRepository.GetPublicaciones_TipoCorreccionByPublicacion(id_crearpublicacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicación no tiene corrección asignada";
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
        public IHttpActionResult InsertPublicaciones_TipoCorreccion([FromBody] Publicaciones_TipoCorreccion publicaciones_TipoCorreccion)
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

                var created = publicaciones_TipoCorreccionRepository.InsertPublicaciones_TipoCorreccion(publicaciones_TipoCorreccion);

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
        public IHttpActionResult UpdatePublicaciones_TipoCorreccion([FromBody] Publicaciones_TipoCorreccion publicaciones_TipoCorreccion)
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

                var created = publicaciones_TipoCorreccionRepository.UpdatePublicaciones_TipoCorreccion(publicaciones_TipoCorreccion);

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
        public IHttpActionResult DeletePublicaciones_TipoCorreccion(int id_tipocorreccion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_TipoCorreccionRepository.DeletePublicaciones_TipoCorreccion(id_tipocorreccion);

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
