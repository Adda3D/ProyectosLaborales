using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.DTO
{
    public class DecVie_CicloFinancieroPostProgramFacultadDTO
    {
        public int id_postprogram { get; set; }
        public int? graduadosbogota { get; set; }
        public int? graduadosconvenio { get; set; }
    }
}