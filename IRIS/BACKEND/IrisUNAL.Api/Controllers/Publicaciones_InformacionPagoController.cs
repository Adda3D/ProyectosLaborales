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
    public class Publicaciones_InformacionPagoController : BaseController<Publicaciones_InformacionPago>
    {
        private readonly IPublicaciones_InformacionPagoRepository _publicaciones_InformacionPagoRepository;
        public Publicaciones_InformacionPagoController(IPublicaciones_InformacionPagoRepository publicaciones_InformacionPagoRepository)
        {
            _publicaciones_InformacionPagoRepository = publicaciones_InformacionPagoRepository;
        }
        readonly IPublicaciones_InformacionPagoRepository publicaciones_InformacionPagoRepository = new Publicaciones_InformacionPagoRepository();
        public Publicaciones_InformacionPagoController()
        {
            _publicaciones_InformacionPagoRepository = publicaciones_InformacionPagoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_InformacionPago()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_InformacionPagoRepository.GetAllPublicaciones_InformacionPago();

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
        public IHttpActionResult GetPublicaciones_InformacionPagoDetails(int id_informacionpago)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_InformacionPagoRepository.GetPublicaciones_InformacionPagoDetails(id_informacionpago);

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
        public IHttpActionResult GetPublicaciones_InformacionPagoByEvaluador(int id_evaluadores)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_InformacionPagoRepository.GetPublicaciones_InformacionPagoByEvaluador(id_evaluadores);

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
        public IHttpActionResult InsertPublicaciones_InformacionPago([FromBody] Publicaciones_InformacionPago publicaciones_InformacionPago)
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

                var created = publicaciones_InformacionPagoRepository.InsertPublicaciones_InformacionPago(publicaciones_InformacionPago);

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
        public IHttpActionResult UpdatePublicaciones_InformacionPago([FromBody] Publicaciones_InformacionPago publicaciones_InformacionPago)
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

                var created = publicaciones_InformacionPagoRepository.UpdatePublicaciones_InformacionPago(publicaciones_InformacionPago);

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
        public IHttpActionResult DeletePublicaciones_InformacionPago(int id_informacionpago)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_InformacionPagoRepository.DeletePublicaciones_InformacionPago(id_informacionpago);

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
