using IrisUNAL.Api.Entities.Repositories.Publicacion;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.Publicacion;
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

namespace IrisUNAL.Api.Controllers.Publicacion
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Publicacion_AplicarpagoController : BaseController<Publicacion_Aplicarpago>
    {
        private readonly Publicacion_AplicarpagoRepository _publicacion_aplicarpagoRepository;

        public Publicacion_AplicarpagoController(Publicacion_AplicarpagoRepository publicacion_aplicarpagoRepository)
        {
            _publicacion_aplicarpagoRepository = publicacion_aplicarpagoRepository;
        }

        readonly Publicacion_AplicarpagoRepository publicacion_aplicarpagoRepository = new Publicacion_AplicarpagoRepository();
        public Publicacion_AplicarpagoController()
        {
            _publicacion_aplicarpagoRepository = publicacion_aplicarpagoRepository;
        }

        [HttpGet]
        public IHttpActionResult GetPublicacion_AplicarpagoDetails(int id_publicacionpago)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicacion_aplicarpagoRepository.GetPublicacion_AplicarpagoDetails(id_publicacionpago);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Detalle de pago inexistente";
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
        public IHttpActionResult InsertPublicacion_Aplicarpago([FromBody] Publicacion_Aplicarpago _publicacion_aplicarpago)
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

                var created = _publicacion_aplicarpagoRepository.InsertPublicacion_Aplicarpago(_publicacion_aplicarpago);

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
        public IHttpActionResult UpdatePublicacion_Aplicarpago([FromBody] Publicacion_Aplicarpago _publicacion_aplicarpago)
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

                var created = _publicacion_aplicarpagoRepository.UpdatePublicacion_Aplicarpago(_publicacion_aplicarpago);

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
        public IHttpActionResult DeletePublicacion_Aplicarpago(int id_publicacionpago)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _publicacion_aplicarpagoRepository.DeletePublicacion_Aplicarpago(id_publicacionpago);

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
        public IHttpActionResult GetDataTablePagosByPublicacionGasto(int id_publicaciongasto)
        {
            DataTableAdapter<Publicacion_Aplicarpago> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _publicacion_aplicarpagoRepository.GetDataTablePagosByPublicacionGasto(id_publicaciongasto, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetDataTablePublicacion_AplicarpagoByPublicacion(int id_crearpublicacion)
        {
            DataTableAdapter<Publicacion_Aplicarpago> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _publicacion_aplicarpagoRepository.GetDataTablePublicacion_AplicarpagoByPublicacion(id_crearpublicacion, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
