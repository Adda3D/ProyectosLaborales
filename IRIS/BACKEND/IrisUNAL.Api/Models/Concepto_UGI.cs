using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("concepto_ugi", Schema = "public")]
    public class Concepto_UGI
    {
        [Key]
        public int id_conceptougi { get; set; }        
        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string concepto { get; set; }               
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }        
    }    
}