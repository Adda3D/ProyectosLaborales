using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_matryoshkaobjetivodep", Schema = "public")]
    public class Decvie_MatryoshkaObjetivoDep
    {
        [Key]
        public int id_matryoshkaobjetivodep { get; set; }
        public int id_matryoska { get; set; }
        public int id_objetivodependencia { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Decvie_Matryoshka Objmatryoshka { get; set; }
        public DecVie_PlanAccionObjetivoDependencia Objobjetivodep { get; set; }

        [NotMapped]
        public string AlcanceMatrioshka
        {
            get
            {
                return (Objmatryoshka == null) ? "" : Objmatryoshka.alcance;
            }
        }

        [NotMapped]
        public string NombreObjetivoDep
        {
            get
            {
                return (Objobjetivodep == null) ? "" : Objobjetivodep.nmobjetivodependencia;

            }
        }

        [NotMapped]
        public string DescripcionObjetivoDep
        {
            get
            {
                return (Objobjetivodep == null) ? "" : (Objobjetivodep.nmobjetivodependencia == null)? "" : (Objobjetivodep.nmobjetivodependencia.Length <= 60) ? Objobjetivodep.nmobjetivodependencia : Objobjetivodep.nmobjetivodependencia.Substring(1, 60) + "...";
            }
        }
    }
}