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
    public class Seguimiento_DesembolsoController : BaseController<Seguimiento_Desembolso>
    {
        private readonly ISeguimiento_DesembolsoRepository _seguimiento_DesembolsoRepository;

        public Seguimiento_DesembolsoController(ISeguimiento_DesembolsoRepository seguimiento_DesembolsoRepository)
        {
            _seguimiento_DesembolsoRepository = seguimiento_DesembolsoRepository;
        }

        readonly ISeguimiento_DesembolsoRepository seguimiento_DesembolsoRepository = new Seguimiento_DesembolsoRepository();
        public Seguimiento_DesembolsoController()
        {
            _seguimiento_DesembolsoRepository = seguimiento_DesembolsoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllSeguimiento_Desembolso()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_DesembolsoRepository.GetAllSeguimiento_Desembolso();

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
        public IHttpActionResult GetSeguimiento_DesembolsoDetails(int id_segdesembolso)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_DesembolsoRepository.GetSeguimiento_DesembolsoDetails(id_segdesembolso);

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
        public IHttpActionResult InsertSeguimiento_Desembolso([FromBody] Seguimiento_Desembolso seguimiento_Desembolso)
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

                var created = _seguimiento_DesembolsoRepository.InsertSeguimiento_Desembolso(seguimiento_Desembolso);

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
        public IHttpActionResult UpdateSeguimiento_Desembolso([FromBody] Seguimiento_Desembolso seguimiento_Desembolso)
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

                var created = _seguimiento_DesembolsoRepository.UpdateSeguimiento_Desembolso(seguimiento_Desembolso);

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
        public IHttpActionResult DeleteSeguimiento_Desembolso(int id_segdesembolso)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _seguimiento_DesembolsoRepository.DeleteSeguimiento_Desembolso(id_segdesembolso);

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
        public IHttpActionResult GetDataTableProyectoDesembolsosByProyecto(int id_asignacionproyecto)
        {
            DataTableAdapter<Seguimiento_Desembolso> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _seguimiento_DesembolsoRepository.GetDataTableProyectoDesembolsosByProyecto(id_asignacionproyecto, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

    }
}
