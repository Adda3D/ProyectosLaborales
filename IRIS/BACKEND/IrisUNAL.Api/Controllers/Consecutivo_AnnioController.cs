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

    public class Consecutivo_AnnioController : BaseController<Consecutivo_Annio>
    {
        private readonly IConsecutivo_AnnioRepository _consecutivo_anniorepository;

        public Consecutivo_AnnioController(IConsecutivo_AnnioRepository consecutivo_anniorepository)
        {
            _consecutivo_anniorepository = consecutivo_anniorepository;
        }
        readonly IConsecutivo_AnnioRepository consecutivo_anniorepository = new Consecutivo_AnnioRepository();
        public Consecutivo_AnnioController()
        {
            _consecutivo_anniorepository = consecutivo_anniorepository;
        }


        [HttpGet]
        public IHttpActionResult GetConsecutivo_Annio(int id_prefijoconsecutivo, DateTime fecha)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _consecutivo_anniorepository.GetConsecutivo_Annio(id_prefijoconsecutivo, fecha);

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
