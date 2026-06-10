using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPersona_TipoServicioRepository
    {
        IEnumerable<Persona_TipoServicio> GetAllPersona_TipoServicio();
        Persona_TipoServicio GetPersona_TipoServicioDetails(int id_tiposervicio);
        Persona_TipoServicio GetPersona_TipoServicioNombre(string nmtiposerv);
        bool InsertPersona_TipoServicio(Persona_TipoServicio persona_TipoServicio);
        bool UpdatePersona_TipoServicio(Persona_TipoServicio persona_TipoServicio);
        bool DeletePersona_TipoServicio(int id_tiposervicio);
        DataTableAdapter<Persona_TipoServicio> GetDataTablePersona_TipoServicio(DataTableRequest model);
    }
}
