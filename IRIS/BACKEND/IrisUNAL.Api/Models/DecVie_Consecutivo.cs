using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_consecutivo", Schema="public")]
    public class DecVie_Consecutivo
    {
        [Key]
        public int id_decvieconsecutivo { get; set; }
        public string numconsecutivo { get; set; }
        public string tsersubserdocu { get; set; }
        public string asunto { get; set; }
        public int idfuncionario { get; set; }
        public int id_depend { get; set; }
        public bool interno { get; set; }
        public bool externo { get; set; }
        public int id_decvieconcepto { get; set; }
        public int dirigidoa { get; set; }
        public int id_decviemacroproceso { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public int id_prefijoconsecutivo { get; set; }
        public DateTime fecha { get; set; }
        public int dependenciadestino { get; set; }
        public Funcionario ObjFuncionario { get; set; }
        public Dependencia ObjDependencia { get; set; }
        public DecVie_Concepto ObjDecVieConcepto { get; set; }
        public DecVie_Macroproceso ObjMacroproceso { get; set; }   
        public Correspondencia_PrefijoConsecutivo Objprefijo { get; set; }

        [NotMapped]
        public string NombrePrefijo
        {
            get
            {
                return (Objprefijo == null) ? "" : Objprefijo.nmprefijo;
            }
        }

        [NotMapped]
        public string NombreResponsable
        {
            get
            {
                return (ObjFuncionario == null) ? "" : ObjFuncionario.nombrecompleto;
            }
        }

        [NotMapped]
        public string DependenciaEmite
        {
            get
            {
                return (ObjDependencia == null) ? "" : ObjDependencia.nmdepend;
            }
        }

        [NotMapped]
        public string NombreConcepto
        {
            get
            {
                return (ObjDecVieConcepto == null) ? "" : ObjDecVieConcepto.nmconcepto;
            }
        }
        [NotMapped]
        public string NombreMacroproceso
        {
            get
            {
                return (ObjMacroproceso == null) ? "" : ObjMacroproceso.nmdecviemacroproceso;
            }
        }
    }
}