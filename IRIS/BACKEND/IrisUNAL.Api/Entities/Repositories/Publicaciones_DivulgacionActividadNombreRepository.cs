using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_DivulgacionActividadNombreRepository : SuperType<Publicaciones_DivulgacionActividadNombre>, IPublicaciones_DivulgacionActividadNombreRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DivulgacionActividadNombreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DivulgacionActividadNombreRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DivulgacionActividadNombre(int id_actividadnombre)
        {
            Delete(id_actividadnombre);
            return true;
        }

        public IEnumerable<Publicaciones_DivulgacionActividadNombre> GetAllPublicaciones_DivulgacionActividadNombre()
        {
            return Get();
        }

        public Publicaciones_DivulgacionActividadNombre GetPublicaciones_DivulgacionActividadNombreDetails(int id_actividadnombre)
        {
            return Get(id_actividadnombre);
        }

        public IEnumerable<Publicaciones_DivulgacionActividadNombre> GetPublicaciones_DivulgacionActividadNombreNom(string cd_nomactividadnombre)
        {
            return Get(c => c.nomactividadnombre == cd_nomactividadnombre);
        }

        public bool InsertPublicaciones_DivulgacionActividadNombre(Publicaciones_DivulgacionActividadNombre publicaciones_DivulgacionActividadNombre)
        {
            Add(publicaciones_DivulgacionActividadNombre);
            return true;
        }

        public bool UpdatePublicaciones_DivulgacionActividadNombre(Publicaciones_DivulgacionActividadNombre publicaciones_DivulgacionActividadNombre)
        {
            Update(publicaciones_DivulgacionActividadNombre);
            return true;
        }
    }
}