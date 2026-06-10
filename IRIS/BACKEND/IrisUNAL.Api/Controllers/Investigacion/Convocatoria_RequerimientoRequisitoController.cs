using IrisUNAL.Api.Entities.Repositories.Investigacion;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.Investigacion;
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

namespace IrisUNAL.Api.Controllers.Investigacion
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class Convocatoria_RequerimientoRequisitoController : BaseController<Convocatoria_RequerimientoRequisito>
    {
        private readonly Convocatoria_RequerimientoRequisitoRepository _convocatoria_RequerimientoRequisitoRepository;
        public Convocatoria_RequerimientoRequisitoController(Convocatoria_RequerimientoRequisitoRepository convocatoria_RequerimientoRequisitoRepository)
        {
            _convocatoria_RequerimientoRequisitoRepository = convocatoria_RequerimientoRequisitoRepository;
        }
        readonly Convocatoria_RequerimientoRequisitoRepository convocatoria_RequerimientoRequisitoRepository = new Convocatoria_RequerimientoRequisitoRepository();
        public Convocatoria_RequerimientoRequisitoController()
        {
            _convocatoria_RequerimientoRequisitoRepository = convocatoria_RequerimientoRequisitoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllConvocatoria_RequerimientoRequisito()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = convocatoria_RequerimientoRequisitoRepository.GetAllConvocatoria_RequerimientoRequisito();

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
        public IHttpActionResult GetConvocatoria_RequerimientoRequisitoDetails(int id_requisito)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = convocatoria_RequerimientoRequisitoRepository.GetConvocatoria_RequerimientoRequisitoDetails(id_requisito);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Requerimiento inexistente";
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
        public IHttpActionResult GetConvocatoria_RequerimientoRequisitoNombre(string cd_nmrequisito)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = convocatoria_RequerimientoRequisitoRepository.GetConvocatoria_RequerimientoRequisitoNombre(cd_nmrequisito);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Requerimiento inexistente";
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
        public IHttpActionResult InsertConvocatoria_RequerimientoRequisito([FromBody] Convocatoria_RequerimientoRequisito convocatoria_RequerimientoRequisito)
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

                var created = convocatoria_RequerimientoRequisitoRepository.InsertConvocatoria_RequerimientoRequisito(convocatoria_RequerimientoRequisito);

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
        public IHttpActionResult UpdateConvocatoria_RequerimientoRequisito([FromBody] Convocatoria_RequerimientoRequisito convocatoria_RequerimientoRequisito )
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

                var created = convocatoria_RequerimientoRequisitoRepository.UpdateConvocatoria_RequerimientoRequisito(convocatoria_RequerimientoRequisito);

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
        public IHttpActionResult DeleteConvocatoria_RequerimientoRequisito(int id_requisito)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = convocatoria_RequerimientoRequisitoRepository.DeleteConvocatoria_RequerimientoRequisito(id_requisito);

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
        public IHttpActionResult GetDataTableConvocatoria_RequerimientoRequisitoByConvocatoria(int id_convocatoria)
        {
            DataTableAdapter<Convocatoria_RequerimientoRequisito> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = convocatoria_RequerimientoRequisitoRepository.GetDataTableConvocatoria_RequerimientoRequisitoByConvocatoria(id_convocatoria, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
