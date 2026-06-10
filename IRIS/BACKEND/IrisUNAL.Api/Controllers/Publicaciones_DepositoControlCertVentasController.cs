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
    public class Publicaciones_DepositoControlCertVentasController : BaseController<Publicaciones_DepositoControlCertVentas>
    {
        private readonly IPublicaciones_DepositoControlCertVentasRepository _publicaciones_DepositoControlCertVentasRepository;
        public Publicaciones_DepositoControlCertVentasController(IPublicaciones_DepositoControlCertVentasRepository publicaciones_DepositoControlCertVentasRepository)
        {
            _publicaciones_DepositoControlCertVentasRepository = publicaciones_DepositoControlCertVentasRepository;
        }
        readonly IPublicaciones_DepositoControlCertVentasRepository publicaciones_DepositoControlCertVentasRepository = new Publicaciones_DepositoControlCertVentasRepository();
        public Publicaciones_DepositoControlCertVentasController()
        {
            _publicaciones_DepositoControlCertVentasRepository = publicaciones_DepositoControlCertVentasRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DepositoControlCertVentas()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoControlCertVentasRepository.GetAllPublicaciones_DepositoControlCertVentas();

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
        public IHttpActionResult GetPublicaciones_DepositoControlCertVentasDetails(int id_certventas)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoControlCertVentasRepository.GetPublicaciones_DepositoControlCertVentasDetails(id_certventas);

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
        public IHttpActionResult InsertPublicaciones_DepositoControlCertVentas([FromBody] Publicaciones_DepositoControlCertVentas publicaciones_DepositoControlCertVentas)
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

                var created = publicaciones_DepositoControlCertVentasRepository.InsertPublicaciones_DepositoControlCertVentas(publicaciones_DepositoControlCertVentas);

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
        public IHttpActionResult UpdatePublicaciones_DepositoControlCertVentas([FromBody] Publicaciones_DepositoControlCertVentas publicaciones_DepositoControlCertVentas)
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

                var created = publicaciones_DepositoControlCertVentasRepository.UpdatePublicaciones_DepositoControlCertVentas(publicaciones_DepositoControlCertVentas);

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
        public IHttpActionResult DeletePublicaciones_DepositoControlCertVentas(int id_certventas)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DepositoControlCertVentasRepository.DeletePublicaciones_DepositoControlCertVentas(id_certventas);

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
        public IHttpActionResult GetDataTablePublicaciones_DepositoControlCertVentasByPublicacion(int id_crearpublicacion)
        {
            DataTableAdapter<Publicaciones_DepositoControlCertVentas> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_DepositoControlCertVentasRepository.GetDataTablePublicaciones_DepositoControlCertVentasByPublicacion(id_crearpublicacion, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
