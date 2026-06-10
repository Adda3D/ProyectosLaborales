using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_informacionpago", Schema="public")]
    public class Publicaciones_InformacionPago
    {
        [Key]
        public int id_informacionpago { get; set; }
        public int id_persona { get; set; }
        public int id_crearpublicacion { get; set; }
        public int id_evaluadores { get; set; }
        public decimal valor { get; set; }
        public string quipu { get; set; }
        public string rag { get; set; }
        public string orpa { get; set; }
        public DateTime fecpago { get; set; }
        public string cpeg { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Persona objPersona { get; set; }

        [NotMapped]
        public decimal Total4mil
        {
            get
            {
                decimal valorimpto = (valor == 0) ? 0 : valor * 4 / 1000;
                valorimpto = valorimpto + valor;

                return valorimpto;
            }
        }

        [NotMapped]
        public string NombreEvaluador
        {
            get
            {
                return (objPersona == null) ? "" : objPersona.nombrecompleto;
            }
        }


    }
}