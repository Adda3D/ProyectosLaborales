using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_ciclofinancieropostprogram", Schema="public")]
    public class DecVie_CicloFinancieroPostProgram
    {
        [Key]
        public int id_postprogram { get; set; }        
        public int id_programapostgrado { get; set; }        
        public int id_ciclofinanciero { get; set; }
        public int? costosemprog { get; set; }
        public int? cupos { get; set; }
        public int? inscritos { get; set; }
        public int? admitidos { get; set; }
        public int? matriculados { get; set; }
        public int? aplazados { get; set; }
        public int? numestudiantes { get; set; }
        public int? porcentaje { get; set; }
        public int? valor { get; set; }
        public int? costosemconvenio { get; set; }
        public int? cuposconvenio { get; set; }
        public int? inscritosconvenio { get; set; }
        public int? admitidosconvenio { get; set; }
        public int? matriculadosconvenio { get; set; }
        public int? aplazadosconvenio { get; set; }
        public int? numestudiantesconvenio { get; set; }
        public int? porcentajeconvenio { get; set; }
        public int? valorconvenio { get; set; }
        public int? graduadosbogota { get; set; }
        public int? graduadosconvenio { get; set; }
        public int? recaudobogota { get; set; }
        public int? recaudoconvenio { get; set; }
        public int? porcentajeugi { get; set; }
        public int? porcentajederadmtvos { get; set; }
        public string facultaddsps { get; set; }
        public int? total { get; set; }
        public int? porcentajeugiconvenio { get; set; }
        public int? porcentajederadmtvosconvenio { get; set; }
        public int? trasladoistconvenio { get; set; }
        public string facultaddspsconvenio { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Decvie_CicloFinancieroProgramaPostgrado Objprogramapostgrado { get; set; }
        public Decvie_CicloFinanciero Objciclofinanciero { get; set; }


        // Nuevo campo idfuncionario
        public int idfuncionario { get; set; }

        // Nuevo campo id_numeroplan
        public string id_numeroplan { get; set; }


        [NotMapped]
        public string NombreSemestreCiclofinanciero
        {
            get
            {
                return (Objciclofinanciero == null) ? "" : Objciclofinanciero.Objsemestre.nmsemestre;
            }
        }

        [NotMapped]
        public string NombreProgramaPostgrado
        {
            get
            {
                return (Objprogramapostgrado == null) ? "" : Objprogramapostgrado.nmprogramapostgrado;
            }
        }
    }
}