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
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class Publicaciones_DepositoControlRepVentasController : BaseController<Publicaciones_DepositoControlRepVentas>
    {
        private readonly IPublicaciones_DepositoControlRepVentasRepository _publicaciones_DepositoControlRepVentasRepository;
        public Publicaciones_DepositoControlRepVentasController(IPublicaciones_DepositoControlRepVentasRepository publicaciones_DepositoControlRepVentasRepository)
        {
            _publicaciones_DepositoControlRepVentasRepository = publicaciones_DepositoControlRepVentasRepository;
        }
        readonly IPublicaciones_DepositoControlRepVentasRepository publicaciones_DepositoControlRepVentasRepository = new Publicaciones_DepositoControlRepVentasRepository();
        public Publicaciones_DepositoControlRepVentasController()
        {
            _publicaciones_DepositoControlRepVentasRepository = publicaciones_DepositoControlRepVentasRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DepositoControlRepVentas()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoControlRepVentasRepository.GetAllPublicaciones_DepositoControlRepVentas();

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
        public IHttpActionResult GetPublicaciones_DepositoControlRepVentasDetails(int id_repventas)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoControlRepVentasRepository.GetPublicaciones_DepositoControlRepVentasDetails(id_repventas);

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
        public IHttpActionResult InsertPublicaciones_DepositoControlRepVentas([FromBody] Publicaciones_DepositoControlRepVentas publicaciones_DepositoControlRepVentas)
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

                var created = publicaciones_DepositoControlRepVentasRepository.InsertPublicaciones_DepositoControlRepVentas(publicaciones_DepositoControlRepVentas);

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
        public IHttpActionResult UpdatePublicaciones_DepositoControlRepVentas([FromBody] Publicaciones_DepositoControlRepVentas publicaciones_DepositoControlRepVentas)
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

                var created = publicaciones_DepositoControlRepVentasRepository.UpdatePublicaciones_DepositoControlRepVentas(publicaciones_DepositoControlRepVentas);

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
        public IHttpActionResult DeletePublicaciones_DepositoControlRepVentas(int id_repventas)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DepositoControlRepVentasRepository.DeletePublicaciones_DepositoControlRepVentas(id_repventas);

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
        public IHttpActionResult GetDataTablePublicaciones_DepositoControlRepVentasByPublicacion(int id_crearpublicacion)
        {
            DataTableAdapter<Publicaciones_DepositoControlRepVentas> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_DepositoControlRepVentasRepository.GetDataTablePublicaciones_DepositoControlRepVentasByPublicacion(id_crearpublicacion, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetPublicaciones_IngresosPorVentasByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoControlRepVentasRepository.GetIngresosVentas(id_crearpublicacion);

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
