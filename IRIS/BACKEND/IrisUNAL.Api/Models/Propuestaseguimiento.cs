using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("propuestaseguimiento", Schema = "public")]
    public class Propuestaseguimiento
    {
        [Key]
        public int idseguimiento { get; set; }

        [Required(ErrorMessage = "Propuesta es requerido")]
        public int id_propuesta { get; set; }

        [Required(ErrorMessage = "Fecha seguimiento es requerido")]
        public DateTime fechaseguimiento { get; set; }

        [Required(ErrorMessage = "Detalle requerido")]
        [StringLength(200, MinimumLength = 1)]
        public string seguimientodetalle { get; set; }

        [Required(ErrorMessage = "Responsable es requerido")]
        public int idfuncionario { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Propuesta propuesta { get; set; }
        public Funcionario funcionario { get; set; }

        [NotMapped]
        public string responsable
        {
            get
            {
                return (funcionario == null) ? "" : funcionario.nombrecompleto;
            }
        }

        [NotMapped]
        public string strfechaseguimiento
        {
            get
            {
                return fechaseguimiento.ToString("yyyy-MM-dd");
            }
        }


    }
}