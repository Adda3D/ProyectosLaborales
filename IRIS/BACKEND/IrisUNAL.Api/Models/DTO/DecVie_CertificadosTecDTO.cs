using System;

namespace IrisUNAL.Api.Models.DTO
{
    public class DecVie_CertificadosTecDTO
    {
        public int id_decviecertificadostec { get; set; } // ID del registro
        public DateTime fecha { get; set; } // Fecha de la solicitud
        public string numcertificadotec { get; set; } // Número del certificado
        public string asunto { get; set; } // Asunto
        public string tsersubserdocu { get; set; } // Solicitante
        public string usuariocreacion { get; set; } // Usuario creador
        public string NombreDependencia { get; set; } // Dependencia (Destino)
        public string estado_pago { get; set; } // Estado del pago (PAGADO/NO PAGADO)
        public string id_certificado_tipo { get; set; } // Tipo (PREGRADO/POSTGRADO)
        public string tipo { get; set; } // Tipo (certificado/verificacion)
    }
}
