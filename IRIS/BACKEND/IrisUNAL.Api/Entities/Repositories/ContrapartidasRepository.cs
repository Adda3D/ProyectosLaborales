using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class ContrapartidasRepository : SuperType<Contrapartidas>, IContrapartidasRepository
    {
        private ApplicationDbContext _context;

        public ContrapartidasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ContrapartidasRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteContrapartidas(int id_contrapartidas)
        {
            Delete(id_contrapartidas);
            return true;
        }

        public IEnumerable<Contrapartidas> GetAllContrapartidas()
        {
            return Get();
        }

        public Contrapartidas GetContrapartidasDetails(int id_contrapartidas)
        {
            return Get(id_contrapartidas);
        }

        public bool InsertContrapartidas(Contrapartidas contrapartidas)
        {
            Add(contrapartidas);
            return true;
        }

        public bool UpdateContrapartidas(Contrapartidas contrapartidas)
        {
            Update(contrapartidas);
            return true;
        }
    }
}