using IrisUNAL.Api.Entities.Repositories;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IrisUNAL.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Seguimiento_CrearGastoController : BaseController<Seguimiento_CrearGasto>
    {
        private readonly ISeguimiento_CrearGastoRepository _seguimiento_CrearGastoRepository;

        public Seguimiento_CrearGastoController(ISeguimiento_CrearGastoRepository seguimiento_CrearGastoRepository)
        {
            _seguimiento_CrearGastoRepository = seguimiento_CrearGastoRepository;
        }

        readonly ISeguimiento_CrearGastoRepository seguimiento_CrearGastoRepository = new Seguimiento_CrearGastoRepository();
        public Seguimiento_CrearGastoController()
        {
            _seguimiento_CrearGastoRepository = seguimiento_CrearGastoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllSeguimiento_CrearGasto()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_CrearGastoRepository.GetAllSeguimiento_CrearGasto();

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
        public IHttpActionResult GetSeguimiento_CrearGastoDetails(int id_creargasto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_CrearGastoRepository.GetSeguimiento_CrearGastoDetails(id_creargasto);

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
        public IHttpActionResult GetSeguimiento_CrearGastoRelaciones(int id_creargasto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_CrearGastoRepository.GetSeguimiento_CrearGastoRelaciones(id_creargasto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Gasto no existente";
                }

                resultdb.Data = data;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }

        [HttpPost]
        public IHttpActionResult InsertSeguimiento_CrearGasto([FromBody] Seguimiento_CrearGasto seguimiento_CrearGasto)
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

                var created = _seguimiento_CrearGastoRepository.InsertSeguimiento_CrearGasto(seguimiento_CrearGasto);

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
        public IHttpActionResult UpdateSeguimiento_CrearGasto([FromBody] Seguimiento_CrearGasto seguimiento_CrearGasto)
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

                var created = _seguimiento_CrearGastoRepository.UpdateSeguimiento_CrearGasto(seguimiento_CrearGasto);

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
        public IHttpActionResult DeleteSeguimiento_CrearGasto(int id_creargasto)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _seguimiento_CrearGastoRepository.DeleteSeguimiento_CrearGasto(id_creargasto);

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
        public IHttpActionResult GetDataTableProyectoGastosByProyecto(int id_asignacionproyecto, int id_partida)
        {
            DataTableAdapter<Seguimiento_CrearGasto> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _seguimiento_CrearGastoRepository.GetDataTableProyectoGastosByProyecto(id_asignacionproyecto, id_partida, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }
    }
}
