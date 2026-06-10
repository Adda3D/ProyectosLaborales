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
    public class DecVie_CuerposColegiadosController : BaseController<DecVie_CuerposColegiados>
    {
        private readonly IDecVie_CuerposColegiadosRepository _decVie_CuerposColegiadosRepository;
        public DecVie_CuerposColegiadosController(IDecVie_CuerposColegiadosRepository decVie_CuerposColegiadosRepository)
        {
            _decVie_CuerposColegiadosRepository = decVie_CuerposColegiadosRepository;
        }
        readonly IDecVie_CuerposColegiadosRepository decVie_CuerposColegiadosRepository = new DecVie_CuerposColegiadosRepository();
        public DecVie_CuerposColegiadosController()
        {
            _decVie_CuerposColegiadosRepository = decVie_CuerposColegiadosRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_CuerposColegiados()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_CuerposColegiadosRepository.GetAllDecVie_CuerposColegiados();

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
        public IHttpActionResult GetDecVie_CuerposColegiadosDetails(int id_cuerposcolegiados)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_CuerposColegiadosRepository.GetDecVie_CuerposColegiadosDetails(id_cuerposcolegiados);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Cuerpo Colegiado inexistente";
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
        public IHttpActionResult GetDecVie_CuerposColegiadosNumero(string cd_numacta)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_CuerposColegiadosRepository.GetDecVie_CuerposColegiadosNumero(cd_numacta);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Cuerpo Colegiado inexistente";
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
        public IHttpActionResult InsertDecVie_CuerposColegiados([FromBody] DecVie_CuerposColegiados decVie_CuerposColegiados)
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

                var created = decVie_CuerposColegiadosRepository.InsertDecVie_CuerposColegiados(decVie_CuerposColegiados);

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
        public IHttpActionResult UpdateDecVie_CuerposColegiados([FromBody] DecVie_CuerposColegiados decVie_CuerposColegiados)
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

                var created = decVie_CuerposColegiadosRepository.UpdateDecVie_CuerposColegiados(decVie_CuerposColegiados);

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
        public IHttpActionResult DeleteDecVie_CuerposColegiados(int id_cuerposcolegiados)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_CuerposColegiadosRepository.DeleteDecVie_CuerposColegiados(id_cuerposcolegiados);

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
        public IHttpActionResult GetDataTableDecVie_CuerposColegiados()
        {
            DataTableAdapter<DecVie_CuerposColegiados> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_CuerposColegiadosRepository.GetDataTableDecVie_CuerposColegiados(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
