using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("funcionario", Schema = "public")]
    public class Funcionario
    {
        [Key]
        public int idfuncionario { get; set; }

        [Required(ErrorMessage = "Número identificación requerido")]
        [StringLength(15, MinimumLength = 1)]
        public string numidentificacion { get; set; }

        [Required(ErrorMessage = "Nombres requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string nombres { get; set; }

        [Required(ErrorMessage = "Apellidos requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string apellidos { get; set; }
        public int id_depend { get; set; }
        public string correo { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Dependencia depfuncionario { get; set; }

        [NotMapped]
        public string dependencia
        {
            get
            {
                return (depfuncionario == null) ? "" : depfuncionario.nmdepend;
            }
        }

        [NotMapped]
        public string nombrecompleto
        {
            get
            {
                return string.Concat((nombres == null) ? "" : nombres, " ", (apellidos == null) ? "" : apellidos);
            }
        }

        [NotMapped]
        public string Usuario
        {
            get
            {
                string sUsuario = "";
                int indice = 0;

                if (correo != null)
                {
                    indice = correo.IndexOf("@");
                    if (indice > -1)
                    {
                        sUsuario = correo.Substring(0, indice);
                    }

                }

                return sUsuario;
            }
        }
    }
}