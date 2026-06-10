using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.DTO
{
    public class UGI_SemestreDTO
    {
        public int id_ugisemestre { get; set; }
        public string numresolucion { get; set; }
        public DateTime fecresolucion { get; set; }
        public string nmsemestre { get; set; }
        public string nmliteral { get; set; }
        public string grupoproducto { get; set; }
        public string concepto { get; set; }
        public int? valorproyectado { get; set; }
        public int? valortotalsemestre { get; set; }
        public string observaciones { get; set; }
    }
}