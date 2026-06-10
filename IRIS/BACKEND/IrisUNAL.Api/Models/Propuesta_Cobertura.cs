using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("propuesta_cobertura", Schema="public")]
    public class Propuesta_Cobertura
    {
        [Key]
        public int id_cobertura { get; set; }
        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(50, MinimumLength = 1)]
        public string nmcobertura { get; set; }        
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}