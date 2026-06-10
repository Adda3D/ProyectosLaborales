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
    public class Publicaciones_DesignacionController : BaseController<Publicaciones_Designacion>
    {
        private readonly IPublicaciones_DesignacionRepository _publicaciones_DesignacionRepository;
        public Publicaciones_DesignacionController(IPublicaciones_DesignacionRepository publicaciones_DesignacionRepository)
        {
            _publicaciones_DesignacionRepository = publicaciones_DesignacionRepository;
        }
        readonly IPublicaciones_DesignacionRepository publicaciones_DesignacionRepository = new Publicaciones_DesignacionRepository();
        public Publicaciones_DesignacionController()
        {
            _publicaciones_DesignacionRepository = publicaciones_DesignacionRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_Designacion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DesignacionRepository.GetAllPublicaciones_Designacion();

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
        public IHttpActionResult GetPublicaciones_DesignacionDetails(int id_designacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DesignacionRepository.GetPublicaciones_DesignacionDetails(id_designacion);

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
        public IHttpActionResult GetPublicaciones_DesignacionByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DesignacionRepository.GetPublicaciones_DesignacionByPublicacion(id_crearpublicacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Designación diagramador no asignada";
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
        public IHttpActionResult InsertPublicaciones_Designacion([FromBody] Publicaciones_Designacion publicaciones_Designacion)
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

                var created = publicaciones_DesignacionRepository.InsertPublicaciones_Designacion(publicaciones_Designacion);

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
        public IHttpActionResult UpdatePublicaciones_Designacion([FromBody] Publicaciones_Designacion publicaciones_Designacion)
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

                var created = publicaciones_DesignacionRepository.UpdatePublicaciones_Designacion(publicaciones_Designacion);

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
        public IHttpActionResult DeletePublicaciones_Designacion(int id_designacion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DesignacionRepository.DeletePublicaciones_Designacion(id_designacion);

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
