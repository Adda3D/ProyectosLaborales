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
    public class DecVie_InventarioConocimientoTipologiaController : BaseController<DecVie_InventarioConocimientoTipologia>
    {
        private readonly IDecVie_InventarioConocimientoTipologiaRepository _decVie_InventarioConocimientoTipologiaRepository;
        public DecVie_InventarioConocimientoTipologiaController(IDecVie_InventarioConocimientoTipologiaRepository decVie_InventarioConocimientoTipologiaRepository)
        {
            _decVie_InventarioConocimientoTipologiaRepository = decVie_InventarioConocimientoTipologiaRepository;
        }
        readonly IDecVie_InventarioConocimientoTipologiaRepository decVie_InventarioConocimientoTipologiaRepository = new DecVie_InventarioConocimientoTipologiaRepository();
        public DecVie_InventarioConocimientoTipologiaController()
        {
            _decVie_InventarioConocimientoTipologiaRepository = decVie_InventarioConocimientoTipologiaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_InventarioConocimientoTipologia()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioConocimientoTipologiaRepository.GetAllDecVie_InventarioConocimientoTipologia();

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
        public IHttpActionResult GetDecVie_InventarioConocimientoTipologiaDetails(int id_conocimientotipologia)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioConocimientoTipologiaRepository.GetDecVie_InventarioConocimientoTipologiaDetails(id_conocimientotipologia);

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
        public IHttpActionResult GetDecVie_InventarioConocimientoTipologiaNombre(string cd_nmtipologia)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioConocimientoTipologiaRepository.GetDecVie_InventarioConocimientoTipologiaNombre(cd_nmtipologia);

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
        public IHttpActionResult InsertDecVie_InventarioConocimientoTipologia([FromBody] DecVie_InventarioConocimientoTipologia decVie_InventarioConocimientoTipologia)
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

                var created = decVie_InventarioConocimientoTipologiaRepository.insertDecVie_InventarioConocimientoTipologia(decVie_InventarioConocimientoTipologia);

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
        public IHttpActionResult UpdateDecVie_InventarioConocimientoTipologia([FromBody] DecVie_InventarioConocimientoTipologia decVie_InventarioConocimientoTipologia)
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

                var created = decVie_InventarioConocimientoTipologiaRepository.UpdateDecVie_InventarioConocimientoTipologia(decVie_InventarioConocimientoTipologia);

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
        public IHttpActionResult DeleteDecVie_InventarioConocimientoTipologia(int id_conocimientotipologia)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_InventarioConocimientoTipologiaRepository.DeleteDecVie_InventarioConocimientoTipologia(id_conocimientotipologia);

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
        public IHttpActionResult GetDataTableDecVie_InventarioConocimientoTipologia()
        {
            DataTableAdapter<DecVie_InventarioConocimientoTipologia> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_InventarioConocimientoTipologiaRepository.GetDataTableDecVie_InventarioConocimientoTipologia(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
