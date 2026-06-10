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
    public class Publicaciones_ImpresionGramajeController : BaseController<Publicaciones_ImpresionGramaje>
    {
        private readonly IPublicaciones_ImpresionGramajeRepository _publicaciones_ImpresionGramajeRepository;
        public Publicaciones_ImpresionGramajeController(IPublicaciones_ImpresionGramajeRepository publicaciones_ImpresionGramajeRepository)
        {
            _publicaciones_ImpresionGramajeRepository = publicaciones_ImpresionGramajeRepository;
        }
        readonly IPublicaciones_ImpresionGramajeRepository publicaciones_ImpresionGramajeRepository = new Publicaciones_ImpresionGramajeRepository();
        public Publicaciones_ImpresionGramajeController()
        {
            _publicaciones_ImpresionGramajeRepository = publicaciones_ImpresionGramajeRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_ImpresionGramaje()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ImpresionGramajeRepository.GetAllPublicaciones_ImpresionGramaje();

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
        public IHttpActionResult GetPublicaciones_ImpresionGramajeDetails(int id_gramaje)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ImpresionGramajeRepository.GetPublicaciones_ImpresionGramajeDetails(id_gramaje);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_ImpresionGramaje inexistente";
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
        public IHttpActionResult GetPublicaciones_ImpresionGramajeNombre(string cd_nmgramaje)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ImpresionGramajeRepository.GetPublicaciones_ImpresionGramajeNombre(cd_nmgramaje);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_ImpresionGramaje inexistente";
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
        public IHttpActionResult InsertPublicaciones_ImpresionGramaje([FromBody] Publicaciones_ImpresionGramaje publicaciones_ImpresionGramaje)
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

                var created = publicaciones_ImpresionGramajeRepository.InsertPublicaciones_ImpresionGramaje(publicaciones_ImpresionGramaje);

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
        public IHttpActionResult UpdatePublicaciones_ImpresionGramaje([FromBody] Publicaciones_ImpresionGramaje publicaciones_ImpresionGramaje)
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

                var created = publicaciones_ImpresionGramajeRepository.UpdatePublicaciones_ImpresionGramaje(publicaciones_ImpresionGramaje);

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
        public IHttpActionResult DeletePublicaciones_ImpresionGramaje(int id_gramaje)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_ImpresionGramajeRepository.DeletePublicaciones_ImpresionGramaje(id_gramaje);

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
        public IHttpActionResult GetDataTablePublicaciones_ImpresionGramaje()
        {
            DataTableAdapter<Publicaciones_ImpresionGramaje> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_ImpresionGramajeRepository.GetDataTablePublicaciones_ImpresionGramaje(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
