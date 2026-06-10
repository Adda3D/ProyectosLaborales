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
    public class DecVie_InventarioConocimientoContratanteController : BaseController<DecVie_InventarioConocimientoContratante>
    {
        private readonly IDecVie_InventarioConocimientoContratanteRepository _decVie_InventarioConocimientoContratanteRepository;
        public DecVie_InventarioConocimientoContratanteController(IDecVie_InventarioConocimientoContratanteRepository decVie_InventarioConocimientoContratanteRepository)
        {
            _decVie_InventarioConocimientoContratanteRepository = decVie_InventarioConocimientoContratanteRepository;
        }
        readonly IDecVie_InventarioConocimientoContratanteRepository decVie_InventarioConocimientoContratanteRepository = new DecVie_InventarioConocimientoContratanteRepository();
        public DecVie_InventarioConocimientoContratanteController()
        {
            _decVie_InventarioConocimientoContratanteRepository = decVie_InventarioConocimientoContratanteRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_InventarioConocimientoContratante()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioConocimientoContratanteRepository.GetAllDecVie_InventarioConocimientoContratante();

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
        public IHttpActionResult GetDecVie_InventarioConocimientoContratanteDetails(int id_conocimientocontratante)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioConocimientoContratanteRepository.GetDecVie_InventarioConocimientoContratanteDetails(id_conocimientocontratante);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_InventarioConocimientoContratante inexistente";
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
        public IHttpActionResult GetDecVie_InventarioConocimientoContratanteNombre(string cd_nmcontratante)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioConocimientoContratanteRepository.GetDecVie_InventarioConocimientoContratanteNombre(cd_nmcontratante);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_InventarioConocimientoContratante inexistente";
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
        public IHttpActionResult InsertDecVie_InventarioConocimientoContratante([FromBody] DecVie_InventarioConocimientoContratante decVie_InventarioConocimientoContratante)
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

                var created = decVie_InventarioConocimientoContratanteRepository.InsertDecVie_InventarioConocimientoContratante(decVie_InventarioConocimientoContratante);

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
        public IHttpActionResult UpdateDecVie_InventarioConocimientoContratante([FromBody] DecVie_InventarioConocimientoContratante decVie_InventarioConocimientoContratante)
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

                var created = decVie_InventarioConocimientoContratanteRepository.UpdateDecVie_InventarioConocimientoContratante(decVie_InventarioConocimientoContratante);

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
        public IHttpActionResult DeleteDecVie_InventarioConocimientoContratante(int id_conocimientocontratante)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_InventarioConocimientoContratanteRepository.DeleteDecVie_InventarioConocimientoContratante(id_conocimientocontratante);

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
        public IHttpActionResult GetDataTableDecVie_InventarioConocimientoContratante()
        {
            DataTableAdapter<DecVie_InventarioConocimientoContratante> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_InventarioConocimientoContratanteRepository.GetDataTableDecVie_InventarioConocimientoContratante(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
