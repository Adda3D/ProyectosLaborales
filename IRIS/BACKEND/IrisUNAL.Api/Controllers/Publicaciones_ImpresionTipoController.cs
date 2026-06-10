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
    public class Publicaciones_ImpresionTipoController : BaseController<Publicaciones_ImpresionTipo>
    {
        private readonly IPublicaciones_ImpresionTipoRepository _publicaciones_ImpresionTipoRepository;
        public Publicaciones_ImpresionTipoController(IPublicaciones_ImpresionTipoRepository publicaciones_ImpresionTipoRepository)
        {
            _publicaciones_ImpresionTipoRepository = publicaciones_ImpresionTipoRepository;
        }
        readonly IPublicaciones_ImpresionTipoRepository publicaciones_ImpresionTipoRepository = new Publicaciones_ImpresionTipoRepository();
        public Publicaciones_ImpresionTipoController()
        {
            _publicaciones_ImpresionTipoRepository = publicaciones_ImpresionTipoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_ImpresionTipo()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ImpresionTipoRepository.GetAllPublicaciones_ImpresionTipo();

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
        public IHttpActionResult GetPublicaciones_ImpresionTipoDetails(int id_impresiontipo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ImpresionTipoRepository.GetPublicaciones_ImpresionTipoDetails(id_impresiontipo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_ImpresionTipo inexistente";
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
        public IHttpActionResult GetPublicaciones_ImpresionTipoNombre(string cd_nmimpresiontipo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ImpresionTipoRepository.GetPublicaciones_ImpresionTipoNombre(cd_nmimpresiontipo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_ImpresionTipo inexistente";
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
        public IHttpActionResult InsertPublicaciones_ImpresionTipo([FromBody] Publicaciones_ImpresionTipo publicaciones_ImpresionTipo)
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

                var created = publicaciones_ImpresionTipoRepository.InsertPublicaciones_ImpresionTipo(publicaciones_ImpresionTipo);

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
        public IHttpActionResult UpdatePublicaciones_ImpresionTipo([FromBody] Publicaciones_ImpresionTipo publicaciones_ImpresionTipo)
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

                var created = publicaciones_ImpresionTipoRepository.UpdatePublicaciones_ImpresionTipo(publicaciones_ImpresionTipo);

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
        public IHttpActionResult DeletePublicaciones_ImpresionTipo(int id_impresiontipo)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_ImpresionTipoRepository.DeletePublicaciones_ImpresionTipo(id_impresiontipo);

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
        public IHttpActionResult GetDataTablePublicaciones_ImpresionTipo()
        {
            DataTableAdapter<Publicaciones_ImpresionTipo> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_ImpresionTipoRepository.GetDataTablePublicaciones_ImpresionTipo(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
