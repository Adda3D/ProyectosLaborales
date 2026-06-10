using IrisUNAL.Api.Entities.Repositories;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IrisUNAL.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Proyectos_EstadoProductoController : BaseController<Proyectos_EstadoProducto>
    {
        private readonly Proyectos_EstadoProductoRepository _estado_ProductoRepository;

        public Proyectos_EstadoProductoController(Proyectos_EstadoProductoRepository estado_ProductoRepository)
        {
            _estado_ProductoRepository = estado_ProductoRepository;
        }

        readonly Proyectos_EstadoProductoRepository estado_ProductoRepository = new Proyectos_EstadoProductoRepository();
        public Proyectos_EstadoProductoController()
        {
            _estado_ProductoRepository = estado_ProductoRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllProyectos_EstadoProducto()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _estado_ProductoRepository.GetAllProyectos_EstadoProducto();

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
        public IHttpActionResult GetProyectos_EstadoProductoDetails(int id_estadoproducto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _estado_ProductoRepository.GetProyectos_EstadoProductoDetails(id_estadoproducto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Estado producto inexistente";
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
        public IHttpActionResult GetProyectos_EstadoProductoNombre(string cd_estadoproducto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _estado_ProductoRepository.GetProyectos_EstadoProductoNombre(cd_estadoproducto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Estado producto inexistente";
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
        public IHttpActionResult InsertProyectos_EstadoProducto([FromBody] Proyectos_EstadoProducto estadoProducto)
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

                var created = _estado_ProductoRepository.InsertProyectos_EstadoProducto(estadoProducto);

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
        public IHttpActionResult UpdateProyectos_EstadoProducto([FromBody] Proyectos_EstadoProducto estadoProducto)
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

                var created = _estado_ProductoRepository.UpdateProyectos_EstadoProducto(estadoProducto);

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
        public IHttpActionResult DeleteProyectos_EstadoProducto(int id_estadoproducto)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _estado_ProductoRepository.DeleteProyectos_EstadoProducto(id_estadoproducto);

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
        public IHttpActionResult GetDataTableProyectos_EstadoProducto()
        {
            DataTableAdapter<Proyectos_EstadoProducto> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _estado_ProductoRepository.GetDataTableProyectos_EstadoProducto(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
