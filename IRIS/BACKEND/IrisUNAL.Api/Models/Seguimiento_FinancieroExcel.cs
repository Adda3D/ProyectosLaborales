using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("seguimiento_financieroexcel", Schema="public")]
    public class Seguimiento_FinancieroExcel
    {[Key]
        public int id_financieroexcel { get; set; }
        public int id_asignacionproyecto { get; set; }
        public int id_modalidad { get; set; }
        public string modalidadextension { get; set; }
        public int id_naturalezaproyecto { get; set; }
        public string nmnaturalezaproyecto { get; set; }
        public string nombreproyecto { get; set; }
        public string codigoquipu { get; set; }
        public string codigohermes { get; set; }
        public int id_persona { get; set; }
        public string directorproyecto { get; set; }
        public string interventorproyecto { get; set; }
        public double identificaciondirector { get; set; }
        public double identificacioninterventor { get; set; }
        public string correodirector { get; set; }
        public string correointerventor { get; set; }
        public double aportefacultad { get; set; }
        public double aportevir { get; set; }
        public double aportedieb { get; set; }
        public int id_segdesembolso { get; set; }
        public int porcentagedesembolso { get; set; }
        public double valordesembolso { get; set; }
        public DateTime fechagiro { get; set; }
        public double totalaportado { get; set; }
        public double valorconvenioaprobado { get; set; }
        public double valortotalproyectoaprobado { get; set; }
        public double valorejecutadoproyecto { get; set; }
        public double vigenciaparaejecutar { get; set; }
        public DateTime fechainicioproyecto { get; set; }
        public DateTime fechaterminacionproyecto { get; set; }
        public string estadoactualproyecto { get; set; }
        public string nombreasistentecoordinacion { get; set; }
        public double identificacionasistentecoordinacion { get; set; }
        public string correoasistentecoordinacion { get; set; }
        public bool campovisible { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}