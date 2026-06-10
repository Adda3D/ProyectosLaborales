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
    public class Investigacion_GastoController : BaseController<Investigacion_Gasto>
    {
        private readonly Investigacion_GastoRepository _investigacion_gastoRepository;

        public Investigacion_GastoController(Investigacion_GastoRepository investigacion_gastoRepository)
        {
            _investigacion_gastoRepository = investigacion_gastoRepository;
        }

        readonly Investigacion_GastoRepository investigacion_gastoRepository = new Investigacion_GastoRepository();
        public Investigacion_GastoController()
        {
            _investigacion_gastoRepository = investigacion_gastoRepository;
        }

        [HttpGet]
        public IHttpActionResult GetInvestigacion_GastoDetails(int id_investigaciongasto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_gastoRepository.GetInvestigacion_GastoDetails(id_investigaciongasto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Gasto no existente";
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
        public IHttpActionResult GetInvestigacion_GastoRelaciones(int id_investigaciongasto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_gastoRepository.GetInvestigacion_GastoRelaciones(id_investigaciongasto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Gasto no existente";
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
        public IHttpActionResult InsertInvestigacion_Gasto([FromBody] Investigacion_Gasto _investigacion_gasto)
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

                var created = _investigacion_gastoRepository.InsertInvestigacion_Gasto(_investigacion_gasto);

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
        public IHttpActionResult UpdateInvestigacion_Gasto([FromBody] Investigacion_Gasto _investigacion_gasto)
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

                var created = _investigacion_gastoRepository.UpdateInvestigacion_Gasto(_investigacion_gasto);

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
        public IHttpActionResult DeleteInvestigacion_Gasto(int id_investigaciongasto)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _investigacion_gastoRepository.DeleteInvestigacion_Gasto(id_investigaciongasto);

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
        public IHttpActionResult GetDataTableInvestigacion_GastoByProyecto(int id_crearproyecto, int id_partida)
        {
            DataTableAdapter<Investigacion_Gasto> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _investigacion_gastoRepository.GetDataTableInvestigacion_GastoByProyecto(id_crearproyecto, id_partida, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }
    }
}
