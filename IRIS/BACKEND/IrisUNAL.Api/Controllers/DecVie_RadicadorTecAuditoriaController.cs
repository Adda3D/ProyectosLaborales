using System;
using System.Web.Http;
using IrisUNAL.Api.Entities.Repositories;
using IrisUNAL.Api.Models;

namespace IrisUNAL.Api.Controllers
{
    public class DecVie_RadicadorTecAuditoriaController : ApiController
    {
        private readonly IDecVie_RadicadorTecAuditoriaRepository _auditoriaRepo;

        public DecVie_RadicadorTecAuditoriaController()
        {
            _auditoriaRepo = new DecVie_RadicadorTecAuditoriaRepository();
        }

        [HttpGet]
        public IHttpActionResult GetHistorialByRadicador(int id_decvieradicadortec)
        {
            var resultdb = new ResultObject();

            try
            {
                var historial = _auditoriaRepo.GetHistorialByRadicador(id_decvieradicadortec);

                resultdb.Ok = true;
                resultdb.Message = "";
                resultdb.Data = historial;

                return Ok(resultdb);
            }
            catch (Exception ex)
            {
                resultdb.Ok = false;
                resultdb.Message = ex.Message;
                resultdb.Data = null;
                return Ok(resultdb);
            }
        }


        [HttpPost]
        public IHttpActionResult InsertAuditoria([FromBody] DecVie_RadicadorTecAuditoria auditoria)
        {
            var resultdb = new ResultObject();

            try
            {
                var creado = _auditoriaRepo.InsertAuditoria(auditoria);
                resultdb.Ok = true;
                resultdb.Data = creado;
                return Ok(resultdb);
            }
            catch (Exception ex)
            {
                resultdb.Ok = false;
                resultdb.Message = ex.Message;
                resultdb.Data = null;
                return Ok(resultdb);
            }
        }

    }
}
