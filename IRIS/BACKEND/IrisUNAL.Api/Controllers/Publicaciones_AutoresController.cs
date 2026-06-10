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
    public class Publicaciones_AutoresController : BaseController<Publicaciones_Autores>
    {
        private readonly IPublicaciones_AutoresRepository _publicaciones_AutoresRepository;
        public Publicaciones_AutoresController(IPublicaciones_AutoresRepository publicaciones_AutoresRepository)
        {
            _publicaciones_AutoresRepository = publicaciones_AutoresRepository;
        }
        readonly IPublicaciones_AutoresRepository publicaciones_AutoresRepository = new Publicaciones_AutoresRepository();
        public Publicaciones_AutoresController()
        {
            _publicaciones_AutoresRepository = publicaciones_AutoresRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_Autores()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_AutoresRepository.GetAllPublicaciones_Autores();

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
        public IHttpActionResult GetPublicaciones_AutoresDetails(int id_autores)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_AutoresRepository.GetPublicaciones_AutoresDetails(id_autores);

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
        public IHttpActionResult GetPublicaciones_AutoresByPublicacionPersona(int id_crearpublicacion, int id_persona)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_AutoresRepository.GetPublicaciones_AutoresByPublicacion(id_crearpublicacion, id_persona);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Persona no asociada a la Publicación ";
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
        public IHttpActionResult InsertPublicaciones_Autores([FromBody] Publicaciones_Autores publicaciones_Autores)
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

                var created = publicaciones_AutoresRepository.InsertPublicaciones_Autores(publicaciones_Autores);

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
        public IHttpActionResult UpdatePublicaciones_Autores([FromBody] Publicaciones_Autores publicaciones_Autores)
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

                var created = publicaciones_AutoresRepository.UpdatePublicaciones_Autores(publicaciones_Autores);

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
        public IHttpActionResult DeletePublicaciones_Autores(int id_autores)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_AutoresRepository.DeletePublicaciones_Autores(id_autores);

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
        public IHttpActionResult GetDataTablePublicaciones_AutoresByPublicacion(int id_crearpublicacion)
        {
            DataTableAdapter<Publicaciones_Autores> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_AutoresRepository.GetDataTablePublicaciones_AutoresByPublicacion(id_crearpublicacion, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetPublicaciones_AutoresDetailsPersona(int id_autores)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_AutoresRepository.GetPublicaciones_AutoresDetailsPersona(id_autores);

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
        public IHttpActionResult UpdatePublicaciones_AutoresLanzamiento([FromBody] Publicaciones_Autores publicaciones_Autores)
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

                var created = publicaciones_AutoresRepository.UpdatePublicaciones_AutoresLanzamiento(publicaciones_Autores);

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
        public IHttpActionResult UpdatePublicaciones_AutoresCierre([FromBody] Publicaciones_Autores publicaciones_Autores)
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

                var created = publicaciones_AutoresRepository.UpdatePublicaciones_AutoresCierre(publicaciones_Autores);

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

    }
}
