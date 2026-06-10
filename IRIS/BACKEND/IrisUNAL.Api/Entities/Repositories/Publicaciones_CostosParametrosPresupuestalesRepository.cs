using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_CostosParametrosPresupuestalesRepository : SuperType<Publicaciones_CostosParametrosPresupuestales>, IPublicaciones_CostosParametrosPresupuestalesRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_CostosParametrosPresupuestalesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_CostosParametrosPresupuestalesRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_CostosParametrosPresupuestales(int id_costopublicacion)
        {
            Delete(id_costopublicacion);
            return true;
        }

        public IEnumerable<Publicaciones_CostosParametrosPresupuestales> GetAllPublicaciones_CostosParametrosPresupuestales()
        {
            return Get();
        }

        public IEnumerable<Publicaciones_CostosParametrosPresupuestales> GetPublicaciones_CostosParametrosPresupuestalesCodigo(string cd_id_kardex)
        {
            return Get(c => c.id_kardex == cd_id_kardex);
        }

        public Publicaciones_CostosParametrosPresupuestales GetPublicaciones_CostosParametrosPresupuestalesDetails(int id_costopublicacion)
        {
            return Get(id_costopublicacion);
        }

        public bool InsertPublicaciones_CostosParametrosPresupuestales(Publicaciones_CostosParametrosPresupuestales publicaciones_CostosParametrosPresupuestales)
        {
            Add(publicaciones_CostosParametrosPresupuestales);
            return true;
        }

        public bool UpdatePublicaciones_CostosParametrosPresupuestales(Publicaciones_CostosParametrosPresupuestales publicaciones_CostosParametrosPresupuestales)
        {
            Update(publicaciones_CostosParametrosPresupuestales);
            return true;
        }
    }
}