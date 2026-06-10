using IrisUNAL.Api.Entities.Repositories;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IrisUNAL.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Investigacion_ContrapartidaController : BaseController<Investigacion_Contrapartida>
    {
        private readonly IInvestigacion_ContrapartidaRepository _investigacion_ContrapartidaRepository;

        public Investigacion_ContrapartidaController(IInvestigacion_ContrapartidaRepository investigacion_ContrapartidaRepository)
        {
            _investigacion_ContrapartidaRepository = investigacion_ContrapartidaRepository;
        }

        readonly IInvestigacion_ContrapartidaRepository investigacion_ContrapartidaRepository = new Investigacion_ContrapartidaRepository();
        public Investigacion_ContrapartidaController()
        {
            _investigacion_ContrapartidaRepository = investigacion_ContrapartidaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllInvestigacion_Contrapartida()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_ContrapartidaRepository.GetAllInvestigacion_Contrapartida();

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
        public IHttpActionResult GetInvestigacion_ContrapartidaDetails(int id_contrapartida)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_ContrapartidaRepository.GetInvestigacion_ContrapartidaDetails(id_contrapartida);

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
        public IHttpActionResult GetInvestigacion_ContrapartidaCodigo(string cd_codigohermes)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_ContrapartidaRepository.GetInvestigacion_ContrapartidaCodigo(cd_codigohermes);

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
        [HttpPost]
        public IHttpActionResult InsertInvestigacion_Contrapartida([FromBody] Investigacion_Contrapartida investigacion_Contrapartida)
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

                var created = _investigacion_ContrapartidaRepository.InsertInvestigacion_Contrapartida(investigacion_Contrapartida);

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
        public IHttpActionResult UpdateInvestigacion_Contrapartida([FromBody] Investigacion_Contrapartida investigacion_Contrapartida)
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

                var created = _investigacion_ContrapartidaRepository.UpdateInvestigacion_Contrapartida(investigacion_Contrapartida);

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
        public IHttpActionResult DeleteInvestigacion_Contrapartida(int id_contrapartida)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _investigacion_ContrapartidaRepository.DeleteInvestigacion_Contrapartida(id_contrapartida);

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
    }
}
