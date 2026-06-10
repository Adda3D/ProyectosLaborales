using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("persona_tipoentidad",Schema="public")]
    public class Persona_TipoEntidad
    {
        [Key]
        public int id_tipoentidad { get; set; }
        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(20, MinimumLength = 1)]
        public string nmtipoent { get; set; }        
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}