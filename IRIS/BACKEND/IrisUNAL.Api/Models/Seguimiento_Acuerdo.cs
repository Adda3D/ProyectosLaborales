using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("seguimiento_acuerdo", Schema = "public")]
    public class Seguimiento_Acuerdo
    {
        [Key]
        public int idacuerdo { get; set; }
        [Required(ErrorMessage = "Id Proyecto es requerido")]
        public int id_asignacionproyecto { get; set; }
        [Required(ErrorMessage = "Número de acuerdo es requerido")]
        [StringLength(15, MinimumLength = 1)]
        public string nroacuerdo { get; set; }
        [Required(ErrorMessage = "Sede acuerdo es requerido")]
        [StringLength(30, MinimumLength = 1)]
        public string sedeacuerdo { get; set; }
        [Required(ErrorMessage = "Facultad acuerdo es requerido")]
        [StringLength(30, MinimumLength = 1)]
        public string facultadacuerdo { get; set; }
        [Required(ErrorMessage = "Nombre acuerdo es requerido")]
        [StringLength(40, MinimumLength = 1)]
        public string nombreacuerdo { get; set; }
        [Required(ErrorMessage = "Fecha inicia es requerido")]
        public DateTime iniciaacuerdo { get; set; }
        [Required(ErrorMessage = "Fecha finaliza es requerido")]
        public DateTime finalizaacuerdo { get; set; }
        [Required(ErrorMessage = "Duración acuerdo es requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string duracionacuerdo { get; set; }
        [Required(ErrorMessage = "Objeto acuerdo es requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string objetoacuerdo { get; set; }
        [Required(ErrorMessage = "Justificación acuerdo es requerido")]
        [StringLength(100, MinimumLength = 1)]
        public string justificacionacuerdo { get; set; }
        [Required(ErrorMessage = "Valor acuerdo es requerido")]
        public decimal valoracuerdo { get; set; }
        public string beneficioacuerdo { get; set; }
        public string dificultadesacuerdo { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Proyectos_AsignacionProyecto ObjProyecto { get; set; }

    }
}