using IrisUNAL.Api.Entities.Repositories.Extension;
using IrisUNAL.Api.Entities.Repositories.Investigacion;
using IrisUNAL.Api.Entities.Repositories.Publicacion;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.Extension;
using IrisUNAL.Api.Models.Investigacion;
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

namespace IrisUNAL.Api.Controllers.Investigacion
{


    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class InvestigacionDashboardController : BaseController<InvestigacionDashboard>
    {
        private readonly InvestigacionDashboardRepository _investigacionDashboardRepository;
        public InvestigacionDashboardController(InvestigacionDashboardRepository investigacionDashboardRepository)
        {
            _investigacionDashboardRepository = investigacionDashboardRepository;
        }
        readonly InvestigacionDashboardRepository investigacionDashboardRepository = new InvestigacionDashboardRepository();
        public InvestigacionDashboardController()
        {
            _investigacionDashboardRepository = investigacionDashboardRepository;
        }


        //Funciones sin ningun filtro unicamente para poder cargar los dropdown con la informacion de la DB
        [HttpGet]
        public IHttpActionResult GetDropdownMontoEjecutadoLiteral()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.DropdownMontoEjecutadoLiteral();

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
        public IHttpActionResult GetDropdownMontoBalanceMontoComprometido_Comprometer()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.DropdownMontoBalanceMontoComprometido_Comprometer();

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
        public IHttpActionResult GetDropdownPresupuestoTotalSemestreVigente()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.DropdownPresupuestoTotalSemestreVigente();

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
        public IHttpActionResult DropdownEjecutadoTotalPorcentaje()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.DropdownEjecutadoTotalPorcentaje();

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
        public IHttpActionResult DropdownDiferenciaTotalComprometidoEjecutado()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.DropdownDiferenciaTotalComprometidoEjecutado();

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



        // Funciones con Filtro Para ser mostradas como Graficos
        [HttpGet]
        public IHttpActionResult GetMontoEjecutadoLiteral(string literal, string semestre)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.MontoEjecutadoLiteral(literal, semestre);

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
        public IHttpActionResult GetEstadoProyecto()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.EstadoProyecto();

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
        public IHttpActionResult GetMontoEjecutadoLiteralFilter(string literal, string semestre)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.MontoEjecutadoLiteralFilter(literal, semestre);

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
        public IHttpActionResult GetBalanceMontoComprometido_Comprometer(string literal, string semestre)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.BalanceMontoComprometido_Comprometer(literal, semestre);

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
        public IHttpActionResult GetComprometido_comprometer(string literal)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.MontoComprometidoComprometer(literal);

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
        public IHttpActionResult GetPresupuestoTotalSemestreVigente(string semestre, string literal)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.PresupuestoTotalSemestreVigente(semestre, literal);

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
        public IHttpActionResult GetComprometidoTotalPorcentaje()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.ComprometidoTotalPorcentaje();

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
        public IHttpActionResult GetEjecutadoTotalPorcentaje(string semestre, string literal)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.EjecutadoTotalPorcentaje(semestre, literal);

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
        public IHttpActionResult GetDiferenciaTotalComprometidoEjecutado(string literal)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.DiferenciaTotalComprometidoEjecutado(literal);

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
        public IHttpActionResult GetBotonInteractivo()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.BotonInteractivo();

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
        public IHttpActionResult GetProyectosEstadoByLiteral(string literal, int anio, int rango1, int rango2)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.ProyectosPorEstadoByLiteral(literal, anio, rango1, rango2);

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
        //----------------------------------------
        //Funciones definidas para filtrar unicamente por semestre 

        [HttpGet]
        public IHttpActionResult GetValorProyectadoSemestre(string semestre)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.ValorProyectadoSemestre(semestre);

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
        public IHttpActionResult GetMontoEjecutadoSemestre(string semestre)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.MontoEjecutadoSemestre(semestre);

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
        public IHttpActionResult GetMontoComprometidoComprometerSemestre(string semestre)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.MontoComprometido_ComprometerSemestre(semestre);

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
        public IHttpActionResult GetProyectosEstado(int anio, int rango1, int rango2)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.ProyectosPorEstado(anio, rango1, rango2);

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
        public IHttpActionResult GetConvovatoriasPorFuenteBySemestre(int anio, int rango1, int rango2)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.ConvovatoriasPorFuenteBySemestre(anio, rango1, rango2);

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
        public IHttpActionResult GetPresuspuestoTotalComprometidoBySemestre(string semestre, int anio, int rango1, int rango2)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.PresuspuestoTotalComprometidoPorcentajeBySemestre(semestre, anio, rango1, rango2);

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
        public IHttpActionResult GetPresuspuestoTotalComprometidoBySemestreAndLiteral(string semestre, string literal, int anio, int rango1, int rango2)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.PresuspuestoTotalComprometidoPorcentajeBySemestreAndLiteral(semestre, literal, anio, rango1, rango2);

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
        public IHttpActionResult GetPresuspuestoTotalComprometidoEjecutadoBySemestre( int anio, int rango1, int rango2)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.PresuspuestoTotalComprometidoEjecutadoBySemestre(anio, rango1, rango2);

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
        public IHttpActionResult GetPresuspuestoTotalComprometidoEjecutadoByLiteralAndSemestre(string literal, int anio, int rango1, int rango2)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacionDashboardRepository.PresuspuestoTotalComprometidoEjecutadoByLiteralAndSemestre(literal, anio, rango1, rango2);

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