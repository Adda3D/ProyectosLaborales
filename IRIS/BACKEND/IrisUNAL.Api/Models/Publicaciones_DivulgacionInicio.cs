using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_divulgacioninicio", Schema = "public")]
    public class Publicaciones_DivulgacionInicio
    {
        [Key]
        public int iddivulgacioninicio { get; set; }
        public int id_crearpublicacion { get; set; }
        public string linkcubierta { get; set; }
        public string linkportada { get; set; }
        public string linkcontraportada { get; set; }
        public string linklomo { get; set; }
        public string linksolapas { get; set; }
        public string linkwebunal { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}