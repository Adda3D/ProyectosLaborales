using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_proveedorservicio", Schema="public")]
    public class Publicaciones_ProveedorServicio
    {
        [Key]
        public int id_proveedorservicio { get; set; }
        public string numidentificacion { get; set; }
        public string nombreproveedor { get; set; }
        public string nombrecontacto { get; set; }
        public string telcontacto { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}