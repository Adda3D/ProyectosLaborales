using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Tareas_ModuloRepository : SuperType<Tareas_Modulo>
    {
        private ApplicationDbContext _context;

        public Tareas_ModuloRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Tareas_ModuloRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Tareas_Modulo> GetAllTareas_Modulo()
        {
            return Get();
        }

    }
}