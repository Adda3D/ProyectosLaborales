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
    public class Publicaciones_FormatoDistribucionController : BaseController<Publicaciones_FormatoDistribucion>
    {
        private readonly IPublicaciones_FormatoDistribucionRepository _publicaciones_FormatoDistribucionRepository;
        public Publicaciones_FormatoDistribucionController(IPublicaciones_FormatoDistribucionRepository publicaciones_FormatoDistribucionRepository)
        {
            _publicaciones_FormatoDistribucionRepository = publicaciones_FormatoDistribucionRepository;
        }
        readonly IPublicaciones_FormatoDistribucionRepository publicaciones_FormatoDistribucionRepository = new Publicaciones_FormatoDistribucionRepository();
        public Publicaciones_FormatoDistribucionController()
        {
            _publicaciones_FormatoDistribucionRepository = publicaciones_FormatoDistribucionRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_FormatoDistribucion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_FormatoDistribucionRepository.GetAllPublicaciones_FormatoDistribucion();

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
        public IHttpActionResult GetPublicaciones_FormatoDistribucionDetails(int id_formatodistribucion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_FormatoDistribucionRepository.GetPublicaciones_FormatoDistribucionDetails(id_formatodistribucion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_FormatoDistribucion inexistente";
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
        public IHttpActionResult GetPublicaciones_FormatoDistribucionNombre(string cd_nmformatodis)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_FormatoDistribucionRepository.GetPublicaciones_FormatoDistribucionNombre(cd_nmformatodis);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_FormatoDistribucion inexistente";
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
        public IHttpActionResult InsertPublicaciones_FormatoDistribucion([FromBody] Publicaciones_FormatoDistribucion publicaciones_FormatoDistribucion)
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

                var created = publicaciones_FormatoDistribucionRepository.InsertPublicaciones_FormatoDistribucion(publicaciones_FormatoDistribucion);

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
        public IHttpActionResult UpdatePublicaciones_FormatoDistribucion([FromBody] Publicaciones_FormatoDistribucion publicaciones_FormatoDistribucion)
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

                var created = publicaciones_FormatoDistribucionRepository.UpdatePublicaciones_FormatoDistribucion(publicaciones_FormatoDistribucion);

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
        public IHttpActionResult DeletePublicaciones_FormatoDistribucion(int id_formatodistribucion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_FormatoDistribucionRepository.DeletePublicaciones_FormatoDistribucion(id_formatodistribucion);

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
        public IHttpActionResult GetDataTablePublicaciones_FormatoDistribucion()
        {
            DataTableAdapter<Publicaciones_FormatoDistribucion> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_FormatoDistribucionRepository.GetDataTablePublicaciones_FormatoDistribucion(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
