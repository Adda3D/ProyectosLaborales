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
    public class Decvie_MatryoshkaNuevoIndicadorController : BaseController<Decvie_MatryoshkaNuevoIndicador>
    {
        private readonly Decvie_MatryoshkaNuevoIndicadorRepository _decvie_MatryoshkaNuevoIndicadorRepository;
        public Decvie_MatryoshkaNuevoIndicadorController (Decvie_MatryoshkaNuevoIndicadorRepository decvie_MatryoshkaNuevoIndicadorRepository)
        {
            _decvie_MatryoshkaNuevoIndicadorRepository = decvie_MatryoshkaNuevoIndicadorRepository;
        }
        readonly Decvie_MatryoshkaNuevoIndicadorRepository decvie_MatryoshkaNuevoIndicadorRepository = new Decvie_MatryoshkaNuevoIndicadorRepository();
        public Decvie_MatryoshkaNuevoIndicadorController()
        {
            _decvie_MatryoshkaNuevoIndicadorRepository = decvie_MatryoshkaNuevoIndicadorRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecvie_MatryoshkaNuevoIndicador()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_MatryoshkaNuevoIndicadorRepository.GetAllDecvie_MatryoshkaNuevoIndicador();

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
        public IHttpActionResult GetDecvie_MatryoshkaNuevoIndicadorDetails(int id_matryoshkanuevoindicador)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decvie_MatryoshkaNuevoIndicadorRepository.GetDecvie_MatryoshkaNuevoIndicadorDetails(id_matryoshkanuevoindicador);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Nuevo Indicador inexistente";
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
        public IHttpActionResult InsertDecvie_MatryoshkaNuevoIndicador([FromBody] Decvie_MatryoshkaNuevoIndicador decvie_MatryoshkaNuevoIndicador )
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

                var created = decvie_MatryoshkaNuevoIndicadorRepository.InsertDecvie_MatryoshkaNuevoIndicador(decvie_MatryoshkaNuevoIndicador);

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
        public IHttpActionResult UpdateDecvie_MatryoshkaNuevoIndicador([FromBody] Decvie_MatryoshkaNuevoIndicador decvie_MatryoshkaNuevoIndicador)
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

                var created = decvie_MatryoshkaNuevoIndicadorRepository.UpdateDecvie_MatryoshkaNuevoIndicador(decvie_MatryoshkaNuevoIndicador);

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
        public IHttpActionResult DeleteDecvie_MatryoshkaNuevoIndicador(int id_matryoshkanuevoindicador)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decvie_MatryoshkaNuevoIndicadorRepository.DeleteDecvie_MatryoshkaNuevoIndicador(id_matryoshkanuevoindicador);

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
        public IHttpActionResult GetDataTableDecvie_MatryoshkaNuevoIndicador()
        {
            DataTableAdapter<Decvie_MatryoshkaNuevoIndicador> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_MatryoshkaNuevoIndicadorRepository.GetDataTableDecvie_MatryoshkaNuevoIndicador(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }
        [HttpGet]
        public IHttpActionResult GetDataTableDecvie_MatryoshkaNuevoIndicadorByMatryohska(int id_matryoska)
        {
            DataTableAdapter<Decvie_MatryoshkaNuevoIndicador> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decvie_MatryoshkaNuevoIndicadorRepository.GetDataTableDecvie_MatryoshkaNuevoIndicadorByMatryohska(id_matryoska, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
