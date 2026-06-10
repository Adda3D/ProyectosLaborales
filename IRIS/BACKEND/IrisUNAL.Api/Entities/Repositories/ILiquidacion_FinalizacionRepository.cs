using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface ILiquidacion_FinalizacionRepository
    {
        IEnumerable<Liquidacion_Finalizacion> GetAllLiquidacion_Finalizacion();
        Liquidacion_Finalizacion GetLiquidacion_FinalizacionDetails(int id_liqfinalizacion);        
        bool InsertLiquidacion_Finalizacion(Liquidacion_Finalizacion liquidacion_Finalizacion);
        bool UpdateLiquidacion_Finalizacion(Liquidacion_Finalizacion liquidacion_Finalizacion);
        bool DeleteLiquidacion_Finalizacion(int id_liqfinalizacion);
        Liquidacion_Finalizacion GetLiquidacion_FinalizacionByProyecto(int id_asignacionproyecto);
    }
}
