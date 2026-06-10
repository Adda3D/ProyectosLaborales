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
    public class Proyectos_TipoProductoController : BaseController<Proyectos_TipoProducto>
    {
        private readonly Proyectos_TipoProductoRepository _tipo_ProductoRepository;

        public Proyectos_TipoProductoController(Proyectos_TipoProductoRepository tipo_ProductoRepository)
        {
            _tipo_ProductoRepository = tipo_ProductoRepository;
        }

        readonly Proyectos_TipoProductoRepository tipo_ProductoRepository = new Proyectos_TipoProductoRepository();
        public Proyectos_TipoProductoController()
        {
            _tipo_ProductoRepository = tipo_ProductoRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllProyectos_TipoProducto()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _tipo_ProductoRepository.GetAllProyectos_TipoProducto();

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
        public IHttpActionResult GetProyectos_TipoProductoDetails(int id_tipoproducto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _tipo_ProductoRepository.GetProyectos_TipoProductoDetails(id_tipoproducto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Tipo producto inexistente";
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
        public IHttpActionResult GetProyectos_TipoProductoNombre(string cd_tipoproducto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _tipo_ProductoRepository.GetProyectos_TipoProductoNombre(cd_tipoproducto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Tipo producto inexistente";
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
        public IHttpActionResult InsertProyectos_TipoProducto([FromBody] Proyectos_TipoProducto tipoProducto)
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

                var created = _tipo_ProductoRepository.InsertProyectos_TipoProducto(tipoProducto);

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
        public IHttpActionResult UpdateProyectos_TipoProducto([FromBody] Proyectos_TipoProducto tipoProducto)
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

                var created = _tipo_ProductoRepository.UpdateProyectos_TipoProducto(tipoProducto);

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
        public IHttpActionResult DeleteProyectos_TipoProducto(int id_tipoproducto)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _tipo_ProductoRepository.DeleteProyectos_TipoProducto(id_tipoproducto);

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
        public IHttpActionResult GetDataTableProyectoTipoProducto()
        {
            DataTableAdapter<Proyectos_TipoProducto> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _tipo_ProductoRepository.GetDataTableProyectoTipoProducto(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
