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
    public class Liquidacion_FinalizacionRepository : SuperType<Liquidacion_Finalizacion>, ILiquidacion_FinalizacionRepository
    {
        private ApplicationDbContext _context;

        public Liquidacion_FinalizacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Liquidacion_FinalizacionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteLiquidacion_Finalizacion(int id_liqfinalizacion)
        {
            Delete(id_liqfinalizacion);
            return true;
        }

        public IEnumerable<Liquidacion_Finalizacion> GetAllLiquidacion_Finalizacion()
        {
            return Get();
        }

        public Liquidacion_Finalizacion GetLiquidacion_FinalizacionDetails(int id_liqfinalizacion)
        {
            return Get(id_liqfinalizacion);
        }

        public bool InsertLiquidacion_Finalizacion(Liquidacion_Finalizacion liquidacion_Finalizacion)
        {
            Add(liquidacion_Finalizacion);
            return true;
        }

        public bool UpdateLiquidacion_Finalizacion(Liquidacion_Finalizacion liquidacion_Finalizacion)
        {
            Update(liquidacion_Finalizacion);
            return true;
        }

        public Liquidacion_Finalizacion GetLiquidacion_FinalizacionByProyecto(int id_asignacionproyecto)
        {
            Expression<Func<Liquidacion_Finalizacion, object>> parameter1 = m => m.ObjProyecto;
            Expression<Func<Liquidacion_Finalizacion, object>>[] parameterArray = new Expression<Func<Liquidacion_Finalizacion, object>>[] { parameter1 };

            return Get(p => p.id_asignacionproyecto == id_asignacionproyecto, parameterArray).FirstOrDefault();
        }
    }
}