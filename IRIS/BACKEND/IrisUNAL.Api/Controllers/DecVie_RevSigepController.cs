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
    public class DecVie_RevSigepController : BaseController<DecVie_RevSigep>
    {
        private readonly IDecVie_RevSigepRepository _decVie_RevSigepRepository;
        public DecVie_RevSigepController(IDecVie_RevSigepRepository decVie_RevSigepRepository)
        {
            _decVie_RevSigepRepository = decVie_RevSigepRepository;
        }
        readonly IDecVie_RevSigepRepository decVie_RevSigepRepository = new DecVie_RevSigepRepository();
        public DecVie_RevSigepController()
        {
            _decVie_RevSigepRepository = decVie_RevSigepRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_RevSigep()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_RevSigepRepository.GetAllDecVie_RevSigep();

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
        public IHttpActionResult GetDecVie_RevSigepDetails(int id_revsigep)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_RevSigepRepository.GetDecVie_RevSigepDetails(id_revsigep);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_RevSigep inexistente";
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
        public IHttpActionResult GetDecVie_RevSigepNombre(string cd_nmrevsigep)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_RevSigepRepository.GetDecVie_RevSigepNombre(cd_nmrevsigep);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_RevSigep inexistente";
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
        public IHttpActionResult InsertDecVie_RevSigep([FromBody] DecVie_RevSigep decVie_RevSigep)
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

                var created = decVie_RevSigepRepository.InsertDecVie_RevSigep(decVie_RevSigep);

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
        public IHttpActionResult UpdateDecVie_RevSigep([FromBody] DecVie_RevSigep decVie_RevSigep)
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

                var created = decVie_RevSigepRepository.UpdateDecVie_RevSigep(decVie_RevSigep);

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
        public IHttpActionResult DeleteDecVie_RevSigep(int id_revsigep)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_RevSigepRepository.DeleteDecVie_RevSigep(id_revsigep);

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
        public IHttpActionResult GetDataTableDecVie_RevSigep()
        {
            DataTableAdapter<DecVie_RevSigep> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _decVie_RevSigepRepository.GetDataTableDecVie_RevSigep(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
