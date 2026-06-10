using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface ITipoOpcionRepository
    {
        IEnumerable<TipoOpcion> GetAllTipoOpcion();
        TipoOpcion GetTipoOpcionDetails(int idopcion);
        IEnumerable<TipoOpcion> GetTipoOpcionNombre(string cd_nombreopcion);
        bool InsertTipoOpcion(TipoOpcion tipoOpcion);
        bool UpdateTipoOpcion(TipoOpcion tipoOpcion);
        bool DeleteTipoOpcion(int idopcion);
    }
}
