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
    public class DecVie_DependenciaController : BaseController<DecVie_Dependencia>
    {
        private readonly IDecVie_DependenciaRepository _decVie_DependenciaRepository;
        public DecVie_DependenciaController(IDecVie_DependenciaRepository decVie_DependenciaRepository)
        {
            _decVie_DependenciaRepository = decVie_DependenciaRepository;
        }
        readonly IDecVie_DependenciaRepository decVie_DependenciaRepository = new DecVie_DependenciaRepository();
        public DecVie_DependenciaController()
        {
            _decVie_DependenciaRepository = decVie_DependenciaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_Dependencia()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_DependenciaRepository.GetAllDecVie_Dependencia();

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
        public IHttpActionResult GetDecVie_DependenciaDetails(int id_decviedependencia)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_DependenciaRepository.GetDecVie_DependenciaDetails(id_decviedependencia);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_Dependencia inexistente";
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
        public IHttpActionResult GetDecVie_DependenciaNombre(string cd_nmdecviedependencia)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_DependenciaRepository.GetDecVie_DependenciaNombre(cd_nmdecviedependencia);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_Dependencia inexistente";
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
        public IHttpActionResult InsertDecVie_Dependencia([FromBody] DecVie_Dependencia decVie_Dependencia)
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

                var created = decVie_DependenciaRepository.InsertDecVie_Dependencia(decVie_Dependencia);

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
        public IHttpActionResult UpdateDecVie_Dependencia([FromBody] DecVie_Dependencia decVie_Dependencia)
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

                var created = decVie_DependenciaRepository.UpdateDecVie_Dependencia(decVie_Dependencia);

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
        public IHttpActionResult DeleteDecVie_Dependencia(int id_decviedependencia)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_DependenciaRepository.DeleteDecVie_Dependencia(id_decviedependencia);

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
        public IHttpActionResult GetDataTableDecVie_Dependencia()
        {
            DataTableAdapter<DecVie_Dependencia> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_DependenciaRepository.GetDataTableDecVie_Dependencia(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
