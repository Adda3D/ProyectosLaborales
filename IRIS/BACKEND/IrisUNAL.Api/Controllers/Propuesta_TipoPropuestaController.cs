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
    public class Propuesta_TipoPropuestaController : BaseController<Propuesta_TipoPropuesta>
    {
        private readonly IPropuesta_TipoPropuestaRepository _propuesta_TipoPropuestaRepository;

        public Propuesta_TipoPropuestaController(IPropuesta_TipoPropuestaRepository propuesta_TipoPropuestaRepository)
        {
            _propuesta_TipoPropuestaRepository = propuesta_TipoPropuestaRepository;
        }

        readonly IPropuesta_TipoPropuestaRepository propuesta_TipoPropuestaRepository = new Propuesta_TipoPropuestaRepository();
        public Propuesta_TipoPropuestaController()
        {
            _propuesta_TipoPropuestaRepository = propuesta_TipoPropuestaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPropuesta_TipoPropuesta()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_TipoPropuestaRepository.GetAllPropuesta_TipoPropuesta();

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
        public IHttpActionResult GetPropuesta_TipoPropuestaDetails(int id_tipopropuesta)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_TipoPropuestaRepository.GetPropuesta_TipoPropuestaDetails(id_tipopropuesta);

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
        public IHttpActionResult GetPropuesta_TipoPropuestaDetails(string cd_nmtipopropuesta)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_TipoPropuestaRepository.GetPropuesta_TipoPropuestaDetails(cd_nmtipopropuesta);

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
        public IHttpActionResult InsertPropuesta_TipoPropuesta([FromBody] Propuesta_TipoPropuesta propuesta_TipoPropuesta)
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

                var created = _propuesta_TipoPropuestaRepository.InsertPropuesta_TipoPropuesta(propuesta_TipoPropuesta);

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
        public IHttpActionResult UpdatePropuesta_TipoPropuesta([FromBody] Propuesta_TipoPropuesta propuesta_TipoPropuesta)
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

                var created = _propuesta_TipoPropuestaRepository.UpdatePropuesta_TipoPropuesta(propuesta_TipoPropuesta);

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
        public IHttpActionResult DeletePropuesta_TipoPropuesta(int id_tipopropuesta)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _propuesta_TipoPropuestaRepository.DeletePropuesta_TipoPropuesta(id_tipopropuesta);

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
        public IHttpActionResult GetDataTableTipoPropuesta()
        {
            DataTableAdapter<Propuesta_TipoPropuesta> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _propuesta_TipoPropuestaRepository.GetDataTablePropuestaTipoPropuesta(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

    }
}
