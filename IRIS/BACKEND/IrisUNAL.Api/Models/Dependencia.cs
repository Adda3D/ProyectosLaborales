using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("dependencia", Schema = "public")]
    public class Dependencia
    {
        [Key]
        public int id_depend { get; set; }

        [Required(ErrorMessage = "Código requerido")]
        [StringLength(10, MinimumLength = 1)]
        public string coddepend { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string nmdepend { get; set; }
        [Required(ErrorMessage = "Código área requerido")]
        public int id_areaacad { get; set; }        
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Area_Academica areaacademica { get; set; }

        [NotMapped]
        public string nombrearea
        {
            get
            {
                return (areaacademica == null) ? "" : areaacademica.nmaacad;
            }
        }
    }
}