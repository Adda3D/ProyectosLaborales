using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.Decanatura
{
    [Table("matrizfinanciera_vigencia", Schema="public")]
    public class MatrizFinanciera_Vigencia
    {
        [Key]
        public int id_vigencia { get; set; }
        public string codvigencia { get; set; }
        public string nmvigencia { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}