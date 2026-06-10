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
    public class Tareas_ModuloController : BaseController<Tareas_Modulo>
    {
        private readonly Tareas_ModuloRepository _tareas_moduloRepository;
        public Tareas_ModuloController(Tareas_ModuloRepository tareas_moduloRepository)
        {
            _tareas_moduloRepository = tareas_moduloRepository;
        }
        readonly Tareas_ModuloRepository tareas_moduloRepository = new Tareas_ModuloRepository();
        public Tareas_ModuloController()
        {
            _tareas_moduloRepository = tareas_moduloRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllTareas_Modulo()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _tareas_moduloRepository.GetAllTareas_Modulo();

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
