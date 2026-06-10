using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPropuesta_TipoModificacionRepository
    {
        IEnumerable<Propuesta_TipoModificacion> GetAllPropuesta_TipoModificacion();
        Propuesta_TipoModificacion GetPropuesta_TipoModificacionDetails(int id_tipomodificacion);
        Propuesta_TipoModificacion GetPropuesta_TipoModificacionDetails(string nmtipomodificacion);
        bool InsertPropuesta_TipoModificacion(Propuesta_TipoModificacion propuesta_TipoModificacion);
        bool UpdatePropuesta_TipoModificacion(Propuesta_TipoModificacion propuesta_TipoModificacion);
        bool DeletePropuesta_TipoModificacion(int id_tipomodificacion);
        DataTableAdapter<Propuesta_TipoModificacion> GetDataTablePropuestaSuscripcionMinuta(DataTableRequest model);
    }
}
