using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Proyecto_ObservacionRepository : SuperType<Proyecto_Observacion>, IProyecto_ObservacionRepository
    {
        private ApplicationDbContext _context;

        public Proyecto_ObservacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Proyecto_ObservacionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteProyecto_Observacion(int id_proyectoobservacion)
        {
            Delete(id_proyectoobservacion);
            return true;
        }

        public IEnumerable<Proyecto_Observacion> GetAllProyecto_Observacion()
        {
            return Get();
        }

        public Proyecto_Observacion GetProyecto_ObservacionDetails(int id_proyectoobservacion)
        {
            return Get(id_proyectoobservacion);
        }

        public bool InsertProyecto_Observacion(Proyecto_Observacion proyecto_Observacion)
        {
            Add(proyecto_Observacion);
            return true;
        }

        public bool UpdateProyecto_Observacion(Proyecto_Observacion proyecto_Observacion)
        {
            Update(proyecto_Observacion);
            return true;
        }
    }
}