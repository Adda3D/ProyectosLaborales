using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.Investigacion
{
    [Table("convocatoria_requerimientorequisito", Schema="public")]
    public class Convocatoria_RequerimientoRequisito
    {
        [Key]
        public int id_requisito { get; set; }
        public int id_convocatoria { get; set; }
        public string nmrequisito { get; set; }
        public string descripcionrequisito { get; set; }
        public string linkdocumento { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Convocatoria Objconvocatoria { get; set; }

        [NotMapped]
        public string TituloConvocatoria
        {
            get
            {
                return (Objconvocatoria == null) ? "" : Objconvocatoria.tituloconvocatoria;
            }
        }
    }
}