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
    public class Publicaciones_CierreEdicionController : BaseController<Publicaciones_CierreEdicion>
    {
        private readonly IPublicaciones_CierreEdicionRepository _publicaciones_CierreEdicionRepository;
        public Publicaciones_CierreEdicionController(IPublicaciones_CierreEdicionRepository publicaciones_CierreEdicionRepository)
        {
            _publicaciones_CierreEdicionRepository = publicaciones_CierreEdicionRepository;
        }
        readonly IPublicaciones_CierreEdicionRepository publicaciones_CierreEdicionRepository = new Publicaciones_CierreEdicionRepository();
        public Publicaciones_CierreEdicionController()
        {
            _publicaciones_CierreEdicionRepository = publicaciones_CierreEdicionRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_CierreEdicion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CierreEdicionRepository.GetAllPublicaciones_CierreEdicion();

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
        public IHttpActionResult GetPublicaciones_CierreEdicionDetails(int id_cierreedicion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CierreEdicionRepository.GetPublicaciones_CierreEdicionDetails(id_cierreedicion);

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
        public IHttpActionResult GetPublicaciones_CierreEdicionByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CierreEdicionRepository.GetPublicaciones_CierreEdicionByPublicacion(id_crearpublicacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Cierre edición no asignado a la publicación";
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
        public IHttpActionResult InsertPublicaciones_CierreEdicion([FromBody] Publicaciones_CierreEdicion publicaciones_CierreEdicion)
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

                var created = publicaciones_CierreEdicionRepository.InsertPublicaciones_CierreEdicion(publicaciones_CierreEdicion);

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
        public IHttpActionResult UpdatePublicaciones_CierreEdicion([FromBody] Publicaciones_CierreEdicion publicaciones_CierreEdicion)
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

                var created = publicaciones_CierreEdicionRepository.UpdatePublicaciones_CierreEdicion(publicaciones_CierreEdicion);

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
        public IHttpActionResult DeletePublicaciones_CierreEdicion(int id_cierreedicion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_CierreEdicionRepository.DeletePublicaciones_CierreEdicion(id_cierreedicion);

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
