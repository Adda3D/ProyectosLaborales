using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_matryoshkaactividaddep", Schema="public")]
    public class Decvie_MatryoshkaActividadDep
    {
        [Key]
        public int id_matryoshkaactividaddep { get; set; }
        public int id_matryoska { get; set; }
        public int id_matryoshkametadep { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public int id_actividades { get; set; }
        public Decvie_Matryoshka Objmatryoshka { get; set; }
        public Decvie_MatryoshkaMetaDep Objmetadep { get; set; }
        public DecVie_PlanAccionActividades Objactividades { get; set; }

        [NotMapped]
        public string AlcanceMatryoshka
        {
            get
            {
                return (Objmatryoshka == null) ? "" : Objmatryoshka.alcance;
            }
        }

        [NotMapped]
        public string NombreMeta
        {
            get
            {
                return (Objmetadep == null) ? "" : Objmetadep.Objnombremeta.nmmeta;
            }
        }

        [NotMapped]
        public string NombreActividad
        {
            get
            {
                return (Objactividades == null) ? "" : Objactividades.nmactividad;
            }
        }
    }
}