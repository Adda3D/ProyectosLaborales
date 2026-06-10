using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_deposito", Schema="public")]
    public class Publicaciones_Deposito
    {
        [Key]
        public int id_deposito { get; set; }
        public int id_formatodis { get; set; }
        public string id_kardex { get; set; }
        public int id_tipopub { get; set; }
        public DateTime fecpublicacion { get; set; }
        public string numedicion { get; set; }
        public bool reimpresion { get; set; }
        public int id_tipomov { get; set; }
        public int cantidad { get; set; }
        public int id_resolucion { get; set; }
        public int id_precios { get; set; }
        public int id_distribucion { get; set; }
        public int id_distribucioncomercial { get; set; }
        public int id_otrosdistribuidores { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }

    }
}