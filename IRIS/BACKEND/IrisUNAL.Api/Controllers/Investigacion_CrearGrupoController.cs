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
    public class Investigacion_CrearGrupoController : BaseController<Investigacion_CrearGrupo>
    {
        private readonly IInvestigacion_CrearGrupoRepository _investigacion_CrearGrupoRepository;

        public Investigacion_CrearGrupoController(IInvestigacion_CrearGrupoRepository investigacion_CrearGrupoRepository)
        {
            _investigacion_CrearGrupoRepository = investigacion_CrearGrupoRepository;
        }

        readonly IInvestigacion_CrearGrupoRepository investigacion_CrearGrupoRepository = new Investigacion_CrearGrupoRepository();
        public Investigacion_CrearGrupoController()
        {
            _investigacion_CrearGrupoRepository = investigacion_CrearGrupoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllInvestigacion_CrearGrupo()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_CrearGrupoRepository.GetAllInvestigacion_CrearGrupo();

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
        public IHttpActionResult GetInvestigacion_CrearGrupoDetails(int id_creargrupo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_CrearGrupoRepository.GetInvestigacion_CrearGrupoDetails(id_creargrupo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Grupo inexistente";
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
        public IHttpActionResult GetInvestigacion_CrearGrupoNombre(string cd_codigohermes)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_CrearGrupoRepository.GetInvestigacion_CrearGrupoCodigo(cd_codigohermes);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Grupo inexistente";
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
        public IHttpActionResult InsertInvestigacion_CrearGrupo([FromBody] Investigacion_CrearGrupo investigacion_CrearGrupo)
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

                var created = _investigacion_CrearGrupoRepository.InsertInvestigacion_CrearGrupo(investigacion_CrearGrupo);

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
        public IHttpActionResult UpdateInvestigacion_CrearGrupo([FromBody] Investigacion_CrearGrupo investigacion_CrearGrupo)
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

                var created = _investigacion_CrearGrupoRepository.UpdateInvestigacion_CrearGrupo(investigacion_CrearGrupo);

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
        public IHttpActionResult DeleteInvestigacion_CrearGrupo(int id_creargrupo)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _investigacion_CrearGrupoRepository.DeleteInvestigacion_CrearGrupo(id_creargrupo);

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
        public IHttpActionResult GetDataTableInvestigacion_CrearGrupo()
        {
            DataTableAdapter<Investigacion_CrearGrupo> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = investigacion_CrearGrupoRepository.GetDataTableInvestigacion_CrearGrupo(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
