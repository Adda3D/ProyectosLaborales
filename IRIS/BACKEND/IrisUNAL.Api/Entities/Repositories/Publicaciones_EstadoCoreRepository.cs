using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_EstadoCoreRepository : SuperType<Publicaciones_EstadoCore>, IPublicaciones_EstadoCoreRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_EstadoCoreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_EstadoCoreRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_EstadoCore(int id_estadocore)
        {
            Delete(id_estadocore);
            return true;
        }

        public IEnumerable<Publicaciones_EstadoCore> GetAllPublicaciones_EstadoCore()
        {
            return Get();
        }

        public IEnumerable<Publicaciones_EstadoCore> GetPublicaciones_EstadoCoreCodigo(string cd_id_kardex)
        {
            return Get(c => c.id_kardex == cd_id_kardex);
        }

        public Publicaciones_EstadoCore GetPublicaciones_EstadoCoreDetails(int id_estadocore)
        {
            return Get(id_estadocore);
        }

        public bool InsertPublicaciones_EstadoCore(Publicaciones_EstadoCore publicaciones_EstadoCore)
        {
            Add(publicaciones_EstadoCore);
            return true;
        }

        public bool UpdatePublicaciones_EstadoCore(Publicaciones_EstadoCore publicaciones_EstadoCore)
        {
            Update(publicaciones_EstadoCore);
            return true;
        }
    }
}