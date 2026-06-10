using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_divulgacionactividadnombre", Schema="public")]
    public class Publicaciones_DivulgacionActividadNombre
    {
        [Key]
        public int id_actividadnombre { get; set; }
        public string numactividadnombre { get; set; }
        public string nomactividadnombre { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}