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
    public class Publicaciones_DivulgacionMediosController : BaseController<Publicaciones_DivulgacionMedios>
    {
        private readonly IPublicaciones_DivulgacionMediosRepository _publicaciones_DivulgacionMediosRepository;
        public Publicaciones_DivulgacionMediosController(IPublicaciones_DivulgacionMediosRepository publicaciones_DivulgacionMediosRepository)
        {
            _publicaciones_DivulgacionMediosRepository = publicaciones_DivulgacionMediosRepository;
        }
        readonly IPublicaciones_DivulgacionMediosRepository publicaciones_DivulgacionMediosRepository = new Publicaciones_DivulgacionMediosRepository();
        public Publicaciones_DivulgacionMediosController()
        {
            _publicaciones_DivulgacionMediosRepository = publicaciones_DivulgacionMediosRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DivulgacionMedios()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionMediosRepository.GetAllPublicaciones_DivulgacionMedios();

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
        public IHttpActionResult GetPublicaciones_DivulgacionMediosDetails(int id_medio)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionMediosRepository.GetPublicaciones_DivulgacionMediosDetails(id_medio);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Medio inexistente";
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
        public IHttpActionResult GetPublicaciones_DivulgacionMediosNombre(string cd_nommedio)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionMediosRepository.GetPublicaciones_DivulgacionMediosNombre(cd_nommedio);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Medio inexistente";
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
        public IHttpActionResult InsertPublicaciones_DivulgacionMedios([FromBody] Publicaciones_DivulgacionMedios publicaciones_DivulgacionMedios)
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

                var created = publicaciones_DivulgacionMediosRepository.InsertPublicaciones_DivulgacionMedios(publicaciones_DivulgacionMedios);

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
        public IHttpActionResult UpdatePublicaciones_DivulgacionMedios([FromBody] Publicaciones_DivulgacionMedios publicaciones_DivulgacionMedios)
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

                var created = publicaciones_DivulgacionMediosRepository.UpdatePublicaciones_DivulgacionMedios(publicaciones_DivulgacionMedios);

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
        public IHttpActionResult DeletePublicaciones_DivulgacionMedios(int id_medio)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DivulgacionMediosRepository.DeletePublicaciones_DivulgacionMedios(id_medio);

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
        public IHttpActionResult GetDataTablePublicaciones_DivulgacionMedios()
        {
            DataTableAdapter<Publicaciones_DivulgacionMedios> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_DivulgacionMediosRepository.GetDataTablePublicaciones_DivulgacionMedios(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
