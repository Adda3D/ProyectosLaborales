using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_planaccionnuevosindicadores", Schema="public")]
    public class DecVie_PlanAccionNuevosIndicadores
    {
        [Key]
        public int id_nuevosindicadores { get; set; }
        public string nmnuevosindicadores { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public int id_depend { get; set; }
        public Dependencia Objdependencia { get; set; }

        [NotMapped]
        public string NombreDependencia
        {
            get
            {
                return (Objdependencia == null) ? "" : Objdependencia.nmdepend;
            }
        }
    }
}