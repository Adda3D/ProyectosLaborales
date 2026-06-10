using IrisUNAL.Api.Entities.Repositories.Investigacion;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.Investigacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
namespace IrisUNAL.Api.Controllers.Investigacion
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class InvestigacionExcelControlFinancieroController : BaseController<InvestigacionExcelControlFinanciero>
    {
        private readonly InvestigacionExcelControlFinancieroRepository _InvestigacionExcelControlFinancieroRepository;
        public InvestigacionExcelControlFinancieroController(InvestigacionExcelControlFinancieroRepository InvestigacionExcelControlFinancieroRepository)
        {
            InvestigacionExcelControlFinancieroRepository = Investigacion_ExcelControlFinancieroRepository;
        }
        readonly InvestigacionExcelControlFinancieroRepository Investigacion_ExcelControlFinancieroRepository = new InvestigacionExcelControlFinancieroRepository();
        public InvestigacionExcelControlFinancieroController()
        {
            _InvestigacionExcelControlFinancieroRepository = Investigacion_ExcelControlFinancieroRepository;
        }


        [HttpGet]
        public IHttpActionResult ReporteInvestigacionControlFinanciero(int id_crearproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data =
               _InvestigacionExcelControlFinancieroRepository.ExcelInvestigacionControlFinanciero(id_crearproyecto);
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
