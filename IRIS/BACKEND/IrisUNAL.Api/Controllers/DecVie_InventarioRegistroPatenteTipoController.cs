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
    public class DecVie_InventarioRegistroPatenteTipoController : BaseController<DecVie_InventarioRegistroPatenteTipo>
    {
        private readonly IDecVie_InventarioRegistroPatenteTipoRepository _decVie_InventarioRegistroPatenteTipoRepository;
        public DecVie_InventarioRegistroPatenteTipoController(IDecVie_InventarioRegistroPatenteTipoRepository decVie_InventarioRegistroPatenteTipoRepository)
        {
            _decVie_InventarioRegistroPatenteTipoRepository = decVie_InventarioRegistroPatenteTipoRepository;
        }
        readonly IDecVie_InventarioRegistroPatenteTipoRepository decVie_InventarioRegistroPatenteTipoRepository = new DecVie_InventarioRegistroPatenteTipoRepository();
        public DecVie_InventarioRegistroPatenteTipoController()
        {
            _decVie_InventarioRegistroPatenteTipoRepository = decVie_InventarioRegistroPatenteTipoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_InventarioRegistroPatenteTipo()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioRegistroPatenteTipoRepository.GetAllDecVie_InventarioRegistroPatenteTipo();

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
        public IHttpActionResult GetDecVie_InventarioRegistroPatenteTipoDetails(int id_patentetipo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioRegistroPatenteTipoRepository.GetDecVie_InventarioRegistroPatenteTipoDetails(id_patentetipo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_Macroproceso inexistente";
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
        public IHttpActionResult GetDecVie_InventarioRegistroPatenteTipoNombre(string cd_nmpatentetipo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioRegistroPatenteTipoRepository.GetDecVie_InventarioRegistroPatenteTipoNombre(cd_nmpatentetipo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_Macroproceso inexistente";
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
        public IHttpActionResult InsertDecVie_InventarioRegistroPatenteTipo([FromBody] DecVie_InventarioRegistroPatenteTipo decVie_InventarioRegistroPatenteTipo)
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

                var created = decVie_InventarioRegistroPatenteTipoRepository.InsertDecVie_InventarioRegistroPatenteTipo(decVie_InventarioRegistroPatenteTipo);

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
        public IHttpActionResult UpdateDecVie_InventarioRegistroPatenteTipo([FromBody] DecVie_InventarioRegistroPatenteTipo decVie_InventarioRegistroPatenteTipo)
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

                var created = decVie_InventarioRegistroPatenteTipoRepository.UpdateDecVie_InventarioRegistroPatenteTipo(decVie_InventarioRegistroPatenteTipo);

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
        public IHttpActionResult DeleteDecVie_InventarioRegistroPatenteTipo(int id_patentetipo)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_InventarioRegistroPatenteTipoRepository.DeleteDecVie_InventarioRegistroPatenteTipo(id_patentetipo);

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
        public IHttpActionResult GetDataTableDecVie_InventarioRegistroPatenteTipo()
        {
            DataTableAdapter<DecVie_InventarioRegistroPatenteTipo> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_InventarioRegistroPatenteTipoRepository.GetDataTableDecVie_InventarioRegistroPatenteTipo(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
