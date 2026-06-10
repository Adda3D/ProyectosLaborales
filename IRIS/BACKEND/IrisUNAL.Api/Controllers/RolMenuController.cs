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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RolMenuController : BaseController<RolMenu>
    {
        private readonly IRolMenuRepository _rolMenuRepository;

        public RolMenuController(IRolMenuRepository rolMenuRepository)
        {
            _rolMenuRepository = rolMenuRepository;
        }

        readonly IRolMenuRepository rolMenuRepository = new RolMenuRepository();
        public RolMenuController()
        {
            _rolMenuRepository = rolMenuRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllRolMenu()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _rolMenuRepository.GetAllRolMenu();

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
        public IHttpActionResult GetRolMenuDetails(int id_rolmenu)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _rolMenuRepository.GetRolMenuDetails(id_rolmenu);

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
        public IHttpActionResult InsertRolMenu([FromBody] RolMenu rolMenu)
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

                var created = _rolMenuRepository.InsertRolMenu(rolMenu);

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
        public IHttpActionResult UpdateRolMenu([FromBody] RolMenu rolMenu)
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

                var created = _rolMenuRepository.UpdateRolMenu(rolMenu);

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
        public IHttpActionResult DeleteRolMenu(int id_rolmenu)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _rolMenuRepository.DeleteRolMenu(id_rolmenu);

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
        public IHttpActionResult UpdateAccesoRol([FromBody] List<AccesoOpcion> acceso)
        {
            var resultdb = new ResultObject();

            try
            {
                var created = _rolMenuRepository.UpdateAccesoRol(acceso);

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
