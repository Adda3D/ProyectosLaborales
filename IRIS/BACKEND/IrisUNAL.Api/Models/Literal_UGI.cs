using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("literal_ugi", Schema = "public")]
    public class Literal_UGI
    {
        [Key]
        public int id_literal { get; set; }
        [Required(ErrorMessage = "Nombre Requerido")]
        [StringLength(10, MinimumLength = 1)]
        public string nmliteral { get; set; }
        [Required(ErrorMessage = "Grupo requerido")]
        [StringLength(250, MinimumLength = 1)]
        public string grupoproducto { get; set; }        
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}