using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("area_academica", Schema = "public")]
    public class Area_Academica
    {
        [Key]
        public int id_areaacad { get; set; }
        
        [Required(ErrorMessage = "Código requerido")]
        [StringLength(10, MinimumLength = 1)]
        public string codarea { get; set; }
        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(50, MinimumLength = 1)]
        public string nmaacad { get; set; }        
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}