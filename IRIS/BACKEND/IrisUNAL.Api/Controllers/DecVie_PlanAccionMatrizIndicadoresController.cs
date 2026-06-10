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
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class DecVie_PlanAccionMatrizIndicadoresController : BaseController<DecVie_PlanAccionMatrizIndicadores>
    {
        private readonly IDecVie_PlanAccionMatrizIndicadoresRepository _decVie_PlanAccionMatrizIndicadoresRepository;
        public DecVie_PlanAccionMatrizIndicadoresController(IDecVie_PlanAccionMatrizIndicadoresRepository decVie_PlanAccionMatrizIndicadoresRepository)
        {
            _decVie_PlanAccionMatrizIndicadoresRepository = decVie_PlanAccionMatrizIndicadoresRepository;
        }
        readonly IDecVie_PlanAccionMatrizIndicadoresRepository decVie_PlanAccionMatrizIndicadoresRepository = new DecVie_PlanAccionMatrizIndicadoresRepository();
        public DecVie_PlanAccionMatrizIndicadoresController()
        {
            _decVie_PlanAccionMatrizIndicadoresRepository = decVie_PlanAccionMatrizIndicadoresRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_PlanAccionMatrizIndicadores()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionMatrizIndicadoresRepository.GetAllDecVie_PlanAccionMatrizIndicadores();

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
        public IHttpActionResult GetDecVie_PlanAccionMatrizIndicadoresDetails(int id_matrizindicadores)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_PlanAccionMatrizIndicadoresRepository.GetDecVie_PlanAccionMatrizIndicadoresDetails(id_matrizindicadores);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "DecVie_PlanAccionMatrizIndicadores inexistente";
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
        public IHttpActionResult InsertDecVie_PlanAccionMatrizIndicadores([FromBody] DecVie_PlanAccionMatrizIndicadores decVie_PlanAccionMatrizIndicadores)
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

                var created = decVie_PlanAccionMatrizIndicadoresRepository.InsertDecVie_PlanAccionMatrizIndicadores(decVie_PlanAccionMatrizIndicadores);

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
        public IHttpActionResult UpdateDecVie_PlanAccionMatrizIndicadores([FromBody] DecVie_PlanAccionMatrizIndicadores decVie_PlanAccionMatrizIndicadores)
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

                var created = decVie_PlanAccionMatrizIndicadoresRepository.UpdateDecVie_PlanAccionMatrizIndicadores(decVie_PlanAccionMatrizIndicadores);

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
        public IHttpActionResult DeleteDecVie_PlanAccionMatrizIndicadores(int id_matrizindicadores)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_PlanAccionMatrizIndicadoresRepository.DeleteDecVie_PlanAccionMatrizIndicadores(id_matrizindicadores);

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
