using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_DiagramacionRepository : SuperType<Publicaciones_Diagramacion>, IPublicaciones_DiagramacionRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DiagramacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DiagramacionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_Diagramacion(int id_diagramacion)
        {
            Delete(id_diagramacion);
            return true;
        }

        public IEnumerable<Publicaciones_Diagramacion> GetAllPublicaciones_Diagramacion()
        {
            return Get();
        }

        public Publicaciones_Diagramacion GetPublicaciones_DiagramacionDetails(int id_diagramacion)
        {
            return Get(id_diagramacion);
        }

        public bool InsertPublicaciones_Diagramacion(Publicaciones_Diagramacion publicaciones_Diagramacion)
        {
            Add(publicaciones_Diagramacion);
            return true;
        }

        public bool UpdatePublicaciones_Diagramacion(Publicaciones_Diagramacion publicaciones_Diagramacion)
        {
            Update(publicaciones_Diagramacion);
            return true;
        }

        public Publicaciones_Diagramacion GetPublicaciones_DiagramacionByPublicacionTipo(int id_crearpublicacion, string tipodiagramacion)
        {
            return Get(d => d.id_crearpublicacion == id_crearpublicacion && d.nmdiagramacion == tipodiagramacion).FirstOrDefault();
        }
    }
}