using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_DesignacionRepository : SuperType<Publicaciones_Designacion>, IPublicaciones_DesignacionRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DesignacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DesignacionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_Designacion(int id_designacion)
        {
            Delete(id_designacion);
            return true;
        }

        public IEnumerable<Publicaciones_Designacion> GetAllPublicaciones_Designacion()
        {
            return Get();
        }

        public Publicaciones_Designacion GetPublicaciones_DesignacionDetails(int id_designacion)
        {
            return Get(id_designacion);
        }

        public bool InsertPublicaciones_Designacion(Publicaciones_Designacion publicaciones_Designacion)
        {
            Add(publicaciones_Designacion);
            return true;
        }

        public bool UpdatePublicaciones_Designacion(Publicaciones_Designacion publicaciones_Designacion)
        {
            Update(publicaciones_Designacion);
            return true;
        }

        public Publicaciones_Designacion GetPublicaciones_DesignacionByPublicacion(int id_crearpublicacion)
        {
            return Get(d => d.id_crearpublicacion == id_crearpublicacion).FirstOrDefault();
        }
    }
}