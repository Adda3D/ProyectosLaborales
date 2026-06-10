using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_CierreEdicionRepository : SuperType<Publicaciones_CierreEdicion>, IPublicaciones_CierreEdicionRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_CierreEdicionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_CierreEdicionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_CierreEdicion(int id_cierreedicion)
        {
            Delete(id_cierreedicion);
            return true;
        }

        public IEnumerable<Publicaciones_CierreEdicion> GetAllPublicaciones_CierreEdicion()
        {
            return Get();
        }

        public Publicaciones_CierreEdicion GetPublicaciones_CierreEdicionDetails(int id_cierreedicion)
        {
            return Get(id_cierreedicion);
        }

        public bool InsertPublicaciones_CierreEdicion(Publicaciones_CierreEdicion publicaciones_CierreEdicion)
        {
            Add(publicaciones_CierreEdicion);
            return true;
        }

        public bool UpdatePublicaciones_CierreEdicion(Publicaciones_CierreEdicion publicaciones_CierreEdicion)
        {
            Update(publicaciones_CierreEdicion);
            return true;
        }

        public Publicaciones_CierreEdicion GetPublicaciones_CierreEdicionByPublicacion(int id_crearpublicacion)
        {
            return Get(c => c.id_crearpublicacion == id_crearpublicacion).FirstOrDefault();
        }
    }
}