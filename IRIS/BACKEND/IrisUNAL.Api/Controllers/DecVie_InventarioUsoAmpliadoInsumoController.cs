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
    public class DecVie_InventarioUsoAmpliadoInsumoController : BaseController<DecVie_InventarioUsoAmpliadoInsumo>
    {
        private readonly IDecVie_InventarioUsoAmpliadoInsumoRepository _decVie_InventarioUsoAmpliadoInsumoRepository;
        public DecVie_InventarioUsoAmpliadoInsumoController (IDecVie_InventarioUsoAmpliadoInsumoRepository decVie_InventarioUsoAmpliadoInsumoRepository)
        {
            _decVie_InventarioUsoAmpliadoInsumoRepository = decVie_InventarioUsoAmpliadoInsumoRepository;
        }
        readonly IDecVie_InventarioUsoAmpliadoInsumoRepository decVie_InventarioUsoAmpliadoInsumoRepository = new DecVie_InventarioUsoAmpliadoInsumoRepository();
        public DecVie_InventarioUsoAmpliadoInsumoController()
        {
            _decVie_InventarioUsoAmpliadoInsumoRepository = decVie_InventarioUsoAmpliadoInsumoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_InventarioUsoAmpliadoInsumo()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioUsoAmpliadoInsumoRepository.GetAllDecVie_InventarioUsoAmpliadoInsumo();

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
        public IHttpActionResult GetDecVie_InventarioUsoAmpliadoInsumoDetails(int id_insumo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioUsoAmpliadoInsumoRepository.GetDecVie_InventarioUsoAmpliadoInsumoDetails(id_insumo);

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
        public IHttpActionResult GetDecVie_InventarioUsoAmpliadoInsumoNombre(string cd_nminsumo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioUsoAmpliadoInsumoRepository.GetDecVie_InventarioUsoAmpliadoInsumoNombre(cd_nminsumo);

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
        public IHttpActionResult InsertDecVie_InventarioUsoAmpliadoInsumo([FromBody] DecVie_InventarioUsoAmpliadoInsumo decVie_InventarioUsoAmpliadoInsumo)
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

                var created = decVie_InventarioUsoAmpliadoInsumoRepository.InsertDecVie_InventarioUsoAmpliadoInsumo(decVie_InventarioUsoAmpliadoInsumo);

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
        public IHttpActionResult UpdateDecVie_InventarioUsoAmpliadoInsumo([FromBody] DecVie_InventarioUsoAmpliadoInsumo decVie_InventarioUsoAmpliadoInsumo)
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

                var created = decVie_InventarioUsoAmpliadoInsumoRepository.UpdateDecVie_InventarioUsoAmpliadoInsumo(decVie_InventarioUsoAmpliadoInsumo);

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
        public IHttpActionResult DeleteDecVie_InventarioUsoAmpliadoInsumo(int id_insumo)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_InventarioUsoAmpliadoInsumoRepository.DeleteDecVie_InventarioUsoAmpliadoInsumo(id_insumo);

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
        public IHttpActionResult GetDataTableDecVie_InventarioUsoAmpliadoInsumo()
        {
            DataTableAdapter<DecVie_InventarioUsoAmpliadoInsumo> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_InventarioUsoAmpliadoInsumoRepository.GetDataTableDecVie_InventarioUsoAmpliadoInsumo(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
