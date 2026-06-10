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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Decvie_MatryoshkaController : BaseController<Decvie_Matryoshka>
    {
        private readonly Decvie_MatryoshkaRepository _decvie_matryoshkaRepository;
        public Decvie_MatryoshkaController(Decvie_MatryoshkaRepository decvie_matryoshkaRepository)
        {
            _decvie_matryoshkaRepository = decvie_matryoshkaRepository;
        }
        readonly Decvie_MatryoshkaRepository decvie_matryoshkaRepository = new Decvie_MatryoshkaRepository();
        public Decvie_MatryoshkaController()
        {
            _decvie_matryoshkaRepository = decvie_matryoshkaRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllDecvie_Matryoshka()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_matryoshkaRepository.GetAllDecvie_Matryoshka();

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
        public IHttpActionResult GetDecvie_MatryoshkaDetails(int id_matryoska)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_matryoshkaRepository.GetDecvie_MatryoshkaDetails(id_matryoska);

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
        public IHttpActionResult InsertDecvie_Matryoshka([FromBody] Decvie_Matryoshka decvie_Matryoshka)
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

                var created = decvie_matryoshkaRepository.InsertDecvie_Matryoshka(decvie_Matryoshka);

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
        public IHttpActionResult UpdateDecvie_Matryoshka([FromBody] Decvie_Matryoshka decvie_Matryoshka)
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

                var created = decvie_matryoshkaRepository.UpdateDecvie_Matryoshka(decvie_Matryoshka);

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
        public IHttpActionResult DeleteDecvie_Matryoshka(int id_matryoska)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decvie_matryoshkaRepository.DeleteDecvie_Matryoshka(id_matryoska);

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
        public IHttpActionResult GetDataTableDecvie_Matryoshka()
        {
            DataTableAdapter<Decvie_Matryoshka> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_matryoshkaRepository.GetDataTableDecvie_Matryoshka(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }
        [HttpGet]
        public IHttpActionResult GetDataTableDecvie_MatryoshkaByDependencia(int id_depend)
        {
            DataTableAdapter<Decvie_Matryoshka> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_matryoshkaRepository.GetDataTableDecvie_MatryoshkaByDependencia(id_depend, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }

        [HttpGet]

        public IHttpActionResult ExcelDecvie_Matryoshka(int id_matryoska)
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = decvie_matryoshkaRepository.ExcelDecvie_Matryoshka(id_matryoska);

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
