using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("seguimiento_rubro", Schema="public")]
    public class Seguimiento_Rubro
    {
        [Key]
        public int id_rubro { get; set; }
        [Required(ErrorMessage = "ID partida requerido")]
        public int id_partida { get; set; }
        [Required(ErrorMessage = "Código requerido")]
        public string codigointernorubro { get; set; }
        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string nombrerubro { get; set; }
        public double? valorrubro { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}