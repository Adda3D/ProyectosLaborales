using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_DivulgacionMaillingRepository : SuperType<Publicaciones_DivulgacionMailling>, IPublicaciones_DivulgacionMaillingRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DivulgacionMaillingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DivulgacionMaillingRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DivulgacionMailling(int id_mailling)
        {
            Delete(id_mailling);
            return true;
        }

        public IEnumerable<Publicaciones_DivulgacionMailling> GetPublicaciones_DivulgacionMaillingCodigo(string cd_id_kardex)
        {
            return Get(c=>c.id_kardex==cd_id_kardex);
        }

        public Publicaciones_DivulgacionMailling GetPublicaciones_DivulgacionMaillingDetails(int id_mailling)
        {
            return Get(id_mailling);
        }

        public IEnumerable<Publicaciones_DivulgacionMailling> GetAllPublicaciones_DivulgacionMailling()
        {
            return Get();
        }

        public bool InsertPublicaciones_DivulgacionMailling(Publicaciones_DivulgacionMailling publicaciones_DivulgacionMailling)
        {
            Add(publicaciones_DivulgacionMailling);
            return true;
        }

        public bool UpdatePublicaciones_DivulgacionMailling(Publicaciones_DivulgacionMailling publicaciones_DivulgacionMailling)
        {
            Update(publicaciones_DivulgacionMailling);
            return true;
        }
    }
}