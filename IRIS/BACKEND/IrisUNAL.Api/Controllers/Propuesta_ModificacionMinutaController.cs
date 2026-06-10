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
    public class Propuesta_ModificacionMinutaController : BaseController<Propuesta_ModificacionMinuta>
    {
        private readonly IPropuesta_ModificacionMinutaRepository _propuesta_ModificacionMinutaRepository;

        public Propuesta_ModificacionMinutaController(IPropuesta_ModificacionMinutaRepository propuesta_ModificacionMinutaRepository)
        {
            _propuesta_ModificacionMinutaRepository = propuesta_ModificacionMinutaRepository;
        }

        readonly IPropuesta_ModificacionMinutaRepository propuesta_ModificacionMinutaRepository = new Propuesta_ModificacionMinutaRepository();
        public Propuesta_ModificacionMinutaController()
        {
            _propuesta_ModificacionMinutaRepository = propuesta_ModificacionMinutaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPropuesta_ModificacionMinuta()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_ModificacionMinutaRepository.GetAllPropuesta_ModificacionMinuta();

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
        public IHttpActionResult GetPropuesta_ModificacionMinutaDetails(int id_modificacionminuta)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_ModificacionMinutaRepository.GetPropuesta_ModificacionMinutaDetails(id_modificacionminuta);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Modificación Minuta inexistente";
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
        public IHttpActionResult GetPropuesta_ModificacionMinutaCodigo(string consecutivoremisiondecanatura)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_ModificacionMinutaRepository.GetPropuesta_ModificacionMinutaCodigo(consecutivoremisiondecanatura);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Modificación Minuta inexistente";
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
        public IHttpActionResult InsertPropuesta_ModificacionMinuta([FromBody] Propuesta_ModificacionMinuta propuesta_ModificacionMinuta)
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

                var created = _propuesta_ModificacionMinutaRepository.InsertPropuesta_ModificacionMinuta(propuesta_ModificacionMinuta);

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
        public IHttpActionResult UpdatePropuesta_ModificacionMinuta([FromBody] Propuesta_ModificacionMinuta propuesta_ModificacionMinuta)
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

                var created = _propuesta_ModificacionMinutaRepository.UpdatePropuesta_ModificacionMinuta(propuesta_ModificacionMinuta);

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
        public IHttpActionResult DeletePropuesta_ModificacionMinuta(int id_modificacionminuta)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _propuesta_ModificacionMinutaRepository.DeletePropuesta_ModificacionMinuta(id_modificacionminuta);

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
        public IHttpActionResult GetDataTablePropuestaModificacionMinutaByPropuesta(int id_propuesta)
        {
            DataTableAdapter<Propuesta_ModificacionMinuta> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _propuesta_ModificacionMinutaRepository.GetDataTablePropuestaModificacionMinutaByPropuesta(id_propuesta, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }


    }
}
