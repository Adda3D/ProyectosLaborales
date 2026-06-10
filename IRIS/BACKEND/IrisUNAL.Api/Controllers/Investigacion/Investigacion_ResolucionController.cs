using IrisUNAL.Api.Entities.Repositories.Investigacion;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.Investigacion;
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

namespace IrisUNAL.Api.Controllers.Investigacion
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Investigacion_ResolucionController : BaseController<Investigacion_Resolucion>
    {
        private readonly Investigacion_ResolucionRepository _investigacion_resolucionRepository;

        // Constructor con inyección de dependencias
        public Investigacion_ResolucionController(Investigacion_ResolucionRepository investigacion_resolucionRepository)
        {
            _investigacion_resolucionRepository = investigacion_resolucionRepository;
        }

        // Constructor sin inyección de dependencias (en caso de que se necesite)
        public Investigacion_ResolucionController()
        {
            _investigacion_resolucionRepository = new Investigacion_ResolucionRepository();
        }


        [HttpGet]
        public IHttpActionResult GetAllInvestigacion_ResolucionByProyecto(int id_crearproyecto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_resolucionRepository.GetAllInvestigacion_ResolucionByProyecto(id_crearproyecto);

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
        public IHttpActionResult InsertInvestigacion_Resolucion([FromBody] Investigacion_Resolucion _investigacion_resolucion)
        {
            var resultdb = new ResultObject();

            try
            {
                // Valida basado en los DataAnnotations del modelo
                if (!ModelState.IsValid)
                {
                    resultdb.Ok = false;
                    resultdb.Message = Request.CreateResponse(ModelState).ToString();
                    resultdb.Data = null;
                    return Return(resultdb); // Necesitamos devolver el resultado aquí si hay errores de validación.
                }

                var created = _investigacion_resolucionRepository.InsertInvestigacion_Resolucion(_investigacion_resolucion);

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
        public IHttpActionResult UpdateInvestigacion_Resolucion([FromBody] Investigacion_Resolucion _investigacion_resolucion)
        {
            var resultdb = new ResultObject();

            try
            {
                // Valida basado en los DataAnnotations del modelo
                if (!ModelState.IsValid)
                {
                    resultdb.Ok = false;
                    resultdb.Message = Request.CreateResponse(ModelState).ToString();
                    resultdb.Data = null;
                    return Return(resultdb); // Devolver el resultado aquí si hay errores de validación.
                }

                var updated = _investigacion_resolucionRepository.UpdateInvestigacion_Resolucion(_investigacion_resolucion);

                resultdb.Ok = true;
                resultdb.Message = "";
                resultdb.Data = updated;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteInvestigacion_Resolucion(int id_proyectoresolucion)
        {
            var resultdb = new ResultObject();
            try
            {
                // Valida las reglas de borrado si es necesario.

                var deleted = _investigacion_resolucionRepository.DeleteInvestigacion_Resolucion(id_proyectoresolucion);

                resultdb.Ok = true;
                resultdb.Message = "";
                resultdb.Data = deleted;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetInvestigacion_ResolucionDetails(int id_proyectoresolucion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_resolucionRepository.GetInvestigacion_ResolucionDetails(id_proyectoresolucion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false; // Cambié a false porque si no existe, no es OK.
                    resultdb.Message = "Resolución Inexistente";
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
 
        public IHttpActionResult GetDataTableInvestigacion_ResolucionByProyecto(int id_crearproyecto)
        {
            DataTableAdapter<Investigacion_ResolucionDto> resultado = null;  // Cambiado a Investigacion_ResolucionDto
            DataTableRequest model = new DataTableRequest();

            try
            {
                // Parseamos el request que viene de DataTables
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                // Convertimos el request a un modelo de DataTable
                model = NvcToDataTablesModel(dtrequest);

                // Obtenemos los datos desde el repositorio
                resultado = _investigacion_resolucionRepository.GetDataTableInvestigacion_ResolucionByProyecto(id_crearproyecto, model);

                // Devolvemos los resultados en el formato esperado por DataTables
                return Ok(new
                {
                    draw = model.draw, // Esto viene del frontend de DataTables
                    recordsTotal = resultado.RecordsTotal,
                    recordsFiltered = resultado.RecordsFiltered,
                    data = resultado.Data
                });
            }
            catch (Exception ex)
            {
                // Manejo del error
                return InternalServerError(ex);
            }
        }


        [HttpGet]
        public IHttpActionResult GetResolucionesByProyecto(int id_crearproyecto)
        {
            try
            {
                // Consulta al repositorio para obtener las resoluciones asociadas al proyecto
                var resoluciones = _investigacion_resolucionRepository
                                   .GetResolucionesByProyecto(id_crearproyecto);

                if (resoluciones == null || !resoluciones.Any())
                {
                    return NotFound();
                }

                // Retornamos las resoluciones, accediendo al numresolucion a través de UGI_Semestre
                return Ok(resoluciones.Select(r => new {
                    r.id_proyectoresolucion,
                    numresolucion = r.UGI_Semestre != null ? r.UGI_Semestre.numresolucion : "Sin relación"
                }));
            }
            catch (Exception ex)
            {
                // Manejo del error
                return InternalServerError(ex);
            }
        }





    }
}
