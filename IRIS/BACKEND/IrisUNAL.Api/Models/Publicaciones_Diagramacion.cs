using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_diagramacion", Schema="public")]
    public class Publicaciones_Diagramacion
    {
        [Key]
        public int id_diagramacion { get; set; }
        public int id_crearpublicacion { get; set; }
        public string nmdiagramacion { get; set; }                
        public int? id_estadodiagramacion { get; set; }
        public int? id_estadocubierta { get; set; }
        public DateTime fechainicio { get; set; }
        public DateTime fechaestimada { get; set; }
        public DateTime? fechaentrega { get; set; }
        public int? duracion { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}