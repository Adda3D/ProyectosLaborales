using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_costosorigencontrato", Schema="public")]
    public class Publicaciones_CostosOrigenContrato
    {
        [Key]
        public int id_origencontrato { get; set; }
        public string proyecto { get; set; }
        public string resolucion { get; set; }
        public DateTime fecresolucion { get; set; }
        public string quipu { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}