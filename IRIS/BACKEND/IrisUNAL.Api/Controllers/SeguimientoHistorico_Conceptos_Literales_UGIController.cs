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
    public class SeguimientoHistorico_Conceptos_Literales_UGIController : BaseController<SeguimientoHistorico_Conceptos_Literales_UGI>
    {
        private readonly ISeguimientoHistorico_Conceptos_Literales_UGIRepository _seguimientoHistorico_Conceptos_Literales_UGIRepository;

        public SeguimientoHistorico_Conceptos_Literales_UGIController(ISeguimientoHistorico_Conceptos_Literales_UGIRepository seguimientoHistorico_Conceptos_Literales_UGIRepository)
        {
            _seguimientoHistorico_Conceptos_Literales_UGIRepository = seguimientoHistorico_Conceptos_Literales_UGIRepository;
        }

        readonly ISeguimientoHistorico_Conceptos_Literales_UGIRepository seguimientoHistorico_Conceptos_Literales_UGIRepository = new SeguimientoHistorico_Conceptos_Literales_UGIRepository();
        public SeguimientoHistorico_Conceptos_Literales_UGIController()
        {
            _seguimientoHistorico_Conceptos_Literales_UGIRepository = seguimientoHistorico_Conceptos_Literales_UGIRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllSeguimientoHistorico_Conceptos_Literales_UGI()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimientoHistorico_Conceptos_Literales_UGIRepository.GetAllSeguimientoHistorico_Conceptos_Literales_UGI();

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
        public IHttpActionResult GetSeguimientoHistorico_Conceptos_Literales_UGIDetails(int id_ejesemugi)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimientoHistorico_Conceptos_Literales_UGIRepository.GetSeguimientoHistorico_Conceptos_Literales_UGIDetails(id_ejesemugi);

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
        public IHttpActionResult GetSeguimientoHistorico_Conceptos_Literales_UGIDetails(string cd_numeroresolucion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimientoHistorico_Conceptos_Literales_UGIRepository.GetSeguimientoHistorico_Conceptos_Literales_UGIDetails(cd_numeroresolucion);

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
        public IHttpActionResult InsertSeguimientoHistorico_Conceptos_Literales_UGI([FromBody] SeguimientoHistorico_Conceptos_Literales_UGI seguimientoHistorico_Conceptos_Literales_UGI)
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

                var created = _seguimientoHistorico_Conceptos_Literales_UGIRepository.InsertSeguimientoHistorico_Conceptos_Literales_UGI(seguimientoHistorico_Conceptos_Literales_UGI);

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
        public IHttpActionResult UpdateSeguimientoHistorico_Conceptos_Literales_UGI([FromBody] SeguimientoHistorico_Conceptos_Literales_UGI seguimientoHistorico_Conceptos_Literales_UGI)
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

                var created = _seguimientoHistorico_Conceptos_Literales_UGIRepository.UpdateSeguimientoHistorico_Conceptos_Literales_UGI(seguimientoHistorico_Conceptos_Literales_UGI);

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
        public IHttpActionResult DeleteSeguimientoHistorico_Conceptos_Literales_UGI(int id_ejesemugi)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _seguimientoHistorico_Conceptos_Literales_UGIRepository.DeleteSeguimientoHistorico_Conceptos_Literales_UGI(id_ejesemugi);

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
