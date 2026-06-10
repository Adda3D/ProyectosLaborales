using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("decvie_matryoshkaprogramapgd", Schema="public")]
    public class Decvie_MatryoshkaProgramaPgd
    {
        [Key]
        public int id_matryoshkaprogramapgd { get; set; }
        public int id_matryoska { get; set; }
        public int id_programapgd { get; set; }
        public string observaciones { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Decvie_Matryoshka Objmatryoshka { get; set; }
        public DecVie_PlanAccionProgramaPgd Objprogramapgd { get; set; }

        [NotMapped]
        public string AlcanceMatryoshka
        {
            get
            {
                return (Objmatryoshka == null) ? "" : Objmatryoshka.alcance;
            }
        }

        [NotMapped]
        public string NombreProgramaPGD
        {
            get
            {
                return (Objprogramapgd == null) ? "" : Objprogramapgd.nmprogramapgd;
            }
        }

        [NotMapped]
        public string DescripcionProgramaPGD
        {
            get
            {
                return (Objprogramapgd == null) ? "" : Objprogramapgd.descripcionprogramapgd;
            }
        }
    }
}