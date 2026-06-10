using IrisUNAL.Api.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{

    public partial class CantidadPorAreaPublicada
    {
        public string nmaacad { get; set; }
        public string anopublicacion { get; set; }
        public int? cantidad { get; set; }


    }

    public partial class CantidadPublicada
    {
        public string anopublicacion { get; set; }
        public int? cantidad { get; set; }
    }

    public partial class ResultObject
    {
        public bool Ok { get; set; }
        public string Message { get; set; }
        public string TrazaError { get; set; }
        public object Data { get; set; }
    }

    public partial class UsuarioLogin
    {
        public string Usuario { get; set; }
        public string Clave { get; set; }
    }

    public partial class DatosUsuario
    {
        public int id_usuario { get; set; }
        public string nombrecompleto { get; set; }
        public string correoinstitucional { get; set; }
        public int idrol { get; set; }
        public int? id_depend { get; set; }
        public List<MenuUsuario> menuusuario { get; set; }
    }
    public partial class AccesoOpcion
    {
        public int idrol { get; set; }
        public int idmenu { get; set; }
        public int idmenupadre { get; set; }
        public bool acceso { get; set; }
    }

    public partial class CantidadPorColeccion
    {
        public string colección { get; set; }
        public string año { get; set; }
        public int? count { get; set; }
    }
    public partial class PublicacionesPorEstado
    {
        public string estadomanuscrito { get; set; }
        public int? cantidad { get; set; }
    }
    public partial class EstadosManuscritos
    {
        public int? idestadomanuscrito { get; set; }
        public string estadomanuscrito { get; set; }
    }
    public partial class ReportePresupuestalPublicaciones
    {

        public long? correccion { get; set; }
        public long? ediciondiagramacion { get; set; }
        public long? impresiondigitalizacion { get; set; }
        public long? totalservicioeditorial { get; set; }
        public long? valorproyectado { get; set; }
    }

    public partial class DropSemestre
    {
        public string Semestre { get; set; }
    }
    public partial class TotalPropuestas
    {
        public int? totalestadopropuesta { get; set; }
        public string estadopropuesta { get; set; }

    }

    public partial class TotalpropuestasModalidad
    {
        public string modalidadpropuesta { get; set; }
        public int? totalmodalidadpropuesta { get; set; }

    }
    public partial class TotalPropuestasTipoUsuario
    {
        public string nmpropuestatipousuario { get; set; }
        public int? totalportipousuario { get; set; }
    }
    public partial class TotalPropuestasOrigen

    {
        public string origenpropuesta { get; set; }
        public int? totalorigenpropuesta { get; set; }
    }
    public partial class ModalidadProyectosEjecucion

    {
        public string nmmodalidad { get; set; }
        public int? cantmodalidad { get; set; }


    }

    public partial class TotProyectosEjecucion

    {
        public int? totalproyectos { get; set; }

    }
    public partial class TotEntidadesPropuestas

    {
        public string razonsocial { get; set; }
        public int? count { get; set; }

    }

    public partial class TotEstadoProyectos

    {
        public int? total { get; set; }
        public string transferenciascope { get; set; }

    }

    public partial class MontoEjecutadoLiteral
    {
        public string Literal { get; set; }
        public string Semestre { get; set; }
        public int? Monto_Ejecutado { get; set; }
    }
    public partial class MontoEjecutadoSemestre
    {
        public string semestre { get; set; }
        public long? monto_ejecutado { get; set; }
    }
    public partial class MontoEjecutadoLiteralFilter
    {
        public string nmliteral { get; set; }
        public string nmsemestre { get; set; }
        public long? proyectado { get; set; }
    }
    public partial class ValorProyectadoSemestre
    {
        public string nmsemestre { get; set; }
        public long? proyectado { get; set; }
    }
    public partial class BalanceMontoComprometido
    {
        public string Literal { get; set; }
        public long? Comprometido { get; set; }
        public string nmsemestre { get; set; }

    }
    public partial class MontoComprometidoComprometerSemestre
    {
        public long? comprometido { get; set; }
        public string nmsemestre { get; set; }

    }
    public partial class Comprometido_comprometer
    {
        public string literal { get; set; }
        public int? comprometido { get; set; }
        public int? monto_ejecutado { get; set; }
        public int? monto_ejecutar { get; set; }

    }
    public partial class presupuestoTotalSemestreVigente
    {
        public string Literal { get; set; }
        public string Semestre { get; set; }
        public double? Presupuesto_Total { get; set; }
    }
    public partial class comprometidoTotalPorcentaje
    {
        public int? total_comprometido { get; set; }
        public long? total_presupuesto { get; set; }
        public double? porcentaje_presupuesto { get; set; }

    }
    public partial class ejecutadoTotalPorcentaje
    {
        public string literal { get; set; }
        public string semestre { get; set; }
        public int? monto_ejecutado { get; set; }
        public double? porcentaje_presupuesto { get; set; }

    }
    public partial class diferenciaTotalComprometidoEjecutado
    {
        public string literal { get; set; }
        public int? comprometido { get; set; }
        public int? monto_ejecutado { get; set; }
        public int? monto_ejecutar { get; set; }

    }
    public partial class ProyectosporEstado
    {
        public string nmestado { get; set; }
        public int? count { get; set; }
    }
    public partial class botonInteractivo
    {
        public string Literal { get; set; }
        public string Semestre { get; set; }
        public int? Presupuesto_Total { get; set; }
    }
    public partial class ProyectosporEstadoConvovatoriasPorFuenteDTO
    {
        public string nmfuentecnv { get; set; }
        public int? count { get; set; }
    }
    public partial class PresuspuestoTotalComprometidoBySemestreDTO
    {
        public int? total_comprometido { get; set; }
        public long? total_presupuesto { get; set; }
        public double? porcentaje_presupuesto { get; set; }
    }
    public partial class PresuspuestoTotalComprometidoBySemestreAndLiteralDTO
    {

        public int? total_comprometido { get; set; }
        public long? total_presupuesto { get; set; }
        public double? porcentaje_presupuesto { get; set; }
    }
    public partial class PresuspuestoTotalComprometidoEjecutadoByLiteralDTO
    {

        public string literal { get; set; }
        public int? comprometido { get; set; }
        public int? monto_ejecutado { get; set; }
        public int? monto_ejecutar { get; set; }
    }
    public partial class PresuspuestoTotalComprometidoEjecutadoByLiteralAndSemestreDTO
    {

        public string literal { get; set; }
        public int? comprometido { get; set; }
        public int? monto_ejecutado { get; set; }
        public int? monto_ejecutar { get; set; }
    }
    public partial class EstadoEvaluacionesDTO
    {
        public string nmconcepto { get; set; }
        public int? count { get; set; }


    }

}