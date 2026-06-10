using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_cesionderechos", Schema="public")]
    public class Publicaciones_CesionDerechos
    {
        [Key]
        public int id_cesionderechos { get; set; }
        public int id_crearpublicacion { get; set; }                
        public bool firmaautores { get; set; }
        public bool firmadecano { get; set; }
        public int licrepro { get; set; }
        public bool licrepo { get; set; }
        public string estado { get; set; }
        public string observaciones { get; set; }
        public string enlacesdrive { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}