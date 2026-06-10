using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_tipocorreccion", Schema="public")]
    public class Publicaciones_TipoCorreccion
    {
        [Key]
        public int id_tipocorreccion { get; set; }
        public int id_crearpublicacion { get; set; }        
        public int id_persona { get; set; }
        public int? id_estadocorreccion { get; set; }
        public string contratocorreccion { get; set; }
        public string orpa1 { get; set; }
        public DateTime? fechaorpa1 { get; set; }
        public string orpa2 { get; set; }
        public DateTime? fechaorpa2 { get; set; }
        public string quipu { get; set; }
        public string tipocorreccion { get; set; }
        public bool reqindices { get; set; }
        public DateTime? feciniciocorreccion { get; set; }
        public DateTime? fecentrega { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Publicaciones_EstadoCorreccion ObjEstadoCorrecion { get; set; }

        [NotMapped]
        public string EstadoCorreccion
        {
            get
            {
                return (ObjEstadoCorrecion == null) ? "" : ObjEstadoCorrecion.nmestadocorreccion;
            }
        }
    }
}