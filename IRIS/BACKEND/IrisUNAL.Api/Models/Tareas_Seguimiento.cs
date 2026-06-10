using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("tareas_seguimiento", Schema = "public")]
    public class Tareas_Seguimiento
    {
        [Key]
        public int idtareaseguimiento { get; set; }
        public int id_tarea { get; set; }
        public string observaciones { get; set; }
        public DateTime fecharealiza { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Tareas ObjTarea { get; set; }        

        [NotMapped]
        public string NombreTarea
        {
            get
            {
                return (ObjTarea == null) ? "" : ObjTarea.detalles;
            }
        }

        [NotMapped]
        public string UsuarioSeguimiento;

    }
}