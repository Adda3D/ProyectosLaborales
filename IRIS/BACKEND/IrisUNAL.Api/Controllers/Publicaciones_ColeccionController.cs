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
    public class Publicaciones_ColeccionController : BaseController<Publicaciones_Coleccion>
    {
        private readonly IPublicaciones_ColeccionRepository _publicaciones_ColeccionRepository;
        public Publicaciones_ColeccionController(IPublicaciones_ColeccionRepository publicaciones_ColeccionRepository)
        {
            _publicaciones_ColeccionRepository = publicaciones_ColeccionRepository;
        }
        readonly IPublicaciones_ColeccionRepository publicaciones_ColeccionRepository = new Publicaciones_ColeccionRepository();
        public Publicaciones_ColeccionController()
        {
            _publicaciones_ColeccionRepository = publicaciones_ColeccionRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_Coleccion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_ColeccionRepository.GetAllPublicaciones_Coleccion();

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
        public IHttpActionResult GetPublicaciones_ColeccionDetails(int id_coleccion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_ColeccionRepository.GetPublicaciones_ColeccionDetails(id_coleccion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_Coleccion inexistente";
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
        public IHttpActionResult GetPublicaciones_ColeccionNombre(string cd_nmcoleccion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_ColeccionRepository.GetPublicaciones_ColeccionNombre(cd_nmcoleccion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_Coleccion inexistente";
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
        public IHttpActionResult GetPublicaciones_ColeccionConsecutivo(int id_coleccion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_ColeccionRepository.GetPublicaciones_ColeccionConsecutivo(id_coleccion);

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

        [HttpPost]
        public IHttpActionResult InsertPublicaciones_Coleccion([FromBody] Publicaciones_Coleccion publicaciones_Coleccion)
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

                var created = _publicaciones_ColeccionRepository.InsertPublicaciones_Coleccion(publicaciones_Coleccion);

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
        public IHttpActionResult UpdatePublicaciones_Coleccion([FromBody] Publicaciones_Coleccion publicaciones_Coleccion)
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

                var created = _publicaciones_ColeccionRepository.UpdatePublicaciones_Coleccion(publicaciones_Coleccion);

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
        public IHttpActionResult DeletePublicaciones_Coleccion(int id_coleccion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _publicaciones_ColeccionRepository.DeletePublicaciones_Coleccion(id_coleccion);

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
        public IHttpActionResult GetDataTablePublicaciones_Coleccion()
        {
            DataTableAdapter<Publicaciones_Coleccion> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_ColeccionRepository.GetDataTablePublicaciones_Coleccion(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
