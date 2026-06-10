using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_diagfinalparam", Schema="public")]
    public class Publicaciones_DiagFinalParam
    {
        [Key]
        public int id_diagfinalparam { get; set; }
        public DateTime fecinicio { get; set; }
        public DateTime fecestimada { get; set; }
        public DateTime fecfinal { get; set; }
        public string responsable { get; set; }
        public bool consolidacion { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}