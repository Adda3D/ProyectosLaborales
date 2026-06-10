using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("liquidacion_finalizacion", Schema="public")]
    public class Liquidacion_Finalizacion
    {
        [Key]
        public int id_liqfinalizacion { get; set; }
        public int id_asignacionproyecto { get; set; }
        public bool ingresos { get; set; }
        public bool pagos { get; set; }
        public bool transferencias { get; set; }
        public bool liquidacioninternahermes { get; set; }
        public string resumenestado { get; set; }
        public DateTime? fechafincontratoasistente { get; set; }
        public string ordenesnumhermes { get; set; }        
        public string matrizsegejecucion { get; set; }
        public string transferenciascope { get; set; }
        public string balfifinalfirmado { get; set; }
        public string subproyectofinhermes { get; set; }        
        public string proacahermesuncompdrive { get; set; }
        public string correoinstitucionalproy { get; set; }
        public string actaliqentidad { get; set; }        
        public string entregaarchivoce { get; set; }
        public string resolucionliqinterna { get; set; }
        public string consecutivosrequerimientos { get; set; }
        public int idfuncionario { get; set; }
        public int id_estadocontrato { get; set; }
        public string pagoscumplidos { get; set; }
        public DateTime fechaestado { get; set; }
        public string informefinal { get; set; }
        public string informefinalenlace { get; set; }
        public string observaciones { get; set; }
        public string productoacademicoenlace { get; set; }
        public string actaliqentidadenlace { get; set; }
        public DateTime fecultimarev { get; set; }        
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Proyectos_AsignacionProyecto ObjProyecto { get; set; }
        public Funcionario ObjFuncionario { get; set; }
    }
}