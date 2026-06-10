using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_divulgacionherramienta", Schema="public")]
    public class Publicaciones_DivulgacionHerramienta
    {
        [Key]
        public int id_herramienta { get; set; }
        public int id_crearpublicacion { get; set; }
        public int id_tipomedio { get; set; }
        public string nombre { get; set; }
        public string lugar { get; set; }
        public DateTime fecha { get; set; }
        public string enlace { get; set; }
        public int? numeroenvios { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }

        public Publicaciones_DivulgacionTipoMedio ObjTipo { get; set; }

        [NotMapped]
        public string NombreTipo
        {
            get
            {
                return (ObjTipo == null) ? "" : ObjTipo.nmtipomedio;
            }
        }

        [NotMapped]
        public string Observacionesdt
        {
            get
            {
                return (observaciones == null) ? "" : (observaciones.Length > 59) ? observaciones.Substring(0, 60) + "... " : observaciones;
            }
        }

    }
}