using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.Decanatura
{
    [Table("matrizfinanciera_gastoapoyo", Schema="public")]
    public class MatrizFinanciera_GastoApoyo
    {
        [Key]
        public int id_gastoapoyo { get; set; }
        public int id_depend { get; set; }
        public int id_matrizfinanciera { get; set; }
        public int? especializado { get; set; }
        public int? profesional { get; set; }
        public int? tecnico { get; set; }
        public int? asistencial { get; set; }
        public int? totalpersonascontratadas { get; set; }
        public int valortotal { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Dependencia Objdependencia { get; set; }
        public MatrizFinanciera Objmatrizfinanciera { get; set; }

        [NotMapped]
        public string MatrizFinancieraVigencia
        {
            get
            {
                return (Objmatrizfinanciera == null) ? "" : Objmatrizfinanciera.NombreVigencia;
            }
        }

        [NotMapped]
        public string NombreDependencia
        {
            get
            {
                return (Objdependencia == null) ? "" : Objdependencia.nmdepend;
            }
        }
    }
}