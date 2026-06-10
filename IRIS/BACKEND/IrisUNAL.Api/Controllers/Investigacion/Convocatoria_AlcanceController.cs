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
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class Convocatoria_AlcanceController : BaseController<Convocatoria_Alcance>
    {
        private readonly Convocatoria_AlcanceRepository _convocatoria_AlcanceRepository;
        public Convocatoria_AlcanceController(Convocatoria_AlcanceRepository convocatoria_AlcanceRepository)
        {
            _convocatoria_AlcanceRepository = convocatoria_AlcanceRepository;
        }
        readonly Convocatoria_AlcanceRepository convocatoria_AlcanceRepository = new Convocatoria_AlcanceRepository();
        public Convocatoria_AlcanceController()
        {
            _convocatoria_AlcanceRepository = convocatoria_AlcanceRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllConvocatoria_Alcance()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = convocatoria_AlcanceRepository.GetAllConvocatoria_Alcance();

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
        public IHttpActionResult GetConvocatoria_AlcanceDetails(int id_alcance)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = convocatoria_AlcanceRepository.GetConvocatoria_AlcanceDetails(id_alcance);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Alcance inexistente";
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
        public IHttpActionResult GetConvocatoria_AlcanceNombre(string cd_nmalcance)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = convocatoria_AlcanceRepository.GetConvocatoria_AlcanceNombre(cd_nmalcance);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Alcance inexistente";
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
        public IHttpActionResult InsertConvocatoria_Alcance([FromBody] Convocatoria_Alcance convocatoria_Alcance)
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

                var created = convocatoria_AlcanceRepository.InsertConvocatoria_Alcance(convocatoria_Alcance);

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
        public IHttpActionResult UpdateConvocatoria_Alcance([FromBody] Convocatoria_Alcance convocatoria_Alcance)
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

                var created = convocatoria_AlcanceRepository.UpdateConvocatoria_Alcance(convocatoria_Alcance);

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
        public IHttpActionResult DeleteConvocatoria_Alcance(int id_alcance)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = convocatoria_AlcanceRepository.DeleteConvocatoria_Alcance(id_alcance);

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
        public IHttpActionResult GetDataTableConvocatoria_Alcance()
        {
            DataTableAdapter<Convocatoria_Alcance> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = convocatoria_AlcanceRepository.GetDataTableConvocatoria_Alcance(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
