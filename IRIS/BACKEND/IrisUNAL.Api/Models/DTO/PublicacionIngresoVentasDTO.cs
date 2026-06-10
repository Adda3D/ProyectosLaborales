using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.DTO
{
    public class PublicacionIngresoVentasDTO
    {
        public int unidades { get; set; }
        public int ventas { get; set; }
        public int comision { get; set; }
        public int neto { get; set; }
        public decimal costounitario { get; set; }
        public decimal ingresounitario { get; set; }
        public decimal margenvalor { get; set; }
        public decimal margenporcentaje { get; set; }

    }
}