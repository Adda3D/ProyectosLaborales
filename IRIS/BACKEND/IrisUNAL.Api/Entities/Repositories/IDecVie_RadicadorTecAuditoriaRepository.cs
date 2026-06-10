using System.Collections.Generic;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_RadicadorTecAuditoriaRepository
    {
        IEnumerable<DecVie_RadicadorTecAuditoriaDTO> GetHistorialByRadicador(int id_decvieradicadortec);
        // Aquí irán otros métodos si los necesitas después (Insert, etc)
        bool InsertAuditoria(DecVie_RadicadorTecAuditoria auditoria);

    }
}
