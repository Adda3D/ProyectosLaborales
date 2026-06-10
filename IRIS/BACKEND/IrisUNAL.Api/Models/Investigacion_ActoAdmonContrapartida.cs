using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("investigacion_actoadmoncontrapartida", Schema="public")]
    public class Investigacion_ActoAdmonContrapartida
    {
        [Key]
        public int id_actoadmoncontrapartida { get; set; }
        public string codigohermes { get; set; }
        public string actoadministrativo { get; set; }        
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}