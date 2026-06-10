using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPropuesta_SuscripcionMinutaRepository
    {
        IEnumerable<Propuesta_SuscripcionMinuta> GetAllPropuesta_SuscripcionMinuta();
        Propuesta_SuscripcionMinuta GetPropuesta_SuscripcionMinutaByPropuesta(int id_propuesta);
        Propuesta_SuscripcionMinuta GetPropuesta_SuscripcionMinutaDetails(int id_suscripcionminuta);
        Propuesta_SuscripcionMinuta GetPropuesta_SuscripcionMinutaMinuta(string numminuta);
        bool InsertPropuesta_SuscripcionMinuta(Propuesta_SuscripcionMinuta propuesta_SuscripcionMinuta);
        bool UpdatePropuesta_SuscripcionMinuta(Propuesta_SuscripcionMinuta propuesta_SuscripcionMinuta);
        bool DeletePropuesta_SuscripcionMinuta(int id_suscripcionminuta);
        DataTableAdapter<Propuesta_SuscripcionMinuta> GetDataTablePropuestaSuscripcionMinuta(DataTableRequest model);
    }
}
