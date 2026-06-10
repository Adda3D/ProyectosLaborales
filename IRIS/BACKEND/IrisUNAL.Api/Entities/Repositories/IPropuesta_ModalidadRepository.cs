using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPropuesta_ModalidadRepository
    {
        IEnumerable<Propuesta_Modalidad> GetAllPropuesta_Modalidad();
        Propuesta_Modalidad GetPropuesta_ModalidadDetails(int id_modalidad);
        IEnumerable<Propuesta_Modalidad> GetPropuesta_ModalidadDetails(string cd_nmmodalidad);
        bool InsertPropuesta_Modalidad(Propuesta_Modalidad propuesta_Modalidad);
        bool UpdatePropuesta_Modalidad(Propuesta_Modalidad propuesta_Modalidad);
        bool DeletePropuesta_Modalidad(int id_modalidad);
        DataTableAdapter<Propuesta_Modalidad> GetDataTablePropuestaModalidad(DataTableRequest model);
    }
}
