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
    public class Publicaciones_DepositoDistribucionParamController : BaseController<Publicaciones_DepositoDistribucionParam>
    {
        private readonly IPublicaciones_DepositoDistribucionParamRepository _publicaciones_DepositoDistribucionParamRepository;
        public Publicaciones_DepositoDistribucionParamController (IPublicaciones_DepositoDistribucionParamRepository publicaciones_DepositoDistribucionParamRepository)
        {
            _publicaciones_DepositoDistribucionParamRepository = publicaciones_DepositoDistribucionParamRepository;
        }
        readonly IPublicaciones_DepositoDistribucionParamRepository publicaciones_DepositoDistribucionParamRepository = new Publicaciones_DepositoDistribucionParamRepository();
        public Publicaciones_DepositoDistribucionParamController()
        {
            _publicaciones_DepositoDistribucionParamRepository = publicaciones_DepositoDistribucionParamRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DepositoDistribucionParam()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoDistribucionParamRepository.GetAllPublicaciones_DepositoDistribucionParam();

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
        public IHttpActionResult GetPublicaciones_DepositoDistribucionParamDetails(int id_distparam)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoDistribucionParamRepository.GetPublicaciones_DepositoDistribucionParamDetails(id_distparam);

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
        public IHttpActionResult GetPublicaciones_DepositoDistribucionParamConsecutivo(string cd_consecutivo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoDistribucionParamRepository.GetPublicaciones_DepositoDistribucionParamConsecutivo(cd_consecutivo);

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
        public IHttpActionResult InsertPublicaciones_DepositoDistribucionParam([FromBody] Publicaciones_DepositoDistribucionParam publicaciones_DepositoDistribucionParam)
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

                var created = publicaciones_DepositoDistribucionParamRepository.InsertPublicaciones_DepositoDistribucionParam(publicaciones_DepositoDistribucionParam);

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
        public IHttpActionResult UpdatePublicaciones_DepositoDistribucionParam([FromBody] Publicaciones_DepositoDistribucionParam publicaciones_DepositoDistribucionParam)
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

                var created = publicaciones_DepositoDistribucionParamRepository.UpdatePublicaciones_DepositoDistribucionParam(publicaciones_DepositoDistribucionParam);

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
        public IHttpActionResult DeletePublicaciones_DepositoDistribucionParam(int id_distparam)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DepositoDistribucionParamRepository.DeletePublicaciones_DepositoDistribucionParam(id_distparam);

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
