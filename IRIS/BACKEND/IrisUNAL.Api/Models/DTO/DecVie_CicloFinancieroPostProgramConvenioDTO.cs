using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.DTO
{
    public class DecVie_CicloFinancieroPostProgramConvenioDTO
    {
        public int id_postprogram { get; set; }
        public int? costosemconvenio { get; set; }
        public int? cuposconvenio { get; set; }
        public int? inscritosconvenio { get; set; }
        public int? admitidosconvenio { get; set; }
        public int? matriculadosconvenio { get; set; }
        public int? aplazadosconvenio { get; set; }
        public int? numestudiantesconvenio { get; set; }
        public int? porcentajeconvenio { get; set; }
        public int? valorconvenio { get; set; }
    }
}