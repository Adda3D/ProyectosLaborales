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
    public class DecVie_InventarioObsolescenciaConceptoController : BaseController<DecVie_InventarioObsolescenciaConcepto>
    {
        private readonly IDecVie_InventarioObsolescenciaConceptoRepository _decVie_InventarioObsolescenciaConceptoRepository;
        public DecVie_InventarioObsolescenciaConceptoController(IDecVie_InventarioObsolescenciaConceptoRepository decVie_InventarioObsolescenciaConceptoRepository)
        {
            _decVie_InventarioObsolescenciaConceptoRepository = decVie_InventarioObsolescenciaConceptoRepository;
        }
        readonly IDecVie_InventarioObsolescenciaConceptoRepository decVie_InventarioObsolescenciaConceptoRepository = new DecVie_InventarioObsolescenciaConceptoRepository();
        public DecVie_InventarioObsolescenciaConceptoController()
        {
            _decVie_InventarioObsolescenciaConceptoRepository = decVie_InventarioObsolescenciaConceptoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_InventarioObsolescenciaConcepto()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioObsolescenciaConceptoRepository.GetAllDecVie_InventarioObsolescenciaConcepto();

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
        public IHttpActionResult GetDecVie_InventarioObsolescenciaConceptoDetails(int id_obsolescenciaconcepto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioObsolescenciaConceptoRepository.GetDecVie_InventarioObsolescenciaConceptoDetails(id_obsolescenciaconcepto);

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
        public IHttpActionResult GetDecVie_InventarioObsolescenciaConceptoNombre(string cd_nmconcepto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioObsolescenciaConceptoRepository.GetDecVie_InventarioObsolescenciaConceptoNombre(cd_nmconcepto);

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
        public IHttpActionResult InsertDecVie_InventarioObsolescenciaConcepto([FromBody] DecVie_InventarioObsolescenciaConcepto decVie_InventarioObsolescenciaConcepto)
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

                var created = decVie_InventarioObsolescenciaConceptoRepository.InsertDecVie_InventarioObsolescenciaConcepto(decVie_InventarioObsolescenciaConcepto);

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
        public IHttpActionResult UpdateDecVie_InventarioObsolescenciaConcepto([FromBody] DecVie_InventarioObsolescenciaConcepto decVie_InventarioObsolescenciaConcepto)
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

                var created = decVie_InventarioObsolescenciaConceptoRepository.UpdateDecVie_InventarioObsolescenciaConcepto(decVie_InventarioObsolescenciaConcepto);

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
        public IHttpActionResult DeleteDecVie_InventarioObsolescenciaConcepto(int id_obsolescenciaconcepto)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_InventarioObsolescenciaConceptoRepository.DeleteDecVie_InventarioObsolescenciaConcepto(id_obsolescenciaconcepto);

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
        public IHttpActionResult GetDataTableDecVie_InventarioObsolescenciaConcepto()
        {
            DataTableAdapter<DecVie_InventarioObsolescenciaConcepto> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_InventarioObsolescenciaConceptoRepository.GetDataTableDecVie_InventarioObsolescenciaConcepto(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
