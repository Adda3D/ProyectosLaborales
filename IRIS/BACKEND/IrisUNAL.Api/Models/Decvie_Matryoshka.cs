using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_matryoshka", Schema = "public")]
    public class Decvie_Matryoshka
    {
        [Key]
        public int id_matryoska { get; set; }
        public int id_depend { get; set; }
        public string alcance { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Dependencia ObjDependencia { get; set; }

        [NotMapped]
        public string NombreDependencia
        {
            get
            {
                return (ObjDependencia == null) ? "" : ObjDependencia.nmdepend;
            }
        }

    }
}