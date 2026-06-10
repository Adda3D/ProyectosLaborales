using System;

namespace IrisUNAL.Api.Models.DTO
{
    public class DecVie_RadicadorTecAuditoriaDTO
    {
        public int id_auditoria { get; set; }
        public int id_decvieradicadortec { get; set; }
        public string tipo_cambio { get; set; }
        public string valor_nuevo { get; set; }
        public string usuario { get; set; }
        public DateTime fecha_cambio { get; set; }
    }

}
