using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_controlfinancierooperativos", Schema="public")]
    public class DecVie_ControlFinancieroOperativos
    {
        [Key]
        public int id_operativos { get; set; }
        public int id_tipooperativo { get; set; }
        public double valortotalcontratadependencia { get; set; }
        public int id_gastos { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}