using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.DTO
{
    public class Decvie_MatryoshkaDTO
    {
        public int id_matryoska { get; set; }
        public string nmdepend { get; set; }
        public string alcance { get; set; }
        public string ejeestrategico { get; set; }
        public string nmprogramapgd { get; set; }
        public string descripcionprogramapgd { get; set; }
        public string estrategia { get; set; }
        public string nmobjetivopgdvrisede { get; set; }
        public string nmobjetivodependencia { get; set; }
        public string nmmeta { get; set; }
        public string nmactividad { get; set; }
        public string nmindicadoresestrategicos { get; set; }
        public string nmnuevosindicadores { get; set; }
        public string nmtipoindicador { get; set; }
        public string descripcion { get; set; }
        public int? presupuesto { get; set; }
        public string ejecucion { get; set; }

    }
}