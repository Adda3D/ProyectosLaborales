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
    public class DecVie_InventarioConocimientoImpactoController : BaseController<DecVie_InventarioConocimientoImpacto>
    {
        private readonly IDecVie_InventarioConocimientoImpactoRepository _decVie_InventarioConocimientoImpactoRepository;
        public DecVie_InventarioConocimientoImpactoController(IDecVie_InventarioConocimientoImpactoRepository decVie_InventarioConocimientoImpactoRepository)
        {
            _decVie_InventarioConocimientoImpactoRepository = decVie_InventarioConocimientoImpactoRepository;
        }
        readonly IDecVie_InventarioConocimientoImpactoRepository decVie_InventarioConocimientoImpactoRepository = new DecVie_InventarioConocimientoImpactoRepository();
        public DecVie_InventarioConocimientoImpactoController()
        {
            _decVie_InventarioConocimientoImpactoRepository = decVie_InventarioConocimientoImpactoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_InventarioConocimientoImpacto()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioConocimientoImpactoRepository.GetAllDecVie_InventarioConocimientoImpacto();

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
        public IHttpActionResult GetDecVie_InventarioConocimientoImpactoDetails(int id_conocimientoimpacto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioConocimientoImpactoRepository.GetDecVie_InventarioConocimientoImpactoDetails(id_conocimientoimpacto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_InventarioConocimientoImpacto inexistente";
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
        public IHttpActionResult GetDecVie_InventarioConocimientoImpactoNombre(string cd_nmimpacto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioConocimientoImpactoRepository.GetDecVie_InventarioConocimientoImpactoNombre(cd_nmimpacto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_InventarioConocimientoImpacto inexistente";
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
        public IHttpActionResult InsertDecVie_InventarioConocimientoImpacto([FromBody] DecVie_InventarioConocimientoImpacto decVie_InventarioConocimientoImpacto)
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

                var created = decVie_InventarioConocimientoImpactoRepository.InsertDecVie_InventarioConocimientoImpacto(decVie_InventarioConocimientoImpacto);

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
        public IHttpActionResult UpdateDecVie_InventarioConocimientoImpacto([FromBody] DecVie_InventarioConocimientoImpacto decVie_InventarioConocimientoImpacto)
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

                var created = decVie_InventarioConocimientoImpactoRepository.UpdateDecVie_InventarioConocimientoImpacto(decVie_InventarioConocimientoImpacto);

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
        public IHttpActionResult DeleteDecVie_InventarioConocimientoImpacto(int id_conocimientoimpacto)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_InventarioConocimientoImpactoRepository.DeleteDecVie_InventarioConocimientoImpacto(id_conocimientoimpacto);

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
        public IHttpActionResult GetDataTableDecVie_InventarioConocimientoImpacto()
        {
            DataTableAdapter<DecVie_InventarioConocimientoImpacto> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_InventarioConocimientoImpactoRepository.GetDataTableDecVie_InventarioConocimientoImpacto(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
