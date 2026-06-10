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
    public class DecVie_DerechosPeticionEstadoController : BaseController<DecVie_DerechosPeticionEstado>
    {
        private readonly IDecVie_DerechosPeticionEstadoRepository _decVie_DerechosPeticionEstadoRepository;
        public DecVie_DerechosPeticionEstadoController(IDecVie_DerechosPeticionEstadoRepository decVie_DerechosPeticionEstadoRepository)
        {
            _decVie_DerechosPeticionEstadoRepository = decVie_DerechosPeticionEstadoRepository;
        }
        readonly IDecVie_DerechosPeticionEstadoRepository decVie_DerechosPeticionEstadoRepository = new DecVie_DerechosPeticionEstadoRepository();
        public DecVie_DerechosPeticionEstadoController()
        {
            _decVie_DerechosPeticionEstadoRepository = decVie_DerechosPeticionEstadoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_DerechosPeticionEstado()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_DerechosPeticionEstadoRepository.GetAllDecVie_DerechosPeticionEstado();

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
        public IHttpActionResult GetDecVie_DerechosPeticionEstadoDetails(int id_estadoderpet)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_DerechosPeticionEstadoRepository.GetDecVie_DerechosPeticionEstadoDetails(id_estadoderpet);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_DerechosPeticionEstado inexistente";
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
        public IHttpActionResult GetDecVie_DerechosPeticionEstadoNombre(string cd_nmestadoderpet)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_DerechosPeticionEstadoRepository.GetDecVie_DerechosPeticionEstadoNombre(cd_nmestadoderpet);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_DerechosPeticionEstado inexistente";
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
        public IHttpActionResult InsertDecVie_DerechosPeticionEstado([FromBody] DecVie_DerechosPeticionEstado decVie_DerechosPeticionEstado)
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

                var created = decVie_DerechosPeticionEstadoRepository.InsertDecVie_DerechosPeticionEstado(decVie_DerechosPeticionEstado);

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
        public IHttpActionResult UpdateDecVie_DerechosPeticionEstado([FromBody] DecVie_DerechosPeticionEstado decVie_DerechosPeticionEstado)
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

                var created = decVie_DerechosPeticionEstadoRepository.UpdateDecVie_DerechosPeticionEstado(decVie_DerechosPeticionEstado);

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
        public IHttpActionResult DeleteDecVie_DerechosPeticionEstado(int id_estadoderpet)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_DerechosPeticionEstadoRepository.DeleteDecVie_DerechosPeticionEstado(id_estadoderpet);

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
        public IHttpActionResult GetDataTableDecVie_DerechosPeticionEstado()
        {
            DataTableAdapter<DecVie_DerechosPeticionEstado> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_DerechosPeticionEstadoRepository.GetDataTableDecVie_DerechosPeticionEstado(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
