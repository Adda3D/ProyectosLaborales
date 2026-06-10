using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("seguimiento_partida", Schema="public")]
    public class Seguimiento_Partida
    {
        [Key]
        public int id_partida { get; set; }
        [Required(ErrorMessage = "Código partida requerido")]
        public string codigointernopartida { get; set; }
        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string nombrepartida { get; set; }        
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}