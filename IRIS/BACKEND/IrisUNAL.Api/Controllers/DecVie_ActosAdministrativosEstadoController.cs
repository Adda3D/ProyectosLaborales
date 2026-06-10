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
    public class DecVie_ActosAdministrativosEstadoController : BaseController<DecVie_ActosAdministrativosEstado>
    {
        private readonly IDecVie_ActosAdministrativosEstadoRepository _decVie_ActosAdministrativosEstadoRepository;
        public DecVie_ActosAdministrativosEstadoController(IDecVie_ActosAdministrativosEstadoRepository decVie_ActosAdministrativosEstadoRepository)
        {
            _decVie_ActosAdministrativosEstadoRepository = decVie_ActosAdministrativosEstadoRepository;
        }
        readonly IDecVie_ActosAdministrativosEstadoRepository decVie_ActosAdministrativosEstadoRepository = new DecVie_ActosAdministrativosEstadoRepository();
        public DecVie_ActosAdministrativosEstadoController()
        {
            _decVie_ActosAdministrativosEstadoRepository = decVie_ActosAdministrativosEstadoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_ActosAdministrativosEstado()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ActosAdministrativosEstadoRepository.GetAllDecVie_ActosAdministrativosEstado();

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
        public IHttpActionResult GetDecVie_ActosAdministrativosEstadoDetails(int id_estadoactoadministrativo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ActosAdministrativosEstadoRepository.GetDecVie_ActosAdministrativosEstadoDetails(id_estadoactoadministrativo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Estado Acto Administrativo inexistente";
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
        public IHttpActionResult GetDecVie_ActosAdministrativosEstadoNombre(string cd_nmestadoactoadministrativo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ActosAdministrativosEstadoRepository.GetDecVie_ActosAdministrativosEstadoNombre(cd_nmestadoactoadministrativo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Estado Acto Administrativo inexistente";
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
        public IHttpActionResult InsertDecVie_ActosAdministrativosEstado([FromBody] DecVie_ActosAdministrativosEstado decVie_ActosAdministrativosEstado)
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

                var created = decVie_ActosAdministrativosEstadoRepository.InsertDecVie_ActosAdministrativosEstado(decVie_ActosAdministrativosEstado);

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
        public IHttpActionResult UpdateDecVie_ActosAdministrativosEstado([FromBody] DecVie_ActosAdministrativosEstado decVie_ActosAdministrativosEstado)
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

                var created = decVie_ActosAdministrativosEstadoRepository.UpdateDecVie_ActosAdministrativosEstado(decVie_ActosAdministrativosEstado);

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
        public IHttpActionResult DeleteDecVie_ActosAdministrativosEstado(int id_estadoactoadministrativo)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_ActosAdministrativosEstadoRepository.DeleteDecVie_ActosAdministrativosEstado(id_estadoactoadministrativo);

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
        public IHttpActionResult GetDataTableDecVie_ActosAdministrativosEstado()
        {
            DataTableAdapter<DecVie_ActosAdministrativosEstado> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_ActosAdministrativosEstadoRepository.GetDataTableDecVie_ActosAdministrativosEstado(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
