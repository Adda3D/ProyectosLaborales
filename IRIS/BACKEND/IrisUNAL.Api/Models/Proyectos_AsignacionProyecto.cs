using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("proyectos_asignacionproyecto", Schema="public")]
    public class Proyectos_AsignacionProyecto
    {
        [Key]
        public int id_asignacionproyecto { get; set; }
        [Required(ErrorMessage = "Id Propuesta es requerido")]
        public int? id_propuesta { get; set; }
        [Required(ErrorMessage = "Consecutivo proyecto es requerido")]
        [StringLength(50, MinimumLength = 1)]
        public string consecutivo { get; set; }
        [Required(ErrorMessage = "Suscripción es requerido")]
        public DateTime yearsuscripcion { get; set; }
        [Required(ErrorMessage = "Tipo proyecto es requerido")]
        public int id_tipopropuesta { get; set; }
        [Required(ErrorMessage = "Naturaleza proyecto es requerido")]
        public int id_naturalezaproyecto { get; set; }
        [Required(ErrorMessage = "Entidad es requerido")]
        public int idpropuesta_entidad { get; set; }
        [Required(ErrorMessage = "Nombre proyecto es requerido")]
        [StringLength(500, MinimumLength = 1)]
        public string nombreproyecto { get; set; }
        [Required(ErrorMessage = "Población objetivo es requerido")]
        [StringLength(200, MinimumLength = 1)]
        public string poblacionobjetivo { get; set; }
        [Required(ErrorMessage = "Director es requerido")]
        public int iddirector { get; set; }
        [Required(ErrorMessage = "Supervisor es requerido")]
        public int idsupervisor { get; set; }
        [Required(ErrorMessage = "Asistente Administrativo es requerido")]
        public int idasistente { get; set; }
        [Required(ErrorMessage = "Número contrato es requerido")]
        [StringLength(200, MinimumLength = 1)]
        public string numcontratoconvenio { get; set; }
        public string yearsejecucion { get; set; }
        public string plazoejecucion { get; set; }
        [Required(ErrorMessage = "Fecha inicio es requerido")]
        public DateTime fecacuerdovoluntades { get; set; }
        public DateTime? fecactainicio { get; set; }
        [Required(ErrorMessage = "Fecha terminación es requerido")]
        public DateTime fecterminacion { get; set; }
        [Required(ErrorMessage = "Ficha QUIPU es requerido")]
        [StringLength(20, MinimumLength = 1)]
        public string fichaquipu { get; set; }
        [Required(ErrorMessage = "Código HERMES es requerido")]
        [StringLength(20, MinimumLength = 1)]
        public string codigohermes { get; set; }
        public string numeromodificaciones { get; set; }
        [Required(ErrorMessage = "Objeto contraro es requerido")]
        [StringLength(800, MinimumLength = 1)]
        public string objetocontratoactividad { get; set; }
        [Required(ErrorMessage = "Alcance proyecto es requerido")]
        public int id_alcanceproyecto { get; set; }
        [Required(ErrorMessage = "Valor inicial es requerido")]
        public decimal valinicialaporteentidad { get; set; }
        public decimal? adiciondisminucion { get; set; }
        public decimal? contrapartida { get; set; }
        public decimal? valortotal { get; set; }
        [Required(ErrorMessage = "Área académica es requerido")]
        public int id_areaacad { get; set; }
        public int? nestudiantesderecho { get; set; }
        public int? nestudiantespolitica { get; set; }
        public int? nestudiantespostgrados { get; set; }
        [Required(ErrorMessage = "Número SAR es requerido")]
        [StringLength(30, MinimumLength = 1)]
        public string numerosar { get; set; }
        [Required(ErrorMessage = "Número ODS/OPS es requerido")]
        [StringLength(30, MinimumLength = 1)]
        public string numeroodsops { get; set; }
        [Required(ErrorMessage = "Estado contrato es requerido")]
        public int id_estadocontrato { get; set; }        
        public int? idregistrorup { get; set; }
        public int? idarchivoentrega { get; set; }
        public string contratoconvenioenlace { get; set; }
        public string entregaarchivoenlace { get; set; }
        public long? aportefacultad { get; set; }
        public long? aportevir { get; set; }
        public long? aportedieb { get; set; }
        public long? aprobadoconvenio { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        //public Funcionario asistente { get; set; }
        public Propuesta_Entidad entidad { get; set; }
  

        [NotMapped]
        public decimal ValorTotalProyecto
        {
            get
            {
                return valinicialaporteentidad + (decimal)adiciondisminucion + (decimal)contrapartida;
            }
        }

        [NotMapped]
        public string nmproyectodt
        {
            get
            {                
                return (nombreproyecto.Length > 59) ? String.Concat(nombreproyecto.Substring(0, 60), " ...") : nombreproyecto;
            }
        }
        /*
        [NotMapped]
        public string nmasistente
        {
            get
            {
                return (asistente == null) ? "" : asistente.nombrecompleto;
            }
        }
        */
        [NotMapped]
        public string nombreentidad
        {
            get
            {
                return (entidad == null) ? "" : entidad.razonsocial;
            }
        }


    }
}