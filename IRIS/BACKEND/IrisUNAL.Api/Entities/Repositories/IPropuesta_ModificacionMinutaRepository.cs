using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPropuesta_ModificacionMinutaRepository
    {
        IEnumerable<Propuesta_ModificacionMinuta> GetAllPropuesta_ModificacionMinuta();
        Propuesta_ModificacionMinuta GetPropuesta_ModificacionMinutaDetails(int id_modificacionminuta);
        Propuesta_ModificacionMinuta GetPropuesta_ModificacionMinutaCodigo(string consecutivoremisiondecanatura);
        bool InsertPropuesta_ModificacionMinuta(Propuesta_ModificacionMinuta propuesta_ModificacionMinuta);
        bool UpdatePropuesta_ModificacionMinuta(Propuesta_ModificacionMinuta propuesta_ModificacionMinuta);
        bool DeletePropuesta_ModificacionMinuta(int id_modificacionminuta);
        DataTableAdapter<Propuesta_ModificacionMinuta> GetDataTablePropuestaModificacionMinutaByPropuesta(int id_propuesta, DataTableRequest model);
    }
}
