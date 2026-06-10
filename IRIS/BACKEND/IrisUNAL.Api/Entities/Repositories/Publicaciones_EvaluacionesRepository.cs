using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_EvaluacionesRepository : SuperType<Publicaciones_Evaluaciones>, IPublicaciones_EvaluacionesRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_EvaluacionesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_EvaluacionesRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_Evaluaciones(int id_evaluaciones)
        {
            Delete(id_evaluaciones);
            return true;
        }

        public IEnumerable<Publicaciones_Evaluaciones> GetAllPublicaciones_Evaluaciones()
        {
            return Get();
        }

        public Publicaciones_Evaluaciones GetPublicaciones_EvaluacionesDetails(int id_evaluaciones)
        {
            return Get(id_evaluaciones);
        }

        public bool InsertPublicaciones_Evaluaciones(Publicaciones_Evaluaciones publicaciones_Evaluaciones)
        {
            Add(publicaciones_Evaluaciones);
            return true;
        }

        public bool UpdatePublicaciones_Evaluaciones(Publicaciones_Evaluaciones publicaciones_Evaluaciones)
        {
            Update(publicaciones_Evaluaciones);
            return true;
        }

        public Publicaciones_Evaluaciones GetPublicaciones_EvaluacionesByPublicacion(int id_crearpublicacion)
        {
            return Get(e => e.id_crearpublicacion == id_crearpublicacion).FirstOrDefault();
        }
    }
}