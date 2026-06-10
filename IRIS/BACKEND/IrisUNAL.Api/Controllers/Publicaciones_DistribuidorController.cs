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
    public class Publicaciones_DistribuidorController : BaseController<Publicaciones_Distribuidor>
    {
        private readonly Publicaciones_DistribuidorRepository _publicaciones_distribuidorRepository;
        public Publicaciones_DistribuidorController(Publicaciones_DistribuidorRepository publicaciones_distribuidorRepository)
        {
            _publicaciones_distribuidorRepository = publicaciones_distribuidorRepository;
        }
        readonly Publicaciones_DistribuidorRepository publicaciones_distribuidorrepository = new Publicaciones_DistribuidorRepository();
        public Publicaciones_DistribuidorController()
        {
            _publicaciones_distribuidorRepository = publicaciones_distribuidorrepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllPublicaciones_Distribuidor()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_distribuidorRepository.GetAllPublicaciones_Distribuidor();

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
        public IHttpActionResult GetPublicaciones_DistribuidorDetails(int iddistribuidor)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_distribuidorRepository.GetPublicaciones_DistribuidorDetails(iddistribuidor);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Distribuidor inexistente";
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
        public IHttpActionResult InsertPublicaciones_Distribuidor([FromBody] Publicaciones_Distribuidor _publicaciones_distribuidor)
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

                var created = _publicaciones_distribuidorRepository.InsertPublicaciones_Distribuidor(_publicaciones_distribuidor);

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
        public IHttpActionResult UpdatePublicaciones_Distribuidor([FromBody] Publicaciones_Distribuidor _publicaciones_distribuidor)
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

                var created = _publicaciones_distribuidorRepository.UpdatePublicaciones_Distribuidor(_publicaciones_distribuidor);

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
        public IHttpActionResult DeletePublicaciones_Distribuidor(int iddistribuidor)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _publicaciones_distribuidorRepository.DeletePublicaciones_Distribuidor(iddistribuidor);

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
        public IHttpActionResult GetDataTablePublicaciones_Distribuidor()
        {
            DataTableAdapter<Publicaciones_Distribuidor> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _publicaciones_distribuidorRepository.GetDataTablePublicaciones_Distribuidor(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
