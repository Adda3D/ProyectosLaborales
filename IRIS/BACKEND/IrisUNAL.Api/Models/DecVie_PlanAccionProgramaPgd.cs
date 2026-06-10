using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_planaccionprogramapgd", Schema="public")]
    public class DecVie_PlanAccionProgramaPgd
    {
        [Key]
        public int id_programapgd { get; set; }
        public string nmprogramapgd { get; set; }
        public string descripcionprogramapgd { get; set; }
        public string estrategiaprogramapgd { get; set; }
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
        public string descripcionprogramapgddt
        {
            get
            {
                return (descripcionprogramapgd.Length <= 60) ? descripcionprogramapgd : descripcionprogramapgd.Substring(1, 60) + "...";
            }
        }

        [NotMapped]
        public string estrategiaprogramapgddt
        {
            get
            {
                return (estrategiaprogramapgd.Length <= 60) ? estrategiaprogramapgd : estrategiaprogramapgd.Substring(1, 60) + "...";
            }
        }
    }
}