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
    public class PropuestaSeguimientoController : BaseController<Propuestaseguimiento>
    {
        private readonly PropuestaSeguimientoRepository _propuestaseguimientoRepository;

        public PropuestaSeguimientoController(PropuestaSeguimientoRepository propuestaseguimientoRepository)
        {
            _propuestaseguimientoRepository = propuestaseguimientoRepository;
        }

        readonly PropuestaSeguimientoRepository funcionarioRepository = new PropuestaSeguimientoRepository();
        public PropuestaSeguimientoController()
        {
            _propuestaseguimientoRepository = funcionarioRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPropuestaSeguimiento()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuestaseguimientoRepository.GetAllPropuestaSeguimiento();

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
        public IHttpActionResult GetPropuestaSeguimientoDetails(int idseguimiento)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuestaseguimientoRepository.GetPropuestaSeguimientoDetails(idseguimiento);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Detalle seguimiento inexistente";
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
        public IHttpActionResult InsertPropuestaSeguimiento([FromBody] Propuestaseguimiento propuestaseguimiento)
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

                var created = _propuestaseguimientoRepository.InsertPropuestaSeguimiento(propuestaseguimiento);

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
        public IHttpActionResult UpdatePropuestaSeguimiento([FromBody] Propuestaseguimiento propuestaseguimiento)
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

                var created = _propuestaseguimientoRepository.UpdatePropuestaSeguimiento(propuestaseguimiento);

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
        public IHttpActionResult DeletePropuestaSeguimiento(int idseguimiento)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _propuestaseguimientoRepository.DeletePropuestaSeguimiento(idseguimiento);

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
        public IHttpActionResult GetDataTablePropuestaSeguimiento()
        {
            DataTableAdapter<Propuestaseguimiento> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _propuestaseguimientoRepository.GetDataTablePropuestaSeguimiento(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetDataTablePropuestaSeguimientoByPropuesta(int id_propuesta)
        {
            DataTableAdapter<Propuestaseguimiento> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _propuestaseguimientoRepository.GetDataTablePropuestaSeguimientoByPropuesta(id_propuesta, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

    }
}
