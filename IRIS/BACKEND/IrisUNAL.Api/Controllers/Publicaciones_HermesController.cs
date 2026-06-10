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
    public class Publicaciones_HermesController : BaseController<Publicaciones_Hermes>
    {
        private readonly IPublicaciones_HermesRepository _publicaciones_HermesRepository;
        public Publicaciones_HermesController(IPublicaciones_HermesRepository publicaciones_HermesRepository)
        {
            _publicaciones_HermesRepository = publicaciones_HermesRepository;
        }
        readonly IPublicaciones_HermesRepository publicaciones_HermesRepository = new Publicaciones_HermesRepository();
        public Publicaciones_HermesController()
        {
            _publicaciones_HermesRepository = publicaciones_HermesRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_Hermes()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_HermesRepository.GetAllPublicaciones_Hermes();

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
        public IHttpActionResult GetPublicaciones_HermesDetails(int id_hermes)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_HermesRepository.GetPublicaciones_HermesDetails(id_hermes);

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
        public IHttpActionResult GetPublicaciones_HermesNumero(string cd_numhermes)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_HermesRepository.GetPublicaciones_HermesNumero(cd_numhermes);

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
        public IHttpActionResult InsertPublicaciones_Hermes([FromBody] Publicaciones_Hermes publicaciones_Hermes)
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

                var created = publicaciones_HermesRepository.InsertPublicaciones_Hermes(publicaciones_Hermes);

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
        public IHttpActionResult UpdatePublicaciones_Hermes([FromBody] Publicaciones_Hermes publicaciones_Hermes)
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

                var created = publicaciones_HermesRepository.UpdatePublicaciones_Hermes(publicaciones_Hermes);

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
        public IHttpActionResult DeletePublicaciones_Hermes(int id_hermes)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_HermesRepository.DeletePublicaciones_Hermes(id_hermes);

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
