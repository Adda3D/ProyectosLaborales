using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("propuesta_modificaciongarantia", Schema="public")]
    public class Propuesta_ModificacionGarantia
    {
        [Key]
        public int id_modificaciongarantia { get; set; }
        [Required(ErrorMessage = "ID suscripción garantía requerido")]
        public int id_suscripciongarantia { get; set; }
        [Required(ErrorMessage = "ID propuesta requerida")]
        public int id_propuesta { get; set; }
        [Required(ErrorMessage = "ID tipo Modificación requerido")]
        public int id_tipomodificacion { get; set; }
        public DateTime? fecsolicitud { get; set; }
        [Required(ErrorMessage = "Descripción de modificación requerido")]
        [StringLength(1000, MinimumLength = 1)]
        public string descripcion { get; set; }        
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Propuesta_TipoModificacion tipoModificacion { get; set; }
        public Propuesta_SuscripcionGarantia garantia { get; set; }

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