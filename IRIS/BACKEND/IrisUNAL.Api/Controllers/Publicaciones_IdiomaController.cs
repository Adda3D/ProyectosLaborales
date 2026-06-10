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
    public class Publicaciones_IdiomaController : BaseController<Publicaciones_Idioma>
    {
        private readonly IPublicaciones_IdiomaRepository _publicaciones_IdiomaRepository;
        public Publicaciones_IdiomaController(IPublicaciones_IdiomaRepository publicaciones_IdiomaRepository)
        {
            _publicaciones_IdiomaRepository = publicaciones_IdiomaRepository;
        }
        readonly IPublicaciones_IdiomaRepository publicaciones_IdiomaRepository = new Publicaciones_IdiomaRepository();
        public Publicaciones_IdiomaController()
        {
            _publicaciones_IdiomaRepository = publicaciones_IdiomaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_Idioma()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_IdiomaRepository.GetAllPublicaciones_Idioma();

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
        public IHttpActionResult GetPublicaciones_IdiomaDetails(int id_idioma)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_IdiomaRepository.GetPublicaciones_IdiomaDetails(id_idioma);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_Idioma inexistente";
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
        public IHttpActionResult GetPublicaciones_IdiomaNombre(string cd_nmidioma)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_IdiomaRepository.GetPublicaciones_IdiomaNombre(cd_nmidioma);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_Idioma inexistente";
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
        public IHttpActionResult InsertPublicaciones_Idioma([FromBody] Publicaciones_Idioma publicaciones_Idioma)
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

                var created = publicaciones_IdiomaRepository.InsertPublicaciones_Idioma(publicaciones_Idioma);

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
        public IHttpActionResult UpdatePublicaciones_Idioma([FromBody] Publicaciones_Idioma publicaciones_Idioma)
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

                var created = publicaciones_IdiomaRepository.UpdatePublicaciones_Idioma(publicaciones_Idioma);

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
        public IHttpActionResult DeletePublicaciones_Idioma(int id_idioma)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_IdiomaRepository.DeletePublicaciones_Idioma(id_idioma);

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
        public IHttpActionResult GetDataTablePublicaciones_Idioma()
        {
            DataTableAdapter<Publicaciones_Idioma> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_IdiomaRepository.GetDataTablePublicaciones_Idioma(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
