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
    public class Propuesta_CoberturaController : BaseController<Propuesta_Cobertura>
    {
        private readonly IPropuesta_CoberturaRepository _propuesta_CoberturaRepository;

        public Propuesta_CoberturaController(IPropuesta_CoberturaRepository propuesta_CoberturaRepository)
        {
            _propuesta_CoberturaRepository = propuesta_CoberturaRepository;
        }

        readonly IPropuesta_CoberturaRepository propuesta_CoberturaRepository = new Propuesta_CoberturaRepository();
        public Propuesta_CoberturaController()
        {
            _propuesta_CoberturaRepository = propuesta_CoberturaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPropuesta_Cobertura()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_CoberturaRepository.GetAllPropuesta_Cobertura();

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
        public IHttpActionResult GetPropuesta_CoberturaDetails(int id_cobertura)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_CoberturaRepository.GetPropuesta_CoberturaDetails(id_cobertura);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Tipo cobertura inexistente";
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
        public IHttpActionResult GetPropuesta_CoberturaDetails(string cd_nmcobertura)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_CoberturaRepository.GetPropuesta_CoberturaDetails(cd_nmcobertura);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Tipo cobertura inexistente";
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
        public IHttpActionResult InsertPropuesta_Cobertura([FromBody] Propuesta_Cobertura propuesta_Cobertura)
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

                var created = _propuesta_CoberturaRepository.InsertPropuesta_Cobertura(propuesta_Cobertura);

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
        public IHttpActionResult UpdatePropuesta_Cobertura([FromBody] Propuesta_Cobertura propuesta_Cobertura)
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

                var created = _propuesta_CoberturaRepository.UpdatePropuesta_Cobertura(propuesta_Cobertura);

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
        public IHttpActionResult DeletePropuesta_Cobertura(int id_cobertura)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _propuesta_CoberturaRepository.DeletePropuesta_Cobertura(id_cobertura);

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
        public IHttpActionResult GetDataTablePropuestaCobertura()
        {
            DataTableAdapter<Propuesta_Cobertura> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _propuesta_CoberturaRepository.GetDataTablePropuestaCobertura(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
