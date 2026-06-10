using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("propuesta_modificacionminuta", Schema="public")]
    public class Propuesta_ModificacionMinuta
    {
        [Key]
        public int id_modificacionminuta { get; set; }
        [Required(ErrorMessage = "ID Minuta requerido")]
        public int id_suscripcionminuta { get; set; }
        [Required(ErrorMessage = "ID propuesta requerida")]
        public int id_propuesta { get; set; }
        [Required(ErrorMessage = "Fecha solicitud modificación requerida")]
        public DateTime fecsolmodvol { get; set; }        
        [Required(ErrorMessage = "Tipo modificación requerido")]
        public int id_tipomodificacion { get; set; }
        [Required(ErrorMessage = "Descripción modificación requerida")]
        [StringLength(800, MinimumLength = 1)]
        public string descripcionmodificacion { get; set; }
        public int? idresponsablerevsolicitud { get; set; }
        public DateTime? fecrevisionsolicitud { get; set; }
        public int? idresponsableremitedecanatura { get; set; }
        public DateTime? fecremsolmoddecanatura { get; set; }
        public string consecutivoremisiondecanatura { get; set; }
        public int? tiemporevisiondec { get; set; }
        public int? idresponsableaprobmodificacion { get; set; }
        public DateTime? fecrecepcionobsdec { get; set; }
        public DateTime? fecremisionobsentidad { get; set; }
        public DateTime? fecapromodificaciones { get; set; }
        public string avalinterno { get; set; }
        public DateTime? fecsusmodacuvol { get; set; }
        public decimal valorajustado { get; set; }
        [StringLength(120)]
        public string plazoejecajustado { get; set; }
        [StringLength(900)]
        public string obligacionesmodificadas { get; set; }
        [StringLength(900)]
        public string productosmodificados { get; set; }
        [StringLength(500)]
        public string enlacesoportes { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }

        public Propuesta_SuscripcionMinuta minuta { get; set; }
        public Propuesta_TipoModificacion tipoModificacion { get; set; }

        [NotMapped]
        public string tipomodificaciondetalle
        {
            get
            {                
                return (tipoModificacion == null) ? "" : tipoModificacion.nmtipomodificacion;
            }
        }

    }
}