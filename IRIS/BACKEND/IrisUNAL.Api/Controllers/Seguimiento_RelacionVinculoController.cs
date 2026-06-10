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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Seguimiento_RelacionVinculoController : BaseController<Seguimiento_RelacionVinculo>
    {
        private readonly ISeguimiento_RelacionVinculoRepository _seguimiento_RelacionVinculoRepository;

        public Seguimiento_RelacionVinculoController(ISeguimiento_RelacionVinculoRepository seguimiento_RelacionVinculoRepository)
        {
            _seguimiento_RelacionVinculoRepository = seguimiento_RelacionVinculoRepository;
        }

        readonly ISeguimiento_RelacionVinculoRepository seguimiento_RelacionVinculoRepository = new Seguimiento_RelacionVinculoRepository();
        public Seguimiento_RelacionVinculoController()
        {
            _seguimiento_RelacionVinculoRepository = seguimiento_RelacionVinculoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllSeguimiento_RelacionVinculo()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_RelacionVinculoRepository.GetAllSeguimiento_RelacionVinculo();

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
        public IHttpActionResult GetSeguimiento_RelacionVinculoDetails(int id_relacionvinculo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_RelacionVinculoRepository.GetSeguimiento_RelacionVinculoDetails(id_relacionvinculo);

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
        public IHttpActionResult GetSeguimiento_RelacionVinculoNombre(string cd_nombrerelacionvinculo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_RelacionVinculoRepository.GetSeguimiento_RelacionVinculoNombre(cd_nombrerelacionvinculo);

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
        public IHttpActionResult InsertSeguimiento_RelacionVinculo([FromBody] Seguimiento_RelacionVinculo seguimiento_RelacionVinculo)
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

                var created = _seguimiento_RelacionVinculoRepository.InsertSeguimiento_RelacionVinculo(seguimiento_RelacionVinculo);

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
        public IHttpActionResult UpdateSeguimiento_RelacionVinculo([FromBody] Seguimiento_RelacionVinculo seguimiento_RelacionVinculo)
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

                var created = _seguimiento_RelacionVinculoRepository.UpdateSeguimiento_RelacionVinculo(seguimiento_RelacionVinculo);

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
        public IHttpActionResult DeleteSeguimiento_RelacionVinculo(int id_relacionvinculo)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _seguimiento_RelacionVinculoRepository.DeleteSeguimiento_RelacionVinculo(id_relacionvinculo);

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
