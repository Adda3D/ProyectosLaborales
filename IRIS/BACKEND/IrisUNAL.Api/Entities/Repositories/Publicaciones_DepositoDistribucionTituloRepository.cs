using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_DepositoDistribucionTituloRepository : SuperType<Publicaciones_DepositoDistribucionTitulo>, IPublicaciones_DepositoDistribucionTituloRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DepositoDistribucionTituloRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DepositoDistribucionTituloRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DepositoDistribucionTitulo(int id_disttitulo)
        {
            Delete(id_disttitulo);
            return true;
        }

        public IEnumerable<Publicaciones_DepositoDistribucionTitulo> GetAllPublicaciones_DepositoDistribucionTitulo()
        {
            return Get();
        }

        public Publicaciones_DepositoDistribucionTitulo GetPublicaciones_DepositoDistribucionTituloDetails(int id_disttitulo)
        {
            return Get(id_disttitulo);
        }

        public IEnumerable<Publicaciones_DepositoDistribucionTitulo> GetPublicaciones_DepositoDistribucionTituloNombre(string cd_nmtitulo)
        {
            return Get(c => c.nmtitulo == cd_nmtitulo);
        }

        public bool InsertPublicaciones_DepositoDistribucionTitulo(Publicaciones_DepositoDistribucionTitulo publicaciones_DepositoDistribucionTitulo)
        {
            Add(publicaciones_DepositoDistribucionTitulo);
            return true;
        }

        public bool UpdatePublicaciones_DepositoDistribucionTitulo(Publicaciones_DepositoDistribucionTitulo publicaciones_DepositoDistribucionTitulo)
        {
            Update(publicaciones_DepositoDistribucionTitulo);
            return true;
        }
    }
}