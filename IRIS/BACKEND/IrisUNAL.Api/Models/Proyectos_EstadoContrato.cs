using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("proyectos_estadocontrato", Schema="public")]
    public class Proyectos_EstadoContrato
    {
        [Key]
        public int id_estadocontrato { get; set; }
        [Required(ErrorMessage = "Estado requerido")]
        [StringLength(50, MinimumLength = 1)]
        public string estadocontrato { get; set; }
        [Required(ErrorMessage = "Detalles requerido")]
        [StringLength(50, MinimumLength = 1)]
        public string detalles { get; set; }
        public bool campovisible { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}