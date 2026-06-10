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
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class DecVie_InventarioGestionConocimientoController : BaseController<DecVie_InventarioGestionConocimiento>
    {
        private readonly IDecVie_InventarioGestionConocimientoRepository _decVie_InventarioGestionConocimientoRepository;
        public DecVie_InventarioGestionConocimientoController(IDecVie_InventarioGestionConocimientoRepository decVie_InventarioGestionConocimientoRepository)
        {
            _decVie_InventarioGestionConocimientoRepository = decVie_InventarioGestionConocimientoRepository;
        }
        readonly IDecVie_InventarioGestionConocimientoRepository decVie_InventarioGestionConocimientoRepository = new DecVie_InventarioGestionConocimientoRepository();
        public DecVie_InventarioGestionConocimientoController()
        {
            _decVie_InventarioGestionConocimientoRepository = decVie_InventarioGestionConocimientoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_InventarioGestionConocimiento()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioGestionConocimientoRepository.GetAllDecVie_InventarioGestionConocimiento();

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
        public IHttpActionResult GetDecVie_InventarioGestionConocimientoDetails(int id_invgesconocimiento)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioGestionConocimientoRepository.GetDecVie_InventarioGestionConocimientoDetails(id_invgesconocimiento);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Inventario Gestión inexistente";
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
        public IHttpActionResult InsertDecVie_InventarioGestionConocimiento([FromBody] DecVie_InventarioGestionConocimiento decVie_InventarioGestionConocimiento)
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

                var created = decVie_InventarioGestionConocimientoRepository.InsertDecVie_InventarioGestionConocimiento(decVie_InventarioGestionConocimiento);

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
        public IHttpActionResult UpdateDecVie_InventarioGestionConocimiento([FromBody] DecVie_InventarioGestionConocimiento decVie_InventarioGestionConocimiento)
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

                var created = decVie_InventarioGestionConocimientoRepository.UpdateDecVie_InventarioGestionConocimiento(decVie_InventarioGestionConocimiento);

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
        public IHttpActionResult DeleteDecVie_InventarioGestionConocimiento(int id_invgesconocimiento)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_InventarioGestionConocimientoRepository.DeleteDecVie_InventarioGestionConocimiento(id_invgesconocimiento);

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
        public IHttpActionResult GetDataTableDecVie_InventarioGestionConocimiento()
        {
            DataTableAdapter<DecVie_InventarioGestionConocimiento> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_InventarioGestionConocimientoRepository.GetDataTableDecVie_InventarioGestionConocimiento(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

        [HttpGet]

        public IHttpActionResult ExcelDecVie_InventarioGestionConocimiento(int id_invgesconocimiento)
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = decVie_InventarioGestionConocimientoRepository.ExcelDecVie_InventarioGestionConocimiento(id_invgesconocimiento);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (archivoresultado == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Error creando Archivo Excel";
                }

                resultdb.Data = archivoresultado;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }

        }
    }
}
