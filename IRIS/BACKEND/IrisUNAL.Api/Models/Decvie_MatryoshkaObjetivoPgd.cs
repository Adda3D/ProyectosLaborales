using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_matryoshkaobjetivopgd", Schema="public")]
    public class Decvie_MatryoshkaObjetivoPgd
    {
        [Key]
        public int id_matryoshkaobjetivopgd { get; set; }
        public int id_matryoska { get; set; }
        public int id_matryoshkaestrategia { get; set; }
        public int id_objetivopgdvrisede { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Decvie_Matryoshka Objmatryoshka { get; set; }
        public Decvie_MatryoshkaEstrategia Objmatryoshkaestrategia { get; set; }
        public DecVie_PlanAccionObjetivosPgdVriSede Objobjetivopgdvri { get; set; }

        [NotMapped]
        public string AlcanceMatryoshka
        {
            get
            {
                return (Objmatryoshka == null) ? "" : Objmatryoshka.alcance;
            }
        }

        [NotMapped]
        public string DetalleEstrategia
        {
            get
            {
                return (Objmatryoshkaestrategia == null) ? "" : Objmatryoshkaestrategia.estrategia;
            }
        }

        [NotMapped]
        public string DescripcionEstrategia
        {
            get
            {
                return (Objmatryoshkaestrategia == null) ? "" : (Objmatryoshkaestrategia.estrategia == null) ? "" : (Objmatryoshkaestrategia.estrategia.Length <= 60) ? Objmatryoshkaestrategia.estrategia : Objmatryoshkaestrategia.estrategia.Substring(1, 60) + "...";
            }
        }

        [NotMapped]
        public string ObjetivoPgd
        {
            get
            {
                return (Objobjetivopgdvri == null) ? "" : Objobjetivopgdvri.nmobjetivopgdvrisede;
            }
        }         
    }
}