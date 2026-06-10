using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_matryoshkametadep", Schema = "public")]
    public class Decvie_MatryoshkaMetaDep
    {
        [Key]
        public int id_matryoshkametadep { get; set; }
        public int id_matryoska { get; set; }
        public int id_matryoshkaobjetivodep { get; set; }
        public int id_meta { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Decvie_Matryoshka Objmatryoshka { get; set; }
        public Decvie_MatryoshkaObjetivoDep Objobjetivodep { get; set; }
        public DecVie_PlanAccionMeta Objnombremeta { get; set; }

        [NotMapped]
        public string AlcanceMatryoshka
        {
            get
            {
                return (Objmatryoshka == null) ? "" : Objmatryoshka.alcance;
            }
        }

        [NotMapped]
        public string NomObjetivoDep
        {
            get
            {
                return (Objobjetivodep == null) ? "" : Objobjetivodep.NombreObjetivoDep;
            }
        }

        [NotMapped]
        public string DetalleObjetivoDep
        {
            get
            {
                return (Objobjetivodep == null) ? "" : (Objobjetivodep.DescripcionObjetivoDep == null) ? "" : (Objobjetivodep.DescripcionObjetivoDep.Length <= 60) ? Objobjetivodep.DescripcionObjetivoDep : Objobjetivodep.DescripcionObjetivoDep.Substring(1, 60) + "...";
            }
        }

        [NotMapped]
        public string NombreMeta
        {
            get
            {
                return (Objnombremeta == null) ? "" : Objnombremeta.nmmeta;
            }
        }
    }
}