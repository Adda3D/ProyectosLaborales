using IrisUNAL.Api.Entities.Repositories.Publicacion;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.Publicacion;
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

namespace IrisUNAL.Api.Controllers.Publicacion
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Publicacion_DesembolsoController : BaseController<Publicacion_Desembolso>
    {
        private readonly Publicacion_DesembolsoRepository _publicacion_desembolsoRepository;

        public Publicacion_DesembolsoController(Publicacion_DesembolsoRepository publicacion_desembolsoRepository)
        {
            _publicacion_desembolsoRepository = publicacion_desembolsoRepository;
        }

        readonly Publicacion_DesembolsoRepository publicacion_desembolsoRepository = new Publicacion_DesembolsoRepository();
        public Publicacion_DesembolsoController()
        {
            _publicacion_desembolsoRepository = publicacion_desembolsoRepository;
        }

        [HttpGet]
        public IHttpActionResult GetPublicacion_DesembolsoDetails(int id_desembolso)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicacion_desembolsoRepository.GetPublicacion_DesembolsoDetails(id_desembolso);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Desembolso Inexistente";
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
        public IHttpActionResult InsertPublicacion_Desembolso([FromBody] Publicacion_Desembolso _publicacion_desembolso)
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

                var created = _publicacion_desembolsoRepository.InsertPublicacion_Desembolso(_publicacion_desembolso);

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
        public IHttpActionResult UpdatePublicacion_Desembolso([FromBody] Publicacion_Desembolso _publicacion_desembolso)
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

                var created = _publicacion_desembolsoRepository.UpdatePublicacion_Desembolso(_publicacion_desembolso);

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
        public IHttpActionResult DeletePublicacion_Desembolso(int id_desembolso)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _publicacion_desembolsoRepository.DeletePublicacion_Desembolso(id_desembolso);

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
        public IHttpActionResult GetDataTablePublicacion_DesembolsoByPublicacion(int id_crearpublicacion)
        {
            DataTableAdapter<Publicacion_Desembolso> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _publicacion_desembolsoRepository.GetDataTablePublicacion_DesembolsoByPublicacion(id_crearpublicacion, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
