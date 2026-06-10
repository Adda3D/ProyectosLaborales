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
    public class Publicaciones_DepositoDistribucionComercialController : BaseController<Publicaciones_DepositoDistribucionComercial>
    {
        private readonly IPublicaciones_DepositoDistribucionComercialRepository _publicaciones_DepositoDistribucionComercialRepository;
        public Publicaciones_DepositoDistribucionComercialController(IPublicaciones_DepositoDistribucionComercialRepository publicaciones_DepositoDistribucionComercialRepository)
        {
            _publicaciones_DepositoDistribucionComercialRepository = publicaciones_DepositoDistribucionComercialRepository;
        }
        readonly IPublicaciones_DepositoDistribucionComercialRepository publicaciones_DepositoDistribucionComercialRepository = new Publicaciones_DepositoDistribucionComercialRepository();
        public Publicaciones_DepositoDistribucionComercialController()
        {
            _publicaciones_DepositoDistribucionComercialRepository = publicaciones_DepositoDistribucionComercialRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DepositoDistribucionComercial()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoDistribucionComercialRepository.GetAllPublicaciones_DepositoDistribucionComercial();

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
        public IHttpActionResult GetPublicaciones_DepositoDistribucionComercialDetails(int id_distribucioncomercial)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoDistribucionComercialRepository.GetPublicaciones_DepositoDistribucionComercialDetails(id_distribucioncomercial);

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
        public IHttpActionResult InsertPublicaciones_DepositoDistribucionComercial([FromBody] Publicaciones_DepositoDistribucionComercial publicaciones_DepositoDistribucionComercial)
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

                var created = publicaciones_DepositoDistribucionComercialRepository.InsertPublicaciones_DepositoDistribucionComercial(publicaciones_DepositoDistribucionComercial);

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
        public IHttpActionResult InsertPublicaciones_DepositoDistribucionComercial_Devolucion([FromBody] Publicaciones_DepositoDistribucionComercial publicaciones_DepositoDistribucionComercial)
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

                if (publicaciones_DepositoDistribucionComercial.cantidad > 0)
                {
                    publicaciones_DepositoDistribucionComercial.cantidad = publicaciones_DepositoDistribucionComercial.cantidad * -1;
                }

                var created = publicaciones_DepositoDistribucionComercialRepository.InsertPublicaciones_DepositoDistribucionComercial(publicaciones_DepositoDistribucionComercial);

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
        public IHttpActionResult UpdatePublicaciones_DepositoDistribucionComercial([FromBody] Publicaciones_DepositoDistribucionComercial publicaciones_DepositoDistribucionComercial)
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

                var created = publicaciones_DepositoDistribucionComercialRepository.UpdatePublicaciones_DepositoDistribucionComercial(publicaciones_DepositoDistribucionComercial);

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
        public IHttpActionResult DeletePublicaciones_DepositoDistribucionComercial(int id_distribucioncomercial)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DepositoDistribucionComercialRepository.DeletePublicaciones_DepositoDistribucionComercial(id_distribucioncomercial);

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
        public IHttpActionResult GetDataTablePublicaciones_DepositoDistribucionComercialByPublicacion(int id_crearpublicacion)
        {
            DataTableAdapter<Publicaciones_DepositoDistribucionComercial> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_DepositoDistribucionComercialRepository.GetDataTablePublicaciones_DepositoDistribucionComercialByPublicacion(id_crearpublicacion, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }

    }
}
