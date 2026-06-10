using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("tipo_persona", Schema="public")]
    public class Tipo_Persona
    {
        [Key]
        public int id_tipopersona { get; set; }
        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(30, MinimumLength = 1)]
        public string nmtipoper { get; set; }        
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}