using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.Investigacion
{
    [Table("convocatoria_interesados", Schema="public")]
    public class Convocatoria_Interesados
    {
        [Key]
        public int id_interesados { get; set; }
        public int id_convocatoria { get; set; }
        public string tituloconvocatoria { get; set; }
        public string nombreinteresado { get; set; }
        public string correointeresado { get; set; }
        public int? idhermes { get; set; }
        public DateTime fechainteres { get; set; }
        public DateTime? diascierre { get; set; }
        public DateTime? fecenviocorreo { get; set; }
        public string consecutivocorreo { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Convocatoria Objconvocatoria { get; set; }

        [NotMapped]
        public string NombreTituloConvocatoria
        {
            get
            {
                return (Objconvocatoria == null) ? "" : Objconvocatoria.tituloconvocatoria;
            }
        }

    }
}