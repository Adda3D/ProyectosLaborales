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
    public class DecVie_MacroprocesoController : BaseController<DecVie_Macroproceso>
    {
        private readonly IDecVie_MacroprocesoRepository _decVie_MacroprocesoRepository;
        public DecVie_MacroprocesoController(IDecVie_MacroprocesoRepository decVie_MacroprocesoRepository)
        {
            _decVie_MacroprocesoRepository = decVie_MacroprocesoRepository;
        }
        readonly IDecVie_MacroprocesoRepository decVie_MacroprocesoRepository = new DecVie_MacroprocesoRepository();
        public DecVie_MacroprocesoController()
        {
            _decVie_MacroprocesoRepository = decVie_MacroprocesoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_Macroproceso()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_MacroprocesoRepository.GetAllDecVie_Macroproceso();

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
        public IHttpActionResult GetDecVie_MacroprocesoDetails(int id_decviemacroproceso)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_MacroprocesoRepository.GetDecVie_MacroprocesoDetails(id_decviemacroproceso);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_Macroproceso inexistente";
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
        public IHttpActionResult GetDecVie_MacroprocesoNombre(string cd_nmdecviemacroproceso)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_MacroprocesoRepository.GetDecVie_MacroprocesoNombre(cd_nmdecviemacroproceso);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_Macroproceso inexistente";
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
        public IHttpActionResult InsertDecVie_Macroproceso([FromBody] DecVie_Macroproceso decVie_Macroproceso)
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

                var created = decVie_MacroprocesoRepository.InsertDecVie_Macroproceso(decVie_Macroproceso);

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
        public IHttpActionResult UpdateDecVie_Macroproceso([FromBody] DecVie_Macroproceso decVie_Macroproceso)
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

                var created = decVie_MacroprocesoRepository.UpdateDecVie_Macroproceso(decVie_Macroproceso);

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
        public IHttpActionResult DeleteDecVie_Macroproceso(int id_decviemacroproceso)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_MacroprocesoRepository.DeleteDecVie_Macroproceso(id_decviemacroproceso);

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
        public IHttpActionResult GetDataTableDecVie_Macroproceso()
        {
            DataTableAdapter<DecVie_Macroproceso> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_MacroprocesoRepository.GetDataTableDecVie_Macroproceso(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
