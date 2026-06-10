using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_depositoprecios", Schema="public")]
    public class Publicaciones_DepositoPrecios
    {
        [Key]
        public int id_precios { get; set; }
        public int id_crearpublicacion { get; set; }
        public int pvpublico { get; set; }
        public int pvcunal { get; set; }
        public int pvdigital { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}