using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface ISeguimientoHistorico_Conceptos_Literales_UGIRepository
    {
        IEnumerable<SeguimientoHistorico_Conceptos_Literales_UGI> GetAllSeguimientoHistorico_Conceptos_Literales_UGI();
        SeguimientoHistorico_Conceptos_Literales_UGI GetSeguimientoHistorico_Conceptos_Literales_UGIDetails(int id_ejesemugi);
        IEnumerable<SeguimientoHistorico_Conceptos_Literales_UGI> GetSeguimientoHistorico_Conceptos_Literales_UGIDetails(string numeroresolucion);
        bool InsertSeguimientoHistorico_Conceptos_Literales_UGI(SeguimientoHistorico_Conceptos_Literales_UGI seguimientoHistorico_Conceptos_Literales_UGI);
        bool UpdateSeguimientoHistorico_Conceptos_Literales_UGI(SeguimientoHistorico_Conceptos_Literales_UGI seguimientoHistorico_Conceptos_Literales_UGI);
        bool DeleteSeguimientoHistorico_Conceptos_Literales_UGI(int id_ejesemugi);
    }
}
