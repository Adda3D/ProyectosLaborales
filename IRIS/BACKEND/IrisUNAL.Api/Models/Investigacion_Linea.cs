using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("investigacion_linea", Schema="public")]
    public class Investigacion_Linea
    {
        [Key]
        public int id_lineas { get; set; }
        public string minciencias { get; set; }
        public string codigohermes { get; set; }
        public int id_crearlinea { get; set; }
        public int id_creargrupo { get; set; }
        public bool campovisible { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}