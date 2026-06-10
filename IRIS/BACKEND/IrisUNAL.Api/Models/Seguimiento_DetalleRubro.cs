using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("seguimiento_detallerubro", Schema="public")]
    public class Seguimiento_DetalleRubro
    {
        [Key]
        public int id_detallerubro { get; set; }
        [Required(ErrorMessage = "ID Rubro requerido")]
        public int id_rubro { get; set; }
        [Required(ErrorMessage = "Codigo requerido")]
        public string codigointernorubro { get; set; }
        public double rubroejecutado { get; set; }
        public double disponibilidadrubro { get; set; }
        public bool campovisible { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}