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
    public class Publicaciones_ResponsableController : BaseController<Publicaciones_Responsable>
    {
        private readonly IPublicaciones_ResponsableRepository _publicaciones_ResponsableRepository;
        public Publicaciones_ResponsableController(IPublicaciones_ResponsableRepository publicaciones_ResponsableRepository)
        {
            _publicaciones_ResponsableRepository = publicaciones_ResponsableRepository;
        }
        readonly IPublicaciones_ResponsableRepository publicaciones_ResponsableRepository = new Publicaciones_ResponsableRepository();
        public Publicaciones_ResponsableController()
        {
            _publicaciones_ResponsableRepository = publicaciones_ResponsableRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_Responsable()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ResponsableRepository.GetAllPublicaciones_Responsable();

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
        public IHttpActionResult GetPublicaciones_ResponsableDetails(int id_responsable)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ResponsableRepository.GetPublicaciones_ResponsableDetails(id_responsable);

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
        public IHttpActionResult InsertPublicaciones_Responsable([FromBody] Publicaciones_Responsable publicaciones_Responsable)
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

                var created = publicaciones_ResponsableRepository.InsertPublicaciones_Responsable(publicaciones_Responsable);

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
        public IHttpActionResult UpdatePublicaciones_Responsable([FromBody] Publicaciones_Responsable publicaciones_Responsable)
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

                var created = publicaciones_ResponsableRepository.UpdatePublicaciones_Responsable(publicaciones_Responsable);

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
        public IHttpActionResult DeletePublicaciones_Responsable(int id_responsable)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_ResponsableRepository.DeletePublicaciones_Responsable(id_responsable);

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
