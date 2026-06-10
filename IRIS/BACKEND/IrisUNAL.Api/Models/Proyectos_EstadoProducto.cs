using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("proyectos_estadoproducto", Schema = "public")]
    public class Proyectos_EstadoProducto
    {
        [Key]
        public int id_estadoproducto { get; set; }
        [Required(ErrorMessage = "Estado producto es requerido")]
        [StringLength(50, MinimumLength = 1)]
        public string estadoproducto { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}