using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_actosadministrativostipo", Schema = "public")]
    public class DecVie_ActosAdministrativosTipo
    { 
        [Key]
        public int id_tipoactoadministrativo { get; set; }
        public string nmidtipoactoadministrativo { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }

    }
}