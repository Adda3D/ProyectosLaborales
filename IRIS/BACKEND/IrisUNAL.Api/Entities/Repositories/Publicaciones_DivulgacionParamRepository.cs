using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_DivulgacionParamRepository : SuperType<Publicaciones_DivulgacionParam>, IPublicaciones_DivulgacionParamRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DivulgacionParamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DivulgacionParamRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DivulgacionParam(int id_divparam)
        {
            Delete(id_divparam);
            return true;
        }

        public IEnumerable<Publicaciones_DivulgacionParam> GetAllPublicaciones_DivulgacionParam()
        {
            return Get();
        }

        public IEnumerable<Publicaciones_DivulgacionParam> GetPublicaciones_DivulgacionParamCodigo(string cd_id_kardex)
        {
            return Get(c => c.id_kardex == cd_id_kardex);
        }

        public Publicaciones_DivulgacionParam GetPublicaciones_DivulgacionParamDetails(int id_divparam)
        {
            return Get(id_divparam);
        }

        public bool InsertPublicaciones_DivulgacionParam(Publicaciones_DivulgacionParam publicaciones_DivulgacionParam)
        {
            Add(publicaciones_DivulgacionParam);
            return true;
        }

        public bool UpdatePublicaciones_DivulgacionParam(Publicaciones_DivulgacionParam publicaciones_DivulgacionParam)
        {
            Update(publicaciones_DivulgacionParam);
            return true;
        }
    }
}