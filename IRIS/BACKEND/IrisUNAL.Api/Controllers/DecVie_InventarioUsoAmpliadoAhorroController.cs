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
    public class DecVie_InventarioUsoAmpliadoAhorroController : BaseController<DecVie_InventarioUsoAmpliadoAhorro>
    {
        private readonly IDecVie_InventarioUsoAmpliadoAhorroRepository _decVie_InventarioUsoAmpliadoAhorroRepository;
        public DecVie_InventarioUsoAmpliadoAhorroController(IDecVie_InventarioUsoAmpliadoAhorroRepository decVie_InventarioUsoAmpliadoAhorroRepository)
        {
            _decVie_InventarioUsoAmpliadoAhorroRepository = decVie_InventarioUsoAmpliadoAhorroRepository;
        }
        readonly IDecVie_InventarioUsoAmpliadoAhorroRepository decVie_InventarioUsoAmpliadoAhorroRepository = new DecVie_InventarioUsoAmpliadoAhorroRepository();
        public DecVie_InventarioUsoAmpliadoAhorroController()
        {
            _decVie_InventarioUsoAmpliadoAhorroRepository = decVie_InventarioUsoAmpliadoAhorroRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_InventarioUsoAmpliadoAhorro()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioUsoAmpliadoAhorroRepository.GetAllDecVie_InventarioUsoAmpliadoAhorro();

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
        public IHttpActionResult GetDecVie_InventarioUsoAmpliadoAhorroDetails(int id_ahorro)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioUsoAmpliadoAhorroRepository.GetDecVie_InventarioUsoAmpliadoAhorroDetails(id_ahorro);

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
        public IHttpActionResult GetDecVie_InventarioUsoAmpliadoAhorroNombre(string cd_nmahorro)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InventarioUsoAmpliadoAhorroRepository.GetDecVie_InventarioUsoAmpliadoAhorroNombre(cd_nmahorro);

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
        public IHttpActionResult InsertDecVie_InventarioUsoAmpliadoAhorro([FromBody] DecVie_InventarioUsoAmpliadoAhorro decVie_InventarioUsoAmpliadoAhorro)
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

                var created = decVie_InventarioUsoAmpliadoAhorroRepository.InsertDecVie_InventarioUsoAmpliadoAhorro(decVie_InventarioUsoAmpliadoAhorro);

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
        public IHttpActionResult UpdateDecVie_InventarioUsoAmpliadoAhorro([FromBody] DecVie_InventarioUsoAmpliadoAhorro decVie_InventarioUsoAmpliadoAhorro)
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

                var created = decVie_InventarioUsoAmpliadoAhorroRepository.UpdateDecVie_InventarioUsoAmpliadoAhorro(decVie_InventarioUsoAmpliadoAhorro);

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
        public IHttpActionResult DeleteDecVie_InventarioUsoAmpliadoAhorro(int id_ahorro)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_InventarioUsoAmpliadoAhorroRepository.DeleteDecVie_InventarioUsoAmpliadoAhorro(id_ahorro);

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
        public IHttpActionResult GetDataTableDecVie_InventarioUsoAmpliadoAhorro()
        {
            DataTableAdapter<DecVie_InventarioUsoAmpliadoAhorro> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_InventarioUsoAmpliadoAhorroRepository.GetDataTableDecVie_InventarioUsoAmpliadoAhorro(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
