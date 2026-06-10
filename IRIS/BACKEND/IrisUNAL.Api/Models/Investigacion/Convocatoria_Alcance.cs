using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.Investigacion
{
    [Table("convocatoria_alcance", Schema="public")]
    public class Convocatoria_Alcance
    {
        [Key]
        public int id_alcance { get; set; }
        public string nmalcance { get; set; }
            public string observaciones { get; set; }
            public DateTime fechacreacion { get; set; }
            public string usuariocreacion { get; set; }
            public DateTime? fechaactualizacion { get; set; }
            public string usuarioactualizacion { get; set; }
            public bool activo { get; set; }
    }
}