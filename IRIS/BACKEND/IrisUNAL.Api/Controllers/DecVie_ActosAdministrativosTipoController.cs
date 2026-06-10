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
    public class DecVie_ActosAdministrativosTipoController : BaseController<DecVie_ActosAdministrativosTipo>
    {
        private readonly IDecVie_ActosAdministrativosTipoRepository _decVie_ActosAdministrativosTipoRepository;
        public DecVie_ActosAdministrativosTipoController(IDecVie_ActosAdministrativosTipoRepository decVie_ActosAdministrativosTipoRepository)
        {
            _decVie_ActosAdministrativosTipoRepository = decVie_ActosAdministrativosTipoRepository;
        }
        readonly IDecVie_ActosAdministrativosTipoRepository decVie_ActosAdministrativosTipoRepository = new DecVie_ActosAdministrativosTipoRepository();
        public DecVie_ActosAdministrativosTipoController()
        {
            _decVie_ActosAdministrativosTipoRepository = decVie_ActosAdministrativosTipoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_ActosAdministrativosTipo()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ActosAdministrativosTipoRepository.GetAllDecVie_ActosAdministrativosTipo();

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
        public IHttpActionResult GetDecVie_ActosAdministrativosTipoDetails(int id_tipoactoadministrativo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ActosAdministrativosTipoRepository.GetDecVie_ActosAdministrativosTipoDetails(id_tipoactoadministrativo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Tipo Acto Administrativo inexistente";
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
        public IHttpActionResult GetDecVie_ActosAdministrativosTipoNombre(string cd_nmidtipoactoadministrativo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ActosAdministrativosTipoRepository.GetDecVie_ActosAdministrativosTipoNombre(cd_nmidtipoactoadministrativo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Tipo Acto Administrativo inexistente";
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
        public IHttpActionResult InsertDecVie_ActosAdministrativosTipo([FromBody] DecVie_ActosAdministrativosTipo decVie_ActosAdministrativosTipo)
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

                var created = decVie_ActosAdministrativosTipoRepository.InsertDecVie_ActosAdministrativosTipo(decVie_ActosAdministrativosTipo);

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
        public IHttpActionResult UpdateDecVie_ActosAdministrativosTipo([FromBody] DecVie_ActosAdministrativosTipo decVie_ActosAdministrativosTipo)
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

                var created = decVie_ActosAdministrativosTipoRepository.UpdateDecVie_ActosAdministrativosTipo(decVie_ActosAdministrativosTipo);

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
        public IHttpActionResult DeleteDecVie_ActosAdministrativosTipo(int id_tipoactoadministrativo)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_ActosAdministrativosTipoRepository.DeleteDecVie_ActosAdministrativosTipo(id_tipoactoadministrativo);

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
        public IHttpActionResult GetDataTableDecVie_ActosAdministrativosTipo()
        {
            DataTableAdapter<DecVie_ActosAdministrativosTipo> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_ActosAdministrativosTipoRepository.GetDataTableDecVie_ActosAdministrativosTipo(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
