using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_EvalObservacionesRepository : SuperType<Publicaciones_EvalObservaciones>
    {
        private ApplicationDbContext _context;

        public Publicaciones_EvalObservacionesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_EvalObservacionesRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Publicaciones_EvalObservaciones> GetAllPublicaciones_EvalObservaciones()
        {
            return Get();
        }

        public Publicaciones_EvalObservaciones GetPublicaciones_EvalObservacionesByPublicacion(int id_crearpublicacion)
        {
            return Get(c => c.id_crearpublicacion == id_crearpublicacion).FirstOrDefault();
        }

        public Publicaciones_EvalObservaciones GetPublicaciones_EvalObservacionesDetails(int idevalobservacion)
        {
            return Get(idevalobservacion);
        }

        public bool InsertPublicaciones_EvalObservaciones(Publicaciones_EvalObservaciones publicaciones_evalobservaciones)
        {
            Add(publicaciones_evalobservaciones);
            return true;
        }

        public bool UpdatePublicaciones_EvalObservaciones(Publicaciones_EvalObservaciones publicaciones_evalobservaciones)
        {
            Update(publicaciones_evalobservaciones);
            return true;
        }

        public bool DeletePublicaciones_EvalObservaciones(int idevalobservacion)
        {
            Delete(idevalobservacion);
            return true;
        }


    }
}