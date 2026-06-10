using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_evaluaciones", Schema="public")]
    public class Publicaciones_Evaluaciones
    {
        [Key]
        public int id_evaluaciones { get; set; }
        public int id_crearpublicacion { get; set; }               
        public string actaprocomifacultad { get; set; }
        public DateTime? fechaactaprocomifacultad { get; set; }
        public string nombreactaprocomifacultad { get; set; }
        public string tipopublicacion { get; set; }
        public int? tirajetotal { get; set; }
        public string actaproconsfacultad { get; set; }
        public DateTime? fechaactaproconsfacultad { get; set; }
        public string nombreactaproconsfacultad { get; set; }
        public string gestorevalunijus { get; set; }
        public int id_evaluacioninicial { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}