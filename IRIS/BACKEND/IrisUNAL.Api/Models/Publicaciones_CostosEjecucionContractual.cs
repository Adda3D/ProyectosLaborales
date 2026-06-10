using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_costosejecucioncontractual", Schema="public")]
    public class Publicaciones_CostosEjecucionContractual
    {
        [Key]
        public int id_ejecucion { get; set; }
        public DateTime ano { get; set; }
        public int id_persona { get; set; }
        public string tipoordencontractual { get; set; }
        public string numero { get; set; }
        public double valorbruto { get; set; }
        public double cuatropormil { get; set; }
        public double valorneto { get; set; }
        public string orpa { get; set; }
        public DateTime fecha { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
    }
}