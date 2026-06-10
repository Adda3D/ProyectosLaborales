using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_depositocontrol", Schema="public")]
    public class Publicaciones_DepositoControl
    {
        [Key]
        public int id_control { get; set; }
        public string id_kardex { get; set; }
        public int id_actacosto { get; set; }
        public double otroscostos { get; set; }
        public double costostotales { get; set; }
        public double costototalunitario { get; set; }
        public int id_repventas { get; set; }
        public int id_certventas { get; set; }
        public int id_ingresoventas { get; set; }
        public int id_movimientos { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}