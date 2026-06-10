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
    public class Propuesta_TipoUsuarioController : BaseController<Propuesta_TipoUsuario>
    {
        public readonly IPropuesta_TipoUsuarioRepository _propuesta_TipoUsuarioRepository;
        private Propuesta_TipoUsuarioController(IPropuesta_TipoUsuarioRepository propuesta_TipoUsuarioRepository)
        {
            _propuesta_TipoUsuarioRepository = propuesta_TipoUsuarioRepository;
        }
        readonly IPropuesta_TipoUsuarioRepository propuesta_TipoUsuarioRepository = new Propuesta_TipoUsuarioRepository();
        public Propuesta_TipoUsuarioController()
        {
            _propuesta_TipoUsuarioRepository = propuesta_TipoUsuarioRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPropuesta_TipoUsuario()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_TipoUsuarioRepository.GetAllPropuesta_TipoUsuario();

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
        public IHttpActionResult GetPropuesta_TipoUsuarioDetails(int id_propuestatipousuario)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_TipoUsuarioRepository.GetPropuesta_TipoUsuarioDetails(id_propuestatipousuario);

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
        public IHttpActionResult GetPropuesta_TipoUsuarioNombre(string cd_nmpropuestatipousuario)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _propuesta_TipoUsuarioRepository.GetPropuesta_TipoUsuarioNombre(cd_nmpropuestatipousuario);

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
        public IHttpActionResult InsertPropuesta_TipoUsuario([FromBody] Propuesta_TipoUsuario propuesta_TipoUsuario)
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

                var created = _propuesta_TipoUsuarioRepository.InsertPropuesta_TipoUsuario(propuesta_TipoUsuario);

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
        public IHttpActionResult UpdatePropuesta_TipoUsuario([FromBody] Propuesta_TipoUsuario propuesta_TipoUsuario)
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

                var created = _propuesta_TipoUsuarioRepository.UpdatePropuesta_TipoUsuario(propuesta_TipoUsuario);

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
        public IHttpActionResult DeletePropuesta_TipoUsuario(int id_propuestatipousuario)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _propuesta_TipoUsuarioRepository.DeletePropuesta_TipoUsuario(id_propuestatipousuario);

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
        public IHttpActionResult GetDatataTablePropuestaTipoUsuario()
        {
            DataTableAdapter<Propuesta_TipoUsuario> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _propuesta_TipoUsuarioRepository.GetDataTablePropuesta_TipoUsuario(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

    }
}
