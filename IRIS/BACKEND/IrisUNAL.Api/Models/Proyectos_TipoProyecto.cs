using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("proyectos_tipoproyecto", Schema="public")]
    public class Proyectos_TipoProyecto
    {
        [Key]
        public int id_tipoproyecto { get; set; }
        [Required(ErrorMessage = "Tipo requerido")]        
        public string tipoproyecto { get; set; }
        [Required(ErrorMessage = "Detalles requeridos")]        
        public string detalles { get; set; }
        public bool campovisible { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}