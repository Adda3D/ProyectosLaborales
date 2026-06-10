using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.DTO
{
    public class DecVie_CicloFinancieroPostProgramBogotaDTO
    {
        public int id_postprogram { get; set; }
        public int? costosemprog { get; set; }
        public int? cupos { get; set; }
        public int? inscritos { get; set; }
        public int? admitidos { get; set; }
        public int? matriculados { get; set; }
        public int? aplazados { get; set; }
        public int? numestudiantes { get; set; }
        public int? porcentaje { get; set; }
        public int? valor { get; set; }

    }
}