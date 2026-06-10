using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.Hermes
{
    public class HermesProyectoInvestigacionWS
    {
		public int id { get; set; }
		public string codigoQUIPU { get; set; }
		public string tipologiaProyecto { get; set; }
		public string nombreProyecto { get; set; }
		public int? duracion { get; set; }
		public string resumen { get; set; }
		public string estadoActual { get; set; }
		public string lugarEjecucion { get; set; }
		public string objetivoGeneral { get; set; }
		public string convocatoria { get; set; }
		public string añoConvocatoria { get; set; }
		public string tipoConvocatoria { get; set; }
		public string modalidad { get; set; }
		public string tDocInvPrincipal { get; set; }
		public string documentoInvPrinc { get; set; }
		public string invPrincipal { get; set; }
		public string horasDedicacion { get; set; }
		public string sede { get; set; }
		public string facultad { get; set; }
		public string departamento { get; set; }
		public DateTime? fechaPropuesta { get; set; }
		public DateTime? fechaInicio { get; set; }
		public DateTime? fechaFinal { get; set; }
		public DateTime? fechaFinalProrrogas { get; set; }
		public decimal? valorPersonal { get; set; }
		public decimal? montoInternoFinanciado { get; set; }
		public decimal? montoExternofinanciado { get; set; }
		public decimal? montoEntParticipantes { get; set; }
		public decimal? montoAdicionesApobadas { get; set; }
		public decimal? totalActualProyecto { get; set; }
		public string impactoEsperado { get; set; }
		public string justificacion { get; set; }
		public string metodologia { get; set; }
		public string descripcion { get; set; }
		public string antecedentes { get; set; }
		public string jornadaDocente { get; set; }
	}
}