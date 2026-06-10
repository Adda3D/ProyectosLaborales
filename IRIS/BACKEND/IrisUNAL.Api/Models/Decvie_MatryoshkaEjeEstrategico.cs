using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_matryoshkaejeestrategico", Schema = "public")]
    public class Decvie_MatryoshkaEjeEstrategico
    {
        [Key]
        public int id_matryoshkaejeestrategico { get; set; }
        public int id_matryoska { get; set; }
        public int id_ejeestrategico { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }        
        public Decvie_Matryoshka Objmatryoshka { get; set; }
        public DecVie_PlanAccionEjeEstrategico Objejeestrategico { get; set; }
                

        [NotMapped]
        public string NombreAlcance
        {
            get
            {
                return (Objmatryoshka == null) ? "" : Objmatryoshka.alcance;
            }
        }

        [NotMapped]
        public string NombreEjeestrategico
        {
            get
            {
                return (Objejeestrategico == null) ? "" : Objejeestrategico.ejeestrategico;
            }
        }

        [NotMapped]
        public string DescripcionEje
        {
            get
            {
                return (Objejeestrategico == null) ? "" : Objejeestrategico.descripcionejeestrategico;
            }
        }
    }
}