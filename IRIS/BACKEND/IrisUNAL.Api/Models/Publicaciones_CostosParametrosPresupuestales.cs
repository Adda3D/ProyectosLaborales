using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_costosparametrospresupuestales", Schema="public")]
    public class Publicaciones_CostosParametrosPresupuestales
    {
        [Key]
        public int id_costopublicacion { get; set; }
        public string avance { get; set; }
        public string id_kardex { get; set; }
        public int id_servicioeditorial { get; set; }
        public int id_ejecucion { get; set; }
        public int id_origencontrato { get; set; }
        public int totalcostosdirectos { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}