using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IrisUNAL.Api.Models
{
    [Table("certificados_solicitud_trazabilidad", Schema = "public")]
    public class Solicitud_CertificadoTrazabilidad
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("certificado_id")]
        public int CertificadoId { get; set; }

        [Column("solicitud_id")]
        public int SolicitudId { get; set; }

        [Column("numero_radicado")]
        public string NumeroRadicado { get; set; }

        [Column("fecha_radicado")]
        public DateTime FechaRadicado { get; set; }

        [Column("correo_electronico")]
        public string CorreoElectronico { get; set; }

        [Column("procedencia")]
        public string Procedencia { get; set; }

        [Column("tipo_dni")]
        public string TipoDni { get; set; }

        [Column("numero_dni")]
        public string NumeroDni { get; set; }

        [Column("asunto")]
        public string Asunto { get; set; }

        [Column("dirigido_a")]
        public string DirigidoA { get; set; }

        [Column("pago")]
        public string Pago { get; set; } = "En verificación";

        [Column("estado")]
        public string Estado { get; set; } = "En Verificación de Pago";

        [Column("fecha_verificacion_pago")]
        public DateTime? FechaVerificacionPago { get; set; }

        [Column("fecha_expedicion")]
        public DateTime? FechaExpedicion { get; set; }

        [Column("fecha_firma")]
        public DateTime? FechaFirma { get; set; }

        [Column("fecha_envio_usuario")]
        public DateTime? FechaEnvioUsuario { get; set; }

        [Column("comprobante_pago")]
        public string ComprobantePago { get; set; }

        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Column("fecha_actualizacion")]
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;

        [Column("observaciones")]
        public string Observaciones { get; set; }

        [Column("comentarios")]
        public string Comentarios { get; set; }


    }
}
