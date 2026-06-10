using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface ISuscripcion_LiquidacionRepository
    {
        IEnumerable<Suscripcion_Liquidacion> GetAllSuscripcion_Liquidacion();
        Suscripcion_Liquidacion GetSuscripcion_LiquidacionDetails(int id_suscripcionliquidcion);        
        bool InsertSuscripcion_Liquidacion(Suscripcion_Liquidacion suscripcion_Liquidacion);
        bool UpdateSuscripcion_Liquidacion(Suscripcion_Liquidacion suscripcion_Liquidacion);
        bool DeleteSuscripcion_Liquidacion(int id_suscripcionliquidcion);
        Suscripcion_Liquidacion GetSuscripcion_LiquidacionByProyecto(int id_asignacionproyecto);
    }
} 