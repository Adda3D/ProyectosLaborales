using IrisUNAL.Api.Entities.Repositories;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IrisUNAL.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Seguimiento_AcuerdoController : BaseController<Seguimiento_Acuerdo>
    {
        private readonly Seguimiento_AcuerdoRepository _seguimiento_acuerdoRepository;
        public Seguimiento_AcuerdoController(Seguimiento_AcuerdoRepository seguimiento_acuerdoRepository)
        {
            _seguimiento_acuerdoRepository = seguimiento_acuerdoRepository;
        }
        readonly Seguimiento_AcuerdoRepository seguimiento_acuerdoRepository = new Seguimiento_AcuerdoRepository();
        public Seguimiento_AcuerdoController()
        {
            _seguimiento_acuerdoRepository = seguimiento_acuerdoRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllSeguimiento_Acuerdo()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_acuerdoRepository.GetAllSeguimiento_Acuerdo();

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
        public IHttpActionResult GetSeguimiento_AcuerdoDetails(int idacuerdo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_acuerdoRepository.GetSeguimiento_AcuerdoDetails(idacuerdo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Acuerdo inexistente";
                }

                resultdb.Data = data;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }
        [HttpGet]
        public IHttpActionResult GetSeguimiento_AcuerdoNroAcuerdo(string nroacuerdo)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_acuerdoRepository.GetSeguimiento_AcuerdoNroAcuerdo(nroacuerdo);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Acuerdo inexistente";
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
        public IHttpActionResult InsertSeguimiento_Acuerdo([FromBody] Seguimiento_Acuerdo seguimiento_acuerdo)
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

                var created = _seguimiento_acuerdoRepository.InsertSeguimiento_Acuerdo(seguimiento_acuerdo);

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
        public IHttpActionResult UpdateSeguimiento_Acuerdo([FromBody] Seguimiento_Acuerdo seguimiento_acuerdo)
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

                var created = _seguimiento_acuerdoRepository.UpdateSeguimiento_Acuerdo(seguimiento_acuerdo);

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
        public IHttpActionResult DeleteSeguimiento_Acuerdo(int idacuerdo)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _seguimiento_acuerdoRepository.DeleteSeguimiento_Acuerdo(idacuerdo);

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
        public IHttpActionResult GetDataTableSeguimiento_AcuerdoByProyecto(int id_asignacionproyecto)
        {
            DataTableAdapter<Seguimiento_Acuerdo> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _seguimiento_acuerdoRepository.GetDataTableSeguimiento_AcuerdoByProyecto(id_asignacionproyecto, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
