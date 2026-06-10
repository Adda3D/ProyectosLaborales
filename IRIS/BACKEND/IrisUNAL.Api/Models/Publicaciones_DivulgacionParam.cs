using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_divulgacionparam", Schema="public")]
    public class Publicaciones_DivulgacionParam
    {
        [Key]
        public int id_divparam { get; set; }
        public string id_kardex { get; set; }
        public int id_medio { get; set; }
        public string lugarpublicacion { get; set; }
        public DateTime fecpublicacion { get; set; }
        public string fuente { get; set; }
        public string observaciones { get; set; }
        public string nmtitulo { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}