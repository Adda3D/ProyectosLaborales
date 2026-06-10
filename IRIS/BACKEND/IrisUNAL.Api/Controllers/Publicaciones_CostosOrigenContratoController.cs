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
    public class Publicaciones_CostosOrigenContratoController : BaseController<Publicaciones_CostosOrigenContrato>
    {
        private readonly IPublicaciones_CostosOrigenContratoRepository _publicaciones_CostosOrigenContratoRepository;
        public Publicaciones_CostosOrigenContratoController (IPublicaciones_CostosOrigenContratoRepository publicaciones_CostosOrigenContratoRepository)
        {
            _publicaciones_CostosOrigenContratoRepository = publicaciones_CostosOrigenContratoRepository;
        }
        readonly IPublicaciones_CostosOrigenContratoRepository publicaciones_CostosOrigenContratoRepository = new Publicaciones_CostosOrigenContratoRepository();
        public Publicaciones_CostosOrigenContratoController()
        {
            _publicaciones_CostosOrigenContratoRepository = publicaciones_CostosOrigenContratoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_CostosOrigenContrato()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CostosOrigenContratoRepository.GetAllPublicaciones_CostosOrigenContrato();

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
        public IHttpActionResult GetPublicaciones_CostosOrigenContratoDetails(int id_origencontrato)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CostosOrigenContratoRepository.GetPublicaciones_CostosOrigenContratoDetails(id_origencontrato);

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
        public IHttpActionResult GetPublicaciones_CostosOrigenContratoNombre(string cd_proyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CostosOrigenContratoRepository.GetPublicaciones_CostosOrigenContratoNombre(cd_proyecto);

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
        public IHttpActionResult InsertPublicaciones_CostosOrigenContrato([FromBody] Publicaciones_CostosOrigenContrato publicaciones_CostosOrigenContrato)
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

                var created = publicaciones_CostosOrigenContratoRepository.InsertPublicaciones_CostosOrigenContrato(publicaciones_CostosOrigenContrato);

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
        public IHttpActionResult UpdatePublicaciones_CostosOrigenContrato([FromBody] Publicaciones_CostosOrigenContrato publicaciones_CostosOrigenContrato)
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

                var created = publicaciones_CostosOrigenContratoRepository.UpdatePublicaciones_CostosOrigenContrato(publicaciones_CostosOrigenContrato);

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
        public IHttpActionResult DeletePublicaciones_CostosOrigenContrato(int id_origencontrato)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_CostosOrigenContratoRepository.DeletePublicaciones_CostosOrigenContrato(id_origencontrato);

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
