using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPropuesta_TipoPropuestaRepository
    {
        IEnumerable<Propuesta_TipoPropuesta> GetAllPropuesta_TipoPropuesta();
        Propuesta_TipoPropuesta GetPropuesta_TipoPropuestaDetails(int id_tipopropuesta);
        IEnumerable<Propuesta_TipoPropuesta> GetPropuesta_TipoPropuestaDetails(string cd_nmtipopropuesta);
        bool InsertPropuesta_TipoPropuesta(Propuesta_TipoPropuesta propuesta_TipoPropuesta);
        bool UpdatePropuesta_TipoPropuesta(Propuesta_TipoPropuesta propuesta_TipoPropuesta);
        bool DeletePropuesta_TipoPropuesta(int id_tipopropuesta);
        DataTableAdapter<Propuesta_TipoPropuesta> GetDataTablePropuestaTipoPropuesta(DataTableRequest model);
    }
}
