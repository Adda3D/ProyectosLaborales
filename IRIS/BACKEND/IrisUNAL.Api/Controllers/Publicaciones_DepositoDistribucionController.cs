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
    public class Publicaciones_DepositoDistribucionController : BaseController<Publicaciones_DepositoDistribucion>
    {
        private readonly IPublicaciones_DepositoDistribucionRepository _publicaciones_DepositoDistribucionRepository;
        public Publicaciones_DepositoDistribucionController(IPublicaciones_DepositoDistribucionRepository publicaciones_DepositoDistribucionRepository)
        {
            _publicaciones_DepositoDistribucionRepository = publicaciones_DepositoDistribucionRepository;
        }
        readonly IPublicaciones_DepositoDistribucionRepository publicaciones_DepositoDistribucionRepository = new Publicaciones_DepositoDistribucionRepository();
        public Publicaciones_DepositoDistribucionController()
        {
            _publicaciones_DepositoDistribucionRepository = publicaciones_DepositoDistribucionRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DepositoDistribucion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoDistribucionRepository.GetAllPublicaciones_DepositoDistribucion();

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
        public IHttpActionResult GetPublicaciones_DepositoDistribucionDetails(int id_distribucion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DepositoDistribucionRepository.GetPublicaciones_DepositoDistribucionDetails(id_distribucion);

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
        public IHttpActionResult InsertPublicaciones_DepositoDistribucion([FromBody] Publicaciones_DepositoDistribucion publicaciones_DepositoDistribucion)
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

                var created = publicaciones_DepositoDistribucionRepository.InsertPublicaciones_DepositoDistribucion(publicaciones_DepositoDistribucion);

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
        public IHttpActionResult InsertPublicaciones_DepositoDistribucion_Devolucion([FromBody] Publicaciones_DepositoDistribucion publicaciones_DepositoDistribucion)
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

                if (publicaciones_DepositoDistribucion.cantidad > 0)
                {
                    publicaciones_DepositoDistribucion.cantidad = publicaciones_DepositoDistribucion.cantidad * -1;
                }

                var created = publicaciones_DepositoDistribucionRepository.InsertPublicaciones_DepositoDistribucion(publicaciones_DepositoDistribucion);

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
        public IHttpActionResult UpdatePublicaciones_DepositoDistribucion([FromBody] Publicaciones_DepositoDistribucion publicaciones_DepositoDistribucion)
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

                var created = publicaciones_DepositoDistribucionRepository.UpdatePublicaciones_DepositoDistribucion(publicaciones_DepositoDistribucion);

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
        public IHttpActionResult DeletePublicaciones_DepositoDistribucion(int id_distribucion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DepositoDistribucionRepository.DeletePublicaciones_DepositoDistribucion(id_distribucion);

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
        public IHttpActionResult GetDataTablePublicaciones_DepositoDistribucionByPublicacion(int id_crearpublicacion)
        {
            DataTableAdapter<Publicaciones_DepositoDistribucion> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_DepositoDistribucionRepository.GetDataTablePublicaciones_DepositoDistribucionByPublicacion(id_crearpublicacion, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }

    }
}
