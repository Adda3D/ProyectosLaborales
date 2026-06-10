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
    public class DecVie_TipologiaController : BaseController<DecVie_Tipologia>
    {
        private readonly IDecVie_TipologiaRepository _decVie_TipologiaRepository;
        public DecVie_TipologiaController(IDecVie_TipologiaRepository decVie_TipologiaRepository)
        {
            _decVie_TipologiaRepository = decVie_TipologiaRepository;
        }
        readonly IDecVie_TipologiaRepository decVie_TipologiaRepository = new DecVie_TipologiaRepository();
        public DecVie_TipologiaController()
        {
            _decVie_TipologiaRepository = decVie_TipologiaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_Tipologia()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_TipologiaRepository.GetAllDecVie_Tipologia();

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
        public IHttpActionResult GetDecVie_TipologiaDetails(int id_decvietipologia)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_TipologiaRepository.GetDecVie_TipologiaDetails(id_decvietipologia);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_Tipologia inexistente";
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
        public IHttpActionResult GetDecVie_TipologiaNombre(string cd_nmdecvietipologia)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_TipologiaRepository.GetDecVie_TipologiaNombre(cd_nmdecvietipologia);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_Tipologia inexistente";
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
        public IHttpActionResult InsertDecVie_Tipologia([FromBody] DecVie_Tipologia decVie_Tipologia)
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

                var created = decVie_TipologiaRepository.InsertDecVie_Tipologia(decVie_Tipologia);

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
        public IHttpActionResult UpdateDecVie_Tipologia([FromBody] DecVie_Tipologia decVie_Tipologia)
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

                var created = decVie_TipologiaRepository.UpdateDecVie_Tipologia(decVie_Tipologia);

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
        public IHttpActionResult DeleteDecVie_Tipologia(int id_decvietipologia)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_TipologiaRepository.DeleteDecVie_Tipologia(id_decvietipologia);

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
        public IHttpActionResult GetDataTableDecVieTipologia()
        {
            DataTableAdapter<DecVie_Tipologia> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_TipologiaRepository.GetDataTableDecVieTipologia(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }


    }
}
