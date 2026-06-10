using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("consecutivo_annio", Schema="public")]
    public class Consecutivo_Annio
    {
        [Key]
        public int id_consecutivoannio { get; set; }
        public string annio { get; set; }
        public int consecutivo { get; set; }
        public int id_prefijoconsecutivo { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        
    }
}