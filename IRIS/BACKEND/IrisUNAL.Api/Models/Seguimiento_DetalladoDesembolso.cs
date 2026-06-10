using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("seguimiento_detalladodesembolso", Schema="public")]
    public class Seguimiento_DetalladoDesembolso
    {
        [Key]
        public int id_detdesembolso { get; set; }
        [Required(ErrorMessage = "ID Concepto requerido")]
        public int id_segconcepto { get; set; }
        [Required(ErrorMessage = "ID Financiero requerido")]
        public int id_financieroexcel { get; set; }
        [Required(ErrorMessage = "ID Poyecto requerido")]
        public int id_asignacionproyecto { get; set; }
        [Required(ErrorMessage = "Nombre proyecto requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string nombreproyecto { get; set; }
        [Required(ErrorMessage = "Quipu proyecto requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string codigoquipu { get; set; }
        [Required(ErrorMessage = "Hermes requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string codigohermes { get; set; }        
        public DateTime? fecha { get; set; }
        public int? id_persona { get; set; }
        public string numidentificacion { get; set; }
        [Required(ErrorMessage = "Nombre proyecto requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string nombre { get; set; }
        public double valordesembolso { get; set; }
        public bool campovisible { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}