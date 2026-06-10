using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_DigitalizacionRepository : SuperType<Publicaciones_Digitalizacion>, IPublicaciones_DigitalizacionRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DigitalizacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DigitalizacionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_Digitalizacion(int id_digitalizacion)
        {
            Delete(id_digitalizacion);
            return true;
        }

        public IEnumerable<Publicaciones_Digitalizacion> GetAllPublicaciones_Digitalizacion()
        {
            return Get();
        }

        public Publicaciones_Digitalizacion GetPublicaciones_DigitalizacionDetails(int id_digitalizacion)
        {
            return Get(id_digitalizacion);
        }

        public bool InsertPublicaciones_Digitalizacion(Publicaciones_Digitalizacion publicaciones_Digitalizacion)
        {
            Add(publicaciones_Digitalizacion);
            return true;
        }

        public bool UpdatePublicaciones_Digitalizacion(Publicaciones_Digitalizacion publicaciones_Digitalizacion)
        {
            Update(publicaciones_Digitalizacion);
            return true;
        }

        public Publicaciones_Digitalizacion GetPublicaciones_DigitalizacionByPublicacion(int id_crearpublicacion)
        {
            return Get(d => d.id_crearpublicacion == id_crearpublicacion).FirstOrDefault();
        }
    }
}