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
    public class Publicaciones_DivulgacionMaillingController : BaseController<Publicaciones_DivulgacionMailling>
    {
        private readonly IPublicaciones_DivulgacionMaillingRepository _publicaciones_DivulgacionMaillingRepository;
        public Publicaciones_DivulgacionMaillingController(IPublicaciones_DivulgacionMaillingRepository publicaciones_DivulgacionMaillingRepository)
        {
            _publicaciones_DivulgacionMaillingRepository = publicaciones_DivulgacionMaillingRepository;
        }
        readonly IPublicaciones_DivulgacionMaillingRepository publicaciones_DivulgacionMaillingRepository = new Publicaciones_DivulgacionMaillingRepository();
        public Publicaciones_DivulgacionMaillingController()
        {
            _publicaciones_DivulgacionMaillingRepository = publicaciones_DivulgacionMaillingRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DivulgacionMailling()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionMaillingRepository.GetAllPublicaciones_DivulgacionMailling();

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
        public IHttpActionResult GetPublicaciones_DivulgacionMaillingDetails(int id_mailling)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionMaillingRepository.GetPublicaciones_DivulgacionMaillingDetails(id_mailling);

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
        public IHttpActionResult GetPublicaciones_DivulgacionMaillingCodigo(string cd_id_kardex)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionMaillingRepository.GetPublicaciones_DivulgacionMaillingCodigo(cd_id_kardex);

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
        public IHttpActionResult InsertPublicaciones_DivulgacionMailling([FromBody] Publicaciones_DivulgacionMailling publicaciones_DivulgacionMailling)
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

                var created = publicaciones_DivulgacionMaillingRepository.InsertPublicaciones_DivulgacionMailling(publicaciones_DivulgacionMailling);

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
        public IHttpActionResult UpdatePublicaciones_DivulgacionMailling([FromBody] Publicaciones_DivulgacionMailling publicaciones_DivulgacionMailling)
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

                var created = publicaciones_DivulgacionMaillingRepository.UpdatePublicaciones_DivulgacionMailling(publicaciones_DivulgacionMailling);

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
        public IHttpActionResult DeletePublicaciones_DivulgacionMailling(int id_mailling)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DivulgacionMaillingRepository.DeletePublicaciones_DivulgacionMailling(id_mailling);

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
