using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_depositodistribucioncomercial", Schema="public")]
    public class Publicaciones_DepositoDistribucionComercial
    {
        [Key]
        public int id_distribucioncomercial { get; set; }
        public int id_crearpublicacion { get; set; }
        public int iddistribuidor { get; set; }
        public DateTime fechaentrega { get; set; }
        public int cantidad { get; set; }
        public string notas { get; set; }
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

        [NotMapped]
        public string notasdt
        {
            get
            {
                return (notas == null) ? "" : (notas.Length > 59) ? String.Concat(notas.Substring(0, 60), " ...") : notas;
            }
        }

    }
}