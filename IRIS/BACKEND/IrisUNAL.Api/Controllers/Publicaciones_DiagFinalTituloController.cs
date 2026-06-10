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
    public class Publicaciones_DiagFinalTituloController : BaseController<Publicaciones_DiagFinalTitulo>
    {
        private readonly IPublicaciones_DiagFinalTituloRepository _publicaciones_DiagFinalTituloRepository;
        public Publicaciones_DiagFinalTituloController(IPublicaciones_DiagFinalTituloRepository publicaciones_DiagFinalTituloRepository)
        {
            _publicaciones_DiagFinalTituloRepository = publicaciones_DiagFinalTituloRepository;
        }
        readonly IPublicaciones_DiagFinalTituloRepository publicaciones_DiagFinalTituloRepository = new Publicaciones_DiagFinalTituloRepository();
        public Publicaciones_DiagFinalTituloController()
        {
            _publicaciones_DiagFinalTituloRepository = publicaciones_DiagFinalTituloRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DiagFinalTitulo()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DiagFinalTituloRepository.GetAllPublicaciones_DiagFinalTitulo();

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
        public IHttpActionResult GetPublicaciones_DiagFinalTituloDetails(int id_diagfinaltitulo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DiagFinalTituloRepository.GetPublicaciones_DiagFinalTituloDetails(id_diagfinaltitulo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_DiagFinalTitulo inexistente";
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
        public IHttpActionResult GetPublicaciones_DiagFinalTituloNombre(string cd_nmdiagfinaltitulo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DiagFinalTituloRepository.GetPublicaciones_DiagFinalTituloNombre(cd_nmdiagfinaltitulo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_DiagFinalTitulo inexistente";
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
        public IHttpActionResult InsertPublicaciones_DiagFinalTitulo([FromBody] Publicaciones_DiagFinalTitulo publicaciones_DiagFinalTitulo)
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

                var created = publicaciones_DiagFinalTituloRepository.InsertPublicaciones_DiagFinalTitulo(publicaciones_DiagFinalTitulo);

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
        public IHttpActionResult UpdatePublicaciones_DiagFinalTitulo([FromBody] Publicaciones_DiagFinalTitulo publicaciones_DiagFinalTitulo)
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

                var created = publicaciones_DiagFinalTituloRepository.UpdatePublicaciones_DiagFinalTitulo(publicaciones_DiagFinalTitulo);

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
        public IHttpActionResult DeletePublicaciones_DiagFinalTitulo(int id_diagfinaltitulo)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DiagFinalTituloRepository.DeletePublicaciones_DiagFinalTitulo(id_diagfinaltitulo);

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
        public IHttpActionResult GetDataTablePublicaciones_DiagFinalTitulo()
        {
            DataTableAdapter<Publicaciones_DiagFinalTitulo> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_DiagFinalTituloRepository.GetDataTablePublicaciones_DiagFinalTitulo(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
