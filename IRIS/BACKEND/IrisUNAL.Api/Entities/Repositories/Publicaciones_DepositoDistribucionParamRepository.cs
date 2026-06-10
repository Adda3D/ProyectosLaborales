using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_DepositoDistribucionParamRepository : SuperType<Publicaciones_DepositoDistribucionParam>, IPublicaciones_DepositoDistribucionParamRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DepositoDistribucionParamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DepositoDistribucionParamRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DepositoDistribucionParam(int id_distparam)
        {
            Delete(id_distparam);
            return true;
        }

        public IEnumerable<Publicaciones_DepositoDistribucionParam> GetAllPublicaciones_DepositoDistribucionParam()
        {
            return Get();
        }

        public IEnumerable<Publicaciones_DepositoDistribucionParam> GetPublicaciones_DepositoDistribucionParamConsecutivo(string cd_consecutivo)
        {
            return Get(c => c.consecutivo == cd_consecutivo);
        }

        public Publicaciones_DepositoDistribucionParam GetPublicaciones_DepositoDistribucionParamDetails(int id_distparam)
        {
            return Get(id_distparam);
        }

        public bool InsertPublicaciones_DepositoDistribucionParam(Publicaciones_DepositoDistribucionParam publicaciones_DepositoDistribucionParam)
        {
            Add(publicaciones_DepositoDistribucionParam);
            return true;
        }

        public bool UpdatePublicaciones_DepositoDistribucionParam(Publicaciones_DepositoDistribucionParam publicaciones_DepositoDistribucionParam)
        {
            Update(publicaciones_DepositoDistribucionParam);
            return true;
        }
    }
}