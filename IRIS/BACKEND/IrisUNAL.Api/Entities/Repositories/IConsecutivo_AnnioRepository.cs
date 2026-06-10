using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IConsecutivo_AnnioRepository
    {
        string GetConsecutivo_Annio(int id_prefijoconsecutivo, DateTime fecha);
        bool InsertConsecutivo_Annio(Consecutivo_Annio consecutivo_Annio);
        bool UpdateConsecutivo_Annio(Consecutivo_Annio consecutivo_Annio);
    }
}
