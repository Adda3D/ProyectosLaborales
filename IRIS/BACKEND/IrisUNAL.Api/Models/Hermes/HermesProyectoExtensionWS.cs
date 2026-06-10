using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.Hermes
{
	public class LstHermesExtension
    {
		public HermesProyectoExtensionWS[] items { get; set; }
	}

    public class HermesProyectoExtensionWS
    {
		public int codigo_hermes { get; set; }
		public string proceso { get; set; }
		public string actividad { get; set; }
		public string estado { get; set; }
		public string observacion { get; set; }
		public string codigo_quipu { get; set; }
		public string modalidad { get; set; }
		public string submodalidad { get; set; }
		public string nombre_proyecto { get; set; }
		public string origen_propuesta { get; set; }
		public string id_acuerdo_interfic { get; set; }
		public int? id_convocatoria { get; set; }
		public string nombre_convocatoria { get; set; }
		public string objeto_convocatoria { get; set; }
		public string documentos_adjuntos { get; set; }
		public string justificacion { get; set; }
		public string convenio_marco { get; set; }
		public string firma { get; set; }
		public DateTime? fecha_acuerdo { get; set; }
		public DateTime? fecha_inicio_proyecto { get; set; }
		public DateTime? fecha_fin_proyecto { get; set; }
		public DateTime? fecha_fin_ejecucion { get; set; }
		public DateTime? fecha_liquidacion_quipu { get; set; }
		public string informe_final { get; set; }
		public string enlace_informe_final { get; set; }
	}
}