using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPersona_TipoEntidadRepository
    {
        IEnumerable<Persona_TipoEntidad> GetAllPersona_TipoEntidad();
        Persona_TipoEntidad GetPersona_TipoEntidadDetails(int id_tipoentidad);
        Persona_TipoEntidad GetPersona_TipoEntidadNombre(string nmtipoent);
        bool InsertPersona_TipoEntidad(Persona_TipoEntidad persona_TipoEntidad);
        bool UpdatePersona_TipoEntidad(Persona_TipoEntidad persona_TipoEntidad);
        bool DeletePersona_TipoEntidad(int id_tipoentidad);
        DataTableAdapter<Persona_TipoEntidad> GetDataTablePersona_TipoEntidad(DataTableRequest model);
    }
}
