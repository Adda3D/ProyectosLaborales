using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_TipoCorreccionRepository : SuperType<Publicaciones_TipoCorreccion>, IPublicaciones_TipoCorreccionRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_TipoCorreccionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_TipoCorreccionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_TipoCorreccion(int id_tipocorreccion)
        {
            Delete(id_tipocorreccion);
            return true;
        }

        public IEnumerable<Publicaciones_TipoCorreccion> GetAllPublicaciones_TipoCorreccion()
        {
            return Get();
        }

        public Publicaciones_TipoCorreccion GetPublicaciones_TipoCorreccionDetails(int id_tipocorreccion)
        {
            return Get(id_tipocorreccion);
        }


        public bool InsertPublicaciones_TipoCorreccion(Publicaciones_TipoCorreccion publicaciones_TipoCorreccion)
        {
            Add(publicaciones_TipoCorreccion);
            return true;
        }

        public bool UpdatePublicaciones_TipoCorreccion(Publicaciones_TipoCorreccion publicaciones_TipoCorreccion)
        {
            Update(publicaciones_TipoCorreccion);
            return true;
        }

        public Publicaciones_TipoCorreccion GetPublicaciones_TipoCorreccionByPublicacion(int id_crearpublicacion)
        {
            return Get(c => c.id_crearpublicacion == id_crearpublicacion).FirstOrDefault();
        }
    }
}