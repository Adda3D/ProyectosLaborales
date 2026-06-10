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
    public class DecVie_EstadoController : BaseController<DecVie_Estado>
    {
        private readonly IDecVie_EstadoRepository _decVie_EstadoRepository;
        public DecVie_EstadoController (IDecVie_EstadoRepository decVie_EstadoRepository)
        {
            _decVie_EstadoRepository = decVie_EstadoRepository;
        }
        readonly IDecVie_EstadoRepository decVie_EstadoRepository = new DecVie_EstadoRepository();
        public DecVie_EstadoController()
        {
            _decVie_EstadoRepository = decVie_EstadoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_Estado()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_EstadoRepository.GetAllDecVie_Estado();

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
        public IHttpActionResult GetDecVie_EstadoDetails(int id_decvieestado)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_EstadoRepository.GetDecVie_EstadoDetails(id_decvieestado);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_Estado inexistente";
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
        public IHttpActionResult GetDecVie_EstadoNombre(string cd_nmdecvieestado)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_EstadoRepository.GetDecVie_EstadoNombre(cd_nmdecvieestado);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_Estado inexistente";
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
        public IHttpActionResult InsertDecVie_Estado([FromBody] DecVie_Estado decVie_Estado)
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

                var created = decVie_EstadoRepository.InsertDecVie_Estado(decVie_Estado);

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
        public IHttpActionResult UpdateDecVie_Estado([FromBody] DecVie_Estado decVie_Estado)
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

                var created = decVie_EstadoRepository.UpdateDecVie_Estado(decVie_Estado);

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
        public IHttpActionResult DeleteDecVie_Estado(int id_decvieestado)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_EstadoRepository.DeleteDecVie_Estado(id_decvieestado);

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
        public IHttpActionResult GetDataTableDecVie_Estado()
        {
            DataTableAdapter<DecVie_Estado> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_EstadoRepository.GetDataTableDecVie_Estado(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
