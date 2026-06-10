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
    public class Publicacion_GastoController : BaseController<Publicacion_Gasto>
    {
        private readonly Publicacion_GastoRepository _publicacion_gastoRepository;

        public Publicacion_GastoController(Publicacion_GastoRepository publicacion_gastoRepository)
        {
            _publicacion_gastoRepository = publicacion_gastoRepository;
        }

        readonly Publicacion_GastoRepository publicacion_gastoRepository = new Publicacion_GastoRepository();
        public Publicacion_GastoController()
        {
            _publicacion_gastoRepository = publicacion_gastoRepository;
        }

        [HttpGet]
        public IHttpActionResult GetPublicacion_GastoDetails(int id_publicaciongasto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicacion_gastoRepository.GetPublicacion_GastoDetails(id_publicaciongasto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Gasto no existente";
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
        public IHttpActionResult GetPublicacion_GastoRelaciones(int id_publicaciongasto)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicacion_gastoRepository.GetPublicacion_GastoRelaciones(id_publicaciongasto);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Gasto no existente";
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
        public IHttpActionResult InsertPublicacion_Gasto([FromBody] Publicacion_Gasto _publicacion_gasto)
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

                var created = _publicacion_gastoRepository.InsertPublicacion_Gasto(_publicacion_gasto);

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
        public IHttpActionResult UpdatePublicacion_Gasto([FromBody] Publicacion_Gasto _publicacion_gasto)
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

                var created = _publicacion_gastoRepository.UpdatePublicacion_Gasto(_publicacion_gasto);

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
        public IHttpActionResult DeletePublicacion_Gasto(int id_publicaciongasto)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _publicacion_gastoRepository.DeletePublicacion_Gasto(id_publicaciongasto);

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
        public IHttpActionResult GetDataTablePublicacion_GastoByPublicacion(int id_crearpublicacion, int id_partida)
        {
            DataTableAdapter<Publicacion_Gasto> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _publicacion_gastoRepository.GetDataTablePublicacion_GastoByPublicacion(id_crearpublicacion, id_partida, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }
    }
}
