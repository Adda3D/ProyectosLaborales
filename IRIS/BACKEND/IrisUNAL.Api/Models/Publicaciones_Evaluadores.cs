using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_evaluadores", Schema="public")]
    public class Publicaciones_Evaluadores
    {
        [Key]
        public int id_evaluadores { get; set; }
        [Required(ErrorMessage = "ID Publicación es requerido")]
        public int id_crearpublicacion { get; set; }
        [Required(ErrorMessage = "ID Prestador es requerido")]
        public int id_persona { get; set; }
        [Required(ErrorMessage = "ID estado evaluación es requerido")]
        public int id_estadoevaluador { get; set; }
        public DateTime? fecdesigcomite { get; set; }
        public string actadesigcomite { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Persona ObjPersona { get; set; }
        public Publicaciones_EstadoEvaluador ObjEstado { get; set; }
        public Publicaciones_CrearPublicacion ObjPublicacion { get; set; }

        [NotMapped]
        public string NombreEvaluador
        {
            get
            {
                return (ObjPersona == null) ? "" : ObjPersona.nombrecompleto;
            }
        }

        [NotMapped]
        public string Estado
        {
            get
            {
                return (ObjEstado == null) ? "" : ObjEstado.nmestadoevaluador;
            }
        }
    }
}