using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.DTO
{
    public class DecVie_InventarioGestionConocimientoDTO
    {
        public int id_invgesconocimiento { get; set; }        
        public string nmsoporte { get; set; }
        public string vigencia { get; set; }        
        public string nmtipologia { get; set; }        
        public string nmenfasis { get; set; }        
        public string razonsocial { get; set; }
        public string beneficiarios { get; set; }        
        public string nmimpacto { get; set; }        
        public string nmpatentetipo { get; set; }
        public string vigenciapatente { get; set; }
        public string entidadpatente { get; set; }
        public long gastos { get; set; }
        public long costodirecto { get; set; }
        public long total { get; set; }        
        public string nminsumo { get; set; }        
        public string nmahorro { get; set; }        
        public string nmconcepto { get; set; }
        public int presupuestoejecutado { get; set; }
        public int designadogestion { get; set; }
        public DateTime? fechavaloracion { get; set; }
    }
}