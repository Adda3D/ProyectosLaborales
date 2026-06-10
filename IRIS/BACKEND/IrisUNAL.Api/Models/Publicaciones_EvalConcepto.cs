using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_evalconcepto", Schema="public")]
    public class Publicaciones_EvalConcepto
    {
        [Key]
        public int id_evalconcepto { get; set; }
        public int id_crearpublicacion { get; set; }
        public int id_evalgenerada { get; set; }
        public int id_evaluadores { get; set; }
        public int id_persona { get; set; }
        public int? id_concepto { get; set; }
        public int? id_estadoconcepto { get; set; }
        public DateTime? fecaceptado { get; set; }
        public DateTime? fecinicial { get; set; }
        public DateTime? fecentrega { get; set; }
        public string linkdocumento { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Persona ObjPersona { get; set; }

        [NotMapped]
        public string NombreEvaluador
        {
            get
            {
                return (ObjPersona == null) ? "" : ObjPersona.nombrecompleto;
            }
        }


    }
}