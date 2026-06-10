using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_depositocontrolingresoventas", Schema="public")]
    public class Publicaciones_DepositoControlIngresoVentas
    {
        [Key]
        public int id_ingresoventas { get; set; }
        public double valoringreso { get; set; }
        public double valorcomision { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}