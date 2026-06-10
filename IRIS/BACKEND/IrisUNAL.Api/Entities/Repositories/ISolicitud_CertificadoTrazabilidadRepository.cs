using System.Collections.Generic;
using IrisUNAL.Api.Models;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface ISolicitud_CertificadoTrazabilidadRepository
    {
        IEnumerable<Solicitud_CertificadoTrazabilidad> GetAllSolicitud_CertificadoTrazabilidad();
        Solicitud_CertificadoTrazabilidad GetSolicitud_CertificadoTrazabilidadById(int id);
        void InsertSolicitud_CertificadoTrazabilidad(Solicitud_CertificadoTrazabilidad entity);
        void UpdateSolicitud_CertificadoTrazabilidad(Solicitud_CertificadoTrazabilidad entity);
        void DeleteSolicitud_CertificadoTrazabilidad(int id);
        void SyncTrazabilidad();
    }
}
