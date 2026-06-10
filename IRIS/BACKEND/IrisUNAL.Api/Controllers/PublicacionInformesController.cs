using IrisUNAL.Api.Entities;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
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
    public class PublicacionInformesController : BaseController<PublicacionIngresoVentasDTO>
    {
        private readonly PublicacionInformesRepository _publicacioninformesRepository;
        public PublicacionInformesController(PublicacionInformesRepository publicacioninformesRepository)
        {
            _publicacioninformesRepository = publicacioninformesRepository;
        }
        readonly PublicacionInformesRepository publicacioninformesRepository = new PublicacionInformesRepository();
        public PublicacionInformesController()
        {
            _publicacioninformesRepository = publicacioninformesRepository;
        }


        [HttpGet]
        public IHttpActionResult GetIngresosVentasByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicacioninformesRepository.GetIngresosVentas(id_crearpublicacion);

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
        public IHttpActionResult GetInventarioByPublicacion(int id_crearpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicacioninformesRepository.GetInventarioByPublicacion(id_crearpublicacion);

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
