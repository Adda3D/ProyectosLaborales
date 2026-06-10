using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPropuesta_AprobacionConsejoFacultadRepository
    {
        IEnumerable<Propuesta_AprobacionConsejoFacultad> GetAllPropuesta_AprobacionConsejoFacultad();
        Propuesta_AprobacionConsejoFacultad GetPropuesta_AprobacionConsejoFacultadDetails(int id_aprobacionconsejofacultad);
        IEnumerable<Propuesta_AprobacionConsejoFacultad> GetPropuesta_AprobacionConsejoFacultadDetails(string cd_nmaprconfac);
        bool InsertPropuesta_AprobacionConsejoFacultad(Propuesta_AprobacionConsejoFacultad propuesta_AprobacionConsejoFacultad);
        bool UpdatePropuesta_AprobacionConsejoFacultad(Propuesta_AprobacionConsejoFacultad propuesta_AprobacionConsejoFacultad);
        bool DeletePropuesta_AprobacionConsejoFacultad(int id_aprobacionconsejofacultad);
        DataTableAdapter<Propuesta_AprobacionConsejoFacultad> GetDataTablePropuestaTipoAprobacion(DataTableRequest model);
    }
}
