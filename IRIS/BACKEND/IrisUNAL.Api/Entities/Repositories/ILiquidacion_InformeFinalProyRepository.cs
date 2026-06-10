using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface ILiquidacion_InformeFinalProyRepository
    {
        IEnumerable<Liquidacion_InformeFinalProy> GetAllLiquidacion_InformeFinalProy();
        Liquidacion_InformeFinalProy GetLiquidacion_InformeFinalProyDetails(int id_informefinalproy);
        IEnumerable<Liquidacion_InformeFinalProy> GetLiquidacion_InformeFinalProyNombre(string nominformefinalproy);
        bool InsertLiquidacion_InformeFinalProy(Liquidacion_InformeFinalProy liquidacion_InformeFinalProy);
        bool UpdateLiquidacion_InformeFinalProy(Liquidacion_InformeFinalProy liquidacion_InformeFinalProy);
        bool DeleteLiquidacion_InformeFinalProy(int id_informefinalproy);
    }
}
