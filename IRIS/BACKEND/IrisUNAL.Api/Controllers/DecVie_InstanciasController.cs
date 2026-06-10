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
    public class DecVie_InstanciasController : BaseController<DecVie_Instancias>
    {
        private readonly IDecVie_InstanciasRepository _decVie_InstanciasRepository;
        public DecVie_InstanciasController(IDecVie_InstanciasRepository decVie_InstanciasRepository)
        {
            _decVie_InstanciasRepository = decVie_InstanciasRepository;
        }
        readonly IDecVie_InstanciasRepository decVie_InstanciasRepository = new DecVie_InstanciasRepository();
        public DecVie_InstanciasController()
        {
            _decVie_InstanciasRepository = decVie_InstanciasRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_Instancias()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InstanciasRepository.GetAllDecVie_Instancias();

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
        public IHttpActionResult GetDecVie_InstanciasDetails(int id_instancia)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InstanciasRepository.GetDecVie_InstanciasDetails(id_instancia);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Instancia inexistente";
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
        public IHttpActionResult GetDecVie_InstanciasNombre(string cd_nminstancia)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_InstanciasRepository.GetDecVie_InstanciasNombre(cd_nminstancia);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Instancia inexistente";
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
        public IHttpActionResult InsertDecVie_Instancias([FromBody] DecVie_Instancias decVie_Instancias)
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

                var created = decVie_InstanciasRepository.InsertDecVie_Instancias(decVie_Instancias);

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
        public IHttpActionResult UpdateDecVie_Instancias([FromBody] DecVie_Instancias decVie_Instancias)
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

                var created = decVie_InstanciasRepository.UpdateDecVie_Instancias(decVie_Instancias);

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
        public IHttpActionResult DeleteDecVie_Instancias(int id_instancia)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_InstanciasRepository.DeleteDecVie_Instancias(id_instancia);

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
        public IHttpActionResult GetDataTableDecVie_Instancias()
        {
            DataTableAdapter<DecVie_Instancias> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_InstanciasRepository.GetDataTableDecVie_Instancias(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
    
}
