using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_matryoshkaestrategia", Schema="public")]
    public class Decvie_MatryoshkaEstrategia
    {
        [Key]
        public int id_matryoshkaestrategia { get; set; }
        public int id_matryoska { get; set; }
        public string estrategia { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Decvie_Matryoshka Objmatryoshka { get; set; }

        [NotMapped]
        public string AlcanceMatryoshka
        {
            get
            {
                return (Objmatryoshka == null) ? "" : Objmatryoshka.alcance;
            }
        }

        [NotMapped]
        public string descripcionEstrategia
        {
            get
            {
                return (estrategia.Length <= 60) ? estrategia : estrategia.Substring(1, 60) + "...";
            }
        }
    }
}