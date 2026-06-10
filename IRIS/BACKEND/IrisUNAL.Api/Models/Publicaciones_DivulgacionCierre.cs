using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{

    [Table("publicaciones_divulgacioncierre", Schema="public")]
    public class Publicaciones_DivulgacionCierre
    {
        [Key]
        public int id_cierre { get; set; }
        public int id_crearpublicacion { get; set; }               
        public bool infdifundida { get; set; }
        public string bitacora { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}