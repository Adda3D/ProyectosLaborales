using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("persona_calificacion", Schema="public")]
    public class Persona_Calificacion
    {
        [Key]
        public int id_calificacion { get; set; }
        [Required(ErrorMessage = "Calificación requerida")]
        [StringLength(10, MinimumLength = 1)]
        public string calificacion { get; set; }        
        public int id_persona { get; set; }
        public int? id_asignacionproyecto { get; set; }
        public int? id_tipoproyecto { get; set; }        
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}