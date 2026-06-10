using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_DiagFinalParamRepository : SuperType<Publicaciones_DiagFinalParam>, IPublicaciones_DiagFinalParamRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DiagFinalParamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DiagFinalParamRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DiagFinalParam(int id_diagfinalparam)
        {
            Delete(id_diagfinalparam);
            return true;
        }

        public IEnumerable<Publicaciones_DiagFinalParam> GetAllPublicaciones_DiagFinalParam()
        {
            return Get();
        }

        public Publicaciones_DiagFinalParam GetPublicaciones_DiagFinalParamDetails(int id_diagfinalparam)
        {
            return Get(id_diagfinalparam);
        }

        public IEnumerable<Publicaciones_DiagFinalParam> GetPublicaciones_DiagFinalParamNombre(string cd_responsable)
        {
            return Get(c => c.responsable == cd_responsable);
        }

        public bool InsertPublicaciones_DiagFinalParam(Publicaciones_DiagFinalParam publicaciones_DiagFinalParam)
        {
            Add(publicaciones_DiagFinalParam);
            return true;
        }

        public bool UpdatePublicaciones_DiagFinalParam(Publicaciones_DiagFinalParam publicaciones_DiagFinalParam)
        {
            Update(publicaciones_DiagFinalParam);
            return true;
        }
    }
}