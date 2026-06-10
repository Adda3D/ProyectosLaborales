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
    public class propuesta_entidadController : BaseController<Propuesta_Entidad>
    {
        private readonly propuesta_entidadRepository _propuesta_entidadRepository;
        public propuesta_entidadController(propuesta_entidadRepository propuestaentidadRepository)
        {
            _propuesta_entidadRepository = propuestaentidadRepository;
        }

        readonly propuesta_entidadRepository propuestaentidadRepository = new propuesta_entidadRepository();
        public propuesta_entidadController()
        {
            _propuesta_entidadRepository = propuestaentidadRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllPropuestaEntidad()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_entidadRepository.GetAllpropuesta_entidad();

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
        public IHttpActionResult GetPropuestaEntidadDetails(int idpropuesta_entidad)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_entidadRepository.Getpropuesta_entidadDetails(idpropuesta_entidad);

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
        public IHttpActionResult GetPropuestaEntidadIdentificacion(string nroidentificacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_entidadRepository.Getpropuesta_entidadDetails(nroidentificacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Entidad inexistente";
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
        public IHttpActionResult GetPropuestaEntidadRazonSocial(string razonsocial)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_entidadRepository.GetPropuestaEntidadRazonSocial(razonsocial);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Entidad inexistente";
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
        public IHttpActionResult InsertPropuestaEntidad([FromBody] Propuesta_Entidad propuestaentidad)
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

                var created = _propuesta_entidadRepository.Insertpropuesta_entidad(propuestaentidad);

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
        public IHttpActionResult UpdatePropuestaEntidad([FromBody] Propuesta_Entidad propuestaentidad)
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

                var created = _propuesta_entidadRepository.Updatepropuesta_entidad(propuestaentidad);

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
        public IHttpActionResult DeletePropuestaEntidad(int idpropuesta_entidad)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _propuesta_entidadRepository.Deletepropuesta_entidad(idpropuesta_entidad);

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
        public IHttpActionResult GetDatataTablePropuestaEntidad()
        {
            DataTableAdapter<Propuesta_Entidad> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _propuesta_entidadRepository.GetDataTablepropuesta_entidad(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }



    }
}
