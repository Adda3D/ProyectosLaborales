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
    public class Publicaciones_RolEditorialController : BaseController<Publicaciones_RolEditorial>
    {
        private readonly IPublicaciones_RolEditorialRepository _publicaciones_RolEditorialRepository;
        public Publicaciones_RolEditorialController(IPublicaciones_RolEditorialRepository publicaciones_RolEditorialRepository)
        {
            _publicaciones_RolEditorialRepository = publicaciones_RolEditorialRepository;
        }
        readonly IPublicaciones_RolEditorialRepository publicaciones_RolEditorialRepository = new Publicaciones_RolEditorialRepository();
        public Publicaciones_RolEditorialController()
        {
            _publicaciones_RolEditorialRepository = publicaciones_RolEditorialRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_RolEditorial()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_RolEditorialRepository.GetAllPublicaciones_RolEditorial();

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
        public IHttpActionResult GetPublicaciones_RolEditorialDetails(int id_roleditorial)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_RolEditorialRepository.GetPublicaciones_RolEditorialDetails(id_roleditorial);

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
        public IHttpActionResult GetPublicaciones_RolEditorialNombre(string cd_nmroleditorial)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_RolEditorialRepository.GetPublicaciones_RolEditorialNombre(cd_nmroleditorial);

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
        public IHttpActionResult InsertPublicaciones_RolEditorial([FromBody] Publicaciones_RolEditorial publicaciones_RolEditorial)
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

                var created = publicaciones_RolEditorialRepository.InsertPublicaciones_RolEditorial(publicaciones_RolEditorial);

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
        public IHttpActionResult UpdatePublicaciones_RolEditorial([FromBody] Publicaciones_RolEditorial publicaciones_RolEditorial)
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

                var created = publicaciones_RolEditorialRepository.UpdatePublicaciones_RolEditorial(publicaciones_RolEditorial);

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
        public IHttpActionResult DeletePublicaciones_RolEditorial(int id_roleditorial)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_RolEditorialRepository.DeletePublicaciones_RolEditorial(id_roleditorial);

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
