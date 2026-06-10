using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_matryoshkaindicadorestrategico", Schema="public")]
    public class Decvie_MatryoshkaIndicadorEstrategico
    {
        [Key]
        public int id_matryoshkaindicadorestrategico { get; set; }
        public int id_matryoska { get; set; }
        public int id_indicadoresestrategicos { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Decvie_Matryoshka Objmatryoshka { get; set; }
        public DecVie_PlanAccionIndicadoresEstrategicos Objindicadoresestrategicos { get; set; }

        [NotMapped]
        public string AlcanceMatryoshka
        {
            get
            {
                return (Objmatryoshka == null) ? "" : Objmatryoshka.alcance;
            }
        }

        [NotMapped]
        public string NombreIndicador
        {
            get
            {
                return (Objindicadoresestrategicos == null) ? "" : Objindicadoresestrategicos.nmindicadoresestrategicos;
            }
        }

        [NotMapped]
        public string NombreCortoIndicador
        {
            get
            {
                return (Objindicadoresestrategicos == null) ? "" : (Objindicadoresestrategicos.nmindicadoresestrategicos == null) ? "" : (Objindicadoresestrategicos.nmindicadoresestrategicos.Length <= 60) ? Objindicadoresestrategicos.nmindicadoresestrategicos : Objindicadoresestrategicos.nmindicadoresestrategicos.Substring(1, 60) + "...";
            }
        }
    }
}