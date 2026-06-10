using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("persona_genero", Schema="public")]
    public class Persona_Genero
    {
        [Key]
        public int id_genero { get; set; }
        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(20, MinimumLength = 1)]
        public string nmgenero { get; set; }
        public bool campovisible { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}