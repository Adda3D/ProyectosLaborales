using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_planaccionejeestrategico", Schema="public")]
    public class DecVie_PlanAccionEjeEstrategico
    {
        [Key]
        public int id_ejeestrategico { get; set; }
        public string ejeestrategico { get; set; }
        public string descripcionejeestrategico { get; set; }
        public string planaccionesestrategica { get; set; }
        public string planaccionesoperativa { get; set; }
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

        [NotMapped]
        public string descripcionejeestrategicodt
        {
            get
            {
                return (descripcionejeestrategico.Length <= 60) ? descripcionejeestrategico : descripcionejeestrategico.Substring(1, 60) + "...";
            }
        }

        [NotMapped]
        public string planaccionesestrategicadt
        {
            get
            {
                return (planaccionesestrategica.Length <= 60) ? planaccionesestrategica : planaccionesestrategica.Substring(1, 60) + "...";
            }
        }

        [NotMapped]
        public string planaccionesoperativadt
        {
            get
            {
                return (planaccionesoperativa.Length <= 60) ? planaccionesoperativa : planaccionesoperativa.Substring(1, 60) + "...";
            }
        }

    }
}