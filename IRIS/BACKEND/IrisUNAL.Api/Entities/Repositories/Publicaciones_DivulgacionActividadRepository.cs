using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_DivulgacionActividadRepository : SuperType<Publicaciones_DivulgacionActividad>, IPublicaciones_DivulgacionActividadRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DivulgacionActividadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DivulgacionActividadRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DivulgacionActividad(int id_actividad)
        {
            Delete(id_actividad);
            return true;
        }

        public IEnumerable<Publicaciones_DivulgacionActividad> GetAllPublicaciones_DivulgacionActividad()
        {
            return Get();
        }

        public Publicaciones_DivulgacionActividad GetPublicaciones_DivulgacionActividadDetails(int id_actividad)
        {
            return Get(id_actividad);
        }

        public bool InsertPublicaciones_DivulgacionActividad(Publicaciones_DivulgacionActividad publicaciones_DivulgacionActividad)
        {
            Add(publicaciones_DivulgacionActividad);
            return true;
        }

        public bool UpdatePublicaciones_DivulgacionActividad(Publicaciones_DivulgacionActividad publicaciones_DivulgacionActividad)
        {
            Update(publicaciones_DivulgacionActividad);
            return true;
        }

        public Publicaciones_DivulgacionActividad GetPublicaciones_DivulgacionActividadByPublicacion(int id_crearpublicacion)
        {
            return Get(d => d.id_crearpublicacion == id_crearpublicacion).FirstOrDefault();
        }
    }
}