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
    public class Seguimiento_PartidaController : BaseController<Seguimiento_Partida>
    {
        private readonly ISeguimiento_PartidaRepository _seguimiento_PartidaRepository;

        public Seguimiento_PartidaController(ISeguimiento_PartidaRepository seguimiento_PartidaRepository)
        {
            _seguimiento_PartidaRepository = seguimiento_PartidaRepository;
        }

        readonly ISeguimiento_PartidaRepository seguimiento_PartidaRepository = new Seguimiento_PartidaRepository();
        public Seguimiento_PartidaController()
        {
            _seguimiento_PartidaRepository = seguimiento_PartidaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllSeguimiento_Partida()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_PartidaRepository.GetAllSeguimiento_Partida();

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
        public IHttpActionResult GetSeguimiento_PartidaDetails(int id_partida)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_PartidaRepository.GetSeguimiento_PartidaDetails(id_partida);

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
        public IHttpActionResult GetSeguimiento_PartidaCodigo(string cd_codigointernopartida)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_PartidaRepository.GetSeguimiento_PartidaCodigo(cd_codigointernopartida);

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
        public IHttpActionResult InsertSeguimiento_Partida([FromBody] Seguimiento_Partida seguimiento_Partida)
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

                var created = _seguimiento_PartidaRepository.InsertSeguimiento_Partida(seguimiento_Partida);

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
        public IHttpActionResult UpdateSeguimiento_Partida([FromBody] Seguimiento_Partida seguimiento_Partida)
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

                var created = _seguimiento_PartidaRepository.UpdateSeguimiento_Partida(seguimiento_Partida);

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
        public IHttpActionResult DeleteSeguimiento_Partida(int id_partida)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _seguimiento_PartidaRepository.DeleteSeguimiento_Partida(id_partida);

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
