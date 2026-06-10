using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_EstadoCorParamRepository : SuperType<Publicaciones_EstadoCorParam>, IPublicaciones_EstadoCorParamRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_EstadoCorParamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_EstadoCorParamRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_EstadoCorParam(int id_estadocorparam)
        {
            Delete(id_estadocorparam);
            return true;
        }

        public IEnumerable<Publicaciones_EstadoCorParam> GetAllPublicaciones_EstadoCorParam()
        {
            return Get();
        }

        public Publicaciones_EstadoCorParam GetPublicaciones_EstadoCorParamDetails(int id_estadocorparam)
        {
            return Get(id_estadocorparam);
        }

        public bool InsertPublicaciones_EstadoCorParam(Publicaciones_EstadoCorParam publicaciones_EstadoCorParam)
        {
            Add(publicaciones_EstadoCorParam);
            return true;
        }

        public bool UpdatePublicaciones_EstadoCorParam(Publicaciones_EstadoCorParam publicaciones_EstadoCorParam)
        {
            Update(publicaciones_EstadoCorParam);
            return true;
        }

        public Publicaciones_EstadoCorParam GetPublicaciones_EstadoCorParamByPublicacionEtapa(int id_crearpublicacion, string correccionetapa)
        {
            return Get(c => c.id_crearpublicacion == id_crearpublicacion && c.correccionetapa == correccionetapa).FirstOrDefault();
        }
    }
}