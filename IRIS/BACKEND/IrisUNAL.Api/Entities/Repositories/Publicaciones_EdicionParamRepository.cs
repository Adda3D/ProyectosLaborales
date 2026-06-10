using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_EdicionParamRepository : SuperType<Publicaciones_EdicionParam>, IPublicaciones_EdicionParamRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_EdicionParamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_EdicionParamRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_EdicionParam(int id_edicionparam)
        {
            Delete(id_edicionparam);
            return true;
        }

        public IEnumerable<Publicaciones_EdicionParam> GetAllPublicaciones_EdicionParam()
        {
            return Get();
        }

        public IEnumerable<Publicaciones_EdicionParam> GetPublicaciones_EdicionParamCodigo(string cd_codhermes)
        {
            return Get(c => c.codhermes == cd_codhermes);
        }

        public Publicaciones_EdicionParam GetPublicaciones_EdicionParamDetails(int id_edicionparam)
        {
            return Get(id_edicionparam);
        }

        public bool InsertPublicaciones_EdicionParam(Publicaciones_EdicionParam publicaciones_EdicionParam)
        {
            Add(publicaciones_EdicionParam);
            return true;
        }

        public bool UpdatePublicaciones_EdicionParam(Publicaciones_EdicionParam publicaciones_EdicionParam)
        {
            Update(publicaciones_EdicionParam);
            return true;
        }
    }
}