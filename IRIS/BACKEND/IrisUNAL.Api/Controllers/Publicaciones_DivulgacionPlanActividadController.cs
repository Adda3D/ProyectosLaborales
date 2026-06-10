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
    public class Publicaciones_DivulgacionPlanActividadController : BaseController<Publicaciones_DivulgacionPlanActividad>
    {
        private readonly Publicaciones_DivulgacionPlanActividadRepository _publicaciones_divulgacionplanactividadRepository;
        public Publicaciones_DivulgacionPlanActividadController(Publicaciones_DivulgacionPlanActividadRepository publicaciones_divulgacionplanactividadRepository)
        {
            _publicaciones_divulgacionplanactividadRepository = publicaciones_divulgacionplanactividadRepository;
        }
        readonly Publicaciones_DivulgacionPlanActividadRepository publicaciones_divulgacionplanactividadRepository = new Publicaciones_DivulgacionPlanActividadRepository();
        public Publicaciones_DivulgacionPlanActividadController()
        {
            _publicaciones_divulgacionplanactividadRepository = publicaciones_divulgacionplanactividadRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DivulgacionPlanActividad()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_divulgacionplanactividadRepository.GetAllPublicaciones_DivulgacionPlanActividad();

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
        public IHttpActionResult GetPublicaciones_DivulgacionPlanActividadDetails(int iddivulgacionplanactividad)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_divulgacionplanactividadRepository.GetPublicaciones_DivulgacionPlanActividadDetails(iddivulgacionplanactividad);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Detalle actividad plan divulgación inexistente";
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
        public IHttpActionResult InsertPublicaciones_DivulgacionPlanActividad([FromBody] Publicaciones_DivulgacionPlanActividad _publicaciones_divulgacionplanactividad)
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

                var created = _publicaciones_divulgacionplanactividadRepository.InsertPublicaciones_DivulgacionPlanActividad(_publicaciones_divulgacionplanactividad);

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
        public IHttpActionResult UpdatePublicaciones_DivulgacionPlanActividad([FromBody] Publicaciones_DivulgacionPlanActividad _publicaciones_divulgacionplanactividad)
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

                var created = _publicaciones_divulgacionplanactividadRepository.UpdatePublicaciones_DivulgacionPlanActividad(_publicaciones_divulgacionplanactividad);

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
        public IHttpActionResult DeletePublicaciones_DivulgacionPlanActividad(int iddivulgacionplanactividad)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _publicaciones_divulgacionplanactividadRepository.DeletePublicaciones_DivulgacionPlanActividad(iddivulgacionplanactividad);

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
        public IHttpActionResult GetPublicaciones_DivulgacionPlanActividadByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_divulgacionplanactividadRepository.GetPublicaciones_DivulgacionPlanActividadByPublicacion(id_crearpublicacion);

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
        public IHttpActionResult GetDataTablePublicaciones_DivulgacionPlanActividadByPublicacion(int id_crearpublicacion)
        {
            DataTableAdapter<Publicaciones_DivulgacionPlanActividad> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _publicaciones_divulgacionplanactividadRepository.GetDataTablePublicaciones_DivulgacionPlanActividadByPublicacion(id_crearpublicacion, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
