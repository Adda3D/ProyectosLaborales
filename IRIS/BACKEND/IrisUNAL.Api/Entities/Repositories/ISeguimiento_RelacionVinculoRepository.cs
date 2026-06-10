using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface ISeguimiento_RelacionVinculoRepository
    {
        IEnumerable<Seguimiento_RelacionVinculo> GetAllSeguimiento_RelacionVinculo();
        Seguimiento_RelacionVinculo GetSeguimiento_RelacionVinculoDetails(int id_relacionvinculo);
        IEnumerable<Seguimiento_RelacionVinculo> GetSeguimiento_RelacionVinculoNombre(string nombrerelacionvinculo);
        bool InsertSeguimiento_RelacionVinculo(Seguimiento_RelacionVinculo seguimiento_RelacionVinculo);
        bool UpdateSeguimiento_RelacionVinculo(Seguimiento_RelacionVinculo seguimiento_RelacionVinculo);
        bool DeleteSeguimiento_RelacionVinculo(int id_relacionvinculo);
    }
}
