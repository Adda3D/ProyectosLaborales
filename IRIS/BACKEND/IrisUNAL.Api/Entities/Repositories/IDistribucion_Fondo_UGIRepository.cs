using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDistribucion_Fondo_UGIRepository
    {
        IEnumerable<Distribucion_Fondo_UGI> GetAllDistribucion_Fondo_UGI();
        Distribucion_Fondo_UGI GetDistribucion_Fondo_UGIDetails(int id_fondougi);
        IEnumerable<Distribucion_Fondo_UGI> GetDistribucion_Fondo_UGIDetails(string cd_numeroresolucion);
        bool InsertDistribucion_Fondo_UGI(Distribucion_Fondo_UGI distribucion_Fondo_UGI);
        bool UpdateDistribucion_Fondo_UGI(Distribucion_Fondo_UGI distribucion_Fondo_UGI);
        bool DeleteDistribucion_Fondo_UGI(int id_fondougi);
    }
}
