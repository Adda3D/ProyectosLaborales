using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPersona_GeneroRepository
    {
        IEnumerable<Persona_Genero> GetAllPersona_Genero();
        Persona_Genero GetPersona_GeneroDetails(int id_genero);
        IEnumerable<Persona_Genero> GetPersona_GeneroDetails(string nmgenero);
        bool InsertPersona_Genero(Persona_Genero persona_Genero);
        bool UpdatePersona_Genero(Persona_Genero persona_Genero);
        bool DeletePersona_Genero(int id_genero);
    }
}
