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
    public class DecVie_OrigenSolicitudController : BaseController<DecVie_OrigenSolicitud>
    {
        private readonly IDecVie_OrigenSolicitudRepository _decVie_OrigenSolicitudRepository;
        public DecVie_OrigenSolicitudController(IDecVie_OrigenSolicitudRepository decVie_OrigenSolicitudRepository)
        {
            _decVie_OrigenSolicitudRepository = decVie_OrigenSolicitudRepository;
        }
        readonly IDecVie_OrigenSolicitudRepository decVie_OrigenSolicitudRepository = new DecVie_OrigenSolicitudRepository();
        public DecVie_OrigenSolicitudController()
        {
            _decVie_OrigenSolicitudRepository = decVie_OrigenSolicitudRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_OrigenSolicitud()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_OrigenSolicitudRepository.GetAllDecVie_OrigenSolicitud();

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
        public IHttpActionResult GetDecVie_OrigenSolicitudDetails(int id_origensolicitud)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_OrigenSolicitudRepository.GetDecVie_OrigenSolicitudDetails(id_origensolicitud);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_OrigenSolicitud inexistente";
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
        public IHttpActionResult GetDecVie_OrigenSolicitudNombre(string cd_nmorigensolicitud)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_OrigenSolicitudRepository.GetDecVie_OrigenSolicitudNombre(cd_nmorigensolicitud);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_OrigenSolicitud inexistente";
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
        public IHttpActionResult InsertDecVie_OrigenSolicitud([FromBody] DecVie_OrigenSolicitud decVie_OrigenSolicitud)
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

                var created = decVie_OrigenSolicitudRepository.InsertDecVie_OrigenSolicitud(decVie_OrigenSolicitud);

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
        public IHttpActionResult UpdateDecVie_OrigenSolicitud([FromBody] DecVie_OrigenSolicitud decVie_OrigenSolicitud)
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

                var created = decVie_OrigenSolicitudRepository.UpdateDecVie_OrigenSolicitud(decVie_OrigenSolicitud);

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
        public IHttpActionResult DeleteDecVie_OrigenSolicitud(int id_origensolicitud)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_OrigenSolicitudRepository.DeleteDecVie_OrigenSolicitud(id_origensolicitud);

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
        public IHttpActionResult GetDataTableDecVie_OrigenSolicitud()
        {
            DataTableAdapter<DecVie_OrigenSolicitud> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_OrigenSolicitudRepository.GetDataTableDecVie_OrigenSolicitud(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
