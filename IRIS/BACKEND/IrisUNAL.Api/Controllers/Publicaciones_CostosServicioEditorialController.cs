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
    public class Publicaciones_CostosServicioEditorialController : BaseController<Publicaciones_CostosServicioEditorial>
    {
        private readonly IPublicaciones_CostosServicioEditorialRepository _publicaciones_CostosServicioEditorialRepository;
        public Publicaciones_CostosServicioEditorialController(IPublicaciones_CostosServicioEditorialRepository publicaciones_CostosServicioEditorialRepository)
        {
            _publicaciones_CostosServicioEditorialRepository = publicaciones_CostosServicioEditorialRepository;
        }
        readonly IPublicaciones_CostosServicioEditorialRepository publicaciones_CostosServicioEditorialRepository = new Publicaciones_CostosServicioEditorialRepository();
        public Publicaciones_CostosServicioEditorialController()
        {
            _publicaciones_CostosServicioEditorialRepository = publicaciones_CostosServicioEditorialRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_CostosServicioEditorial()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CostosServicioEditorialRepository.GetAllPublicaciones_CostosServicioEditorial();

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
        public IHttpActionResult GetPublicaciones_CostosServicioEditorialDetails(int id_servicioeditorial)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CostosServicioEditorialRepository.GetPublicaciones_CostosServicioEditorialDetails(id_servicioeditorial);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_CostosServicioEditorial inexistente";
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
        public IHttpActionResult GETPublicaciones_CostosServicioEditorialNombre(string cd_nomservicioeditorial)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CostosServicioEditorialRepository.GETPublicaciones_CostosServicioEditorialNombre(cd_nomservicioeditorial);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_CostosServicioEditorial inexistente";
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
        public IHttpActionResult InsertPublicaciones_CostosServicioEditorial([FromBody] Publicaciones_CostosServicioEditorial publicaciones_CostosServicioEditorial)
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

                var created = publicaciones_CostosServicioEditorialRepository.InsertPublicaciones_CostosServicioEditorial(publicaciones_CostosServicioEditorial);

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
        public IHttpActionResult UpdatePublicaciones_CostosServicioEditorial([FromBody] Publicaciones_CostosServicioEditorial publicaciones_CostosServicioEditorial)
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

                var created = publicaciones_CostosServicioEditorialRepository.UpdatePublicaciones_CostosServicioEditorial(publicaciones_CostosServicioEditorial);

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
        public IHttpActionResult DeletePublicaciones_CostosServicioEditorial(int id_servicioeditorial)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_CostosServicioEditorialRepository.DeletePublicaciones_CostosServicioEditorial(id_servicioeditorial);

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
        public IHttpActionResult GetDataTablePublicaciones_CostosServicioEditorial()
        {
            DataTableAdapter<Publicaciones_CostosServicioEditorial> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_CostosServicioEditorialRepository.GetDataTablePublicaciones_CostosServicioEditorial(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
