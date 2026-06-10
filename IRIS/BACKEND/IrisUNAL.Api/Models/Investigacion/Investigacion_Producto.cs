using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("investigacion_producto", Schema="public")]
    public class Investigacion_Producto
    {
        [Key]
        public int id_producto { get; set; }
        public int id_crearproyecto { get; set; }
        public int id_tipoproducto { get; set; }
        public int id_estadoproducto { get; set; }
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public DateTime fechainicio { get; set; }
        public DateTime fechafin { get; set; }
        public DateTime? fechaentrega { get; set; }
        public int cumplidos { get; set; }
        public string observaciones { get; set; }        
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Investigacion_CrearProyecto ObjProyecto { get; set; }
        public Proyectos_TipoProducto ObjTipoPropducto{ get; set; }
        public Proyectos_EstadoProducto ObjEstadoProducto { get; set; }

        [NotMapped]
        public string TipoProducto 
        { 
            get
            {
                return (ObjTipoPropducto == null) ? "" : ObjTipoPropducto.tipoproducto;
            }
        } 

        [NotMapped]
        public string EstadoProducto
        {
            get
            {
                return (ObjEstadoProducto == null) ? "" : ObjEstadoProducto.estadoproducto;
            }
        }
    }
}