using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_RolEditorialRepository : SuperType<Publicaciones_RolEditorial>, IPublicaciones_RolEditorialRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_RolEditorialRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_RolEditorialRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_RolEditorial(int id_roleditorial)
        {
            Delete(id_roleditorial);
            return true;
        }

        public IEnumerable<Publicaciones_RolEditorial> GetAllPublicaciones_RolEditorial()
        {
            return Get();
        }

        public Publicaciones_RolEditorial GetPublicaciones_RolEditorialDetails(int id_roleditorial)
        {
            return Get(id_roleditorial);
        }

        public IEnumerable<Publicaciones_RolEditorial> GetPublicaciones_RolEditorialNombre(string cd_nmroleditorial)
        {
            return Get(c => c.nmroleditorial == cd_nmroleditorial);
        }

        public bool InsertPublicaciones_RolEditorial(Publicaciones_RolEditorial publicaciones_RolEditorial)
        {
            Add(publicaciones_RolEditorial);
            return true;
        }

        public bool UpdatePublicaciones_RolEditorial(Publicaciones_RolEditorial publicaciones_RolEditorial)
        {
            Update(publicaciones_RolEditorial);
            return true;
        }
    }
}