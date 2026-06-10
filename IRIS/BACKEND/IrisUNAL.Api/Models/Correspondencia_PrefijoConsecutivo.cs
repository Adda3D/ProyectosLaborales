
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("correspondencia_prefijoconsecutivo", Schema="public")]
    public class Correspondencia_PrefijoConsecutivo
    {
        [Key]
        public int id_prefijoconsecutivo { get; set; }
        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(30, MinimumLength = 1)]
        public string nmprefijo { get; set; }
        [Required(ErrorMessage = "Prefijo requerido")]
        [StringLength(30, MinimumLength = 1)]
        public string prefijo { get; set; }
        public int id_depend { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
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