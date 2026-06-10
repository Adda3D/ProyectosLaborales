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
    public class Publicaciones_ImpresionController : BaseController<Publicaciones_Impresion>
    {
        private readonly IPublicaciones_ImpresionRepository _publicaciones_ImpresionRepository;
        public Publicaciones_ImpresionController(IPublicaciones_ImpresionRepository publicaciones_ImpresionRepository)
        {
            _publicaciones_ImpresionRepository = publicaciones_ImpresionRepository;
        }
        readonly IPublicaciones_ImpresionRepository publicaciones_ImpresionRepository = new Publicaciones_ImpresionRepository();
        public Publicaciones_ImpresionController()
        {
            _publicaciones_ImpresionRepository = publicaciones_ImpresionRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_Impresion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ImpresionRepository.GetAllPublicaciones_Impresion();

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
        public IHttpActionResult GetPublicaciones_ImpresionDetails(int id_impresion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ImpresionRepository.GetPublicaciones_ImpresionDetails(id_impresion);

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
        public IHttpActionResult GetPublicaciones_ImpresionByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ImpresionRepository.GetPublicaciones_ImpresionByPublicacion(id_crearpublicacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Definición impresión no asignada a la publicación";
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
        public IHttpActionResult InsertPublicaciones_Impresion([FromBody] Publicaciones_Impresion publicaciones_Impresion)
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

                var created = publicaciones_ImpresionRepository.InsertPublicaciones_Impresion(publicaciones_Impresion);

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
        public IHttpActionResult UpdatePublicaciones_Impresion([FromBody] Publicaciones_Impresion publicaciones_Impresion)
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

                var created = publicaciones_ImpresionRepository.UpdatePublicaciones_Impresion(publicaciones_Impresion);

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
        public IHttpActionResult DeletePublicaciones_Impresion(int id_impresion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_ImpresionRepository.DeletePublicaciones_Impresion(id_impresion);

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
