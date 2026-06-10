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
    public class Publicaciones_DivulgacionCierreController : BaseController<Publicaciones_DivulgacionCierre>
    {
        private readonly IPublicaciones_DivulgacionCierreRepository _publicaciones_DivulgacionCierreRepository;
        public Publicaciones_DivulgacionCierreController(IPublicaciones_DivulgacionCierreRepository publicaciones_DivulgacionCierreRepository)
        {
            _publicaciones_DivulgacionCierreRepository = publicaciones_DivulgacionCierreRepository;
        }
        readonly IPublicaciones_DivulgacionCierreRepository publicaciones_DivulgacionCierreRepository = new Publicaciones_DivulgacionCierreRepository();
        public Publicaciones_DivulgacionCierreController()
        {
            _publicaciones_DivulgacionCierreRepository = publicaciones_DivulgacionCierreRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DivulgacionCierre()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionCierreRepository.GetAllPublicaciones_DivulgacionCierre();

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
        public IHttpActionResult GetPublicaciones_DivulgacionCierreDetails(int id_cierre)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionCierreRepository.GetPublicaciones_DivulgacionCierreDetails(id_cierre);

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
        public IHttpActionResult InsertPublicaciones_DivulgacionCierre([FromBody] Publicaciones_DivulgacionCierre publicaciones_DivulgacionCierre)
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

                var created = publicaciones_DivulgacionCierreRepository.InsertPublicaciones_DivulgacionCierre(publicaciones_DivulgacionCierre);

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
        public IHttpActionResult UpdatePublicaciones_DivulgacionCierre([FromBody] Publicaciones_DivulgacionCierre publicaciones_DivulgacionCierre)
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

                var created = publicaciones_DivulgacionCierreRepository.UpdatePublicaciones_DivulgacionCierre(publicaciones_DivulgacionCierre);

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
        public IHttpActionResult DeletePublicaciones_DivulgacionCierre(int id_cierre)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DivulgacionCierreRepository.DeletePublicaciones_DivulgacionCierre(id_cierre);

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
        public IHttpActionResult GetPublicaciones_DivulgacionCierreByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionCierreRepository.GetPublicaciones_DivulgacionCierreByPublicacion(id_crearpublicacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Cierre de divulgacón no asignado para la publicación";
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
