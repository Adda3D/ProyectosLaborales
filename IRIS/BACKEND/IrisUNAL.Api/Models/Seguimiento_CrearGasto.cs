using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("seguimiento_creargasto", Schema="public")]
    public class Seguimiento_CrearGasto
    {
        [Key]
        public int id_creargasto { get; set; }
        [Required(ErrorMessage = "Concepto es requerido")]
        public int id_segconcepto { get; set; }
        public int? id_financieroexcel { get; set; }
        [Required(ErrorMessage = "Proyecto es requerido")]
        public int id_asignacionproyecto { get; set; }
        [Required(ErrorMessage = "Prestador es requerido")]        
        public int id_persona { get; set; }
        [Required(ErrorMessage = "Partida es requerido")]
        public int id_partida { get; set; }
        [Required(ErrorMessage = "Rubro es requerido")]
        public int id_rubro { get; set; }
        [Required(ErrorMessage = "Vínculo es requerido")]
        public int id_relacionvinculo { get; set; }
        [Required(ErrorMessage = "Nombre gasto es requerido")]
        [StringLength(500, MinimumLength = 1)]
        public string nombregasto { get; set; }
        [Required(ErrorMessage = "Valor total es requerido")]
        public decimal valortotal { get; set; }
        [Required(ErrorMessage = "Fecha legalización es requerido")]
        public DateTime fechalegalizacionorden { get; set; }
        public string tipo { get; set; }
        [Required(ErrorMessage = "Número de order es requerido")]
        [StringLength(30, MinimumLength = 1)]
        public string numorden { get; set; }
        [Required(ErrorMessage = "Fecha inicio es requerido")]
        public DateTime fechainicio { get; set; }
        [Required(ErrorMessage = "Fecha finaliza es requerido")]
        public DateTime fechafinal { get; set; }
        public string estado { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public decimal gastototal4mil { get; set; }
        public Persona objPersona { get; set; }
        public Seguimiento_Concepto objConcepto { get; set; }
        public Seguimiento_Rubro ObjRubro { get; set; }

        [NotMapped]
        public decimal Total4mil
        {
            get
            {
                decimal valor = (valortotal == 0) ? 0 : valortotal * 4 / 1000;
                valor = valortotal + valor;

                return valor;
            }
        }

        [NotMapped]
        public decimal? TotalPagado { get; set; }

        [NotMapped]
        public string NombrePersona
        {
            get
            {
                return (objPersona == null) ? "" : objPersona.nombrecompleto;
            }
        }

        [NotMapped]
        public string  Identificacion
        {
            get
            {
                return (objPersona == null) ? "" : objPersona.numidentificacion;
            }
        }

        [NotMapped]
        public string NombreConcepto
        {
            get
            {
                return (objConcepto == null) ? "" : objConcepto.nombreconcepto;
            }
        }
        
        [NotMapped]
        public string NombreRubro
        {
            get
            {
                return (ObjRubro == null) ? "" : ObjRubro.nombrerubro;
            }
        }
    }
}