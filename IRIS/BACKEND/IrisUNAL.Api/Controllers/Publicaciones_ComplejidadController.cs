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
    public class Publicaciones_ComplejidadController : BaseController<Publicaciones_Complejidad>
    {
        private readonly IPublicaciones_ComplejidadRepository _publicaciones_ComplejidadRepository;
        public Publicaciones_ComplejidadController(IPublicaciones_ComplejidadRepository publicaciones_ComplejidadRepository)
        {
            _publicaciones_ComplejidadRepository = publicaciones_ComplejidadRepository;
        }
        readonly IPublicaciones_ComplejidadRepository publicaciones_ComplejidadRepository = new Publicaciones_ComplejidadRepository();
        public Publicaciones_ComplejidadController()
        {
            _publicaciones_ComplejidadRepository = publicaciones_ComplejidadRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_Complejidad()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_ComplejidadRepository.GetAllPublicaciones_Complejidad();

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
        public IHttpActionResult GetPublicaciones_ComplejidadDetails(int id_complejidad)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_ComplejidadRepository.GetPublicaciones_ComplejidadDetails(id_complejidad);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_Complejidad inexistente";
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
        public IHttpActionResult GetPublicaciones_ComplejidadNombre(string cd_nmcomplejidad)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_ComplejidadRepository.GetPublicaciones_ComplejidadNombre(cd_nmcomplejidad);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_Complejidad inexistente";
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
        public IHttpActionResult InsertPublicaciones_Complejidad([FromBody] Publicaciones_Complejidad publicaciones_Complejidad)
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

                var created = _publicaciones_ComplejidadRepository.InsertPublicaciones_Complejidad(publicaciones_Complejidad);

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
        public IHttpActionResult UpdatePublicaciones_Complejidad([FromBody] Publicaciones_Complejidad publicaciones_Complejidad)
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

                var created = _publicaciones_ComplejidadRepository.UpdatePublicaciones_Complejidad(publicaciones_Complejidad);

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
        public IHttpActionResult DeletePublicaciones_Complejidad(int id_complejidad)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _publicaciones_ComplejidadRepository.DeletePublicaciones_Complejidad(id_complejidad);

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
        public IHttpActionResult GetDataTablePublicaciones_Complejidad()
        {
            DataTableAdapter<Publicaciones_Complejidad> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_ComplejidadRepository.GetDataTablePublicaciones_Complejidad(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
