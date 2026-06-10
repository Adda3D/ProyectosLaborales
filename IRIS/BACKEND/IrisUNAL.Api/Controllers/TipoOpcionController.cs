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
    public class TipoOpcionController : BaseController<TipoOpcion>
    {
        private readonly ITipoOpcionRepository _tipoOpcionRepository;
        public TipoOpcionController(ITipoOpcionRepository tipoOpcionRepository)
        {
            _tipoOpcionRepository = tipoOpcionRepository;
        }
        readonly ITipoOpcionRepository tipoOpcionRepository = new TipoOpcionRepository();
        public TipoOpcionController()
        {
            _tipoOpcionRepository = tipoOpcionRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllTipoOpcion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _tipoOpcionRepository.GetAllTipoOpcion();

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
        public IHttpActionResult GetTipoOpcionDetails(int idopcion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _tipoOpcionRepository.GetTipoOpcionDetails(idopcion);

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
        public IHttpActionResult GetTipoOpcionNombre(string cd_nombreopcion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _tipoOpcionRepository.GetTipoOpcionNombre(cd_nombreopcion);

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
        public IHttpActionResult InsertTipoOpcion([FromBody] TipoOpcion tipoOpcion)
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

                var created = _tipoOpcionRepository.InsertTipoOpcion(tipoOpcion);

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
        public IHttpActionResult UpdateTipoOpcion([FromBody] TipoOpcion tipoOpcion)
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

                var created = _tipoOpcionRepository.UpdateTipoOpcion(tipoOpcion);

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
        public IHttpActionResult DeleteTipoOpcion(int idopcion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _tipoOpcionRepository.DeleteTipoOpcion(idopcion);

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
