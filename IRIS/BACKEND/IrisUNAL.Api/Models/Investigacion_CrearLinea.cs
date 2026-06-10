using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("investigacion_crearlinea", Schema="public")]
    public class Investigacion_CrearLinea
    {
        [Key]
        public int id_crearlinea { get; set; }
        public string linea { get; set; }        
        public int id_creargrupo { get; set; }
        public string campointeres { get; set; }        
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Investigacion_CrearGrupo grupoinvestigacion { get; set; }
        
        [NotMapped]
        public string NomGrupo
        {
            get
            {
               return (grupoinvestigacion == null) ?"": grupoinvestigacion.nombregrupo;
            }
        }
    }
}