using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("seguimientohistorico_conceptos_literales_ugi", Schema="public")]
    public class SeguimientoHistorico_Conceptos_Literales_UGI
    {
        [Key]
        public int id_ejesemugi { get; set; }
        [Required(ErrorMessage = "Código Fondo UGI requerido")]
        public int id_fondougi { get; set; }
        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string numeroresolucion { get; set; }
        public DateTime? fecharesolucion { get; set; }
        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string semestre { get; set; }
        public double valortotalsemestre { get; set; }
        public double valorejecutado { get; set; }
        public double disponibilidad { get; set; }
        public double repo25 { get; set; }
        public double exliqrecneje { get; set; }
        public double liqprougi { get; set; }
        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string observaciones { get; set; }
        public bool campovisible { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}