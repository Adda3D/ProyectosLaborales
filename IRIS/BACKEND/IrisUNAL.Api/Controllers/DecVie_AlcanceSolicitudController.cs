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
    public class DecVie_AlcanceSolicitudController : BaseController<DecVie_AlcanceSolicitud>
    {
        private readonly IDecVie_AlcanceSolicitudRepository _decVie_AlcanceSolicitudRepository;
        public DecVie_AlcanceSolicitudController(IDecVie_AlcanceSolicitudRepository decVie_AlcanceSolicitudRepository)
        {
            _decVie_AlcanceSolicitudRepository = decVie_AlcanceSolicitudRepository;
        }
        readonly IDecVie_AlcanceSolicitudRepository decVie_AlcanceSolicitudRepository = new DecVie_AlcanceSolicitudRepository();
        public DecVie_AlcanceSolicitudController()
        {
            _decVie_AlcanceSolicitudRepository = decVie_AlcanceSolicitudRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_AlcanceSolicitud()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_AlcanceSolicitudRepository.GetAllDecVie_AlcanceSolicitud();

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
        public IHttpActionResult GetDecVie_AlcanceSolicitudDetails(int id_alcancesolicitud)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_AlcanceSolicitudRepository.GetDecVie_AlcanceSolicitudDetails(id_alcancesolicitud);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_AlcanceSolicitud inexistente";
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
        public IHttpActionResult GetDecVie_AlcanceSolicitudNombre(string cd_nmalcancesolicitud)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_AlcanceSolicitudRepository.GetDecVie_AlcanceSolicitudNombre(cd_nmalcancesolicitud);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_AlcanceSolicitud inexistente";
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
        public IHttpActionResult InsertDecVie_AlcanceSolicitud([FromBody] DecVie_AlcanceSolicitud decVie_AlcanceSolicitud)
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

                var created = decVie_AlcanceSolicitudRepository.InsertDecVie_AlcanceSolicitud(decVie_AlcanceSolicitud);

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
        public IHttpActionResult UpdateDecVie_AlcanceSolicitud([FromBody] DecVie_AlcanceSolicitud decVie_AlcanceSolicitud)
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

                var created = decVie_AlcanceSolicitudRepository.UpdateDecVie_AlcanceSolicitud(decVie_AlcanceSolicitud);

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
        public IHttpActionResult DeleteDecVie_AlcanceSolicitud(int id_alcancesolicitud)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_AlcanceSolicitudRepository.DeleteDecVie_AlcanceSolicitud(id_alcancesolicitud);

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
        public IHttpActionResult GetDataTableDecVie_AlcanceSolicitud()
        {
            DataTableAdapter<DecVie_AlcanceSolicitud> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_AlcanceSolicitudRepository.GetDataTableDecVie_AlcanceSolicitud(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
