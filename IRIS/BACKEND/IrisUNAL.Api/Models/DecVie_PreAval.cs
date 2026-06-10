using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_preaval", Schema = ("public"))]
    public class DecVie_PreAval
    {
        [Key]
        public int id_preaval { get; set; }
        public DateTime? fecradicacion { get; set; }
        public string consecutivo { get; set; }
        public string tiposolucitud { get; set; }
        public int? id_rubro { get; set; }
        public int id_decviemacroproceso { get; set; }
        public int id_depend { get; set; }
        public string proyecto { get; set; }
        public string quipu { get; set; }
        public string hermes { get; set; }
        public int id_doccontractuales { get; set; }
        public int? montosolicitado { get; set; }
        public int id_persona { get; set; }
        public string tiempovinculacion { get; set; }
        public string objeto { get; set; }
        public string obligaciones { get; set; }
        public string revisionprecontractual { get; set; }
        public int? id_revsigep { get; set; }
        public int? id_asuntosdisciplinarios { get; set; }
        public int? id_conceptodecanatura { get; set; }
        public int? id_estadopreaval { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public string observacionesdecanatura { get; set; }
        public Persona Objpersona { get; set; }
        public Seguimiento_Rubro Objrubro {get; set;}
        public DecVie_Macroproceso Objmacroproceso { get; set; }        
        public Dependencia Objdependencia { get; set; }
        public DecVie_TipoDocContractuales Objtipodocumentoscontractuales { get; set; }
        public DecVie_EstadoPreAval Objestadopreaval { get; set; }
        
        

        [NotMapped]
        public string NombrePersona
        {
            get
            {
                return (Objpersona == null) ? "" : Objpersona.nombrecompleto;
            }
        }

        [NotMapped]
        public string NombreMacroproceso
        {
            get
            {
                return (Objmacroproceso == null) ? "" : Objmacroproceso.nmdecviemacroproceso;
            }
        }

        [NotMapped]
        public string NombreRubro
        {
            get
            {
                return (Objrubro == null) ? "" : Objrubro.nombrerubro;
            }
        }

        [NotMapped]
        public string NombreDependencia
        {
            get
            {
                return (Objdependencia == null) ? "" : Objdependencia.nmdepend;
            }
        }

        [NotMapped]
        public string TipoDocumentoContractual
        {
            get
            {
                return (Objtipodocumentoscontractuales == null) ? "" : Objtipodocumentoscontractuales.nmdoccontractuales;
            }
        }        

        [NotMapped]
        public string NombreEstadoPreaval
        {
            get
            {
                return (Objestadopreaval == null) ? "" : Objestadopreaval.nmestadopreaval;
            }
        }
        
    }
}