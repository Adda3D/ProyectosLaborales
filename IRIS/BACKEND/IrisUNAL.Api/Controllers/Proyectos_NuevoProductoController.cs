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
    public class Proyectos_NuevoProductoController : BaseController<Proyectos_NuevoProducto>
    {
        private readonly IProyectos_NuevoProductoRepository _proyectos_NuevoProductoRepository;

        public Proyectos_NuevoProductoController(IProyectos_NuevoProductoRepository proyectos_NuevoProductoRepository)
        {
            _proyectos_NuevoProductoRepository = proyectos_NuevoProductoRepository;
        }

        readonly IProyectos_NuevoProductoRepository proyectos_NuevoProductoRepository = new Proyectos_NuevoProductoRepository();
        public Proyectos_NuevoProductoController()
        {
            _proyectos_NuevoProductoRepository = proyectos_NuevoProductoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllProyectos_NuevoProducto()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_NuevoProductoRepository.GetAllProyectos_NuevoProducto();

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
        public IHttpActionResult GetProyectos_NuevoProductoDetails(int id_nuevoproducto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _proyectos_NuevoProductoRepository.GetProyectos_NuevoProductoDetails(id_nuevoproducto);

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
        public IHttpActionResult InsertProyectos_NuevoProducto([FromBody] Proyectos_NuevoProducto proyectos_NuevoProducto)
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

                var created = _proyectos_NuevoProductoRepository.InsertProyectos_NuevoProducto(proyectos_NuevoProducto);

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
        public IHttpActionResult UpdateProyectos_NuevoProducto([FromBody] Proyectos_NuevoProducto proyectos_NuevoProducto)
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

                var created = _proyectos_NuevoProductoRepository.UpdateProyectos_NuevoProducto(proyectos_NuevoProducto);

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
        public IHttpActionResult DeleteProyectos_NuevoProducto(int id_nuevoproducto)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _proyectos_NuevoProductoRepository.DeleteProyectos_NuevoProducto(id_nuevoproducto);

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
        public IHttpActionResult GetDataTableProyectos_ProductosByProyecto(int id_asignacionproyecto)
        {
            DataTableAdapter<Proyectos_NuevoProducto> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _proyectos_NuevoProductoRepository.GetDataTableProyectos_ProductosByProyecto(id_asignacionproyecto, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
