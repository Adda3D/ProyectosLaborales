using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class RolMenuOpcionesRepository : SuperType<RolMenuOpciones>, IRolMenuOpcionesRepository
    {
        private ApplicationDbContext _context;

        public RolMenuOpcionesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public RolMenuOpcionesRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteRolMenuOpciones(int idrolmenuopciones)
        {
            Delete(idrolmenuopciones);
            return true;
        }

        public IEnumerable<RolMenuOpciones> GetAllRolMenuOpciones()
        {
            return Get();
        }

        public RolMenuOpciones GetRolMenuOpcionesDetails(int idrolmenuopciones)
        {
            return Get(idrolmenuopciones);
        }

        public bool InsertRolMenuOpciones(RolMenuOpciones rolMenuOpciones)
        {
            Add(rolMenuOpciones);
            return true;
        }

        public bool UpdateRolMenuOpciones(RolMenuOpciones rolMenuOpciones)
        {
            Update(rolMenuOpciones);
            return true;
        }
    }
}