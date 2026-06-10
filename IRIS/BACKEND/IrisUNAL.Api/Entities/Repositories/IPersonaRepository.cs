using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPersonaRepository
    {
        IEnumerable<Persona> GetAllPersona();
        Persona GetPersonaDetails(int id_persona);
        Persona GetPersonaIdentificacion(string numidentificacion);
        bool InsertPersona(Persona persona);
        bool UpdatePersona(Persona persona);
        bool DeletePersona(int id_persona);
        DataTableAdapter<Persona> GetDataTablePersona(DataTableRequest model);
        IEnumerable<Persona> GetAllPersonaEvaluador();
    }
}
