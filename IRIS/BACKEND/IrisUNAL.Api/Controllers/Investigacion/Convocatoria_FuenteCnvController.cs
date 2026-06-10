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
    public class Convocatoria_FuenteCnvController : BaseController<Convocatoria_FuenteCnv>
    {
        private readonly Convocatoria_FuenteCnvRepository _convocatoria_FuenteCnvRepository;
        public Convocatoria_FuenteCnvController(Convocatoria_FuenteCnvRepository convocatoria_FuenteCnvRepository)
        {
            _convocatoria_FuenteCnvRepository = convocatoria_FuenteCnvRepository;
        }
        readonly Convocatoria_FuenteCnvRepository convocatoria_FuenteCnvRepository = new Convocatoria_FuenteCnvRepository();
        public Convocatoria_FuenteCnvController()
        {
            _convocatoria_FuenteCnvRepository = convocatoria_FuenteCnvRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllConvocatoria_FuenteCnv()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = convocatoria_FuenteCnvRepository.GetAllConvocatoria_FuenteCnv();

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
        public IHttpActionResult GetConvocatoria_FuenteCnvDetails(int id_fuentecnv)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = convocatoria_FuenteCnvRepository.GetConvocatoria_FuenteCnvDetails(id_fuentecnv);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Fuente inexistente";
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
        public IHttpActionResult GetConvocatoria_FuenteCnvNombre(string cd_nmfuentecnv)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = convocatoria_FuenteCnvRepository.GetConvocatoria_FuenteCnvNombre(cd_nmfuentecnv);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Fuente inexistente";
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
        public IHttpActionResult InsertConvocatoria_FuenteCnv([FromBody] Convocatoria_FuenteCnv convocatoria_FuenteCnv)
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

                var created = convocatoria_FuenteCnvRepository.InsertConvocatoria_FuenteCnv(convocatoria_FuenteCnv);

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
        public IHttpActionResult UpdateConvocatoria_FuenteCnv([FromBody] Convocatoria_FuenteCnv convocatoria_FuenteCnv)
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

                var created = convocatoria_FuenteCnvRepository.UpdateConvocatoria_FuenteCnv(convocatoria_FuenteCnv);

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
        public IHttpActionResult DeleteConvocatoria_FuenteCnv(int id_fuentecnv)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = convocatoria_FuenteCnvRepository.DeleteConvocatoria_FuenteCnv(id_fuentecnv);

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
        public IHttpActionResult GetDataTableConvocatoria_FuenteCnv()
        {
            DataTableAdapter<Convocatoria_FuenteCnv> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = convocatoria_FuenteCnvRepository.GetDataTableConvocatoria_FuenteCnv(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
