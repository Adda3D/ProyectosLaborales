using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_planaccionobjetivoestrategico", Schema="public")]
    public class DecVie_PlanAccionObjetivoEstrategico
    {
        [Key]
        public int id_objetivoestrategico { get; set; }
        public string objetivoestrategico { get; set; }
        public string descripcionobjetivoestrategico { get; set; }
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