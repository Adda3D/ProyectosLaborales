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
    public class Publicaciones_DivulgacionTituloController : BaseController<Publicaciones_DivulgacionTitulo>
    {
        private readonly IPublicaciones_DivulgacionTituloRepository _publicaciones_DivulgacionTituloRepository;
        public Publicaciones_DivulgacionTituloController(IPublicaciones_DivulgacionTituloRepository publicaciones_DivulgacionTituloRepository)
        {
            _publicaciones_DivulgacionTituloRepository = publicaciones_DivulgacionTituloRepository;
        }
        readonly IPublicaciones_DivulgacionTituloRepository publicaciones_DivulgacionTituloRepository = new Publicaciones_DivulgacionTituloRepository();
        public Publicaciones_DivulgacionTituloController()
        {
            _publicaciones_DivulgacionTituloRepository = publicaciones_DivulgacionTituloRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DivulgacionTitulo()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionTituloRepository.GetAllPublicaciones_DivulgacionTitulo();

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
        public IHttpActionResult GetPublicaciones_DivulgacionTituloDetails(int id_divtitulo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionTituloRepository.GetPublicaciones_DivulgacionTituloDetails(id_divtitulo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_DivulgacionTitulo inexistente";
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
        public IHttpActionResult GetPublicaciones_DivulgacionTituloNombre(string cd_nmtitulo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionTituloRepository.GetPublicaciones_DivulgacionTituloNombre(cd_nmtitulo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_DivulgacionTitulo inexistente";
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
        public IHttpActionResult InsertPublicaciones_DivulgacionTitulo([FromBody] Publicaciones_DivulgacionTitulo publicaciones_DivulgacionTitulo)
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

                var created = publicaciones_DivulgacionTituloRepository.InsertPublicaciones_DivulgacionTitulo(publicaciones_DivulgacionTitulo);

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
        public IHttpActionResult UpdatePublicaciones_DivulgacionTitulo([FromBody] Publicaciones_DivulgacionTitulo publicaciones_DivulgacionTitulo)
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

                var created = publicaciones_DivulgacionTituloRepository.UpdatePublicaciones_DivulgacionTitulo(publicaciones_DivulgacionTitulo);

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
        public IHttpActionResult DeletePublicaciones_DivulgacionTitulo(int id_divtitulo)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DivulgacionTituloRepository.DeletePublicaciones_DivulgacionTitulo(id_divtitulo);

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
        public IHttpActionResult GetDataTablePublicaciones_DivulgacionTitulo()
        {
            DataTableAdapter<Publicaciones_DivulgacionTitulo> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_DivulgacionTituloRepository.GetDataTablePublicaciones_DivulgacionTitulo(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
