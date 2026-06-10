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
    public class Propuesta_AvalConsejoFacultadController : BaseController<Propuesta_AvalConsejoFacultad>
    {
        private readonly IPropuesta_AvalConsejoFacultadRepository _propuesta_AvalConsejoFacultadRepository;

        public Propuesta_AvalConsejoFacultadController(IPropuesta_AvalConsejoFacultadRepository propuesta_AvalConsejoFacultadRepository)
        {
            _propuesta_AvalConsejoFacultadRepository = propuesta_AvalConsejoFacultadRepository;
        }

        readonly IPropuesta_AvalConsejoFacultadRepository propuesta_AvalConsejoFacultadRepository = new Propuesta_AvalConsejoFacultadRepository();
        public Propuesta_AvalConsejoFacultadController()
        {
            _propuesta_AvalConsejoFacultadRepository = propuesta_AvalConsejoFacultadRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPropuesta_AvalConsejoFacultad()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_AvalConsejoFacultadRepository.GetAllPropuesta_AvalConsejoFacultad();

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
        public IHttpActionResult GetPropuesta_AvalConsejoFacultadDetails(int id_avalconfac)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_AvalConsejoFacultadRepository.GetPropuesta_AvalConsejoFacultadDetails(id_avalconfac);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Aval consejo inexistente";
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
        public IHttpActionResult GetPropuesta_AvalConsejoFacultadDetails(string numeroaval)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_AvalConsejoFacultadRepository.GetPropuesta_AvalConsejoFacultadDetails(numeroaval);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Aval consejo inexistente";
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
        public IHttpActionResult InsertPropuesta_AvalConsejoFacultad([FromBody] Propuesta_AvalConsejoFacultad propuesta_AvalConsejoFacultad)
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

                var created = _propuesta_AvalConsejoFacultadRepository.InsertPropuesta_AvalConsejoFacultad(propuesta_AvalConsejoFacultad);

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
        public IHttpActionResult UpdatePropuesta_AvalConsejoFacultad([FromBody] Propuesta_AvalConsejoFacultad propuesta_AvalConsejoFacultad)
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

                var created = _propuesta_AvalConsejoFacultadRepository.UpdatePropuesta_AvalConsejoFacultad(propuesta_AvalConsejoFacultad);

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
        public IHttpActionResult DeletePropuesta_AvalConsejoFacultad(int id_avalconfac)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _propuesta_AvalConsejoFacultadRepository.DeletePropuesta_AvalConsejoFacultad(id_avalconfac);

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
        public IHttpActionResult GetDataTablePropuestaAvalConsejoFacultad()
        {
            DataTableAdapter<Propuesta_AvalConsejoFacultad> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _propuesta_AvalConsejoFacultadRepository.GetDataTablePropuestaAvalConsejoFacultad(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

    }
}
