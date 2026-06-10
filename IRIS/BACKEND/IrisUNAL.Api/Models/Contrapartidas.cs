using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("contrapartidas", Schema="public")]
    public class Contrapartidas
    {
        [Key]
        public int id_contrapartidas { get; set; }
        public int id_crearproyecto { get; set; }
        public int id_contrapartida { get; set; }        
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string  usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}