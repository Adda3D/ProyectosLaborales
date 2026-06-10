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
    public class FuncionarioController : BaseController<Funcionario>
    {
        private readonly FuncionarioRepository _funcionarioRepository;

        public FuncionarioController(FuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        readonly FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
        public FuncionarioController()
        {
            _funcionarioRepository = funcionarioRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllFuncionario()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _funcionarioRepository.GetAllFuncionario();

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
        public IHttpActionResult GetFuncionarioDetails(int idfuncionario)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _funcionarioRepository.GetFuncionarioDetails(idfuncionario);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Funcionario inexistente";
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
        public IHttpActionResult GetFuncionarioIdentificacion(string numidentificacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _funcionarioRepository.GetFuncionarioIdentificacion(numidentificacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Funcionario inexistente";
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
        public IHttpActionResult InsertFuncionario([FromBody] Funcionario funcionario)
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

                var created = _funcionarioRepository.InsertFuncionario(funcionario);

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
        public IHttpActionResult UpdateFuncionario([FromBody] Funcionario funcionario)
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

                var created = _funcionarioRepository.UpdateFuncionario(funcionario);

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
        public IHttpActionResult DeleteFuncionario(int idfuncionario)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _funcionarioRepository.DeleteFuncionario(idfuncionario);

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
        public IHttpActionResult GetDataTableFuncionario()
        {
            DataTableAdapter<Funcionario> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _funcionarioRepository.GetDataTableFuncionario(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetFuncionariosPorDependencia(int id_depend)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _funcionarioRepository
                    .GetAllFuncionario()
                    .Where(f => f.id_depend == id_depend) // quitamos .activo
                    .Select(f => new {
                        f.idfuncionario,
                        f.nombres,
                        f.apellidos
                    })
                    .ToList();

                resultdb.Ok = true;
                resultdb.Data = data;
                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetIdFuncionarioByUsuario(string usuario)
        {
            var resultdb = new ResultObject();
            try
            {
                // Buscar funcionario cuyo correo comience con el usuario (ej. juanperez -> juanperez@unal.edu.co)
                var funcionario = _funcionarioRepository
                    .GetAllFuncionario()
                    .FirstOrDefault(f => f.correo.ToLower().StartsWith(usuario.ToLower()));

                if (funcionario == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "No se encontró funcionario con ese usuario.";
                    return Return(resultdb);
                }

                resultdb.Ok = true;
                resultdb.Data = new { idfuncionario = funcionario.idfuncionario };
                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }


    }
}
