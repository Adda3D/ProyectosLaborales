using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("investigacion_publicacion", Schema="public")]
    public class Investigacion_Publicacion
    {
        [Key]
        public int id_invpublicacion { get; set; }
        public string codigohermes { get; set; }
        public string grupoinvestigacion { get; set; }
        public string kardex { get; set; }
        public string anoregistroisbn { get; set; }
        public string isbn { get; set; }
        public string ebook { get; set; }
        public string titulo { get; set; }
        public string nombreapellidoautor { get; set; }
        public string serietextoinvestigacion { get; set; }
        public string coleccion { get; set; }
        public bool etapacomercializacion { get; set; }
        public bool requierereimpresion { get; set; }
        public bool requierereedicion { get; set; }
        public bool campovisible { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}