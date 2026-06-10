using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("propuesta_suscripcionminuta", Schema = "public")]
    public class Propuesta_SuscripcionMinuta
    {
        [Key]
        public int id_suscripcionminuta { get; set; }
        [Required(ErrorMessage = "ID Aval requerido")]
        public int id_avalconfac { get; set; }
        public int id_propuesta { get; set; }
        [Required(ErrorMessage = "Fecha recepción requerida")]
        public DateTime fecrecepcion { get; set; }
        [Required(ErrorMessage = "Estado cargue en SECOP requerido")]
        public string minutacargadasecop { get; set; }
        public DateTime? fecrevce { get; set; }
        public DateTime? fecremisiondecanatura { get; set; }
        [StringLength(50, ErrorMessage = "Consecutivo decanatura no puede exceder 50 caracteres")]
        public string consecutivoremisiondecanatura { get; set; }
        public DateTime? fecrespuestaobsdecanatura { get; set; }
        [StringLength(500, ErrorMessage = "Observaciones decanatura no puede exceder 500 caracteres")]
        public string observacionesdecanatura { get; set; }
        public DateTime? fecintegracionaobsminuta { get; set; }
        [StringLength(50, ErrorMessage = "Consecutivo remisión entidadno puede exceder 50 caracteres")]
        public string consecutivoremisionminutaent { get; set; }
        public int? tiemporevminuta { get; set; }
        public DateTime? fecrespobsminuta { get; set; }
        public int? tiemporemminutaobs { get; set; }
        public DateTime? fecaprintminuta { get; set; }
        public string avalesinternos { get; set; }
        public DateTime? firmaunal { get; set; }
        public DateTime? firmaminutasecop { get; set; }
        public DateTime? firmaentidad { get; set; }
        [Required(ErrorMessage = "Número minuta requerido")]
        [StringLength(50, MinimumLength = 1)]
        public string numminuta { get; set; }
        [Required(ErrorMessage = "Nombre minuta requerido")]
        [StringLength(250, MinimumLength = 1)]
        public string nombreminutaproyecto { get; set; }
        public string enlacesoportes { get; set; }
        public int? idresponsablece { get; set; }
        public int? idresponsabledecanatura { get; set; }
        public int? idresponsableobsdec { get; set; }
        public int? idresponsableintegraobs { get; set; }
        public int? idresponsableavales { get; set; }
        public int? idresponsablefirma { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Propuesta propuesta { get; set; }
        public Propuesta_AvalConsejoFacultad avalconsejo { get; set; }
    }
}