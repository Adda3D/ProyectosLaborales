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
    public class DecVie_RadicadorCorController : BaseController<DecVie_RadicadorCor>
    {
        private readonly IDecVie_RadicadorCorRepository _decVie_RadicadorCorRepository;
        public DecVie_RadicadorCorController(IDecVie_RadicadorCorRepository decVie_RadicadorCorRepository)
        {
            _decVie_RadicadorCorRepository = decVie_RadicadorCorRepository;
        }
        readonly IDecVie_RadicadorCorRepository decVie_RadicadorCorRepository = new DecVie_RadicadorCorRepository();
        public DecVie_RadicadorCorController()
        {
            _decVie_RadicadorCorRepository = decVie_RadicadorCorRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_RadicadorCor()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_RadicadorCorRepository.GetAllDecVie_RadicadorCor();

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
        public IHttpActionResult GetDecVie_RadicadorCorDetails(int id_radicadorcor)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_RadicadorCorRepository.GetDecVie_RadicadorCorDetails(id_radicadorcor);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Radicado inexistente";
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
        public IHttpActionResult GetDecVie_RadicadorCorNombre(string cd_numerodocumento)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_RadicadorCorRepository.GetDecVie_RadicadorCorNombre(cd_numerodocumento);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Radicado inexistente";
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
        public IHttpActionResult InsertDecVie_RadicadorCor([FromBody] DecVie_RadicadorCor decVie_RadicadorCor)
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

                var created = decVie_RadicadorCorRepository.InsertDecVie_RadicadorCor(decVie_RadicadorCor);

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
        public IHttpActionResult UpdateDecVie_RadicadorCor([FromBody] DecVie_RadicadorCor decVie_RadicadorCor)
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

                var created = decVie_RadicadorCorRepository.UpdateDecVie_RadicadorCor(decVie_RadicadorCor);

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
        public IHttpActionResult DeleteDecVie_RadicadorCor(int id_radicadorcor)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_RadicadorCorRepository.DeleteDecVie_RadicadorCor(id_radicadorcor);

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
        public IHttpActionResult GetDataTableDecVie_RadicadorCor()
        {
            DataTableAdapter<DecVie_RadicadorCor> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_RadicadorCorRepository.GetDataTableDecVie_RadicadorCor(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
