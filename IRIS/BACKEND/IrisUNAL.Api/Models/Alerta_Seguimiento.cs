using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("alerta_seguimiento", Schema = "public")]
    public class Alerta_Seguimiento
    {
        [Key]
        public int idalertaseguimiento { get; set; }
        public string opcion { get; set; }
        public string consecutivo { get; set; }
        public string tituloalerta { get; set; }
        public string observaciones { get; set; }
        public string usuario { get; set; }
        public DateTime fechavence { get; set; }
        public string estado { get; set; }
        public DateTime? fechafinaliza { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }

        [NotMapped]
        public int DiasVence
        {
            get
            {
                var today = DateTime.Now;
                var hoy = new DateTime(today.Year, today.Month, today.Day);
                var diffOfDates = hoy - fechavence;

                return diffOfDates.Days;

            }
        }

    }
}