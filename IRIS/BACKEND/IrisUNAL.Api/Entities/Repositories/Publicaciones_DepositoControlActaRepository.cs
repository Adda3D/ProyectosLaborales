using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_DepositoControlActaRepository : SuperType<Publicaciones_DepositoControlActa>, IPublicaciones_DepositoControlActaRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DepositoControlActaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DepositoControlActaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DepositoControlActa(int id_actacosto)
        {
            Delete(id_actacosto);
            return true;
        }

        public IEnumerable<Publicaciones_DepositoControlActa> GetAllPublicaciones_DepositoControlActa()
        {
            return Get();
        }

        public Publicaciones_DepositoControlActa GetPublicaciones_DepositoControlActaDetails(int id_actacosto)
        {
            return Get(id_actacosto);
        }

        public bool InsertPublicaciones_DepositoControlActa(Publicaciones_DepositoControlActa publicaciones_DepositoControlActa)
        {
            Add(publicaciones_DepositoControlActa);
            return true;
        }

        public bool UpdatePublicaciones_DepositoControlActa(Publicaciones_DepositoControlActa publicaciones_DepositoControlActa)
        {
            Update(publicaciones_DepositoControlActa);
            return true;
        }

        public Publicaciones_DepositoControlActa GetPublicaciones_DepositoControlActaByPublicacion(int id_crearpublicacion)
        {
            return Get(d => d.id_crearpublicacion == id_crearpublicacion).FirstOrDefault();
        }
    }
}