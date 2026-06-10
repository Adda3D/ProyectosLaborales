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
    public class Publicaciones_TipoObraController : BaseController<Publicaciones_TipoObra>
    {
        private readonly IPublicaciones_TipoObraRepository _publicaciones_TipoObraRepository;
        public Publicaciones_TipoObraController(IPublicaciones_TipoObraRepository publicaciones_TipoObraRepository)
        {
            _publicaciones_TipoObraRepository = publicaciones_TipoObraRepository;
        }
        readonly IPublicaciones_TipoObraRepository publicaciones_TipoObraRepository = new Publicaciones_TipoObraRepository();
        public Publicaciones_TipoObraController()
        {
            _publicaciones_TipoObraRepository = publicaciones_TipoObraRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_TipoObra()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_TipoObraRepository.GetAllPublicaciones_TipoObra();

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
        public IHttpActionResult GetPublicaciones_TipoObraDetails(int id_tipoobra)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_TipoObraRepository.GetPublicaciones_TipoObraDetails(id_tipoobra);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_TipoObra inexistente";
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
        public IHttpActionResult GetPublicaciones_TipoObraNombre(string cd_nmtipoobra)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_TipoObraRepository.GetPublicaciones_TipoObraNombre(cd_nmtipoobra);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Publicaciones_TipoObra inexistente";
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
        public IHttpActionResult InsertPublicaciones_TipoObra([FromBody] Publicaciones_TipoObra publicaciones_TipoObra)
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

                var created = publicaciones_TipoObraRepository.InsertPublicaciones_TipoObra(publicaciones_TipoObra);

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
        public IHttpActionResult UpdatePublicaciones_TipoObra([FromBody] Publicaciones_TipoObra publicaciones_TipoObra)
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

                var created = publicaciones_TipoObraRepository.UpdatePublicaciones_TipoObra(publicaciones_TipoObra);

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
        public IHttpActionResult DeletePublicaciones_TipoObra(int id_tipoobra)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_TipoObraRepository.DeletePublicaciones_TipoObra(id_tipoobra);

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
        public IHttpActionResult GetDataTablePublicaciones_TipoObra()
        {
            DataTableAdapter<Publicaciones_TipoObra> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_TipoObraRepository.GetDataTablePublicaciones_TipoObra(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
