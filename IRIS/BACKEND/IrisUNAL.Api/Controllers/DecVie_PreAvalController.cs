using IrisUNAL.Api.Entities.Repositories;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
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
    public class DecVie_PreAvalController : BaseController<DecVie_PreAval>
    {
        private readonly IDecVie_PreAvalRepository _decVie_PreAvalRepository;
        public DecVie_PreAvalController(IDecVie_PreAvalRepository decVie_PreAvalRepository)
        {
            _decVie_PreAvalRepository = decVie_PreAvalRepository;
        }
        readonly IDecVie_PreAvalRepository decVie_PreAvalRepository = new DecVie_PreAvalRepository();
        public DecVie_PreAvalController()
        {
            _decVie_PreAvalRepository = decVie_PreAvalRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_PreAval()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PreAvalRepository.GetAllDecVie_PreAval();

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
        public IHttpActionResult GetDecVie_PreAvalDetails(int id_preaval)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PreAvalRepository.GetDecVie_PreAvalDetails(id_preaval);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_PreAval inexistente";
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
        public IHttpActionResult GetDecVie_PreAvalCodigo(string cd_consecutivo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PreAvalRepository.GetDecVie_PreAvalCodigo(cd_consecutivo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_PreAval inexistente";
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
        public IHttpActionResult InsertDecVie_PreAval([FromBody] DecVie_PreAval decVie_PreAval)
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

                var created = decVie_PreAvalRepository.InsertDecVie_PreAval(decVie_PreAval);

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
        public IHttpActionResult UpdateDecVie_PreAval([FromBody] DecVie_PreAval decVie_PreAval)
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

                var created = decVie_PreAvalRepository.UpdateDecVie_PreAval(decVie_PreAval);

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
        public IHttpActionResult UpdateDecVie_PreAvalRevision([FromBody] DecVie_PreAvalRevisionDTO decVie_PreAvalRevisionDTO)
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

                var created = decVie_PreAvalRepository.UpdateDecVie_PreAvalRevision(decVie_PreAvalRevisionDTO);

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
        public IHttpActionResult UpdateDecVie_PreAvalConceptoDecanatura([FromBody] DecVie_PreAvalConceptoDecanaturaDTO decVie_PreAvalConceptoDecanaturaDTO)
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

                var created = decVie_PreAvalRepository.UpdateDecVie_PreAvalConceptoDecanatura(decVie_PreAvalConceptoDecanaturaDTO);

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
        public IHttpActionResult DeleteDecVie_PreAval(int id_preaval)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_PreAvalRepository.DeleteDecVie_PreAval(id_preaval);

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
        public IHttpActionResult GetDataTableDecVie_PreAval()
        {
            DataTableAdapter<DecVie_PreAval> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_PreAvalRepository.GetDataTableDecVie_PreAval(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }
    }
}
