using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_HermesRepository : SuperType<Publicaciones_Hermes>, IPublicaciones_HermesRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_HermesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_HermesRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_Hermes(int id_hermes)
        {
            Delete(id_hermes);
                return true;
        }

        public IEnumerable<Publicaciones_Hermes> GetAllPublicaciones_Hermes()
        {
            return Get();
        }

        public Publicaciones_Hermes GetPublicaciones_HermesDetails(int id_hermes)
        {
            return Get(id_hermes);
        }

        public IEnumerable<Publicaciones_Hermes> GetPublicaciones_HermesNumero(string cd_numhermes)
        {
            return Get(c => c.numhermes == cd_numhermes);
        }

        public bool InsertPublicaciones_Hermes(Publicaciones_Hermes publicaciones_Hermes)
        {
            Add(publicaciones_Hermes);
            return true;
        }

        public bool UpdatePublicaciones_Hermes(Publicaciones_Hermes publicaciones_Hermes)
        {
            Update(publicaciones_Hermes);
            return true;
        }
    }
}