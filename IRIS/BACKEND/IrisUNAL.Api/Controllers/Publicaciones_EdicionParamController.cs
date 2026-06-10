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
    public class Publicaciones_EdicionParamController : BaseController<Publicaciones_EdicionParam>
    {
        private readonly IPublicaciones_EdicionParamRepository _publicaciones_EdicionParamRepository;
        public Publicaciones_EdicionParamController(IPublicaciones_EdicionParamRepository publicaciones_EdicionParamRepository)
        {
            _publicaciones_EdicionParamRepository = publicaciones_EdicionParamRepository;
        }
        readonly IPublicaciones_EdicionParamRepository publicaciones_EdicionParamRepository = new Publicaciones_EdicionParamRepository();
        public Publicaciones_EdicionParamController()
        {
            _publicaciones_EdicionParamRepository = publicaciones_EdicionParamRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_EdicionParam()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EdicionParamRepository.GetAllPublicaciones_EdicionParam();

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
        public IHttpActionResult GetPublicaciones_EdicionParamDetails(int id_edicionparam)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EdicionParamRepository.GetPublicaciones_EdicionParamDetails(id_edicionparam);

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
        public IHttpActionResult GetPublicaciones_EdicionParamCodigo(string cd_codhermes)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EdicionParamRepository.GetPublicaciones_EdicionParamCodigo(cd_codhermes);

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
        public IHttpActionResult InsertPublicaciones_EdicionParam([FromBody] Publicaciones_EdicionParam publicaciones_EdicionParam)
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

                var created = publicaciones_EdicionParamRepository.InsertPublicaciones_EdicionParam(publicaciones_EdicionParam);

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
        public IHttpActionResult UpdatePublicaciones_EdicionParam([FromBody] Publicaciones_EdicionParam publicaciones_EdicionParam)
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

                var created = publicaciones_EdicionParamRepository.UpdatePublicaciones_EdicionParam(publicaciones_EdicionParam);

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
        public IHttpActionResult DeletePublicaciones_EdicionParam(int id_edicionparam)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_EdicionParamRepository.DeletePublicaciones_EdicionParam(id_edicionparam);

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
