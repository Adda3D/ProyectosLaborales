using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("propuesta_estadopropuesta", Schema="public")]
    public class Propuesta_EstadoPropuesta
    {
        [Key]
        public int id_estadopropuesta { get; set; }
        [Required(ErrorMessage = "Estado requerido")]
        [StringLength(50, MinimumLength = 1)]
        public string nmestadopropuesta { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}