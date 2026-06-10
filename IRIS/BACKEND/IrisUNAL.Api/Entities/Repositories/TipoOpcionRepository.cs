using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class TipoOpcionRepository : SuperType<TipoOpcion>, ITipoOpcionRepository
    {
        private ApplicationDbContext _context;

        public TipoOpcionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public TipoOpcionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteTipoOpcion(int idopcion)
        {
            Delete(idopcion);
            return true;
        }

        public IEnumerable<TipoOpcion> GetAllTipoOpcion()
        {
            return Get();
        }

        public TipoOpcion GetTipoOpcionDetails(int idopcion)
        {
            return Get(idopcion);
        }

        public bool InsertTipoOpcion(TipoOpcion tipoOpcion)
        {
            Add(tipoOpcion);
            return true;
        }

        public bool UpdateTipoOpcion(TipoOpcion tipoOpcion)
        {
            Update(tipoOpcion);
            return true;
        }

        IEnumerable<TipoOpcion> ITipoOpcionRepository.GetTipoOpcionNombre(string cd_nombreopcion)
        {
            return Get(c => c.nombreopcion == cd_nombreopcion);
        }
    }
}