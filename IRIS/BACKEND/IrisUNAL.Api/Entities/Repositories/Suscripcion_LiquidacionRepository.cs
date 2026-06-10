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
    public class Suscripcion_LiquidacionRepository : SuperType<Suscripcion_Liquidacion>, ISuscripcion_LiquidacionRepository
    {
        private ApplicationDbContext _context;

        public Suscripcion_LiquidacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Suscripcion_LiquidacionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteSuscripcion_Liquidacion(int id_suscripcionliquidcion)
        {
            Delete(id_suscripcionliquidcion);
            return true;
        }

        public IEnumerable<Suscripcion_Liquidacion> GetAllSuscripcion_Liquidacion()
        {
            return Get();
        }

        public Suscripcion_Liquidacion GetSuscripcion_LiquidacionDetails(int id_suscripcionliquidcion)
        {
            return Get(id_suscripcionliquidcion);
        }

        public bool InsertSuscripcion_Liquidacion(Suscripcion_Liquidacion suscripcion_Liquidacion)
        {
            Add(suscripcion_Liquidacion);
            return true;
        }

        public bool UpdateSuscripcion_Liquidacion(Suscripcion_Liquidacion suscripcion_Liquidacion)
        {
            Update(suscripcion_Liquidacion);
            return true;
        }

        public Suscripcion_Liquidacion GetSuscripcion_LiquidacionByProyecto(int id_asignacionproyecto)
        {
            Expression<Func<Suscripcion_Liquidacion, object>> parameter1 = m => m.ObjProyecto.entidad;
            Expression<Func<Suscripcion_Liquidacion, object>>[] parameterArray = new Expression<Func<Suscripcion_Liquidacion, object>>[] { parameter1 };

            return Get(p => p.id_asignacionproyecto == id_asignacionproyecto, parameterArray).FirstOrDefault();
        }
    }
}