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
    public class Publicaciones_DivulgacionParamController : BaseController<Publicaciones_DivulgacionParam>
    {
        private readonly IPublicaciones_DivulgacionParamRepository _publicaciones_DivulgacionParamRepository;
        public Publicaciones_DivulgacionParamController(IPublicaciones_DivulgacionParamRepository publicaciones_DivulgacionParamRepository)
        {
            _publicaciones_DivulgacionParamRepository = publicaciones_DivulgacionParamRepository;
        }
        readonly IPublicaciones_DivulgacionParamRepository publicaciones_DivulgacionParamRepository = new Publicaciones_DivulgacionParamRepository();
        public Publicaciones_DivulgacionParamController()
        {
            _publicaciones_DivulgacionParamRepository = publicaciones_DivulgacionParamRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DivulgacionParam()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionParamRepository.GetAllPublicaciones_DivulgacionParam();

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
        public IHttpActionResult GetPublicaciones_DivulgacionParamDetails(int id_divparam)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionParamRepository.GetPublicaciones_DivulgacionParamDetails(id_divparam);

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
        public IHttpActionResult GetPublicaciones_DivulgacionParamCodigo(string cd_id_kardex)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionParamRepository.GetPublicaciones_DivulgacionParamCodigo(cd_id_kardex);

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
        public IHttpActionResult InsertPublicaciones_DivulgacionParam([FromBody] Publicaciones_DivulgacionParam publicaciones_DivulgacionParam)
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

                var created = publicaciones_DivulgacionParamRepository.InsertPublicaciones_DivulgacionParam(publicaciones_DivulgacionParam);

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
        public IHttpActionResult UpdatePublicaciones_DivulgacionParam([FromBody] Publicaciones_DivulgacionParam publicaciones_DivulgacionParam)
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

                var created = publicaciones_DivulgacionParamRepository.UpdatePublicaciones_DivulgacionParam(publicaciones_DivulgacionParam);

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
        public IHttpActionResult DeletePublicaciones_DivulgacionParam(int id_divparam)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DivulgacionParamRepository.DeletePublicaciones_DivulgacionParam(id_divparam);

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
