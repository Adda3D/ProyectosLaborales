using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("seguimiento_concepto", Schema="public")]
    public class Seguimiento_Concepto
    {
        [Key]
        public int id_segconcepto { get; set; }
        [Required(ErrorMessage = "ID Rubro requerido")]
        public int id_rubro { get; set; }
        [Required(ErrorMessage = "ID Partida requerido")]
        public int id_partida { get; set; }        
        [Required(ErrorMessage = "Codigo requerido")]        
        public string codigointernoconcepto { get; set; }
        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(50, MinimumLength = 1)]
        public string nombreconcepto { get; set; }        
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Seguimiento_Partida objPartida { get; set; }
        public Seguimiento_Rubro objRubro { get; set; }

        [NotMapped]
        public string NombrePartida
        {
            get
            {
                return (objPartida == null) ? "" : objPartida.nombrepartida;
            }
        }

        [NotMapped]
        public string NombreRubro
        {
            get
            {
                return (objRubro == null) ? "" : objRubro.nombrerubro;
            }
        }
    }
}