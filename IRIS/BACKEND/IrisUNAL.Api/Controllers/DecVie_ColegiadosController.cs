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
    public class DecVie_ColegiadosController : BaseController<DecVie_Colegiados>
    {
        private readonly IDecVie_ColegiadosRepository _decVie_ColegiadosRepository;
        public DecVie_ColegiadosController(IDecVie_ColegiadosRepository decVie_ColegiadosRepository)
        {
            _decVie_ColegiadosRepository = decVie_ColegiadosRepository;
        }
        readonly IDecVie_ColegiadosRepository decVie_ColegiadosRepository = new DecVie_ColegiadosRepository();
        public DecVie_ColegiadosController()
        {
            _decVie_ColegiadosRepository = decVie_ColegiadosRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_Colegiados()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ColegiadosRepository.GetAllDecVie_Colegiados();

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
        public IHttpActionResult GetDecVie_ColegiadosDetails(int id_colegiado)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ColegiadosRepository.GetDecVie_ColegiadosDetails(id_colegiado);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Colegiado inexistente";
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
        public IHttpActionResult GetDecVie_ColegiadosNombre(string cd_nmcolegiado)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ColegiadosRepository.GetDecVie_ColegiadosNombre(cd_nmcolegiado);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Colegiado inexistente";
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
        public IHttpActionResult InsertDecVie_Colegiados([FromBody] DecVie_Colegiados decVie_Colegiados)
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

                var created = decVie_ColegiadosRepository.InsertDecVie_Colegiados(decVie_Colegiados);

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
        public IHttpActionResult UpdateDecVie_Colegiados([FromBody] DecVie_Colegiados decVie_Colegiados)
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

                var created = decVie_ColegiadosRepository.UpdateDecVie_Colegiados(decVie_Colegiados);

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
        public IHttpActionResult DeleteDecVie_Colegiados(int id_colegiado)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_ColegiadosRepository.DeleteDecVie_Colegiados(id_colegiado);

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
        public IHttpActionResult GetDataTableDecVie_Colegiados()
        {
            DataTableAdapter<DecVie_Colegiados> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_ColegiadosRepository.GetDataTableDecVie_Colegiados(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
