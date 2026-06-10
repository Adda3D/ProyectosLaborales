using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("proyectos_obligaciones", Schema="public")]
    public class Proyectos_Obligaciones
    {
        [Key]
        public int id_proyectoobligaciones { get; set; }
        [Required(ErrorMessage = "ID Asignación requerido")]
        public int id_asignacionproyecto { get; set; }
        [Required(ErrorMessage = "ID Estado requerido")]
        public int id_estadoobligacion { get; set; }
        [Required(ErrorMessage = "Detalle obligación requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string obligacion { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Proyectos_EstadoObligacion estadoObligacion { get; set; }

        [NotMapped]
        public string strestado
        {
            get
            {
                return (estadoObligacion == null) ? "" : estadoObligacion.estadoobligacion;
            }
        }
    }
}