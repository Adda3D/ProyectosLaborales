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
    public class Publicaciones_ConceptoController : BaseController<Publicaciones_Concepto>
    {
        private readonly IPublicaciones_ConceptoRepository _publicaciones_ConceptoRepository;
        public Publicaciones_ConceptoController(IPublicaciones_ConceptoRepository publicaciones_ConceptoRepository)
        {
            _publicaciones_ConceptoRepository = publicaciones_ConceptoRepository;
        }
        readonly IPublicaciones_ConceptoRepository publicaciones_ConceptoRepository = new Publicaciones_ConceptoRepository();
        public Publicaciones_ConceptoController()
        {
            _publicaciones_ConceptoRepository = publicaciones_ConceptoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_Concepto()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ConceptoRepository.GetAllPublicaciones_Concepto();

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
        public IHttpActionResult GetPublicaciones_ConceptoDetails(int id_concepto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ConceptoRepository.GetPublicaciones_ConceptoDetails(id_concepto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_Concepto inexistente";
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
        public IHttpActionResult GetPublicaciones_ConceptoNombre(string cd_nmconcepto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_ConceptoRepository.GetPublicaciones_ConceptoNombre(cd_nmconcepto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_Concepto inexistente";
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
        public IHttpActionResult InsertPublicaciones_Concepto([FromBody] Publicaciones_Concepto publicaciones_Concepto)
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

                var created = publicaciones_ConceptoRepository.InsertPublicaciones_Concepto(publicaciones_Concepto);

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
        public IHttpActionResult UpdatePublicaciones_Concepto([FromBody] Publicaciones_Concepto publicaciones_Concepto)
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

                var created = publicaciones_ConceptoRepository.UpdatePublicaciones_Concepto(publicaciones_Concepto);

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
        public IHttpActionResult DeletePublicaciones_Concepto(int id_concepto)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_ConceptoRepository.DeletePublicaciones_Concepto(id_concepto);

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
        public IHttpActionResult GetDataTablePublicaciones_Concepto()
        {
            DataTableAdapter<Publicaciones_Concepto> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_ConceptoRepository.GetDataTablePublicaciones_Concepto(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
