using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_distribuidor", Schema = "public")]
    public class Publicaciones_Distribuidor
    {
        [Key]
        public int iddistribuidor { get; set; }
        [Required(ErrorMessage = "Nombre distribuidor es requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string distribuidor { get; set; }
        [Required(ErrorMessage = "Dirección distribuidor es requerido")]
        [StringLength(150, MinimumLength = 1)]
        public string direccion { get; set; }
        [Required(ErrorMessage = "Teléfono distribuidor es requerido")]
        [StringLength(20, MinimumLength = 1)]
        public string telefono { get; set; }
        [Required(ErrorMessage = "E-mail distribuidor es requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string correo { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}