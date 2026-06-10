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
    public class Decvie_CicloFinancieroController : BaseController<Decvie_CicloFinanciero>
    {
        private readonly Decvie_CicloFinancieroRepository _decvie_CicloFinancieroRepository;
        public Decvie_CicloFinancieroController(Decvie_CicloFinancieroRepository decvie_CicloFinancieroRepository)
        {
            _decvie_CicloFinancieroRepository = decvie_CicloFinancieroRepository;
        }
        readonly Decvie_CicloFinancieroRepository decvie_CicloFinancieroRepository = new Decvie_CicloFinancieroRepository();
        public Decvie_CicloFinancieroController()
        {
            _decvie_CicloFinancieroRepository = decvie_CicloFinancieroRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecvie_CicloFinanciero()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_CicloFinancieroRepository.GetAllDecvie_CicloFinanciero();

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
        public IHttpActionResult GetDecvie_CicloFinancieroDetails(int id_ciclofinanciero)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_CicloFinancieroRepository.GetDecvie_CicloFinancieroDetails(id_ciclofinanciero);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Matryoshka inexistente";
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
        public IHttpActionResult InsertDecvie_CicloFinanciero([FromBody] Decvie_CicloFinanciero decvie_CicloFinanciero )
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

                var created = decvie_CicloFinancieroRepository.InsertDecvie_CicloFinanciero(decvie_CicloFinanciero);

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
        public IHttpActionResult UpdateDecvie_CicloFinanciero([FromBody] Decvie_CicloFinanciero decvie_CicloFinanciero)
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

                var created = decvie_CicloFinancieroRepository.UpdateDecvie_CicloFinanciero(decvie_CicloFinanciero);

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
        public IHttpActionResult DeleteDecvie_CicloFinanciero(int id_ciclofinanciero)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decvie_CicloFinancieroRepository.DeleteDecvie_CicloFinanciero(id_ciclofinanciero);

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
        public IHttpActionResult GetDataTableDecvie_CicloFinanciero()
        {
            DataTableAdapter<Decvie_CicloFinanciero> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_CicloFinancieroRepository.GetDataTableDecvie_CicloFinanciero(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }
        [HttpGet]
        public IHttpActionResult GetDataTableDecvie_CicloFinancieroBySemestre( int id_ciclofinanciero)
        {
            DataTableAdapter<Decvie_CicloFinanciero> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_CicloFinancieroRepository.GetDataTableDecvie_CicloFinancieroBySemestre(id_ciclofinanciero, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

        [HttpGet]

        public IHttpActionResult ExcelDecvie_CicloFinanciero(int id_ciclofinanciero)
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = decvie_CicloFinancieroRepository.ExcelDecvie_CicloFinanciero(id_ciclofinanciero);                

                resultdb.Ok = true;
                resultdb.Message = "";

                if (archivoresultado == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Error creando Archivo Excel";
                }

                resultdb.Data = archivoresultado;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }

        }

    }
}
