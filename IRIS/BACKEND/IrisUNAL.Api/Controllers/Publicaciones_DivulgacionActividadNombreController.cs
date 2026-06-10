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
    public class Publicaciones_DivulgacionActividadNombreController : BaseController<Publicaciones_DivulgacionActividadNombre>
    {
        private IPublicaciones_DivulgacionActividadNombreRepository _publicaciones_DivulgacionActividadNombreRepository;
        public Publicaciones_DivulgacionActividadNombreController(IPublicaciones_DivulgacionActividadNombreRepository publicaciones_DivulgacionActividadNombreRepository)
        {
            _publicaciones_DivulgacionActividadNombreRepository = publicaciones_DivulgacionActividadNombreRepository;
        }
        readonly IPublicaciones_DivulgacionActividadNombreRepository publicaciones_DivulgacionActividadNombreRepository = new Publicaciones_DivulgacionActividadNombreRepository();
        public Publicaciones_DivulgacionActividadNombreController()
        {
            _publicaciones_DivulgacionActividadNombreRepository = publicaciones_DivulgacionActividadNombreRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DivulgacionActividadNombre()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionActividadNombreRepository.GetAllPublicaciones_DivulgacionActividadNombre();

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
        public IHttpActionResult GetPublicaciones_DivulgacionActividadNombreDetails(int id_actividadnombre)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionActividadNombreRepository.GetPublicaciones_DivulgacionActividadNombreDetails(id_actividadnombre);

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
        public IHttpActionResult GetPublicaciones_DivulgacionActividadNombreNom(string cd_nomactividadnombre)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionActividadNombreRepository.GetPublicaciones_DivulgacionActividadNombreNom(cd_nomactividadnombre);

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
        public IHttpActionResult InsertPublicaciones_DivulgacionActividadNombre([FromBody] Publicaciones_DivulgacionActividadNombre publicaciones_DivulgacionActividadNombre)
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

                var created = publicaciones_DivulgacionActividadNombreRepository.InsertPublicaciones_DivulgacionActividadNombre(publicaciones_DivulgacionActividadNombre);

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
        public IHttpActionResult UpdatePublicaciones_DivulgacionActividadNombre([FromBody] Publicaciones_DivulgacionActividadNombre publicaciones_DivulgacionActividadNombre)
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

                var created = publicaciones_DivulgacionActividadNombreRepository.UpdatePublicaciones_DivulgacionActividadNombre(publicaciones_DivulgacionActividadNombre);

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
        public IHttpActionResult DeletePublicaciones_DivulgacionActividadNombre(int id_actividadnombre)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DivulgacionActividadNombreRepository.DeletePublicaciones_DivulgacionActividadNombre(id_actividadnombre);

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
