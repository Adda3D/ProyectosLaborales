using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.Publicacion
{
    [Table("publicaciones_estadomanuscrito", Schema = "public")]
    public class Publicaciones_EstadoManuscrito
    {
        [Key]       
        public int idestadomanuscrito { get; set; }
        public string estadomanuscrito { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; } 
    }
}