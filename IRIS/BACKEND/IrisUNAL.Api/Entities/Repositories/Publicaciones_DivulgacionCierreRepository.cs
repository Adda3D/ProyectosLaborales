using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_DivulgacionCierreRepository : SuperType<Publicaciones_DivulgacionCierre>, IPublicaciones_DivulgacionCierreRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DivulgacionCierreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DivulgacionCierreRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DivulgacionCierre(int id_cierre)
        {
            Delete(id_cierre);
            return true;
        }

        public IEnumerable<Publicaciones_DivulgacionCierre> GetAllPublicaciones_DivulgacionCierre()
        {
            return Get();
        }        

        public Publicaciones_DivulgacionCierre GetPublicaciones_DivulgacionCierreDetails(int id_cierre)
        {
            return Get(id_cierre);
        }

        public bool InsertPublicaciones_DivulgacionCierre(Publicaciones_DivulgacionCierre publicaciones_DivulgacionCierre)
        {
            Add(publicaciones_DivulgacionCierre);
            return true;
        }

        public bool UpdatePublicaciones_DivulgacionCierre(Publicaciones_DivulgacionCierre publicaciones_DivulgacionCierre)
        {
            Update(publicaciones_DivulgacionCierre);
            return true;
        }

        public Publicaciones_DivulgacionCierre GetPublicaciones_DivulgacionCierreByPublicacion(int id_crearpublicacion)
        {
            return Get(d => d.id_crearpublicacion == id_crearpublicacion).FirstOrDefault();
        }
    }
}