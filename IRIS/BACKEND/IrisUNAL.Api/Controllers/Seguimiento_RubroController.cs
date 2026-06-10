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
    public class Seguimiento_RubroController : BaseController<Seguimiento_Rubro>
    {
        private readonly ISeguimiento_RubroRepository _seguimiento_RubroRepository;

        public Seguimiento_RubroController(ISeguimiento_RubroRepository seguimiento_RubroRepository)
        {
            _seguimiento_RubroRepository = seguimiento_RubroRepository;
        }

        readonly ISeguimiento_RubroRepository seguimiento_RubroRepository = new Seguimiento_RubroRepository();
        public Seguimiento_RubroController()
        {
            _seguimiento_RubroRepository = seguimiento_RubroRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllSeguimiento_Rubro()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_RubroRepository.GetAllSeguimiento_Rubro();

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
        public IHttpActionResult GetAllSeguimiento_RubroByPartida(int id_partida)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_RubroRepository.GetAllSeguimiento_RubroByPartida(id_partida);

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
        public IHttpActionResult GetSeguimiento_RubroDetails(int id_rubro)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_RubroRepository.GetSeguimiento_RubroDetails(id_rubro);

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
        public IHttpActionResult GetSeguimiento_RubroCodigo(string cd_codigointernorubro)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_RubroRepository.GetSeguimiento_RubroCodigo(cd_codigointernorubro);

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
        public IHttpActionResult InsertSeguimiento_Rubro([FromBody] Seguimiento_Rubro seguimiento_Rubro)
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

                var created = _seguimiento_RubroRepository.InsertSeguimiento_Rubro(seguimiento_Rubro);

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
        public IHttpActionResult UpdateSeguimiento_Rubro([FromBody] Seguimiento_Rubro seguimiento_Rubro)
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

                var created = _seguimiento_RubroRepository.UpdateSeguimiento_Rubro(seguimiento_Rubro);

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
        public IHttpActionResult DeleteSeguimiento_Rubro(int id_rubro)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _seguimiento_RubroRepository.DeleteSeguimiento_Rubro(id_rubro);

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
