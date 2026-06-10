using IrisUNAL.Api.Entities.Repositories.Investigacion;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.Investigacion;
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

namespace IrisUNAL.Api.Controllers.Investigacion
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Investigacion_DesembolsoController : BaseController<Investigacion_Desembolso>
    {
        private readonly Investigacion_DesembolsoRepository _investigacion_desembolsoRepository;

        public Investigacion_DesembolsoController(Investigacion_DesembolsoRepository investigacion_desembolsoRepository)
        {
            _investigacion_desembolsoRepository = investigacion_desembolsoRepository;
        }

        readonly Investigacion_DesembolsoRepository investigacion_desembolsoRepository = new Investigacion_DesembolsoRepository();
        public Investigacion_DesembolsoController()
        {
            _investigacion_desembolsoRepository = investigacion_desembolsoRepository;
        }

        [HttpGet]
        public IHttpActionResult GetInvestigacion_DesembolsoDetails(int id_desembolso)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_desembolsoRepository.GetInvestigacion_DesembolsoDetails(id_desembolso);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Desembolso Inexistente";
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
        public IHttpActionResult InsertInvestigacion_Desembolso([FromBody] Investigacion_Desembolso _investigacion_desembolso)
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

                var created = _investigacion_desembolsoRepository.InsertInvestigacion_Desembolso(_investigacion_desembolso);

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
        public IHttpActionResult UpdateInvestigacion_Desembolso([FromBody] Investigacion_Desembolso _investigacion_desembolso)
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

                var created = _investigacion_desembolsoRepository.UpdateInvestigacion_Desembolso(_investigacion_desembolso);

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
        public IHttpActionResult DeleteInvestigacion_Desembolso(int id_desembolso)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _investigacion_desembolsoRepository.DeleteInvestigacion_Desembolso(id_desembolso);

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
        public IHttpActionResult GetDataTableInvestigacion_DesembolsoByProyecto(int id_crearproyecto)
        {
            DataTableAdapter<Investigacion_Desembolso> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _investigacion_desembolsoRepository.GetDataTableInvestigacion_DesembolsoByProyecto(id_crearproyecto, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
