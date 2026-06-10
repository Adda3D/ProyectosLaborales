using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_certificadostec", Schema = "public")]
    public class DecVie_CertificadosTec
    {
        [Key]
        public int id_decviecertificadostec { get; set; }
        public int id_prefijoconsecutivo { get; set; }
        public string numcertificadotec { get; set; }
        public string tsersubserdocu { get; set; }
        public string asunto { get; set; }
        public int idfuncionario { get; set; }
        public int id_depend { get; set; }
        public string tipo { get; set; } // si es certificado o verificacion
        public string id_certificado_tipo { get; set; } // Nuevo: Tipo (PREGRADO, POSTGRADO, etc.)
        public string estado_pago { get; set; } // Nuevo: Estado Pago (NO PAGO, PAGADO)
        public string dni { get; set; }
        public string observaciones { get; set; }
        public DateTime fecha { get; set; }
        public DateTime? recibido_dependencia { get; set; }
        public DateTime? fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }        
        public int? dependenciadestino { get; set; } 

        [ForeignKey("dependenciadestino")] 
        public Dependencia ObjDependenciaDestino { get; set; } 

        public Funcionario ObjFuncionario { get; set; }

        [ForeignKey("id_depend")]
        public Dependencia ObjDependencia { get; set; }


        [ForeignKey("id_prefijoconsecutivo")]
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
        public string NombreTipoCertificado
        {
            get
            {
                return id_certificado_tipo ?? "";
            }
        }

        [NotMapped]
        public string EstadoPago
        {
            get
            {
                return estado_pago ?? "";
            }
        }

        [NotMapped]
        public string TipoCertificado
        {
            get
            {
                return tipo ?? "";
            }
        }
    }
}
