using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("proyectos_nuevoproducto", Schema="public")]
    public class Proyectos_NuevoProducto
    {
        [Key]
        public int id_nuevoproducto { get; set; }
        [Required(ErrorMessage = "ID proyecto requerido")]
        public int id_asignacionproyecto { get; set; }
        [Required(ErrorMessage = "Descripción producto es requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string descripcion { get; set; }
        [Required(ErrorMessage = "Tipo producto es requerido")]
        public int id_tipoproducto { get; set; }
        public DateTime? fechaentrega { get; set; }
        [Required(ErrorMessage = "Estado producto es requerido")]        
        public int id_estadoproducto { get; set; }        
        public int? numpersonas { get; set; }        
        public int? numhoras { get; set; }        
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Proyectos_TipoProducto tipoProducto { get; set; }
        public Proyectos_EstadoProducto estadoProducto { get; set; }

        [NotMapped]
        public string strtipoproducto
        {
            get
            {
                return (tipoProducto == null) ? "" : tipoProducto.tipoproducto;
            }
        }

        [NotMapped]
        public string strestadoproducto
        {
            get
            {
                return (estadoProducto == null) ? "" : estadoProducto.estadoproducto;
            }
        }

    }
}