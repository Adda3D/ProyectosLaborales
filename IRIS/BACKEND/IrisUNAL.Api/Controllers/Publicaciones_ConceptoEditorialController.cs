using IrisUNAL.Api.Entities.Repositories;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IrisUNAL.Api.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class Publicaciones_ConceptoEditorialController : BaseController<Publicaciones_ConceptoEditorial>
    {
        private readonly IPublicaciones_ConceptoEditorialRepository _publicaciones_ConceptoEditorialRepository;
        public Publicaciones_ConceptoEditorialController(IPublicaciones_ConceptoEditorialRepository publicaciones_ConceptoEditorialRepository)
        {
            _publicaciones_ConceptoEditorialRepository = publicaciones_ConceptoEditorialRepository;
        }
        readonly IPublicaciones_ConceptoEditorialRepository publicaciones_ConceptoEditorialRepository = new Publicaciones_ConceptoEditorialRepository();
        public Publicaciones_ConceptoEditorialController()
        {
            _publicaciones_ConceptoEditorialRepository = publicaciones_ConceptoEditorialRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_ConceptoEditorial()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ConceptoEditorialRepository.GetAllPublicaciones_ConceptoEditorial();

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
        public IHttpActionResult GetPublicaciones_ConceptoEditorialDetails(int id_conceptoeditorial)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ConceptoEditorialRepository.GetPublicaciones_ConceptoEditorialDetails(id_conceptoeditorial);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Concepto editorial inexistente";
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
        public IHttpActionResult GetPublicaciones_ConceptoEditorialByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ConceptoEditorialRepository.GetPublicaciones_ConceptoEditorialByPublicacion(id_crearpublicacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicación no tiene concepto editorial creado";
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
        public IHttpActionResult InsertPublicaciones_ConceptoEditorial([FromBody] Publicaciones_ConceptoEditorial publicaciones_ConceptoEditorial)
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

                var created = publicaciones_ConceptoEditorialRepository.InsertPublicaciones_ConceptoEditorial(publicaciones_ConceptoEditorial);

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
        public IHttpActionResult UpdatePublicaciones_ConceptoEditorial([FromBody] Publicaciones_ConceptoEditorial publicaciones_ConceptoEditorial)
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

                var created = publicaciones_ConceptoEditorialRepository.UpdatePublicaciones_ConceptoEditorial(publicaciones_ConceptoEditorial);

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
        public IHttpActionResult DeletePublicaciones_ConceptoEditorial(int id_conceptoeditorial)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_ConceptoEditorialRepository.DeletePublicaciones_ConceptoEditorial(id_conceptoeditorial);

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
    }
}
