using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_TipologiaRepository : SuperType<Publicaciones_Tipologia>, IPublicaciones_TipologiaRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_TipologiaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_TipologiaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_Tipologia(int id_tipologia)
        {
            Delete(id_tipologia);
            return true;
        }

        public IEnumerable<Publicaciones_Tipologia> GetAllPublicaciones_Tipologia()
        {
            return Get();
        }

        public Publicaciones_Tipologia GetPublicaciones_TipologiaDetails(int id_tipologia)
        {
            return Get(id_tipologia);
        }

        public bool InsertPublicaciones_Tipologia(Publicaciones_Tipologia publicaciones_Tipologia)
        {
            Add(publicaciones_Tipologia);
            return true;
        }

        public bool UpdatePublicaciones_Tipologia(Publicaciones_Tipologia publicaciones_Tipologia)
        {
            Update(publicaciones_Tipologia);
            return true;
        }
    }
}