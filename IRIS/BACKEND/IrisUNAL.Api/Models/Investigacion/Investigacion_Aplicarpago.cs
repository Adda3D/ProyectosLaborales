using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.Investigacion
{
    [Table("investigacion_aplicarpago", Schema = "public")]
    public class Investigacion_Aplicarpago
    {
        [Key]
        public int id_investigacionpago { get; set; }        
        public int id_crearproyecto { get; set; }
        public int id_investigaciongasto { get; set; }
        public DateTime fechapago { get; set; }
        [Required(ErrorMessage = "ORPA es requerido")]
        [StringLength(30, MinimumLength = 1)]
        public string orpa { get; set; }
        [Required(ErrorMessage = "Comprobante de egreso es requerido")]
        [StringLength(30, MinimumLength = 1)]
        public string cp_egr { get; set; }
        [Required(ErrorMessage = "Período es requerido")]
        public int id_semestre { get; set; }
        [Required(ErrorMessage = "Valor neto es requerido")]
        public decimal valorneto { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Semestre ObjSemestre { get; set; }
        public Investigacion_Gasto ObjGasto { get; set; }
        public Investigacion_CrearProyecto ObjProyecto { get; set; }

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