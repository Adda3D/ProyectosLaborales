using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_edicionparam", Schema="public")]
    public class Publicaciones_EdicionParam
    {
        [Key]
        public int id_edicionparam { get; set; }
        public DateTime fecinicio { get; set; }
        public DateTime fecestimada { get; set; }
        public DateTime fecfin { get; set; }
        public string responsable { get; set; }
        public string numpaginas { get; set; }
        public bool propcaratula { get; set; }
        public bool codqr { get; set; }
        public string codhermes { get; set; }
        public bool fichacartografica { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}