using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_depositodistribucioncomercialotros", Schema= "public")]
    public class Publicaciones_DepositoDistribucionComercialOtros
    {
        [Key]
        public int id_otrosdistribuidores { get; set; }
        public string nmotrosdistribuidores { get; set; }
        public string consecutivo { get; set; }
        public DateTime fecentrega { get; set; }
        public string numentregados { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}