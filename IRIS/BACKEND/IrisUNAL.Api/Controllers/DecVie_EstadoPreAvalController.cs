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
    public class DecVie_EstadoPreAvalController : BaseController<DecVie_EstadoPreAval>
    {
        private readonly IDecVie_EstadoPreAvalRepository _decVie_EstadoPreAvalRepository;
        public DecVie_EstadoPreAvalController(IDecVie_EstadoPreAvalRepository decVie_EstadoPreAvalRepository)
        {
            _decVie_EstadoPreAvalRepository = decVie_EstadoPreAvalRepository;
        }
        readonly IDecVie_EstadoPreAvalRepository decVie_EstadoPreAvalRepository = new DecVie_EstadoPreAvalRepository();
        public DecVie_EstadoPreAvalController()
        {
            _decVie_EstadoPreAvalRepository = decVie_EstadoPreAvalRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_EstadoPreAval()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_EstadoPreAvalRepository.GetAllDecVie_EstadoPreAval();

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
        public IHttpActionResult GetDecVie_EstadoPreAvalDetails(int id_estadopreaval)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_EstadoPreAvalRepository.GetDecVie_EstadoPreAvalDetails(id_estadopreaval);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_EstadoPreAval inexistente";
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
        public IHttpActionResult GetDecVie_EstadoPreAvalNombre(string cd_nmestadopreaval)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_EstadoPreAvalRepository.GetDecVie_EstadoPreAvalNombre(cd_nmestadopreaval);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_EstadoPreAval inexistente";
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
        public IHttpActionResult InsertDecVie_EstadoPreAval([FromBody] DecVie_EstadoPreAval decVie_EstadoPreAval)
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

                var created = decVie_EstadoPreAvalRepository.InsertDecVie_EstadoPreAval(decVie_EstadoPreAval);

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
        public IHttpActionResult UpdateDecVie_EstadoPreAval([FromBody] DecVie_EstadoPreAval decVie_EstadoPreAval)
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

                var created = decVie_EstadoPreAvalRepository.UpdateDecVie_EstadoPreAval(decVie_EstadoPreAval);

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
        public IHttpActionResult DeleteDecVie_EstadoPreAval(int id_estadopreaval)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_EstadoPreAvalRepository.DeleteDecVie_EstadoPreAval(id_estadopreaval);

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
        public IHttpActionResult GetDataTableDecVie_EstadoPreAval()
        {
            DataTableAdapter<DecVie_EstadoPreAval> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_EstadoPreAvalRepository.GetDataTableDecVie_EstadoPreAval(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
