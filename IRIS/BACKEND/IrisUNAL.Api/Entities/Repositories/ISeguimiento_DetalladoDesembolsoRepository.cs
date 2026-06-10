using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface ISeguimiento_DetalladoDesembolsoRepository
    {
        IEnumerable<Seguimiento_DetalladoDesembolso> GetAllSeguimiento_DetalladoDesembolso();
        Seguimiento_DetalladoDesembolso GetSeguimiento_DetalladoDesembolsoDetails(int id_detdesembolso);
        IEnumerable<Seguimiento_DetalladoDesembolso> GetSeguimiento_DetalladoDesembolsoCodigo(string cd_codigohermes);
        bool InsertSeguimiento_DetalladoDesembolso(Seguimiento_DetalladoDesembolso seguimiento_DetalladoDesembolso);
        bool UpdateSeguimiento_DetalladoDesembolso(Seguimiento_DetalladoDesembolso seguimiento_DetalladoDesembolso);
        bool DeleteSeguimiento_DetalladoDesembolso(int id_detdesembolso);
    }
}
