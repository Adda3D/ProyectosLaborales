using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("propuesta_modalidad", Schema="public")]
    public class Propuesta_Modalidad
    {
        [Key]
        public int id_modalidad { get; set; }
        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(255, MinimumLength = 1)]
        public string nmmodalidad { get; set; }        
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}