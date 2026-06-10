using IrisUNAL.Api.Entities.Repositories.Publicacion;
using IrisUNAL.Api.Models.Publicacion;
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

namespace IrisUNAL.Api.Controllers.Publicacion
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Publicaciones_EstadoManuscritoController : BaseController<Publicaciones_EstadoManuscrito>
    {
        private readonly Publicaciones_EstadoManuscritoRepository _publicaciones_EstadoManuscritoRepository;
        public Publicaciones_EstadoManuscritoController(Publicaciones_EstadoManuscritoRepository publicaciones_EstadoManuscritoRepository)
        {
            _publicaciones_EstadoManuscritoRepository = publicaciones_EstadoManuscritoRepository;
        }
        readonly Publicaciones_EstadoManuscritoRepository publicaciones_EstadoManuscritoRepository = new Publicaciones_EstadoManuscritoRepository();
        public Publicaciones_EstadoManuscritoController()
        {
            _publicaciones_EstadoManuscritoRepository = publicaciones_EstadoManuscritoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_EstadoManuscrito()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_EstadoManuscritoRepository.GetAllPublicaciones_EstadoManuscrito();

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
        public IHttpActionResult GetPublicaciones_EstadoManuscritoDetails(int idestadomanuscrito)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_EstadoManuscritoRepository.GetPublicaciones_EstadoManuscritoDetails(idestadomanuscrito);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Estado inexistente";
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
        public IHttpActionResult GetPublicaciones_EstadoManuscritoNombre(string cd_estadomanuscrito)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_EstadoManuscritoRepository.GetPublicaciones_EstadoManuscritoNombre(cd_estadomanuscrito);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Estado inexistente";
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
        public IHttpActionResult InsertPublicaciones_EstadoManuscrito([FromBody] Publicaciones_EstadoManuscrito publicaciones_EstadoManuscrito)
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

                var created = _publicaciones_EstadoManuscritoRepository.InsertPublicaciones_EstadoManuscrito(publicaciones_EstadoManuscrito);

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
        public IHttpActionResult UpdatePublicaciones_EstadoManuscrito([FromBody] Publicaciones_EstadoManuscrito publicaciones_EstadoManuscrito)
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

                var created = _publicaciones_EstadoManuscritoRepository.UpdatePublicaciones_EstadoManuscrito(publicaciones_EstadoManuscrito);

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
        public IHttpActionResult DeletePublicaciones_EstadoManuscrito(int idestadomanuscrito)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _publicaciones_EstadoManuscritoRepository.DeletePublicaciones_EstadoManuscrito(idestadomanuscrito);

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
        public IHttpActionResult GetDataTablePublicaciones_EstadoManuscrito()
        {
            DataTableAdapter<Publicaciones_EstadoManuscrito> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _publicaciones_EstadoManuscritoRepository.GetDataTablePublicaciones_EstadoManuscrito(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
