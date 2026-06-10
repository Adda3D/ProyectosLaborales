using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_CoedicionRepository : SuperType<Publicaciones_Coedicion>, IPublicaciones_CoedicionRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_CoedicionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_CoedicionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_Coedicion(int id_coedicion)
        {
            Delete(id_coedicion);
            return true;
        }

        public IEnumerable<Publicaciones_Coedicion> GetAllPublicaciones_Coedicion()
        {
            return Get();
        }

        public Publicaciones_Coedicion GetPublicaciones_CoedicionDetails(int id_coedicion)
        {
            return Get(id_coedicion);
        }

        public IEnumerable<Publicaciones_Coedicion> GetPublicaciones_CoedicionNumero(string cd_numcontrato)
        {
            return Get(c => c.numcontrato == cd_numcontrato);
        }

        public bool InsertPublicaciones_Coedicion(Publicaciones_Coedicion publicaciones_Coedicion)
        {
            Add(publicaciones_Coedicion);
            return true;
        }

        public bool UpdatePublicaciones_Coedicion(Publicaciones_Coedicion publicaciones_Coedicion)
        {
            Update(publicaciones_Coedicion);
            return true;
        }
    }
}