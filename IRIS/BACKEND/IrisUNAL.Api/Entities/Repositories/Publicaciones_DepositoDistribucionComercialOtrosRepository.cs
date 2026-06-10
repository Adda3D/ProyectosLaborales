using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_DepositoDistribucionComercialOtrosRepository : SuperType<Publicaciones_DepositoDistribucionComercialOtros>, IPublicaciones_DepositoDistribucionComercialOtrosRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DepositoDistribucionComercialOtrosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DepositoDistribucionComercialOtrosRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DepositoDistribucionComercialOtros(int id_otrosdistribuidores)
        {
            Delete(id_otrosdistribuidores);
            return true;
        }

        public IEnumerable<Publicaciones_DepositoDistribucionComercialOtros> GetAllPublicaciones_DepositoDistribucionComercialOtros()
        {
            return Get();
        }

        public Publicaciones_DepositoDistribucionComercialOtros GetPublicaciones_DepositoDistribucionComercialOtrosDetails(int id_otrosdistribuidores)
        {
            return Get(id_otrosdistribuidores);
        }

        public IEnumerable<Publicaciones_DepositoDistribucionComercialOtros> GetPublicaciones_DepositoDistribucionComercialOtrosNombre(string cd_nmotrosdistribuidores)
        {
            return Get(c => c.nmotrosdistribuidores == cd_nmotrosdistribuidores);
        }

        public bool InsertPublicaciones_DepositoDistribucionComercialOtros(Publicaciones_DepositoDistribucionComercialOtros publicaciones_DepositoDistribucionComercialOtros)
        {
            Add(publicaciones_DepositoDistribucionComercialOtros);
            return true;
        }

        public bool UpdatePublicaciones_DepositoDistribucionComercialOtros(Publicaciones_DepositoDistribucionComercialOtros publicaciones_DepositoDistribucionComercialOtros)
        {
            Update(publicaciones_DepositoDistribucionComercialOtros);
            return true;
        }
    }
}