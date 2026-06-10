using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_DivulgacionInicioRepository : SuperType<Publicaciones_DivulgacionInicio>
    {
        private ApplicationDbContext _context;

        public Publicaciones_DivulgacionInicioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DivulgacionInicioRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Publicaciones_DivulgacionInicio> GetAllPublicaciones_DivulgacionInicio()
        {
            return Get();
        }

        public Publicaciones_DivulgacionInicio GetPublicaciones_DivulgacionInicioDetails(int iddivulgacioninicio)
        {
            return Get(iddivulgacioninicio);
        }

        public bool InsertPublicaciones_DivulgacionInicio(Publicaciones_DivulgacionInicio _publicaciones_divulgacioninicio)
        {
            Add(_publicaciones_divulgacioninicio);
            return true;
        }

        public bool UpdatePublicaciones_DivulgacionInicio(Publicaciones_DivulgacionInicio _publicaciones_divulgacioninicio)
        {
            Update(_publicaciones_divulgacioninicio);
            return true;
        }

        public bool DeletePublicaciones_DivulgacionInicio(int iddivulgacioninicio)
        {
            Delete(iddivulgacioninicio);
            return true;
        }

        public Publicaciones_DivulgacionInicio GetPublicaciones_DivulgacionInicioByPublicacion(int id_crearpublicacion)
        {
            return Get(d => d.id_crearpublicacion == id_crearpublicacion).FirstOrDefault();            
        }

    }
}