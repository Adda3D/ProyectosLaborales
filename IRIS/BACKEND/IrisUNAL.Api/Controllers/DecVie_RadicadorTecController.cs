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
    public class DecVie_RadicadorTecController : BaseController<DecVie_RadicadorTec>
    {
        private readonly IDecVie_RadicadorTecRepository _decVie_RadicadorTecRepository;
        public DecVie_RadicadorTecController(IDecVie_RadicadorTecRepository decVie_RadicadorTecRepository)
        {
            _decVie_RadicadorTecRepository = decVie_RadicadorTecRepository;
        }
        readonly IDecVie_RadicadorTecRepository decVie_RadicadorTecRepository = new DecVie_RadicadorTecRepository();
        public DecVie_RadicadorTecController()
        {
            _decVie_RadicadorTecRepository = decVie_RadicadorTecRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_RadicadorTec()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_RadicadorTecRepository.GetAllDecVie_RadicadorTec();

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
        public IHttpActionResult GetDecVie_RadicadorTecDetails(int id_decvieradicadortec)
        {
            var resultdb = new ResultObject();
            try
            {
                //var data = decVie_RadicadorTecRepository.GetDecVie_RadicadorTecDetails(id_decvieradicadortec);
                var data = decVie_RadicadorTecRepository.GetRadicadorTecWithRelations(id_decvieradicadortec);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "RadicadorTec inexistente";
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
        public IHttpActionResult GetDecVie_RadicadorTecNumero(string cd_numradicadortec)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_RadicadorTecRepository.GetDecVie_RadicadorTecNumero(cd_numradicadortec);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "RadicadorTec inexistente";
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
        public IHttpActionResult InsertDecVie_RadicadorTec([FromBody] DecVie_RadicadorTec decVie_RadicadorTec)
        {
            var resultdb = new ResultObject();

            try
            {
                if (!ModelState.IsValid)
                {
                    resultdb.Ok = false;
                    resultdb.Message = Request.CreateResponse(ModelState).ToString();
                    resultdb.Data = null;
                }

                var created = decVie_RadicadorTecRepository.InsertDecVie_RadicadorTec(decVie_RadicadorTec);

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
        public IHttpActionResult InsertDecVie_RadicadorTec_Data([FromBody] DecVie_RadicadorTec decVie_RadicadorTec)
        {
            var resultdb = new ResultObject();

            try
            {
                if (!ModelState.IsValid)
                {
                    resultdb.Ok = false;
                    resultdb.Message = Request.CreateResponse(ModelState).ToString();
                    resultdb.Data = null;
                }

                var created = decVie_RadicadorTecRepository.InsertDecVie_RadicadorTec_Data(decVie_RadicadorTec);

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
        public IHttpActionResult UpdateDecVie_RadicadorTec([FromBody] DecVie_RadicadorTec decVie_RadicadorTec)
        {
            var resultdb = new ResultObject();

            try
            {
                if (!ModelState.IsValid)
                {
                    resultdb.Ok = false;
                    resultdb.Message = Request.CreateResponse(ModelState).ToString();
                    resultdb.Data = null;
                }

                var created = decVie_RadicadorTecRepository.UpdateDecVie_RadicadorTec(decVie_RadicadorTec);

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
        public IHttpActionResult UpdateDecVie_RadicadorTec_Data([FromBody] DecVie_RadicadorTec decVie_RadicadorTec)
        {
            var resultdb = new ResultObject();

            try
            {
                if (!ModelState.IsValid)
                {
                    resultdb.Ok = false;
                    resultdb.Message = Request.CreateResponse(ModelState).ToString();
                    resultdb.Data = null;
                }

                var created = decVie_RadicadorTecRepository.UpdateDecVie_RadicadorTec_Data(decVie_RadicadorTec);

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
        public IHttpActionResult DeleteDecVie_RadicadorTec(int id_decvieradicadortec)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_RadicadorTecRepository.DeleteDecVie_RadicadorTec(id_decvieradicadortec);

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
        public IHttpActionResult GetDataTableDecVie_RadicadorTec()
        {
            DataTableAdapter<DecVie_RadicadorTec> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_RadicadorTecRepository.GetDataTableDecVie_RadicadorTec(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

        //public IHttpActionResult GetDataTableDecVie_RadicadorTecPrueba()
        //{
        //    DataTableAdapter<DecVie_RadicadorTecDTO> resultado = null; 
        //    DataTableRequest model = new DataTableRequest();

        //    try
        //    {
        //        NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

        //        model = NvcToDataTablesModel(dtrequest);

        //        resultado = decVie_RadicadorTecRepository.GetDataTableDecVie_RadicadorTecPrueba(model);

        //        return Ok(resultado); // Retorna el resultado correctamente
        //    }
        //    catch (Exception ex)
        //    {
        //        return Content(HttpStatusCode.InternalServerError, ex.Message);
        //    }
        //}
        public IHttpActionResult GetDataTableDecVie_RadicadorTecPrueba()
        {
            DataTableAdapter<DecVie_RadicadorTecDTO> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                // Leer parámetros del DataTable
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);
                model = NvcToDataTablesModel(dtrequest);

                // Procesar filtro de funcionario
                int? filtroFuncionario = null;
                if (dtrequest["filtroFuncionario"] != null && int.TryParse(dtrequest["filtroFuncionario"], out int val))
                {
                    filtroFuncionario = val;
                }

                // Llamar al repositorio con el filtro
                resultado = decVie_RadicadorTecRepository.GetDataTableDecVie_RadicadorTecPrueba(model, filtroFuncionario);

                return Ok(resultado); // Retorna el resultado correctamente
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


    }
}

