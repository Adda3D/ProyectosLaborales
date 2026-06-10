using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace IrisUNAL.Api.Models.Publicacion
{
    [Table("publicacionesexcel", Schema = "public")]
    public class PublicacionesExcel
    {
        public string id_kardex { get; set; }
        public int id_bodega { get; set; }
        public int total_ventas { get; set; }
        public int total_inventario { get; set; }
        public int unidades_vendidas { get; set; }
        public int inv_institucional { get; set; }
        public int inv_comercial { get; set; }
        public int ajustes { get; set; }

    }
}