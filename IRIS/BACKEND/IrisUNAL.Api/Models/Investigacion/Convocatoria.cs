using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.Investigacion
{
    [Table("convocatoria", Schema="public")]
    public class Convocatoria
    {
        [Key]
        public int id_convocatoria { get; set; }
        public string naturaleza { get; set; }
        public int id_alcance { get; set; }
        public int id_fuentecnv { get; set; }
        public string tituloconvocatoria { get; set; }
        public string objetivogeneral { get; set; }
        public string dirigidolargo { get; set; }
        public string dirigidocorto { get; set; }
        public int totalrecursos { get; set; }
        public int? id_recursoparticipante { get; set; }
        public DateTime fechaapertura { get; set; }
        public DateTime fechacierre { get; set; }
        public DateTime fecharesultadosdef { get; set; }
        public int id_estadocnv { get; set; }
        public int contrapartida { get; set; }
        public int? id_requisito { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Convocatoria_Alcance Objconvocatoriaalcance { get; set; }
        public Convocatoria_EstadoCnv Objconvocatoriaestado { get; set; }
        public Convocatoria_FuenteCnv Objconvocatoriafuente { get; set; }        

        [NotMapped]
        public string NombreAlcance
        {
            get
            {
                return (Objconvocatoriaalcance == null) ? "" : Objconvocatoriaalcance.nmalcance;
            }
        }
        [NotMapped]
        public string NombreEstado
        {
            get
            {
                return (Objconvocatoriaestado == null) ? "" : Objconvocatoriaestado.nmestadocnv;
            }
        }
        [NotMapped]
        public string NombreFuente
        {
            get
            {
                return (Objconvocatoriafuente == null) ? "" : Objconvocatoriafuente.nmfuentecnv;
            }
        }       
    }
}