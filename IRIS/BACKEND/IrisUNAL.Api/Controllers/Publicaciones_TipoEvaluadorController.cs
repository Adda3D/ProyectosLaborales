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
    public class Publicaciones_TipoEvaluadorController : BaseController<Publicaciones_TipoEvaluador>
    {
        private readonly IPublicaciones_TipoEvaluadorRepository _publicaciones_TipoEvaluadorRepository;
        public Publicaciones_TipoEvaluadorController(IPublicaciones_TipoEvaluadorRepository publicaciones_TipoEvaluadorRepository)
        {
            _publicaciones_TipoEvaluadorRepository = publicaciones_TipoEvaluadorRepository;
        }
        readonly IPublicaciones_TipoEvaluadorRepository publicaciones_TipoEvaluadorRepository = new Publicaciones_TipoEvaluadorRepository();
        public Publicaciones_TipoEvaluadorController()
        {
            _publicaciones_TipoEvaluadorRepository = publicaciones_TipoEvaluadorRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_TipoEvaluador()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_TipoEvaluadorRepository.GetAllPublicaciones_TipoEvaluador();

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
        public IHttpActionResult GetPublicaciones_TipoEvaluadorDetails(int id_tipoevaluador)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_TipoEvaluadorRepository.GetPublicaciones_TipoEvaluadorDetails(id_tipoevaluador);

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
        public IHttpActionResult InsertPublicaciones_TipoEvaluador([FromBody] Publicaciones_TipoEvaluador publicaciones_TipoEvaluador)
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

                var created = publicaciones_TipoEvaluadorRepository.InsertPublicaciones_TipoEvaluador(publicaciones_TipoEvaluador);

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
        public IHttpActionResult UpdatePublicaciones_TipoEvaluador([FromBody] Publicaciones_TipoEvaluador publicaciones_TipoEvaluador)
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

                var created = publicaciones_TipoEvaluadorRepository.UpdatePublicaciones_TipoEvaluador(publicaciones_TipoEvaluador);

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
        public IHttpActionResult DeletePublicaciones_TipoEvaluador(int id_tipoevaluador)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_TipoEvaluadorRepository.DeletePublicaciones_TipoEvaluador(id_tipoevaluador);

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
