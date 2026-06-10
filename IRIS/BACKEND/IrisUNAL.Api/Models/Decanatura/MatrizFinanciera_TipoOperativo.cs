using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.Decanatura
{
    [Table("matrizfinanciera_tipooperativo", Schema="public")]
    public class MatrizFinanciera_TipoOperativo
    {
        [Key]
        public int id_tipooperativo { get; set; }
        public string codtipooperativo { get; set; }
        public string nmtipooperativo { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}