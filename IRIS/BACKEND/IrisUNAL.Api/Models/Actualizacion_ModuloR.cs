using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("actualizacion_modulor", Schema="public")]
    public class Actualizacion_ModuloR
    {
        [Key]
        public int id_actualizacionmodulor { get; set; }
        public int id_asignacionproyecto { get; set; }        
        public DateTime fecrevinicialeshermesrup { get; set; }
        public string obscerrarmodrup { get; set; }
        public DateTime? fecremproydneipi1 { get; set; }        
        public DateTime? fecdevdneipi { get; set; }        
        public DateTime? feccorreccionproy { get; set; }        
        public DateTime? fecremproydneipi2 { get; set; }       
        public DateTime? fecverenvcamaracomercio { get; set; }        
        public string codrup { get; set; }
        public long? valorsmlv { get; set; }
        public int? idfuncionarioremitedneipi { get; set; }
        public int? idfuncionariodevodneipi { get; set; }
        public int? idfuncionariocorreccion { get; set; }
        public int? idfuncionarioreenviodneipi { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public string observaciones { get; set; }
        public bool activo { get; set; }
        public Proyectos_AsignacionProyecto ObjProyecto { get; set; }
    }
}