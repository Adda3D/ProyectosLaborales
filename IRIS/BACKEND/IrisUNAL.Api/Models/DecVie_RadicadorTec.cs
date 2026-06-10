using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_radicadortec", Schema = "public")]
    public class DecVie_RadicadorTec
    {
        [Key]
        public int id_decvieradicadortec { get; set; }
        public string numradicadortec { get; set; }
        public string tsersubserdocu { get; set; }
        public string asunto { get; set; }
        public int idfuncionario { get; set; }
        public int id_depend { get; set; }
        public bool interno { get; set; }
        public bool externo { get; set; }
        public string id_decvieconcepto { get; set; }
        //public int dirigidoa { get; set; }
        public string id_decviemacroproceso { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public int id_prefijoconsecutivo { get; set; }
        public DateTime fecha { get; set; }
        public int dependenciadestino { get; set; }
        public int nfolios { get; set; }
        public string otroasunto { get; set; }
        public string dni { get; set; }
        public string personasrelacionadas { get; set; }
        public DateTime? recibido_dependencia { get; set; }
        public DateTime? fecha_vencimiento { get; set; }
        public DateTime? fecha_respuesta { get; set; }

        public Funcionario ObjFuncionario { get; set; }

        [ForeignKey("id_depend")]
        public Dependencia ObjDependencia { get; set; }
        public Correspondencia_PrefijoConsecutivo Objprefijo { get; set; }

        [ForeignKey("dependenciadestino")]
        public Dependencia ObjDependenciaDestino { get; set; } 


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



    }
}
