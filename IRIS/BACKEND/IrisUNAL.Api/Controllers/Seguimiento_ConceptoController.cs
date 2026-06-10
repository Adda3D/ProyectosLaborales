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
    public class Seguimiento_ConceptoController : BaseController<Seguimiento_Concepto>
    {
        private readonly ISeguimiento_ConceptoRepository _seguimiento_ConceptoRepository;

        public Seguimiento_ConceptoController(ISeguimiento_ConceptoRepository seguimiento_ConceptoRepository)
        {
            _seguimiento_ConceptoRepository = seguimiento_ConceptoRepository;
        }

        readonly ISeguimiento_ConceptoRepository seguimiento_ConceptoRepository = new Seguimiento_ConceptoRepository();
        public Seguimiento_ConceptoController()
        {
            _seguimiento_ConceptoRepository = seguimiento_ConceptoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllSeguimiento_Concepto()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_ConceptoRepository.GetAllSeguimiento_Concepto();

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
        public IHttpActionResult GetSeguimiento_ConceptoByRubro(int id_rubro)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_ConceptoRepository.GetSeguimiento_ConceptoByRubro(id_rubro);

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
        public IHttpActionResult GetSeguimiento_ConceptoDetails(int id_concepto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_ConceptoRepository.GetSeguimiento_ConceptoDetails(id_concepto);

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
        public IHttpActionResult GetSeguimiento_ConceptoCodigo(string cd_codigointernoconcepto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_ConceptoRepository.GetSeguimiento_ConceptoCodigo(cd_codigointernoconcepto);

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
        public IHttpActionResult InsertSeguimiento_Concepto([FromBody] Seguimiento_Concepto seguimiento_Concepto)
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

                var created = _seguimiento_ConceptoRepository.InsertSeguimiento_Concepto(seguimiento_Concepto);

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
        public IHttpActionResult UpdateSeguimiento_Concepto([FromBody] Seguimiento_Concepto seguimiento_Concepto)
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

                var created = _seguimiento_ConceptoRepository.UpdateSeguimiento_Concepto(seguimiento_Concepto);

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
        public IHttpActionResult DeleteSeguimiento_Concepto(int id_concepto)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _seguimiento_ConceptoRepository.DeleteSeguimiento_Concepto(id_concepto);

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
        public IHttpActionResult GetDataTableSeguimiento_Concepto()
        {
            DataTableAdapter<Seguimiento_Concepto> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _seguimiento_ConceptoRepository.GetDataTableSeguimiento_Concepto(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
