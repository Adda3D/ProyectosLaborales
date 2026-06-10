using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("distribucion_fondo_ugi", Schema="public")]
    public class Distribucion_Fondo_UGI
    {
        [Key]
        public int id_fondougi { get; set; }
        [Required(ErrorMessage = "Concepto UGI requerido")]
        public int id_conceptougi { get; set; }
        [Required(ErrorMessage = "Semestre requerido")]
        public int id_semestre { get; set; }
        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string numeroresolucion { get; set; }
        public DateTime fecharesolucion { get; set; }
        public double valortotalsemestre { get; set; }
        public double valorejecutado { get; set; }
        public double disponibilidad { get; set; }        
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}