using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_ciclofinanciero", Schema="public")]
    public class Decvie_CicloFinanciero
    {
        [Key]
        public int id_ciclofinanciero { get; set; }
        public int id_semestre { get; set; }        
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }        
        public Semestre Objsemestre { get; set; }

        [NotMapped]
        public string NombreSemestre
        {
            get
            {
                return (Objsemestre == null) ? "" : Objsemestre.nmsemestre;
            }
        }               
    }
}