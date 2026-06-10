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
    public class Publicaciones_ProveedorServicioController : BaseController<Publicaciones_ProveedorServicio>
    {
        private readonly IPublicaciones_ProveedorServicioRepository _publicaciones_ProveedorServicioRepository;
        public Publicaciones_ProveedorServicioController(IPublicaciones_ProveedorServicioRepository publicaciones_ProveedorServicioRepository)
        {
            _publicaciones_ProveedorServicioRepository = publicaciones_ProveedorServicioRepository;
        }
        readonly IPublicaciones_ProveedorServicioRepository publicaciones_ProveedorServicioRepository = new Publicaciones_ProveedorServicioRepository();
        public Publicaciones_ProveedorServicioController()
        {
            _publicaciones_ProveedorServicioRepository = publicaciones_ProveedorServicioRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_ProveedorServicio()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ProveedorServicioRepository.GetAllPublicaciones_ProveedorServicio();

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
        public IHttpActionResult GetPublicaciones_ProveedorServicioDetails(int id_proveedorservicio)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ProveedorServicioRepository.GetPublicaciones_ProveedorServicioDetails(id_proveedorservicio);

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
        public IHttpActionResult GetPublicaciones_ProveedorServicioNombre(string cd_nombreproveedor)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ProveedorServicioRepository.GetPublicaciones_ProveedorServicioNombre(cd_nombreproveedor);

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
        public IHttpActionResult InsertPublicaciones_ProveedorServicio([FromBody] Publicaciones_ProveedorServicio publicaciones_ProveedorServicio)
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

                var created = publicaciones_ProveedorServicioRepository.InsertPublicaciones_ProveedorServicio(publicaciones_ProveedorServicio);

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
        public IHttpActionResult UpdatePublicaciones_ProveedorServicio([FromBody] Publicaciones_ProveedorServicio publicaciones_ProveedorServicio)
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

                var created = publicaciones_ProveedorServicioRepository.UpdatePublicaciones_ProveedorServicio(publicaciones_ProveedorServicio);

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
        public IHttpActionResult DeletePublicaciones_ProveedorServicio(int id_proveedorservicio)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_ProveedorServicioRepository.DeletePublicaciones_ProveedorServicio(id_proveedorservicio);

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
