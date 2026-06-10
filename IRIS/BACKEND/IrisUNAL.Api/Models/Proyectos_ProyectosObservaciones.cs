using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("proyectos_proyectosobservaciones", Schema="public")]
    public class Proyectos_ProyectosObservaciones
    {
        [Key]
        public int id_proyectosobservaciones { get; set; }
        [Required(ErrorMessage = "ID Proyecto es requerido")]
        public int id_asignacionproyecto { get; set; }
        [Required(ErrorMessage = "Descripción requerido")]
        [StringLength(150, MinimumLength = 1)]
        public string descripcion { get; set; }
        public DateTime fechaasignacion { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Proyectos_AsignacionProyecto proyecto { get; set; }
    }
}