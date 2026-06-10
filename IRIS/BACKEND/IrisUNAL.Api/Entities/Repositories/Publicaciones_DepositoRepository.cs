using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_DepositoRepository : SuperType<Publicaciones_Deposito>, IPublicaciones_DepositoRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DepositoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DepositoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_Deposito(int id_deposito)
        {
            Delete(id_deposito);
            return true;
        }

        public IEnumerable<Publicaciones_Deposito> GetAllPublicaciones_Deposito()
        {
            return Get();
        }

        public IEnumerable<Publicaciones_Deposito> GetPublicaciones_DepositoCodigo(string cd_id_kardex)
        {
            return Get(c => c.id_kardex == cd_id_kardex);
        }

        public Publicaciones_Deposito GetPublicaciones_DepositoDetails(int id_deposito)
        {
            return Get(id_deposito);
        }

        public bool InsertPublicaciones_Deposito(Publicaciones_Deposito publicaciones_Deposito)
        {
            Add(publicaciones_Deposito);
            return true;
        }

        public bool UpdatePublicaciones_Deposito(Publicaciones_Deposito publicaciones_Deposito)
        {
            Update(publicaciones_Deposito);
            return true;
        }
    }
}