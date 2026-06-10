using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_CesionDerechosRepository : SuperType<Publicaciones_CesionDerechos>, IPublicaciones_CesionDerechosRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_CesionDerechosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_CesionDerechosRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_CesionDerechos(int id_cesionderechos)
        {
            Delete(id_cesionderechos);
            return true;
        }

        public IEnumerable<Publicaciones_CesionDerechos> GetAllPublicaciones_CesionDerechos()
        {
            return Get();
        }

        public Publicaciones_CesionDerechos GetPublicaciones_CesionDerechosDetails(int id_cesionderechos)
        {
            return Get(id_cesionderechos);
        }

        public bool InsertPublicaciones_CesionDerechos(Publicaciones_CesionDerechos publicaciones_CesionDerechos)
        {
            Add(publicaciones_CesionDerechos);
            return true;
        }

        public bool UpdatePublicaciones_CesionDerechos(Publicaciones_CesionDerechos publicaciones_CesionDerechos)
        {
            Update(publicaciones_CesionDerechos);
            return true;
        }

        public Publicaciones_CesionDerechos GetPublicaciones_CesionDerechosByPublicacion(int id_crearpublicacion)
        {
            return Get(c => c.id_crearpublicacion == id_crearpublicacion).FirstOrDefault();
        }
    }
}