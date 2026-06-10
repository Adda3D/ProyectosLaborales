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
    public class Publicaciones_OrigenManuscritoController : BaseController<Publicaciones_OrigenManuscrito>
    {
        private readonly IPublicaciones_OrigenManuscritoRepository _publicaciones_OrigenManuscritoRepository;
        public Publicaciones_OrigenManuscritoController (IPublicaciones_OrigenManuscritoRepository publicaciones_OrigenManuscritoRepository)
        {
            _publicaciones_OrigenManuscritoRepository = publicaciones_OrigenManuscritoRepository;
        }
        readonly IPublicaciones_OrigenManuscritoRepository publicaciones_OrigenManuscritoRepository = new Publicaciones_OrigenManuscritoRepository();
        public Publicaciones_OrigenManuscritoController()
        {
            _publicaciones_OrigenManuscritoRepository = publicaciones_OrigenManuscritoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_OrigenManuscrito()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_OrigenManuscritoRepository.GetAllPublicaciones_OrigenManuscrito();

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
        public IHttpActionResult GetPublicaciones_OrigenManuscritoDetails(int id_origenmanuscrito)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_OrigenManuscritoRepository.GetPublicaciones_OrigenManuscritoDetails(id_origenmanuscrito);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_OrigenManuscrito inexistente";
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
        public IHttpActionResult GetPublicaciones_OrigenManuscritoNombre(string cd_nmorigenmanuscrito)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_OrigenManuscritoRepository.GetPublicaciones_OrigenManuscritoNombre(cd_nmorigenmanuscrito);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_OrigenManuscrito inexistente";
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
        public IHttpActionResult InsertPublicaciones_OrigenManuscrito([FromBody] Publicaciones_OrigenManuscrito publicaciones_OrigenManuscrito)
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

                var created = publicaciones_OrigenManuscritoRepository.InsertPublicaciones_OrigenManuscrito(publicaciones_OrigenManuscrito);

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
        public IHttpActionResult UpdatePublicaciones_OrigenManuscrito([FromBody] Publicaciones_OrigenManuscrito publicaciones_OrigenManuscrito)
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

                var created = publicaciones_OrigenManuscritoRepository.UpdatePublicaciones_OrigenManuscrito(publicaciones_OrigenManuscrito);

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
        public IHttpActionResult DeletePublicaciones_OrigenManuscrito(int id_origenmanuscrito)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_OrigenManuscritoRepository.DeletePublicaciones_OrigenManuscrito(id_origenmanuscrito);

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
        public IHttpActionResult GetDataTablePublicaciones_OrigenManuscrito()
        {
            DataTableAdapter<Publicaciones_OrigenManuscrito> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_OrigenManuscritoRepository.GetDataTablePublicaciones_OrigenManuscrito(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
