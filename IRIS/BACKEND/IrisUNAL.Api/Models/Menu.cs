using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("menu", Schema="public")]
    public class Menu
    {[Key]
        public int idmenu { get; set; }
        public int idmenupadre { get; set; }
        public string nombreitem { get; set; }
        public string url { get; set; }
        public string onclick { get; set; }
        public string classimage { get; set; }
        public int orden { get; set; }
        public bool mostrar { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public bool? opciones { get; set; }
    }
}