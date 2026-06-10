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
    public class Publicaciones_CarProyEditorialController : BaseController<Publicaciones_CarProyEditorial>
    {
        private readonly IPublicaciones_CarProyEditorialRepository _publicaciones_CarProyEditorialRepository;
        public Publicaciones_CarProyEditorialController(IPublicaciones_CarProyEditorialRepository publicaciones_CarProyEditorialRepository)
        {
            _publicaciones_CarProyEditorialRepository = publicaciones_CarProyEditorialRepository;
        }
        readonly IPublicaciones_CarProyEditorialRepository publicaciones_CarProyEditorialRepository = new Publicaciones_CarProyEditorialRepository();
        public Publicaciones_CarProyEditorialController()
        {
            _publicaciones_CarProyEditorialRepository = publicaciones_CarProyEditorialRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_CarProyEditorial()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CarProyEditorialRepository.GetAllPublicaciones_CarProyEditorial();

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
        public IHttpActionResult GetPublicaciones_CarProyEditorialDetails(int id_carproyeditorial)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CarProyEditorialRepository.GetPublicaciones_CarProyEditorialDetails(id_carproyeditorial);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_CarProyEditorial inexistente";
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
        public IHttpActionResult GetPublicaciones_CarProyEditorialNombre(string cd_nmcarproyeditorial)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CarProyEditorialRepository.GetPublicaciones_CarProyEditorialNombre(cd_nmcarproyeditorial);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_CarProyEditorial inexistente";
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
        public IHttpActionResult InsertPublicaciones_CarProyEditorial([FromBody] Publicaciones_CarProyEditorial publicaciones_CarProyEditorial)
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

                var created = publicaciones_CarProyEditorialRepository.InsertPublicaciones_CarProyEditorial(publicaciones_CarProyEditorial);

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
        public IHttpActionResult UpdatePublicaciones_CarProyEditorial([FromBody] Publicaciones_CarProyEditorial publicaciones_CarProyEditorial)
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

                var created = publicaciones_CarProyEditorialRepository.UpdatePublicaciones_CarProyEditorial(publicaciones_CarProyEditorial);

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
        public IHttpActionResult DeletePublicaciones_CarProyEditorial(int id_carproyeditorial)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_CarProyEditorialRepository.DeletePublicaciones_CarProyEditorial(id_carproyeditorial);

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
        public IHttpActionResult GetDataTablePublicaciones_CarProyEditorial()
        {
            DataTableAdapter<Publicaciones_CarProyEditorial> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_CarProyEditorialRepository.GetDataTablePublicaciones_CarProyEditorial(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
