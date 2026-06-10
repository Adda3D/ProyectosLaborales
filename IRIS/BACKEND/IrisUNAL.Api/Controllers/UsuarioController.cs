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
    public class UsuarioController : BaseController<Usuario>
    {
        public readonly IUsuarioRepository _usuarioRepository;
        private UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        readonly IUsuarioRepository usuarioRepository = new UsuarioRepository();
        public UsuarioController()
        {
            _usuarioRepository = usuarioRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllUsuario()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _usuarioRepository.GetAllUsuario();

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
        public IHttpActionResult GetUsuario(int id_usuario)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _usuarioRepository.GetUsuarioDetails(id_usuario);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Usuario Inexistente";
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
        public IHttpActionResult GetUsuario(string correo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _usuarioRepository.GetUsuarioDetails(correo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Usuario Inexistente";
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
        public IHttpActionResult InsertUsuario([FromBody] Usuario usuario)        
        {
            var resultdb = new ResultObject();
            usuario.activo = true;

            try
            {
                //VALIDA BASADO EN LOS DATAANNOTATIONS DEL MODELO
                if (!ModelState.IsValid)
                {
                    resultdb.Ok = false;
                    resultdb.Message = Request.CreateResponse(ModelState).ToString();
                    resultdb.Data = null;
                }

                var created = _usuarioRepository.InsertUsuario(usuario);

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
        public IHttpActionResult UpdateUsuario([FromBody] Usuario usuario)
        {
            var resultdb = new ResultObject();
            usuario.activo = true;

            try
            {
                //VALIDA BASADO EN LOS DATAANNOTATIONS DEL MODELO
                if (!ModelState.IsValid)
                {
                    resultdb.Ok = false;
                    resultdb.Message = Request.CreateResponse(ModelState).ToString();
                    resultdb.Data = null;
                }

                var created = _usuarioRepository.UpdateUsuario(usuario);

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
        public IHttpActionResult DeleteUsuario(int id_usuario)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _usuarioRepository.DeleteUsuario(id_usuario);

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
        public IHttpActionResult GetDataTableUsuario()
        {
            DataTableAdapter<Usuario> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _usuarioRepository.GetDataTableUsuario(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

        [HttpPost]
        public IHttpActionResult UsuarioLogin([FromBody] UsuarioLogin login)
        {
            var resultdb = new ResultObject();
            try
            {
                var datosusuario = _usuarioRepository.UsuarioLogin(login);

                resultdb.Ok = true;
                resultdb.Message = "";
                resultdb.Data = datosusuario;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }

    }
}
