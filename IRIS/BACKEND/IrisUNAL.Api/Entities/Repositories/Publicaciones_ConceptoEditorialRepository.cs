using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_ConceptoEditorialRepository : SuperType<Publicaciones_ConceptoEditorial>, IPublicaciones_ConceptoEditorialRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_ConceptoEditorialRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_ConceptoEditorialRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_ConceptoEditorial(int id_conceptoeditorial)
        {
            Delete(id_conceptoeditorial);
            return true;
        }

        public IEnumerable<Publicaciones_ConceptoEditorial> GetAllPublicaciones_ConceptoEditorial()
        {
            return Get();
        }

        public Publicaciones_ConceptoEditorial GetPublicaciones_ConceptoEditorialDetails(int id_conceptoeditorial)
        {
            return Get(id_conceptoeditorial);
        }

        public bool InsertPublicaciones_ConceptoEditorial(Publicaciones_ConceptoEditorial publicaciones_ConceptoEditorial)
        {
            Add(publicaciones_ConceptoEditorial);
            return true;
        }

        public bool UpdatePublicaciones_ConceptoEditorial(Publicaciones_ConceptoEditorial publicaciones_ConceptoEditorial)
        {
            Update(publicaciones_ConceptoEditorial);
            return true;
        }

        public Publicaciones_ConceptoEditorial GetPublicaciones_ConceptoEditorialByPublicacion(int id_crearpublicacion)
        {
            return Get(p => p.id_crearpublicacion == id_crearpublicacion).FirstOrDefault();
        }
    }
}