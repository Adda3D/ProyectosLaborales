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
    public class Publicaciones_EstadoConceptoController : BaseController<Publicaciones_EstadoConcepto>
    {
        private readonly IPublicaciones_EstadoConceptoRepository _publicaciones_EstadoConceptoRepository;
        public Publicaciones_EstadoConceptoController(IPublicaciones_EstadoConceptoRepository publicaciones_EstadoConceptoRepository)
        {
            _publicaciones_EstadoConceptoRepository = publicaciones_EstadoConceptoRepository;
        }
        readonly IPublicaciones_EstadoConceptoRepository publicaciones_EstadoConceptoRepository = new Publicaciones_EstadoConceptoRepository();
        public Publicaciones_EstadoConceptoController()
        {
            _publicaciones_EstadoConceptoRepository = publicaciones_EstadoConceptoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_EstadoConcepto()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EstadoConceptoRepository.GetAllPublicaciones_EstadoConcepto();

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
        public IHttpActionResult GetPublicaciones_EstadoConceptoDetails(int id_estadoconcepto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EstadoConceptoRepository.GetPublicaciones_EstadoConceptoDetails(id_estadoconcepto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_EstadoConcepto inexistente";
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
        public IHttpActionResult GetPublicaciones_EstadoConceptoNombre(string cd_nmestadoconcepto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EstadoConceptoRepository.GetPublicaciones_EstadoConceptoNombre(cd_nmestadoconcepto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_EstadoConcepto inexistente";
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
        public IHttpActionResult InsertPublicaciones_EstadoConcepto([FromBody] Publicaciones_EstadoConcepto publicaciones_EstadoConcepto)
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

                var created = publicaciones_EstadoConceptoRepository.InsertPublicaciones_EstadoConcepto(publicaciones_EstadoConcepto);

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
        public IHttpActionResult UpdatePublicaciones_EstadoConcepto([FromBody] Publicaciones_EstadoConcepto publicaciones_EstadoConcepto)
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

                var created = publicaciones_EstadoConceptoRepository.UpdatePublicaciones_EstadoConcepto(publicaciones_EstadoConcepto);

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
        public IHttpActionResult DeletePublicaciones_EstadoConcepto(int id_estadoconcepto)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_EstadoConceptoRepository.DeletePublicaciones_EstadoConcepto(id_estadoconcepto);

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
        public IHttpActionResult GetDataTablePublicaciones_EstadoConcepto()
        {
            DataTableAdapter<Publicaciones_EstadoConcepto> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_EstadoConceptoRepository.GetDataTablePublicaciones_EstadoConcepto(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
