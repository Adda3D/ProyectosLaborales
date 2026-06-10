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
    public class Propuesta_ModalidadController : BaseController<Propuesta_Modalidad>
    {
        private readonly IPropuesta_ModalidadRepository _propuesta_ModalidadRepository;

        public Propuesta_ModalidadController(IPropuesta_ModalidadRepository propuesta_ModalidadRepository)
        {
            _propuesta_ModalidadRepository = propuesta_ModalidadRepository;
        }

        readonly IPropuesta_ModalidadRepository propuesta_ModalidadRepository = new Propuesta_ModalidadRepository();
        public Propuesta_ModalidadController()
        {
            _propuesta_ModalidadRepository = propuesta_ModalidadRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPropuesta_Modalidad()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_ModalidadRepository.GetAllPropuesta_Modalidad();

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
        public IHttpActionResult GetPropuesta_ModalidadDetails(int id_modalidad)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_ModalidadRepository.GetPropuesta_ModalidadDetails(id_modalidad);

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
        public IHttpActionResult GetPropuesta_ModalidadDetails(string cd_nmmodalidad)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_ModalidadRepository.GetPropuesta_ModalidadDetails(cd_nmmodalidad);

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
        public IHttpActionResult InsertPropuesta_Modalidad([FromBody] Propuesta_Modalidad propuesta_Modalidad)
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

                var created = _propuesta_ModalidadRepository.InsertPropuesta_Modalidad(propuesta_Modalidad);

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
        public IHttpActionResult UpdatePropuesta_Modalidad([FromBody] Propuesta_Modalidad propuesta_Modalidad)
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

                var created = _propuesta_ModalidadRepository.UpdatePropuesta_Modalidad(propuesta_Modalidad);

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
        public IHttpActionResult DeletePropuesta_Modalidad(int id_modalidad)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _propuesta_ModalidadRepository.DeletePropuesta_Modalidad(id_modalidad);

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
        public IHttpActionResult GetDataTablePropuestaModalidad()
        {
            DataTableAdapter<Propuesta_Modalidad> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _propuesta_ModalidadRepository.GetDataTablePropuestaModalidad(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

    }
}
