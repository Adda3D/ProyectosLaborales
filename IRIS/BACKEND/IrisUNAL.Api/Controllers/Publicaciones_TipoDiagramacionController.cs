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
    public class Publicaciones_TipoDiagramacionController : BaseController<Publicaciones_TipoDiagramacion>
    {
        private readonly IPublicaciones_TipoDiagramacionRepository _publicaciones_TipoDiagramacionRepository;
        public Publicaciones_TipoDiagramacionController(IPublicaciones_TipoDiagramacionRepository publicaciones_TipoDiagramacionRepository)
        {
            _publicaciones_TipoDiagramacionRepository = publicaciones_TipoDiagramacionRepository;
        }
        readonly IPublicaciones_TipoDiagramacionRepository publicaciones_TipoDiagramacionRepository = new Publicaciones_TipoDiagramacionRepository();
        public Publicaciones_TipoDiagramacionController()
        {
            _publicaciones_TipoDiagramacionRepository = publicaciones_TipoDiagramacionRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_TipoDiagramacion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_TipoDiagramacionRepository.GetAllPublicaciones_TipoDiagramacion();

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
        public IHttpActionResult GetPublicaciones_TipoDiagramacionDetails(int id_tipodiagramacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_TipoDiagramacionRepository.GetPublicaciones_TipoDiagramacionDetails(id_tipodiagramacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_TipoDiagramacion inexistente";
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
        public IHttpActionResult GetPublicaciones_TipoDiagramacionNombre(string cd_nmtipodiagramacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_TipoDiagramacionRepository.GetPublicaciones_TipoDiagramacionNombre(cd_nmtipodiagramacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_TipoDiagramacion inexistente";
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
        public IHttpActionResult InsertPublicaciones_TipoDiagramacion([FromBody] Publicaciones_TipoDiagramacion publicaciones_TipoDiagramacion)
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

                var created = publicaciones_TipoDiagramacionRepository.InsertPublicaciones_TipoDiagramacion(publicaciones_TipoDiagramacion);

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
        public IHttpActionResult UpdatePublicaciones_TipoDiagramacion([FromBody] Publicaciones_TipoDiagramacion publicaciones_TipoDiagramacion)
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

                var created = publicaciones_TipoDiagramacionRepository.UpdatePublicaciones_TipoDiagramacion(publicaciones_TipoDiagramacion);

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
        public IHttpActionResult DeletePublicaciones_TipoDiagramacion(int id_tipodiagramacion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_TipoDiagramacionRepository.DeletePublicaciones_TipoDiagramacion(id_tipodiagramacion);

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
        public IHttpActionResult GetDataTablePublicaciones_TipoDiagramacion()
        {
            DataTableAdapter<Publicaciones_TipoDiagramacion> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_TipoDiagramacionRepository.GetDataTablePublicaciones_TipoDiagramacion(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
