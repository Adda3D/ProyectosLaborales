using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("proyecto_observacion", Schema="public")]
    public class Proyecto_Observacion
    {
        [Key]
        public int id_proyectoobservacion { get; set; }
        public int id_asignacionproyecto { get; set; }
        public int id_proyectosobservaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}