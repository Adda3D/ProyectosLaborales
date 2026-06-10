using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.Hermes
{
    [Table("hermes_investigacion", Schema = "public")]
    public class HermesProyectoInvestigacion
    {
        [Key]
		public int idproyecto { get; set; }
		public int id_hermes { get; set; }
        public string codigoquipu { get; set; }
        public string tipologiaproyecto { get; set; }
        public string nombreproyecto { get; set; }
        public int? duracion { get; set; }
        public string resumen { get; set; }
		public string estadoactual { get; set; }
		public string lugarejecucion { get; set; }
		public string objetivogeneral { get; set; }
		public string convocatoria { get; set; }
		public string annioconvocatoria { get; set; }
		public string tipoconvocatoria { get; set; }
		public string modalidad { get; set; }
		public string tdocinvprincipal { get; set; }
		public string documentoinvprinc { get; set; }
		public string invprincipal { get; set; }
		public string horasdedicacion { get; set; }
		public string sede { get; set; }
		public string facultad { get; set; }
		public string departamento { get; set; }
		public DateTime? fechapropuesta { get; set; }
		public DateTime? fechainicio { get; set; }
		public DateTime? fechafinal { get; set; }
		public DateTime? fechafinalprorrogas { get; set; }
        public decimal? valorpersonal { get; set; }
		public decimal? montointernofinanciado { get; set; }
		public decimal? montoexternofinanciado { get; set; }
		public decimal? montoentparticipantes { get; set; }
		public decimal? montoadicionesapobadas { get; set; }
		public decimal? totalactualproyecto { get; set; }
		public string impactoesperado { get; set; }
		public string justificacion { get; set; }
		public string metodologia { get; set; }
		public string descripcion { get; set; }
		public string antecedentes { get; set; }
		public string jornadadocente { get; set; }
		public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }

		[NotMapped]
		public string nombreproyectodt
		{
			get
			{
				return (nombreproyecto == null) ? "" : (nombreproyecto.Length > 89) ? String.Concat(nombreproyecto.Substring(0, 90), " ...") : nombreproyecto;
			}
		}

		[NotMapped]
		public string convocatoriadt
		{
			get
			{
				return (convocatoria == null) ? "" : (convocatoria.Length > 89) ? String.Concat(convocatoria.Substring(0, 90), " ...") : convocatoria;
			}
		}

	}
}
