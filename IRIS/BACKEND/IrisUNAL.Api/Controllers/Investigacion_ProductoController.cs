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
    public class Investigacion_ProductoController : BaseController<Investigacion_Producto>
    {
        private readonly IInvestigacion_ProductoRepository _investigacion_productoRepository;

        public Investigacion_ProductoController(IInvestigacion_ProductoRepository investigacion_ProductoRepository)
        {
            _investigacion_productoRepository = investigacion_ProductoRepository;
        }

        readonly IInvestigacion_ProductoRepository investigacion_ProductoRepository = new Investigacion_ProductoRepository();
        public Investigacion_ProductoController()
        {
            _investigacion_productoRepository = investigacion_ProductoRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllInvestigacion_Producto()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_productoRepository.GetAllInvestigacion_Producto();

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
        public IHttpActionResult GetInvestigacion_ProductoDetails(int id_producto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_productoRepository.GetInvestigacion_ProductoDetails(id_producto);

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
        public IHttpActionResult InsertInvestigacion_Producto([FromBody] Investigacion_Producto investigacion_Producto)
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

                var created = _investigacion_productoRepository.InsertInvestigacion_Producto(investigacion_Producto);

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
        public IHttpActionResult UpdateInvestigacion_Producto([FromBody] Investigacion_Producto investigacion_Producto)
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

                var created = _investigacion_productoRepository.UpdateInvestigacion_Producto(investigacion_Producto);

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
        public IHttpActionResult DeleteInvestigacion_Producto(int id_producto)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _investigacion_productoRepository.DeleteInvestigacion_Producto(id_producto);

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
        public IHttpActionResult GetDataTableInvestigacion_ProductoByProyecto(int id_crearproyecto)
        {
            DataTableAdapter<Investigacion_Producto> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _investigacion_productoRepository.GetDataTableInvestigacion_ProductoByProyecto(id_crearproyecto, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

    }
}
