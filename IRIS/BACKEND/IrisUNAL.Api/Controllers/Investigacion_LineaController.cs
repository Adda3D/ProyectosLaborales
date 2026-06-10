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
    public class Investigacion_LineaController : BaseController<Investigacion_Linea>
    {
        private readonly IInvestigacion_LineaRepository _investigacion_LineaRepository;

        public Investigacion_LineaController(IInvestigacion_LineaRepository investigacion_LineaRepository)
        {
            _investigacion_LineaRepository = investigacion_LineaRepository;
        }

        readonly IInvestigacion_LineaRepository investigacion_LineaRepository = new Investigacion_LineaRepository();
        public Investigacion_LineaController()
        {
            _investigacion_LineaRepository = investigacion_LineaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllInvestigacion_Linea()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_LineaRepository.GetAllInvestigacion_Linea();

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
        public IHttpActionResult GetInvestigacion_LineaDetails(int id_linea)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_LineaRepository.GetInvestigacion_LineaDetails(id_linea);

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
        public IHttpActionResult GetInvestigacion_LineaCodigo(string cd_codigohermes)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_LineaRepository.GetInvestigacion_LineaCodigo(cd_codigohermes);

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
        public IHttpActionResult InsertInvestigacion_Linea([FromBody] Investigacion_Linea investigacion_Linea)
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

                var created = _investigacion_LineaRepository.InsertInvestigacion_Linea(investigacion_Linea);

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
        public IHttpActionResult UpdateInvestigacion_Linea([FromBody] Investigacion_Linea investigacion_Linea)
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

                var created = _investigacion_LineaRepository.UpdateInvestigacion_Linea(investigacion_Linea);

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
        public IHttpActionResult DeleteInvestigacion_Linea(int id_linea)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _investigacion_LineaRepository.DeleteInvestigacion_Linea(id_linea);

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
