using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("tipo_documento", Schema="public")]
    public class Tipo_Documento
    {
        [Key]
        public int id_tipodocumento { get; set; }
        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(10, MinimumLength = 1)]
        public string nmtipodoc { get; set; }
        public bool campovisible { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}