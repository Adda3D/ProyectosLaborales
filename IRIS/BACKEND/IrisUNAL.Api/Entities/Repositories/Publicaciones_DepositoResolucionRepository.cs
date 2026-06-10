using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_DepositoResolucionRepository : SuperType<Publicaciones_DepositoResolucion>, IPublicaciones_DepositoResolucionRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DepositoResolucionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DepositoResolucionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DepositoResolucion(int id_resolucion)
        {
            Delete(id_resolucion);
            return true;
        }

        public IEnumerable<Publicaciones_DepositoResolucion> GetAllPublicaciones_DepositoResolucion()
        {
            return Get();
        }

        public Publicaciones_DepositoResolucion GetPublicaciones_DepositoResolucionDetails(int id_resolucion)
        {
            return Get(id_resolucion);
        }

        public IEnumerable<Publicaciones_DepositoResolucion> GetPublicaciones_DepositoResolucionNumero(string cd_numresolucion)
        {
            return Get(c => c.numresolucion == cd_numresolucion);
        }

        public bool InsertPublicaciones_DepositoResolucion(Publicaciones_DepositoResolucion publicaciones_DepositoResolucion)
        {
            Add(publicaciones_DepositoResolucion);
            return true;
        }

        public bool UpdatePublicaciones_DepositoResolucion(Publicaciones_DepositoResolucion publicaciones_DepositoResolucion)
        {
            Update(publicaciones_DepositoResolucion);
            return true;
        }

        public Publicaciones_DepositoResolucion GetPublicaciones_DepositoResolucionByPublicacion(int id_crearpublicacion)
        {
            return Get(r => r.id_crearpublicacion == id_crearpublicacion).FirstOrDefault();
        }
    }
}