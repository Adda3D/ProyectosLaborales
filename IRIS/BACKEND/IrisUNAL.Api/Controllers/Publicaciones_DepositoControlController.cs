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
    public class Publicaciones_DepositoControlController : BaseController<Publicaciones_DepositoControl>
    {
        private readonly IPublicaciones_DepositoControlRepository _publicaciones_DepositoControlRepository;
        public Publicaciones_DepositoControlController(IPublicaciones_DepositoControlRepository publicaciones_DepositoControlRepository)
        {
            _publicaciones_DepositoControlRepository = publicaciones_DepositoControlRepository;
        }
        readonly IPublicaciones_DepositoControlRepository publicaciones_DepositoControlRepository = new Publicaciones_DepositoControlRepository();
        public Publicaciones_DepositoControlController()
        {
            _publicaciones_DepositoControlRepository = publicaciones_DepositoControlRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DepositoControl()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoControlRepository.GetAllPublicaciones_DepositoControl();

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
        public IHttpActionResult GetPublicaciones_DepositoControlDetails(int id_control)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoControlRepository.GetPublicaciones_DepositoControlDetails(id_control);

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
        public IHttpActionResult GetPublicaciones_DepositoControlCodigo(string cd_id_kardex)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoControlRepository.GetPublicaciones_DepositoControlCodigo(cd_id_kardex);

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
        public IHttpActionResult InsertPublicaciones_DepositoControl([FromBody] Publicaciones_DepositoControl publicaciones_DepositoControl)
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

                var created = publicaciones_DepositoControlRepository.InsertPublicaciones_DepositoControl(publicaciones_DepositoControl);

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
        public IHttpActionResult UpdatePublicaciones_DepositoControl([FromBody] Publicaciones_DepositoControl publicaciones_DepositoControl)
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

                var created = publicaciones_DepositoControlRepository.UpdatePublicaciones_DepositoControl(publicaciones_DepositoControl);

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
        public IHttpActionResult DeletePublicaciones_DepositoControl(int id_control)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DepositoControlRepository.DeletePublicaciones_DepositoControl(id_control);

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
