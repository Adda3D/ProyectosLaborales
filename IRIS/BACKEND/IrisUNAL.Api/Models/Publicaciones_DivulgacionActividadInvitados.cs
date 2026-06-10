using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_divulgacionactividadinvitados", Schema= "public")]
    public class Publicaciones_DivulgacionActividadInvitados
    {
        [Key]
        public int id_invitados { get; set; }
        public int id_crearpublicacion { get; set; }
        public string nombrecompleto { get; set; }
        public string institucion { get; set; }
        public string nalointer { get; set; }
        public string perfil { get; set; }                
        public string telefono { get; set; }
        public string email { get; set; }
        public bool divulgacionfoto { get; set; }
        public bool divulgacionnombre { get; set; }
        public bool divulgacionperfil { get; set; }
        public bool? agradecimientoevento { get; set; }
        public string agradecimientonotas { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }

        [NotMapped]
        public string Notasdt
        {
            get
            {
                return (agradecimientonotas == null) ? "" : (agradecimientonotas.Length > 89) ? String.Concat(agradecimientonotas.Substring(0, 90), " ...") : agradecimientonotas;
            }
        }

    }
}