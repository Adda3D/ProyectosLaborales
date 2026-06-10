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
    public class Publicaciones_TipologiaController : BaseController<Publicaciones_Tipologia>
    {
        private readonly IPublicaciones_TipologiaRepository _publicaciones_TipologiaRepository;
        public Publicaciones_TipologiaController(IPublicaciones_TipologiaRepository publicaciones_TipologiaRepository)
        {
            _publicaciones_TipologiaRepository = publicaciones_TipologiaRepository;
        }
        readonly IPublicaciones_TipologiaRepository publicaciones_TipologiaRepository = new Publicaciones_TipologiaRepository();
        public Publicaciones_TipologiaController()
        {
            _publicaciones_TipologiaRepository = publicaciones_TipologiaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_Tipologia()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_TipologiaRepository.GetAllPublicaciones_Tipologia();

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
        public IHttpActionResult GetPublicaciones_TipologiaDetails(int id_tipologia)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_TipologiaRepository.GetPublicaciones_TipologiaDetails(id_tipologia);

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
        public IHttpActionResult InsertPublicaciones_Tipologia([FromBody] Publicaciones_Tipologia publicaciones_Tipologia)
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

                var created = publicaciones_TipologiaRepository.InsertPublicaciones_Tipologia(publicaciones_Tipologia);

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
        public IHttpActionResult UpdatePublicaciones_Tipologia([FromBody] Publicaciones_Tipologia publicaciones_Tipologia)
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

                var created = publicaciones_TipologiaRepository.UpdatePublicaciones_Tipologia(publicaciones_Tipologia);

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
        public IHttpActionResult DeletePublicaciones_Tipologia(int id_tipologia)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_TipologiaRepository.DeletePublicaciones_Tipologia(id_tipologia);

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
