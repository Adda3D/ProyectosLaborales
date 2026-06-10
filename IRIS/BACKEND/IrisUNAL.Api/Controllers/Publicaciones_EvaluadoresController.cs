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
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class Publicaciones_EvaluadoresController : BaseController<Publicaciones_Evaluadores>
    {
        private readonly IPublicaciones_EvaluadoresRepository _publicaciones_EvaluadoresRepository;
        public Publicaciones_EvaluadoresController(IPublicaciones_EvaluadoresRepository publicaciones_EvaluadoresRepository)
        {
            _publicaciones_EvaluadoresRepository = publicaciones_EvaluadoresRepository;
        }
        readonly IPublicaciones_EvaluadoresRepository publicaciones_EvaluadoresRepository = new Publicaciones_EvaluadoresRepository();
        public Publicaciones_EvaluadoresController()
        {
            _publicaciones_EvaluadoresRepository = publicaciones_EvaluadoresRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_Evaluadores()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EvaluadoresRepository.GetAllPublicaciones_Evaluadores();

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
        public IHttpActionResult GetPublicaciones_EvaluadoresDetails(int id_evaluadores)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EvaluadoresRepository.GetPublicaciones_EvaluadoresDetails(id_evaluadores);

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
        public IHttpActionResult GetPublicaciones_EvaluadoresByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EvaluadoresRepository.GetPublicaciones_EvaluadoresByPublicacion(id_crearpublicacion);

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
        public IHttpActionResult GetPublicaciones_EvaluadoresExisteEvaluador(int id_crearpublicacion, int id_persona)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_EvaluadoresRepository.GetPublicaciones_EvaluadoresExisteEvaluador(id_crearpublicacion, id_persona);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Evaluador no asignado a la publicación";
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
        public IHttpActionResult InsertPublicaciones_Evaluadores([FromBody] Publicaciones_Evaluadores publicaciones_Evaluadores)
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

                var created = publicaciones_EvaluadoresRepository.InsertPublicaciones_Evaluadores(publicaciones_Evaluadores);

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
        public IHttpActionResult UpdatePublicaciones_Evaluadores([FromBody] Publicaciones_Evaluadores publicaciones_Evaluadores)
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

                var created = publicaciones_EvaluadoresRepository.UpdatePublicaciones_Evaluadores(publicaciones_Evaluadores);

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
        public IHttpActionResult DeletePublicaciones_Evaluadores(int id_evaluadores)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_EvaluadoresRepository.DeletePublicaciones_Evaluadores(id_evaluadores);

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
        public IHttpActionResult GetDataTablePublicaciones_EvaluadoresByPublicacion(int id_crearpublicacion)
        {
            DataTableAdapter<Publicaciones_Evaluadores> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_EvaluadoresRepository.GetDataTablePublicaciones_EvaluadoresByPublicacion(id_crearpublicacion, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }
    }
}
