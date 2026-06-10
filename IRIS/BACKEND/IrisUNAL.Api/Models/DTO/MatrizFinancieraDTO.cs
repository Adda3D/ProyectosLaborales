using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.DTO
{
    public class MatrizFinancieraDTO
    {
        public int id_matrizfinanciera { get; set; }
        public string nmvigencia { get; set; }
        public string nmdepend { get; set; }
        public long presupuestogeneral { get; set; }
        public long presupuestogeneralcomprometido { get; set; }
        public long presupuestogeneralcomprometer { get; set; }
        public long presupuestougi { get; set; }
        public long presupuestougicomprometido { get; set; }
        public long presupuestougicomprometer { get; set; }
        public long presupuestoestudiantes { get; set; }
        public long presupuestoestudiantescomprometido { get; set; }
        public long presupuestoestudiantescomprometer { get; set; }
        public int id_gastoapoyo { get; set; }        
        public int? especializado { get; set; }
        public int? profesional { get; set; }
        public int? tecnico { get; set; }
        public int? asistencial { get; set; }
        public int? totalpersonascontratadas { get; set; }
        public int valortotal { get; set; }
        public string observaciones { get; set; }
        public int id_gastooperativo { get; set; }
        public int id_tipooperativo { get; set; }
        public string nmtipooperativo { get; set; }
    }
}