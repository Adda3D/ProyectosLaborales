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
    public class Publicaciones_DivulgacionHerramientaController : BaseController<Publicaciones_DivulgacionHerramienta>
    {
        private readonly IPublicaciones_DivulgacionHerramientaRepository _publicaciones_DivulgacionHerramientaRepository;
        public Publicaciones_DivulgacionHerramientaController(IPublicaciones_DivulgacionHerramientaRepository publicaciones_DivulgacionHerramientaRepository)
        {
            _publicaciones_DivulgacionHerramientaRepository = publicaciones_DivulgacionHerramientaRepository;
        }
        readonly IPublicaciones_DivulgacionHerramientaRepository publicaciones_DivulgacionHerramientaRepository = new Publicaciones_DivulgacionHerramientaRepository();
        public Publicaciones_DivulgacionHerramientaController()
        {
            _publicaciones_DivulgacionHerramientaRepository = publicaciones_DivulgacionHerramientaRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DivulgacionHerramienta()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionHerramientaRepository.GetAllPublicaciones_DivulgacionHerramienta();

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
        public IHttpActionResult GetPublicaciones_DivulgacionHerramientaDetails(int id_herramienta)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionHerramientaRepository.GetPublicaciones_DivulgacionHerramientaDetails(id_herramienta);

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
        public IHttpActionResult InsertPublicaciones_DivulgacionHerramienta([FromBody] Publicaciones_DivulgacionHerramienta publicaciones_DivulgacionHerramienta)
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

                var created = publicaciones_DivulgacionHerramientaRepository.InsertPublicaciones_DivulgacionHerramienta(publicaciones_DivulgacionHerramienta);

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
        public IHttpActionResult UpdatePublicaciones_DivulgacionHerramienta([FromBody] Publicaciones_DivulgacionHerramienta publicaciones_DivulgacionHerramienta)
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

                var created = publicaciones_DivulgacionHerramientaRepository.UpdatePublicaciones_DivulgacionHerramienta(publicaciones_DivulgacionHerramienta);

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
        public IHttpActionResult DeletePublicaciones_DivulgacionHerramienta(int id_herramienta)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DivulgacionHerramientaRepository.DeletePublicaciones_DivulgacionHerramienta(id_herramienta);

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
        public IHttpActionResult GetDataTablePublicaciones_DivulgacionHerramientaByPublicacionTipo(int id_crearpublicacion, int id_tipomedio)
        {
            DataTableAdapter<Publicaciones_DivulgacionHerramienta> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_DivulgacionHerramientaRepository.GetDataTablePublicaciones_DivulgacionHerramientaByPublicacionTipo(id_crearpublicacion, id_tipomedio, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
