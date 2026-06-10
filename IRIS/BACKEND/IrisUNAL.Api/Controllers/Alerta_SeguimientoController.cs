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
    public class Alerta_SeguimientoController : BaseController<Alerta_Seguimiento>
    {
        private readonly Alerta_SeguimientoRepository _alerta_seguimientoRepository;
        public Alerta_SeguimientoController(Alerta_SeguimientoRepository alerta_seguimientoRepository)
        {
            _alerta_seguimientoRepository = alerta_seguimientoRepository;
        }
        readonly Alerta_SeguimientoRepository alerta_seguimientoRepository = new Alerta_SeguimientoRepository();
        public Alerta_SeguimientoController()
        {
            _alerta_seguimientoRepository = alerta_seguimientoRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAlerta_SeguimientoDetails(int idalertaseguimiento)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _alerta_seguimientoRepository.GetAlerta_SeguimientoDetails(idalertaseguimiento);

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
        public IHttpActionResult InsertAlerta_Seguimiento([FromBody] Alerta_Seguimiento alerta_seguimiento)
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

                var created = _alerta_seguimientoRepository.InsertAlerta_Seguimiento(alerta_seguimiento);

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
        public IHttpActionResult UpdateAlerta_Seguimiento([FromBody] Alerta_Seguimiento alerta_seguimiento)
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

                var created = _alerta_seguimientoRepository.UpdateAlerta_Seguimiento(alerta_seguimiento);

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
        public IHttpActionResult DeleteAlerta_Seguimiento(int idalertaseguimiento)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _alerta_seguimientoRepository.DeleteAlerta_Seguimiento(idalertaseguimiento);

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
        public IHttpActionResult GetDataTableAlerta_SeguimientoByFuncionarioEstado(string usuario, string estado)
        {
            DataTableAdapter<Alerta_Seguimiento> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _alerta_seguimientoRepository.GetDataTableAlerta_SeguimientoByUsuarioEstado(usuario, estado, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }

        [HttpGet]
        public IHttpActionResult GetAlerta_SeguimientoByUsuarioEstado(string usuario, string estado)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _alerta_seguimientoRepository.GetAlerta_SeguimientoByUsuarioEstado(usuario, estado);

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
        public IHttpActionResult UpdateAlerta_SeguimientoCerrar(int idalertaseguimiento)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _alerta_seguimientoRepository.UpdateAlerta_SeguimientoCerrar(idalertaseguimiento);

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
