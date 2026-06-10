using IrisUNAL.Api.Entities.Repositories;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
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
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class Publicaciones_CrearPublicacionController : BaseController<Publicaciones_CrearPublicacion>
    {
        private readonly IPublicaciones_CrearPublicacionRepository _publicaciones_CrearPublicacionRepository;
        public Publicaciones_CrearPublicacionController(IPublicaciones_CrearPublicacionRepository publicaciones_CrearPublicacionRepository)
        {
            _publicaciones_CrearPublicacionRepository = publicaciones_CrearPublicacionRepository;
        }
        readonly IPublicaciones_CrearPublicacionRepository publicaciones_CrearPublicacionRepository = new Publicaciones_CrearPublicacionRepository();
        public Publicaciones_CrearPublicacionController()
        {
            _publicaciones_CrearPublicacionRepository = publicaciones_CrearPublicacionRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_CrearPublicacion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CrearPublicacionRepository.GetAllPublicaciones_CrearPublicacion();

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
        public IHttpActionResult GetPublicaciones_CrearPublicacionDetails(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CrearPublicacionRepository.GetPublicaciones_CrearPublicacionDetails(id_crearpublicacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicación inexistente";
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
        public IHttpActionResult GetPublicaciones_CrearPublicacionCodigo(string cd_id_kardex)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CrearPublicacionRepository.GetPublicaciones_CrearPublicacionCodigo(cd_id_kardex);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicación inexistente";
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
        public IHttpActionResult GetPublicaciones_CrearPublicacionEvaluacionInicial(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CrearPublicacionRepository.GetPublicaciones_CrearPublicacionEvaluacionInicial(id_crearpublicacion);

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
        public IHttpActionResult InsertPublicaciones_CrearPublicacion([FromBody] Publicaciones_CrearPublicacion publicaciones_CrearPublicacion)
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

                var created = publicaciones_CrearPublicacionRepository.InsertPublicaciones_CrearPublicacion(publicaciones_CrearPublicacion);

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
        public IHttpActionResult UpdatePublicaciones_CrearPublicacion([FromBody] Publicaciones_CrearPublicacion publicaciones_CrearPublicacion)
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

                var created = publicaciones_CrearPublicacionRepository.UpdatePublicaciones_CrearPublicacion(publicaciones_CrearPublicacion);

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
        public IHttpActionResult UpdatePublicaciones_CrearPublicacionEvaluacion([FromBody] CrearPublicacionEvaluacionDTO update_evaluacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CrearPublicacionRepository.UpdatePublicaciones_CrearPublicacionEvaluacion(update_evaluacion.id_crearpublicacion, update_evaluacion.id_evaluacioninicial);

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

        [HttpDelete]
        public IHttpActionResult DeletePublicaciones_CrearPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_CrearPublicacionRepository.DeletePublicaciones_CrearPublicacion(id_crearpublicacion);

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
        public IHttpActionResult GetDataTablePublicaciones()
        {
            DataTableAdapter<Publicaciones_CrearPublicacion> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_CrearPublicacionRepository.GetDataTablePublicaciones(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetPublicaciones_CrearPublicacionAportes(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_CrearPublicacionRepository.GetPublicaciones_CrearPublicacionAportes(id_crearpublicacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicación inexistente";
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
        public IHttpActionResult UpdatePublicaciones_CrearPublicacionAportes(PublicacionTotalAportesDTO publicacion_aportes)
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

                var created = publicaciones_CrearPublicacionRepository.UpdatePublicaciones_CrearPublicacionAportes(publicacion_aportes);

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

        [HttpGet]
        public IHttpActionResult ExcelFinancieroPublicaciones_CrearPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = publicaciones_CrearPublicacionRepository.ExcelFinancieroPublicaciones_CrearPublicacion(id_crearpublicacion);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (archivoresultado == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Error creando Archivo Excel";
                }

                resultdb.Data = archivoresultado;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }
    }
}
