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
    public class Publicaciones_ImpresionEncuadernacionController : BaseController<Publicaciones_ImpresionEncuadernacion>
    {
        private readonly IPublicaciones_ImpresionEncuadernacionRepository _publicaciones_ImpresionEncuadernacionRepository;
        public Publicaciones_ImpresionEncuadernacionController(IPublicaciones_ImpresionEncuadernacionRepository publicaciones_ImpresionEncuadernacionRepository)
        {
            _publicaciones_ImpresionEncuadernacionRepository = publicaciones_ImpresionEncuadernacionRepository;
        }
        readonly IPublicaciones_ImpresionEncuadernacionRepository publicaciones_ImpresionEncuadernacionRepository = new Publicaciones_ImpresionEncuadernacionRepository();
        public Publicaciones_ImpresionEncuadernacionController()
        {
            _publicaciones_ImpresionEncuadernacionRepository = publicaciones_ImpresionEncuadernacionRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_ImpresionEncuadernacion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ImpresionEncuadernacionRepository.GetAllPublicaciones_ImpresionEncuadernacion();

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
        public IHttpActionResult GetPublicaciones_ImpresionEncuadernacionDetails(int id_encuadernacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ImpresionEncuadernacionRepository.GetPublicaciones_ImpresionEncuadernacionDetails(id_encuadernacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_ImpresionEncuadernacion inexistente";
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
        public IHttpActionResult GetPublicaciones_ImpresionEncuadernacionNombre(string cd_nmencuadernacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ImpresionEncuadernacionRepository.GetPublicaciones_ImpresionEncuadernacionNombre(cd_nmencuadernacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_ImpresionEncuadernacion inexistente";
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
        public IHttpActionResult InsertPublicaciones_ImpresionEncuadernacion([FromBody] Publicaciones_ImpresionEncuadernacion publicaciones_ImpresionEncuadernacion)
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

                var created = publicaciones_ImpresionEncuadernacionRepository.InsertPublicaciones_ImpresionEncuadernacion(publicaciones_ImpresionEncuadernacion);

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
        public IHttpActionResult UpdatePublicaciones_ImpresionEncuadernacion([FromBody] Publicaciones_ImpresionEncuadernacion publicaciones_ImpresionEncuadernacion)
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

                var created = publicaciones_ImpresionEncuadernacionRepository.UpdatePublicaciones_ImpresionEncuadernacion(publicaciones_ImpresionEncuadernacion);

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
        public IHttpActionResult DeletePublicaciones_ImpresionEncuadernacion(int id_encuadernacion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_ImpresionEncuadernacionRepository.DeletePublicaciones_ImpresionEncuadernacion(id_encuadernacion);

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
        public IHttpActionResult GetDataTablePublicaciones_ImpresionEncuadernacion()
        {
            DataTableAdapter<Publicaciones_ImpresionEncuadernacion> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_ImpresionEncuadernacionRepository.GetDataTablePublicaciones_ImpresionEncuadernacion(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
