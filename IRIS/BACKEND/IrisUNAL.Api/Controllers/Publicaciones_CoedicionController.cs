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
    public class Publicaciones_CoedicionController : BaseController<Publicaciones_Coedicion>
    {
        private readonly IPublicaciones_CoedicionRepository _publicaciones_CoedicionRepository;
        public Publicaciones_CoedicionController (IPublicaciones_CoedicionRepository publicaciones_CoedicionRepository)
        {
            _publicaciones_CoedicionRepository = publicaciones_CoedicionRepository;
        }
        readonly IPublicaciones_CoedicionRepository publicaciones_CoedicionRepository = new Publicaciones_CoedicionRepository();
        public Publicaciones_CoedicionController()
        {
            _publicaciones_CoedicionRepository = publicaciones_CoedicionRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_Coedicion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_CoedicionRepository.GetAllPublicaciones_Coedicion();

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
        public IHttpActionResult GetPublicaciones_CoedicionDetails(int id_coedicion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_CoedicionRepository.GetPublicaciones_CoedicionDetails(id_coedicion);

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
        public IHttpActionResult GetPublicaciones_CoedicionNumero(string cd_numcontrato)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_CoedicionRepository.GetPublicaciones_CoedicionNumero(cd_numcontrato);

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
        public IHttpActionResult InsertPublicaciones_Coedicion([FromBody] Publicaciones_Coedicion publicaciones_Coedicion)
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

                var created = _publicaciones_CoedicionRepository.InsertPublicaciones_Coedicion(publicaciones_Coedicion);

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
        public IHttpActionResult UpdatePublicaciones_Coedicion([FromBody] Publicaciones_Coedicion publicaciones_Coedicion)
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

                var created = _publicaciones_CoedicionRepository.UpdatePublicaciones_Coedicion(publicaciones_Coedicion);

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
        public IHttpActionResult DeletePublicaciones_Coedicion(int id_coedicion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _publicaciones_CoedicionRepository.DeletePublicaciones_Coedicion(id_coedicion);

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
