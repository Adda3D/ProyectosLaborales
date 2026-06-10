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
    public class DecVie_InventarioConocimientoEnfasisController : BaseController<DecVie_InventarioConocimientoEnfasis>
    {
        private readonly IDecVie_InventarioConocimientoEnfasisRepository _decVie_InventarioConocimientoEnfasisRepository;
        public DecVie_InventarioConocimientoEnfasisController(IDecVie_InventarioConocimientoEnfasisRepository decVie_InventarioConocimientoEnfasisRepository)
        {
            _decVie_InventarioConocimientoEnfasisRepository = decVie_InventarioConocimientoEnfasisRepository;
        }
        readonly IDecVie_InventarioConocimientoEnfasisRepository decVie_InventarioConocimientoEnfasisRepository = new DecVie_InventarioConocimientoEnfasisRepository();
        public DecVie_InventarioConocimientoEnfasisController()
        {
            _decVie_InventarioConocimientoEnfasisRepository = decVie_InventarioConocimientoEnfasisRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_InventarioConocimientoEnfasis()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioConocimientoEnfasisRepository.GetAllDecVie_InventarioConocimientoEnfasis();

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
        public IHttpActionResult GetDecVie_InventarioConocimientoEnfasisDetails(int id_conocimientoenfasis)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioConocimientoEnfasisRepository.GetDecVie_InventarioConocimientoEnfasisDetails(id_conocimientoenfasis);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_InventarioConocimientoEnfasis inexistente";
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
        public IHttpActionResult GetDecVie_InventarioConocimientoEnfasisNombre(string cd_nmenfasis)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioConocimientoEnfasisRepository.GetDecVie_InventarioConocimientoEnfasisNombre(cd_nmenfasis);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_InventarioConocimientoEnfasis inexistente";
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
        public IHttpActionResult InsertDecVie_InventarioConocimientoEnfasis([FromBody] DecVie_InventarioConocimientoEnfasis decVie_InventarioConocimientoEnfasis)
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

                var created = decVie_InventarioConocimientoEnfasisRepository.InsertDecVie_InventarioConocimientoEnfasis(decVie_InventarioConocimientoEnfasis);

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
        public IHttpActionResult UpdateDecVie_InventarioConocimientoEnfasis([FromBody] DecVie_InventarioConocimientoEnfasis decVie_InventarioConocimientoEnfasis)
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

                var created = decVie_InventarioConocimientoEnfasisRepository.UpdateDecVie_InventarioConocimientoEnfasis(decVie_InventarioConocimientoEnfasis);

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
        public IHttpActionResult DeleteDecVie_InventarioConocimientoEnfasis(int id_conocimientoenfasis)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_InventarioConocimientoEnfasisRepository.DeleteDecVie_InventarioConocimientoEnfasis(id_conocimientoenfasis);

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
        public IHttpActionResult GetDataTableDecVie_InventarioConocimientoEnfasis()
        {
            DataTableAdapter<DecVie_InventarioConocimientoEnfasis> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_InventarioConocimientoEnfasisRepository.GetDataTableDecVie_InventarioConocimientoEnfasis(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
