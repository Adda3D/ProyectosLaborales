using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("tareas", Schema="public")]
    public class Tareas
    {
        [Key]
        public int id_tarea { get; set; }
        public string detalles { get; set; }
        public DateTime fechainicio { get; set; }        
        public DateTime? fechafin { get; set; }
        public DateTime fechaentrega { get; set; }
        public int id_estadotarea { get; set; }
        public string funcionario { get; set; }
        public int? idtareamodulo { get; set; }
        public int? idrelacionado { get; set; }
        public string consecutivo { get; set; }
        public int avance { get; set; }
        public string seguimiento { get; set; }
        public string relacioncon { get; set; }
        public string funcionarioasigna { get; set; }
        public string asignadopor { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }        
        public Estado_Tarea ObjEstado { get; set; }
        public Tareas_Modulo ObjModulo { get; set; }        

        [NotMapped]
        public string EstadoTarea
        {
            get
            {
                return (ObjEstado == null) ? "" : ObjEstado.nmestadotarea;
            }
        }

        [NotMapped]
        public string NombreModulo
        {
            get
            {
                return (ObjModulo == null) ? "" : ObjModulo.nombremodulo;
            }
        }

        [NotMapped]
        public string Responsable { get; set; }        

        [NotMapped]
        public int DiasVence
        {
            get
            {
                var today = DateTime.Now;
                var hoy = new DateTime(today.Year, today.Month, today.Day);
                var diffOfDates = hoy - fechaentrega;

                return diffOfDates.Days;

            }
        }
    }
}