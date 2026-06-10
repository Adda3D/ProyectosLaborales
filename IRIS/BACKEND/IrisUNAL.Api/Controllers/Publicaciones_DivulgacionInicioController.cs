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
    public class Publicaciones_DivulgacionInicioController : BaseController<Publicaciones_DivulgacionInicio>
    {
        private readonly Publicaciones_DivulgacionInicioRepository _publicaciones_divulgacioninicioRepository;
        public Publicaciones_DivulgacionInicioController(Publicaciones_DivulgacionInicioRepository publicaciones_divulgacioninicioRepository)
        {
            _publicaciones_divulgacioninicioRepository = publicaciones_divulgacioninicioRepository;
        }
        readonly Publicaciones_DivulgacionInicioRepository publicaciones_divulgacioninicioRepository = new Publicaciones_DivulgacionInicioRepository();
        public Publicaciones_DivulgacionInicioController()
        {
            _publicaciones_divulgacioninicioRepository = publicaciones_divulgacioninicioRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DivulgacionInicio()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_divulgacioninicioRepository.GetAllPublicaciones_DivulgacionInicio();

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
        public IHttpActionResult GetPublicaciones_DivulgacionInicioDetails(int iddivulgacioninicio)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_divulgacioninicioRepository.GetPublicaciones_DivulgacionInicioDetails(iddivulgacioninicio);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Detalle inicio divulgación inexistente";
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
        public IHttpActionResult InsertPublicaciones_DivulgacionInicio([FromBody] Publicaciones_DivulgacionInicio _publicaciones_divulgacioninicio)
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

                var created = _publicaciones_divulgacioninicioRepository.InsertPublicaciones_DivulgacionInicio(_publicaciones_divulgacioninicio);

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
        public IHttpActionResult UpdatePublicaciones_DivulgacionInicio([FromBody] Publicaciones_DivulgacionInicio _publicaciones_divulgacioninicio)
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

                var created = _publicaciones_divulgacioninicioRepository.UpdatePublicaciones_DivulgacionInicio(_publicaciones_divulgacioninicio);

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
        public IHttpActionResult DeletePublicaciones_DivulgacionInicio(int iddivulgacioninicio)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _publicaciones_divulgacioninicioRepository.DeletePublicaciones_DivulgacionInicio(iddivulgacioninicio);

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
        public IHttpActionResult GetPublicaciones_DivulgacionInicioByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_divulgacioninicioRepository.GetPublicaciones_DivulgacionInicioByPublicacion(id_crearpublicacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Datos inicio divulgación no asignados para la publicación";
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
