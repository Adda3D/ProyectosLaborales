using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_planaccionalcance", Schema="public")]
    public class DecVie_PlanAccionAlcance
    {
        [Key]
        public int id_planaccionalcance { get; set; }
        public string descripcionalcance { get; set; }
        public int id_alcanceanno { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public int id_depend { get; set; }
        public Dependencia Objdependencia { get; set; }
        public DecVie_PlanAccionAlcanceAnno ObjAlcanceanno { get; set; }

        [NotMapped]
        public string NombreDependencia
        {
            get
            {
                return (Objdependencia == null) ? "" : Objdependencia.nmdepend;
            }
        }
       
        [NotMapped]
        public string NombreAlcanceanno
        {
            get
            {
                return (ObjAlcanceanno == null) ? "" : ObjAlcanceanno.nmalcanceanno;
            }
        }
    }
}