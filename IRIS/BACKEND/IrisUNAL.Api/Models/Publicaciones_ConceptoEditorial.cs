using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_conceptoeditorial", Schema="public")]
    public class Publicaciones_ConceptoEditorial
    {
        [Key]
        public int id_conceptoeditorial { get; set; }
        [Required(ErrorMessage = "ID Publicación es requerido")]
        public int id_crearpublicacion { get; set; }
        [Required(ErrorMessage = "Estado Manuscrito Original Presentado es requerido")]
        public bool manuscritooriginal { get; set; }
        public DateTime? fecentregaoriginal { get; set; }
        [Required(ErrorMessage = "Estado Manuscrito Definitivo Presentado es requerido")]
        public bool manuscirtodefinitivo { get; set; }
        public DateTime? fecentregadefinitivo { get; set; }
        [Required(ErrorMessage = "Estado Concepto Editorial es requerido")]
        public bool conceptoeditorial { get; set; }
        public DateTime? fechaelaboracion { get; set; }
        public DateTime? fechaelabfinal { get; set; }
        public int? id_sistemacitacion { get; set; }
        public int? numimgajenolic { get; set; }
        public int? numimgajenoslic { get; set; }
        public int? numimgpropio { get; set; }
        public int? numimgblanconegro { get; set; }
        public int? numimgcolor { get; set; }
        public int? numtablas { get; set; }
        public int? numtblcolor { get; set; }
        public int? numtblblanconegro { get; set; }
        public int? idrecomendacionimpre { get; set; }
        public string urlconcepedit { get; set; }
        public string concepteditpreliminar { get; set; }
        public string concepteditfinal { get; set; }
        public int indicesanaliticos { get; set; }
        public int selloeditorial { get; set; }
        public bool estraduccion { get; set; }
        public bool escomercializable { get; set; }
        public string palabrasclave { get; set; }
        public string resenacubierta { get; set; }
        public string gestoreditunijus { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Publicaciones_CrearPublicacion ObjPublicacion { get; set; }
    }
}