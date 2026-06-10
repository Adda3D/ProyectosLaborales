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
    public class Propuesta_AprobacionConsejoFacultadController : BaseController<Propuesta_AprobacionConsejoFacultad>
    {
        private readonly IPropuesta_AprobacionConsejoFacultadRepository _propuesta_AprobacionConsejoFacultadRepository;

        public Propuesta_AprobacionConsejoFacultadController(IPropuesta_AprobacionConsejoFacultadRepository propuesta_AprobacionConsejoFacultadRepository)
        {
            _propuesta_AprobacionConsejoFacultadRepository = propuesta_AprobacionConsejoFacultadRepository;
        }

        readonly IPropuesta_AprobacionConsejoFacultadRepository propuesta_AprobacionConsejoFacultadRepository = new Propuesta_AprobacionConsejoFacultadRepository();
        public Propuesta_AprobacionConsejoFacultadController()
        {
            _propuesta_AprobacionConsejoFacultadRepository = propuesta_AprobacionConsejoFacultadRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPropuesta_AprobacionConsejoFacultad()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_AprobacionConsejoFacultadRepository.GetAllPropuesta_AprobacionConsejoFacultad();

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
        public IHttpActionResult GetPropuesta_AprobacionConsejoFacultadDetails(int id_aprobacionconsejofacultad)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_AprobacionConsejoFacultadRepository.GetPropuesta_AprobacionConsejoFacultadDetails(id_aprobacionconsejofacultad);

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
        public IHttpActionResult GetPropuesta_AprobacionConsejoFacultadDetails(string cd_nmaprconfac)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_AprobacionConsejoFacultadRepository.GetPropuesta_AprobacionConsejoFacultadDetails(cd_nmaprconfac);

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
        public IHttpActionResult InsertPropuesta_AprobacionConsejoFacultad([FromBody] Propuesta_AprobacionConsejoFacultad propuesta_AprobacionConsejoFacultad)
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

                var created = _propuesta_AprobacionConsejoFacultadRepository.InsertPropuesta_AprobacionConsejoFacultad(propuesta_AprobacionConsejoFacultad);

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
        public IHttpActionResult UpdatePropuesta_AprobacionConsejoFacultad([FromBody] Propuesta_AprobacionConsejoFacultad propuesta_AprobacionConsejoFacultad)
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

                var created = _propuesta_AprobacionConsejoFacultadRepository.UpdatePropuesta_AprobacionConsejoFacultad(propuesta_AprobacionConsejoFacultad);

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
        public IHttpActionResult DeletePropuesta_AprobacionConsejoFacultad(int id_aprobacionconsejofacultad)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _propuesta_AprobacionConsejoFacultadRepository.DeletePropuesta_AprobacionConsejoFacultad(id_aprobacionconsejofacultad);

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
        public IHttpActionResult GetDataTablePropuestaTipoAprobacion()
        {
            DataTableAdapter<Propuesta_AprobacionConsejoFacultad> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _propuesta_AprobacionConsejoFacultadRepository.GetDataTablePropuestaTipoAprobacion(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

    }
}
