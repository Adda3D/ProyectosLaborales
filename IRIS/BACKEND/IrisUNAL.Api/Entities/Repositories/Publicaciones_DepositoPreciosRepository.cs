using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_DepositoPreciosRepository : SuperType<Publicaciones_DepositoPrecios>, IPublicaciones_DepositoPreciosRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DepositoPreciosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DepositoPreciosRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DepositoPrecios(int id_precios)
        {
            Delete(id_precios);
            return true;
        }

        public IEnumerable<Publicaciones_DepositoPrecios> GetAllPublicaciones_DepositoPrecios()
        {
            return Get();
        }

        public Publicaciones_DepositoPrecios GetPublicaciones_DepositoPreciosDetails(int id_precios)
        {
            return Get(id_precios);
        }

        public bool InsertPublicaciones_DepositoPrecios(Publicaciones_DepositoPrecios publicaciones_DepositoPrecios)
        {
            Add(publicaciones_DepositoPrecios);
            return true;
        }

        public bool UpdatePublicaciones_DepositoPrecios(Publicaciones_DepositoPrecios publicaciones_DepositoPrecios)
        {
            Update(publicaciones_DepositoPrecios);
            return true;
        }

        public Publicaciones_DepositoPrecios GetPublicaciones_DepositoPreciosByPublicacion(int id_crearpublicacion)
        {
            return Get(p => p.id_crearpublicacion == id_crearpublicacion).FirstOrDefault();
        }
    }
}