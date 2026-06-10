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
    public class Publicaciones_DepositoControlIngresoVentasController : BaseController<Publicaciones_DepositoControlIngresoVentas>
    {
        private readonly IPublicaciones_DepositoControlIngresoVentasRepository _publicaciones_DepositoControlIngresoVentasRepository;
        public Publicaciones_DepositoControlIngresoVentasController (IPublicaciones_DepositoControlIngresoVentasRepository publicaciones_DepositoControlIngresoVentasRepository)
        {
            _publicaciones_DepositoControlIngresoVentasRepository = publicaciones_DepositoControlIngresoVentasRepository;
        }
        readonly IPublicaciones_DepositoControlIngresoVentasRepository publicaciones_DepositoControlIngresoVentasRepository = new Publicaciones_DepositoControlIngresoVentasRepository();
        public Publicaciones_DepositoControlIngresoVentasController()
        {
            _publicaciones_DepositoControlIngresoVentasRepository = publicaciones_DepositoControlIngresoVentasRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DepositoControlIngresoVentas()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoControlIngresoVentasRepository.GetAllPublicaciones_DepositoControlIngresoVentas();

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
        public IHttpActionResult GetPublicaciones_DepositoControlIngresoVentasDetails(int id_ingresoventas)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoControlIngresoVentasRepository.GetPublicaciones_DepositoControlIngresoVentasDetails(id_ingresoventas);

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
        public IHttpActionResult InsertPublicaciones_DepositoControlIngresoVentas([FromBody] Publicaciones_DepositoControlIngresoVentas publicaciones_DepositoControlIngresoVentas)
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

                var created = publicaciones_DepositoControlIngresoVentasRepository.InsertPublicaciones_DepositoControlIngresoVentas(publicaciones_DepositoControlIngresoVentas);

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
        public IHttpActionResult UpdatePublicaciones_DepositoControlIngresoVentas([FromBody] Publicaciones_DepositoControlIngresoVentas publicaciones_DepositoControlIngresoVentas)
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

                var created = publicaciones_DepositoControlIngresoVentasRepository.UpdatePublicaciones_DepositoControlIngresoVentas(publicaciones_DepositoControlIngresoVentas);

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
        public IHttpActionResult DeletePublicaciones_DepositoControlIngresoVentas(int id_ingresoventas)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DepositoControlIngresoVentasRepository.DeletePublicaciones_DepositoControlIngresoVentas(id_ingresoventas);

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
