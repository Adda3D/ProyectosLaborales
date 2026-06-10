using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_ciclofinancieroprogramapostgrado", Schema = "public")]
    public class Decvie_CicloFinancieroProgramaPostgrado
    {
        [Key]
        public int id_programapostgrado { get; set; }        
        public string nmprogramapostgrado { get; set; }
        public string tipoprograma { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
              

    }
}