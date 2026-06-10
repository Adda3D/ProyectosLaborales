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
    [EnableCors(origins: "*", headers: "*", methods:"*")]
    public class ContrapartidasController : BaseController<Contrapartidas>
    {
        public IContrapartidasRepository _contrapartidasRepository;
        private ContrapartidasController(IContrapartidasRepository contrapartidasRepository)
        {
            _contrapartidasRepository = contrapartidasRepository;
        }
        readonly IContrapartidasRepository contrapartidasRepository = new ContrapartidasRepository();
        public ContrapartidasController()
        {
            _contrapartidasRepository = contrapartidasRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllContrapartidas()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _contrapartidasRepository.GetAllContrapartidas();

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
        public IHttpActionResult GetContrapartidasDetails(int id_contrapartidas)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _contrapartidasRepository.GetContrapartidasDetails(id_contrapartidas);

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
        public IHttpActionResult InsertContrapartidas([FromBody] Contrapartidas contrapartidas)
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

                var created = _contrapartidasRepository.InsertContrapartidas(contrapartidas);

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
        public IHttpActionResult UpdateContrapartidas([FromBody] Contrapartidas contrapartidas)
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

                var created = _contrapartidasRepository.UpdateContrapartidas(contrapartidas);

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
        public IHttpActionResult DeleteContrapartidas(int id_contrapartidas)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _contrapartidasRepository.DeleteContrapartidas(id_contrapartidas);

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
