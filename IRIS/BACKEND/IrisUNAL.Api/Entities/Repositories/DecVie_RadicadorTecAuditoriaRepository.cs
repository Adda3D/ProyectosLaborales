using System.Collections.Generic;
using System.Linq;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class DecVie_RadicadorTecAuditoriaRepository : IDecVie_RadicadorTecAuditoriaRepository
    {
        private readonly ApplicationDbContext _context;

        public DecVie_RadicadorTecAuditoriaRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<DecVie_RadicadorTecAuditoriaDTO> GetHistorialByRadicador(int id_decvieradicadortec)
        {
            var historial = _context.decvie_radicadortec_auditoria
                .Where(x => x.id_decvieradicadortec == id_decvieradicadortec)
                .OrderBy(x => x.fecha_cambio)
                .Select(x => new DecVie_RadicadorTecAuditoriaDTO
                {
                    id_auditoria = x.id_auditoria,
                    id_decvieradicadortec = x.id_decvieradicadortec,
                    tipo_cambio = x.tipo_cambio,
                    valor_nuevo = x.valor_nuevo,
                    usuario = x.usuario,
                    fecha_cambio = x.fecha_cambio
                })
                .ToList();

            return historial;
        }

        public bool InsertAuditoria(DecVie_RadicadorTecAuditoria auditoria)
        {
            _context.decvie_radicadortec_auditoria.Add(auditoria);
            return _context.SaveChanges() > 0;
        }

    }
}
