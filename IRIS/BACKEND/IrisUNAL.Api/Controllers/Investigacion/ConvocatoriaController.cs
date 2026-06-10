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
    public class ConvocatoriaController : BaseController<Convocatoria>
    {
        private readonly ConvocatoriaRepository _convocatoriaRepository;
        public ConvocatoriaController(ConvocatoriaRepository convocatoriaRepository)
        {
            _convocatoriaRepository = convocatoriaRepository;
        }
        readonly ConvocatoriaRepository convocatoriaRepository = new ConvocatoriaRepository();
        public ConvocatoriaController()
        {
            _convocatoriaRepository = convocatoriaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllConvocatoria()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = convocatoriaRepository.GetAllConvocatoria();

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
        public IHttpActionResult GetConvocatoriaDetails(int id_convocatoria)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = convocatoriaRepository.GetConvocatoriaDetails(id_convocatoria);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Convocatoria inexistente";
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
        public IHttpActionResult GetConvocatoriaNombre(string cd_tituloconvocatoria)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = convocatoriaRepository.GetConvocatoriaNombre(cd_tituloconvocatoria);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Estado inexistente";
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
        public IHttpActionResult InsertConvocatoria([FromBody] Convocatoria convocatoria)
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

                var created = convocatoriaRepository.InsertConvocatoria(convocatoria);

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
        public IHttpActionResult UpdateConvocatoria([FromBody] Convocatoria convocatoria)
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

                var created = convocatoriaRepository.UpdateConvocatoria(convocatoria);

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
        public IHttpActionResult DeleteConvocatoria(int id_convocatoria)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = convocatoriaRepository.DeleteConvocatoria(id_convocatoria);

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
        public IHttpActionResult GetDataTableConvocatoria()
        {
            DataTableAdapter<Convocatoria> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = convocatoriaRepository.GetDataTableConvocatoria(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
