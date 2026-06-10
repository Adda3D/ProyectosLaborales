using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.DTO
{
    public class PublicacionInventarioDTO
    {
        public int id_crearpublicacion { get; set; }
        public int ejemplaresinstitucional { get; set; }
        public int ejemplarescomercializa { get; set; }
        public int ejemplaresinmovil { get; set; }
        public int mvtoinstitucional { get; set; }
        public int ajusteins { get; set; }
        public int mvtocomercial { get; set; }
        public int ajustecomercial { get; set; }
        public int ajusteinmovil { get; set; }
        public int unidadesvendidas { get; set; }
        public int? invinamovible { get; set; }
        public int? invinstitucional { get; set; }
        public int? invcomercial { get; set; }
        public int? invterceros { get; set; }

    }
}