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
    public class DecVie_ActosAdministrativosController : BaseController<DecVie_ActosAdministrativos>
    {
        private readonly IDecVie_ActosAdministrativosRepository _decVie_ActosAdministrativosRepository;
        public DecVie_ActosAdministrativosController(IDecVie_ActosAdministrativosRepository decVie_ActosAdministrativosRepository)
        {
            _decVie_ActosAdministrativosRepository = decVie_ActosAdministrativosRepository;
        }
        readonly IDecVie_ActosAdministrativosRepository decVie_ActosAdministrativosRepository = new DecVie_ActosAdministrativosRepository();
        public DecVie_ActosAdministrativosController()
        {
            _decVie_ActosAdministrativosRepository = decVie_ActosAdministrativosRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_ActosAdministrativos()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ActosAdministrativosRepository.GetAllDecVie_ActosAdministrativos();

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

        public IHttpActionResult ExcelDecVie_ActosAdministrativos()
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = decVie_ActosAdministrativosRepository.ExcelDecVie_ActosAdministrativos();

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

        [HttpGet]
        public IHttpActionResult GetDecVie_ActosAdministrativosDetails(int id_actoadministrativo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ActosAdministrativosRepository.GetDecVie_ActosAdministrativosDetails(id_actoadministrativo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Acto Administrativo inexistente";
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
        public IHttpActionResult GetDecVie_ActosAdministrativosConsecutivo(string cd_consecutivoactoadministrativo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ActosAdministrativosRepository.GetDecVie_ActosAdministrativosConsecutivo(cd_consecutivoactoadministrativo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Acto Administrativo inexistente";
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
        public IHttpActionResult InsertDecVie_ActosAdministrativos([FromBody] DecVie_ActosAdministrativos decVie_ActosAdministrativos)
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

                var created = decVie_ActosAdministrativosRepository.InsertDecVie_ActosAdministrativos(decVie_ActosAdministrativos);

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
        public IHttpActionResult UpdateDecVie_ActosAdministrativos([FromBody] DecVie_ActosAdministrativos decVie_ActosAdministrativos)
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

                var created = decVie_ActosAdministrativosRepository.UpdateDecVie_ActosAdministrativos(decVie_ActosAdministrativos);

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
        public IHttpActionResult DeleteDecVie_ActosAdministrativos(int id_actoadministrativo)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_ActosAdministrativosRepository.DeleteDecVie_ActosAdministrativos(id_actoadministrativo);

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
        public IHttpActionResult GetDataTableDecVie_ActosAdministrativos()
        {
            DataTableAdapter<DecVie_ActosAdministrativos> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_ActosAdministrativosRepository.GetDataTableDecVie_ActosAdministrativos(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
