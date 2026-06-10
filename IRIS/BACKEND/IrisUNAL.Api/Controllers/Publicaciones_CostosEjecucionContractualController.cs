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
    public class Publicaciones_CostosEjecucionContractualController : BaseController<Publicaciones_CostosEjecucionContractual>
    {
        private readonly IPublicaciones_CostosEjecucionContractualRepository _publicaciones_CostosEjecucionContractualRepository;
        public Publicaciones_CostosEjecucionContractualController(IPublicaciones_CostosEjecucionContractualRepository publicaciones_CostosEjecucionContractualRepository)
        {
            _publicaciones_CostosEjecucionContractualRepository = publicaciones_CostosEjecucionContractualRepository;
        }
        readonly IPublicaciones_CostosEjecucionContractualRepository publicaciones_CostosEjecucionContractualRepository = new Publicaciones_CostosEjecucionContractualRepository();
        public Publicaciones_CostosEjecucionContractualController()
        {
            _publicaciones_CostosEjecucionContractualRepository = publicaciones_CostosEjecucionContractualRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_CostosEjecucionContractual()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CostosEjecucionContractualRepository.GetAllPublicaciones_CostosEjecucionContractual();

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
        public IHttpActionResult GetPublicaciones_CostosEjecucionContractualDetails(int id_ejecucion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CostosEjecucionContractualRepository.GetPublicaciones_CostosEjecucionContractualDetails(id_ejecucion);

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
        public IHttpActionResult GetPublicaciones_CostosEjecucionContractualOrden(string cd_orpa)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CostosEjecucionContractualRepository.GetPublicaciones_CostosEjecucionContractualOrden(cd_orpa);

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
        public IHttpActionResult InsertPublicaciones_CostosEjecucionContractual([FromBody] Publicaciones_CostosEjecucionContractual publicaciones_CostosEjecucionContractual)
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

                var created = publicaciones_CostosEjecucionContractualRepository.InsertPublicaciones_CostosEjecucionContractual(publicaciones_CostosEjecucionContractual);

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
        public IHttpActionResult UpdatePublicaciones_CostosEjecucionContractual([FromBody] Publicaciones_CostosEjecucionContractual publicaciones_CostosEjecucionContractual)
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

                var created = publicaciones_CostosEjecucionContractualRepository.UpdatePublicaciones_CostosEjecucionContractual(publicaciones_CostosEjecucionContractual);

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
        public IHttpActionResult DeletePublicaciones_CostosEjecucionContractual(int id_ejecucion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_CostosEjecucionContractualRepository.DeletePublicaciones_CostosEjecucionContractual(id_ejecucion);

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
