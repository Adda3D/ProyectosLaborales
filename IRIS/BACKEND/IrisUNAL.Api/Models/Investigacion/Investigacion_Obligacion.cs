using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.Investigacion
{
    [Table("investigacion_obligacion", Schema = "public")]
    public class Investigacion_Obligacion
    {
        [Key]
        public int id_proyectoobligacion { get; set; }
        [Required(ErrorMessage = "ID proyecto requerido")]
        public int id_crearproyecto { get; set; }
        [Required(ErrorMessage = "ID Estado requerido")]
        public int id_estadoobligacion { get; set; }
        [Required(ErrorMessage = "Detalle obligación requerido")]        
        public string obligacion { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Proyectos_EstadoObligacion ObjEstado { get; set; }

        [NotMapped]
        public string EstadoObligacion
        {
            get
            {
                return (ObjEstado == null) ? "" : ObjEstado.estadoobligacion;
            }
        }
    }
}