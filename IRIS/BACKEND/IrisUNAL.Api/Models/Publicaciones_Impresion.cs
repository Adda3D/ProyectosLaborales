using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_impresion", Schema = "public")]
    public class Publicaciones_Impresion
    {
        [Key]
        public int id_impresion { get; set; }
        public int id_crearpublicacion { get; set; }
        public int id_encuadernacion { get; set; }
        public int id_papel { get; set; }
        public int id_impresiontipo { get; set; }
        public int id_gramaje { get; set; }
        public int id_tintastaco { get; set; }
        public int id_persona { get; set; }
        public int paginasfinales { get; set; }
        public int tiraje { get; set; }
        public DateTime? fecinicio { get; set; }
        public DateTime? fecentrega { get; set; }
        public bool pruebaimpresion { get; set; }
        public bool imptodotiraje { get; set; }        
        public string comentariosimpresion { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}