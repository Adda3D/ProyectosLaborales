using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_DiagFinalRepository : SuperType<Publicaciones_DiagFinal>, IPublicaciones_DiagFinalRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DiagFinalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DiagFinalRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DiagFinal(int id_diagfinal)
        {
            Delete(id_diagfinal);
            return true;
        }

        public IEnumerable<Publicaciones_DiagFinal> GetAllPublicaciones_DiagFinal()
        {
            return Get();
        }

        public Publicaciones_DiagFinal GetPublicaciones_DiagFinalDetails(int id_diagfinal)
        {
            return Get(id_diagfinal);
        }

        public bool InsertPublicaciones_DiagFinal(Publicaciones_DiagFinal publicaciones_DiagFinal)
        {
            Add(publicaciones_DiagFinal);
            return true;
        }

        public bool UpdatePublicaciones_DiagFinal(Publicaciones_DiagFinal publicaciones_DiagFinal)
        {
            Update(publicaciones_DiagFinal);
            return true;
        }
    }
}