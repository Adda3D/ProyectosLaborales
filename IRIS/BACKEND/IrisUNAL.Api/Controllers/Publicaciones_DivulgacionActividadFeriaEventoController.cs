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
    public class Publicaciones_DivulgacionActividadFeriaEventoController : BaseController<Publicaciones_DivulgacionActividadFeriaEvento>
    {
        private readonly Publicaciones_DivulgacionActividadFeriaEventoRepository _publicaciones_divulgacionactividadferiaeventoRepository;
        public Publicaciones_DivulgacionActividadFeriaEventoController(Publicaciones_DivulgacionActividadFeriaEventoRepository Publicaciones_DivulgacionActividadFeriaEventoRepository)
        {
            _publicaciones_divulgacionactividadferiaeventoRepository = Publicaciones_DivulgacionActividadFeriaEventoRepository;
        }
        readonly Publicaciones_DivulgacionActividadFeriaEventoRepository publicaciones_divulgacionactividadferiaeventoRepository = new Publicaciones_DivulgacionActividadFeriaEventoRepository();
        public Publicaciones_DivulgacionActividadFeriaEventoController()
        {
            _publicaciones_divulgacionactividadferiaeventoRepository = publicaciones_divulgacionactividadferiaeventoRepository;
        }


        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DivulgacionActividadFeriaEvento()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_divulgacionactividadferiaeventoRepository.GetAllPublicaciones_DivulgacionActividadFeriaEvento();

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
        public IHttpActionResult GetPublicaciones_DivulgacionActividadFeriaEventoDetails(int idferiaevento)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_divulgacionactividadferiaeventoRepository.GetPublicaciones_DivulgacionActividadFeriaEventoDetails(idferiaevento);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Detalle feria/evento divulgación inexistente";
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
        public IHttpActionResult InsertPublicaciones_DivulgacionActividadFeriaEvento([FromBody] Publicaciones_DivulgacionActividadFeriaEvento _publicaciones_divulgacionactividadFeriaEvento)
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

                var created = _publicaciones_divulgacionactividadferiaeventoRepository.InsertPublicaciones_DivulgacionActividadFeriaEvento(_publicaciones_divulgacionactividadFeriaEvento);

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
        public IHttpActionResult UpdatePublicaciones_DivulgacionActividadFeriaEvento([FromBody] Publicaciones_DivulgacionActividadFeriaEvento _publicaciones_divulgacionactividadFeriaEvento)
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

                var created = _publicaciones_divulgacionactividadferiaeventoRepository.UpdatePublicaciones_DivulgacionActividadFeriaEvento(_publicaciones_divulgacionactividadFeriaEvento);

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
        public IHttpActionResult DeletePublicaciones_DivulgacionActividadFeriaEvento(int idferiaevento)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _publicaciones_divulgacionactividadferiaeventoRepository.DeletePublicaciones_DivulgacionActividadFeriaEvento(idferiaevento);

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
        public IHttpActionResult GetPublicaciones_DivulgacionActividadFeriaEventoByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_divulgacionactividadferiaeventoRepository.GetPublicaciones_DivulgacionActividadFeriaEventoByPublicacion(id_crearpublicacion);

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
        public IHttpActionResult GetDataTablePublicaciones_DivulgacionActividadFeriaEventoByPublicacion(int id_crearpublicacion)
        {
            DataTableAdapter<Publicaciones_DivulgacionActividadFeriaEvento> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _publicaciones_divulgacionactividadferiaeventoRepository.GetDataTablePublicaciones_DivulgacionActividadFeriaEventoByPublicacion(id_crearpublicacion, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
