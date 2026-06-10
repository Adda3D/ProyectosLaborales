using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("propuesta_avalconsejofacultad", Schema="public")]
    public class Propuesta_AvalConsejoFacultad
    {
        [Key]
        public int id_avalconfac { get; set; }
        [Required(ErrorMessage = "Número requerido")]
        [StringLength(50, MinimumLength = 1)]
        public string numeroaval { get; set; }
        [Required(ErrorMessage = "Descripción requerida")]
        [StringLength(100, MinimumLength = 1)]
        public string descripcionaval { get; set; }
        [Required(ErrorMessage = "Observaciones requerido")]
        [StringLength(500, ErrorMessage = "Observaciones no puede exceder 500 caracteres")]
        public string observacionesaval { get; set; }        
        [StringLength(300, ErrorMessage = "Enlace no puede exceder 300 caracteres")]
        public string enlaceavalconfac { get; set; }        
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }

    }
}