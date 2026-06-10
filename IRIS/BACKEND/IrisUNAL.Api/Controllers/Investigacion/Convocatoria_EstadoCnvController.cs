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
    public class Convocatoria_EstadoCnvController : BaseController<Convocatoria_EstadoCnv>
    {
        private readonly Convocatoria_EstadoCnvRepository _convocatoria_EstadoCnvRepository;
        public Convocatoria_EstadoCnvController (Convocatoria_EstadoCnvRepository convocatoria_EstadoCnvRepository)
        {
            _convocatoria_EstadoCnvRepository = convocatoria_EstadoCnvRepository;
        }
        readonly Convocatoria_EstadoCnvRepository convocatoria_EstadoCnvRepository = new Convocatoria_EstadoCnvRepository();
        public Convocatoria_EstadoCnvController()
        {
            _convocatoria_EstadoCnvRepository = convocatoria_EstadoCnvRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllConvocatoria_EstadoCnv()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = convocatoria_EstadoCnvRepository.GetAllConvocatoria_EstadoCnv();

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
        public IHttpActionResult GetConvocatoria_EstadoCnvDetails(int id_estadocnv)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = convocatoria_EstadoCnvRepository.GetConvocatoria_EstadoCnvDetails(id_estadocnv);

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

        [HttpGet]
        public IHttpActionResult GetConvocatoria_EstadoCnvNombre(string cd_nmestadocnv)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = convocatoria_EstadoCnvRepository.GetConvocatoria_EstadoCnvNombre(cd_nmestadocnv);

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
        public IHttpActionResult InsertConvocatoria_EstadoCnv([FromBody] Convocatoria_EstadoCnv convocatoria_EstadoCnv)
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

                var created = convocatoria_EstadoCnvRepository.InsertConvocatoria_EstadoCnv(convocatoria_EstadoCnv);

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
        public IHttpActionResult UpdateConvocatoria_EstadoCnv([FromBody] Convocatoria_EstadoCnv convocatoria_EstadoCnv)
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

                var created = convocatoria_EstadoCnvRepository.UpdateConvocatoria_EstadoCnv(convocatoria_EstadoCnv);

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
        public IHttpActionResult DeleteConvocatoria_EstadoCnv(int id_estadocnv)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = convocatoria_EstadoCnvRepository.DeleteConvocatoria_EstadoCnv(id_estadocnv);

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
        public IHttpActionResult GetDataTableConvocatoria_EstadoCnv()
        {
            DataTableAdapter<Convocatoria_EstadoCnv> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = convocatoria_EstadoCnvRepository.GetDataTableConvocatoria_EstadoCnv(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
