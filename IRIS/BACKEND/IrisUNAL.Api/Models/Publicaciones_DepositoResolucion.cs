using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_depositoresolucion", Schema="public")]
    public class Publicaciones_DepositoResolucion
    {
        [Key]
        public int id_resolucion { get; set; }
        public int id_crearpublicacion { get; set; }
        public string numresolucion { get; set; }
        public string quiengenera { get; set; }
        public DateTime fecresolucion { get; set; }
        public string actoadmin { get; set; }
        public int ejemplaresinstitucional { get; set; }
        public int ejemplaresinmovil { get; set; }
        public int ejemplarescomercializa { get; set; }
        public int tirajeimpresion { get; set; }
        public int tirajetotal { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}