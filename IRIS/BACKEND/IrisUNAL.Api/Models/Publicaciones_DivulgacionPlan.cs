using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_divulgacionplan", Schema="public")]
    public class Publicaciones_DivulgacionPlan
    {
        [Key]
        public int id_plan { get; set; }
        public int id_crearpublicacion { get; set; }        
        public string textopromocional { get; set; }        
        public DateTime fecinicio { get; set; }
        public DateTime feccierre { get; set; }
        public bool derecho { get; set; }
        public bool cienciapolitica { get; set; }
        public bool entregaautor { get; set; }
        public bool entregainvitado { get; set; }
        public bool entregamoderador { get; set; }
        public bool entregaeditorial { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}