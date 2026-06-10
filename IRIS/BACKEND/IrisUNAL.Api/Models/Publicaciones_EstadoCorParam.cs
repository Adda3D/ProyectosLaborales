using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_estadocorparam", Schema="public")]
    public class Publicaciones_EstadoCorParam
    {
        [Key]
        public int id_estadocorparam { get; set; }
        public int id_crearpublicacion { get; set; }
        public string correccionetapa { get; set; }
        public int? id_persona { get; set; }
        public string responsable { get; set; }        
        public DateTime ingreso { get; set; }
        public int duracion { get; set; }
        public DateTime finalizacion { get; set; }
        public DateTime? fecharealfinalizacion { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}