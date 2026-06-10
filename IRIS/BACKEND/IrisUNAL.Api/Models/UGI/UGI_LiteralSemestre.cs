using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.UGI
{
    [Table("ugi_literalsemestre", Schema="public")]
    public class UGI_LiteralSemestre
    {
        [Key]
        public int id_ugiliteralsemestre { get; set; }
        public int id_ugisemestre { get; set; }
        public int id_literal { get; set; }
        public long? valorproyectado { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public UGI_Semestre Objugisemestre { get; set; }
        public Literal_UGI Objliteral { get; set; }

        [NotMapped]
        public string NombreSemestre
        {
            get
            {
                return (Objugisemestre == null) ? "" : Objugisemestre.Objsemestre.nmsemestre;
            }
        }

        [NotMapped]
        public string NombreLiteral
        {
            get
            {
                return (Objliteral == null) ? "" : Objliteral.nmliteral;
            }
        }
    }
}