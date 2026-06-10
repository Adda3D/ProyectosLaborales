using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPropuesta_EstadoPropuestaRepository
    {
        IEnumerable<Propuesta_EstadoPropuesta> GetAllPropuesta_EstadoPropuesta();
        Propuesta_EstadoPropuesta GetPropuesta_EstadoPropuestaDetails(int id_estadopropuesta);
        IEnumerable<Propuesta_EstadoPropuesta> GetPropuesta_EstadoPropuestaDetails(string cd_nmestadopropuesta);
        bool InsertPropuesta_EstadoPropuesta(Propuesta_EstadoPropuesta propuesta_EstadoPropuesta);
        bool UpdatePropuesta_EstadoPropuesta(Propuesta_EstadoPropuesta propuesta_EstadoPropuesta);
        bool DeletePropuesta_EstadoPropuesta(int id_estadopropuesta);
        DataTableAdapter<Propuesta_EstadoPropuesta> GetDataTablePropuestaEstado(DataTableRequest model);
    }
}
