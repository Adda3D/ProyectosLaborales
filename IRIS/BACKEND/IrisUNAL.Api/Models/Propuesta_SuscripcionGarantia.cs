using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("propuesta_suscripciongarantia", Schema="public")]
    public class Propuesta_SuscripcionGarantia
    {
        [Key]
        public int id_suscripciongarantia { get; set; }
        [Required(ErrorMessage = "ID Propuesta requerido")]
        public int id_propuesta { get; set; }
        [Required(ErrorMessage = "Coberturas requeridas")]
        [StringLength(100, MinimumLength = 1)]
        public string coberturas { get; set; }
        [Required(ErrorMessage = "Descripción de amparo requerido")]
        [StringLength(500, MinimumLength = 1)]
        public string descripcionamparo { get; set; }
        public string cdp { get; set; }
        public string rag { get; set; }
        public string orpa { get; set; }
        [Required(ErrorMessage = "Fecha solicitud póliza requerido")]
        public DateTime fecsolaseguradora { get; set; }
        public int? idresponsablesolaseguradora { get; set; }
        [StringLength(128)]
        public string nombreaseguradora { get; set; }
        public DateTime? fecapropoliza { get; set; }
        [StringLength(50)]
        public string numeropoliza { get; set; }
        public DateTime? fecpagopoliza { get; set; }
        public decimal valorpoliza { get; set; }
        public DateTime? vigenciapolizainicio { get; set; }
        public DateTime? vigenciapolizafin { get; set; }
        public int? idresponsablepagopoliza { get; set; }
        public DateTime? fecrementidad { get; set; }
        public string consecutivoremision { get; set; }
        public DateTime? actupolsecop { get; set; }
        public int? idresponsableremisionpoliza { get; set; }
        public int? idresponsablepolizasecop { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Propuesta propuesta { get; set; }
    }
}