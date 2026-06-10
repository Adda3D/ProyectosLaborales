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
    public class Publicaciones_EstadoDiagramacionController : BaseController<Publicaciones_EstadoDiagramacion>
    {
        private readonly IPublicaciones_EstadoDiagramacionRepository _publicaciones_EstadoDiagramacionRepository;
        public Publicaciones_EstadoDiagramacionController(IPublicaciones_EstadoDiagramacionRepository publicaciones_EstadoDiagramacionRepository)
        {
            _publicaciones_EstadoDiagramacionRepository = publicaciones_EstadoDiagramacionRepository;
        }
        readonly IPublicaciones_EstadoDiagramacionRepository publicaciones_EstadoDiagramacionRepository = new Publicaciones_EstadoDiagramacionRepository();
        public Publicaciones_EstadoDiagramacionController()
        {
            _publicaciones_EstadoDiagramacionRepository = publicaciones_EstadoDiagramacionRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_EstadoDiagramacion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EstadoDiagramacionRepository.GetAllPublicaciones_EstadoDiagramacion();

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
        public IHttpActionResult GetPublicaciones_EstadoDiagramacionDetails(int id_estadodiagramacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EstadoDiagramacionRepository.GetPublicaciones_EstadoDiagramacionDetails(id_estadodiagramacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_EstadoDiagramacion inexistente";
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
        public IHttpActionResult GetPublicaciones_EstadoDiagramacionNombre(string cd_nmestadodiagramacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EstadoDiagramacionRepository.GetPublicaciones_EstadoDiagramacionNombre(cd_nmestadodiagramacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_EstadoDiagramacion inexistente";
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
        public IHttpActionResult InsertPublicaciones_EstadoDiagramacion([FromBody] Publicaciones_EstadoDiagramacion publicaciones_EstadoDiagramacion)
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

                var created = publicaciones_EstadoDiagramacionRepository.InsertPublicaciones_EstadoDiagramacion(publicaciones_EstadoDiagramacion);

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
        public IHttpActionResult UpdatePublicaciones_EstadoDiagramacion([FromBody] Publicaciones_EstadoDiagramacion publicaciones_EstadoDiagramacion)
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

                var created = publicaciones_EstadoDiagramacionRepository.UpdatePublicaciones_EstadoDiagramacion(publicaciones_EstadoDiagramacion);

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
        public IHttpActionResult DeletePublicaciones_EstadoDiagramacion(int id_estadodiagramacion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_EstadoDiagramacionRepository.DeletePublicaciones_EstadoDiagramacion(id_estadodiagramacion);

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
        public IHttpActionResult GetDataTablePublicaciones_EstadoDiagramacion()
        {
            DataTableAdapter<Publicaciones_EstadoDiagramacion> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_EstadoDiagramacionRepository.GetDataTablePublicaciones_EstadoDiagramacion(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
