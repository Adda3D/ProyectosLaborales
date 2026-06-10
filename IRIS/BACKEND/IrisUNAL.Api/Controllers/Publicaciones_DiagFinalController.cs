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
    public class Publicaciones_DiagFinalController : BaseController<Publicaciones_DiagFinal>
    {
        private readonly IPublicaciones_DiagFinalRepository _publicaciones_DiagFinalRepository;
        public Publicaciones_DiagFinalController(IPublicaciones_DiagFinalRepository publicaciones_DiagFinalRepository)
        {
            _publicaciones_DiagFinalRepository = publicaciones_DiagFinalRepository;
        }
        readonly IPublicaciones_DiagFinalRepository publicaciones_DiagFinalRepository = new Publicaciones_DiagFinalRepository();
        public Publicaciones_DiagFinalController()
        {
            _publicaciones_DiagFinalRepository = publicaciones_DiagFinalRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DiagFinal()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DiagFinalRepository.GetAllPublicaciones_DiagFinal();

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
        public IHttpActionResult GetPublicaciones_DiagFinalDetails(int id_diagfinal)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DiagFinalRepository.GetPublicaciones_DiagFinalDetails(id_diagfinal);

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
        public IHttpActionResult InsertPublicaciones_DiagFinal([FromBody] Publicaciones_DiagFinal publicaciones_DiagFinal)
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

                var created = publicaciones_DiagFinalRepository.InsertPublicaciones_DiagFinal(publicaciones_DiagFinal);

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
        public IHttpActionResult UpdatePublicaciones_DiagFinal([FromBody] Publicaciones_DiagFinal publicaciones_DiagFinal)
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

                var created = publicaciones_DiagFinalRepository.UpdatePublicaciones_DiagFinal(publicaciones_DiagFinal);

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
        public IHttpActionResult DeletePublicaciones_DiagFinal(int id_diagfinal)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DiagFinalRepository.DeletePublicaciones_DiagFinal(id_diagfinal);

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
