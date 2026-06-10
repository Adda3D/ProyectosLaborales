using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("seguimiento_aplicarpago", Schema = "public")]
    public class Seguimiento_AplicarPago
    {
        [Key]
        public int id_aplicarpago { get; set; }
        public int? id_financieroexcel { get; set; }
        public int id_asignacionproyecto { get; set; }
        public int id_creargasto { get; set; }
        public DateTime fecha { get; set; }
        [Required(ErrorMessage = "ORPA es requerido")]
        [StringLength(30, MinimumLength = 1)]
        public string orpa { get; set; }
        [Required(ErrorMessage = "Comprobante de egreso es requerido")]
        [StringLength(30, MinimumLength = 1)]
        public string cp_egr { get; set; }
        [Required(ErrorMessage = "Período es requerido")]
        public int id_semestre { get; set; }
        [Required(ErrorMessage = "Valor neto es requerido")]
        public int valorneto { get; set; }
        public string notas { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Semestre ObjSemestre { get; set; }
        public Seguimiento_CrearGasto ObjGasto { get; set; }

        [NotMapped]
        public string Periodo
        {
            get
            {
                return (ObjSemestre == null) ? "" : ObjSemestre.nmsemestre;
            }
        }
    }
}