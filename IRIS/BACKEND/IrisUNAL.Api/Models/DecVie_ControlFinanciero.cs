using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_controlfinanciero", Schema="public")]
    public class DecVie_ControlFinanciero
    {
        [Key]
        public int id_controlfinanciero { get; set; }
        public string nmpresupuesto { get; set; }
        public double valorpresupuesto { get; set; }
        public double valpresupcomprometido { get; set; }
        public double valpresupcomprometer { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}