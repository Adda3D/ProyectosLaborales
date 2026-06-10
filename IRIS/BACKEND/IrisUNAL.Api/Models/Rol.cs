using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("rol", Schema="public")]
    public class Rol
    {
        [Key]
        public int idrol { get; set; }
        public string nombre { get; set; }
        public string tipoacceso { get; set; }
        public DateTime fechacreacion { get; set; }
        public int idusuariocreacion { get; set; }
        public DateTime fechaactualizacion { get; set; }
        public int idusuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}