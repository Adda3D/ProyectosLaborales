using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("propuesta_entidad", Schema = "public")]
    public class Propuesta_Entidad
    {
        [Key]
        public int idpropuesta_entidad { get; set; }

        [Required(ErrorMessage = "Tipo documento requerido")]
        public int id_tipodocumento { get; set; }

        [Required(ErrorMessage = "Tipo entidad requerido")]
        public int id_tipoentidad { get; set; }

        [Required(ErrorMessage = "Número identificación requerido")]
        [StringLength(12, MinimumLength = 1)]
        public string numidentificacion { get; set; }

        [Required(ErrorMessage = "Razón social requerido")]
        [StringLength(300, MinimumLength = 1)]
        public string razonsocial { get; set; }

        [Required(ErrorMessage = "Dirección requerido")]
        [StringLength(200, MinimumLength = 1)]
        public string direccion { get; set; }

        [Required(ErrorMessage = "Teléfono requerido")]
        [StringLength(20, MinimumLength = 1)]
        public string telefono { get; set; }
        public string correo { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }

    }
}