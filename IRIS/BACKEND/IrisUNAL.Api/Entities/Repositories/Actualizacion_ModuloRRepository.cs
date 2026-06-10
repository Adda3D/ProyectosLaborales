using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Actualizacion_ModuloRRepository : SuperType<Actualizacion_ModuloR>, IActualizacion_ModuloRRepository
    {
        private ApplicationDbContext _context;

        public Actualizacion_ModuloRRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Actualizacion_ModuloRRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteActualizacion_ModuloR(int id_actualizacionmodulor)
        {
            Delete(id_actualizacionmodulor);
            return true;
        }

        public Actualizacion_ModuloR GetActualizacion_ModuloRDetails(int id_actualizacionmodulor)
        {
            return Get(id_actualizacionmodulor);
        }

        public IEnumerable<Actualizacion_ModuloR> GetAllActualizacion_ModuloR()
        {
            return Get();
        }

        public bool InsertActualizacion_ModuloR(Actualizacion_ModuloR actualizacion_ModuloR)
        {
            Add(actualizacion_ModuloR);
            return true;
        }

        public bool UpdateActualizacion_ModuloR(Actualizacion_ModuloR actualizacion_ModuloR)
        {
            Update(actualizacion_ModuloR);
            return true;
        }

        public Actualizacion_ModuloR GetActualizacion_ModuloRByProyecto(int id_asignacionproyecto)
        {
            Expression<Func<Actualizacion_ModuloR, object>> parameter1 = m => m.ObjProyecto;
            Expression<Func<Actualizacion_ModuloR, object>>[] parameterArray = new Expression<Func<Actualizacion_ModuloR, object>>[] { parameter1 };

            return Get(p => p.id_asignacionproyecto == id_asignacionproyecto, parameterArray).FirstOrDefault();

        }
    }
}