using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_coedicion", Schema="public")]
    public class Publicaciones_Coedicion
    {
        [Key]
        public int id_coedicion { get; set; }
        public bool coedicion { get; set; }
        public string numcoedicion { get; set; }
        public string id_kardex { get; set; }
        public string numcontrato { get; set; }
        public DateTime fecinicial { get; set; }
        public DateTime fecfin { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}