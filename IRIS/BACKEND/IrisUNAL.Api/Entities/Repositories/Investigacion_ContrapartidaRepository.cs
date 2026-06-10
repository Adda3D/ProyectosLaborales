using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Investigacion_ContrapartidaRepository : SuperType<Investigacion_Contrapartida>, IInvestigacion_ContrapartidaRepository
    {
        private ApplicationDbContext _context;

        public Investigacion_ContrapartidaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Investigacion_ContrapartidaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteInvestigacion_Contrapartida(int id_contrapartida)
        {
            Delete(id_contrapartida);
            return true;
        }

        public IEnumerable<Investigacion_Contrapartida> GetAllInvestigacion_Contrapartida()
        {
            return Get();
        }

        public IEnumerable<Investigacion_Contrapartida> GetInvestigacion_ContrapartidaCodigo(string cd_codigohermes)
        {
            return Get(c => c.codigohermes == cd_codigohermes);
        }

        public Investigacion_Contrapartida GetInvestigacion_ContrapartidaDetails(int id_contrapartida)
        {
            return Get(id_contrapartida);
        }

        public bool InsertInvestigacion_Contrapartida(Investigacion_Contrapartida investigacion_Contrapartida)
        {
            Add(investigacion_Contrapartida);
            return true;
        }

        public bool UpdateInvestigacion_Contrapartida(Investigacion_Contrapartida investigacion_Contrapartida)
        {
            Update(investigacion_Contrapartida);
            return true;
        }
    }
}