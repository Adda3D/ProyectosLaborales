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
    public class Publicaciones_DivulgacionActividadInvitadosController : BaseController<Publicaciones_DivulgacionActividadInvitados>
    {
        private readonly IPublicaciones_DivulgacionActividadInvitadosRepository _publicaciones_DivulgacionActividadInvitadosRepository;
        public Publicaciones_DivulgacionActividadInvitadosController(IPublicaciones_DivulgacionActividadInvitadosRepository publicaciones_DivulgacionActividadInvitadosRepository)
        {
            _publicaciones_DivulgacionActividadInvitadosRepository = publicaciones_DivulgacionActividadInvitadosRepository;
        }
        readonly IPublicaciones_DivulgacionActividadInvitadosRepository publicaciones_DivulgacionActividadInvitadosRepository = new Publicaciones_DivulgacionActividadInvitadosRepository();
        public Publicaciones_DivulgacionActividadInvitadosController()
        {
            _publicaciones_DivulgacionActividadInvitadosRepository = publicaciones_DivulgacionActividadInvitadosRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DivulgacionActividadInvitados()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionActividadInvitadosRepository.GetAllPublicaciones_DivulgacionActividadInvitados();

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
        public IHttpActionResult GetPublicaciones_DivulgacionActividadInvitadosDetails(int id_invitados)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionActividadInvitadosRepository.GetPublicaciones_DivulgacionActividadInvitadosDetails(id_invitados);

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
        public IHttpActionResult InsertPublicaciones_DivulgacionActividadInvitados([FromBody] Publicaciones_DivulgacionActividadInvitados publicaciones_DivulgacionActividadInvitados)
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

                var created = publicaciones_DivulgacionActividadInvitadosRepository.InsertPublicaciones_DivulgacionActividadInvitados(publicaciones_DivulgacionActividadInvitados);

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
        public IHttpActionResult UpdatePublicaciones_DivulgacionActividadInvitados([FromBody] Publicaciones_DivulgacionActividadInvitados publicaciones_DivulgacionActividadInvitados)
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

                var created = publicaciones_DivulgacionActividadInvitadosRepository.UpdatePublicaciones_DivulgacionActividadInvitados(publicaciones_DivulgacionActividadInvitados);

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
        public IHttpActionResult DeletePublicaciones_DivulgacionActividadInvitados(int id_invitados)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DivulgacionActividadInvitadosRepository.DeletePublicaciones_DivulgacionActividadInvitados(id_invitados);

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
        public IHttpActionResult GetDataTablePublicaciones_DivulgacionActividadInvitadosByPublicacion(int id_crearpublicacion)
        {
            DataTableAdapter<Publicaciones_DivulgacionActividadInvitados> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_DivulgacionActividadInvitadosRepository.GetDataTablePublicaciones_DivulgacionActividadInvitadosByPublicacion(id_crearpublicacion, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

        [HttpPost]
        public IHttpActionResult UpdatePublicaciones_DivulgacionActividadInvitadosCierre([FromBody] Publicaciones_DivulgacionActividadInvitados publicaciones_DivulgacionActividadInvitados)
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

                var created = publicaciones_DivulgacionActividadInvitadosRepository.UpdatePublicaciones_DivulgacionActividadInvitadosCierre(publicaciones_DivulgacionActividadInvitados);

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
    }
}
