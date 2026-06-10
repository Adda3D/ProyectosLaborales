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
    public class Publicaciones_DiagramacionController : BaseController<Publicaciones_Diagramacion>
    {
        private readonly IPublicaciones_DiagramacionRepository _publicaciones_DiagramacionRepository;
        public Publicaciones_DiagramacionController(IPublicaciones_DiagramacionRepository publicaciones_DiagramacionRepository)
        {
            _publicaciones_DiagramacionRepository = publicaciones_DiagramacionRepository;
        }
        readonly IPublicaciones_DiagramacionRepository publicaciones_DiagramacionRepository = new Publicaciones_DiagramacionRepository();
        public Publicaciones_DiagramacionController()
        {
            _publicaciones_DiagramacionRepository = publicaciones_DiagramacionRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_Diagramacion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DiagramacionRepository.GetAllPublicaciones_Diagramacion();

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
        public IHttpActionResult GetPublicaciones_DiagramacionDetails(int id_diagramacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DiagramacionRepository.GetPublicaciones_DiagramacionDetails(id_diagramacion);

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
        public IHttpActionResult GetPublicaciones_DiagramacionByPublicacionTipo(int id_crearpublicacion, string nmdiagramacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DiagramacionRepository.GetPublicaciones_DiagramacionByPublicacionTipo(id_crearpublicacion, nmdiagramacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Diagramación " + nmdiagramacion + " no definida ";
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
        public IHttpActionResult InsertPublicaciones_Diagramacion([FromBody] Publicaciones_Diagramacion publicaciones_Diagramacion)
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

                var created = publicaciones_DiagramacionRepository.InsertPublicaciones_Diagramacion(publicaciones_Diagramacion);

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
        public IHttpActionResult UpdatePublicaciones_Diagramacion([FromBody] Publicaciones_Diagramacion publicaciones_Diagramacion)
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

                var created = publicaciones_DiagramacionRepository.UpdatePublicaciones_Diagramacion(publicaciones_Diagramacion);

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
        public IHttpActionResult DeletePublicaciones_Diagramacion(int id_diagramacion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DiagramacionRepository.DeletePublicaciones_Diagramacion(id_diagramacion);

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
