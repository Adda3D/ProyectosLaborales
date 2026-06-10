using IrisUNAL.Api.Entities.Repositories.Publicacion;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IrisUNAL.Api.Controllers.Publicacion
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Publicaciones_DashBoardController : BaseController<Publicaciones_CrearPublicacion>
    {
        private readonly Publicaciones_DashBoardRepository _publicaciones_DashBoardRepository;
        public Publicaciones_DashBoardController(Publicaciones_DashBoardRepository publicaciones_DashBoardRepository)
        {
            _publicaciones_DashBoardRepository = publicaciones_DashBoardRepository;
        }
        readonly Publicaciones_DashBoardRepository publicaciones_DashBoardRepository = new Publicaciones_DashBoardRepository();
        public Publicaciones_DashBoardController()
        {
            _publicaciones_DashBoardRepository = publicaciones_DashBoardRepository;
        }

        [HttpGet]
        public IHttpActionResult RegistrosPorFechaManuscritoPublicado()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _publicaciones_DashBoardRepository.RegistrosPorFechaManuscritoPublicado();

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
        public IHttpActionResult RegistrosPorAreaPublicado(string rango1, string rango2)
        {
            var resultdb = new ResultObject();
            try
            {
                var data =
               _publicaciones_DashBoardRepository.RegistrosPorAreaPublicado(rango1, rango2);
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
        public IHttpActionResult RegistrosPublicacionesPorColeccion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data =
               _publicaciones_DashBoardRepository.RegistrosPublicacionesPorColeccion();
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
        public IHttpActionResult RegistrosPublicacionesPorEstado()
        {
            var resultdb = new ResultObject();
            try
            {
                var data =
    _publicaciones_DashBoardRepository.RegistrosPublicacionesPorEstado();
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
        public IHttpActionResult EstadosPublicacionesManuscritosGetAll()
        {
            var resultdb = new ResultObject();
            try
            {
                var data =
               _publicaciones_DashBoardRepository.EstadosPublicacionesManuscritosGetAll();
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
        public IHttpActionResult ReportePresupuestalPublicacionesSemestre(string semestre)
        {
            var resultdb = new ResultObject();
            try
            {
                var data =
               _publicaciones_DashBoardRepository.ReportePresupuestalPublicacionesSemestre(semestre);
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
        public IHttpActionResult EstadoEvaluaciones(int anio)
        {
            var resultdb = new ResultObject();
            try
            {
                var data =
               _publicaciones_DashBoardRepository.EstadoEvaluaciones(anio);
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


