using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.Investigacion
{
    [Table("investigacion_observacion", Schema = "public")]
    public class Investigacion_Observacion
    {
        [Key]
        public int id_proyectoobservacion { get; set; }
        [Required(ErrorMessage = "ID proyecto requerido")]
        public int id_crearproyecto { get; set; }
        [Required(ErrorMessage = "Fecha Observación requerido")]
        public DateTime fechaobservacion { get; set; }
        [Required(ErrorMessage = "Detalle observación requerido")]
        public string observacion { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}