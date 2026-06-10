using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_depositocontrolacta", Schema="public")]
    public class Publicaciones_DepositoControlActa
    {
        [Key]
        public int id_actacosto { get; set; }
        public int id_crearpublicacion { get; set; }
        public DateTime fecenvioagu { get; set; }
        public int costodirecto { get; set; }
        public int costoindirecto { get; set; }
        public int? costoinventario { get; set; }
        public int costototal { get; set; }
        public int tirajetotal { get; set; }
        public decimal? costounitario { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }        
    }
}