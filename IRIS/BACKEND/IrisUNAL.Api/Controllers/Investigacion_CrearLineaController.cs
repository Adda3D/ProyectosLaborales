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
    public class Investigacion_CrearLineaController : BaseController<Investigacion_CrearLinea>
    {
        private readonly IInvestigacion_CrearLineaRepository _investigacion_CrearLineaRepository;

        public Investigacion_CrearLineaController(IInvestigacion_CrearLineaRepository investigacion_CrearLineaRepository)
        {
            _investigacion_CrearLineaRepository = investigacion_CrearLineaRepository;
        }

        readonly IInvestigacion_CrearLineaRepository investigacion_CrearLineaRepository = new Investigacion_CrearLineaRepository();
        public Investigacion_CrearLineaController()
        {
            _investigacion_CrearLineaRepository = investigacion_CrearLineaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllInvestigacion_CrearLinea()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_CrearLineaRepository.GetAllInvestigacion_CrearLinea();

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
        public IHttpActionResult GetInvestigacion_CrearLineaDetails(int id_crearlinea)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_CrearLineaRepository.GetInvestigacion_CrearLineaDetails(id_crearlinea);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Código inexistente";
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
        public IHttpActionResult GetInvestigacion_CrearLineaNombre(string cd_linea)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_CrearLineaRepository.GetInvestigacion_CrearLineaNombre(cd_linea);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Código inexistente";
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
        public IHttpActionResult InsertInvestigacion_CrearLinea([FromBody] Investigacion_CrearLinea investigacion_CrearLinea)
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

                var created = _investigacion_CrearLineaRepository.InsertInvestigacion_CrearLinea(investigacion_CrearLinea);

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
        public IHttpActionResult UpdateInvestigacion_CrearLinea([FromBody] Investigacion_CrearLinea investigacion_CrearLinea)
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

                var created = _investigacion_CrearLineaRepository.UpdateInvestigacion_CrearLinea(investigacion_CrearLinea);

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
        public IHttpActionResult DeleteInvestigacion_CrearLinea(int id_crearlinea)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _investigacion_CrearLineaRepository.DeleteInvestigacion_CrearLinea(id_crearlinea);

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
        public IHttpActionResult GetDataTableInvestigacion_CrearLinea()
        {
            DataTableAdapter<Investigacion_CrearLinea> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _investigacion_CrearLineaRepository.GetDataTableInvestigacion_CrearLinea(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
