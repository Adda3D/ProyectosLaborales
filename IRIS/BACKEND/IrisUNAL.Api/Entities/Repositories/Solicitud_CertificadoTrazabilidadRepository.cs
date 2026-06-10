using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;  

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Solicitud_CertificadoTrazabilidadRepository
    : SuperType<Solicitud_CertificadoTrazabilidad>, ISolicitud_CertificadoTrazabilidadRepository

    {
        private readonly ApplicationDbContext _context;

        public Solicitud_CertificadoTrazabilidadRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Solicitud_CertificadoTrazabilidad> GetAllSolicitud_CertificadoTrazabilidad()
        {
            return _context.certificados_solicitud_trazabilidad
                .OrderByDescending(x => x.FechaRadicado)
                .ToList();
        }

        public Solicitud_CertificadoTrazabilidad GetSolicitud_CertificadoTrazabilidadById(int id)
        {
            return _context.certificados_solicitud_trazabilidad
                .FirstOrDefault(x => x.Id == id);
        }

        public void InsertSolicitud_CertificadoTrazabilidad(Solicitud_CertificadoTrazabilidad entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            entity.FechaCreacion = DateTime.Now;
            entity.FechaActualizacion = DateTime.Now;

            _context.certificados_solicitud_trazabilidad.Add(entity);
            _context.SaveChanges();
        }

        public void UpdateSolicitud_CertificadoTrazabilidad(Solicitud_CertificadoTrazabilidad trazabilidad)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var entity = context.certificados_solicitud_trazabilidad
                        .FirstOrDefault(x => x.Id == trazabilidad.Id);

                    if (entity == null)
                        throw new Exception("No se encontró el registro de trazabilidad especificado.");

                    // Actualiza los campos editables
                    entity.Pago = trazabilidad.Pago;
                    entity.Estado = trazabilidad.Estado;
                    entity.Comentarios = trazabilidad.Comentarios;
                    entity.FechaActualizacion = DateTime.Now;

                    // Actualiza la fecha correspondiente según el nuevo estado
                    switch (trazabilidad.Estado)
                    {
                        case "En Verificación de Pago":
                            entity.FechaVerificacionPago = DateTime.Now;
                            break;

                        case "En Proceso de Expedición":
                            entity.FechaExpedicion = DateTime.Now;
                            break;

                        case "En Proceso de Firma":
                            entity.FechaFirma = DateTime.Now;
                            break;

                        case "Enviado al usuario":
                            entity.FechaEnvioUsuario = DateTime.Now;
                            break;
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la trazabilidad del certificado: " + ex.Message);
            }
        }


        public void DeleteSolicitud_CertificadoTrazabilidad(int id)
        {
            var entity = _context.certificados_solicitud_trazabilidad.Find(id);
            if (entity != null)
            {
                _context.certificados_solicitud_trazabilidad.Remove(entity);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Sincroniza los registros desde certificados_radicador_solicitud y certificados_radicador_certificadoindividual.
        /// Solo insertará los registros que aún no existan.
        /// </summary>
        public void SyncTrazabilidad()
        {
            try
            {
                string sql = @"
                    INSERT INTO public.certificados_solicitud_trazabilidad
                    (
                        certificado_id,
                        solicitud_id,
                        numero_radicado,
                        fecha_radicado,
                        correo_electronico,
                        procedencia,
                        tipo_dni,
                        numero_dni,
                        asunto,
                        dirigido_a,
                        pago,
                        estado,
                        comprobante_pago,
                        observaciones, 
                        fecha_creacion,
                        fecha_actualizacion
                    )
                    SELECT 
                        c.id AS certificado_id,
                        s.id AS solicitud_id,
                        c.radicado AS numero_radicado,
                        s.fecha_creacion AS fecha_radicado,
                        s.correo_personal AS correo_electronico,
                        s.nombre_completo AS procedencia,
                        s.tipo_documento AS tipo_dni,
                        s.numero_documento AS numero_dni,
                        CONCAT(c.radicado, ' - Solicitud de Certificado ', c.tipo_certificado, ' (', c.tipo_usuario, ')') AS asunto,
                        c.ambito AS dirigido_a,
                        'En verificación' AS pago,
                        'En Verificación de Pago' AS estado,
                        s.comprobante_pago AS comprobante_pago,
                        c.observaciones, 
                        NOW() AS fecha_creacion,
                        NOW() AS fecha_actualizacion
                    FROM public.certificados_radicador_solicitud s
                    INNER JOIN public.certificados_radicador_certificadoindividual c 
                        ON c.solicitud_id = s.id
                    WHERE NOT EXISTS (
                        SELECT 1 
                        FROM public.certificados_solicitud_trazabilidad t
                        WHERE t.certificado_id = c.id
                    );";

                _context.Database.ExecuteSqlCommand(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al sincronizar la trazabilidad de certificados: " + ex.Message);
            }
        }
    }
}
