using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.Investigacion
{
    [Table("convocatoria_recursoparticipante", Schema="public")]
    public class Convocatoria_RecursoParticipante
    {
        [Key]
        public int id_recursoparticipante { get; set; }
        public int id_convocatoria { get; set; }
        public string nmrecurso { get; set; }
        public int? valorrecurso { get; set; }
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