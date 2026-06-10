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
    public class Seguimiento_FinancieroExcelController : BaseController<Seguimiento_FinancieroExcel>
    {
        private readonly ISeguimiento_FinancieroExcelRepository _seguimiento_FinancieroExcelRepository;

        public Seguimiento_FinancieroExcelController(ISeguimiento_FinancieroExcelRepository seguimiento_FinancieroExcelRepository)
        {
            _seguimiento_FinancieroExcelRepository = seguimiento_FinancieroExcelRepository;
        }

        readonly ISeguimiento_FinancieroExcelRepository seguimiento_FinancieroExcelRepository = new Seguimiento_FinancieroExcelRepository();
        public Seguimiento_FinancieroExcelController()
        {
            _seguimiento_FinancieroExcelRepository = seguimiento_FinancieroExcelRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllSeguimiento_FinancieroExcel()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_FinancieroExcelRepository.GetAllSeguimiento_FinancieroExcel();

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
        public IHttpActionResult GetSeguimiento_FinancieroExcelDetails(int id_financieroexcel)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_FinancieroExcelRepository.GetSeguimiento_FinancieroExcelDetails(id_financieroexcel);

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
        public IHttpActionResult GetSeguimiento_FinancieroExcelCodigo(string cd_codigoquipu)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_FinancieroExcelRepository.GetSeguimiento_FinancieroExcelCodigo(cd_codigoquipu);

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
        public IHttpActionResult InsertSeguimiento_FinancieroExcel([FromBody] Seguimiento_FinancieroExcel seguimiento_FinancieroExcel)
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

                var created = _seguimiento_FinancieroExcelRepository.InsertSeguimiento_FinancieroExcel(seguimiento_FinancieroExcel);

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
        public IHttpActionResult UpdateSeguimiento_FinancieroExcel([FromBody] Seguimiento_FinancieroExcel seguimiento_FinancieroExcel)
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

                var created = _seguimiento_FinancieroExcelRepository.UpdateSeguimiento_FinancieroExcel(seguimiento_FinancieroExcel);

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
        public IHttpActionResult DeleteSeguimiento_FinancieroExcel(int id_financieroexcel)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _seguimiento_FinancieroExcelRepository.DeleteSeguimiento_FinancieroExcel(id_financieroexcel);

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
