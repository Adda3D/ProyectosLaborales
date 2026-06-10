using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("proyecto_persona", Schema="public")]
    public class Proyecto_Persona
    {
        [Key]
        public int id_proyectopersona { get; set; }
        [Required(ErrorMessage = "ID proyecto requerido")]
        public int id_asignacionproyecto { get; set; }
        [Required(ErrorMessage = "ID relacionado es requerido")]
        public int id_persona { get; set; }
        [Required(ErrorMessage = "ID tipo proyecto es requerido")]
        public int id_tipoproyecto { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Persona persona { get; set; }

        [NotMapped]
        public string nombrepersona
        {
            get
            {
                return (persona == null) ? "" : persona.nombrecompleto;
            }
        }
    }
}