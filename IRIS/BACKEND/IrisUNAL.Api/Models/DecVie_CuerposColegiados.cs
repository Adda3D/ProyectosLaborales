using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_cuerposcolegiados", Schema="public")]
    public class DecVie_CuerposColegiados
    {
        [Key]
        public int id_cuerposcolegiados { get; set; }
        public DateTime ano { get; set; }
        public DateTime fecha { get; set; }
        public string numacta { get; set; }        
        public int id_decviemacroproceso { get; set; }
        public string decisionrecomendacion { get; set; }
        public int id_depend { get; set; }
        public string chasqui { get; set; }
        public string numconsecutivosecretaria { get; set; }
        public string observaciones { get; set; }
        public string url { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public int id_colegiado { get; set; }
        public DecVie_Colegiados Objcolegiados { get; set; }
        public DecVie_Macroproceso Objmacroproceso { get; set; }
        public Dependencia Objdependencia { get; set; }

        [NotMapped]
        public string NombreColegiado
        {
            get
            {
                return (Objcolegiados == null) ? "" : Objcolegiados.nmcolegiado;
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
        public string NombreDependencia
        {
            get
            {
                return (Objdependencia == null) ? "" : Objdependencia.nmdepend;
            }
        }
    }
}