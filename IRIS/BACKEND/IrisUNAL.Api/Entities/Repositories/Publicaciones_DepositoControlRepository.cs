using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_DepositoControlRepository : SuperType<Publicaciones_DepositoControl>, IPublicaciones_DepositoControlRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DepositoControlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DepositoControlRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DepositoControl(int id_control)
        {
            Delete(id_control);
            return true;
        }

        public IEnumerable<Publicaciones_DepositoControl> GetAllPublicaciones_DepositoControl()
        {
            return Get();
        }

        public IEnumerable<Publicaciones_DepositoControl> GetPublicaciones_DepositoControlCodigo(string cd_id_kardex)
        {
            return Get(c => c.id_kardex == cd_id_kardex);
        }

        public Publicaciones_DepositoControl GetPublicaciones_DepositoControlDetails(int id_control)
        {
            return Get(id_control);
        }

        public bool InsertPublicaciones_DepositoControl(Publicaciones_DepositoControl publicaciones_DepositoControl)
        {
            Add(publicaciones_DepositoControl);
            return true;
        }

        public bool UpdatePublicaciones_DepositoControl(Publicaciones_DepositoControl publicaciones_DepositoControl)
        {
            Update(publicaciones_DepositoControl);
            return true;
        }
    }
}