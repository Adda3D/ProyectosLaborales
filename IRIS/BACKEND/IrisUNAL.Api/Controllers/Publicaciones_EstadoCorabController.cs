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
    public class Publicaciones_EstadoCorabController : BaseController<Publicaciones_EstadoCorab>
    {
        private readonly IPublicaciones_EstadoCorabRepository _publicaciones_EstadoCorabRepository;
        public Publicaciones_EstadoCorabController(IPublicaciones_EstadoCorabRepository publicaciones_EstadoCorabRepository)
        {
            _publicaciones_EstadoCorabRepository = publicaciones_EstadoCorabRepository;
        }
        readonly IPublicaciones_EstadoCorabRepository publicaciones_EstadoCorabRepository = new Publicaciones_EstadoCorabRepository();
        public Publicaciones_EstadoCorabController()
        {
            _publicaciones_EstadoCorabRepository = publicaciones_EstadoCorabRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_EstadoCorab()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EstadoCorabRepository.GetAllPublicaciones_EstadoCorab();

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
        public IHttpActionResult GetPublicaciones_EstadoCorabDetails(int id_estadocorab)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EstadoCorabRepository.GetPublicaciones_EstadoCorabDetails(id_estadocorab);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_EstadoCorab inexistente";
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
        public IHttpActionResult GetPublicaciones_EstadoCorabNombre(string cd_nmestadocorab)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EstadoCorabRepository.GetPublicaciones_EstadoCorabNombre(cd_nmestadocorab);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_EstadoCorab inexistente";
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
        public IHttpActionResult InsertPublicaciones_EstadoCorab([FromBody] Publicaciones_EstadoCorab publicaciones_EstadoCorab)
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

                var created = publicaciones_EstadoCorabRepository.InsertPublicaciones_EstadoCorab(publicaciones_EstadoCorab);

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
        public IHttpActionResult UpdatePublicaciones_EstadoCorab([FromBody] Publicaciones_EstadoCorab publicaciones_EstadoCorab)
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

                var created = publicaciones_EstadoCorabRepository.UpdatePublicaciones_EstadoCorab(publicaciones_EstadoCorab);

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
        public IHttpActionResult DeletePublicaciones_EstadoCorab(int id_estadocorab)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_EstadoCorabRepository.DeletePublicaciones_EstadoCorab(id_estadocorab);

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
        public IHttpActionResult GetDataTablePublicaciones_EstadoCorab()
        {
            DataTableAdapter<Publicaciones_EstadoCorab> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_EstadoCorabRepository.GetDataTablePublicaciones_EstadoCorab(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
