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
    public class DecVie_ControlFinancieroOperativosController : BaseController<DecVie_ControlFinancieroOperativos>
    {
        private readonly IDecVie_ControlFinancieroOperativosRepository _decVie_ControlFinancieroOperativosRepository;
        public DecVie_ControlFinancieroOperativosController(IDecVie_ControlFinancieroOperativosRepository decVie_ControlFinancieroOperativosRepository)
        {
            _decVie_ControlFinancieroOperativosRepository = decVie_ControlFinancieroOperativosRepository;
        }
        readonly IDecVie_ControlFinancieroOperativosRepository decVie_ControlFinancieroOperativosRepository = new DecVie_ControlFinancieroOperativosRepository();
        public DecVie_ControlFinancieroOperativosController()
        {
            _decVie_ControlFinancieroOperativosRepository = decVie_ControlFinancieroOperativosRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_ControlFinancieroOperativos()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ControlFinancieroOperativosRepository.GetAllDecVie_ControlFinancieroOperativos();

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
        public IHttpActionResult GetDecVie_ControlFinancieroOperativosDetails(int id_operativos)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_ControlFinancieroOperativosRepository.GetDecVie_ControlFinancieroOperativosDetails(id_operativos);

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
        public IHttpActionResult InsertDecVie_ControlFinancieroOperativos([FromBody] DecVie_ControlFinancieroOperativos decVie_ControlFinancieroOperativos)
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

                var created = decVie_ControlFinancieroOperativosRepository.InsertDecVie_ControlFinancieroOperativos(decVie_ControlFinancieroOperativos);

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
        public IHttpActionResult UpdateDecVie_ControlFinancieroOperativos([FromBody] DecVie_ControlFinancieroOperativos decVie_ControlFinancieroOperativos)
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

                var created = decVie_ControlFinancieroOperativosRepository.UpdateDecVie_ControlFinancieroOperativos(decVie_ControlFinancieroOperativos);

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
        public IHttpActionResult DeleteDecVie_ControlFinancieroOperativos(int id_operativos)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_ControlFinancieroOperativosRepository.DeleteDecVie_ControlFinancieroOperativos(id_operativos);

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
