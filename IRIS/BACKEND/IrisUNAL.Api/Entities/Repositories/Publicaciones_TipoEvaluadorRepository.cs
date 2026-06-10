using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_TipoEvaluadorRepository : SuperType<Publicaciones_TipoEvaluador>, IPublicaciones_TipoEvaluadorRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_TipoEvaluadorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_TipoEvaluadorRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_TipoEvaluador(int id_tipoevaluador)
        {
            Delete(id_tipoevaluador);
            return true;
        }

        public IEnumerable<Publicaciones_TipoEvaluador> GetAllPublicaciones_TipoEvaluador()
        {
            return Get();
        }

        public Publicaciones_TipoEvaluador GetPublicaciones_TipoEvaluadorDetails(int id_tipoevaluador)
        {
            return Get(id_tipoevaluador);
        }        

        public bool InsertPublicaciones_TipoEvaluador(Publicaciones_TipoEvaluador publicaciones_TipoEvaluador)
        {
            Add(publicaciones_TipoEvaluador);
            return true;
        }

        public bool UpdatePublicaciones_TipoEvaluador(Publicaciones_TipoEvaluador publicaciones_TipoEvaluador)
        {
            Update(publicaciones_TipoEvaluador);
            return true;
        }
    }
}