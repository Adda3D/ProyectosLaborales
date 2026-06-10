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
    public class Investigacion_ActoAdmonContrapartidaController : BaseController<Investigacion_ActoAdmonContrapartida>
    {
        private readonly IInvestigacion_ActoAdmonContrapartidaRepository _investigacion_ActoAdmonContrapartidaRepository;

        public Investigacion_ActoAdmonContrapartidaController(IInvestigacion_ActoAdmonContrapartidaRepository investigacion_ActoAdmonContrapartidaRepository)
        {
            _investigacion_ActoAdmonContrapartidaRepository = investigacion_ActoAdmonContrapartidaRepository;
        }

        readonly IInvestigacion_ActoAdmonContrapartidaRepository investigacion_ActoAdmonContrapartidaRepository = new Investigacion_ActoAdmonContrapartidaRepository();
        public Investigacion_ActoAdmonContrapartidaController()
        {
            _investigacion_ActoAdmonContrapartidaRepository = investigacion_ActoAdmonContrapartidaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllInvestigacion_ActoAdmonContrapartida()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_ActoAdmonContrapartidaRepository.GetAllInvestigacion_ActoAdmonContrapartida();

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
        public IHttpActionResult GetInvestigacion_ActoAdmonContrapartidaDetails(int id_actoadmoncontrapartida)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_ActoAdmonContrapartidaRepository.GetInvestigacion_ActoAdmonContrapartidaDetails(id_actoadmoncontrapartida);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Acto Administrativo inexistente";
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
        public IHttpActionResult GetInvestigacion_ActoAdmonContrapartidaCodigo(string cd_codigohermes)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_ActoAdmonContrapartidaRepository.GetInvestigacion_ActoAdmonContrapartidaCodigo(cd_codigohermes);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Acto Administrativo inexistente";
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
        public IHttpActionResult InsertInvestigacion_ActoAdmonContrapartida([FromBody] Investigacion_ActoAdmonContrapartida investigacion_ActoAdmonContrapartida)
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

                var created = _investigacion_ActoAdmonContrapartidaRepository.InsertInvestigacion_ActoAdmonContrapartida(investigacion_ActoAdmonContrapartida);

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
        public IHttpActionResult UpdateInvestigacion_ActoAdmonContrapartida([FromBody] Investigacion_ActoAdmonContrapartida investigacion_ActoAdmonContrapartida)
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

                var created = _investigacion_ActoAdmonContrapartidaRepository.UpdateInvestigacion_ActoAdmonContrapartida(investigacion_ActoAdmonContrapartida);

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
        public IHttpActionResult DeleteInvestigacion_ActoAdmonContrapartida(int id_actoadmoncontrapartida)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _investigacion_ActoAdmonContrapartidaRepository.DeleteInvestigacion_ActoAdmonContrapartida(id_actoadmoncontrapartida);

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
        public IHttpActionResult GetDataTableInvestigacion_ActoAdmonContrapartida()
        {
            DataTableAdapter<Investigacion_ActoAdmonContrapartida> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = investigacion_ActoAdmonContrapartidaRepository.GetDataTableInvestigacion_ActoAdmonContrapartida(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
