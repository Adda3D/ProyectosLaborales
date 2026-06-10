using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPropuesta_AvalConsejoFacultadRepository
    {
        IEnumerable<Propuesta_AvalConsejoFacultad> GetAllPropuesta_AvalConsejoFacultad();
        Propuesta_AvalConsejoFacultad GetPropuesta_AvalConsejoFacultadDetails(int id_avalconfac);
        Propuesta_AvalConsejoFacultad GetPropuesta_AvalConsejoFacultadDetails(string cd_numeroaval);
        bool InsertPropuesta_AvalConsejoFacultad(Propuesta_AvalConsejoFacultad propuesta_AvalConsejoFacultad);
        bool UpdatePropuesta_AvalConsejoFacultad(Propuesta_AvalConsejoFacultad propuesta_AvalConsejoFacultad);
        bool DeletePropuesta_AvalConsejoFacultad(int id_avalconfac);
        DataTableAdapter<Propuesta_AvalConsejoFacultad> GetDataTablePropuestaAvalConsejoFacultad(DataTableRequest model);
    }
}
