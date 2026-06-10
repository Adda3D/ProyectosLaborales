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
    public class Publicaciones_ResenaController : BaseController<Publicaciones_Resena>
    {
        private readonly IPublicaciones_ResenaRepository _publicaciones_ResenaRepository;
        public Publicaciones_ResenaController(IPublicaciones_ResenaRepository publicaciones_ResenaRepository)
        {
            _publicaciones_ResenaRepository = publicaciones_ResenaRepository;
        }
        readonly IPublicaciones_ResenaRepository publicaciones_ResenaRepository = new Publicaciones_ResenaRepository();
        public Publicaciones_ResenaController()
        {
            _publicaciones_ResenaRepository = publicaciones_ResenaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_Resena()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ResenaRepository.GetAllPublicaciones_Resena();

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
        public IHttpActionResult GetPublicaciones_ResenaDetails(int id_resena)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ResenaRepository.GetPublicaciones_ResenaDetails(id_resena);

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
        public IHttpActionResult GetPublicaciones_ResenaNombre(string cd_nmresena)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ResenaRepository.GetPublicaciones_ResenaNombre(cd_nmresena);

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
        public IHttpActionResult InsertPublicaciones_Resena([FromBody] Publicaciones_Resena publicaciones_Resena)
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

                var created = publicaciones_ResenaRepository.InsertPublicaciones_Resena(publicaciones_Resena);

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
        public IHttpActionResult UpdatePublicaciones_Resena([FromBody] Publicaciones_Resena publicaciones_Resena)
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

                var created = publicaciones_ResenaRepository.UpdatePublicaciones_Resena(publicaciones_Resena);

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
        public IHttpActionResult DeletePublicaciones_Resena(int id_resena)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_ResenaRepository.DeletePublicaciones_Resena(id_resena);

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
