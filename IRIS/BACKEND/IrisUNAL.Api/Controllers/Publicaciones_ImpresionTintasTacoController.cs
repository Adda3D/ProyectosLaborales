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
    public class Publicaciones_ImpresionTintasTacoController : BaseController<Publicaciones_ImpresionTintasTaco>
    {
        private readonly IPublicaciones_ImpresionTintasTacoRepository _publicaciones_ImpresionTintasTacoRepository;
        public Publicaciones_ImpresionTintasTacoController (IPublicaciones_ImpresionTintasTacoRepository publicaciones_ImpresionTintasTacoRepository)
        {
            _publicaciones_ImpresionTintasTacoRepository = publicaciones_ImpresionTintasTacoRepository;
        }
        readonly IPublicaciones_ImpresionTintasTacoRepository publicaciones_ImpresionTintasTacoRepository = new Publicaciones_ImpresionTintasTacoRepository();
        public Publicaciones_ImpresionTintasTacoController()
        {
            _publicaciones_ImpresionTintasTacoRepository = publicaciones_ImpresionTintasTacoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_ImpresionTintasTaco()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ImpresionTintasTacoRepository.GetAllPublicaciones_ImpresionTintasTaco();

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
        public IHttpActionResult GetPublicaciones_ImpresionTintasTacoDetails(int id_tintastaco)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ImpresionTintasTacoRepository.GetPublicaciones_ImpresionTintasTacoDetails(id_tintastaco);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_ImpresionTintasTaco inexistente";
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
        public IHttpActionResult GetPublicaciones_ImpresionTintasTacoNombre(string cd_nmtintastaco)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ImpresionTintasTacoRepository.GetPublicaciones_ImpresionTintasTacoNombre(cd_nmtintastaco);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_ImpresionTintasTaco inexistente";
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
        public IHttpActionResult InsertPublicaciones_ImpresionTintasTaco([FromBody] Publicaciones_ImpresionTintasTaco publicaciones_ImpresionTintasTaco)
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

                var created = publicaciones_ImpresionTintasTacoRepository.InsertPublicaciones_ImpresionTintasTaco(publicaciones_ImpresionTintasTaco);

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
        public IHttpActionResult UpdatePublicaciones_ImpresionTintasTaco([FromBody] Publicaciones_ImpresionTintasTaco publicaciones_ImpresionTintasTaco)
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

                var created = publicaciones_ImpresionTintasTacoRepository.UpdatePublicaciones_ImpresionTintasTaco(publicaciones_ImpresionTintasTaco);

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
        public IHttpActionResult DeletePublicaciones_ImpresionTintasTaco(int id_tintastaco)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_ImpresionTintasTacoRepository.DeletePublicaciones_ImpresionTintasTaco(id_tintastaco);

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
        public IHttpActionResult GetDataTablePublicaciones_ImpresionTintasTaco()
        {
            DataTableAdapter<Publicaciones_ImpresionTintasTaco> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_ImpresionTintasTacoRepository.GetDataTablePublicaciones_ImpresionTintasTaco(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
