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
    public class DecVie_DerechosPeticionOficinaController : BaseController<DecVie_DerechosPeticionOficina>
    {
        private readonly IDecVie_DerechosPeticionOficinaRepository _decVie_DerechosPeticionOficinaRepository;
        public DecVie_DerechosPeticionOficinaController(IDecVie_DerechosPeticionOficinaRepository decVie_DerechosPeticionOficinaRepository)
        {
            _decVie_DerechosPeticionOficinaRepository = decVie_DerechosPeticionOficinaRepository;
        }
        readonly IDecVie_DerechosPeticionOficinaRepository decVie_DerechosPeticionOficinaRepository = new DecVie_DerechosPeticionOficinaRepository();
        public DecVie_DerechosPeticionOficinaController()
        {
            _decVie_DerechosPeticionOficinaRepository = decVie_DerechosPeticionOficinaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_DerechosPeticionOficina()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_DerechosPeticionOficinaRepository.GetAllDecVie_DerechosPeticionOficina();

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
        public IHttpActionResult GetDecVie_DerechosPeticionOficinaDetails(int id_oficina)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_DerechosPeticionOficinaRepository.GetDecVie_DerechosPeticionOficinaDetails(id_oficina);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_DerechosPeticionOficina inexistente";
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
        public IHttpActionResult GetDecVie_DerechosPeticionOficinaNombre(string cd_nmoficina)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_DerechosPeticionOficinaRepository.GetDecVie_DerechosPeticionOficinaNombre(cd_nmoficina);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_DerechosPeticionOficina inexistente";
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
        public IHttpActionResult InsertDecVie_DerechosPeticionOficina([FromBody] DecVie_DerechosPeticionOficina decVie_DerechosPeticionOficina)
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

                var created = decVie_DerechosPeticionOficinaRepository.InsertDecVie_DerechosPeticionOficina(decVie_DerechosPeticionOficina);

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
        public IHttpActionResult UpdateDecVie_DerechosPeticionOficina([FromBody] DecVie_DerechosPeticionOficina decVie_DerechosPeticionOficina)
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

                var created = decVie_DerechosPeticionOficinaRepository.UpdateDecVie_DerechosPeticionOficina(decVie_DerechosPeticionOficina);

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
        public IHttpActionResult DeleteDecVie_DerechosPeticionOficina(int id_oficina)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_DerechosPeticionOficinaRepository.DeleteDecVie_DerechosPeticionOficina(id_oficina);

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
        public IHttpActionResult GetDataTableDecVie_DerechosPeticionOficina()
        {
            DataTableAdapter<DecVie_DerechosPeticionOficina> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_DerechosPeticionOficinaRepository.GetDataTableDecVie_DerechosPeticionOficina(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
