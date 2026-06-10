using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_ResponsableRepository : SuperType<Publicaciones_Responsable>, IPublicaciones_ResponsableRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_ResponsableRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_ResponsableRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_Responsable(int id_responsable)
        {
            Delete(id_responsable);
            return true;
        }

        public IEnumerable<Publicaciones_Responsable> GetAllPublicaciones_Responsable()
        {
            return Get();
        }

        public Publicaciones_Responsable GetPublicaciones_ResponsableDetails(int id_responsable)
        {
            return Get(id_responsable);
        }

        public bool InsertPublicaciones_Responsable(Publicaciones_Responsable publicaciones_Responsable)
        {
            Add(publicaciones_Responsable);
            return true;
        }

        public bool UpdatePublicaciones_Responsable(Publicaciones_Responsable publicaciones_Responsable)
        {
            Update(publicaciones_Responsable);
            return true;
        }
    }
}