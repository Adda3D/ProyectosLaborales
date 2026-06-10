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
    public class RolMenuOpcionesController : BaseController<RolMenuOpciones>
    {
        private readonly IRolMenuOpcionesRepository _rolMenuOpcionesRepository;
        public RolMenuOpcionesController(IRolMenuOpcionesRepository rolMenuOpcionesRepository)
        {
            _rolMenuOpcionesRepository = rolMenuOpcionesRepository;
        }
        readonly IRolMenuOpcionesRepository rolMenuOpcionesRepository = new RolMenuOpcionesRepository();
        public RolMenuOpcionesController()
        {
            _rolMenuOpcionesRepository = rolMenuOpcionesRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllRolMenuOpciones()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _rolMenuOpcionesRepository.GetAllRolMenuOpciones();

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
        public IHttpActionResult GetRolMenuOpcionesDetails(int idrolmenuopciones)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _rolMenuOpcionesRepository.GetRolMenuOpcionesDetails(idrolmenuopciones);

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
        public IHttpActionResult InsertRolMenuOpciones([FromBody] RolMenuOpciones rolMenuOpciones)
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

                var created = _rolMenuOpcionesRepository.InsertRolMenuOpciones(rolMenuOpciones);

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
        public IHttpActionResult UpdateRolMenuOpciones([FromBody] RolMenuOpciones rolMenuOpciones)
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

                var created = _rolMenuOpcionesRepository.UpdateRolMenuOpciones(rolMenuOpciones);

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
        public IHttpActionResult DeleteRolMenuOpciones(int idrolmenuopciones)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _rolMenuOpcionesRepository.DeleteRolMenuOpciones(idrolmenuopciones);

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
