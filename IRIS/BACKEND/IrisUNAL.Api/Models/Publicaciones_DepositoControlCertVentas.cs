using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_depositocontrolcertventas", Schema="public")]
    public class Publicaciones_DepositoControlCertVentas
    {
        [Key]
        public int id_certventas { get; set; }
        public int id_crearpublicacion { get; set; }
        public int libroscert { get; set; }
        public DateTime fecenvio { get; set; }
        public bool enviado { get; set; }
        public string nrocertificado { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}