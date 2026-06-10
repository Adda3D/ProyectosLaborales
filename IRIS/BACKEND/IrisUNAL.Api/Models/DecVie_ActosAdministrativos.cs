using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_actosadministrativos", Schema="public")]
    public class DecVie_ActosAdministrativos
    {
        [Key]
        public int id_actoadministrativo { get; set; }
        public DateTime fechaexpedicion { get; set; }
        public int id_tipoactoadministrativo { get; set; }
        public string consecutivoactoadministrativo { get; set; }
        public string conconceptoasunto { get; set; }
        public int id_decvietipologia { get; set; }
        public int id_decviemacroproceso { get; set; }
        public int id_depend { get; set; }
        public string beneficiario { get; set; }
        public int dependenciafirma { get; set; }
        public int id_persona { get; set; }
        public int id_estadoactoadministrativo { get; set; }
        public string dependenciadocumento { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public string numidentificacion { get; set; }
        public DecVie_ActosAdministrativosTipo tipoactoadmi { get; set; }
        public DecVie_ActosAdministrativosEstado estadoacto { get; set; }
        public DecVie_Tipologia tipologiaactos { get; set; }
        public DecVie_Macroproceso macroprocesoactos{ get; set; }
        public Dependencia dependenciasolicitante { get; set; }        
        public Persona responsablesolicitud { get; set; }      

        [NotMapped]
         public string TipoActoAdmi
        {
            get
            {
                return (tipoactoadmi == null) ? "" : tipoactoadmi.nmidtipoactoadministrativo;
            }
        }
        [NotMapped]
        public string EstadoActoAdmi
        {
            get
            {
                return (estadoacto == null) ? "" : estadoacto.nmestadoactoadministrativo;
            }
        }
        [NotMapped]
        public string TipologiaActosAdmi
        {
            get
            {
                return (tipologiaactos == null) ? "" : tipologiaactos.nmdecvietipologia;
            }
        }
        [NotMapped]
        public string MacroprocesoaActosAdmi
        {
            get
            {
                return (macroprocesoactos == null) ? "" : macroprocesoactos.nmdecviemacroproceso;
            }
        }
        [NotMapped]
        public string SolicitanteActosAdmi
        {
            get
            {
                return (dependenciasolicitante == null) ? "" : dependenciasolicitante.nmdepend;
            }
        }
        
        [NotMapped]
        public string ResponsableSolicitudActoAdmi
        {
            get
            {
                return (responsablesolicitud == null) ? "" : responsablesolicitud.nombrecompleto;
            }
        }
       
    }
}