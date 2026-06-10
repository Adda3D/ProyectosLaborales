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
    public class DecVie_ControlFinancieroGastosController : BaseController<DecVie_ControlFinancieroGastos>
    {
        private readonly IDecVie_ControlFinancieroGastosRepository _decVie_ControlFinancieroGastosRepository;
        public DecVie_ControlFinancieroGastosController(IDecVie_ControlFinancieroGastosRepository decVie_ControlFinancieroGastosRepository)
        {
            _decVie_ControlFinancieroGastosRepository = decVie_ControlFinancieroGastosRepository;
        }
        readonly IDecVie_ControlFinancieroGastosRepository decVie_ControlFinancieroGastosRepository = new DecVie_ControlFinancieroGastosRepository();
        public DecVie_ControlFinancieroGastosController()
        {
            _decVie_ControlFinancieroGastosRepository = decVie_ControlFinancieroGastosRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_ControlFinancieroGastos()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ControlFinancieroGastosRepository.GetAllDecVie_ControlFinancieroGastos();

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
        public IHttpActionResult GetDecVie_ControlFinancieroGastosDetails(int id_gastos)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ControlFinancieroGastosRepository.GetDecVie_ControlFinancieroGastosDetails(id_gastos);

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
        public IHttpActionResult InsertDecVie_ControlFinancieroGastos([FromBody] DecVie_ControlFinancieroGastos decVie_ControlFinancieroGastos)
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

                var created = decVie_ControlFinancieroGastosRepository.InsertDecVie_ControlFinancieroGastos(decVie_ControlFinancieroGastos);

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
        public IHttpActionResult UpdateDecVie_ControlFinancieroGastos([FromBody] DecVie_ControlFinancieroGastos decVie_ControlFinancieroGastos)
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

                var created = decVie_ControlFinancieroGastosRepository.UpdateDecVie_ControlFinancieroGastos(decVie_ControlFinancieroGastos);

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
        public IHttpActionResult DeleteDecVie_ControlFinancieroGastos(int id_gastos)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_ControlFinancieroGastosRepository.DeleteDecVie_ControlFinancieroGastos(id_gastos);

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
