using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_depositocontrolrepventas", Schema="public")]
    public class Publicaciones_DepositoControlRepVentas
    {
        [Key]
        public int id_repventas { get; set; }
        public int id_crearpublicacion { get; set; }
        public int iddistribuidor { get; set; }
        public int unidadesvendidas { get; set; }
        public int valorventas { get; set; }
        public int valorcomision { get; set; }
        public DateTime fecreporte { get; set; }
        public bool revisado { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Publicaciones_CrearPublicacion ObjPublicacion { get; set; }
        public Publicaciones_Distribuidor ObjDistribuidor { get; set; }

        [NotMapped]
        public string NombreDistribuidor
        {
            get
            {
                return (ObjDistribuidor == null) ? "" : ObjDistribuidor.distribuidor;
            }
        }

    }
}