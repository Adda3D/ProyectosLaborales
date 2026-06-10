using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_tipoevaluador", Schema = "public")]
    public class Publicaciones_TipoEvaluador
    {
        [Key]
        public int id_tipoevaluador { get; set; }
        public int id_persona { get; set; }
        public int id_estadoevaluador { get; set; }
        public bool internoexterno { get; set; }
        public bool minciencias { get; set; }
        public bool nominacioncvlac { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}