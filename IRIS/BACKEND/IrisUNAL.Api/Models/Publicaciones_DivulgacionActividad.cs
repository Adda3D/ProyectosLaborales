using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_divulgacionactividad", Schema="public")]
    public class Publicaciones_DivulgacionActividad
    {
        [Key]
        public int id_actividad { get; set; }
        public int id_crearpublicacion { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }       
        public DateTime fecha { get; set; }
        public string hora { get; set; }
        public int id_persona { get; set; }
        public string linkguion { get; set; }
        public bool checkmaterial { get; set; }
        public string linkmaterial { get; set; }        
        public string linkpublicidad { get; set; }
        public string textoinvitacion { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}