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
    public class Publicaciones_ImpresionPapelController : BaseController<Publicaciones_ImpresionPapel>
    {
        private IPublicaciones_ImpresionPapelRepository _publicaciones_ImpresionPapelRepository;
        public Publicaciones_ImpresionPapelController(IPublicaciones_ImpresionPapelRepository publicaciones_ImpresionPapelRepository)
        {
            _publicaciones_ImpresionPapelRepository = publicaciones_ImpresionPapelRepository;
        }
        readonly IPublicaciones_ImpresionPapelRepository publicaciones_ImpresionPapelRepository = new Publicaciones_ImpresionPapelRepository();
        public Publicaciones_ImpresionPapelController()
        {
            _publicaciones_ImpresionPapelRepository = publicaciones_ImpresionPapelRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_ImpresionPapel()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ImpresionPapelRepository.GetAllPublicaciones_ImpresionPapel();

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
        public IHttpActionResult GetPublicaciones_ImpresionPapelDetails(int id_papel)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ImpresionPapelRepository.GetPublicaciones_ImpresionPapelDetails(id_papel);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_ImpresionPapel inexistente";
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
        public IHttpActionResult GetPublicaciones_ImpresionPapelNombre(string cd_nmpapel)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ImpresionPapelRepository.GetPublicaciones_ImpresionPapelNombre(cd_nmpapel);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_ImpresionPapel inexistente";
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
        public IHttpActionResult InsertPublicaciones_ImpresionPapel([FromBody] Publicaciones_ImpresionPapel publicaciones_ImpresionPapel)
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

                var created = publicaciones_ImpresionPapelRepository.InsertPublicaciones_ImpresionPapel(publicaciones_ImpresionPapel);

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
        public IHttpActionResult UpdatePublicaciones_ImpresionPapel([FromBody] Publicaciones_ImpresionPapel publicaciones_ImpresionPapel)
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

                var created = publicaciones_ImpresionPapelRepository.UpdatePublicaciones_ImpresionPapel(publicaciones_ImpresionPapel);

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
        public IHttpActionResult DeletePublicaciones_ImpresionPapel(int id_papel)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_ImpresionPapelRepository.DeletePublicaciones_ImpresionPapel(id_papel);

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
        public IHttpActionResult GetDataTablePublicaciones_ImpresionPapel()
        {
            DataTableAdapter<Publicaciones_ImpresionPapel> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_ImpresionPapelRepository.GetDataTablePublicaciones_ImpresionPapel(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
