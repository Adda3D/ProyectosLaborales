using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_ResenaRepository : SuperType<Publicaciones_Resena>, IPublicaciones_ResenaRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_ResenaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_ResenaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_Resena(int id_resena)
        {
            Delete(id_resena);
            return true;
        }

        public IEnumerable<Publicaciones_Resena> GetAllPublicaciones_Resena()
        {
            return Get();
        }

        public Publicaciones_Resena GetPublicaciones_ResenaDetails(int id_resena)
        {
            return Get(id_resena);
        }

        public IEnumerable<Publicaciones_Resena> GetPublicaciones_ResenaNombre(string cd_nmresena)
        {
            return Get(c => c.nmresena == cd_nmresena);
        }

        public bool InsertPublicaciones_Resena(Publicaciones_Resena publicaciones_Resena)
        {
            Add(publicaciones_Resena);
            return true;
        }

        public bool UpdatePublicaciones_Resena(Publicaciones_Resena publicaciones_Resena)
        {
            Update(publicaciones_Resena);
            return true;
        }
    }
}