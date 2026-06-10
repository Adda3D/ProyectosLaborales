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
    public class DecVie_InventarioConocimientoSoporteController : BaseController<DecVie_InventarioConocimientoSoporte>
    {
        private readonly IDecVie_InventarioConocimientoSoporteRepository _decVie_InventarioConocimientoSoporteRepository;
        public DecVie_InventarioConocimientoSoporteController(IDecVie_InventarioConocimientoSoporteRepository decVie_InventarioConocimientoSoporteRepository)
        {
            _decVie_InventarioConocimientoSoporteRepository = decVie_InventarioConocimientoSoporteRepository;
        }
        readonly IDecVie_InventarioConocimientoSoporteRepository decVie_InventarioConocimientoSoporteRepository = new DecVie_InventarioConocimientoSoporteRepository();
        public DecVie_InventarioConocimientoSoporteController()
        {
            _decVie_InventarioConocimientoSoporteRepository = decVie_InventarioConocimientoSoporteRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_InventarioConocimientoSoporte()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioConocimientoSoporteRepository.GetAllDecVie_InventarioConocimientoSoporte();

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
        public IHttpActionResult GetDecVie_InventarioConocimientoSoporteDetails(int id_conocimientosoporte)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioConocimientoSoporteRepository.GetDecVie_InventarioConocimientoSoporteDetails(id_conocimientosoporte);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_Macroproceso inexistente";
                }

                resultdb.Data = data;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetDecVie_InventarioConocimientoSoporteNombre(string cd_nmsoporte)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioConocimientoSoporteRepository.GetDecVie_InventarioConocimientoSoporteNombre(cd_nmsoporte);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_Macroproceso inexistente";
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
        public IHttpActionResult InsertDecVie_InventarioConocimientoSoporte([FromBody] DecVie_InventarioConocimientoSoporte decVie_InventarioConocimientoSoporte)
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

                var created = decVie_InventarioConocimientoSoporteRepository.InsertDecVie_InventarioConocimientoSoporte(decVie_InventarioConocimientoSoporte);

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
        public IHttpActionResult UpdateDecVie_InventarioConocimientoSoporte([FromBody] DecVie_InventarioConocimientoSoporte decVie_InventarioConocimientoSoporte)
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

                var created = decVie_InventarioConocimientoSoporteRepository.UpdateDecVie_InventarioConocimientoSoporte(decVie_InventarioConocimientoSoporte);

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
        public IHttpActionResult DeleteDecVie_InventarioConocimientoSoporte(int id_conocimientosoporte)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_InventarioConocimientoSoporteRepository.DeleteDecVie_InventarioConocimientoSoporte(id_conocimientosoporte);

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
        public IHttpActionResult GetDataTableDecVie_InventarioConocimientoSoporte()
        {
            DataTableAdapter<DecVie_InventarioConocimientoSoporte> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_InventarioConocimientoSoporteRepository.GetDataTableDecVie_InventarioConocimientoSoporte(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
