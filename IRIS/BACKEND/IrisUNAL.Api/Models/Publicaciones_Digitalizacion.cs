using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_digitalizacion", Schema="public")]
    public class Publicaciones_Digitalizacion
    {
        [Key]
        public int id_digitalizacion { get; set; }
        public int id_crearpublicacion { get; set; }
        public int id_persona { get; set; }
        public bool versionpreliminareb { get; set; }
        public bool solajustesunijus { get; set; }
        public bool verfinaleb { get; set; }
        public bool envcomercializacion { get; set; }
        public string comentariosdig { get; set; }        
        public DateTime? fechainicio { get; set; }
        public DateTime? fechaentrega { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}