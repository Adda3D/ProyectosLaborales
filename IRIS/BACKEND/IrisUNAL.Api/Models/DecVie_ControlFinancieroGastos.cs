using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_controlfinancierogastos", Schema="public")]
    public class DecVie_ControlFinancieroGastos
    {
        [Key]
        public int id_gastos { get; set; }
        public int id_depend { get; set; }
        public string numpersonascontratadas { get; set; }
        public double valortotalcontdependencia { get; set; }
        public bool profesioalespecializado { get; set; }
        public bool profesional { get; set; }
        public bool tecnico { get; set; }
        public bool asistencial { get; set; }
        public int id_controlfinanciero { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}