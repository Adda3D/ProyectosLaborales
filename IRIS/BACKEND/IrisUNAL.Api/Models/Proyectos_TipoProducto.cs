using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("proyectos_tipoproducto", Schema = "public")]
    public class Proyectos_TipoProducto
    {
        [Key]
        public int id_tipoproducto { get; set; }
        [Required(ErrorMessage = "Tipo producto es requerido")]        
        public string tipoproducto { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }

    }
}