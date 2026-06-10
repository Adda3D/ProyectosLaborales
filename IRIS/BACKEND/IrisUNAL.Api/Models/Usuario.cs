using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("usuario", Schema="public")]
    public class Usuario
    {
        [Key]
        public int id_usuario { get; set; }

        [Required(ErrorMessage = "Nombre usuario requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string nombrecompleto { get; set; }

        [Required(ErrorMessage = "Correo requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string correoinstitucional { get; set; }

        [Required(ErrorMessage = "Rol requerido")]
        public int idrol { get; set; }
        public string clave { get; set; }
        public int? id_depend { get; set; }
        public DateTime? fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Dependencia ObjDependencia { get; set; }
        public Rol ObjRol { get; set; }

        [NotMapped]
        public string NombreDependencia
        {
            get
            {
                return (ObjDependencia == null) ? "" : ObjDependencia.nmdepend;
            }
        }

        [NotMapped]
        public string NombreRol
        {
            get
            {
                return (ObjRol == null) ? "" : ObjRol.nombre;
            }
        }
    }
}