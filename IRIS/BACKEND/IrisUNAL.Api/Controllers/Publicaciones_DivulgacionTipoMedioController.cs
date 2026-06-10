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
    public class Publicaciones_DivulgacionTipoMedioController : BaseController<Publicaciones_DivulgacionTipoMedio>
    {
        private readonly IPublicaciones_DivulgacionTipoMedioRepository _publicaciones_DivulgacionTipoMedioRepository;
        public Publicaciones_DivulgacionTipoMedioController(IPublicaciones_DivulgacionTipoMedioRepository publicaciones_DivulgacionTipoMedioRepository)
        {
            _publicaciones_DivulgacionTipoMedioRepository = publicaciones_DivulgacionTipoMedioRepository;
        }
        readonly IPublicaciones_DivulgacionTipoMedioRepository publicaciones_DivulgacionTipoMedioRepository = new Publicaciones_DivulgacionTipoMedioRepository();
        public Publicaciones_DivulgacionTipoMedioController()
        {
            _publicaciones_DivulgacionTipoMedioRepository = publicaciones_DivulgacionTipoMedioRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_DivulgacionTipoMedio()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionTipoMedioRepository.GetAllPublicaciones_DivulgacionTipoMedio();

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
        public IHttpActionResult GetPublicaciones_DivulgacionTipoMedioDetails(int id_tipomedio)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionTipoMedioRepository.GetPublicaciones_DivulgacionTipoMedioDetails(id_tipomedio);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Tipo Medio inexistente";
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
        public IHttpActionResult GetPublicaciones_DivulgacionTipoMedioNombre(string cd_nmtipomedio)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = publicaciones_DivulgacionTipoMedioRepository.GetPublicaciones_DivulgacionTipoMedioNombre(cd_nmtipomedio);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Tipo Medio inexistente";
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
        public IHttpActionResult InsertPublicaciones_DivulgacionTipoMedio([FromBody] Publicaciones_DivulgacionTipoMedio publicaciones_DivulgacionTipoMedio)
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

                var created = publicaciones_DivulgacionTipoMedioRepository.InsertPublicaciones_DivulgacionTipoMedio(publicaciones_DivulgacionTipoMedio);

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
        public IHttpActionResult UpdatePublicaciones_DivulgacionTipoMedio([FromBody] Publicaciones_DivulgacionTipoMedio publicaciones_DivulgacionTipoMedio)
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

                var created = publicaciones_DivulgacionTipoMedioRepository.UpdatePublicaciones_DivulgacionTipoMedio(publicaciones_DivulgacionTipoMedio);

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
        public IHttpActionResult DeletePublicaciones_DivulgacionTipoMedio(int id_tipomedio)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = publicaciones_DivulgacionTipoMedioRepository.DeletePublicaciones_DivulgacionTipoMedio(id_tipomedio);

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
        public IHttpActionResult GetDataTablePublicaciones_DivulgacionTipoMedio()
        {
            DataTableAdapter<Publicaciones_DivulgacionTipoMedio> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = publicaciones_DivulgacionTipoMedioRepository.GetDataTablePublicaciones_DivulgacionTipoMedio(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
