using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPersona_PaisRepository
    {
        IEnumerable<Persona_Pais> GetAllPersona_Pais();
        Persona_Pais GetPersona_PaisDetails(int id_pais);
        IEnumerable<Persona_Pais> GetPersona_PaisDetails(string nmpais);
        bool InsertPersona_Pais(Persona_Pais persona_Pais);
        bool UpdatePersona_Pais(Persona_Pais persona_Pais);
        bool DeletePersona_Pais(int id_pais);
    }
}
