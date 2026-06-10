using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.Decanatura
{
    [Table("matrizfinanciera", Schema="public")]
    public class MatrizFinanciera
    {
        [Key]
        public int id_matrizfinanciera { get; set; }
        public int id_vigencia { get; set; }
        public int? id_depend { get; set; }
        public long presupuestogeneral { get; set; }
        public long presupuestogeneralcomprometido { get; set; }
        public long presupuestogeneralcomprometer { get; set; }
        public long presupuestougi { get; set; }
        public long presupuestougicomprometido { get; set; }
        public long presupuestougicomprometer { get; set; }
        public long presupuestoestudiantes { get; set; }
        public long presupuestoestudiantescomprometido { get; set; }
        public long presupuestoestudiantescomprometer { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public MatrizFinanciera_Vigencia Objvigencia { get; set; }
        public Dependencia Objdependencia { get; set; }

        [NotMapped]
        public string NombreVigencia
        {
            get
            {
                return (Objvigencia == null) ? "" : Objvigencia.nmvigencia;
            }
        }

        //[NotMapped]
        //public string NombreDependencia
        //{
        //    get
        //    {
        //        return (Objdependencia == null) ? "" : Objdependencia.nmdepend;
        //    }
        //}
    }
}