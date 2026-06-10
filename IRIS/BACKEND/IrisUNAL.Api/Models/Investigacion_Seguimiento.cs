using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("investigacion_seguimiento", Schema="public")]
    public class Investigacion_Seguimiento
    {
        [Key]
        public int id_seguimiento { get; set; }
        public int id_crearproyecto { get; set; }
        public string seguimiento { get; set; }
        public string observaciones { get; set; }        
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Investigacion_CrearProyecto crearProyecto { get; set; }
        [NotMapped]
        public string NombreProyecto
        {
            get
            {
                return (crearProyecto == null) ? "" : crearProyecto.nombreproyecto;
            }
        }
    }
}