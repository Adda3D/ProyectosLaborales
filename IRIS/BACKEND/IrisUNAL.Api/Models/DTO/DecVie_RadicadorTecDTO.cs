using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Models.DTO
{
    public class DecVie_RadicadorTecDTO
    {
            public int id_decvieradicadortec { get; set; }
            public DateTime fecha { get; set; }
            public string numradicadortec { get; set; }
            public string asunto { get; set; }
            public string tsersubserdocu { get; set; }
            public string usuariocreacion { get; set; }
            public string NombreDependencia { get; set; }
            public DateTime? fecha_vencimiento { get; set; }
            public string id_decviemacroproceso { get; set; }
    }
}
