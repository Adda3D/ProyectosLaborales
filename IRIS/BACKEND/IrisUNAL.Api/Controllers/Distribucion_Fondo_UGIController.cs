using IrisUNAL.Api.Entities.Repositories;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IrisUNAL.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Distribucion_Fondo_UGIController : BaseController<Distribucion_Fondo_UGI>
    {
        private readonly IDistribucion_Fondo_UGIRepository _distribucion_Fondo_UGIRepository;

        public Distribucion_Fondo_UGIController(IDistribucion_Fondo_UGIRepository distribucion_Fondo_UGIRepository)
        {
            _distribucion_Fondo_UGIRepository = distribucion_Fondo_UGIRepository;
        }
        readonly IDistribucion_Fondo_UGIRepository distribucion_Fondo_UGIRepository = new Distribucion_Fondo_UGIRepository();
        public Distribucion_Fondo_UGIController()
        {
            _distribucion_Fondo_UGIRepository = distribucion_Fondo_UGIRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDistribucion_Fondo_UGI()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _distribucion_Fondo_UGIRepository.GetAllDistribucion_Fondo_UGI();

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
        public IHttpActionResult GetDistribucion_Fondo_UGIDetails(int id_fondougi)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _distribucion_Fondo_UGIRepository.GetDistribucion_Fondo_UGIDetails(id_fondougi);

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
        public IHttpActionResult GetDistribucion_Fondo_UGICodigo(string cd_numeroresolucion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _distribucion_Fondo_UGIRepository.GetDistribucion_Fondo_UGIDetails(cd_numeroresolucion);

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
        public IHttpActionResult InsertDistribucion_Fondo_UGI([FromBody] Distribucion_Fondo_UGI distribucion_Fondo_UGI)
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

                var created = _distribucion_Fondo_UGIRepository.InsertDistribucion_Fondo_UGI(distribucion_Fondo_UGI);

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
        public IHttpActionResult UpdateDistribucion_Fondo_UGI([FromBody] Distribucion_Fondo_UGI distribucion_Fondo_UGI)
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

                var created = _distribucion_Fondo_UGIRepository.UpdateDistribucion_Fondo_UGI(distribucion_Fondo_UGI);

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
        public IHttpActionResult DeleteDistribucion_Fondo_UGI(int id_fondougi)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _distribucion_Fondo_UGIRepository.DeleteDistribucion_Fondo_UGI(id_fondougi);

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
    }
}
