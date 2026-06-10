using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_planaccionmatrizindicadores", Schema="public")]
    public class DecVie_PlanAccionMatrizIndicadores
    {
        [Key]
        public int id_matrizindicadores { get; set; }
        public int id_ejeestrategico { get; set; }
        public int id_programapgd { get; set; }
        public int id_objetivopgdvrisede { get; set; }
        public int id_decviemacroproceso { get; set; }
        public int id_objetivodependencia { get; set; }
        public int id_meta { get; set; }
        public int id_actividades { get; set; }
        public int id_indicadoresestrategicos { get; set; }
        public int id_nuevosindicadores { get; set; }
        public int id_tipoindicador { get; set; }
        public string descripcion { get; set; }
        public double presupuesto { get; set; }
        public string alcance { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}