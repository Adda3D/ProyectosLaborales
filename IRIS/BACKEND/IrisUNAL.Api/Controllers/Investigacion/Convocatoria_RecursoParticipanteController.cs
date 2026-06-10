using IrisUNAL.Api.Entities.Repositories.Investigacion;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.Investigacion;
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

namespace IrisUNAL.Api.Controllers.Investigacion
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class Convocatoria_RecursoParticipanteController : BaseController<Convocatoria_RecursoParticipante>
    {
        private readonly Convocatoria_RecursoParticipanteRepository _convocatoria_RecursoParticipanteRepository;
        public Convocatoria_RecursoParticipanteController (Convocatoria_RecursoParticipanteRepository convocatoria_RecursoParticipanteRepository)
        {
            _convocatoria_RecursoParticipanteRepository = convocatoria_RecursoParticipanteRepository;
        }
        readonly Convocatoria_RecursoParticipanteRepository convocatoria_RecursoParticipanteRepository = new Convocatoria_RecursoParticipanteRepository();
        public Convocatoria_RecursoParticipanteController()
        {
            _convocatoria_RecursoParticipanteRepository = convocatoria_RecursoParticipanteRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllConvocatoria_RecursoParticipante()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = convocatoria_RecursoParticipanteRepository.GetAllConvocatoria_RecursoParticipante();

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
        public IHttpActionResult GetConvocatoria_RecursoParticipanteDetails(int id_recursoparticipante)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = convocatoria_RecursoParticipanteRepository.GetConvocatoria_RecursoParticipanteDetails(id_recursoparticipante);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Recurso inexistente";
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
        public IHttpActionResult GetConvocatoria_RecursoParticipanteNombre(string cd_nmrecurso)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = convocatoria_RecursoParticipanteRepository.GetConvocatoria_RecursoParticipanteNombre(cd_nmrecurso);
        

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Recurso inexistente";
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
        public IHttpActionResult InsertConvocatoria_RecursoParticipante([FromBody] Convocatoria_RecursoParticipante convocatoria_RecursoParticipante)
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

                var created = convocatoria_RecursoParticipanteRepository.InsertConvocatoria_RecursoParticipante(convocatoria_RecursoParticipante);

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
        public IHttpActionResult UpdateConvocatoria_RecursoParticipante([FromBody] Convocatoria_RecursoParticipante convocatoria_RecursoParticipante)
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

                var created = convocatoria_RecursoParticipanteRepository.UpdateConvocatoria_RecursoParticipante(convocatoria_RecursoParticipante);

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
        public IHttpActionResult DeleteConvocatoria_RecursoParticipante(int id_recursoparticipante)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = convocatoria_RecursoParticipanteRepository.DeleteConvocatoria_RecursoParticipante(id_recursoparticipante);

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
        public IHttpActionResult GetDataTableConvocatoria_RecursoParticipanteByConvocatoria(int id_convocatoria)
        {
            DataTableAdapter<Convocatoria_RecursoParticipante> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = convocatoria_RecursoParticipanteRepository.GetDataTableConvocatoria_RecursoParticipanteByConvocatoria(id_convocatoria, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
