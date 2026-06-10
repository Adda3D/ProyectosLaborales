using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_cierreedicion", Schema="public")]
    public class Publicaciones_CierreEdicion
    {
        [Key]
        public int id_cierreedicion { get; set; }
        public int id_crearpublicacion { get; set; }
        public bool fichacatalografica { get; set; }
        public string solicitudisbn { get; set; }
        public DateTime? fecsolisbn { get; set; }
        public int isbndigital { get; set; }
        public string nroisbndigital { get; set; }
        public int isbnimpreso { get; set; }
        public string nroisbnimpreso { get; set; }
        public int isbndemanda { get; set; }
        public string nroisbndemanda { get; set; }
        public bool credproceditorial { get; set; }
        public DateTime? anoedicion { get; set; }
        public string observaciones { get; set; }               
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}