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
    public class Publicaciones_AreaCurricularController : BaseController<Publicaciones_AreaCurricular>
    {
        private readonly IPublicaciones_AreaCurricularRepository _publicaciones_AreaCurricularRepository;
        public Publicaciones_AreaCurricularController(IPublicaciones_AreaCurricularRepository publicaciones_AreaCurricularRepository)
        {
            _publicaciones_AreaCurricularRepository = publicaciones_AreaCurricularRepository;
        }

        readonly IPublicaciones_AreaCurricularRepository publicaciones_AreaCurricularRepository = new Publicaciones_AreaCurricularRepository();
        public Publicaciones_AreaCurricularController()
        {
            _publicaciones_AreaCurricularRepository = publicaciones_AreaCurricularRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_AreaCurricular()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_AreaCurricularRepository.GetAllPublicaciones_AreaCurricular();

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
        public IHttpActionResult GetPublicaciones_AreaCurricularDetails(int id_areacurricular)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_AreaCurricularRepository.GetPublicaciones_AreaCurricularDetails(id_areacurricular);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_AreaCurricular inexistente";
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
        public IHttpActionResult GetPublicaciones_AreaCurricularDetails(string cd_nmareacurricular)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_AreaCurricularRepository.GetPublicaciones_AreaCurricularDetails(cd_nmareacurricular);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_AreaCurricular inexistente";
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
        public IHttpActionResult InsertPublicaciones_AreaCurricular([FromBody] Publicaciones_AreaCurricular publicaciones_AreaCurricular)
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

                var created = publicaciones_AreaCurricularRepository.InsertPublicaciones_AreaCurricular( publicaciones_AreaCurricular);

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
        public IHttpActionResult UpdatePublicaciones_AreaCurricular([FromBody] Publicaciones_AreaCurricular publicaciones_AreaCurricular)
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

                var created = publicaciones_AreaCurricularRepository.UpdatePublicaciones_AreaCurricular(publicaciones_AreaCurricular);

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
        public IHttpActionResult DeletePublicaciones_AreaCurricular(int id_areacurricular)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_AreaCurricularRepository.DeletePublicaciones_AreaCurricular(id_areacurricular);

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
        public IHttpActionResult GetDataTablePublicaciones_AreaCurricular()
        {
            DataTableAdapter<Publicaciones_AreaCurricular> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_AreaCurricularRepository.GetDataTablePublicaciones_AreaCurricular(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
