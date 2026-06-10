using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPropuesta_OrigenPropuestaRepository
    {
        IEnumerable<Propuesta_OrigenPropuesta> GetAllPropuesta_OrigenPropuesta();
        Propuesta_OrigenPropuesta GetPropuesta_OrigenPropuestaDetails(int id_origenpropuesta);
        IEnumerable<Propuesta_OrigenPropuesta> GetPropuesta_OrigenPropuestaDetails(string cd_nmorigenpropuesta);
        bool InsertPropuesta_OrigenPropuesta(Propuesta_OrigenPropuesta propuesta_OrigenPropuesta);
        bool UpdatePropuesta_OrigenPropuesta(Propuesta_OrigenPropuesta propuesta_OrigenPropuesta);
        bool DeletePropuesta_OrigenPropuesta(int id_origenpropuesta);
        DataTableAdapter<Propuesta_OrigenPropuesta> GetDataTablePropuestaOrigen(DataTableRequest model);
    }
}
