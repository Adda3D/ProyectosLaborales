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
    public class Publicaciones_DigitalizacionController : BaseController<Publicaciones_Digitalizacion>
    {
        private readonly IPublicaciones_DigitalizacionRepository _publicaciones_DigitalizacionRepository;
        public Publicaciones_DigitalizacionController(IPublicaciones_DigitalizacionRepository publicaciones_DigitalizacionRepository)
        {
            _publicaciones_DigitalizacionRepository = publicaciones_DigitalizacionRepository;
        }
        readonly IPublicaciones_DigitalizacionRepository publicaciones_DigitalizacionRepository = new Publicaciones_DigitalizacionRepository();
        public Publicaciones_DigitalizacionController()
        {
            _publicaciones_DigitalizacionRepository = publicaciones_DigitalizacionRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_Digitalizacion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DigitalizacionRepository.GetAllPublicaciones_Digitalizacion();

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
        public IHttpActionResult GetPublicaciones_DigitalizacionDetails(int id_digitalizacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DigitalizacionRepository.GetPublicaciones_DigitalizacionDetails(id_digitalizacion);

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
        public IHttpActionResult GetPublicaciones_DigitalizacionByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DigitalizacionRepository.GetPublicaciones_DigitalizacionByPublicacion(id_crearpublicacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Datos Digitalización no asignados a la publicación";
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
        public IHttpActionResult InsertPublicaciones_Digitalizacion([FromBody] Publicaciones_Digitalizacion publicaciones_Digitalizacion)
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

                var created = publicaciones_DigitalizacionRepository.InsertPublicaciones_Digitalizacion(publicaciones_Digitalizacion);

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
        public IHttpActionResult UpdatePublicaciones_Digitalizacion([FromBody] Publicaciones_Digitalizacion publicaciones_Digitalizacion)
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

                var created = publicaciones_DigitalizacionRepository.UpdatePublicaciones_Digitalizacion(publicaciones_Digitalizacion);

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
        public IHttpActionResult DeletePublicaciones_Digitalizacion(int id_digitalizacion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DigitalizacionRepository.DeletePublicaciones_Digitalizacion(id_digitalizacion);

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
