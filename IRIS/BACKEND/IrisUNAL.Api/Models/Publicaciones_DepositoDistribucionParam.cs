using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_depositodistribucionparam", Schema="public")]
    public class Publicaciones_DepositoDistribucionParam
    {
        [Key]
        public int id_distparam { get; set; }
        public string consecutivo { get; set; }
        public DateTime fecentrega { get; set; }
        public string numentregados { get; set; }
        public string cajaautores { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}