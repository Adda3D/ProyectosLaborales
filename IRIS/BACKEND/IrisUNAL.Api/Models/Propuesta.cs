using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("propuesta", Schema = "public")]
    public class Propuesta
    {
        [Key]
        public int id_propuesta { get; set; }

        [Required(ErrorMessage = "Consecutivo oferta requerido")]
        [StringLength(50, MinimumLength = 1)]
        public string consecutivooferta { get; set; }

        [Required(ErrorMessage = "Nombre propuesta requerido")]
        [StringLength(500, MinimumLength = 1)]
        public string nmpropuesta { get; set; }

        [Required(ErrorMessage = "Fecha radicación requerido")]
        public DateTime fecrad { get; set; }
        public decimal valorinicialpropuesta { get; set; }

        [Required(ErrorMessage = "Responsable es requerido")]
        public int idfuncionario { get; set; }

        [Required(ErrorMessage = "Tipo usuario es requerido")]
        public int id_propuestatipousuario { get; set; }

        [Required(ErrorMessage = "Modalidad es requerido")]
        public int id_modalidad { get; set; }

        [Required(ErrorMessage = "Origen es requerido")]
        public int id_origenpropuesta { get; set; }

        [Required(ErrorMessage = "Tipo propuesta es requerido")]
        public int id_tipopropuesta { get; set; }
        public int? id_aprobacionconsejofacultad { get; set; }
        public int? id_actaconsejofacultad { get; set; }
        public string oficioaprobacion { get; set; }
        public string oficioaprobenlace { get; set; }
        public string actaaprobacion { get; set; }
        public string actaaprobenlace { get; set; }
        [Required(ErrorMessage = "Estado propuesta es requerido")]
        public int id_estadopropuesta { get; set; }

        [Required(ErrorMessage = "Contratante es requerido")]
        public int idpropuesta_entidad { get; set; }
        public string contratoconvenio { get; set; }
        public int? id_estadosuscripcioncontratoconvenio { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Funcionario funcionario { get; set; }
        public Propuesta_Entidad contratante { get; set; }
        public Propuesta_EstadoPropuesta estado { get; set; }
        public Propuesta_TipoPropuesta ObjTipoPropuesta { get; set; }

        [NotMapped]
        public string nmpropuestadt
        {
            get
            {
                return (nmpropuesta.Length > 59) ? String.Concat(nmpropuesta.Substring(0, 60), " ...") : nmpropuesta;
            }
        }

        [NotMapped]
        public string responsable
        {
            get
            {
                return (funcionario == null) ? "" : funcionario.nombrecompleto;
            }
        }

        [NotMapped]
        public string entidadcontrata
        {
            get
            {
                return (contratante == null) ? "" : contratante.razonsocial;
            }
        }

        [NotMapped]
        public string nombreestado
        {
            get
            {
                return (estado == null) ? "" : estado.nmestadopropuesta;
            }
        }

        [NotMapped]
        public string strfecrad
        {
            get
            {
                return fecrad.ToString("yyyy-MM-dd");
            }
        }

        [NotMapped]
        public string strvalor
        {
            get
            {
                return (valorinicialpropuesta == 0) ? "" : valorinicialpropuesta.ToString("#,#");
                
            }
        }

        [NotMapped]
        public string TipoPropuesta
        {
            get
            {
                return (ObjTipoPropuesta == null) ? "" : ObjTipoPropuesta.nmtipopropuesta;
            }
        }

    }
}