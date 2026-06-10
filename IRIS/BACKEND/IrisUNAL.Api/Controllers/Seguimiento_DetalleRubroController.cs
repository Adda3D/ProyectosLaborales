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
    public class Seguimiento_DetalleRubroController : BaseController<Seguimiento_DetalleRubro>
    {
        private readonly ISeguimiento_DetalleRubroRepository _seguimiento_DetalleRubroRepository;

        public Seguimiento_DetalleRubroController(ISeguimiento_DetalleRubroRepository seguimiento_DetalleRubroRepository)
        {
            _seguimiento_DetalleRubroRepository = seguimiento_DetalleRubroRepository;
        }

        readonly ISeguimiento_DetalleRubroRepository seguimiento_DetalleRubroRepository = new Seguimiento_DetalleRubroRepository();
        public Seguimiento_DetalleRubroController()
        {
            _seguimiento_DetalleRubroRepository = seguimiento_DetalleRubroRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllSeguimiento_DetalleRubro()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_DetalleRubroRepository.GetAllSeguimiento_DetalleRubro();

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
        public IHttpActionResult GetSeguimiento_DetalleRubroDetails(int id_detallerubro)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_DetalleRubroRepository.GetSeguimiento_DetalleRubroDetails(id_detallerubro);

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
        public IHttpActionResult GetSeguimiento_DetalleRubroCodigo(string cd_codigointernorubro)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_DetalleRubroRepository.GetSeguimiento_DetalleRubroCodigo(cd_codigointernorubro);

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
        public IHttpActionResult InsertSeguimiento_DetalleRubro([FromBody] Seguimiento_DetalleRubro seguimiento_DetalleRubro)
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

                var created = _seguimiento_DetalleRubroRepository.InsertSeguimiento_DetalleRubro(seguimiento_DetalleRubro);

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
        public IHttpActionResult UpdateSeguimiento_DetalleRubro([FromBody] Seguimiento_DetalleRubro seguimiento_DetalleRubro)
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

                var created = _seguimiento_DetalleRubroRepository.UpdateSeguimiento_DetalleRubro(seguimiento_DetalleRubro);

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
        public IHttpActionResult DeleteSeguimiento_DetalleRubro(int id_detallerubro)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _seguimiento_DetalleRubroRepository.DeleteSeguimiento_DetalleRubro(id_detallerubro);

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
