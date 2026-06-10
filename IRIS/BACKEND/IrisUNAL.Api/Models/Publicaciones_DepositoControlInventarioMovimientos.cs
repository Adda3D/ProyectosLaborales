using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models
{
    [Table("publicaciones_depositocontrolinventariomovimientos", Schema="public")]
    public class Publicaciones_DepositoControlInventarioMovimientos
    {
        [Key]
        public int id_movimientos { get; set; }
        public int id_crearpublicacion { get; set; }        
        public int id_bodega { get; set; }
        public int id_tipomov { get; set; }
        public string descripcion { get; set; }        
        public DateTime fecha { get; set; }
        public int cantidad { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public string usuarioactualizacion { get; set; }
        public bool activo { get; set; }
        public Publicaciones_CrearPublicacion ObjPublicacion { get; set; }
        public Publicaciones_DepositoControlInventarioBodega ObjBodega { get; set; }
        public Publicaciones_DepositoTipoMov ObjTipoMov { get; set; }

        [NotMapped]
        public string NombreBodega
        {
            get
            {
                return (ObjBodega == null) ? "" : ObjBodega.nmbodega;
            }
        }

        [NotMapped]
        public string TipoMovimiento
        {
            get
            {
                return (ObjTipoMov == null) ? "" : ObjTipoMov.nmtipomov;
            }
        }

        [NotMapped]
        public string descripciondt
        {
            get
            {
                return (descripcion == null) ? "" : (descripcion.Length > 59) ? String.Concat(descripcion.Substring(0, 60), " ...") : descripcion;
            }
        }

    }
}