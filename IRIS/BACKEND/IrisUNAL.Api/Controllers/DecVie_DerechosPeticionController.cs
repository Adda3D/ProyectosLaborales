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
    public class DecVie_DerechosPeticionController : BaseController<DecVie_DerechosPeticion>
    {
        private readonly IDecVie_DerechosPeticionRepository _decVie_DerechosPeticionRepository;
        public DecVie_DerechosPeticionController(IDecVie_DerechosPeticionRepository decVie_DerechosPeticionRepository)
        {
            _decVie_DerechosPeticionRepository = decVie_DerechosPeticionRepository;
        }
        readonly IDecVie_DerechosPeticionRepository decVie_DerechosPeticionRepository = new DecVie_DerechosPeticionRepository();
        public DecVie_DerechosPeticionController()
        {
            _decVie_DerechosPeticionRepository = decVie_DerechosPeticionRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_DerechosPeticion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_DerechosPeticionRepository.GetAllDecVie_DerechosPeticion();

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
        public IHttpActionResult GetDecVie_DerechosPeticionDetails(int id_derechopeticion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_DerechosPeticionRepository.GetDecVie_DerechosPeticionDetails(id_derechopeticion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Derecho de Petición  inexistente";
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
        public IHttpActionResult GetDecVie_DerechosPeticionNumero(string cd_numradicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_DerechosPeticionRepository.GetDecVie_DerechosPeticionNumero(cd_numradicacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Derecho de Petición  inexistente";
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
        public IHttpActionResult InsertDecVie_DerechosPeticion([FromBody] DecVie_DerechosPeticion decVie_DerechosPeticion)
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

                var created = decVie_DerechosPeticionRepository.InsertDecVie_DerechosPeticion(decVie_DerechosPeticion);

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
        public IHttpActionResult UpdateDecVie_DerechosPeticion([FromBody] DecVie_DerechosPeticion decVie_DerechosPeticion)
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

                var created = decVie_DerechosPeticionRepository.UpdateDecVie_DerechosPeticion(decVie_DerechosPeticion);

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
        public IHttpActionResult DeleteDecVie_DerechosPeticion(int id_derechopeticion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_DerechosPeticionRepository.DeleteDecVie_DerechosPeticion(id_derechopeticion);

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
        public IHttpActionResult GetDataTableDecVie_DerechosPeticion()
        {
            DataTableAdapter<DecVie_DerechosPeticion> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_DerechosPeticionRepository.GetDataTableDecVie_DerechosPeticion(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
