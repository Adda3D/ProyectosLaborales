using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_divulgacionactividadferiaevento", Schema = "public")]
    public class Publicaciones_DivulgacionActividadFeriaEvento
    {
        [Key]
        public int idferiaevento { get; set; }
        public int id_crearpublicacion { get; set; }
        public string tipo { get; set; }
        public string nombre { get; set; }
        public DateTime fecha { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }

        [NotMapped]
        public string Observacionesdt
        {
            get
            {
                return (observaciones == null) ? "" : (observaciones.Length > 59) ? observaciones.Substring(0, 60) + "... " : observaciones;
            }
        }
    }
}