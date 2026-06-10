using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("propuesta_tipomodificacion", Schema="public")]
    public class Propuesta_TipoModificacion
    {
        [Key]
        public int id_tipomodificacion { get; set; }
        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(50, MinimumLength = 1)]
        public string nmtipomodificacion { get; set; }        
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}