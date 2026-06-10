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
    public class Publicaciones_DepositoControlActaController : BaseController<Publicaciones_DepositoControlActa>
    {
        private readonly IPublicaciones_DepositoControlActaRepository _publicaciones_DepositoControlActaRepository;
        public Publicaciones_DepositoControlActaController(IPublicaciones_DepositoControlActaRepository publicaciones_DepositoControlActaRepository)
        {
            _publicaciones_DepositoControlActaRepository = publicaciones_DepositoControlActaRepository;
        }
        readonly IPublicaciones_DepositoControlActaRepository publicaciones_DepositoControlActaRepository = new Publicaciones_DepositoControlActaRepository();
        public Publicaciones_DepositoControlActaController()
        {
            _publicaciones_DepositoControlActaRepository = publicaciones_DepositoControlActaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DepositoControlActa()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoControlActaRepository.GetAllPublicaciones_DepositoControlActa();

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
        public IHttpActionResult GetPublicaciones_DepositoControlActaDetails(int id_actacosto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoControlActaRepository.GetPublicaciones_DepositoControlActaDetails(id_actacosto);

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
        public IHttpActionResult GetPublicaciones_DepositoControlActaByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoControlActaRepository.GetPublicaciones_DepositoControlActaByPublicacion(id_crearpublicacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Acta de costos no asignada para la publicación";
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
        public IHttpActionResult InsertPublicaciones_DepositoControlActa([FromBody] Publicaciones_DepositoControlActa publicaciones_DepositoControlActa)
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

                var created = publicaciones_DepositoControlActaRepository.InsertPublicaciones_DepositoControlActa(publicaciones_DepositoControlActa);

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
        public IHttpActionResult UpdatePublicaciones_DepositoControlActa([FromBody] Publicaciones_DepositoControlActa publicaciones_DepositoControlActa)
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

                var created = publicaciones_DepositoControlActaRepository.UpdatePublicaciones_DepositoControlActa(publicaciones_DepositoControlActa);

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
        public IHttpActionResult DeletePublicaciones_DepositoControlActa(int id_actacosto)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DepositoControlActaRepository.DeletePublicaciones_DepositoControlActa(id_actacosto);

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
