using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("proyectos_naturalezaproyecto", Schema="public")]
    public class Proyectos_NaturalezaProyecto
    {
        [Key]
        public int id_naturalezaproyecto { get; set; }
        [Required(ErrorMessage = "Naturaleza requerida")]        
        public string naturalezaproyecto { get; set; }
        [Required(ErrorMessage = "Detalles requerido")]        
        public string detalles { get; set; }
        public bool campovisible { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}