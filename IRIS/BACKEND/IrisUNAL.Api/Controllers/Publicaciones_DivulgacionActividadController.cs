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
    public class Publicaciones_DivulgacionActividadController : BaseController<Publicaciones_DivulgacionActividad>
    {
        private readonly IPublicaciones_DivulgacionActividadRepository _publicaciones_DivulgacionActividadRepository;
        public Publicaciones_DivulgacionActividadController(IPublicaciones_DivulgacionActividadRepository publicaciones_DivulgacionActividadRepository)
        {
            _publicaciones_DivulgacionActividadRepository = publicaciones_DivulgacionActividadRepository;
        }
        readonly IPublicaciones_DivulgacionActividadRepository publicaciones_DivulgacionActividadRepository = new Publicaciones_DivulgacionActividadRepository();
        public Publicaciones_DivulgacionActividadController()
        {
            _publicaciones_DivulgacionActividadRepository = publicaciones_DivulgacionActividadRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DivulgacionActividad()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionActividadRepository.GetAllPublicaciones_DivulgacionActividad();

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
        public IHttpActionResult GetPublicaciones_DivulgacionActividadDetails(int id_actividad)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionActividadRepository.GetPublicaciones_DivulgacionActividadDetails(id_actividad);

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
        public IHttpActionResult InsertPublicaciones_DivulgacionActividad([FromBody] Publicaciones_DivulgacionActividad publicaciones_DivulgacionActividad)
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

                var created = publicaciones_DivulgacionActividadRepository.InsertPublicaciones_DivulgacionActividad(publicaciones_DivulgacionActividad);

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
        public IHttpActionResult UpdatePublicaciones_DivulgacionActividad([FromBody] Publicaciones_DivulgacionActividad publicaciones_DivulgacionActividad)
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

                var created = publicaciones_DivulgacionActividadRepository.UpdatePublicaciones_DivulgacionActividad(publicaciones_DivulgacionActividad);

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
        public IHttpActionResult DeletePublicaciones_DivulgacionActividad(int id_actividad)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DivulgacionActividadRepository.DeletePublicaciones_DivulgacionActividad(id_actividad);

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
        public IHttpActionResult GetPublicaciones_DivulgacionActividadByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionActividadRepository.GetPublicaciones_DivulgacionActividadByPublicacion(id_crearpublicacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Datos lanzamiento facultad no asignados para la publicación";
                }

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
