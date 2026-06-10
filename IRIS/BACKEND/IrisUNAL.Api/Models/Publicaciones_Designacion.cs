using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_designacion", Schema="public")]
    public class Publicaciones_Designacion
    {
        [Key]
        public int id_designacion { get; set; }
        public int id_crearpublicacion { get; set; }
        public string nmcontratacion { get; set; }
        public int id_tipologia { get; set; }
        public int id_persona { get; set; }
        public int? numpagos { get; set; }
        public DateTime? fecinicio { get; set; }
        public DateTime? fecfin { get; set; }
        public string orpa1 { get; set; }
        public DateTime? fecpagopar { get; set; }
        public string orpa2 { get; set; }
        public DateTime? fecpagofinal { get; set; }
        public string quipu { get; set; }
        public int id_tipodiagramacion { get; set; }        
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Persona ObjPersona { get; set; }
        public Publicaciones_Tipologia ObjTipologia { get; set; }

        [NotMapped]
        public string NombreContratista
        {
            get
            {
                return (ObjPersona == null) ? "" : ObjPersona.nombrecompleto;
            }
        }

        [NotMapped]
        public string NombreTipo
        {
            get
            {
                return (ObjTipologia == null) ? "" : ObjTipologia.nmtipologia;
            }
        }
    }
}