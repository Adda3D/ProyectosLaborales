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
    public class Publicaciones_DiagFinalParamController : BaseController<Publicaciones_DiagFinalParam>
    {
        private readonly IPublicaciones_DiagFinalParamRepository _publicaciones_DiagFinalParamRepository;
        public Publicaciones_DiagFinalParamController (IPublicaciones_DiagFinalParamRepository publicaciones_DiagFinalParamRepository)
        {
            _publicaciones_DiagFinalParamRepository = publicaciones_DiagFinalParamRepository;
        }
        readonly IPublicaciones_DiagFinalParamRepository publicaciones_DiagFinalParamRepository = new Publicaciones_DiagFinalParamRepository();
        public Publicaciones_DiagFinalParamController()
        {
            _publicaciones_DiagFinalParamRepository = publicaciones_DiagFinalParamRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DiagFinalParam()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DiagFinalParamRepository.GetAllPublicaciones_DiagFinalParam();

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
        public IHttpActionResult GetPublicaciones_DiagFinalParamDetails(int id_diagfinalparam)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DiagFinalParamRepository.GetPublicaciones_DiagFinalParamDetails(id_diagfinalparam);

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
        public IHttpActionResult GetPublicaciones_DiagFinalParamNombre(string cd_responsable)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DiagFinalParamRepository.GetPublicaciones_DiagFinalParamNombre(cd_responsable);

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
        public IHttpActionResult InsertPublicaciones_DiagFinalParam([FromBody] Publicaciones_DiagFinalParam publicaciones_DiagFinalParam)
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

                var created = publicaciones_DiagFinalParamRepository.InsertPublicaciones_DiagFinalParam(publicaciones_DiagFinalParam);

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
        public IHttpActionResult UpdatePublicaciones_DiagFinalParam([FromBody] Publicaciones_DiagFinalParam publicaciones_DiagFinalParam)
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

                var created = publicaciones_DiagFinalParamRepository.UpdatePublicaciones_DiagFinalParam(publicaciones_DiagFinalParam);

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
        public IHttpActionResult DeletePublicaciones_DiagFinalParam(int id_diagfinalparam)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DiagFinalParamRepository.DeletePublicaciones_DiagFinalParam(id_diagfinalparam);

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
